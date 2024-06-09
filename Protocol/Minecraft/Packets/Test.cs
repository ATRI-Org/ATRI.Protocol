using ATRI.Protocol.Raknet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRI.Protocol.MC;
namespace ATRI.Protocol.Protocol.Minecraft.Packetsaaaaaaaaaaaaaaaaa
{
    [RegisterPacketID(0x01)]
    public class MCPE_LOGIN : Packet
    {
        public int ProtocolVersion; // Placeholder for the actual field
        public byte[] Payload; // Placeholder for the actual field
        public MCPE_LOGIN() : base(0x01)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ProtocolVersion = ReadIntBe();
            Payload = ReadByteArray();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteBe(ProtocolVersion);
            WriteByteArray(Payload);
            return After();
        }
    }
    [RegisterPacketID(0x02)]
    public class MCPE_PLAY_STATUS : Packet
    {
        public int Status; // Placeholder for the actual field
        public MCPE_PLAY_STATUS() : base(0x02)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Status = ReadIntBe();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteBe(Status);
            return After();
        }
    }
    [RegisterPacketID(0x03)]
    public class MCPE_SERVER_TO_CLIENT_HANDSHAKE : Packet
    {
        public string Token; // Placeholder for the actual field
        public MCPE_SERVER_TO_CLIENT_HANDSHAKE() : base(0x03)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Token = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Token);
            return After();
        }
    }
    [RegisterPacketID(0x04)]
    public class MCPE_CLIENT_TO_SERVER_HANDSHAKE : Packet
    {
        public MCPE_CLIENT_TO_SERVER_HANDSHAKE() : base(0x04)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x05)]
    public class MCPE_DISCONNECT : Packet
    {
        public object Hidedisconnectreason; // Placeholder for the actual field
        public string Message; // Placeholder for the actual field
        public MCPE_DISCONNECT() : base(0x05)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Hidedisconnectreason = Read();
            Message = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Hidedisconnectreason);
            Write(Message);
            return After();
        }
    }
    [RegisterPacketID(0x06)]
    public class MCPE_RESOURCE_PACKS_INFO : Packet
    {
        public object Mustaccept; // Placeholder for the actual field
        public object Hasscripts; // Placeholder for the actual field
        public object ForceServerPacks; // Placeholder for the actual field
        public object BehahaviorPackInfos; // Placeholder for the actual field
        public object TexturePacks; // Placeholder for the actual field
        public MCPE_RESOURCE_PACKS_INFO() : base(0x06)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Mustaccept = Read();
            Hasscripts = Read();
            ForceServerPacks = Read();
            BehahaviorPackInfos = Read();
            TexturePacks = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Mustaccept);
            Write(Hasscripts);
            Write(ForceServerPacks);
            Write(BehahaviorPackInfos);
            Write(TexturePacks);
            return After();
        }
    }
    [RegisterPacketID(0x07)]
    public class MCPE_RESOURCE_PACK_STACK : Packet
    {
        public object Mustaccept; // Placeholder for the actual field
        public object BehaviorPackIdVersions; // Placeholder for the actual field
        public object ResourcePackIdVersions; // Placeholder for the actual field
        public string GameVersion; // Placeholder for the actual field
        public object Experiments; // Placeholder for the actual field
        public object ExperimentsPreviouslyToggled; // Placeholder for the actual field
        public MCPE_RESOURCE_PACK_STACK() : base(0x07)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Mustaccept = Read();
            BehaviorPackIdVersions = Read();
            ResourcePackIdVersions = Read();
            GameVersion = ReadString();
            Experiments = Read();
            ExperimentsPreviouslyToggled = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Mustaccept);
            Write(BehaviorPackIdVersions);
            Write(ResourcePackIdVersions);
            Write(GameVersion);
            Write(Experiments);
            Write(ExperimentsPreviouslyToggled);
            return After();
        }
    }
    [RegisterPacketID(0x08)]
    public class MCPE_RESOURCE_PACK_CLIENT_RESPONSE : Packet
    {
        public object Responsestatus; // Placeholder for the actual field
        public object ResourcePackIds; // Placeholder for the actual field
        public MCPE_RESOURCE_PACK_CLIENT_RESPONSE() : base(0x08)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Responsestatus = Read();
            ResourcePackIds = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Responsestatus);
            Write(ResourcePackIds);
            return After();
        }
    }
    [RegisterPacketID(0x09)]
    public class MCPE_TEXT : Packet
    {
        public object Type; // Placeholder for the actual field
        public MCPE_TEXT() : base(0x09)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Type = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Type);
            return After();
        }
    }
    [RegisterPacketID(0x0a)]
    public class MCPE_SET_TIME : Packet
    {
        public int Time; // Placeholder for the actual field
        public MCPE_SET_TIME() : base(0x0a)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Time = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(Time);
            return After();
        }
    }
    [RegisterPacketID(0x0b)]
    public class MCPE_START_GAME : Packet
    {
        public MCPE_START_GAME() : base(0x0b)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x0c)]
    public class MCPE_ADD_PLAYER : Packet
    {
        public object UUID; // Placeholder for the actual field
        public string Username; // Placeholder for the actual field
        public long RuntimeEntityID; // Placeholder for the actual field
        public string PlatformChatID; // Placeholder for the actual field
        public object X; // Placeholder for the actual field
        public object Y; // Placeholder for the actual field
        public object Z; // Placeholder for the actual field
        public object SpeedX; // Placeholder for the actual field
        public object SpeedY; // Placeholder for the actual field
        public object SpeedZ; // Placeholder for the actual field
        public object Pitch; // Placeholder for the actual field
        public object Yaw; // Placeholder for the actual field
        public object HeadYaw; // Placeholder for the actual field
        public object Item; // Placeholder for the actual field
        public uint GameType; // Placeholder for the actual field
        public object Metadata; // Placeholder for the actual field
        public object SyncData; // Placeholder for the actual field
        public object EntityIDSelf; // Placeholder for the actual field
        public object PlayerPermissions; // Placeholder for the actual field
        public object CommandPermissions; // Placeholder for the actual field
        public object Layers; // Placeholder for the actual field
        public object Links; // Placeholder for the actual field
        public string DeviceID; // Placeholder for the actual field
        public int DeviceOS; // Placeholder for the actual field
        public MCPE_ADD_PLAYER() : base(0x0c)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            UUID = Read();
            Username = ReadString();
            RuntimeEntityID = ReadUnsignedVarLong();
            PlatformChatID = ReadString();
            X = Read();
            Y = Read();
            Z = Read();
            SpeedX = Read();
            SpeedY = Read();
            SpeedZ = Read();
            Pitch = Read();
            Yaw = Read();
            HeadYaw = Read();
            Item = Read();
            GameType = ReadUnsignedVarInt();
            Metadata = Read();
            SyncData = Read();
            EntityIDSelf = Read();
            PlayerPermissions = Read();
            CommandPermissions = Read();
            Layers = Read();
            Links = Read();
            DeviceID = ReadString();
            DeviceOS = ReadInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(UUID);
            Write(Username);
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(PlatformChatID);
            Write(X);
            Write(Y);
            Write(Z);
            Write(SpeedX);
            Write(SpeedY);
            Write(SpeedZ);
            Write(Pitch);
            Write(Yaw);
            Write(HeadYaw);
            Write(Item);
            WriteUnsignedVarInt(GameType);
            Write(Metadata);
            Write(SyncData);
            Write(EntityIDSelf);
            Write(PlayerPermissions);
            Write(CommandPermissions);
            Write(Layers);
            Write(Links);
            Write(DeviceID);
            Write(DeviceOS);
            return After();
        }
    }
    [RegisterPacketID(0x0d)]
    public class MCPE_ADD_ENTITY : Packet
    {
        public object EntityIDSelf; // Placeholder for the actual field
        public long RuntimeEntityID; // Placeholder for the actual field
        public string EntityType; // Placeholder for the actual field
        public object X; // Placeholder for the actual field
        public object Y; // Placeholder for the actual field
        public object Z; // Placeholder for the actual field
        public object SpeedX; // Placeholder for the actual field
        public object SpeedY; // Placeholder for the actual field
        public object SpeedZ; // Placeholder for the actual field
        public object Pitch; // Placeholder for the actual field
        public object Yaw; // Placeholder for the actual field
        public object HeadYaw; // Placeholder for the actual field
        public object BodyYaw; // Placeholder for the actual field
        public object Attributes; // Placeholder for the actual field
        public object Metadata; // Placeholder for the actual field
        public object SyncData; // Placeholder for the actual field
        public object Links; // Placeholder for the actual field
        public MCPE_ADD_ENTITY() : base(0x0d)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            EntityIDSelf = Read();
            RuntimeEntityID = ReadUnsignedVarLong();
            EntityType = ReadString();
            X = Read();
            Y = Read();
            Z = Read();
            SpeedX = Read();
            SpeedY = Read();
            SpeedZ = Read();
            Pitch = Read();
            Yaw = Read();
            HeadYaw = Read();
            BodyYaw = Read();
            Attributes = Read();
            Metadata = Read();
            SyncData = Read();
            Links = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(EntityIDSelf);
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(EntityType);
            Write(X);
            Write(Y);
            Write(Z);
            Write(SpeedX);
            Write(SpeedY);
            Write(SpeedZ);
            Write(Pitch);
            Write(Yaw);
            Write(HeadYaw);
            Write(BodyYaw);
            Write(Attributes);
            Write(Metadata);
            Write(SyncData);
            Write(Links);
            return After();
        }
    }
    [RegisterPacketID(0x0e)]
    public class MCPE_REMOVE_ENTITY : Packet
    {
        public object EntityIDSelf; // Placeholder for the actual field
        public MCPE_REMOVE_ENTITY() : base(0x0e)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            EntityIDSelf = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(EntityIDSelf);
            return After();
        }
    }
    [RegisterPacketID(0x0f)]
    public class MCPE_ADD_ITEM_ENTITY : Packet
    {
        public object EntityIDSelf; // Placeholder for the actual field
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Item; // Placeholder for the actual field
        public object X; // Placeholder for the actual field
        public object Y; // Placeholder for the actual field
        public object Z; // Placeholder for the actual field
        public object SpeedX; // Placeholder for the actual field
        public object SpeedY; // Placeholder for the actual field
        public object SpeedZ; // Placeholder for the actual field
        public object Metadata; // Placeholder for the actual field
        public object IsFromFishing; // Placeholder for the actual field
        public MCPE_ADD_ITEM_ENTITY() : base(0x0f)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            EntityIDSelf = Read();
            RuntimeEntityID = ReadUnsignedVarLong();
            Item = Read();
            X = Read();
            Y = Read();
            Z = Read();
            SpeedX = Read();
            SpeedY = Read();
            SpeedZ = Read();
            Metadata = Read();
            IsFromFishing = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(EntityIDSelf);
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Item);
            Write(X);
            Write(Y);
            Write(Z);
            Write(SpeedX);
            Write(SpeedY);
            Write(SpeedZ);
            Write(Metadata);
            Write(IsFromFishing);
            return After();
        }
    }
    [RegisterPacketID(0x11)]
    public class MCPE_TAKE_ITEM_ENTITY : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public long Target; // Placeholder for the actual field
        public MCPE_TAKE_ITEM_ENTITY() : base(0x11)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Target = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            WriteUnsignedVarLong(Target);
            return After();
        }
    }
    [RegisterPacketID(0x12)]
    public class MCPE_MOVE_ENTITY : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Flags; // Placeholder for the actual field
        public object Position; // Placeholder for the actual field
        public MCPE_MOVE_ENTITY() : base(0x12)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Flags = Read();
            Position = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Flags);
            Write(Position);
            return After();
        }
    }
    [RegisterPacketID(0x13)]
    public class MCPE_MOVE_PLAYER : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object X; // Placeholder for the actual field
        public object Y; // Placeholder for the actual field
        public object Z; // Placeholder for the actual field
        public object Pitch; // Placeholder for the actual field
        public object Yaw; // Placeholder for the actual field
        public object HeadYaw; // Placeholder for the actual field
        public object Mode; // Placeholder for the actual field
        public object OnGround; // Placeholder for the actual field
        public long OtherRuntimeEntityID; // Placeholder for the actual field
        public MCPE_MOVE_PLAYER() : base(0x13)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            X = Read();
            Y = Read();
            Z = Read();
            Pitch = Read();
            Yaw = Read();
            HeadYaw = Read();
            Mode = Read();
            OnGround = Read();
            OtherRuntimeEntityID = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(X);
            Write(Y);
            Write(Z);
            Write(Pitch);
            Write(Yaw);
            Write(HeadYaw);
            Write(Mode);
            Write(OnGround);
            WriteUnsignedVarLong(OtherRuntimeEntityID);
            return After();
        }
    }
    [RegisterPacketID(0x14)]
    public class MCPE_RIDER_JUMP : Packet
    {
        public int Unknown; // Placeholder for the actual field
        public MCPE_RIDER_JUMP() : base(0x14)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Unknown = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(Unknown);
            return After();
        }
    }
    [RegisterPacketID(0x15)]
    public class MCPE_UPDATE_BLOCK : Packet
    {
        public object Coordinates; // Placeholder for the actual field
        public uint BlockRuntimeID; // Placeholder for the actual field
        public uint BlockPriority; // Placeholder for the actual field
        public uint Storage; // Placeholder for the actual field
        public MCPE_UPDATE_BLOCK() : base(0x15)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Coordinates = Read();
            BlockRuntimeID = ReadUnsignedVarInt();
            BlockPriority = ReadUnsignedVarInt();
            Storage = ReadUnsignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Coordinates);
            WriteUnsignedVarInt(BlockRuntimeID);
            WriteUnsignedVarInt(BlockPriority);
            WriteUnsignedVarInt(Storage);
            return After();
        }
    }
    [RegisterPacketID(0x16)]
    public class MCPE_ADD_PAINTING : Packet
    {
        public object EntityIDSelf; // Placeholder for the actual field
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Coordinates; // Placeholder for the actual field
        public int Direction; // Placeholder for the actual field
        public string Title; // Placeholder for the actual field
        public MCPE_ADD_PAINTING() : base(0x16)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            EntityIDSelf = Read();
            RuntimeEntityID = ReadUnsignedVarLong();
            Coordinates = Read();
            Direction = ReadSignedVarInt();
            Title = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(EntityIDSelf);
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Coordinates);
            WriteSignedVarInt(Direction);
            Write(Title);
            return After();
        }
    }
    [RegisterPacketID(0x17)]
    public class MCPE_TICK_SYNC : Packet
    {
        public object RequestTime; // Placeholder for the actual field
        public object ResponseTime; // Placeholder for the actual field
        public MCPE_TICK_SYNC() : base(0x17)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RequestTime = Read();
            ResponseTime = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(RequestTime);
            Write(ResponseTime);
            return After();
        }
    }
    [RegisterPacketID(0x18)]
    public class MCPE_LEVEL_SOUND_EVENT_OLD : Packet
    {
        public object SoundID; // Placeholder for the actual field
        public object Position; // Placeholder for the actual field
        public int BlockId; // Placeholder for the actual field
        public int EntityType; // Placeholder for the actual field
        public object Isbabymob; // Placeholder for the actual field
        public object Isglobal; // Placeholder for the actual field
        public MCPE_LEVEL_SOUND_EVENT_OLD() : base(0x18)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            SoundID = Read();
            Position = Read();
            BlockId = ReadSignedVarInt();
            EntityType = ReadSignedVarInt();
            Isbabymob = Read();
            Isglobal = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(SoundID);
            Write(Position);
            WriteSignedVarInt(BlockId);
            WriteSignedVarInt(EntityType);
            Write(Isbabymob);
            Write(Isglobal);
            return After();
        }
    }
    [RegisterPacketID(0x19)]
    public class MCPE_LEVEL_EVENT : Packet
    {
        public int EventID; // Placeholder for the actual field
        public object Position; // Placeholder for the actual field
        public int Data; // Placeholder for the actual field
        public MCPE_LEVEL_EVENT() : base(0x19)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            EventID = ReadSignedVarInt();
            Position = Read();
            Data = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(EventID);
            Write(Position);
            WriteSignedVarInt(Data);
            return After();
        }
    }
    [RegisterPacketID(0x1a)]
    public class MCPE_BLOCK_EVENT : Packet
    {
        public object Coordinates; // Placeholder for the actual field
        public int Case1; // Placeholder for the actual field
        public int Case2; // Placeholder for the actual field
        public MCPE_BLOCK_EVENT() : base(0x1a)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Coordinates = Read();
            Case1 = ReadSignedVarInt();
            Case2 = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Coordinates);
            WriteSignedVarInt(Case1);
            WriteSignedVarInt(Case2);
            return After();
        }
    }
    [RegisterPacketID(0x1b)]
    public class MCPE_ENTITY_EVENT : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object EventID; // Placeholder for the actual field
        public int Data; // Placeholder for the actual field
        public MCPE_ENTITY_EVENT() : base(0x1b)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            EventID = Read();
            Data = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(EventID);
            WriteSignedVarInt(Data);
            return After();
        }
    }
    [RegisterPacketID(0x1c)]
    public class MCPE_MOB_EFFECT : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object EventID; // Placeholder for the actual field
        public int EffectID; // Placeholder for the actual field
        public int Amplifier; // Placeholder for the actual field
        public object Particles; // Placeholder for the actual field
        public int Duration; // Placeholder for the actual field
        public MCPE_MOB_EFFECT() : base(0x1c)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            EventID = Read();
            EffectID = ReadSignedVarInt();
            Amplifier = ReadSignedVarInt();
            Particles = Read();
            Duration = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(EventID);
            WriteSignedVarInt(EffectID);
            WriteSignedVarInt(Amplifier);
            Write(Particles);
            WriteSignedVarInt(Duration);
            return After();
        }
    }
    [RegisterPacketID(0x1d)]
    public class MCPE_UPDATE_ATTRIBUTES : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Attributes; // Placeholder for the actual field
        public long Tick; // Placeholder for the actual field
        public MCPE_UPDATE_ATTRIBUTES() : base(0x1d)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Attributes = Read();
            Tick = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Attributes);
            WriteUnsignedVarLong(Tick);
            return After();
        }
    }
    [RegisterPacketID(0x1e)]
    public class MCPE_INVENTORY_TRANSACTION : Packet
    {
        public object Transaction; // Placeholder for the actual field
        public MCPE_INVENTORY_TRANSACTION() : base(0x1e)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Transaction = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Transaction);
            return After();
        }
    }
    [RegisterPacketID(0x1f)]
    public class MCPE_MOB_EQUIPMENT : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Item; // Placeholder for the actual field
        public object Slot; // Placeholder for the actual field
        public object SelectedSlot; // Placeholder for the actual field
        public object WindowsId; // Placeholder for the actual field
        public MCPE_MOB_EQUIPMENT() : base(0x1f)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Item = Read();
            Slot = Read();
            SelectedSlot = Read();
            WindowsId = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Item);
            Write(Slot);
            Write(SelectedSlot);
            Write(WindowsId);
            return After();
        }
    }
    [RegisterPacketID(0x20)]
    public class MCPE_MOB_ARMOR_EQUIPMENT : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Helmet; // Placeholder for the actual field
        public object Chestplate; // Placeholder for the actual field
        public object Leggings; // Placeholder for the actual field
        public object Boots; // Placeholder for the actual field
        public MCPE_MOB_ARMOR_EQUIPMENT() : base(0x20)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Helmet = Read();
            Chestplate = Read();
            Leggings = Read();
            Boots = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Helmet);
            Write(Chestplate);
            Write(Leggings);
            Write(Boots);
            return After();
        }
    }
    [RegisterPacketID(0x21)]
    public class MCPE_INTERACT : Packet
    {
        public object ActionID; // Placeholder for the actual field
        public long TargetRuntimeEntityID; // Placeholder for the actual field
        public MCPE_INTERACT() : base(0x21)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ActionID = Read();
            TargetRuntimeEntityID = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(ActionID);
            WriteUnsignedVarLong(TargetRuntimeEntityID);
            return After();
        }
    }
    [RegisterPacketID(0x22)]
    public class MCPE_BLOCK_PICK_REQUEST : Packet
    {
        public int X; // Placeholder for the actual field
        public int Y; // Placeholder for the actual field
        public int Z; // Placeholder for the actual field
        public object AddUserData; // Placeholder for the actual field
        public object SelectedSlot; // Placeholder for the actual field
        public MCPE_BLOCK_PICK_REQUEST() : base(0x22)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            X = ReadSignedVarInt();
            Y = ReadSignedVarInt();
            Z = ReadSignedVarInt();
            AddUserData = Read();
            SelectedSlot = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(X);
            WriteSignedVarInt(Y);
            WriteSignedVarInt(Z);
            Write(AddUserData);
            Write(SelectedSlot);
            return After();
        }
    }
    [RegisterPacketID(0x23)]
    public class MCPE_ENTITY_PICK_REQUEST : Packet
    {
        public object RuntimeEntityID; // Placeholder for the actual field
        public object SelectedSlot; // Placeholder for the actual field
        public object AddUserData; // Placeholder for the actual field
        public MCPE_ENTITY_PICK_REQUEST() : base(0x23)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = Read();
            SelectedSlot = Read();
            AddUserData = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(RuntimeEntityID);
            Write(SelectedSlot);
            Write(AddUserData);
            return After();
        }
    }
    [RegisterPacketID(0x24)]
    public class MCPE_PLAYER_ACTION : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public int ActionID; // Placeholder for the actual field
        public object Coordinates; // Placeholder for the actual field
        public object ResultCoordinates; // Placeholder for the actual field
        public int Face; // Placeholder for the actual field
        public MCPE_PLAYER_ACTION() : base(0x24)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            ActionID = ReadSignedVarInt();
            Coordinates = Read();
            ResultCoordinates = Read();
            Face = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            WriteSignedVarInt(ActionID);
            Write(Coordinates);
            Write(ResultCoordinates);
            WriteSignedVarInt(Face);
            return After();
        }
    }
    [RegisterPacketID(0x26)]
    public class MCPE_HURT_ARMOR : Packet
    {
        public int Cause; // Placeholder for the actual field
        public int Health; // Placeholder for the actual field
        public long Armorslotflags; // Placeholder for the actual field
        public MCPE_HURT_ARMOR() : base(0x26)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Cause = ReadVarInt();
            Health = ReadSignedVarInt();
            Armorslotflags = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteVarInt(Cause);
            WriteSignedVarInt(Health);
            WriteUnsignedVarLong(Armorslotflags);
            return After();
        }
    }
    [RegisterPacketID(0x27)]
    public class MCPE_SET_ENTITY_DATA : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Metadata; // Placeholder for the actual field
        public object SyncData; // Placeholder for the actual field
        public long Tick; // Placeholder for the actual field
        public MCPE_SET_ENTITY_DATA() : base(0x27)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Metadata = Read();
            SyncData = Read();
            Tick = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Metadata);
            Write(SyncData);
            WriteUnsignedVarLong(Tick);
            return After();
        }
    }
    [RegisterPacketID(0x28)]
    public class MCPE_SET_ENTITY_MOTION : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Velocity; // Placeholder for the actual field
        public MCPE_SET_ENTITY_MOTION() : base(0x28)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Velocity = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Velocity);
            return After();
        }
    }
    [RegisterPacketID(0x29)]
    public class MCPE_SET_ENTITY_LINK : Packet
    {
        public object RiddenID; // Placeholder for the actual field
        public object RiderID; // Placeholder for the actual field
        public object LinkType; // Placeholder for the actual field
        public object Unknown; // Placeholder for the actual field
        public MCPE_SET_ENTITY_LINK() : base(0x29)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RiddenID = Read();
            RiderID = Read();
            LinkType = Read();
            Unknown = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(RiddenID);
            Write(RiderID);
            Write(LinkType);
            Write(Unknown);
            return After();
        }
    }
    [RegisterPacketID(0x2a)]
    public class MCPE_SET_HEALTH : Packet
    {
        public int Health; // Placeholder for the actual field
        public MCPE_SET_HEALTH() : base(0x2a)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Health = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(Health);
            return After();
        }
    }
    [RegisterPacketID(0x2b)]
    public class MCPE_SET_SPAWN_POSITION : Packet
    {
        public int SpawnType; // Placeholder for the actual field
        public object Coordinates; // Placeholder for the actual field
        public int Dimension; // Placeholder for the actual field
        public object Unknowncoordinates; // Placeholder for the actual field
        public MCPE_SET_SPAWN_POSITION() : base(0x2b)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            SpawnType = ReadSignedVarInt();
            Coordinates = Read();
            Dimension = ReadSignedVarInt();
            Unknowncoordinates = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(SpawnType);
            Write(Coordinates);
            WriteSignedVarInt(Dimension);
            Write(Unknowncoordinates);
            return After();
        }
    }
    [RegisterPacketID(0x2c)]
    public class MCPE_ANIMATE : Packet
    {
        public int ActionID; // Placeholder for the actual field
        public long RuntimeEntityID; // Placeholder for the actual field
        public MCPE_ANIMATE() : base(0x2c)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ActionID = ReadSignedVarInt();
            RuntimeEntityID = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(ActionID);
            WriteUnsignedVarLong(RuntimeEntityID);
            return After();
        }
    }
    [RegisterPacketID(0x2d)]
    public class MCPE_RESPAWN : Packet
    {
        public object X; // Placeholder for the actual field
        public object Y; // Placeholder for the actual field
        public object Z; // Placeholder for the actual field
        public object State; // Placeholder for the actual field
        public long RuntimeEntityID; // Placeholder for the actual field
        public MCPE_RESPAWN() : base(0x2d)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            X = Read();
            Y = Read();
            Z = Read();
            State = Read();
            RuntimeEntityID = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(X);
            Write(Y);
            Write(Z);
            Write(State);
            WriteUnsignedVarLong(RuntimeEntityID);
            return After();
        }
    }
    [RegisterPacketID(0x2e)]
    public class MCPE_CONTAINER_OPEN : Packet
    {
        public object WindowID; // Placeholder for the actual field
        public object Type; // Placeholder for the actual field
        public object Coordinates; // Placeholder for the actual field
        public object RuntimeEntityID; // Placeholder for the actual field
        public MCPE_CONTAINER_OPEN() : base(0x2e)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            WindowID = Read();
            Type = Read();
            Coordinates = Read();
            RuntimeEntityID = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(WindowID);
            Write(Type);
            Write(Coordinates);
            Write(RuntimeEntityID);
            return After();
        }
    }
    [RegisterPacketID(0x2f)]
    public class MCPE_CONTAINER_CLOSE : Packet
    {
        public object WindowID; // Placeholder for the actual field
        public object Server; // Placeholder for the actual field
        public MCPE_CONTAINER_CLOSE() : base(0x2f)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            WindowID = Read();
            Server = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(WindowID);
            Write(Server);
            return After();
        }
    }
    [RegisterPacketID(0x30)]
    public class MCPE_PLAYER_HOTBAR : Packet
    {
        public uint SelectedSlot; // Placeholder for the actual field
        public object WindowID; // Placeholder for the actual field
        public object SelectSlot; // Placeholder for the actual field
        public MCPE_PLAYER_HOTBAR() : base(0x30)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            SelectedSlot = ReadUnsignedVarInt();
            WindowID = Read();
            SelectSlot = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarInt(SelectedSlot);
            Write(WindowID);
            Write(SelectSlot);
            return After();
        }
    }
    [RegisterPacketID(0x31)]
    public class MCPE_INVENTORY_CONTENT : Packet
    {
        public uint InventoryId; // Placeholder for the actual field
        public object Input; // Placeholder for the actual field
        public MCPE_INVENTORY_CONTENT() : base(0x31)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            InventoryId = ReadUnsignedVarInt();
            Input = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarInt(InventoryId);
            Write(Input);
            return After();
        }
    }
    [RegisterPacketID(0x32)]
    public class MCPE_INVENTORY_SLOT : Packet
    {
        public uint InventoryId; // Placeholder for the actual field
        public uint Slot; // Placeholder for the actual field
        public object Item; // Placeholder for the actual field
        public MCPE_INVENTORY_SLOT() : base(0x32)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            InventoryId = ReadUnsignedVarInt();
            Slot = ReadUnsignedVarInt();
            Item = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarInt(InventoryId);
            WriteUnsignedVarInt(Slot);
            Write(Item);
            return After();
        }
    }
    [RegisterPacketID(0x33)]
    public class MCPE_CONTAINER_SET_DATA : Packet
    {
        public object WindowID; // Placeholder for the actual field
        public int Property; // Placeholder for the actual field
        public int Value; // Placeholder for the actual field
        public MCPE_CONTAINER_SET_DATA() : base(0x33)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            WindowID = Read();
            Property = ReadSignedVarInt();
            Value = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(WindowID);
            WriteSignedVarInt(Property);
            WriteSignedVarInt(Value);
            return After();
        }
    }
    [RegisterPacketID(0x34)]
    public class MCPE_CRAFTING_DATA : Packet
    {
        public object Recipes; // Placeholder for the actual field
        public object Potiontyperecipes; // Placeholder for the actual field
        public object potioncontainerrecipes; // Placeholder for the actual field
        public object Materialreducerrecipes; // Placeholder for the actual field
        public object IsClean; // Placeholder for the actual field
        public MCPE_CRAFTING_DATA() : base(0x34)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Recipes = Read();
            Potiontyperecipes = Read();
            potioncontainerrecipes = Read();
            Materialreducerrecipes = Read();
            IsClean = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Recipes);
            Write(Potiontyperecipes);
            Write(potioncontainerrecipes);
            Write(Materialreducerrecipes);
            Write(IsClean);
            return After();
        }
    }
    [RegisterPacketID(0x35)]
    public class MCPE_CRAFTING_EVENT : Packet
    {
        public object WindowID; // Placeholder for the actual field
        public int RecipeType; // Placeholder for the actual field
        public object RecipeID; // Placeholder for the actual field
        public object Input; // Placeholder for the actual field
        public object Result; // Placeholder for the actual field
        public MCPE_CRAFTING_EVENT() : base(0x35)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            WindowID = Read();
            RecipeType = ReadSignedVarInt();
            RecipeID = Read();
            Input = Read();
            Result = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(WindowID);
            WriteSignedVarInt(RecipeType);
            Write(RecipeID);
            Write(Input);
            Write(Result);
            return After();
        }
    }
    [RegisterPacketID(0x36)]
    public class MCPE_GUI_DATA_PICK_ITEM : Packet
    {
        public MCPE_GUI_DATA_PICK_ITEM() : base(0x36)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x37)]
    public class MCPE_ADVENTURE_SETTINGS : Packet
    {
        public uint Flags; // Placeholder for the actual field
        public uint Commandpermission; // Placeholder for the actual field
        public uint Actionpermissions; // Placeholder for the actual field
        public uint Permissionlevel; // Placeholder for the actual field
        public uint Customstoredpermissions; // Placeholder for the actual field
        public object EntityUniqueId; // Placeholder for the actual field
        public MCPE_ADVENTURE_SETTINGS() : base(0x37)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Flags = ReadUnsignedVarInt();
            Commandpermission = ReadUnsignedVarInt();
            Actionpermissions = ReadUnsignedVarInt();
            Permissionlevel = ReadUnsignedVarInt();
            Customstoredpermissions = ReadUnsignedVarInt();
            EntityUniqueId = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarInt(Flags);
            WriteUnsignedVarInt(Commandpermission);
            WriteUnsignedVarInt(Actionpermissions);
            WriteUnsignedVarInt(Permissionlevel);
            WriteUnsignedVarInt(Customstoredpermissions);
            Write(EntityUniqueId);
            return After();
        }
    }
    [RegisterPacketID(0x38)]
    public class MCPE_BLOCK_ENTITY_DATA : Packet
    {
        public object Coordinates; // Placeholder for the actual field
        public object NamedTag; // Placeholder for the actual field
        public MCPE_BLOCK_ENTITY_DATA() : base(0x38)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Coordinates = Read();
            NamedTag = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Coordinates);
            Write(NamedTag);
            return After();
        }
    }
    [RegisterPacketID(0x39)]
    public class MCPE_PLAYER_INPUT : Packet
    {
        public object MotionX; // Placeholder for the actual field
        public object MotionZ; // Placeholder for the actual field
        public object Jumping; // Placeholder for the actual field
        public object Sneaking; // Placeholder for the actual field
        public MCPE_PLAYER_INPUT() : base(0x39)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            MotionX = Read();
            MotionZ = Read();
            Jumping = Read();
            Sneaking = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(MotionX);
            Write(MotionZ);
            Write(Jumping);
            Write(Sneaking);
            return After();
        }
    }
    [RegisterPacketID(0x3a)]
    public class MCPE_LEVEL_CHUNK : Packet
    {
        public int ChunkX; // Placeholder for the actual field
        public int ChunkZ; // Placeholder for the actual field
        public MCPE_LEVEL_CHUNK() : base(0x3a)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ChunkX = ReadSignedVarInt();
            ChunkZ = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(ChunkX);
            WriteSignedVarInt(ChunkZ);
            return After();
        }
    }
    [RegisterPacketID(0x3b)]
    public class MCPE_SET_COMMANDS_ENABLED : Packet
    {
        public object Enabled; // Placeholder for the actual field
        public MCPE_SET_COMMANDS_ENABLED() : base(0x3b)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Enabled = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Enabled);
            return After();
        }
    }
    [RegisterPacketID(0x3c)]
    public class MCPE_SET_DIFFICULTY : Packet
    {
        public uint Difficulty; // Placeholder for the actual field
        public MCPE_SET_DIFFICULTY() : base(0x3c)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Difficulty = ReadUnsignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarInt(Difficulty);
            return After();
        }
    }
    [RegisterPacketID(0x3d)]
    public class MCPE_CHANGE_DIMENSION : Packet
    {
        public int Dimension; // Placeholder for the actual field
        public object Position; // Placeholder for the actual field
        public object Respawn; // Placeholder for the actual field
        public MCPE_CHANGE_DIMENSION() : base(0x3d)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Dimension = ReadSignedVarInt();
            Position = Read();
            Respawn = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(Dimension);
            Write(Position);
            Write(Respawn);
            return After();
        }
    }
    [RegisterPacketID(0x3e)]
    public class MCPE_SET_PLAYER_GAME_TYPE : Packet
    {
        public int Gamemode; // Placeholder for the actual field
        public MCPE_SET_PLAYER_GAME_TYPE() : base(0x3e)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Gamemode = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(Gamemode);
            return After();
        }
    }
    [RegisterPacketID(0x3f)]
    public class MCPE_PLAYER_LIST : Packet
    {
        public object Records; // Placeholder for the actual field
        public MCPE_PLAYER_LIST() : base(0x3f)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Records = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Records);
            return After();
        }
    }
    [RegisterPacketID(0x40)]
    public class MCPE_SIMPLE_EVENT : Packet
    {
        public object EventType; // Placeholder for the actual field
        public MCPE_SIMPLE_EVENT() : base(0x40)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            EventType = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(EventType);
            return After();
        }
    }
    [RegisterPacketID(0x41)]
    public class MCPE_TELEMETRY_EVENT : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public int Eventdata; // Placeholder for the actual field
        public object Eventtype; // Placeholder for the actual field
        public object AuxData; // Placeholder for the actual field
        public MCPE_TELEMETRY_EVENT() : base(0x41)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Eventdata = ReadSignedVarInt();
            Eventtype = Read();
            AuxData = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            WriteSignedVarInt(Eventdata);
            Write(Eventtype);
            Write(AuxData);
            return After();
        }
    }
    [RegisterPacketID(0x42)]
    public class MCPE_SPAWN_EXPERIENCE_ORB : Packet
    {
        public object Position; // Placeholder for the actual field
        public int Count; // Placeholder for the actual field
        public MCPE_SPAWN_EXPERIENCE_ORB() : base(0x42)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Position = Read();
            Count = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Position);
            WriteSignedVarInt(Count);
            return After();
        }
    }
    [RegisterPacketID(0x43)]
    public class MCPE_CLIENTBOUND_MAP_ITEM_DATA : Packet
    {
        public object MapInfo; // Placeholder for the actual field
        public MCPE_CLIENTBOUND_MAP_ITEM_DATA() : base(0x43)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            MapInfo = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(MapInfo);
            return After();
        }
    }
    [RegisterPacketID(0x44)]
    public class MCPE_MAP_INFO_REQUEST : Packet
    {
        public object MapID; // Placeholder for the actual field
        public MCPE_MAP_INFO_REQUEST() : base(0x44)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            MapID = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(MapID);
            return After();
        }
    }
    [RegisterPacketID(0x45)]
    public class MCPE_REQUEST_CHUNK_RADIUS : Packet
    {
        public int ChunkRadius; // Placeholder for the actual field
        public object MaxRadius; // Placeholder for the actual field
        public MCPE_REQUEST_CHUNK_RADIUS() : base(0x45)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ChunkRadius = ReadSignedVarInt();
            MaxRadius = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(ChunkRadius);
            Write(MaxRadius);
            return After();
        }
    }
    [RegisterPacketID(0x46)]
    public class MCPE_CHUNK_RADIUS_UPDATE : Packet
    {
        public int ChunkRadius; // Placeholder for the actual field
        public MCPE_CHUNK_RADIUS_UPDATE() : base(0x46)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ChunkRadius = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(ChunkRadius);
            return After();
        }
    }
    [RegisterPacketID(0x47)]
    public class MCPE_ITEM_FRAME_DROP_ITEM : Packet
    {
        public object Coordinates; // Placeholder for the actual field
        public MCPE_ITEM_FRAME_DROP_ITEM() : base(0x47)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Coordinates = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Coordinates);
            return After();
        }
    }
    [RegisterPacketID(0x48)]
    public class MCPE_GAME_RULES_CHANGED : Packet
    {
        public object Rules; // Placeholder for the actual field
        public MCPE_GAME_RULES_CHANGED() : base(0x48)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Rules = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Rules);
            return After();
        }
    }
    [RegisterPacketID(0x49)]
    public class MCPE_CAMERA : Packet
    {
        public object Unknown1; // Placeholder for the actual field
        public object Unknown2; // Placeholder for the actual field
        public MCPE_CAMERA() : base(0x49)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Unknown1 = Read();
            Unknown2 = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Unknown1);
            Write(Unknown2);
            return After();
        }
    }
    [RegisterPacketID(0x4a)]
    public class MCPE_BOSS_EVENT : Packet
    {
        public object BossEntityID; // Placeholder for the actual field
        public uint EventType; // Placeholder for the actual field
        public MCPE_BOSS_EVENT() : base(0x4a)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            BossEntityID = Read();
            EventType = ReadUnsignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(BossEntityID);
            WriteUnsignedVarInt(EventType);
            return After();
        }
    }
    [RegisterPacketID(0x4b)]
    public class MCPE_SHOW_CREDITS : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public int Status; // Placeholder for the actual field
        public MCPE_SHOW_CREDITS() : base(0x4b)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Status = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            WriteSignedVarInt(Status);
            return After();
        }
    }
    [RegisterPacketID(0x4c)]
    public class MCPE_AVAILABLE_COMMANDS : Packet
    {
        public MCPE_AVAILABLE_COMMANDS() : base(0x4c)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x4d)]
    public class MCPE_COMMAND_REQUEST : Packet
    {
        public string Command; // Placeholder for the actual field
        public uint Commandtype; // Placeholder for the actual field
        public object UnknownUUID; // Placeholder for the actual field
        public string RequestID; // Placeholder for the actual field
        public object IsInternal; // Placeholder for the actual field
        public int Version; // Placeholder for the actual field
        public MCPE_COMMAND_REQUEST() : base(0x4d)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Command = ReadString();
            Commandtype = ReadUnsignedVarInt();
            UnknownUUID = Read();
            RequestID = ReadString();
            IsInternal = Read();
            Version = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Command);
            WriteUnsignedVarInt(Commandtype);
            Write(UnknownUUID);
            Write(RequestID);
            Write(IsInternal);
            WriteSignedVarInt(Version);
            return After();
        }
    }
    [RegisterPacketID(0x4e)]
    public class MCPE_COMMAND_BLOCK_UPDATE : Packet
    {
        public object IsBlock; // Placeholder for the actual field
        public MCPE_COMMAND_BLOCK_UPDATE() : base(0x4e)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            IsBlock = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(IsBlock);
            return After();
        }
    }
    [RegisterPacketID(0x4f)]
    public class MCPE_COMMAND_OUTPUT : Packet
    {
        public MCPE_COMMAND_OUTPUT() : base(0x4f)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x50)]
    public class MCPE_UPDATE_TRADE : Packet
    {
        public object WindowID; // Placeholder for the actual field
        public object WindowType; // Placeholder for the actual field
        public int Unknown0; // Placeholder for the actual field
        public int Unknown1; // Placeholder for the actual field
        public int Unknown2; // Placeholder for the actual field
        public object IsWilling; // Placeholder for the actual field
        public object TraderEntityID; // Placeholder for the actual field
        public object PlayerEntityID; // Placeholder for the actual field
        public string DisplayName; // Placeholder for the actual field
        public object NamedTag; // Placeholder for the actual field
        public MCPE_UPDATE_TRADE() : base(0x50)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            WindowID = Read();
            WindowType = Read();
            Unknown0 = ReadVarInt();
            Unknown1 = ReadVarInt();
            Unknown2 = ReadVarInt();
            IsWilling = Read();
            TraderEntityID = Read();
            PlayerEntityID = Read();
            DisplayName = ReadString();
            NamedTag = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(WindowID);
            Write(WindowType);
            WriteVarInt(Unknown0);
            WriteVarInt(Unknown1);
            WriteVarInt(Unknown2);
            Write(IsWilling);
            Write(TraderEntityID);
            Write(PlayerEntityID);
            Write(DisplayName);
            Write(NamedTag);
            return After();
        }
    }
    [RegisterPacketID(0x51)]
    public class MCPE_UPDATE_EQUIPMENT : Packet
    {
        public object WindowID; // Placeholder for the actual field
        public object WindowType; // Placeholder for the actual field
        public object Unknown; // Placeholder for the actual field
        public object EntityID; // Placeholder for the actual field
        public object NamedTag; // Placeholder for the actual field
        public MCPE_UPDATE_EQUIPMENT() : base(0x51)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            WindowID = Read();
            WindowType = Read();
            Unknown = Read();
            EntityID = Read();
            NamedTag = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(WindowID);
            Write(WindowType);
            Write(Unknown);
            Write(EntityID);
            Write(NamedTag);
            return After();
        }
    }
    [RegisterPacketID(0x52)]
    public class MCPE_RESOURCE_PACK_DATA_INFO : Packet
    {
        public string PackageID; // Placeholder for the actual field
        public object MaxChunkSize; // Placeholder for the actual field
        public object ChunkCount; // Placeholder for the actual field
        public object CompressedPackageSize; // Placeholder for the actual field
        public byte[] Hash; // Placeholder for the actual field
        public object IsPremium; // Placeholder for the actual field
        public object PackType; // Placeholder for the actual field
        public MCPE_RESOURCE_PACK_DATA_INFO() : base(0x52)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            PackageID = ReadString();
            MaxChunkSize = Read();
            ChunkCount = Read();
            CompressedPackageSize = Read();
            Hash = ReadByteArray();
            IsPremium = Read();
            PackType = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(PackageID);
            Write(MaxChunkSize);
            Write(ChunkCount);
            Write(CompressedPackageSize);
            WriteByteArray(Hash);
            Write(IsPremium);
            Write(PackType);
            return After();
        }
    }
    [RegisterPacketID(0x53)]
    public class MCPE_RESOURCE_PACK_CHUNK_DATA : Packet
    {
        public string PackageID; // Placeholder for the actual field
        public object ChunkIndex; // Placeholder for the actual field
        public object Progress; // Placeholder for the actual field
        public byte[] Payload; // Placeholder for the actual field
        public MCPE_RESOURCE_PACK_CHUNK_DATA() : base(0x53)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            PackageID = ReadString();
            ChunkIndex = Read();
            Progress = Read();
            Payload = ReadByteArray();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(PackageID);
            Write(ChunkIndex);
            Write(Progress);
            WriteByteArray(Payload);
            return After();
        }
    }
    [RegisterPacketID(0x54)]
    public class MCPE_RESOURCE_PACK_CHUNK_REQUEST : Packet
    {
        public string PackageID; // Placeholder for the actual field
        public object ChunkIndex; // Placeholder for the actual field
        public MCPE_RESOURCE_PACK_CHUNK_REQUEST() : base(0x54)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            PackageID = ReadString();
            ChunkIndex = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(PackageID);
            Write(ChunkIndex);
            return After();
        }
    }
    [RegisterPacketID(0x55)]
    public class MCPE_TRANSFER : Packet
    {
        public string ServerAddress; // Placeholder for the actual field
        public object Port; // Placeholder for the actual field
        public MCPE_TRANSFER() : base(0x55)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ServerAddress = ReadString();
            Port = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(ServerAddress);
            Write(Port);
            return After();
        }
    }
    [RegisterPacketID(0x56)]
    public class MCPE_PLAY_SOUND : Packet
    {
        public string Name; // Placeholder for the actual field
        public object Coordinates; // Placeholder for the actual field
        public object Volume; // Placeholder for the actual field
        public object Pitch; // Placeholder for the actual field
        public MCPE_PLAY_SOUND() : base(0x56)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Name = ReadString();
            Coordinates = Read();
            Volume = Read();
            Pitch = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Name);
            Write(Coordinates);
            Write(Volume);
            Write(Pitch);
            return After();
        }
    }
    [RegisterPacketID(0x57)]
    public class MCPE_STOP_SOUND : Packet
    {
        public string Name; // Placeholder for the actual field
        public object StopAll; // Placeholder for the actual field
        public MCPE_STOP_SOUND() : base(0x57)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Name = ReadString();
            StopAll = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Name);
            Write(StopAll);
            return After();
        }
    }
    [RegisterPacketID(0x58)]
    public class MCPE_SET_TITLE : Packet
    {
        public int Type; // Placeholder for the actual field
        public string Text; // Placeholder for the actual field
        public int FadeInTime; // Placeholder for the actual field
        public int StayTime; // Placeholder for the actual field
        public int FadeOutTime; // Placeholder for the actual field
        public string Xuid; // Placeholder for the actual field
        public string PlatformOnlineId; // Placeholder for the actual field
        public MCPE_SET_TITLE() : base(0x58)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Type = ReadSignedVarInt();
            Text = ReadString();
            FadeInTime = ReadSignedVarInt();
            StayTime = ReadSignedVarInt();
            FadeOutTime = ReadSignedVarInt();
            Xuid = ReadString();
            PlatformOnlineId = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(Type);
            Write(Text);
            WriteSignedVarInt(FadeInTime);
            WriteSignedVarInt(StayTime);
            WriteSignedVarInt(FadeOutTime);
            Write(Xuid);
            Write(PlatformOnlineId);
            return After();
        }
    }
    [RegisterPacketID(0x59)]
    public class MCPE_ADD_BEHAVIOR_TREE : Packet
    {
        public string BehaviorTree; // Placeholder for the actual field
        public MCPE_ADD_BEHAVIOR_TREE() : base(0x59)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            BehaviorTree = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(BehaviorTree);
            return After();
        }
    }
    [RegisterPacketID(0x5a)]
    public class MCPE_STRUCTURE_BLOCK_UPDATE : Packet
    {
        public MCPE_STRUCTURE_BLOCK_UPDATE() : base(0x5a)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x5b)]
    public class MCPE_SHOW_STORE_OFFER : Packet
    {
        public string Unknown0; // Placeholder for the actual field
        public object Unknown1; // Placeholder for the actual field
        public MCPE_SHOW_STORE_OFFER() : base(0x5b)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Unknown0 = ReadString();
            Unknown1 = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Unknown0);
            Write(Unknown1);
            return After();
        }
    }
    [RegisterPacketID(0x5c)]
    public class MCPE_PURCHASE_RECEIPT : Packet
    {
        public MCPE_PURCHASE_RECEIPT() : base(0x5c)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x5d)]
    public class MCPE_PLAYER_SKIN : Packet
    {
        public object UUID; // Placeholder for the actual field
        public object Skin; // Placeholder for the actual field
        public string SkinName; // Placeholder for the actual field
        public string OldSkinName; // Placeholder for the actual field
        public object isVerified; // Placeholder for the actual field
        public MCPE_PLAYER_SKIN() : base(0x5d)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            UUID = Read();
            Skin = Read();
            SkinName = ReadString();
            OldSkinName = ReadString();
            isVerified = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(UUID);
            Write(Skin);
            Write(SkinName);
            Write(OldSkinName);
            Write(isVerified);
            return After();
        }
    }
    [RegisterPacketID(0x5e)]
    public class MCPE_SUB_CLIENT_LOGIN : Packet
    {
        public MCPE_SUB_CLIENT_LOGIN() : base(0x5e)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x5f)]
    public class MCPE_INITIATE_WEB_SOCKET_CONNECTION : Packet
    {
        public string Server; // Placeholder for the actual field
        public MCPE_INITIATE_WEB_SOCKET_CONNECTION() : base(0x5f)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Server = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Server);
            return After();
        }
    }
    [RegisterPacketID(0x60)]
    public class MCPE_SET_LAST_HURT_BY : Packet
    {
        public int Unknown; // Placeholder for the actual field
        public MCPE_SET_LAST_HURT_BY() : base(0x60)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Unknown = ReadVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteVarInt(Unknown);
            return After();
        }
    }
    [RegisterPacketID(0x61)]
    public class MCPE_BOOK_EDIT : Packet
    {
        public MCPE_BOOK_EDIT() : base(0x61)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x62)]
    public class MCPE_NPC_REQUEST : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Unknown0; // Placeholder for the actual field
        public string Unknown1; // Placeholder for the actual field
        public object Unknown2; // Placeholder for the actual field
        public MCPE_NPC_REQUEST() : base(0x62)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Unknown0 = Read();
            Unknown1 = ReadString();
            Unknown2 = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Unknown0);
            Write(Unknown1);
            Write(Unknown2);
            return After();
        }
    }
    [RegisterPacketID(0x63)]
    public class MCPE_PHOTO_TRANSFER : Packet
    {
        public string Filename; // Placeholder for the actual field
        public string Imagedata; // Placeholder for the actual field
        public string Unknown2; // Placeholder for the actual field
        public MCPE_PHOTO_TRANSFER() : base(0x63)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Filename = ReadString();
            Imagedata = ReadString();
            Unknown2 = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Filename);
            Write(Imagedata);
            Write(Unknown2);
            return After();
        }
    }
    [RegisterPacketID(0x64)]
    public class MCPE_MODAL_FORM_REQUEST : Packet
    {
        public object ModalFormInfo; // Placeholder for the actual field
        public MCPE_MODAL_FORM_REQUEST() : base(0x64)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ModalFormInfo = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(ModalFormInfo);
            return After();
        }
    }
    [RegisterPacketID(0x65)]
    public class MCPE_MODAL_FORM_RESPONSE : Packet
    {
        public uint FormId; // Placeholder for the actual field
        public string Data; // Placeholder for the actual field
        public MCPE_MODAL_FORM_RESPONSE() : base(0x65)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            FormId = ReadUnsignedVarInt();
            Data = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarInt(FormId);
            Write(Data);
            return After();
        }
    }
    [RegisterPacketID(0x66)]
    public class MCPE_SERVER_SETTINGS_REQUEST : Packet
    {
        public MCPE_SERVER_SETTINGS_REQUEST() : base(0x66)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x67)]
    public class MCPE_SERVER_SETTINGS_RESPONSE : Packet
    {
        public long FormId; // Placeholder for the actual field
        public string Data; // Placeholder for the actual field
        public MCPE_SERVER_SETTINGS_RESPONSE() : base(0x67)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            FormId = ReadUnsignedVarLong();
            Data = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(FormId);
            Write(Data);
            return After();
        }
    }
    [RegisterPacketID(0x68)]
    public class MCPE_SHOW_PROFILE : Packet
    {
        public string XUID; // Placeholder for the actual field
        public MCPE_SHOW_PROFILE() : base(0x68)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            XUID = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(XUID);
            return After();
        }
    }
    [RegisterPacketID(0x69)]
    public class MCPE_SET_DEFAULT_GAME_TYPE : Packet
    {
        public int Gamemode; // Placeholder for the actual field
        public MCPE_SET_DEFAULT_GAME_TYPE() : base(0x69)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Gamemode = ReadVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteVarInt(Gamemode);
            return After();
        }
    }
    [RegisterPacketID(0x6a)]
    public class MCPE_REMOVE_OBJECTIVE : Packet
    {
        public string ObjectiveName; // Placeholder for the actual field
        public MCPE_REMOVE_OBJECTIVE() : base(0x6a)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ObjectiveName = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(ObjectiveName);
            return After();
        }
    }
    [RegisterPacketID(0x6b)]
    public class MCPE_SET_DISPLAY_OBJECTIVE : Packet
    {
        public string DisplaySlot; // Placeholder for the actual field
        public string ObjectiveName; // Placeholder for the actual field
        public string DisplayName; // Placeholder for the actual field
        public string CriteriaName; // Placeholder for the actual field
        public int SortOrder; // Placeholder for the actual field
        public MCPE_SET_DISPLAY_OBJECTIVE() : base(0x6b)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            DisplaySlot = ReadString();
            ObjectiveName = ReadString();
            DisplayName = ReadString();
            CriteriaName = ReadString();
            SortOrder = ReadSignedVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(DisplaySlot);
            Write(ObjectiveName);
            Write(DisplayName);
            Write(CriteriaName);
            WriteSignedVarInt(SortOrder);
            return After();
        }
    }
    [RegisterPacketID(0x6c)]
    public class MCPE_SET_SCORE : Packet
    {
        public object Entries; // Placeholder for the actual field
        public MCPE_SET_SCORE() : base(0x6c)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Entries = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Entries);
            return After();
        }
    }
    [RegisterPacketID(0x6d)]
    public class MCPE_LAB_TABLE : Packet
    {
        public object UselessByte; // Placeholder for the actual field
        public int LabTableX; // Placeholder for the actual field
        public int LabTableY; // Placeholder for the actual field
        public int LabTableZ; // Placeholder for the actual field
        public object ReactionType; // Placeholder for the actual field
        public MCPE_LAB_TABLE() : base(0x6d)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            UselessByte = Read();
            LabTableX = ReadVarInt();
            LabTableY = ReadVarInt();
            LabTableZ = ReadVarInt();
            ReactionType = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(UselessByte);
            WriteVarInt(LabTableX);
            WriteVarInt(LabTableY);
            WriteVarInt(LabTableZ);
            Write(ReactionType);
            return After();
        }
    }
    [RegisterPacketID(0x6e)]
    public class MCPE_UPDATE_BLOCK_SYNCED : Packet
    {
        public object Coordinates; // Placeholder for the actual field
        public uint BlockRuntimeID; // Placeholder for the actual field
        public uint BlockPriority; // Placeholder for the actual field
        public uint DataLayerID; // Placeholder for the actual field
        public long Unknown0; // Placeholder for the actual field
        public long Unknown1; // Placeholder for the actual field
        public MCPE_UPDATE_BLOCK_SYNCED() : base(0x6e)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Coordinates = Read();
            BlockRuntimeID = ReadUnsignedVarInt();
            BlockPriority = ReadUnsignedVarInt();
            DataLayerID = ReadUnsignedVarInt();
            Unknown0 = ReadUnsignedVarLong();
            Unknown1 = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Coordinates);
            WriteUnsignedVarInt(BlockRuntimeID);
            WriteUnsignedVarInt(BlockPriority);
            WriteUnsignedVarInt(DataLayerID);
            WriteUnsignedVarLong(Unknown0);
            WriteUnsignedVarLong(Unknown1);
            return After();
        }
    }
    [RegisterPacketID(0x6f)]
    public class MCPE_MOVE_ENTITY_DELTA : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public object Flags; // Placeholder for the actual field
        public MCPE_MOVE_ENTITY_DELTA() : base(0x6f)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            Flags = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(Flags);
            return After();
        }
    }
    [RegisterPacketID(0x70)]
    public class MCPE_SET_SCOREBOARD_IDENTITY : Packet
    {
        public object Entries; // Placeholder for the actual field
        public MCPE_SET_SCOREBOARD_IDENTITY() : base(0x70)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Entries = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Entries);
            return After();
        }
    }
    [RegisterPacketID(0x71)]
    public class MCPE_SET_LOCAL_PLAYER_AS_INITIALIZED : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public MCPE_SET_LOCAL_PLAYER_AS_INITIALIZED() : base(0x71)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            return After();
        }
    }
    [RegisterPacketID(0x72)]
    public class MCPE_UPDATE_SOFT_ENUM : Packet
    {
        public MCPE_UPDATE_SOFT_ENUM() : base(0x72)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x73)]
    public class MCPE_NETWORK_STACK_LATENCY : Packet
    {
        public object Timestamp; // Placeholder for the actual field
        public object UnknownFlag; // Placeholder for the actual field
        public MCPE_NETWORK_STACK_LATENCY() : base(0x73)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Timestamp = Read();
            UnknownFlag = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Timestamp);
            Write(UnknownFlag);
            return After();
        }
    }
    [RegisterPacketID(0x75)]
    public class MCPE_SCRIPT_CUSTOM_EVENT : Packet
    {
        public string EventName; // Placeholder for the actual field
        public string EventData; // Placeholder for the actual field
        public MCPE_SCRIPT_CUSTOM_EVENT() : base(0x75)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            EventName = ReadString();
            EventData = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(EventName);
            Write(EventData);
            return After();
        }
    }
    [RegisterPacketID(0x76)]
    public class MCPE_SPAWN_PARTICLE_EFFECT : Packet
    {
        public object DimensionID; // Placeholder for the actual field
        public object EntityID; // Placeholder for the actual field
        public object Position; // Placeholder for the actual field
        public string Particlename; // Placeholder for the actual field
        public string MolangVariablesJson; // Placeholder for the actual field
        public MCPE_SPAWN_PARTICLE_EFFECT() : base(0x76)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            DimensionID = Read();
            EntityID = Read();
            Position = Read();
            Particlename = ReadString();
            MolangVariablesJson = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(DimensionID);
            Write(EntityID);
            Write(Position);
            Write(Particlename);
            Write(MolangVariablesJson);
            return After();
        }
    }
    [RegisterPacketID(0x77)]
    public class MCPE_AVAILABLE_ENTITY_IDENTIFIERS : Packet
    {
        public object NamedTag; // Placeholder for the actual field
        public MCPE_AVAILABLE_ENTITY_IDENTIFIERS() : base(0x77)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            NamedTag = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(NamedTag);
            return After();
        }
    }
    [RegisterPacketID(0x78)]
    public class MCPE_LEVEL_SOUND_EVENT_V2 : Packet
    {
        public object SoundID; // Placeholder for the actual field
        public object Position; // Placeholder for the actual field
        public int BlockId; // Placeholder for the actual field
        public string EntityType; // Placeholder for the actual field
        public object Isbabymob; // Placeholder for the actual field
        public object Isglobal; // Placeholder for the actual field
        public MCPE_LEVEL_SOUND_EVENT_V2() : base(0x78)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            SoundID = Read();
            Position = Read();
            BlockId = ReadSignedVarInt();
            EntityType = ReadString();
            Isbabymob = Read();
            Isglobal = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(SoundID);
            Write(Position);
            WriteSignedVarInt(BlockId);
            Write(EntityType);
            Write(Isbabymob);
            Write(Isglobal);
            return After();
        }
    }
    [RegisterPacketID(0x79)]
    public class MCPE_NETWORK_CHUNK_PUBLISHER_UPDATE : Packet
    {
        public object Coordinates; // Placeholder for the actual field
        public uint Radius; // Placeholder for the actual field
        public int SavedChunks; // Placeholder for the actual field
        public MCPE_NETWORK_CHUNK_PUBLISHER_UPDATE() : base(0x79)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Coordinates = Read();
            Radius = ReadUnsignedVarInt();
            SavedChunks = ReadInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Coordinates);
            WriteUnsignedVarInt(Radius);
            Write(SavedChunks);
            return After();
        }
    }
    [RegisterPacketID(0x7a)]
    public class MCPE_BIOME_DEFINITION_LIST : Packet
    {
        public object NamedTag; // Placeholder for the actual field
        public MCPE_BIOME_DEFINITION_LIST() : base(0x7a)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            NamedTag = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(NamedTag);
            return After();
        }
    }
    [RegisterPacketID(0x7b)]
    public class MCPE_LEVEL_SOUND_EVENT : Packet
    {
        public uint SoundID; // Placeholder for the actual field
        public object Position; // Placeholder for the actual field
        public int BlockId; // Placeholder for the actual field
        public string EntityType; // Placeholder for the actual field
        public object Isbabymob; // Placeholder for the actual field
        public object Isglobal; // Placeholder for the actual field
        public MCPE_LEVEL_SOUND_EVENT() : base(0x7b)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            SoundID = ReadUnsignedVarInt();
            Position = Read();
            BlockId = ReadSignedVarInt();
            EntityType = ReadString();
            Isbabymob = Read();
            Isglobal = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarInt(SoundID);
            Write(Position);
            WriteSignedVarInt(BlockId);
            Write(EntityType);
            Write(Isbabymob);
            Write(Isglobal);
            return After();
        }
    }
    [RegisterPacketID(0x7c)]
    public class MCPE_LEVEL_EVENT_GENERIC : Packet
    {
        public MCPE_LEVEL_EVENT_GENERIC() : base(0x7c)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x7d)]
    public class MCPE_LECTERN_UPDATE : Packet
    {
        public MCPE_LECTERN_UPDATE() : base(0x7d)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x7e)]
    public class MCPE_VIDEO_STREAM_CONNECT : Packet
    {
        public string ServerURI; // Placeholder for the actual field
        public object FrameSendFrequency; // Placeholder for the actual field
        public object Action; // Placeholder for the actual field
        public int ResolutionX; // Placeholder for the actual field
        public int ResolutionY; // Placeholder for the actual field
        public MCPE_VIDEO_STREAM_CONNECT() : base(0x7e)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ServerURI = ReadString();
            FrameSendFrequency = Read();
            Action = Read();
            ResolutionX = ReadInt();
            ResolutionY = ReadInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(ServerURI);
            Write(FrameSendFrequency);
            Write(Action);
            Write(ResolutionX);
            Write(ResolutionY);
            return After();
        }
    }
    [RegisterPacketID(0x81)]
    public class MCPE_CLIENT_CACHE_STATUS : Packet
    {
        public object Enabled; // Placeholder for the actual field
        public MCPE_CLIENT_CACHE_STATUS() : base(0x81)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Enabled = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Enabled);
            return After();
        }
    }
    [RegisterPacketID(0x82)]
    public class MCPE_ON_SCREEN_TEXTURE_ANIMATION : Packet
    {
        public MCPE_ON_SCREEN_TEXTURE_ANIMATION() : base(0x82)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x83)]
    public class MCPE_MAP_CREATE_LOCKED_COPY : Packet
    {
        public MCPE_MAP_CREATE_LOCKED_COPY() : base(0x83)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x84)]
    public class MCPE_STRUCTURE_TEMPLATE_DATA_EXPORT_REQUEST : Packet
    {
        public MCPE_STRUCTURE_TEMPLATE_DATA_EXPORT_REQUEST() : base(0x84)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x85)]
    public class MCPE_STRUCTURE_TEMPLATE_DATA_EXPORT_RESPONSE : Packet
    {
        public MCPE_STRUCTURE_TEMPLATE_DATA_EXPORT_RESPONSE() : base(0x85)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x86)]
    public class MCPE_UPDATE_BLOCK_PROPERTIES : Packet
    {
        public object NamedTag; // Placeholder for the actual field
        public MCPE_UPDATE_BLOCK_PROPERTIES() : base(0x86)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            NamedTag = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(NamedTag);
            return After();
        }
    }
    [RegisterPacketID(0x87)]
    public class MCPE_CLIENT_CACHE_BLOB_STATUS : Packet
    {
        public MCPE_CLIENT_CACHE_BLOB_STATUS() : base(0x87)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x88)]
    public class MCPE_CLIENT_CACHE_MISS_RESPONSE : Packet
    {
        public MCPE_CLIENT_CACHE_MISS_RESPONSE() : base(0x88)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x8f)]
    public class MCPE_NETWORK_SETTINGS : Packet
    {
        public object CompressionThreshold; // Placeholder for the actual field
        public object CompressionAlgorithm; // Placeholder for the actual field
        public object ClientThrottleEnabled; // Placeholder for the actual field
        public object ClientThrottleThreshold; // Placeholder for the actual field
        public object ClientThrottleScalar; // Placeholder for the actual field
        public MCPE_NETWORK_SETTINGS() : base(0x8f)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            CompressionThreshold = Read();
            CompressionAlgorithm = Read();
            ClientThrottleEnabled = Read();
            ClientThrottleThreshold = Read();
            ClientThrottleScalar = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(CompressionThreshold);
            Write(CompressionAlgorithm);
            Write(ClientThrottleEnabled);
            Write(ClientThrottleThreshold);
            Write(ClientThrottleScalar);
            return After();
        }
    }
    [RegisterPacketID(0x90)]
    public class MCPE_PLAYER_AUTH_INPUT : Packet
    {
        public MCPE_PLAYER_AUTH_INPUT() : base(0x90)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x91)]
    public class MCPE_CREATIVE_CONTENT : Packet
    {
        public object Input; // Placeholder for the actual field
        public MCPE_CREATIVE_CONTENT() : base(0x91)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Input = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Input);
            return After();
        }
    }
    [RegisterPacketID(0x92)]
    public class MCPE_PLAYER_ENCHANT_OPTIONS : Packet
    {
        public object Enchantoptions; // Placeholder for the actual field
        public MCPE_PLAYER_ENCHANT_OPTIONS() : base(0x92)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Enchantoptions = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Enchantoptions);
            return After();
        }
    }
    [RegisterPacketID(0x93)]
    public class MCPE_ITEM_STACK_REQUEST : Packet
    {
        public object Requests; // Placeholder for the actual field
        public MCPE_ITEM_STACK_REQUEST() : base(0x93)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Requests = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Requests);
            return After();
        }
    }
    [RegisterPacketID(0x94)]
    public class MCPE_ITEM_STACK_RESPONSE : Packet
    {
        public object Responses; // Placeholder for the actual field
        public MCPE_ITEM_STACK_RESPONSE() : base(0x94)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Responses = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Responses);
            return After();
        }
    }
    [RegisterPacketID(0x97)]
    public class MCPE_UPDATE_PLAYER_GAME_TYPE : Packet
    {
        public MCPE_UPDATE_PLAYER_GAME_TYPE() : base(0x97)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x9c)]
    public class MCPE_PACKET_VIOLATION_WARNING : Packet
    {
        public int ViolationType; // Placeholder for the actual field
        public int Severity; // Placeholder for the actual field
        public int PacketId; // Placeholder for the actual field
        public string Reason; // Placeholder for the actual field
        public MCPE_PACKET_VIOLATION_WARNING() : base(0x9c)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ViolationType = ReadSignedVarInt();
            Severity = ReadSignedVarInt();
            PacketId = ReadSignedVarInt();
            Reason = ReadString();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteSignedVarInt(ViolationType);
            WriteSignedVarInt(Severity);
            WriteSignedVarInt(PacketId);
            Write(Reason);
            return After();
        }
    }
    [RegisterPacketID(0xa2)]
    public class MCPE_ITEM_COMPONENT : Packet
    {
        public object Entries; // Placeholder for the actual field
        public MCPE_ITEM_COMPONENT() : base(0xa2)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Entries = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Entries);
            return After();
        }
    }
    [RegisterPacketID(0xa3)]
    public class MCPE_FILTER_TEXT_PACKET : Packet
    {
        public string Text; // Placeholder for the actual field
        public object Fromserver; // Placeholder for the actual field
        public MCPE_FILTER_TEXT_PACKET() : base(0xa3)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Text = ReadString();
            Fromserver = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Text);
            Write(Fromserver);
            return After();
        }
    }
    [RegisterPacketID(0xac)]
    public class MCPE_UPDATE_SUB_CHUNK_BLOCKS_PACKET : Packet
    {
        public object Subchunkcoordinates; // Placeholder for the actual field
        public object Layerzeroupdates; // Placeholder for the actual field
        public object Layeroneupdates; // Placeholder for the actual field
        public MCPE_UPDATE_SUB_CHUNK_BLOCKS_PACKET() : base(0xac)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Subchunkcoordinates = Read();
            Layerzeroupdates = Read();
            Layeroneupdates = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Subchunkcoordinates);
            Write(Layerzeroupdates);
            Write(Layeroneupdates);
            return After();
        }
    }
    [RegisterPacketID(0xae)]
    public class MCPE_SUB_CHUNK_PACKET : Packet
    {
        public object Cacheenabled; // Placeholder for the actual field
        public int Dimension; // Placeholder for the actual field
        public object Subchunkcoordinates; // Placeholder for the actual field
        public MCPE_SUB_CHUNK_PACKET() : base(0xae)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Cacheenabled = Read();
            Dimension = ReadVarInt();
            Subchunkcoordinates = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Cacheenabled);
            WriteVarInt(Dimension);
            Write(Subchunkcoordinates);
            return After();
        }
    }
    [RegisterPacketID(0xaf)]
    public class MCPE_SUB_CHUNK_REQUEST_PACKET : Packet
    {
        public int Dimension; // Placeholder for the actual field
        public object BasePosition; // Placeholder for the actual field
        public object Offsets; // Placeholder for the actual field
        public MCPE_SUB_CHUNK_REQUEST_PACKET() : base(0xaf)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Dimension = ReadVarInt();
            BasePosition = Read();
            Offsets = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteVarInt(Dimension);
            Write(BasePosition);
            Write(Offsets);
            return After();
        }
    }
    [RegisterPacketID(0xb4)]
    public class MCPE_DIMENSION_DATA : Packet
    {
        public object Definitions; // Placeholder for the actual field
        public MCPE_DIMENSION_DATA() : base(0xb4)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Definitions = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Definitions);
            return After();
        }
    }
    [RegisterPacketID(0xbb)]
    public class MCPE_UPDATE_ABILITIES : Packet
    {
        public object EntityUniqueID; // Placeholder for the actual field
        public object PlayerPermissions; // Placeholder for the actual field
        public object CommandPermissions; // Placeholder for the actual field
        public object Layers; // Placeholder for the actual field
        public MCPE_UPDATE_ABILITIES() : base(0xbb)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            EntityUniqueID = Read();
            PlayerPermissions = Read();
            CommandPermissions = Read();
            Layers = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(EntityUniqueID);
            Write(PlayerPermissions);
            Write(CommandPermissions);
            Write(Layers);
            return After();
        }
    }
    [RegisterPacketID(0xbc)]
    public class MCPE_UPDATE_ADVENTURE_SETTINGS : Packet
    {
        public object NoPvM; // Placeholder for the actual field
        public object NoMvP; // Placeholder for the actual field
        public object ImmutableWorld; // Placeholder for the actual field
        public object ShowNameTags; // Placeholder for the actual field
        public object AutoJump; // Placeholder for the actual field
        public MCPE_UPDATE_ADVENTURE_SETTINGS() : base(0xbc)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            NoPvM = Read();
            NoMvP = Read();
            ImmutableWorld = Read();
            ShowNameTags = Read();
            AutoJump = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(NoPvM);
            Write(NoMvP);
            Write(ImmutableWorld);
            Write(ShowNameTags);
            Write(AutoJump);
            return After();
        }
    }
    [RegisterPacketID(0xb8)]
    public class MCPE_REQUEST_ABILITY : Packet
    {
        public int Ability; // Placeholder for the actual field
        public MCPE_REQUEST_ABILITY() : base(0xb8)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Ability = ReadVarInt();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteVarInt(Ability);
            return After();
        }
    }
    [RegisterPacketID(0xc1)]
    public class MCPE_REQUEST_NETWORK_SETTINGS : Packet
    {
        public int ProtocolVersion; // Placeholder for the actual field
        public MCPE_REQUEST_NETWORK_SETTINGS() : base(0xc1)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            ProtocolVersion = ReadIntBe();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteBe(ProtocolVersion);
            return After();
        }
    }
    [RegisterPacketID(0x12e)]
    public class MCPE_TRIM_DATA : Packet
    {
        public MCPE_TRIM_DATA() : base(0x12e)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            return After();
        }
    }
    [RegisterPacketID(0x12f)]
    public class MCPE_OPEN_SIGN : Packet
    {
        public object Coordinates; // Placeholder for the actual field
        public object Front; // Placeholder for the actual field
        public MCPE_OPEN_SIGN() : base(0x12f)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            Coordinates = Read();
            Front = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            Write(Coordinates);
            Write(Front);
            return After();
        }
    }
    [RegisterPacketID(0xe0)]
    public class MCPE_ALEX_ENTITY_ANIMATION : Packet
    {
        public long RuntimeEntityID; // Placeholder for the actual field
        public string BoneId; // Placeholder for the actual field
        public object Keys; // Placeholder for the actual field
        public MCPE_ALEX_ENTITY_ANIMATION() : base(0xe0)
        {
        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            RuntimeEntityID = ReadUnsignedVarLong();
            BoneId = ReadString();
            Keys = Read();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteUnsignedVarLong(RuntimeEntityID);
            Write(BoneId);
            Write(Keys);
            return After();
        }
    }

}
