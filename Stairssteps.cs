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
    class Stairssteps : InteractiveItem, PhysicalObject
    {
        public List<Body> Bodies { get; set; }
        public bool IsStair { get; set; }
        public Event thisEvent { get; set; }

        public Vector2 GetPosition()
        {
            return new Vector2(ConvertUnits.ToDisplayUnits(Position.X), ConvertUnits.ToDisplayUnits(Position.Y));
        }
        public void InitializePhysics(World world)
        {
            Body body = new Body(world);
            Vertices verts = new Vertices();
            if (!IsStair) verts.Add(new Vector2(ConvertUnits.ToSimUnits(Bounds.X), ConvertUnits.ToSimUnits(Bounds.Y)));
            verts.Add(new Vector2(ConvertUnits.ToSimUnits(Bounds.X + Bounds.Width), ConvertUnits.ToSimUnits(Bounds.Y)));
            verts.Add(new Vector2(ConvertUnits.ToSimUnits(Bounds.X + Bounds.Width), ConvertUnits.ToSimUnits(Bounds.Y + Bounds.Height)));
            verts.Add(new Vector2(ConvertUnits.ToSimUnits(Bounds.X), ConvertUnits.ToSimUnits(Bounds.Y + Bounds.Height)));
            
            body.CreateFixture(new PolygonShape(verts, 0));


            body.Friction = 0.40f;
            Bodies = new List<Body>();
            Bodies.Add(body);
        }
        //Event evnt;
        public void Initialize(Texture2D Texture, Vector2 Position, World world, bool IsStair)
        {
            this.IsStair = IsStair;
            base.Initialize(Texture, Position);
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, IsStair ? Settings.STAIRWIDTH : Settings.PLATEAUWIDTH, IsStair ? Settings.STAIRHEIGHT : Settings.PLATEAUHEIGHT);
            InitializePhysics(world);
        }

        public void SetEvent(Texture2D EveTexture, EventType EVE, World world)
        {
            switch (EVE)
            {
                case EventType.NPC:
                    thisEvent = new Event();
                    break;

                case EventType.PICKUP:
                    thisEvent = new Event();
                    break;
            }

        }
        public void Update()
        {
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 ScreenOffset)
        {
            spriteBatch.Draw(Textures[0], new Rectangle((int)(Bounds.X - ScreenOffset.X), (int)(Bounds.Y - ScreenOffset.Y), Bounds.Width, Bounds.Height), Color.White);
        }
    }
}
