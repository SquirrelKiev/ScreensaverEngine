using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ScreensaverEngine.Parallax
{
    internal class RuntimeLayer
    {
        public Layer Layer { get; }
        public Vector2 currentPosition = Vector2.Zero;
        public Texture2D Texture { get; }
        public Vector2 Scale { get; }
        public Rectangle BoundingBox => new((int)currentPosition.X, (int)currentPosition.Y, (int)Scale.X, (int)Scale.Y);

        internal RuntimeLayer(Layer layer, Texture2D texture)
        {
            Layer = layer;
            Texture = texture;
            currentPosition.X = 1 - Scale.X;
            currentPosition.Y = layer.yOffset;

            Scale = layer.customScale ?? new Vector2(texture.Width, texture.Height);
        }
    }
}
