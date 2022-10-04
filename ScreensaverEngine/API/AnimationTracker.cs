using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ScreensaverEngine
{
    public class AnimationTracker
    {
        public Vector2 position = Vector2.Zero;
        public Texture2D spritesheet { get; private set; }
        public bool loop { get; private set; } = false;
        public bool animationCompleted { get; private set; } = false;
        public float timeBetweenFrames = .1f;

        private float frameWidth
        {
            get
            {
                return spritesheet.Width / totalFrames;
            }
        }

        private float lastFrameRendered = 0f;
        private int frame = 0;
        private int totalFrames = 1;

        public AnimationTracker(Texture2D spritesheet, int totalFrames, Vector2 startingPosition, bool loop = true, float timeBetweenFrames = 0.05f)
        {
            this.spritesheet = spritesheet;
            this.totalFrames = totalFrames;
            this.loop = loop;
            this.timeBetweenFrames = timeBetweenFrames;
            position = startingPosition;
        }

        public void Update(GameTime gameTime)
        {
            if (lastFrameRendered + timeBetweenFrames <= gameTime.TotalGameTime.TotalSeconds)
            {
                frame++;
                if (frame > totalFrames - 1)
                {
                    if (loop == false)
                    {
                        animationCompleted = true;
                        return;
                    }

                    frame = 0;
                }

                lastFrameRendered = (float)gameTime.TotalGameTime.TotalSeconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Raylib.DrawText($"{frame}", 20, 20, 36, Color.GREEN);position

            spriteBatch.Draw(spritesheet,
                new Rectangle((int)position.X, (int)position.Y, (int)frameWidth, spritesheet.Height),
                new Rectangle((int)frameWidth * frame, 0, (int)frameWidth, spritesheet.Height),
                Color.White);
        }
    }
}
