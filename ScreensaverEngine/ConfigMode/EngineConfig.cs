using Newtonsoft.Json;
using System;
using System.IO;

namespace ScreensaverEngine.Config
{
    public class EngineConfig
    {
        public static string BaseConfigPath
        {
            get
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ScreensaverEngine");
                Directory.CreateDirectory(path);

                return path;
            }
        }

        public static string EngineConfigPath
        {
            get
            {
                return Path.Combine(BaseConfigPath, "EngineConfig.json");
            }
        }

        [JsonProperty]
        public string AssemblyToLoad { get; internal set; } = "ScreensaverEngine.Parallax, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        internal EngineConfig()
        { }

        internal static EngineConfig LoadConfig()
        {
            EngineConfig config;
            if (File.Exists(EngineConfigPath))
            {
                config = JsonConvert.DeserializeObject<EngineConfig>(File.ReadAllText(EngineConfigPath));
            }
            else
            {
                config = new EngineConfig();
            }

            return config;
        }

        internal void SaveConfig()
        {
            var json = JsonConvert.SerializeObject(this);

            File.WriteAllText(EngineConfigPath, json);
        }
    }
}
