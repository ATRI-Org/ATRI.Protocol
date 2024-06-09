using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ATRI.Network;
using ATRI.Protocol.Raknet;
using ATRI.Protocol.Raknet.Utils.Cryptography;
using ATRI.Protocol.MC;
using test;
using ATRI.Protocol.Bedrock;
namespace ATRI.RakNet.Bedrock
{
    public static class BedrockMessagePacketHandle
    {
        public delegate void HandleBedrockMessage_(Packet packet, byte[] buf,IPEndPoint ipend,RaknetSession session);
        public static event HandleBedrockMessage_ HandleMessage;
        public static Dictionary<IPEndPoint, CryptoContext> Crypto = new();
        public static void HandleBedrockMessage(Packet packet, byte[] buf,IPEndPoint iP,RaknetSession session)
        {
            HandleMessage(packet,buf,iP,session);
            if (packet.IsUse)
            {
                return;
            }
            switch (packet)
            {
                case MCPE_REQUEST_NETWORK_SETTINGS:
                    
                    MCPE_NETWORK_SETTINGS settingsPacket = new();
                    settingsPacket.compressionAlgorithm = 0;//zlib
                    settingsPacket.compressionThreshold = 1;
                    settingsPacket.clientThrottleEnabled = false;
                    settingsPacket.clientThrottleScalar = 0;
                    settingsPacket.clientThrottleThreshold = 0;
                    session.SendPacket(settingsPacket,true,0x0c);
                    break;
                case MCPE_LOGIN:
                    MCPE_LOGIN mCPE_LOGIN = new();
                    mCPE_LOGIN.Deserialize(buf);
                    HandleLogin.HandleLoginPacket(mCPE_LOGIN,session,ref iP);
                    break;
                case MCPE_CLIENT_TO_SERVER_HANDSHAKE:
                    MCPE_PLAY_STATUS mCPE_PLAY_STATUS = new MCPE_PLAY_STATUS();
                    mCPE_PLAY_STATUS.status = (int)MCPE_PLAY_STATUS.Play_status.Login_Failed_Edu_Vanilla;
                    session.SendPacket(mCPE_PLAY_STATUS);
                    break;
                case MCPE_SERVER_TO_CLIENT_HANDSHAKE:
                     
                    break;
                    
            }
        }
       
    }
}
