using ATRI.Protocol.Raknet;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Net;
using System;
using ATRI.RakNet.Protocol.Raknet;
using ATRI.Protocol.Raknet.Utils.Cryptography;
using ATRI.Protocol.Raknet.Utils;
using System.IO.Compression;
using ATRI.RakNet.Bedrock;
using ATRI.RakNet.Network;
using ATRI.Protocol.MC;
using static System.Runtime.InteropServices.JavaScript.JSType;
using test;
using static System.Collections.Specialized.BitVector32;
namespace ATRI.Network
{

    public class RaknetSession
    {
        public IPEndPoint PeerEndPoint { get; private set; }
        public bool IsUseEncryption { get; set; } = false;
        public bool IsInitCompression { get; set; } = false;
        private static readonly Dictionary<int, List<(Type, Delegate)>> Listeners = new Dictionary<int, List<(Type, Delegate)>>();
        public PlayerInfo PlayerInfo { get; set; }
        public Thread SenderThread;
        public byte rak_version;
        public Timer PingTimer;
        public bool Connected;
        public RecvQ Recvq;
        public SendQ Sendq;
        public CryptoContext CryptoContext = null ;
        public int Send_Tick { get; set; } = 100;
        private readonly AsyncUdpClient Socket;
        private bool thrownUnkownPackets;
        public int MaxRepingCount = 6;
        private int repingCount;
        private ulong guid;
        public RaknetClient raknetClient;
        public delegate void SessionDisconnectedDelegate(RaknetSession session);
        public SessionDisconnectedDelegate SessionDisconnected = delegate { };

        public delegate void PacketReceiveBytesDelegate(IPEndPoint address, byte[] bytes);
        public PacketReceiveBytesDelegate SessionReceiveRaw = delegate { };
        
        public RaknetSession(AsyncUdpClient Socket, IPEndPoint Address, ulong guid, byte rakVersion, RecvQ recvQ, SendQ sendQ, bool thrownUnkownPackets = false)
        {
            this.Socket = Socket;
            PeerEndPoint = Address;
            this.guid = guid;
            Connected = true;
            this.thrownUnkownPackets = thrownUnkownPackets;

            rak_version = rakVersion;

            Sendq = sendQ;
            Recvq = recvQ;

            StartPing();
            SenderThread = StartSender();
        }
        public void HandleFrameSet(IPEndPoint peer_addr, byte[] data)
        {
            if (!Connected)
            {
                foreach (FrameSetPacket f in Recvq.Flush(peer_addr))
                {
                    HandleFrame(peer_addr, f);
                }
            }

            RaknetReader stream = new RaknetReader(data);
            byte headerFlags = stream.ReadU8();
            switch ((PacketID)headerFlags)
            {
                case PacketID.Nack:
                    {
                        //Console.WriteLine("Nack");
                        lock (Sendq)
                        {
                            Nack nack = RakNetNativePacket.ReadPacketNack(data);
                            for (int i = 0; i < nack.record_count; i++)
                            {
                                if (nack.sequences[i].Start == nack.sequences[i].End)
                                {
                                    Sendq.Nack(nack.sequences[i].Start, Common.CurTimestampMillis());
                                }
                                else
                                {
                                    for (uint j = nack.sequences[i].Start; j <= nack.sequences[i].End; j++)
                                    {
                                        Sendq.Nack(j, Common.CurTimestampMillis());
                                    }
                                }
                            }
                        }

                        break;
                    }
                case PacketID.Ack:
                    {
                        //Console.WriteLine("Ack");
                        lock (Sendq)
                        {
                            Ack ack = RakNetNativePacket.ReadPacketAck(data);
                            for (int i = 0; i < ack.record_count; i++)
                            {
                                if (ack.sequences[i].Start == ack.sequences[i].End)
                                {
                                    Sendq.Ack(ack.sequences[i].Start, Common.CurTimestampMillis());
                                }
                                else
                                {
                                    for (uint j = ack.sequences[i].Start; j <= ack.sequences[i].End; j++)
                                    {
                                        Sendq.Ack(j, Common.CurTimestampMillis());
                                    }
                                }
                            }
                        }

                        break;
                    }
                default:
                    {
                        if ((PacketID)data[0] >= PacketID.FrameSetPacketBegin 
                            && (PacketID)data[0] <= PacketID.FrameSetPacketEnd)
                        {
                            var frames = new FrameVec(data);
                            lock (Recvq)
                            {
                                foreach (var frame in frames.frames)
                                {
                                    Recvq.Insert(frame);
                                    foreach (FrameSetPacket f in Recvq.Flush(peer_addr))
                                    {
                                        HandleFrame(peer_addr, f);
                                    }
                                }
                            }
                            var acks = Recvq.GetAck();
                            if (acks.Count != 0)
                            {
                                Ack packet = new Ack
                                {
                                    record_count = (ushort)acks.Count,
                                    sequences = acks,
                                };
                                byte[] buf = RakNetNativePacket.WritePacketAck(packet);
                                Socket.Send(peer_addr, buf);
                            }
                        }
                        break;
                    }
            }
        }

        public void HandleFrame(IPEndPoint address, FrameSetPacket frame)
        {
            PacketID packetID = (PacketID)frame.data[0];
            switch (packetID)
            {
                case PacketID.ConnectedPing:
                    HandleConnectPing(frame.data);
                    break;
                case PacketID.ConnectedPong:
                    repingCount = 0;
                    break;
                case PacketID.ConnectionRequest:
                    HandleConnectionRequest(address, frame.data);
                    break;
                case PacketID.ConnectionRequestAccepted:
                    HandleConnectionRequestAccepted(frame.data);
                    break;
                case PacketID.NewIncomingConnection:
                    break;
                case PacketID.Disconnect:
                    HandleDisconnectionNotification();
                    break;
                case PacketID.Game:
                    HandleGamePacket(frame.data);
                    break;
                default:
                    SessionReceiveRaw(address, frame.data);
                    //HandleIncomingPacket(frame.data);
                    break;
            }
        }
        public static byte[] MicrosoftCompress(byte[] data)
        {
            MemoryStream uncompressed = new MemoryStream(data); 
            MemoryStream compressed = new MemoryStream();
            DeflateStream deflateStream = new DeflateStream(compressed, CompressionMode.Compress, false); 
            uncompressed.CopyTo(deflateStream); 
            deflateStream.Close(); 
            byte[] result = compressed.ToArray();
            return result;
        }
       public void Disconnect(string text)
        {
            MCPE_DISCONNECT mCPE_DISCONNECT = new MCPE_DISCONNECT();
            mCPE_DISCONNECT.message = text;
            SendPacket(mCPE_DISCONNECT);
        }
        public void SendPacketDirect(byte[] da)
        {
            lock (Sendq)
            {
                Sendq.Insert(Reliability.ReliableOrdered, da);
            }
        }
        public unsafe void SendPacket(Packet packet,bool isDirect = false, byte Header_others = 0x00,bool first_use_compress = false,bool is_use_enynpt = false)
        {
            
            byte game_packet_id = 0xfe;
            byte[] data_ = packet.Serialize();
            RaknetWriter raknetWriter = new RaknetWriter();
            raknetWriter.WriteU8(game_packet_id);
            if(Header_others != 0x00)
            {
                raknetWriter.WriteU8(Header_others);
            }
            if (isDirect) {
                raknetWriter.Write(data_);
                lock (Sendq)
                {
                    Sendq.Insert(Reliability.ReliableOrdered, raknetWriter.GetRawPayload());
                }
                return;
            }
            MemoryStream stream = new MemoryStream();
            MemoryStream memoryStream = new MemoryStream();
            VarInt.WriteUInt32(memoryStream, (uint)data_.Length);
            memoryStream.Write(data_, 0, data_.Length);
            memoryStream.Flush();
            if (IsInitCompression == true|| first_use_compress == true || is_use_enynpt)
            {
                
                byte[] compress = MicrosoftCompress(memoryStream.ToArray());
               
                if (IsUseEncryption && !is_use_enynpt)
                {
                    List<byte> bytes = new List<byte>();
                    bytes.Add(0x00);
                    bytes.AddRange(compress);
                    var data = CryptoUtils.Encrypt(bytes.ToArray(),CryptoContext);
                    stream.Write(data);
                    stream.Flush();
                    raknetWriter.Write(stream.ToArray());
                }
                else
                {
                    stream.WriteByte(0x00);
                    stream.Write(compress);
                    stream.Flush();
                    raknetWriter.Write(stream.ToArray());
                }
            }
            else
            {
                raknetWriter.WriteU8(game_packet_id);
                raknetWriter.WriteU8((byte)0x01);
                raknetWriter.Write(memoryStream.ToArray());
            }
            lock (Sendq)
            {
                Sendq.Insert(Reliability.ReliableOrdered,raknetWriter.GetRawPayload());
            }
            memoryStream.Dispose();
            stream.Dispose();
        }
        
        private unsafe void HandleGamePacket(byte[] data)
        {

            //Skip header 0xfe
            byte[] rec = data.Skip(1).ToArray();
            ReadOnlyMemory<byte> memory = rec;
            if (data == null || data.Length == 0)
                return;
            if (IsUseEncryption != false)
            {
                memory = CryptoUtils.Decrypt(memory,CryptoContext).ToArray().Skip(1).ToArray();
            }

            ///Console.WriteLine(*ptr2);
            if ((memory.ToArray())[0] == 0x00)
            {
                IsInitCompression = true;
                byte[] R_data = DeCompress(memory.ToArray().Skip(1).ToArray());
                MemoryStream stream = new MemoryStream(R_data);
                BedrockMessagePacketHandle.HandleBedrockMessage(RegisterPacket.CreatObj(VarInt.ReadInt32(stream)), R_data, PeerEndPoint, this);
                stream.Dispose();
                return;
            }
            else
            {

                byte[] R_data = memory.ToArray().Skip(1).ToArray();
                MemoryStream stream = new MemoryStream(R_data);
                BedrockMessagePacketHandle.HandleBedrockMessage(RegisterPacket.CreatObj(VarInt.ReadInt32(stream)),R_data,PeerEndPoint,this);
                stream.Dispose();
                return;
            }
        }
        private byte[] DeCompress(byte[] bytesaa)
        {
            var stream = new MemoryStream(bytesaa);
            using var mem = new MemoryStream();
            using (var DeflateStream = new System.IO.Compression.DeflateStream(stream, CompressionMode.Decompress, false))
            {

                DeflateStream.CopyTo(mem);
                DeflateStream.Dispose();
            }
            byte[] bytes1 = mem.ToArray();
            mem.Dispose();
            stream.Dispose();
            var memss = new MemoryStream(bytes1);
            uint test_data = VarInt.ReadUInt32(memss);
            memss.Position = memss.Length - test_data;
            byte[] bytes = new byte[test_data];
            memss.Read(bytes, 0, (int)test_data);
            return bytes;
        }
        //private void HandleIncomingPacket(byte[] buffer) {
        //    byte packetID = buffer[0];
        //    bool exists = Listeners.TryGetValue(packetID, out List<(Type, Delegate)> value);
        //    if (!exists) return;
        //    foreach((Type, Delegate) registration in value)
        //    {
        //        Delegate callback = registration.Item2;
        //        Type packetType = registration.Item1;
        //        MethodInfo method = packetType.GetMethod("Deserialize");
        //        if (method == null) return;
        //        object packet = Activator.CreateInstance(packetType, new object[] { buffer });
        //        method.Invoke(packet, new object[] {});
        //        callback.DynamicInvoke(packet);
        //    }
        //}

        private void HandleConnectPing(byte[] data)
        {
            ConnectedPing pingPacket = RakNetNativePacket.ReadPacketConnectedPing(data);
            ConnectedPong pongPacket = new ConnectedPong
            {
                client_timestamp = pingPacket.client_timestamp,
                server_timestamp = Common.CurTimestampMillis(),
            };

            byte[] buf = RakNetNativePacket.WritePacketConnectedPong(pongPacket);
            lock (Sendq)
                Sendq.Insert(Reliability.Unreliable, buf);
        }

        private void HandleConnectionRequestAccepted(byte[] data)
        {
            ConnectionRequestAccepted packet = RakNetNativePacket.ReadPacketConnectionRequestAccepted(data);
#pragma warning disable CS8601 // 引用类型赋值可能为 null。
            NewIncomingConnection packet_reply = new NewIncomingConnection
            {
                server_address = (IPEndPoint)Socket.Socket.Client.LocalEndPoint,
                request_timestamp = packet.request_timestamp,
                accepted_timestamp = Common.CurTimestampMillis(),
            };
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
            byte[] buf = RakNetNativePacket.WritePacketNewIncomingConnection(packet_reply);
            lock (Sendq)
                Sendq.Insert(Reliability.ReliableOrdered, buf);
        }

        private void HandleConnectionRequest(IPEndPoint peer_addr, byte[] data)
        {
            ConnectionRequest packet = RakNetNativePacket.ReadPacketConnectionRequest(data);
            ConnectionRequestAccepted packet_reply = new ConnectionRequestAccepted
            {
                client_address = peer_addr,
                system_index = 0,
                request_timestamp = packet.time,
                accepted_timestamp = Common.CurTimestampMillis(),
            };
            byte[] buf = RakNetNativePacket.WritePacketConnectionRequestAccepted(packet_reply);
            lock (Sendq)
                Sendq.Insert(Reliability.ReliableOrdered, buf);
            
        }
        private bool isThreadStart = true;
        public void StopSender()
        {
            isThreadStart = false;
            SenderThread = null;
        }
        private void HandleDisconnectionNotification()
        {
            Connected = false;
            StopSender();
            PingTimer.Dispose();
            SessionDisconnected(this);
            try{BedrockMessagePacketHandle.Crypto.Remove(PeerEndPoint);}catch { }
            GC.Collect();
            if (PlayerInfo!=null)
            {
                Logger.INFO($"Player {PlayerInfo.Username} UUID: {PlayerInfo.ClientUuid} Client: {PlayerInfo.DeviceModel} disconnecting!");
            }
        }

        public void HandleConnect()
        {
            ConnectionRequest requestPacket = new ConnectionRequest
            {
                guid = guid,
                time = Common.CurTimestampMillis(),
                use_encryption = 0x01,
            };
            byte[] buf = RakNetNativePacket.WritePacketConnectionRequest(requestPacket);
            lock (Sendq)
                Sendq.Insert(Reliability.ReliableOrdered, buf);
        }

        public Thread StartSender()
        {
            Thread thread = new Thread(() => 
            {
                while (true)
                {

                    if (!isThreadStart)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                    foreach (FrameSetPacket item in Sendq.Flush(Common.CurTimestampMillis(), PeerEndPoint))
                    {
                        byte[] sdata = item.Serialize();
                        Socket.Send(PeerEndPoint, sdata);
                    }
                }
            });
            thread.Start();
            return thread;
        }

        public void StartPing()
        {
#pragma warning disable CS8622 // 参数类型中引用类型的为 Null 性与目标委托不匹配(可能是由于为 Null 性特性)。
            PingTimer = new Timer(SendPing, null,
                new Random().Next(1000, 1500), new Random().Next(1000, 1500));
#pragma warning restore CS8622 // 参数类型中引用类型的为 Null 性与目标委托不匹配(可能是由于为 Null 性特性)。
        }

        public void SendPing(object obj)
        {
            if (!Connected) return;
            ConnectedPing pingPacket = new ConnectedPing
            {
                client_timestamp = Common.CurTimestampMillis(),
            };

            byte[] buffer = RakNetNativePacket.WritePacketConnectedPing(pingPacket);
            lock (Sendq)
                Sendq.Insert(Reliability.Unreliable, buffer);

            repingCount++;
            if (repingCount < MaxRepingCount) return;

            HandleDisconnectionNotification();
        }
    }
}
