using Newtonsoft.Json;
using System;
using System.IO;

namespace ScreensaverEngine
{
    public class EngineConfig
    {
        public static string EngineConfigPath => Path.Combine(ConfigUtility.BaseConfigPath, "EngineConfig.json");

        [JsonProperty]
        public string AssemblyToLoad { get; internal set; } = "ScreensaverEngine.Parallax, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
    }
}
