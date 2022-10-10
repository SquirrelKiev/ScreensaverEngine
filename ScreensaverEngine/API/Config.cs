using Newtonsoft.Json;

namespace ScreensaverEngine
{
    public class Config
    {
        [JsonProperty]
        public string AssemblyToLoad { get; private set; } = "ScreensaverEngine.Parallax, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        internal Config()
        { }
    }
}
