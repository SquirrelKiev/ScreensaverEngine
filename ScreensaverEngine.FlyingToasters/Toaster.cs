using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ScreensaverEngine.FlyingToasters
{
    internal class Toast
    {
        public Vector2 position;
        public int speed;

        private AnimationTracker tracker;

        public void Initialize(Vector2 startingPosition, ToastType toastType, int speed)
        {
            this.speed = speed;

            position = startingPosition;

            tracker = new AnimationTracker(toastType.texture, toastType.frames, position, true, 1 / (speed * .1f));
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
