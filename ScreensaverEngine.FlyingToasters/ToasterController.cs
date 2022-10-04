using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework.Audio;

namespace ScreensaverEngine.FlyingToasters
{
    internal class ToasterController : Component
    {
        Assembly currentAssembly = Assembly.GetExecutingAssembly();
        const string contentDir = "ScreensaverEngine.FlyingToasters.Content";

        private static Random random = new Random();

        private const float maxToasters = 20f;
        private const float timeBetweenToasters = .5f;

        private const int toasterCollisionSize = 48;

        private static double lastToasterDepartureTime = 0;
        private static HashSet<Toaster> toasters = new HashSet<Toaster>();

        private static SoundEffect explosionSound;

        public static Texture2D explosionTexture;

        public static Dictionary<Toaster.ToastType, Texture2D[]> toasterTextures = new Dictionary<Toaster.ToastType, Texture2D[]>();

        private static List<AnimationTracker> explosionAnimators = new List<AnimationTracker>();

        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            explosionTexture = Texture2D.FromStream(graphicsDevice, currentAssembly.GetManifestResourceStream($"{contentDir}.explosion.png"));

            explosionSound = SoundEffect.FromStream(currentAssembly.GetManifestResourceStream($"{contentDir}.snd_badexplosion.wav"));

            toasterTextures[Toaster.ToastType.Toaster] = new Texture2D[]
            {
                Texture2D.FromStream(graphicsDevice, currentAssembly.GetManifestResourceStream($"{contentDir}.toaster.png"))
            };
            toasterTextures[Toaster.ToastType.Toast] = new Texture2D[]
            {
                Texture2D.FromStream(graphicsDevice, currentAssembly.GetManifestResourceStream($"{contentDir}.toastlight.gif")),
                Texture2D.FromStream(graphicsDevice, currentAssembly.GetManifestResourceStream($"{contentDir}.toastwell.gif")),
                Texture2D.FromStream(graphicsDevice, currentAssembly.GetManifestResourceStream($"{contentDir}.toastverywell.gif")),
                Texture2D.FromStream(graphicsDevice, currentAssembly.GetManifestResourceStream($"{contentDir}.toastburnt.gif"))
            };
        }

        public override void Update(GameTime gameTime)
        {
            if (toasters.Count < maxToasters && lastToasterDepartureTime + timeBetweenToasters <= gameTime.TotalGameTime.TotalSeconds)
            {
                int toasterX = 0;
                int toasterY = 0;

                bool unsafeSpawn = true;

                while (unsafeSpawn)
                {
                    unsafeSpawn = false;

                    double toastPosDecider = random.NextDouble() * 2;

                    if (toastPosDecider <= 1)
                    {
                        toasterX = (int)(Engine.BaseWidth * toastPosDecider);
                        toasterY = -80;
                    }
                    else
                    {
                        toasterX = Engine.BaseWidth + 10;
                        toasterY = (int)(Engine.BaseHeight * (toastPosDecider - 1));
                    }

                    int spawnCheckSize = toasterCollisionSize * 2;

                    foreach (Toaster toaster in toasters)
                    {
                        if (
                            new Rectangle(toasterX, toasterY, spawnCheckSize, spawnCheckSize).Intersects
                            (new Rectangle((int)toaster.position.X, (int)toaster.position.Y, spawnCheckSize, spawnCheckSize)))
                        {
                            Debug.Log($"failed against toaster at X {toaster.position.X} Y {toaster.position.Y}. My pos is X {toasterX} Y {toasterY}");
                            unsafeSpawn = true;
                        }
                    }
                }

                Debug.Log($"Toaster departed at {gameTime.TotalGameTime.TotalSeconds} X: {toasterX} Y: {toasterY}");

                toasters.Add(new Toaster(new Vector2(toasterX, toasterY)));

                lastToasterDepartureTime = gameTime.TotalGameTime.TotalSeconds;
            }

            HashSet<Toaster> toastersToRemove = null;

            foreach (Toaster toaster in toasters)
            {
                toaster.position.X -= toaster.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                toaster.position.Y += toaster.speed * 0.5f * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (toaster.position.X <= -64 || toaster.position.Y >= Engine.BaseHeight)
                {
                    Debug.Log($"Toaster sent to landfill at {gameTime.TotalGameTime.TotalSeconds}");
                    if (toastersToRemove == null)
                        toastersToRemove = new HashSet<Toaster>();

                    toastersToRemove.Add(toaster);
                }

                // Not optimal but shouldn't be an issue
                foreach (Toaster toaster1 in toasters)
                {
                    if (toaster1 == toaster)
                        continue;

                    if (
                        new Rectangle((int)toaster.position.X, (int)toaster.position.Y, toasterCollisionSize, toasterCollisionSize).Intersects
                        (new Rectangle((int)toaster1.position.X, (int)toaster1.position.Y, toasterCollisionSize, toasterCollisionSize)))
                    {
                        if (toastersToRemove == null)
                            toastersToRemove = new HashSet<Toaster>();

                        if (!toastersToRemove.Contains(toaster))
                            toastersToRemove.Add(toaster);

                        if (!toastersToRemove.Contains(toaster1))
                            toastersToRemove.Add(toaster1);

                        explosionSound.Play();
                        explosionAnimators.Add(new AnimationTracker(explosionTexture, 17, toaster.position, false));
                    }
                }
            }

            if (toastersToRemove != null)
            {
                foreach (Toaster toaster in toastersToRemove)
                {
                    toasters.Remove(toaster);
                }
            }

            foreach(Toaster toaster in toasters)
            {
                toaster.Update(gameTime);
            }

            foreach(AnimationTracker tracker in explosionAnimators)
            {
                tracker.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Toaster toaster in toasters)
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
        }
    }
}
