using ATRI.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ATRI.RakNet.Network;
namespace ATRI.Protocol.Bedrock
{
    public class CreatServer
    {
        private Type[] GetRegister()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetAssembly(typeof(RegisterPacketID));
            System.Type[] types = asm.GetExportedTypes();

            Func<Attribute[], bool> IsMyAttribute = o =>
            {
                foreach (Attribute a in o)
                {
                    if (a is RegisterPacketID)
                        return true;
                }
                return false;
            };

            System.Type[] cosType = types.Where(o =>
            {
                return IsMyAttribute(System.Attribute.GetCustomAttributes(o, true));
            }
            ).ToArray();
            return cosType;
        }
        private RaknetListener listener;
        public CreatServer(MotdProvider motdProvider, string bind_ipaddresss) 
        {
            motdProvider.Build();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(bind_ipaddresss), (int)motdProvider.port);
            RaknetListener raknetListener = new RaknetListener(iPEndPoint, motdProvider);
            this.listener = raknetListener;
            foreach (Type packetType in GetRegister())
            {
                RegisterPacketID attribute =
                packetType.GetCustomAttribute<RegisterPacketID>();
                RegisterPacket.Register(attribute.ID, packetType);
            }
        }
        public void Start()
        {
            Logger.INFO("Start Server!");
            Logger.INFO("     _      _____   ____    ___ ");
            Logger.INFO("    / \\    |_   _| |  _ \\  |_ _|");
            Logger.INFO("   / _ \\     | |   | |_) |  | |");
            Logger.INFO("  / ___ \\    | |   |  _ <   | | ");
            Logger.INFO(" /_/   \\_\\   |_|   |_| \\_\\ |___|");
            Logger.INFO("                                ");
            Logger.INFO("Server Started!");
            listener.BeginListener();
        }
        public void Stop()
        {
            listener.StopListener();
        }
    }
}
