using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ScreensaverEngine.Test
{
    internal class TestClass : Component
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Engine.Rectangle, new Rectangle(Engine.BaseWidth / 2, Engine.BaseHeight / 2, 20, 20), Color.White);
        }
    }
}
