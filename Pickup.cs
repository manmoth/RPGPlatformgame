using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;

namespace WindowsGame1
{
    enum ItemType
    {
        COIN, 
        Item2,
        Item3
    }

    class Pickup
    {
        ItemType Type;
        Vector2 Position;
        List<Texture2D> Textures;

        public Vector2 GetPosition()
        {
            return new Vector2(ConvertUnits.ToDisplayUnits(Position.X), ConvertUnits.ToDisplayUnits(Position.Y));
        }
        public void Initialize(Texture2D PUtexture,ItemType IT, Vector2 position)
        {
            
        }
        public void Update(Vector2 playerPos)
        {
            Rectangle rectPlayer = new Rectangle((int)playerPos.X, (int)playerPos.Y, Settings.PLAYERWIDTH, Settings.PLAYERHEIGHT);
        }
        public void Draw(SpriteBatch batch, Vector2 ScreenOffset)
        {
            batch.Draw(Textures[0], Position-ScreenOffset, Color.White);
        }

        
        
    }
}
