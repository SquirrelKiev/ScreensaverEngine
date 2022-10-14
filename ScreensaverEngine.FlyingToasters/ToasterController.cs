using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Reflection;
using Microsoft.Xna.Framework.Audio;

namespace ScreensaverEngine.FlyingToasters
{
    internal class ToasterController : Component
    {
        private ToasterConfig config;

        private readonly Assembly currentAssembly = Assembly.GetExecutingAssembly();

        private static readonly Random random = new();

        private const int toasterCollisionSize = 48;
        private Toast[] toasts;
        private List<Toast> toastsToRemove;

        private SoundEffect explosionSound;

        public Texture2D explosionTexture;

        public ToastType[] toastTypes;

        private readonly List<AnimationTracker> explosionAnimators = new();

        public override void Initialize()
        {
            config = ConfigUtility.LoadConfig<ToasterConfig>();
        }

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            explosionTexture = ContentUtility.LoadTexture2DFromManifest(currentAssembly, graphicsDevice, "explosion.png");

            explosionSound = SoundEffect.FromStream(currentAssembly.GetManifestResourceStream(
                $"{ContentUtility.GetManifestContentDirectory(currentAssembly)}.snd_badexplosion.wav"));

            var tempToastTypes = new List<ToastType>();

            AddToastConditionally(tempToastTypes, graphicsDevice, config.Toaster, "toaster.png", 6);
            AddToastConditionally(tempToastTypes, graphicsDevice, config.LightlyToastedToast, "toastlight.gif", 1);
            AddToastConditionally(tempToastTypes, graphicsDevice, config.WellToastedToast, "toastwell.gif", 1);
            AddToastConditionally(tempToastTypes, graphicsDevice, config.VeryWellToastedToast, "toastverywell.gif", 1);
            AddToastConditionally(tempToastTypes, graphicsDevice, config.BurntToast, "toastburnt.gif", 1);

            this.toastTypes = tempToastTypes.ToArray();

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

            foreach (var toast in toasts)
            {
                toast.position.X -= toast.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                toast.position.Y += toast.speed * 0.5f * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (toast.position.X <= -64 || toast.position.Y >= Engine.BaseHeight)
                {
                    toastsToRemove.Add(toast);
                }

                // Not optimal but shouldn't be an issue
                foreach (var collidingToast in toasts)
                {
                    if (toast == collidingToast)
                        continue;

                    var a = new Rectangle((int)collidingToast.position.X, (int)collidingToast.position.Y,
                        toasterCollisionSize, toasterCollisionSize);
                    var b = new Rectangle((int)toast.position.X, (int)toast.position.Y, toasterCollisionSize,
                        toasterCollisionSize);

                    if (!a.Intersects(b)) continue;

                    if (!toastsToRemove.Contains(collidingToast))
                        toastsToRemove.Add(collidingToast);

                    if (!toastsToRemove.Contains(toast))
                        toastsToRemove.Add(toast);

                    explosionSound.Play(volume: .3f, pitch: 0.0f, pan: 0.0f);
                    explosionAnimators.Add(new AnimationTracker(explosionTexture, 17, (toast.position + collidingToast.position) / 2, false));
                }
            }

            foreach (var toaster in toastsToRemove)
            {
                SpawnToaster(false, toaster);
            }

            foreach (var toaster in toasts)
            {
                toaster.Update(gameTime);
            }

            foreach (var tracker in explosionAnimators)
            {
                tracker.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var toaster in toasts)
            {
                toaster.Draw(spriteBatch);
            }

            List<AnimationTracker> animatorsToRemove = null;

            foreach (var animator in explosionAnimators)
            {
                if (animator.AnimationCompleted == false)
                {
                    animator.Draw(spriteBatch);
                }
                else
                {
                    animatorsToRemove ??= new List<AnimationTracker>();

                    animatorsToRemove.Add(animator);
                }
            }

            if (animatorsToRemove == null) return;

            foreach (var animator in animatorsToRemove)
            {
                explosionAnimators.Remove(animator);
            }
        }

        private void SpawnToaster(bool initToaster, Toast toaster)
        {
            var toastX = 0;
            var toastY = 0;

            var unsafeSpawn = true;

            while (unsafeSpawn)
            {
                unsafeSpawn = false;

                var toastPosDecider = random.NextDouble() * 2;

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

                const int spawnCheckSize = toasterCollisionSize * 2;

                foreach (var toast in toasts)
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
