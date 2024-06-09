using System.Collections.Generic;
using System.Net;
using System;
using System.Buffers.Binary;
using System.Reflection.PortableExecutable;
using System.Text;
using ATRI.Protocol.Raknet.Utils;
using ATRI.Protocol.Raknet.Utils.IO;
using System.Net.Sockets;
using ATRI.Protocol.Raknet.Utils.Metadata;
using ATRI.Protocol.Raknet.Utils.Nbt;
using ATRI.Protocol.Raknet.Utils.Vectors;
using fNbt;
using Newtonsoft.Json;
using System.Buffers;
using System.Numerics;
using System.Transactions;
using Org.BouncyCastle.Utilities;
namespace ATRI.Protocol.MC
{
    public abstract class Packet
    {
        public MemoryStream _buffer;
        public BinaryWriter _writer;
        public MemoryStreamReader _reader;
        public byte[] Buffer { get; set; }
        private int id { get; set; }
        public bool IsUse = false;
        public Packet(int id)
        {
            _buffer = new MemoryStream();
            
            this.id = id;
        }
        public T Cast<T>() where T : Packet
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { Buffer });
        }
        public void Write(object value)
        {

        }
        public object Read()
        {
            return null;
        }
        public void Write(sbyte value)
        {
            _writer.Write(value);
        }

        public sbyte ReadSByte()
        {
            return (sbyte)_reader.ReadByte();
        }

        public void Write(byte value)
        {
            _writer.Write(value);
        }

        public byte ReadByte()
        {
            return (byte)_reader.ReadByte();
        }

        public void Write(bool value)
        {
            Write((byte)(value ? 1 : 0));
        }

        public bool ReadBool()
        {
            return _reader.ReadByte() != 0;
        }

        public void Write(Memory<byte> value)
        {
            Write((ReadOnlyMemory<byte>)value);
        }

        public void Write(ReadOnlyMemory<byte> value)
        {
            if (value.IsEmpty)
            {
                return;
            }
            _writer.Write(value.Span);
        }

        public void Write(byte[] value)
        {
            if (value == null)
            {
                return;
            }

            _writer.Write(value);
        }

        public ReadOnlyMemory<byte> Slice(int count)
        {
            return _reader.Read(count);
        }

        public ReadOnlyMemory<byte> ReadReadOnlyMemory(int count, bool slurp = false)
        {
            if (!slurp && count == 0) return Memory<byte>.Empty;

            if (count == 0)
            {
                count = (int)(_reader.Length - _reader.Position);
            }

            ReadOnlyMemory<byte> readBytes = _reader.Read(count);
            if (readBytes.Length != count) throw new ArgumentOutOfRangeException($"Expected {count} bytes, only read {readBytes.Length}.");
            return readBytes;
        }

        public byte[] ReadBytes(int count, bool slurp = false)
        {
            if (!slurp && count == 0) return new byte[0];

            if (count == 0)
            {
                count = (int)(_reader.Length - _reader.Position);
            }

            ReadOnlyMemory<byte> readBytes = _reader.Read(count);
            if (readBytes.Length != count) throw new ArgumentOutOfRangeException($"Expected {count} bytes, only read {readBytes.Length}.");
            return readBytes.ToArray(); //TODO: Replace with ReadOnlyMemory<byte> return
        }

        public void WriteByteArray(byte[] value)
        {
            if (value == null)
            {
                WriteLength(0);
                return;
            }

            WriteLength(value.Length);

            if (value.Length == 0) return;

            _writer.Write(value, 0, value.Length);
        }

        public byte[] ReadByteArray(bool slurp = false)
        {
            var len = ReadLength();
            var bytes = ReadBytes(len, slurp);
            return bytes;
        }

        public void Write(ulong[] value)
        {
            if (value == null)
            {
                WriteLength(0);
                return;
            }

            WriteLength(value.Length);

            if (value.Length == 0) return;
            for (int i = 0; i < value.Length; i++)
            {
                ulong val = value[i];
                Write(val);
            }
        }

        public ulong[] ReadUlongs(bool slurp = false)
        {
            var len = ReadLength();
            var ulongs = new ulong[len];
            for (int i = 0; i < ulongs.Length; i++)
            {
                ulongs[i] = ReadUlong();
            }
            return ulongs;
        }

        public void Write(short value, bool bigEndian = false)
        {
            if (bigEndian) _writer.Write(BinaryPrimitives.ReverseEndianness(value));
            else _writer.Write(value);
        }

        public short ReadShort(bool bigEndian = false)
        {
            if (_reader.Position == _reader.Length) return 0;

            if (bigEndian) return BinaryPrimitives.ReverseEndianness(_reader.ReadInt16());

            return _reader.ReadInt16();
        }

        public void Write(ushort value, bool bigEndian = false)
        {
            if (bigEndian) _writer.Write(BinaryPrimitives.ReverseEndianness(value));
            else _writer.Write(value);
        }

        public ushort ReadUshort(bool bigEndian = false)
        {
            if (_reader.Position == _reader.Length) return 0;

            if (bigEndian) return BinaryPrimitives.ReverseEndianness(_reader.ReadUInt16());

            return _reader.ReadUInt16();
        }

        public void WriteBe(short value)
        {
            _writer.Write(BinaryPrimitives.ReverseEndianness(value));
        }

        public short ReadShortBe()
        {
            if (_reader.Position == _reader.Length) return 0;

            return BinaryPrimitives.ReverseEndianness(_reader.ReadInt16());
        }

        public void Write(Int24 value)
        {
            _writer.Write(value.GetBytes());
        }

        public Int24 ReadLittle()
        {
            return new Int24(_reader.Read(3).Span);
        }

        public void Write(int value, bool bigEndian = false)
        {
            if (bigEndian) _writer.Write(BinaryPrimitives.ReverseEndianness(value));
            else _writer.Write(value);
        }

        public int ReadInt(bool bigEndian = false)
        {
            if (bigEndian) return BinaryPrimitives.ReverseEndianness(_reader.ReadInt32());

            return _reader.ReadInt32();
        }

        public void WriteBe(int value)
        {
            _writer.Write(BinaryPrimitives.ReverseEndianness(value));
        }

        public int ReadIntBe()
        {
            return BinaryPrimitives.ReverseEndianness(_reader.ReadInt32());
        }

        public void Write(uint value)
        {
            _writer.Write(value);
        }

        public uint ReadUint()
        {
            return _reader.ReadUInt32();
        }


        public void WriteVarInt(int value)
        {
            VarInt.WriteInt32(_buffer, value);
        }

        public int ReadVarInt()
        {
            return VarInt.ReadInt32(_reader);
        }

        public void WriteSignedVarInt(int value)
        {
            VarInt.WriteSInt32(_buffer, value);
        }

        public int ReadSignedVarInt()
        {
            return VarInt.ReadSInt32(_reader);
        }

        public void WriteUnsignedVarInt(uint value)
        {
            VarInt.WriteUInt32(_buffer, value);
        }

        public uint ReadUnsignedVarInt()
        {
            return VarInt.ReadUInt32(_reader);
        }

        public int ReadLength()
        {
            return (int)VarInt.ReadUInt32(_reader);
        }

        public void WriteLength(int value)
        {
            VarInt.WriteUInt32(_buffer, (uint)value);
        }

        public void WriteVarLong(long value)
        {
            VarInt.WriteInt64(_buffer, value);
        }

        public long ReadVarLong()
        {
            return VarInt.ReadInt64(_reader);
        }

        public void WriteEntityId(long value)
        {
            WriteSignedVarLong(value);
        }

        public void WriteSignedVarLong(long value)
        {
            VarInt.WriteSInt64(_buffer, value);
        }

        public long ReadSignedVarLong()
        {
            return VarInt.ReadSInt64(_reader);
        }

        public void WriteRuntimeEntityId(long value)
        {
            WriteUnsignedVarLong(value);
        }

        public void WriteUnsignedVarLong(long value)
        {
            // Need to fix this to ulong later
            VarInt.WriteUInt64(_buffer, (ulong)value);
        }

        public long ReadUnsignedVarLong()
        {
            // Need to fix this to ulong later
            return (long)VarInt.ReadUInt64(_reader);
        }

        public void Write(long value)
        {
            _writer.Write(BinaryPrimitives.ReverseEndianness(value));
        }

        public long ReadLong()
        {
            return BinaryPrimitives.ReverseEndianness(_reader.ReadInt64());
        }

        public void Write(ulong value)
        {
            _writer.Write(value);
        }

        public ulong ReadUlong()
        {
            return _reader.ReadUInt64();
        }

        public void Write(float value)
        {
            _writer.Write(value);
            //byte[] bytes = BitConverter.GetBytes(value);
            //_writer.Write(bytes[3]);
            //_writer.Write(bytes[2]);
            //_writer.Write(bytes[1]);
            //_writer.Write(bytes[0]);
        }

        public float ReadFloat()
        {
            //byte[] buffer = _reader.ReadBytes(4);
            //return BitConverter.ToSingle(new[] {buffer[3], buffer[2], buffer[1], buffer[0]}, 0);
            return _reader.ReadSingle();
        }

        public void Write(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                WriteLength(0);
                return;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(value);

            WriteLength(bytes.Length);
            Write(bytes);
        }
        public void WriteMagic()
        {
            byte[] magic = new byte[]
            {
            0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe,
            0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78
            };
            _writer.Write(magic);
        }
        public void Write(IPEndPoint endpoint)
        {
            if (endpoint.AddressFamily == AddressFamily.InterNetwork)
            {
                Write((byte)4);
                var parts = endpoint.Address.ToString().Split('.');
                foreach (var part in parts)
                {
                    Write((byte)~byte.Parse(part));
                }
                Write((short)endpoint.Port, true);
            }
        }
        public IPEndPoint ReadIPEndPoint()
        {
            byte ipVersion = ReadByte();

            IPAddress address = IPAddress.Any;
            int port = 0;

            if (ipVersion == 4)
            {
                string ipAddress = $"{(byte)~ReadByte()}.{(byte)~ReadByte()}.{(byte)~ReadByte()}.{(byte)~ReadByte()}";
                address = IPAddress.Parse(ipAddress);
                port = (ushort)ReadShort(true);
            }
            else if (ipVersion == 6)
            {
                ReadShort(); // Address family
                port = (ushort)ReadShort(true); // Port
                ReadLong(); // Flow info
                var addressBytes = ReadBytes(16);
                address = new IPAddress(addressBytes);
            }
            else
            {

            }

            return new IPEndPoint(address, port);
        }

        public string ReadString()
        {
            if (_reader.Position == _reader.Length) return string.Empty;
            int len = ReadLength();
            if (len <= 0) return string.Empty;
            return Encoding.UTF8.GetString(ReadBytes(len));
        }

        public void WriteFixedString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Write((short)0, true);
                return;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(value);

            Write((short)bytes.Length, true);
            Write(bytes);
        }

        public string ReadFixedString()
        {
            if (_reader.Position == _reader.Length) return string.Empty;
            short len = ReadShort(true);
            if (len <= 0) return string.Empty;
            return Encoding.UTF8.GetString(_reader.Read(len).Span);
        }
        public void Write(Vector2 vec)
        {
            Write((float)vec.X);
            Write((float)vec.Y);
        }

        public Vector2 ReadVector2()
        {
            return new Vector2(ReadFloat(), ReadFloat());
        }

        public void Write(Vector3 vec)
        {
            Write((float)vec.X);
            Write((float)vec.Y);
            Write((float)vec.Z);
        }

        public Vector3 ReadVector3()
        {
            return new Vector3(ReadFloat(), ReadFloat(), ReadFloat());
        }


        public void Write(BlockCoordinates coord)
        {
            WriteSignedVarInt(coord.X);
            WriteUnsignedVarInt((uint)coord.Y);
            WriteSignedVarInt(coord.Z);
        }

        public void WritePaintingCoordinates(BlockCoordinates coord)
        {
            Write((float)coord.X);
            Write((float)coord.Y);
            Write((float)coord.Z);
        }

        public BlockCoordinates ReadBlockCoordinates()
        {
            return new BlockCoordinates(ReadSignedVarInt(), (int)ReadUnsignedVarInt(), ReadSignedVarInt());
        }

        public void Write(PlayerLocation location)
        {
            Write(location.X);
            Write(location.Y);
            Write(location.Z);
            var d = 256f / 360f;
            Write((byte)Math.Round(location.Pitch * d)); // 256/360
            Write((byte)Math.Round(location.HeadYaw * d)); // 256/360
            Write((byte)Math.Round(location.Yaw * d)); // 256/360
        }

        public PlayerLocation ReadPlayerLocation()
        {
            PlayerLocation location = new PlayerLocation();
            location.X = ReadFloat();
            location.Y = ReadFloat();
            location.Z = ReadFloat();
            location.Pitch = ReadByte() * 1f / 0.71f;
            location.HeadYaw = ReadByte() * 1f / 0.71f;
            location.Yaw = ReadByte() * 1f / 0.71f;

            return location;
        }
        public void Write(UUID uuid)
        {
            if (uuid == null) throw new Exception("Expected UUID, required");
            Write(uuid.GetBytes());
        }

        public UUID ReadUUID()
        {
            UUID uuid = new UUID(ReadBytes(16));
            return uuid;
        }

        public void Write(Nbt nbt)
        {
            Write(nbt, _writer.BaseStream, nbt.NbtFile.UseVarInt);
        }

        public static void Write(Nbt nbt, Stream stream, bool useVarInt)
        {
            NbtFile file = nbt.NbtFile;
            file.BigEndian = false;
            file.UseVarInt = useVarInt;

            byte[] saveToBuffer = file.SaveToBuffer(NbtCompression.None);
            stream.Write(saveToBuffer, 0, saveToBuffer.Length);
        }


        public Nbt ReadNbt()
        {
            return ReadNbt(_reader);
        }

        public static Nbt ReadNbt(Stream stream, bool allowAlternativeRootTag = true, bool useVarInt = true)
        {
            Nbt nbt = new Nbt();
            NbtFile nbtFile = new NbtFile();
            nbtFile.BigEndian = false;
            nbtFile.UseVarInt = useVarInt;
            nbtFile.AllowAlternativeRootTag = allowAlternativeRootTag;

            nbt.NbtFile = nbtFile;
            nbtFile.LoadFromStream(stream, NbtCompression.None);

            return nbt;
        }

        public static NbtCompound ReadNbtCompound(Stream stream, bool useVarInt = false)
        {
            NbtFile file = new NbtFile();
            file.BigEndian = false;
            file.UseVarInt = useVarInt;
            file.AllowAlternativeRootTag = false;

            file.LoadFromStream(stream, NbtCompression.None);

            return (NbtCompound)file.RootTag;
        }

        public void Write(MetadataInts metadata)
        {
            if (metadata == null)
            {
                WriteUnsignedVarInt(0);
                return;
            }

            WriteUnsignedVarInt((uint)metadata.Count);

            for (byte i = 0; i < metadata.Count; i++)
            {
                MetadataInt slot = metadata[i] as MetadataInt;
                if (slot != null)
                {
                    WriteUnsignedVarInt((uint)slot.Value);
                }
            }
        }

        public MetadataInts ReadMetadataInts()
        {
            MetadataInts metadata = new MetadataInts();
            uint count = ReadUnsignedVarInt();

            for (byte i = 0; i < count; i++)
            {
                metadata[i] = new MetadataInt((int)ReadUnsignedVarInt());
            }

            return metadata;
        }


        public static byte[] GetNbtData(NbtCompound nbtCompound, bool useVarInt = true)
        {
            nbtCompound.Name = string.Empty;
            var file = new NbtFile(nbtCompound);
            file.BigEndian = false;
            file.UseVarInt = useVarInt;

            return file.SaveToBuffer(NbtCompression.None);
        }

        public void Write(MetadataDictionary metadata)
        {
            if (metadata != null)
            {
                metadata.WriteTo(_writer);
            }
        }

        public MetadataDictionary ReadMetadataDictionary()
        {
            //_buffer.Position = _reader.Position;
            var reader = new BinaryReader(_reader);
            var dictionary = MetadataDictionary.FromStream(reader);
            //_reader.Position = (int) _buffer.Position;
            return dictionary;
        }
        protected void Before(byte[] bytes)
        {
             Buffer = bytes;
            _reader = new MemoryStreamReader(Buffer);
            _writer = new BinaryWriter(_buffer);
            _buffer.Write(bytes);
            ReadVarInt();
        }
        protected void Before()
        {
             Buffer = null;
            _reader = new MemoryStreamReader(Buffer);
            _writer = new BinaryWriter(_buffer);
            WriteVarInt(id);
        }
        protected byte[] After()
        {
            _buffer.Flush();
            _writer.Flush();
            _reader.Flush();
            byte[] data = _buffer.ToArray();
            _buffer.Dispose();
            _writer.Dispose();
            _reader.Dispose();
            return data;
        }
        public abstract byte[] Serialize();

        public abstract void Deserialize(byte[] bytes);
    }
}
