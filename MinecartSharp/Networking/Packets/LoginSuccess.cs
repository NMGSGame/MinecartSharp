﻿using MinecartSharp.MinecaftSharp.Networking.Interfaces;
using MinecartSharp.MinecartSharp.Networking.Helpers;
using MinecartSharp.MinecartSharp.Networking.Wrappers;

namespace MinecartSharp.MinecartSharp.Networking.Packets
{
    public class LoginSuccess : IPacket
    {
        public int PacketID
        {
            get
            {
                return 0x02;
            }
        }

        public bool IsPlayePacket
        {
            get
            {
                return true;
            }
        }

        public void Read(ClientWrapper state, MSGBuffer buffer, object[] Arguments)
        {
        }

        public void Write(ClientWrapper state, MSGBuffer buffer, object[] Arguments)
        {
            buffer.WriteVarInt(PacketID);
            buffer.WriteString((string)Arguments[0]);
            buffer.WriteString((string)Arguments[1]);
            buffer.FlushData();
        }
    }
}
