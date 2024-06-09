using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATRI.Protocol.Bedrock
{
    public class MotdProvider
    {
        public string motd_text { get; set; } = "ATRI Bedrock Server";
        public int Protocol_Version { get; set; } = 663;
        public string Protocol_Name { get; set; } = "1.21.71";
        public string Map_name { get; set; } = "World";
        public long port { get; set; } = 19132;
        public enum ServerMode
        {
            Survival,
            Creative,
            Adventure
        }
        public enum ServerType
        {
            MCBE,
            MCEE
        }
        internal ServerType type;
        internal ServerMode serverMode;
        public MotdProvider(ServerType type, ServerMode serverMode)
        {
            this.type = type;
            this.serverMode = serverMode;
        }
        public string Build()
        {
            StringBuilder sb = new StringBuilder();
            if (type == ServerType.MCBE)
            {
                sb.Append("MCPE;");
            }
            if (type == ServerType.MCEE)
            {
                sb.Append("MCEE;");
            }
            sb.Append(motd_text + ";");
            sb.Append(Protocol_Version.ToString() + ";");
            sb.Append(Protocol_Name + ";" + "0;10;");
            sb.Append("13085570283980221660;");
            sb.Append(Map_name + ";");
            if (serverMode == ServerMode.Survival)
            {
                sb.Append("Survival;");
            }
            if (serverMode == ServerMode.Creative)
            {
                sb.Append("Creative;");
            }
            if (serverMode == ServerMode.Adventure)
            {
                sb.Append("Adventurel;");
            }
            sb.Append("1;");
            sb.Append(port.ToString() + ";" + port + 1.ToString() + ";" + "0;");
           data = sb.ToString();
            return data;
        }
        public string? data;
    }
}
