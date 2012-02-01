using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using FarseerPhysics.Dynamics;
using FarseerPhysics;
using FarseerPhysics.DebugViews;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Screen
    {

        SpriteFont font;
        ContentManager Content;
        public event EventHandler Event;
        public delegate void EventHandler(Screen s, MenuEventType et);

        Vector2 ScreenOffset;
        Texture2D[] Background;
        Texture2D[] Foreground;
        DebugViewXNA DebugView;

        SpriteBatch spriteBatch;
        KeyboardState kbAfter;
        KeyboardState kbBefore;
        Map map1;
        Player player;
        World physicsWorld;

        public Game1()
        {
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public override void Initialize(IServiceProvider services)
        {
            Content = new ContentManager(services);
            Content.RootDirectory = "Content";
            
            ScreenOffset = Vector2.Zero;

            ScreenManager.Graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;
            ScreenManager.Graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;

            map1 = new Map();
            player = new Player();

            physicsWorld = new World(new Vector2(0, ConvertUnits.ToSimUnits(600f)));

            //AudioManager.Instance.Initialize(ScreenManager);


            DebugView = new DebugViewXNA(physicsWorld);

            //DebugView.AppendFlags(FarseerPhysics.DebugViewFlags.PolygonPoints);
            //DebugView.AppendFlags(FarseerPhysics.DebugViewFlags.DebugPanel);
            //DebugView.AppendFlags(FarseerPhysics.DebugViewFlags.ContactPoints);
            //DebugView.AppendFlags(FarseerPhysics.DebugViewFlags.AABB);
            DebugView.DefaultShapeColor = Color.Green;
            DebugView.StaticShapeColor = Color.Blue;
            DebugView.KinematicShapeColor = Color.Brown;
            DebugView.SleepingShapeColor = Color.White;
            DebugView.InactiveShapeColor = Color.Yellow;
            DebugView.LoadContent(ScreenManager.Graphics.GraphicsDevice, Content);
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(ScreenManager.Graphics.GraphicsDevice);

            player.Initialize(Content.Load<Texture2D>("mchar_walk"), new Vector2(100,3000));
            player.InitializePhysics(physicsWorld);

            Background = new Texture2D[24];
            Foreground = new Texture2D[5];

            for (int i = 1; i <= Background.Length; i++)
            {
                Background[i-1] = Content.Load<Texture2D>(i+"_bg-tree");
                
            }
            for (int i = 1; i <= Foreground.Length; i++)
            {
                Foreground[i-1] = Content.Load<Texture2D>(i + "_bg-pillars");
            }
            map1.LoadContent(Content.Load<Texture2D>("StepCorner"), Content.Load<Texture2D>("StepHorizontal"), Background, Foreground);
            map1.Initialize();

            map1.InitializePhysics(physicsWorld);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            kbBefore = Keyboard.GetState();

            if (ScreenManager.KeyStateAfter.IsKeyDown(GameControls.KMenu) &&
            ScreenManager.KeyStateBefore.IsKeyUp(GameControls.KMenu))
            {
                if (Event != null)
                {
                    Event(this, MenuEventType.Pause);
                }
            }
            else if (ScreenManager.GamePadAfter.IsConnected &&
                    (ScreenManager.GamePadAfter.IsButtonDown(GameControls.GMenu) &&
                        ScreenManager.GamePadBefore.IsButtonUp(GameControls.GMenu)))
            {
                if (Event != null)
                {
                    Event(this, MenuEventType.Pause);
                }
            }


            //if (ConvertUnits.ToDisplayUnits(player.Bodies[0].Position.X)-ScreenOffset.X > Settings.SCREEN_WIDTH / 2)
            //{
                ScreenOffset.X = ConvertUnits.ToDisplayUnits(player.Bodies[0].WorldCenter.X) - Settings.SCREEN_WIDTH / 2;
            //}
            //if (ConvertUnits.ToDisplayUnits(player.Bodies[0].Position.Y) - ScreenOffset.Y > Settings.SCREEN_HEIGHT / 2)
            //{
                ScreenOffset.Y = ConvertUnits.ToDisplayUnits(player.Bodies[0].WorldCenter.Y) - Settings.SCREEN_HEIGHT*( 3/4f);
            //}

            if (ScreenOffset.X < 0)
            {
                if (ScreenOffset.Y < 0) ScreenOffset = Vector2.Zero;
                else ScreenOffset = new Vector2(0, ScreenOffset.Y);
            }
            else if (ScreenOffset.Y < 0) ScreenOffset = new Vector2(ScreenOffset.X, 0);
            map1.Update(player.Bodies[0].Position);
            player.Update(kbAfter, kbBefore, gameTime);
            
            kbAfter = Keyboard.GetState();

            physicsWorld.Step((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            map1.Draw(spriteBatch, ScreenOffset, false);
            player.Draw(spriteBatch, ScreenOffset);
            map1.Draw(spriteBatch, ScreenOffset, true);

            spriteBatch.End();

            if (kbAfter.IsKeyDown(Keys.Space))
            {
                Vector2 physicsOffset = ScreenOffset + new Vector2(0, 0);

                Matrix view = Matrix.CreateTranslation(-ConvertUnits.ToSimUnits(ScreenOffset.X + Settings.SCREEN_WIDTH / 2), -ConvertUnits.ToSimUnits((ScreenOffset.Y + Settings.SCREEN_HEIGHT / 2)), 0);
                Matrix proj = Matrix.CreateOrthographicOffCenter(
                    -ConvertUnits.ToSimUnits(Settings.SCREEN_WIDTH / 2f),
                     ConvertUnits.ToSimUnits(Settings.SCREEN_WIDTH / 2f),
                     ConvertUnits.ToSimUnits(Settings.SCREEN_HEIGHT / 2f),
                    -ConvertUnits.ToSimUnits(Settings.SCREEN_HEIGHT / 2f), 0, 1);
                DebugView.RenderDebugData(ref proj, ref view);
            }

        }
    }
}
