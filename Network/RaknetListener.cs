using ATRI.Protocol.Raknet;

using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Net;
using System;
using ATRI.RakNet.Protocol.Raknet;
using ATRI.Protocol.Bedrock;
namespace ATRI.Network
{
    public class RaknetListener
    {
        public delegate void SessionConnectedDelegate(RaknetSession session);
        public SessionConnectedDelegate SessionConnected = delegate { };
        public AsyncUdpClient Socket;

        private static readonly Dictionary<int, List<(Type, Delegate)>> Listeners = new Dictionary<int, List<(Type, Delegate)>>();
        private Dictionary<IPEndPoint, RaknetSession> Sessions = new Dictionary<IPEndPoint, RaknetSession>();

        private byte rak_version = 0xB;
        private ulong guid;
        private MotdProvider motd;
        public RaknetListener(IPEndPoint address,MotdProvider motd)
        {
            Socket = new AsyncUdpClient(address);
            Socket.PacketReceived += OnPacketReceived;
            SessionConnected += OnSessionEstablished;
            byte[] buffer = new byte[8];
            new Random().NextBytes(buffer);
            guid = (ulong)BitConverter.ToInt64(buffer, 0);
            this.motd = motd;
        }
       
        private void OnSessionEstablished(RaknetSession session)
        {
            session.SessionReceiveRaw += OnPacketReceived;
            session.SessionDisconnected += RemoveSession;
        }

        void RemoveSession(RaknetSession session)
        {
            session.SessionReceiveRaw -= OnPacketReceived;
            IPEndPoint peerAddr = session.PeerEndPoint;

            lock(Sessions)
                Sessions.Remove(peerAddr);
        }

        private void OnPacketReceived(IPEndPoint address, byte[] data)
        {
            switch ((PacketID)data[0]) {
                case PacketID.OpenConnectionRequest1:
                    HandleOpenConnectionRequest1(address, data);
                    break;
                case PacketID.OpenConnectionRequest2:
                    HandleOpenConnectionRequest2(address, data);
                    break;
                case PacketID.UnconnectedPing1:
                    HandleUnConnectPing(address,data);
                    break;
                case PacketID.UnconnectedPing2:
                    HandleUnConnectPing(address,data);
                    break;
                default:
                    {
                        if (Sessions.TryGetValue(address, out var session))
                        {
                            session.HandleFrameSet(address, data);
                        }
                        break;
                    }
            }
        }
        private void HandleUnConnectPing(IPEndPoint peer_addr, byte[] data)
        {
            UnconnectPong unconnectPong = new UnconnectPong
            {
                time = Common.CurTimestampMillis(),
                guid = guid,
                motd = motd.data,
            };
            byte[] buf = RakNetNativePacket.WriteUnconnectPong(unconnectPong);
            Socket.Send(peer_addr, buf);
        }
        private void HandleOpenConnectionRequest1(IPEndPoint peer_addr, byte[] data)
        {
            OpenConnectionReply1 reply1Packet = new OpenConnectionReply1
            {
                magic = true,
                guid = guid,
                use_encryption = 0x00,
                mtu_size = Common.RAKNET_CLIENT_MTU,
            };
            byte[] reply1Buf = RakNetNativePacket.WritePacketConnectionOpenReply1(reply1Packet);
            Socket.Send(peer_addr, reply1Buf);
        }

        private void HandleOpenConnectionRequest2(IPEndPoint peer_addr, byte[] data)
        {
            OpenConnectionRequest2 req = RakNetNativePacket.ReadPacketConnectionOpenRequest2(data);
            OpenConnectionReply2 reply2Packet = new OpenConnectionReply2
            {
                magic = true,
                guid = guid,
                address = peer_addr,
                mtu = req.mtu,
                encryption_enabled = 0x00,
            };
            byte[] reply2Buf = RakNetNativePacket.WritePacketConnectionOpenReply2(reply2Packet);
            var session = new RaknetSession(Socket, peer_addr, guid, rak_version, new RecvQ(), new SendQ(req.mtu));
            lock (Sessions)
            {
                Sessions.Add(peer_addr, session);
                Socket.Send(peer_addr, reply2Buf);
                SessionConnected(session);
            }
        }

        public void BeginListener()
        {
            Socket.Run();
        }

        public void StopListener()
        {
            lock (Sessions)
            {
                for (int i = Sessions.Count - 1; i >= 0; i--)
                {
                    var session = Sessions.Values.ElementAt(i);
                    session.SessionDisconnected(session);
                }
            }

            Socket.Stop();
        }

    }
}
