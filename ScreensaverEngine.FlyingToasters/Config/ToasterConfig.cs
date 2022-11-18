using Newtonsoft.Json;

namespace ScreensaverEngine.FlyingToasters
{
    public class ToasterConfig
    {
        [JsonProperty]
        public int NumToasters { get; internal set; } = 10;

        [JsonProperty]
        public bool LightlyToastedToast { get; internal set; } = true;
        [JsonProperty]
        public bool WellToastedToast { get; internal set; } = true;
        [JsonProperty]
        public bool VeryWellToastedToast { get; internal set; } = true;
        [JsonProperty]
        public bool BurntToast { get; internal set; } = true;
        [JsonProperty]
        public bool Toaster { get; internal set; } = true;

        [JsonProperty]
        public float Volume { get; internal set; } = 0.1f;

        [JsonProperty]
        public int MaxSpeed { get; internal set; } = 200;
        [JsonProperty]
        public int MinSpeed { get; internal set; } = 90;
    }
}
