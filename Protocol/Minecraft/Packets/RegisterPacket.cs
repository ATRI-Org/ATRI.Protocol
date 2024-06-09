using ATRI.Protocol.Raknet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRI.Protocol.MC;
namespace ATRI.RakNet.Network
{
    public static class RegisterPacket
    {
        public static Dictionary<int, Type> valuePairs = new Dictionary<int, Type>();
        public static void Register(int id,Type packet)
        {
            valuePairs.Add(id,packet);
        }
        public static Packet CreatObj(int id)
        {
            try
            {
                var type = valuePairs[id];
                var da = System.Activator.CreateInstance(type);
                return (Packet)da;
            }
            catch (Exception ex)
            {
                Logger.ERROR("Unnone Packet id:"+id);
                throw new Exception("None Packet");
            }
        }
    }
}
