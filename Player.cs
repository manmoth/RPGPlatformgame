using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Collision.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Common;

namespace WindowsGame1
{
    class Player : InteractiveItem, PhysicalObject, Animated
    {
        private FixedAngleJoint AngJoint;
        private bool Running;
        private bool Jumping;
        private SpriteEffects Forward;
        public Vector2 GetPosition()
        {
            return new Vector2(ConvertUnits.ToDisplayUnits(Position.X), ConvertUnits.ToDisplayUnits(Position.Y));
        }
        public int TotalFrames {get; set;}
        public int AnimationFrame {get; set;}
        public int AnimationSteps {get; set;}
        public void AnimationStep()
        {
            AnimationFrame++;
            AnimationFrame %= TotalFrames;
            if (AnimationSteps >= Settings.PLAYERFRAMESTOTAL)
            {
                AnimationSteps = 0;
                AnimationFrame = 0;
                
            }
            else if (AnimationFrame / (float)TotalFrames > AnimationSteps / (float)Settings.PLAYERFRAMESTOTAL)
            {
                AnimationSteps++;
            }

        }
        public void AnimationReset()
        {
            AnimationSteps = 0;
            AnimationFrame = 0;
        }
        public List<Body> Bodies{ get; set;}

        public override void Initialize(Texture2D Texture, Vector2 Position){

             this.Position = new Vector2(Position.X, Position.Y); 
             Bounds = new Rectangle((int)Position.X, (int)Position.Y, Settings.PLAYERWIDTH, Settings.PLAYERHEIGHT);
             Textures = new List<Texture2D>();
             Textures.Add(Texture);
             TotalFrames = Settings.ANIMATIONSTEPS;
             AnimationSteps = 0;
        }
        public void InitializePhysics(World world)
        {
            Body body = new Body(world);
            Vertices verts = new Vertices();

            verts.Add(new Vector2(ConvertUnits.ToSimUnits(Bounds.X), ConvertUnits.ToSimUnits(Bounds.Y + Bounds.Height / 4f)));
            verts.Add(new Vector2(ConvertUnits.ToSimUnits(Bounds.X + Bounds.Width/2f), ConvertUnits.ToSimUnits(Bounds.Y+Bounds.Height/4f)));
            verts.Add(new Vector2(ConvertUnits.ToSimUnits(Bounds.X + Bounds.Width/2f), ConvertUnits.ToSimUnits(Bounds.Y + Bounds.Height- Bounds.Height / 4f)));
            verts.Add(new Vector2(ConvertUnits.ToSimUnits(Bounds.X), ConvertUnits.ToSimUnits(Bounds.Y + Bounds.Height- Bounds.Height/4f)));

            body.CreateFixture(new PolygonShape(verts, 1));

            Bodies = new List<Body>();
            body.BodyType = BodyType.Dynamic;
            body.Mass = Settings.PLAYERMASS;
            body.Friction = 0.3f;
            Bodies = new List<Body>();
            Bodies.Add(body);

            AngJoint = JointFactory.CreateFixedAngleJoint(world, body);
            AngJoint.CollideConnected = false;
            AngJoint.Softness = 0f;
            AngJoint.TargetAngle = 0f;
        }
        public override void Draw(SpriteBatch batch, Vector2 ScreenOffset)
        {
            Console.WriteLine(ScreenOffset);
            Console.WriteLine(Bounds);
            batch.Draw(Textures[0], new Rectangle((int)(Bounds.X-ScreenOffset.X-Bounds.Width / 2),
                (int)(Bounds.Y - ScreenOffset.Y-Bounds.Height/2),
                (int)(Settings.PLAYERWIDTH), (int)(Settings.PLAYERHEIGHT)), 
                new Rectangle(Settings.PLAYERWIDTH * AnimationSteps, 0,Settings.PLAYERWIDTH, Settings.PLAYERHEIGHT), 
                    Color.White, 0, Vector2.Zero, Forward, 0);
        }
        public void Update(KeyboardState kbAfter, KeyboardState kbBefore, GameTime gameTime)
        {
            Bounds = new Rectangle((int)(ConvertUnits.ToDisplayUnits(Bodies[0].WorldCenter.X)), 
                (int)(ConvertUnits.ToDisplayUnits(Bodies[0].WorldCenter.Y)), 
                Settings.PLAYERWIDTH, Settings.PLAYERHEIGHT);
            Position = new Vector2(Bounds.X, Bounds.Y);
            PlayerMovement(kbAfter, kbBefore, gameTime);
            if (Running)
                AnimationStep();
            else
                AnimationReset();

        }
        private void PlayerMovement(KeyboardState kbAfter, KeyboardState kbBefore, GameTime gameTime)
        {

            if (Position.Y < 0)
                Bodies[0].Position = new Vector2(0, Bodies[0].Position.Y);
            if (Position.X < 0)
                Bodies[0].Position = new Vector2(Bodies[0].Position.X, 0);


            Running = false;
            if (Bodies[0].LinearVelocity.X > Settings.MAXVELOCITY) Bodies[0].LinearVelocity = new Vector2(Settings.MAXVELOCITY, Bodies[0].LinearVelocity.Y);
            else if (Bodies[0].LinearVelocity.X < -Settings.MAXVELOCITY) Bodies[0].LinearVelocity = new Vector2(-Settings.MAXVELOCITY, Bodies[0].LinearVelocity.Y);
        
            if (Bodies[0].LinearVelocity.Y > Settings.MAXVELOCITY) Bodies[0].LinearVelocity = new Vector2(Bodies[0].LinearVelocity.X,Settings.MAXVELOCITY);
            else if (Bodies[0].LinearVelocity.Y < -Settings.MAXVELOCITY) Bodies[0].LinearVelocity = new Vector2(Bodies[0].LinearVelocity.X, -Settings.MAXVELOCITY);
            
            if (kbAfter.IsKeyDown(Keys.Left))
            {
                Running = true;
                Forward = SpriteEffects.FlipHorizontally;
                Bodies[0].ApplyLinearImpulse(new Vector2(ConvertUnits.ToSimUnits(-Settings.PLAYERMOVE), 0));
            }
            else if (kbAfter.IsKeyDown(Keys.Right))
            {
                Running = true;
                Forward = SpriteEffects.None;
                Bodies[0].ApplyLinearImpulse(new Vector2(ConvertUnits.ToSimUnits(Settings.PLAYERMOVE), 0));
            }
            if (kbBefore.IsKeyDown(Keys.Up) && kbAfter.IsKeyUp(Keys.Up))
            {
                Bodies[0].ApplyLinearImpulse(new Vector2(0, ConvertUnits.ToSimUnits(-Settings.PLAYERJUMP)));
            }
            if (kbBefore.IsKeyDown(Keys.Down) && kbAfter.IsKeyUp(Keys.Down))
            {
                Bodies[0].ApplyLinearImpulse(new Vector2(0, ConvertUnits.ToSimUnits(Settings.PLAYERJUMP)));
            }
        }
    }
}
