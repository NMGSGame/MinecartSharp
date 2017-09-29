﻿using System;
using System.Collections.Generic;
using MinecartSharp.MinecaftSharp.Networking.Interfaces;
using MinecartSharp.MinecartSharp.Networking.Packets;
using MinecartSharp.Objects;
using MinecartSharp.Networking.Packets;

namespace MinecartSharp.MinecartSharp.Networking
{
    internal class Globals
    {
        public static string ProtocolName = "MinecartSharp 1.12";
        public static int ProtocolVersion = 340;
        public static int MaxPlayers = 10;
        public static int PlayersOnline = 0;
        public static string ServerMOTD = "Themepark lol";
        internal static List<IPacket> Packets = new List<IPacket>();
        public static int LastUniqueID = 0;
        public static byte Difficulty = 0;
        public static bool UseCompression = false;

        private static void LoadDebugChunks()
        {
            Program.Logger.Log(Utils.LogType.Info, "Generating debug chunks");
            Globals.ChunkColums.Add(Globals.WorldGen.GenerateChunkColumn(new Vector2(0, 0)));
            /*   int r = 49; //Radius. (13*4 = 52) and we need 49 Chunks for a player to spawn. So this should be fine :)
               int ox = 0, oy = 0; //Middle point

               int done = 0;
               for (int x = -r; x < r ; x++)
               {
                   int height = (int)Math.Sqrt(r * r - x * x);

                   for (int y = -height; y < height; y++)
                   {
                       Globals.ChunkColums.Add (Globals.WorldGen.GenerateChunkColumn (new Vector2 (x + ox, y + oy)));
                       done++;
                       if (done == r)
                           break;
                   }
                   if (done == r)
                       break;
               }*/
            Program.Logger.Log(Utils.LogType.Info, "Done debug chunks");
        }

        #region WorldGeneration
        public static FlatLandGenerator WorldGen = new FlatLandGenerator();
        public static List<ChunkColumn> ChunkColums = new List<ChunkColumn>();
        public static string LVLType = "flat";
        #endregion      


        internal static void setupPackets()
        {
            Packets.Add(new HandshakePacket());
            Packets.Add(new LoginSuccess());
            Packets.Add(new Ping());
            Packets.Add(new KeepAlive());
        }
    }
}