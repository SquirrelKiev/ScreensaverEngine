using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;

namespace ScreensaverEngine
{
    public class Engine : Game
    {
        #region Variables
        public EngineConfig Config { get; }

        public GameTime GameTime { get; private set; }

        public GraphicsDeviceManager Graphics { get; }
        public Matrix ScreenMatrix { get; private set; }
        public Viewport Viewport { get; private set; }

        public const int BaseWidth = 1280;
        public const int BaseHeight = 720;
        public int ViewWidth { get; private set; }
        public int ViewHeight { get; private set; }

        public bool PreviewMode => previewWndHandle.HasValue;
        private readonly IntPtr? previewWndHandle;

        public Color BackgroundColor { get; set; } = Color.Black;

        public SpriteBatch SpriteBatch { get; private set; }

        private readonly Component[] components;

        public Texture2D Rectangle { get; private set; }
        #endregion Variables

        internal Engine(Assembly assembly, EngineConfig config, IntPtr? previewWndHandle = null)
        {
            Config = config;
            this.previewWndHandle = previewWndHandle;

            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            components = ReflectionUtility.GetInstancedTypesFromAssembly<Component>(assembly, true);
            foreach (var component in components)
            {
                component.Engine = this;
            }
        }

        protected override void Initialize()
        {
            if (PreviewMode)
            {
                var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Window.Handle);

                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

                // ReSharper disable once PossibleInvalidOperationException
                NativeMethods.GetClientRect(previewWndHandle.Value, out var parentRect);

                Graphics.PreferredBackBufferWidth = parentRect.Size.Width;
                Graphics.PreferredBackBufferWidth = parentRect.Size.Height;
                Graphics.IsFullScreen = false;
                IsMouseVisible = true;

                Graphics.ApplyChanges();

                // Set the preview window as the parent of this window
                NativeMethods.SetParent(Window.Handle, previewWndHandle.Value);

                // Make this a child window so it will close when the parent dialog closes
#pragma warning disable CA1806 // Do not ignore method results - its probably fine
                NativeMethods.SetWindowLong(Window.Handle, -16, new IntPtr(NativeMethods.GetWindowLong(Window.Handle, -16) | 0x40000000));
#pragma warning restore CA1806 // Do not ignore method results

                // Move and resize the window to fit within the parent
                NativeMethods.MoveWindow(Window.Handle, parentRect.Left, parentRect.Top, parentRect.Right, parentRect.Bottom, false);
            }
            else
            {
#if DEBUG
                Graphics.PreferredBackBufferWidth = 1280;
                Graphics.PreferredBackBufferHeight = 720;
                Graphics.ApplyChanges();
#else
                Graphics.PreferredBackBufferWidth  = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                Graphics.IsFullScreen = true;
                IsMouseVisible = false;
                Graphics.ApplyChanges();
#endif
            }

            UpdateView();

            Debug.Log($"Base Width: {BaseWidth}, Base Height: {BaseHeight}");
            Debug.Log($"Window Width: {ViewWidth}, Window Height: {ViewHeight}");

            foreach (var component in components) component.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Rectangle = new Texture2D(GraphicsDevice, 1, 1);
            Rectangle.SetData(new[] { Color.White });

            foreach (var component in components) component.LoadContent(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            GameTime = gameTime;

            foreach (var component in components) component.PreUpdate(gameTime);

            foreach (var component in components) component.Update(gameTime);

            base.Update(gameTime);

            foreach (var component in components) component.PostUpdate(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameTime = gameTime;

            foreach (var component in components) component.PreDraw();

            base.Draw(gameTime);

            GraphicsDevice.Viewport = Viewport;

            GraphicsDevice.Clear(BackgroundColor);

            SpriteBatch.Begin(transformMatrix: ScreenMatrix, samplerState: SamplerState.PointClamp);
            {
                foreach (var component in components) component.Draw(SpriteBatch);
            }
            SpriteBatch.End();

            foreach (var component in components) component.PostDraw();
        }

        // thank you monocle engine very cool
        private void UpdateView()
        {
            float screenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            float screenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

            if (screenWidth / BaseWidth > screenHeight / BaseHeight)
            {
                ViewWidth = (int)(screenHeight / BaseHeight * BaseWidth);
                ViewHeight = (int)screenHeight;
            }
            else
            {
                ViewWidth = (int)screenWidth;
                ViewHeight = (int)(screenWidth / BaseWidth * BaseHeight);
            }

            // update screen matrix
            ScreenMatrix = Matrix.CreateScale(ViewWidth / (float)BaseWidth);

            // update viewport
            Viewport = new Viewport
            {
                X = (int)(screenWidth / 2f - ViewWidth / 2f),
                Y = (int)(screenHeight / 2f - ViewHeight / 2f),
                Width = ViewWidth,
                Height = ViewHeight,
                MinDepth = 0,
                MaxDepth = 1
            };
        }
    }
}