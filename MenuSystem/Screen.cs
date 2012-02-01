using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    public abstract class Screen
    {
        public Screen()
        {

        }
        public virtual void Initialize(IServiceProvider services)
        {

        }
        public virtual void LoadContent()
        {

        }
        public virtual void UnloadContent() 
        {

        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
