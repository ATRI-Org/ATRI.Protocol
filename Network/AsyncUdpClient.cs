using ATRI.Protocol.Raknet;

using System.Net.Sockets;
using System.Net;
using System;

namespace ATRI.Network
{
    public class AsyncUdpClient
    {
        public UdpClient Socket;

        public delegate void PacketReceivedDelegate(IPEndPoint address, byte[] packet);
        public PacketReceivedDelegate PacketReceived = delegate { };
        private AsyncCallback? recv = null;
        private bool _closed = false;


        public AsyncUdpClient()
        {
            Socket = Common.CreateListener(new IPEndPoint(IPAddress.Any, 0));
        }

        public AsyncUdpClient(IPEndPoint address)
        {
            Socket = Common.CreateListener(address);
        }

        public void Send(IPEndPoint address, byte[] packet)
        {
            try
            {
                Socket?.BeginSend(packet, packet.Length, address, (ar) =>
                {
                    if (_closed) return;

#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    UdpClient client = (UdpClient)ar.AsyncState;
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    client.EndSend(ar);
                }, Socket);
            } catch {};
        }
        public void SendNoAnsync(IPEndPoint address, byte[] packet)
        {
            
                try
                {
                   Socket.Send(packet,packet.Length,address);
                }
                catch { };
            
        }
        public void Run()
        {
            IPEndPoint source = new IPEndPoint(0, 0);
            Socket?.BeginReceive(recv = (ar) =>
            {
                if (_closed) return;

#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                Socket = (UdpClient)ar.AsyncState;
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                byte[] receivedData = Socket.EndReceive(ar, ref source);
                Socket.BeginReceive(recv, Socket);

                PacketReceived(source, receivedData);
            }, Socket);
        }

        public void Stop()
        {
            _closed = true;
            Socket?.Close();
        }
    }

}
