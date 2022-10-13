using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework.Audio;
using System.Linq;

namespace ScreensaverEngine.FlyingToasters
{
    internal class ToasterController : Component
    {
        ToasterConfig config;

        Assembly currentAssembly = Assembly.GetExecutingAssembly();

        private static Random random = new Random();

        private const int toasterCollisionSize = 48;
        private Toast[] toasts;
        private List<Toast> toastsToRemove;

        private SoundEffect explosionSound;

        public Texture2D explosionTexture;

        public ToastType[] toastTypes;

        private List<AnimationTracker> explosionAnimators = new List<AnimationTracker>();

        public override void Initialize()
        {
            config = ConfigUtility.LoadConfig<ToasterConfig>();
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            explosionTexture = ContentUtility.LoadTexture2DFromManifest(currentAssembly, graphicsDevice, "explosion.png");

            explosionSound = SoundEffect.FromStream(currentAssembly.GetManifestResourceStream(
                $"{ContentUtility.GetManifestContentDirectory(currentAssembly)}.snd_badexplosion.wav"));

            List<ToastType> toastTypes = new List<ToastType>();

            AddToastConditionally(toastTypes, graphicsDevice, config.Toaster, "toaster.png", 6);
            AddToastConditionally(toastTypes, graphicsDevice, config.LightlyToastedToast, "toastlight.gif", 1);
            AddToastConditionally(toastTypes, graphicsDevice, config.WellToastedToast, "toastwell.gif", 1);
            AddToastConditionally(toastTypes, graphicsDevice, config.VeryWellToastedToast, "toastverywell.gif", 1);
            AddToastConditionally(toastTypes, graphicsDevice, config.BurntToast, "toastburnt.gif", 1);

            this.toastTypes = toastTypes.ToArray();

            // should probably move out of load content
            toasts = new Toast[config.NumToasters];
            toastsToRemove = new List<Toast>();

            for (int i = 0; i < toasts.Length; i++)
            {
                toasts[i] = new Toast();
                SpawnToaster(true, toasts[i]);
            }
        }

        private void AddToastConditionally(List<ToastType> toastTypes, GraphicsDevice graphicsDevice, bool condition, string toastTexture, int frames)
        {
            if (condition)
                toastTypes.Add(new ToastType(ContentUtility.LoadTexture2DFromManifest(currentAssembly, graphicsDevice, toastTexture), frames));
        }

        public override void Update(GameTime gameTime)
        {
            toastsToRemove.Clear();

            for (int i = 0; i < toasts.Length; i++)
            {
                toasts[i].position.X -= toasts[i].speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                toasts[i].position.Y += toasts[i].speed * 0.5f * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (toasts[i].position.X <= -64 || toasts[i].position.Y >= Engine.BaseHeight)
                {
                    toastsToRemove.Add(toasts[i]);
                }

                // Not optimal but shouldn't be an issue
                for (int x = 0; x < toasts.Length; x++)
                {
                    if (toasts[i] == toasts[x])
                        continue;

                    if (
                        new Rectangle((int)toasts[x].position.X, (int)toasts[x].position.Y, toasterCollisionSize, toasterCollisionSize).Intersects
                        (new Rectangle((int)toasts[i].position.X, (int)toasts[i].position.Y, toasterCollisionSize, toasterCollisionSize)))
                    {
                        if (!toastsToRemove.Contains(toasts[x]))
                            toastsToRemove.Add(toasts[x]);

                        if (!toastsToRemove.Contains(toasts[i]))
                            toastsToRemove.Add(toasts[i]);

                        explosionSound.Play(volume: .3f, pitch: 0.0f, pan: 0.0f);
                        explosionAnimators.Add(new AnimationTracker(explosionTexture, 17, (toasts[i].position + toasts[x].position) / 2, false));
                    }
                }
            }

            foreach (Toast toaster in toastsToRemove)
            {
                SpawnToaster(false, toaster);
            }

            foreach (Toast toaster in toasts)
            {
                toaster.Update(gameTime);
            }

            foreach (AnimationTracker tracker in explosionAnimators)
            {
                tracker.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Toast toaster in toasts)
            {
                toaster.Draw(spriteBatch);
            }

            List<AnimationTracker> animatorsToRemove = null;

            foreach (AnimationTracker animator in explosionAnimators)
            {
                if (animator.animationCompleted == false)
                {
                    animator.Draw(spriteBatch);
                }
                else
                {
                    if (animatorsToRemove == null)
                        animatorsToRemove = new List<AnimationTracker>();

                    animatorsToRemove.Add(animator);
                }
            }

            if (animatorsToRemove != null)
            {
                foreach (AnimationTracker animator in animatorsToRemove)
                {
                    explosionAnimators.Remove(animator);
                }
            }
        }

        private void SpawnToaster(bool initToaster, Toast toaster)
        {
            int toastX = 0;
            int toastY = 0;

            bool unsafeSpawn = true;

            while (unsafeSpawn)
            {
                unsafeSpawn = false;

                double toastPosDecider = random.NextDouble() * 2;

                if (initToaster)
                {
                    toastX = (int)(Engine.BaseWidth * random.NextDouble());
                    toastY = (int)(Engine.BaseHeight * (random.NextDouble()));
                }
                else if (toastPosDecider <= 1)
                {
                    toastX = (int)(Engine.BaseWidth * toastPosDecider);
                    toastY = -80;
                }
                else
                {
                    toastX = Engine.BaseWidth + 10;
                    toastY = (int)(Engine.BaseHeight * (toastPosDecider - 1));
                }

                int spawnCheckSize = toasterCollisionSize * 2;

                foreach (Toast toast in toasts)
                {
                    if (toast != null &&
                        new Rectangle(toastX, toastY, spawnCheckSize, spawnCheckSize).Intersects
                        (new Rectangle((int)toast.position.X, (int)toast.position.Y, spawnCheckSize, spawnCheckSize)))
                    {
                        unsafeSpawn = true;
                    }
                }
            }

            toaster.Initialize(new Vector2(toastX, toastY), toastTypes[random.Next(toastTypes.Length - 1)], random.Next(config.MinSpeed, config.MaxSpeed));
        }
    }
}
