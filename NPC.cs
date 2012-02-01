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
    enum CharacterID
    {
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGTH,
        NINE,
        TEN
    }

    class NPC : InteractiveItem
    {
        private FixedAngleJoint AngJoint;
        public Event npcEvent;

        


        public List<Body> Bodies { get; set; }
        public Vector2 GetPosition()
        {
            return new Vector2(ConvertUnits.ToDisplayUnits(Position.X), ConvertUnits.ToDisplayUnits(Position.Y));
        }
        int DistanceFromStart;
        //public void Initialize();

        public void Initialize(Texture2D Texture, CharacterID npcType,  Vector2 Position)
        {
            npcEvent = new Event();
            npcEvent.InitializeNPC(npcType);
            base.Initialize(Texture, new Vector2(Position.X, Position.Y-70));
        }
        public override void Draw(SpriteBatch batch, Vector2 ScreenOffset)
        {
            batch.Draw(Textures[0], Position-ScreenOffset, Color.White);
        }

        public void Update()
        {

        }
    }
}
