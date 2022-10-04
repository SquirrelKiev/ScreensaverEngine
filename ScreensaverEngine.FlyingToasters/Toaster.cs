using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreensaverEngine.FlyingToasters
{
    internal class Toaster
    {
        private static Random random = new Random();

        public const int minSpeed = 90;
        public const int maxSpeed = 200;

        public Vector2 position;
        public int speed;

        private AnimationTracker tracker;

        public enum ToastType
        {
            Toaster = 6,
            Toast = 1
        }

        public Toaster(Vector2 startingPosition)
        {
            speed = random.Next(minSpeed, maxSpeed);
            position = startingPosition;

            ToastType[] toastTypes = Enum.GetValues<ToastType>();
            ToastType toastType = toastTypes[random.Next(0, toastTypes.Length)];
            Texture2D[] textures = ToasterController.toasterTextures[toastType];

            tracker = new AnimationTracker(textures[random.Next(0, textures.Length - 1)], (int)toastType, position, true, 1 / (speed * .1f));
        }

        public void Update(GameTime gameTime)
        {
            tracker.position = position;
            tracker.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            tracker.Draw(spriteBatch);
        }
    }
}
