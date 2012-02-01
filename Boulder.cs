using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;

namespace WindowsGame1
{
    class Boulder : InteractiveItem, PhysicalObject
    {
        public List<Body> Bodies { get; set; }
        CircleShape cs;
        public void InitializePhysics(World world)
        {
            Body body = new Body(world);
            Vertices verts = new Vertices();
            verts.Add(new Vector2((Position.X + 25) / Settings.PHYSICSSCALE, (Position.Y + 7) / Settings.PHYSICSSCALE));
            verts.Add(new Vector2((Position.X + 75) / Settings.PHYSICSSCALE, (Position.Y + 7) / Settings.PHYSICSSCALE));
            verts.Add(new Vector2((Position.X + 100) / Settings.PHYSICSSCALE, (Position.Y +50) / Settings.PHYSICSSCALE));
            verts.Add(new Vector2((Position.X + 75) / Settings.PHYSICSSCALE, (Position.Y +43) / Settings.PHYSICSSCALE));
            verts.Add(new Vector2((Position.X + 25) / Settings.PHYSICSSCALE, (Position.Y +43) / Settings.PHYSICSSCALE));
            verts.Add(new Vector2((Position.X) / Settings.PHYSICSSCALE, (Position.Y + +50) / Settings.PHYSICSSCALE));
            cs = new CircleShape(2.5f,0);
            cs.Position = Position;
            
            body.CreateFixture(cs);
            body.BodyType = BodyType.Dynamic;
            
            Bodies.Add(body);
        }
        //Event evnt;
        public void Initialize(Texture2D Texture, Vector2 Position, World world)//Lets rock and roll
        {
            
            base.Initialize(Texture, Position);
            //Bounds = new Rectangle((int)Position.X, (int)Position.Y);
            Bodies = new List<Body>();
            InitializePhysics(world);
        }

        public void SetEvent(/*HvilkenEvent X*/)
        {
            //Setter tilens event
            //evnt= new Event(X);
        }


        public Vector2 GetPosition()
        {
            return new Vector2(ConvertUnits.ToDisplayUnits(Position.X), ConvertUnits.ToDisplayUnits(Position.Y));
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 ScreenOffset)
        {
            float f1 = (int)(Bodies[0].Position.X * Settings.PHYSICSSCALE) -ScreenOffset.X;
            float f2 = (int)(Bodies[0].Position.Y * Settings.PHYSICSSCALE)- ScreenOffset.Y;
            Vector2 v2=  new Vector2(f1,f2 );
            spriteBatch.Draw(Textures[0],v2, Color.White);
        }
    }
}
