using ATRI.Protocol.Raknet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRI.Protocol.MC;
namespace test
{
    [RegisterPacketID(0x01)]
    public class MCPE_LOGIN : Packet
    {

        public int protocolVersion; // = null;
        public byte[] payload; // = null;
        public MCPE_LOGIN() : base(0x01)
        {

        }
        public override void Deserialize(byte[] bytes)
        {
            Before(bytes);
            protocolVersion = ReadIntBe();
            payload = ReadByteArray();
            After();
        }
        public override byte[] Serialize()
        {
            Before();
            WriteBe(protocolVersion);
            WriteByteArray(payload);
            return After();
        }
    }
    [RegisterPacketID(0x02)]
    public class MCPE_PLAY_STATUS : Packet
    {
        public enum Play_status
        {

            Login_Success = 0,
            Login_Failed_Client = 1,
            Login_Failed_Server = 2,
            Player_Spawn = 3,
            Login_Failed_Invalid_Tenant = 4,
            Login_Failed_Vanilla_Edu = 5,
            Login_Failed_Edu_Vanilla = 6,
            Login_Failed_Server_Full = 7,

        }
        public int status; // = null;
        public MCPE_PLAY_STATUS() : base(0x02)
        {

        }
        public override void Deserialize(byte[] bytes)
        {

            Before(bytes);


            status = ReadIntBe();


            After();
        }
        public override byte[] Serialize()
        {

            Before();

            WriteBe(status);



            return After();
        }
    }
    [RegisterPacketID(0x03)]
    public class MCPE_SERVER_TO_CLIENT_HANDSHAKE : Packet
    {
        public string token; // = null;
        public MCPE_SERVER_TO_CLIENT_HANDSHAKE() : base(0x03)
        {

        }
        public override void Deserialize(byte[] bytes)
        {

            Before(bytes);


            token = ReadString();


            After();
        }
        public override byte[] Serialize()
        {

            Before();


            Write(token);


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
        public bool hideDisconnectReason; // = null;
        public string message; // = null;
        public uint failReason; // = null;
        public MCPE_DISCONNECT() : base(0x05)
        {

        }
        public override void Deserialize(byte[] bytes)
        {

            Before(bytes);

            failReason = ReadUnsignedVarInt();
            hideDisconnectReason = ReadBool();
            message = ReadString();

            After();
        }
        public override byte[] Serialize()
        {

            Before();
            WriteUnsignedVarInt(0); //todo
            Write(hideDisconnectReason);
            Write(message);
            return After();
        }
    }
    [RegisterPacketID(0x06)]
    public class MCPE_RESOURCE_PACKS_INFO : Packet
    {
        public MCPE_RESOURCE_PACKS_INFO() : base(0x06)
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
    [RegisterPacketID(0x07)]
    public class MCPE_RESOURCE_PACK_STACK : Packet
    {
        public MCPE_RESOURCE_PACK_STACK() : base(0x07)
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
    [RegisterPacketID(0x08)]
    public class MCPE_RESOURCE_PACK_CLIENT_RESPONSE : Packet
    {
        public enum Response_status
        {

            Refused = 1,
            Send_packs = 2,
            Have_all_packs = 3,
            Completed = 4,

        }
        public MCPE_RESOURCE_PACK_CLIENT_RESPONSE() : base(0x08)
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
    [RegisterPacketID(0x09)]
    public class MCPE_TEXT : Packet
    {
        public enum Chat_types
        {

            Raw = 0,
            Chat = 1,
            Translation = 2,
            Popup = 3,
            JukeboxPopup = 4,
            Tip = 5,
            System = 6,
            Whisper = 7,
            Announcement = 8,
            Json = 9,
            JsonWhisper = 10,
            JsonAnnouncement = 11,

        }
        public MCPE_TEXT() : base(0x09)
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
    [RegisterPacketID(0x0a)]
    public class MCPE_SET_TIME : Packet
    {
        public MCPE_SET_TIME() : base(0x0a)
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
        public MCPE_ADD_PLAYER() : base(0x0c)
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
    [RegisterPacketID(0x0d)]
    public class MCPE_ADD_ENTITY : Packet
    {
        public MCPE_ADD_ENTITY() : base(0x0d)
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
    [RegisterPacketID(0x0e)]
    public class MCPE_REMOVE_ENTITY : Packet
    {
        public MCPE_REMOVE_ENTITY() : base(0x0e)
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
    [RegisterPacketID(0x0f)]
    public class MCPE_ADD_ITEM_ENTITY : Packet
    {
        public MCPE_ADD_ITEM_ENTITY() : base(0x0f)
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
    [RegisterPacketID(0x11)]
    public class MCPE_TAKE_ITEM_ENTITY : Packet
    {
        public MCPE_TAKE_ITEM_ENTITY() : base(0x11)
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
    [RegisterPacketID(0x12)]
    public class MCPE_MOVE_ENTITY : Packet
    {
        public MCPE_MOVE_ENTITY() : base(0x12)
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
    [RegisterPacketID(0x13)]
    public class MCPE_MOVE_PLAYER : Packet
    {
        public enum Mode
        {

            Normal = 0,
            Reset = 1,
            Teleport = 2,
            Rotation = 3,

        }
        public enum TeleportCause
        {

            Unknown = 0,
            Projectile = 1,
            Chorus_Fruit = 2,
            Command = 3,
            Behavior = 4,
            Count = 5,

        }
        public MCPE_MOVE_PLAYER() : base(0x13)
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
    [RegisterPacketID(0x14)]
    public class MCPE_RIDER_JUMP : Packet
    {
        public MCPE_RIDER_JUMP() : base(0x14)
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
    [RegisterPacketID(0x15)]
    public class MCPE_UPDATE_BLOCK : Packet
    {
        public enum Flags
        {

            None = 0,
            Neighbors = 1,
            Network = 2,
            Nographic = 4,
            Priority = 8,
            All = (Neighbors | Network),
            All_Priority = (All | Priority),

        }
        public MCPE_UPDATE_BLOCK() : base(0x15)
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
    [RegisterPacketID(0x16)]
    public class MCPE_ADD_PAINTING : Packet
    {
        public MCPE_ADD_PAINTING() : base(0x16)
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
    [RegisterPacketID(0x17)]
    public class MCPE_TICK_SYNC : Packet
    {
        public MCPE_TICK_SYNC() : base(0x17)
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
    [RegisterPacketID(0x18)]
    public class MCPE_LEVEL_SOUND_EVENT_OLD : Packet
    {
        public MCPE_LEVEL_SOUND_EVENT_OLD() : base(0x18)
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
    [RegisterPacketID(0x19)]
    public class MCPE_LEVEL_EVENT : Packet
    {
        public MCPE_LEVEL_EVENT() : base(0x19)
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
    [RegisterPacketID(0x1a)]
    public class MCPE_BLOCK_EVENT : Packet
    {
        public MCPE_BLOCK_EVENT() : base(0x1a)
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
    [RegisterPacketID(0x1b)]
    public class MCPE_ENTITY_EVENT : Packet
    {
        public MCPE_ENTITY_EVENT() : base(0x1b)
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
    [RegisterPacketID(0x1c)]
    public class MCPE_MOB_EFFECT : Packet
    {
        public MCPE_MOB_EFFECT() : base(0x1c)
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
    [RegisterPacketID(0x1d)]
    public class MCPE_UPDATE_ATTRIBUTES : Packet
    {
        public MCPE_UPDATE_ATTRIBUTES() : base(0x1d)
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
    [RegisterPacketID(0x1e)]
    public class MCPE_INVENTORY_TRANSACTION : Packet
    {
        public enum Transaction_type
        {

            Normal = 0,
            Inventory_mismatch = 1,
            Item_use = 2,
            Item_use_on_entity = 3,
            Item_release = 4,

        }
        public enum Inventory_source_type
        {

            Container = 0,
            Global = 1,
            World_interaction = 2,
            Creative = 3,
            Crafting = 100,
            Unspecified = 99999,

        }
        public enum Crafting_action
        {

            Craft_Add_Ingredient = -2,
            Craft_Remove_Ingredient = -3,
            Craft_Result = -4,
            Craft_Use_Ingredient = -5,
            Anvil_Input = -10,
            Anvil_Material = -11,
            Anvil_Result = -12,
            Anvil_Output = -13,
            Enchant_item = -15,
            Enchant_lapis = -16,
            Enchant_result = -17,
            Drop = -100,

        }
        public enum Item_release_action
        {

            Release = 0,
            Use = 1,

        }
        public enum Item_use_action
        {

            Place, _ClickBlock = 0,
            Use, _ClickAir = 1,
            Destroy = 2,

        }
        public enum Item_use_on_entity_action
        {

            Interact = 0,
            Attack = 1,
            Item_interact = 2,

        }
        public MCPE_INVENTORY_TRANSACTION() : base(0x1e)
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
    [RegisterPacketID(0x1f)]
    public class MCPE_MOB_EQUIPMENT : Packet
    {
        public MCPE_MOB_EQUIPMENT() : base(0x1f)
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
    [RegisterPacketID(0x20)]
    public class MCPE_MOB_ARMOR_EQUIPMENT : Packet
    {
        public MCPE_MOB_ARMOR_EQUIPMENT() : base(0x20)
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
    [RegisterPacketID(0x21)]
    public class MCPE_INTERACT : Packet
    {
        public enum Actions
        {

            Right_click = 1,
            Left_click = 2,
            Leave_vehicle = 3,
            Mouse_over = 4,
            Open_NPC = 5,
            Open_inventory = 6,

        }
        public MCPE_INTERACT() : base(0x21)
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
    [RegisterPacketID(0x22)]
    public class MCPE_BLOCK_PICK_REQUEST : Packet
    {
        public MCPE_BLOCK_PICK_REQUEST() : base(0x22)
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
    [RegisterPacketID(0x23)]
    public class MCPE_ENTITY_PICK_REQUEST : Packet
    {
        public MCPE_ENTITY_PICK_REQUEST() : base(0x23)
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
    [RegisterPacketID(0x24)]
    public class MCPE_PLAYER_ACTION : Packet
    {
        public MCPE_PLAYER_ACTION() : base(0x24)
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
    [RegisterPacketID(0x26)]
    public class MCPE_HURT_ARMOR : Packet
    {
        public MCPE_HURT_ARMOR() : base(0x26)
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
    [RegisterPacketID(0x27)]
    public class MCPE_SET_ENTITY_DATA : Packet
    {
        public MCPE_SET_ENTITY_DATA() : base(0x27)
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
    [RegisterPacketID(0x28)]
    public class MCPE_SET_ENTITY_MOTION : Packet
    {
        public MCPE_SET_ENTITY_MOTION() : base(0x28)
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
    [RegisterPacketID(0x29)]
    public class MCPE_SET_ENTITY_LINK : Packet
    {
        public enum Link_Actions
        {

            Remove = 0,
            Ride = 1,
            Passenger = 2,

        }
        public MCPE_SET_ENTITY_LINK() : base(0x29)
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
    [RegisterPacketID(0x2a)]
    public class MCPE_SET_HEALTH : Packet
    {
        public MCPE_SET_HEALTH() : base(0x2a)
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
    [RegisterPacketID(0x2b)]
    public class MCPE_SET_SPAWN_POSITION : Packet
    {
        public MCPE_SET_SPAWN_POSITION() : base(0x2b)
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
    [RegisterPacketID(0x2c)]
    public class MCPE_ANIMATE : Packet
    {
        public MCPE_ANIMATE() : base(0x2c)
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
    [RegisterPacketID(0x2d)]
    public class MCPE_RESPAWN : Packet
    {
        public enum Respawn_State
        {

            Search = 0,
            Ready = 1,
            Client_Ready = 2,

        }
        public MCPE_RESPAWN() : base(0x2d)
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
    [RegisterPacketID(0x2e)]
    public class MCPE_CONTAINER_OPEN : Packet
    {
        public MCPE_CONTAINER_OPEN() : base(0x2e)
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
    [RegisterPacketID(0x2f)]
    public class MCPE_CONTAINER_CLOSE : Packet
    {
        public MCPE_CONTAINER_CLOSE() : base(0x2f)
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
    [RegisterPacketID(0x30)]
    public class MCPE_PLAYER_HOTBAR : Packet
    {
        public MCPE_PLAYER_HOTBAR() : base(0x30)
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
    [RegisterPacketID(0x31)]
    public class MCPE_INVENTORY_CONTENT : Packet
    {
        public MCPE_INVENTORY_CONTENT() : base(0x31)
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
    [RegisterPacketID(0x32)]
    public class MCPE_INVENTORY_SLOT : Packet
    {
        public MCPE_INVENTORY_SLOT() : base(0x32)
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
    [RegisterPacketID(0x33)]
    public class MCPE_CONTAINER_SET_DATA : Packet
    {
        public MCPE_CONTAINER_SET_DATA() : base(0x33)
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
    [RegisterPacketID(0x34)]
    public class MCPE_CRAFTING_DATA : Packet
    {
        public MCPE_CRAFTING_DATA() : base(0x34)
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
    [RegisterPacketID(0x35)]
    public class MCPE_CRAFTING_EVENT : Packet
    {
        public enum Recipe_Types
        {

            Shapeless = 0,
            Shaped = 1,
            Furnace = 2,
            Furnace_data = 3,
            Multi = 4,
            Shulker_box = 5,
            Chemistry_Shapeless = 6,
            Chemistry_Shaped = 7,
            Smithing_Transform = 8,
            Smithing_Trim = 9,

        }
        public MCPE_CRAFTING_EVENT() : base(0x35)
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
        public MCPE_ADVENTURE_SETTINGS() : base(0x37)
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
    [RegisterPacketID(0x38)]
    public class MCPE_BLOCK_ENTITY_DATA : Packet
    {
        public MCPE_BLOCK_ENTITY_DATA() : base(0x38)
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
    [RegisterPacketID(0x39)]
    public class MCPE_PLAYER_INPUT : Packet
    {
        public MCPE_PLAYER_INPUT() : base(0x39)
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
    [RegisterPacketID(0x3a)]
    public class MCPE_LEVEL_CHUNK : Packet
    {
        public MCPE_LEVEL_CHUNK() : base(0x3a)
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
    [RegisterPacketID(0x3b)]
    public class MCPE_SET_COMMANDS_ENABLED : Packet
    {
        public MCPE_SET_COMMANDS_ENABLED() : base(0x3b)
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
    [RegisterPacketID(0x3c)]
    public class MCPE_SET_DIFFICULTY : Packet
    {
        public MCPE_SET_DIFFICULTY() : base(0x3c)
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
    [RegisterPacketID(0x3d)]
    public class MCPE_CHANGE_DIMENSION : Packet
    {
        public MCPE_CHANGE_DIMENSION() : base(0x3d)
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
    [RegisterPacketID(0x3e)]
    public class MCPE_SET_PLAYER_GAME_TYPE : Packet
    {
        public MCPE_SET_PLAYER_GAME_TYPE() : base(0x3e)
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
    [RegisterPacketID(0x3f)]
    public class MCPE_PLAYER_LIST : Packet
    {
        public MCPE_PLAYER_LIST() : base(0x3f)
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
    [RegisterPacketID(0x40)]
    public class MCPE_SIMPLE_EVENT : Packet
    {
        public MCPE_SIMPLE_EVENT() : base(0x40)
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
    [RegisterPacketID(0x41)]
    public class MCPE_TELEMETRY_EVENT : Packet
    {
        public MCPE_TELEMETRY_EVENT() : base(0x41)
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
    [RegisterPacketID(0x42)]
    public class MCPE_SPAWN_EXPERIENCE_ORB : Packet
    {
        public MCPE_SPAWN_EXPERIENCE_ORB() : base(0x42)
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
    [RegisterPacketID(0x43)]
    public class MCPE_CLIENTBOUND_MAP_ITEM_DATA : Packet
    {
        public MCPE_CLIENTBOUND_MAP_ITEM_DATA() : base(0x43)
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
    [RegisterPacketID(0x44)]
    public class MCPE_MAP_INFO_REQUEST : Packet
    {
        public MCPE_MAP_INFO_REQUEST() : base(0x44)
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
    [RegisterPacketID(0x45)]
    public class MCPE_REQUEST_CHUNK_RADIUS : Packet
    {
        public MCPE_REQUEST_CHUNK_RADIUS() : base(0x45)
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
    [RegisterPacketID(0x46)]
    public class MCPE_CHUNK_RADIUS_UPDATE : Packet
    {
        public MCPE_CHUNK_RADIUS_UPDATE() : base(0x46)
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
    [RegisterPacketID(0x47)]
    public class MCPE_ITEM_FRAME_DROP_ITEM : Packet
    {
        public MCPE_ITEM_FRAME_DROP_ITEM() : base(0x47)
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
    [RegisterPacketID(0x48)]
    public class MCPE_GAME_RULES_CHANGED : Packet
    {
        public MCPE_GAME_RULES_CHANGED() : base(0x48)
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
    [RegisterPacketID(0x49)]
    public class MCPE_CAMERA : Packet
    {
        public MCPE_CAMERA() : base(0x49)
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
    [RegisterPacketID(0x4a)]
    public class MCPE_BOSS_EVENT : Packet
    {
        public enum Type
        {

            Add_Boss = 0,
            Add_Player = 1,
            Remove_boss = 2,
            Remove_Player = 3,
            Update_Progress = 4,
            Update_Name = 5,
            Update_Options = 6,
            Update_Style = 7,
            Query = 8,

        }
        public MCPE_BOSS_EVENT() : base(0x4a)
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
    [RegisterPacketID(0x4b)]
    public class MCPE_SHOW_CREDITS : Packet
    {
        public MCPE_SHOW_CREDITS() : base(0x4b)
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
        public MCPE_COMMAND_REQUEST() : base(0x4d)
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
    [RegisterPacketID(0x4e)]
    public class MCPE_COMMAND_BLOCK_UPDATE : Packet
    {
        public MCPE_COMMAND_BLOCK_UPDATE() : base(0x4e)
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
        public MCPE_UPDATE_TRADE() : base(0x50)
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
    [RegisterPacketID(0x51)]
    public class MCPE_UPDATE_EQUIPMENT : Packet
    {
        public MCPE_UPDATE_EQUIPMENT() : base(0x51)
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
    [RegisterPacketID(0x52)]
    public class MCPE_RESOURCE_PACK_DATA_INFO : Packet
    {
        public MCPE_RESOURCE_PACK_DATA_INFO() : base(0x52)
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
    [RegisterPacketID(0x53)]
    public class MCPE_RESOURCE_PACK_CHUNK_DATA : Packet
    {
        public MCPE_RESOURCE_PACK_CHUNK_DATA() : base(0x53)
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
    [RegisterPacketID(0x54)]
    public class MCPE_RESOURCE_PACK_CHUNK_REQUEST : Packet
    {
        public MCPE_RESOURCE_PACK_CHUNK_REQUEST() : base(0x54)
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
    [RegisterPacketID(0x55)]
    public class MCPE_TRANSFER : Packet
    {
        public MCPE_TRANSFER() : base(0x55)
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
    [RegisterPacketID(0x56)]
    public class MCPE_PLAY_SOUND : Packet
    {
        public MCPE_PLAY_SOUND() : base(0x56)
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
    [RegisterPacketID(0x57)]
    public class MCPE_STOP_SOUND : Packet
    {
        public MCPE_STOP_SOUND() : base(0x57)
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
    [RegisterPacketID(0x58)]
    public class MCPE_SET_TITLE : Packet
    {
        public MCPE_SET_TITLE() : base(0x58)
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
    [RegisterPacketID(0x59)]
    public class MCPE_ADD_BEHAVIOR_TREE : Packet
    {
        public MCPE_ADD_BEHAVIOR_TREE() : base(0x59)
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
        public MCPE_SHOW_STORE_OFFER() : base(0x5b)
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
        public MCPE_PLAYER_SKIN() : base(0x5d)
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
        public MCPE_INITIATE_WEB_SOCKET_CONNECTION() : base(0x5f)
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
    [RegisterPacketID(0x60)]
    public class MCPE_SET_LAST_HURT_BY : Packet
    {
        public MCPE_SET_LAST_HURT_BY() : base(0x60)
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
        public MCPE_NPC_REQUEST() : base(0x62)
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
    [RegisterPacketID(0x63)]
    public class MCPE_PHOTO_TRANSFER : Packet
    {
        public MCPE_PHOTO_TRANSFER() : base(0x63)
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
    [RegisterPacketID(0x64)]
    public class MCPE_MODAL_FORM_REQUEST : Packet
    {
        public MCPE_MODAL_FORM_REQUEST() : base(0x64)
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
    [RegisterPacketID(0x65)]
    public class MCPE_MODAL_FORM_RESPONSE : Packet
    {
        public MCPE_MODAL_FORM_RESPONSE() : base(0x65)
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
        public MCPE_SERVER_SETTINGS_RESPONSE() : base(0x67)
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
    [RegisterPacketID(0x68)]
    public class MCPE_SHOW_PROFILE : Packet
    {
        public MCPE_SHOW_PROFILE() : base(0x68)
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
    [RegisterPacketID(0x69)]
    public class MCPE_SET_DEFAULT_GAME_TYPE : Packet
    {
        public MCPE_SET_DEFAULT_GAME_TYPE() : base(0x69)
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
    [RegisterPacketID(0x6a)]
    public class MCPE_REMOVE_OBJECTIVE : Packet
    {
        public MCPE_REMOVE_OBJECTIVE() : base(0x6a)
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
    [RegisterPacketID(0x6b)]
    public class MCPE_SET_DISPLAY_OBJECTIVE : Packet
    {
        public MCPE_SET_DISPLAY_OBJECTIVE() : base(0x6b)
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
    [RegisterPacketID(0x6c)]
    public class MCPE_SET_SCORE : Packet
    {
        public enum Types
        {

            Change = 0,
            Remove = 1,

        }
        public enum Change_Types
        {

            Player = 1,
            Entity = 2,
            Fake_Player = 3,

        }
        public MCPE_SET_SCORE() : base(0x6c)
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
    [RegisterPacketID(0x6d)]
    public class MCPE_LAB_TABLE : Packet
    {
        public MCPE_LAB_TABLE() : base(0x6d)
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
    [RegisterPacketID(0x6e)]
    public class MCPE_UPDATE_BLOCK_SYNCED : Packet
    {
        public MCPE_UPDATE_BLOCK_SYNCED() : base(0x6e)
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
    [RegisterPacketID(0x6f)]
    public class MCPE_MOVE_ENTITY_DELTA : Packet
    {
        public MCPE_MOVE_ENTITY_DELTA() : base(0x6f)
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
    [RegisterPacketID(0x70)]
    public class MCPE_SET_SCOREBOARD_IDENTITY : Packet
    {
        public enum Operations
        {

            Register_Identity = 0,
            Clear_Identity = 1,

        }
        public MCPE_SET_SCOREBOARD_IDENTITY() : base(0x70)
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
    [RegisterPacketID(0x71)]
    public class MCPE_SET_LOCAL_PLAYER_AS_INITIALIZED : Packet
    {
        public MCPE_SET_LOCAL_PLAYER_AS_INITIALIZED() : base(0x71)
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
        public MCPE_NETWORK_STACK_LATENCY() : base(0x73)
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
    [RegisterPacketID(0x75)]
    public class MCPE_SCRIPT_CUSTOM_EVENT : Packet
    {
        public MCPE_SCRIPT_CUSTOM_EVENT() : base(0x75)
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
    [RegisterPacketID(0x76)]
    public class MCPE_SPAWN_PARTICLE_EFFECT : Packet
    {
        public MCPE_SPAWN_PARTICLE_EFFECT() : base(0x76)
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
    [RegisterPacketID(0x77)]
    public class MCPE_AVAILABLE_ENTITY_IDENTIFIERS : Packet
    {
        public MCPE_AVAILABLE_ENTITY_IDENTIFIERS() : base(0x77)
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
    [RegisterPacketID(0x78)]
    public class MCPE_LEVEL_SOUND_EVENT_V2 : Packet
    {
        public MCPE_LEVEL_SOUND_EVENT_V2() : base(0x78)
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
    [RegisterPacketID(0x79)]
    public class MCPE_NETWORK_CHUNK_PUBLISHER_UPDATE : Packet
    {
        public MCPE_NETWORK_CHUNK_PUBLISHER_UPDATE() : base(0x79)
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
    [RegisterPacketID(0x7a)]
    public class MCPE_BIOME_DEFINITION_LIST : Packet
    {
        public MCPE_BIOME_DEFINITION_LIST() : base(0x7a)
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
    [RegisterPacketID(0x7b)]
    public class MCPE_LEVEL_SOUND_EVENT : Packet
    {
        public MCPE_LEVEL_SOUND_EVENT() : base(0x7b)
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
        public MCPE_VIDEO_STREAM_CONNECT() : base(0x7e)
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
    [RegisterPacketID(0x81)]
    public class MCPE_CLIENT_CACHE_STATUS : Packet
    {
        public MCPE_CLIENT_CACHE_STATUS() : base(0x81)
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
        public MCPE_UPDATE_BLOCK_PROPERTIES() : base(0x86)
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
        public enum Compression
        {
            Nothing = 0,
            Everything = 1,
        }

        public short compressionThreshold; // = null;
        public short compressionAlgorithm; // = null;
        public bool clientThrottleEnabled; // = null;
        public byte clientThrottleThreshold; // = null;
        public float clientThrottleScalar; // = null;
        public MCPE_NETWORK_SETTINGS() : base(0x8f)
        {

        }
        public override void Deserialize(byte[] bytes)
        {

            Before(bytes);

            compressionThreshold = ReadShort();
            compressionAlgorithm = ReadShort();
            clientThrottleEnabled = ReadBool();
            clientThrottleThreshold = ReadByte();
            clientThrottleScalar = ReadFloat();

            After();
        }
        public override byte[] Serialize()
        {

            Before();

            Write(compressionThreshold);
            Write(compressionAlgorithm);
            Write(clientThrottleEnabled);
            Write(clientThrottleThreshold);
            Write(clientThrottleScalar);
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
        public MCPE_CREATIVE_CONTENT() : base(0x91)
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
    [RegisterPacketID(0x92)]
    public class MCPE_PLAYER_ENCHANT_OPTIONS : Packet
    {
        public MCPE_PLAYER_ENCHANT_OPTIONS() : base(0x92)
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
    [RegisterPacketID(0x93)]
    public class MCPE_ITEM_STACK_REQUEST : Packet
    {
        public enum Action_type
        {

            Take = 0,
            Place = 1,
            Swap = 2,
            Drop = 3,
            Destroy = 4,
            Consume = 5,
            Create = 6,
            Place_into_bundle = 7,
            Take_from_bundle = 8,
            Lab_table_combine = 9,
            Beacon_payment = 10,
            Mine_Block = 11,
            Craft_recipe = 12,
            Craft_recipe_Auto = 13,
            Craft_creative = 14,
            Craft_recipe_optional = 15,
            Craft_Grindstone = 16,
            Craft_loom = 17,
            Craft_not_implemented_deprecated = 18,
            Craft_results_deprecated = 19,

        }
        public MCPE_ITEM_STACK_REQUEST() : base(0x93)
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
    [RegisterPacketID(0x94)]
    public class MCPE_ITEM_STACK_RESPONSE : Packet
    {
        public MCPE_ITEM_STACK_RESPONSE() : base(0x94)
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
        public MCPE_PACKET_VIOLATION_WARNING() : base(0x9c)
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
    [RegisterPacketID(0xa2)]
    public class MCPE_ITEM_COMPONENT : Packet
    {
        public MCPE_ITEM_COMPONENT() : base(0xa2)
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
    [RegisterPacketID(0xa3)]
    public class MCPE_FILTER_TEXT_PACKET : Packet
    {
        public MCPE_FILTER_TEXT_PACKET() : base(0xa3)
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
    [RegisterPacketID(0xac)]
    public class MCPE_UPDATE_SUB_CHUNK_BLOCKS_PACKET : Packet
    {
        public MCPE_UPDATE_SUB_CHUNK_BLOCKS_PACKET() : base(0xac)
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
    [RegisterPacketID(0xae)]
    public class MCPE_SUB_CHUNK_PACKET : Packet
    {
        public MCPE_SUB_CHUNK_PACKET() : base(0xae)
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
    [RegisterPacketID(0xaf)]
    public class MCPE_SUB_CHUNK_REQUEST_PACKET : Packet
    {
        public MCPE_SUB_CHUNK_REQUEST_PACKET() : base(0xaf)
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
    [RegisterPacketID(0xb4)]
    public class MCPE_DIMENSION_DATA : Packet
    {
        public MCPE_DIMENSION_DATA() : base(0xb4)
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
    [RegisterPacketID(0xbb)]
    public class MCPE_UPDATE_ABILITIES : Packet
    {
        public MCPE_UPDATE_ABILITIES() : base(0xbb)
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
    [RegisterPacketID(0xbc)]
    public class MCPE_UPDATE_ADVENTURE_SETTINGS : Packet
    {
        public MCPE_UPDATE_ADVENTURE_SETTINGS() : base(0xbc)
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
    [RegisterPacketID(0xb8)]
    public class MCPE_REQUEST_ABILITY : Packet
    {
        public MCPE_REQUEST_ABILITY() : base(0xb8)
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
    [RegisterPacketID(0xc1)]
    public class MCPE_REQUEST_NETWORK_SETTINGS : Packet
    {
        public int ProtoalVersion;
        public MCPE_REQUEST_NETWORK_SETTINGS() : base(0xc1)
        {

        }
        public override void Deserialize(byte[] bytes)
        {

            Before(bytes);
            ProtoalVersion = ReadIntBe();
            After();
        }
        public override byte[] Serialize()
        {

            Before();
            WriteBe(ProtoalVersion);
            return After();
        }
    }
    [RegisterPacketID(0xe0)]
    public class MCPE_ALEX_ENTITY_ANIMATION : Packet
    {
        public MCPE_ALEX_ENTITY_ANIMATION() : base(0xe0)
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
}