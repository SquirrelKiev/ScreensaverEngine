using Newtonsoft.Json;

namespace ScreensaverEngine
{
    public class EngineConfig
    {
        [JsonProperty]
        public string AssemblyToLoad { get; internal set; } = "ScreensaverEngine.Parallax, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
    }
}
