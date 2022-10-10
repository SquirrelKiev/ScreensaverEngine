namespace ScreensaverEngine.Parallax
{
    public struct Layer
    {
        public string filePath;
        public bool isEmbedded;
        public int speed;

        public Layer(string filePath, int speed, bool isEmbedded = false)
        {
            this.filePath = filePath;
            this.isEmbedded = isEmbedded;
            this.speed = speed;
        }
    }
}
