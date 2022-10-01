using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreensaverEngine
{
    /// <summary>
    /// This is instantiated at runtime by the <see cref="Engine"/>, and calls the overridable methods. 
    /// All passed in variables can be also grabbed from <see cref="Engine"/>, they are simply passed in for convenience. 
    /// </summary>
    public abstract class Component
    {
        public virtual void Initialize() { }
        public virtual void LoadContent(GraphicsDevice graphicsDevice) { }
        public virtual void OnShutdown() { }

        public virtual void PreUpdate(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void PostUpdate(GameTime gameTime) { }

        public virtual void PreDraw() { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
        public virtual void PostDraw() { }
    }
}
