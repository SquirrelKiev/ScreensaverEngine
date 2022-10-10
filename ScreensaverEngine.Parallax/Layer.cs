using System.Numerics;

namespace ScreensaverEngine.Parallax
{
    public struct Layer
    {
        public string filePath;
        public bool isEmbedded;
        public int speed;
        public int yOffset = 0;
        public Vector2? customScale;

        public Layer(string filePath, int speed, bool isEmbedded = false, int yOffset = 0, Vector2? customScale = null)
        {
            this.filePath = filePath;
            this.speed = speed;
            this.isEmbedded = isEmbedded;
            this.yOffset = yOffset;
            this.customScale = customScale;
        }
    }
}
