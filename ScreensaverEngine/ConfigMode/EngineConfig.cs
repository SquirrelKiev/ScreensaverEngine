using Newtonsoft.Json;
using System;
using System.IO;

namespace ScreensaverEngine.Config
{
    public class EngineConfig
    {
        public static string EngineConfigPath
        {
            get
            {
                return Path.Combine(ConfigUtility.BaseConfigPath, "EngineConfig.json");
            }
        }

        [JsonProperty]
        public string AssemblyToLoad { get; internal set; } = "ScreensaverEngine.Parallax, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        public EngineConfig()
        { }
    }
}
