﻿using System;

namespace Skynet
{
    public static class Config
    {
        public static ulong BotChannelId = 0;
        public static string ApiKey;
        public static string BotDir = Environment.CurrentDirectory;
        public static string Branch;
        public static string BotName = "Skynet";
        public static string Version = "0.2.5.5";
        public static string OS = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
        public static string LogWithoutStamp;
    }
}