using Microsoft.Xna.Framework.Graphics;

namespace ScreensaverEngine.FlyingToasters
{
    public struct ToastType
    {
        public ToastType(Texture2D texture, int frames)
        {
            this.frames = frames;
            this.texture = texture;
        }

        public int frames;
        public Texture2D texture;
    }
}
