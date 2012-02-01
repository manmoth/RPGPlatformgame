using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{   
    
    class InteractiveItem
    {
        public Vector2 Position { get; set;}
        public List<Texture2D> Textures{ get; set;}
        public Rectangle Bounds { get; set; }

        public virtual void Initialize(Texture2D Texture,Vector2 Position)
        {
            this.Position = new Vector2(Position.X, Position.Y);
            this.Bounds = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            this.Textures = new List<Texture2D>();
            this.Textures.Add(Texture);
        }

        public virtual void Update()
        {
            this.Bounds = new Rectangle((int)Position.X, (int)Position.Y, Bounds.Width, Bounds.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 ScreenOffset)
        {
            spriteBatch.Draw(Textures[0], new Rectangle((int)(Position.X - ScreenOffset.X), (int)(Position.Y - ScreenOffset.Y), Bounds.Width, Bounds.Height), Color.White);
   }
    }
}

