using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace ScreensaverEngine.Config
{
    public class EngineConfig
    {
        [JsonProperty]
        public string AssemblyToLoad { get; private set; } = "ScreensaverEngine.Parallax, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        internal EngineConfig()
        { }

        internal static EngineConfig LoadConfig()
        {
            // TODO
            return new EngineConfig();
        }
    }
}
