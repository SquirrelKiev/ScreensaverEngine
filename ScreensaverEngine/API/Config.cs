using Newtonsoft.Json;

namespace ScreensaverEngine
{
    public class Config
    {
        [JsonProperty]
        public string assemblyToLoad { get; private set; } = "ScreensaverEngine.FlyingToasters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        internal Config()
        { }
    }
}
