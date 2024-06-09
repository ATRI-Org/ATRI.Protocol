using ATRI.Network;
using ATRI.Protocol.Raknet.Utils.Cryptography;
using ATRI.Protocol.Raknet.Utils.Skins;
using ATRI.Protocol.Raknet.Utils;
using fNbt;
using Jose;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using test;
using ATRI.RakNet.Bedrock;
using System.Net;

namespace ATRI.Protocol.Bedrock
{
    public static class HandleLogin
    {
        public static void HandleLoginPacket(MCPE_LOGIN loginPacket, RaknetSession raknetSession,ref IPEndPoint iPEnd)
        {
            PlayerInfo _playerInfo = new PlayerInfo();
            raknetSession.PlayerInfo = _playerInfo;
            string certificateChain;
            string skinData;
            var destination = new MemoryStream(loginPacket.payload);
            destination.Position = 0;
            NbtBinaryReader reader = new NbtBinaryReader(destination, false);
            var countCertData = reader.ReadInt32();
            certificateChain = Encoding.UTF8.GetString(reader.ReadBytes(countCertData));
            var countSkinData = reader.ReadInt32();
            skinData = Encoding.UTF8.GetString(reader.ReadBytes(countSkinData));


            try
            {
                {
                    IDictionary<string, dynamic> headers = JWT.Headers(skinData);
                    dynamic payload = JObject.Parse(JWT.Payload(skinData));
                    Logger.INFO(payload.ToString());
                    try
                    {
                        _playerInfo.ProtocolVersion = loginPacket.protocolVersion;
                        _playerInfo.ClientId = payload.ClientRandomId;
                        _playerInfo.CurrentInputMode = payload.CurrentInputMode;
                        _playerInfo.DefaultInputMode = payload.DefaultInputMode;
                        _playerInfo.DeviceModel = payload.DeviceModel;
                        _playerInfo.DeviceOS = payload.DeviceOS;
                        _playerInfo.GameVersion = payload.GameVersion;
                        _playerInfo.GuiScale = payload.GuiScale;
                        _playerInfo.LanguageCode = payload.LanguageCode;
                        _playerInfo.PlatformChatId = payload.PlatformOnlineId;
                        _playerInfo.ServerAddress = payload.ServerAddress;
                        _playerInfo.UIProfile = payload.UIProfile;
                        _playerInfo.ThirdPartyName = payload.ThirdPartyName;
                        _playerInfo.TenantId = payload.TenantId;
                        _playerInfo.DeviceId = payload.DeviceId;

                        _playerInfo.Skin = new Skin()
                        {
                            Cape = new Cape()
                            {
                                Data = Convert.FromBase64String((string)payload.CapeData ?? string.Empty),
                                Id = payload.CapeId,
                                ImageHeight = payload.CapeImageHeight,
                                ImageWidth = payload.CapeImageWidth,
                                OnClassicSkin = payload.CapeOnClassicSkin,
                            },
                            SkinId = payload.SkinId,
                            ResourcePatch = Encoding.UTF8.GetString(Convert.FromBase64String((string)payload.SkinResourcePatch ?? string.Empty)),
                            Width = payload.SkinImageWidth,
                            Height = payload.SkinImageHeight,
                            Data = Convert.FromBase64String((string)payload.SkinData ?? string.Empty),
                            GeometryData = Encoding.UTF8.GetString(Convert.FromBase64String((string)payload.SkinGeometryData ?? string.Empty)),
                            AnimationData = payload.SkinAnimationData,
                            IsPremiumSkin = payload.PremiumSkin,
                            IsPersonaSkin = payload.PersonaSkin,
                        };
                        foreach (dynamic animationData in payload.AnimatedImageData)
                        {
                            _playerInfo.Skin.Animations.Add(
                                new Animation()
                                {
                                    Image = Convert.FromBase64String((string)animationData.Image ?? string.Empty),
                                    ImageHeight = animationData.ImageHeight,
                                    ImageWidth = animationData.ImageWidth,
                                    FrameCount = animationData.Frames,
                                    Expression = animationData.AnimationExpression,
                                    Type = animationData.Type,
                                }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.ERROR("Parsing skin data" + e);
                    }
                }

                {
                    dynamic json = JObject.Parse(certificateChain);

                    JArray chain = json.chain;
                    //var chainArray = chain.ToArray();

                    string validationKey = null;
                    string identityPublicKey = null;

                    foreach (JToken token in chain)
                    {
                        IDictionary<string, dynamic> headers = JWT.Headers(token.ToString());
                        dynamic jsonPayload = JObject.Parse(JWT.Payload(token.ToString()));
                       // Logger.INFO($"JWT Payload:\n{jsonPayload}");
                        if (!headers.ContainsKey("x5u")) continue;

                        string x5u = headers["x5u"];

                        if (identityPublicKey == null)
                        {
                            if (CertificateData.MojangRootKey.Equals(x5u, StringComparison.InvariantCultureIgnoreCase))
                            {
                               // Logger.INFO("Key is ok, and got Mojang root");
                            }
                            else if (chain.Count > 1)
                            {
                               // Logger.INFO("Got client cert (client root)");
                                continue;
                            }
                            else if (chain.Count == 1)
                            {
                               // Logger.INFO("Selfsigned chain");
                            }
                        }
                        else if (identityPublicKey.Equals(x5u))
                        {
                            //Logger.INFO("Derived Key is ok");
                        }

                        ECPublicKeyParameters x5KeyParam = (ECPublicKeyParameters)PublicKeyFactory.CreateKey(x5u.DecodeBase64());
                        var signParam = new ECParameters
                        {
                            Curve = ECCurve.NamedCurves.nistP384,
                            Q =
                            {
                                X = x5KeyParam.Q.AffineXCoord.GetEncoded(),
                                Y = x5KeyParam.Q.AffineYCoord.GetEncoded()
                            },
                        };
                        signParam.Validate();

                        CertificateData data = JWT.Decode<CertificateData>(token.ToString(), ECDsa.Create(signParam));

                        // Validate

                        if (data != null)
                        {
                            identityPublicKey = data.IdentityPublicKey;

                            if (CertificateData.MojangRootKey.Equals(x5u, StringComparison.InvariantCultureIgnoreCase))
                            {
                               // Logger.INFO("Got Mojang key. Is valid = " + data.CertificateAuthority);
                                validationKey = data.IdentityPublicKey;
                            }
                            else if (validationKey != null && validationKey.Equals(x5u, StringComparison.InvariantCultureIgnoreCase))
                            {
                                //TODO: Remove. Just there to be able to join with same XBL multiple times without crashing the server.
                                //data.ExtraData.Identity = Guid.NewGuid().ToString();
                                _playerInfo.CertificateData = data;
                            }
                            else
                            {
                                if (data.ExtraData == null) continue;

                                // Self signed, make sure they don't fake XUID
                                if (data.ExtraData.Xuid != null)
                                {
                                    //Logger.WARN("Received fake XUID from " + data.ExtraData.DisplayName);
                                    data.ExtraData.Xuid = null;
                                }

                                //TODO: Remove. Just there to be able to join with same XBL multiple times without crashing the server.
                                //data.ExtraData.Identity = Guid.NewGuid().ToString();
                                _playerInfo.CertificateData = data;
                            }
                        }
                        else
                        {
                            Logger.ERROR("Not a valid Identity Public Key for decoding");
                        }
                    }

                    //TODO: Implement disconnect here

                    {
                        _playerInfo.Username = _playerInfo.CertificateData.ExtraData.DisplayName;
                        string identity = _playerInfo.CertificateData.ExtraData.Identity;

                        Logger.INFO($"Connecting user {_playerInfo.Username} with identity={identity} on protocol version={_playerInfo.ProtocolVersion}");
                        _playerInfo.ClientUuid = new UUID(identity);


                        if (true)
                        {
                            // Use bouncy to parse the DER key
                            ECPublicKeyParameters remotePublicKey = (ECPublicKeyParameters)
                                PublicKeyFactory.CreateKey(_playerInfo.CertificateData.IdentityPublicKey.DecodeBase64());

                            var b64RemotePublicKey = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(remotePublicKey).GetEncoded().EncodeBase64();
                            Debug.Assert(_playerInfo.CertificateData.IdentityPublicKey == b64RemotePublicKey);
                            Debug.Assert(remotePublicKey.PublicKeyParamSet.Id == "1.3.132.0.34");
                          //  Logger.INFO($"{remotePublicKey.PublicKeyParamSet}");

                            var generator = new ECKeyPairGenerator("ECDH");
                            generator.Init(new ECKeyGenerationParameters(remotePublicKey.PublicKeyParamSet, SecureRandom.GetInstance("SHA256PRNG")));
                            var keyPair = generator.GenerateKeyPair();

                            ECPublicKeyParameters pubAsyKey = (ECPublicKeyParameters)keyPair.Public;
                            ECPrivateKeyParameters privAsyKey = (ECPrivateKeyParameters)keyPair.Private;

                            var secretPrepend = Encoding.UTF8.GetBytes("RANDOM SECRET");

                            ECDHBasicAgreement agreement = new ECDHBasicAgreement();
                            agreement.Init(keyPair.Private);
                            byte[] secret;
                            using (var sha = SHA256.Create())
                            {
                                secret = sha.ComputeHash(secretPrepend.Concat(agreement.CalculateAgreement(remotePublicKey).ToByteArrayUnsigned()).ToArray());
                            }

                            Debug.Assert(secret.Length == 32);



                            var encryptor = new SicStream.StreamingSicBlockCipher(new SicBlockCipher(new AesEngine()));
                            var decryptor = new SicStream.StreamingSicBlockCipher(new SicBlockCipher(new AesEngine()));
                            decryptor.Init(false, new ParametersWithIV(new KeyParameter(secret), secret.Take(12).Concat(new byte[] { 0, 0, 0, 2 }).ToArray()));
                            encryptor.Init(true, new ParametersWithIV(new KeyParameter(secret), secret.Take(12).Concat(new byte[] { 0, 0, 0, 2 }).ToArray()));
                            //IBufferedCipher decryptor = CipherUtilities.GetCipher("AES/CFB8/NoPadding");
                            //decryptor.Init(false, new ParametersWithIV(new KeyParameter(secret), secret.Take(16).ToArray()));
                            var client_cryptc = new CryptoContext();
                            client_cryptc.Encryptor = encryptor;
                            client_cryptc.Decryptor = decryptor;
                            client_cryptc.Key = secret;
                            BedrockMessagePacketHandle.Crypto.Add(iPEnd,client_cryptc);
                            raknetSession.CryptoContext = client_cryptc;
                            raknetSession.IsUseEncryption = true;
                            //IBufferedCipher encryptor = CipherUtilities.GetCipher("AES/CFB8/NoPadding");
                            //encryptor.Init(true, new ParametersWithIV(new KeyParameter(secret), secret.Take(16).ToArray()));

                            var signParam = new ECParameters
                            {
                                Curve = ECCurve.NamedCurves.nistP384,
                                Q =
                                {
                                    X = pubAsyKey.Q.AffineXCoord.GetEncoded(),
                                    Y = pubAsyKey.Q.AffineYCoord.GetEncoded()
                                }
                            };
                            signParam.D = FixDSize(privAsyKey.D.ToByteArrayUnsigned(), signParam.Q.X.Length);
                            signParam.Validate();

                            string signedToken = null;
                            //if (_session.Server.IsEdu)
                            //{
                            //	EduTokenManager tokenManager = _session.Server.EduTokenManager;
                            //	signedToken = tokenManager.GetSignedToken(_playerInfo.TenantId);
                            //}

                            var signKey = ECDsa.Create(signParam);
                            var b64PublicKey = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pubAsyKey).GetEncoded().EncodeBase64();
                            var handshakeJson = new HandshakeData
                            {
                                salt = secretPrepend.EncodeBase64(),
                            };
                            string val = JWT.Encode(handshakeJson, signKey, JwsAlgorithm.ES384, new Dictionary<string, object> { { "x5u", b64PublicKey } });

                           // Logger.INFO($"Headers:\n{string.Join(";", JWT.Headers(val))}");
                           // Logger.INFO($"Return salt:\n{JWT.Payload(val)}");
                           // Logger.INFO($"JWT:\n{val}");
                            MCPE_SERVER_TO_CLIENT_HANDSHAKE mCPE_SERVER_TO_CLIENT_HANDSHAKE = new MCPE_SERVER_TO_CLIENT_HANDSHAKE();
                            mCPE_SERVER_TO_CLIENT_HANDSHAKE.token = val;
                            raknetSession.SendPacket(mCPE_SERVER_TO_CLIENT_HANDSHAKE,false,0,false,true);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Logger.ERROR("Decrypt" + e);
            }
        }
        public static byte[] FixDSize(byte[] input, int expectedSize)
        {
            if (input.Length == expectedSize)
            {
                return input;
            }

            byte[] tmp;

            if (input.Length < expectedSize)
            {
                tmp = new byte[expectedSize];
                Buffer.BlockCopy(input, 0, tmp, expectedSize - input.Length, input.Length);
                return tmp;
            }

            if (input.Length > expectedSize + 1 || input[0] != 0)
            {
                throw new InvalidOperationException();
            }

            tmp = new byte[expectedSize];
            Buffer.BlockCopy(input, 1, tmp, 0, expectedSize);
            return tmp;
        }
    }
}
    public class PlayerInfo
    {
        public int ADRole { get; set; }
        public CertificateData CertificateData { get; set; }
        public string Username { get; set; }
        public UUID ClientUuid { get; set; }
        public string ServerAddress { get; set; }
        public long ClientId { get; set; }
        public Skin Skin { get; set; }
        public int CurrentInputMode { get; set; }
        public int DefaultInputMode { get; set; }
        public string DeviceModel { get; set; }
        public string GameVersion { get; set; }
        public int DeviceOS { get; set; }
        public string DeviceId { get; set; }
        public int GuiScale { get; set; }
        public int UIProfile { get; set; }
        public int Edition { get; set; }
        public int ProtocolVersion { get; set; }
        public string LanguageCode { get; set; }
        public string PlatformChatId { get; set; }
        public string ThirdPartyName { get; set; }
        public string TenantId { get; set; }
    }

