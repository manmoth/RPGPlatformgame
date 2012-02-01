using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    public enum MenuEventType
    {
        Start,Pause,Continue,MainMenu,Load,LoadDone, Exit
    }
    public class ScreenManager : Microsoft.Xna.Framework.Game
    {
        #region Fields
        //GAME
        List<Screen> screens;
        List<Screen> toBeRemoved;
        List<Screen> activeScreens;
        Screen nextScreen;
        WindowsGame1.Game1 gameScreen;
        TitleScreen titleScreen;
        PauseScreen pauseScreen;
        LoadingScreen loadingScreen;

        Thread loadingThread; 
        //XNA 
        ContentManager content;
        static GraphicsDeviceManager graphics;
        static InputManager input; 

        SpriteBatch spriteBatch;
        public static KeyboardState KeyStateBefore
        {
            get { return input.KeyStateBefore; }
        }
        public static KeyboardState KeyStateAfter
        {
            get { return input.KeyStateAfter; }
        }
        public static GamePadState GamePadBefore
        {
            get { return input.GamePadBefore; }
        }
        public static GamePadState GamePadAfter
        {
            get { return input.GamePadAfter; }
        }

        public static GraphicsDeviceManager Graphics
        {
            get { return graphics; }
        }
        #endregion
        #region Constructor
        public ScreenManager()
        {
            graphics = new GraphicsDeviceManager(this);
            content = Content;
            Content.RootDirectory = "Content";
        }
        #endregion
        #region Methods
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            input = new InputManager();
            screens = new List<Screen>();
            toBeRemoved = new List<Screen>();
            activeScreens = new List<Screen>();
            titleScreen = new TitleScreen();
            titleScreen.Event += new TitleScreen.EventHandler(MenuEventHandler);
            //activeScreens.Add(gameScreen);
            activeScreens.Add(titleScreen);
            screens.Add(titleScreen);

           
            //graphics.ToggleFullScreen();
    #if XBOX
                            graphics.PreferredBackBufferWidth = 1280;
                            graphics.PreferredBackBufferHeight = 720;
    #else
            graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;
            graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;

    #endif 
                graphics.ApplyChanges();
            foreach (Screen screen in screens) screen.Initialize(Services);
            base.Initialize();
        }

        /// <summary>
        /// Load your graphics content.
        /// </summary>
        protected override void LoadContent()
        {
            // Load content belonging to the screen manager.
            ContentManager content = Content;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Tell each of the screens to load their content.
            foreach (Screen screen in screens)
            {
                screen.LoadContent();
            }
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (gameScreen != null)
            {
                if (loadingThread == null)
                {
                }
                else if (loadingThread!=null)
                {
                    nextScreen = gameScreen;
                    toBeRemoved.Add(loadingScreen);
                }
            }
            input.KeyStateAfter = Keyboard.GetState();
            input.GamePadAfter = GamePad.GetState(input.MainIndex);

            if (nextScreen != null)
            {
                activeScreens.Add(nextScreen);
                nextScreen = null;
            }
            foreach (Screen screen in toBeRemoved)
            {
                if (activeScreens.Contains(screen)) activeScreens.Remove(screen);
                
            }
            toBeRemoved.Clear();
            foreach (Screen screen in activeScreens) screen.Update(gameTime);
            base.Update(gameTime);
            input.KeyStateBefore = Keyboard.GetState();
            input.GamePadBefore = GamePad.GetState(input.MainIndex);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            foreach (Screen screen in activeScreens) screen.Draw(spriteBatch);
            base.Draw(gameTime);
        }
        private void MenuEventHandler(Screen s,MenuEventType et)
        {
            if (s is MenuScreen)
            {
                if (et == MenuEventType.Exit) Exit();
                else if (et == MenuEventType.Continue)
                {
                    nextScreen = gameScreen;
                    toBeRemoved.Add(s);
                }
                else if (et == MenuEventType.MainMenu)
                {
                    nextScreen = titleScreen;
                    toBeRemoved.Add(s);
                }
                else if (et == MenuEventType.Start)
                {
                    gameScreen = new WindowsGame1.Game1();
                    gameScreen.Initialize(Services);
                    gameScreen.LoadContent();
                    gameScreen.Event += new Game1.EventHandler(MenuEventHandler);
                    nextScreen = gameScreen;
                    toBeRemoved.Add(s);
                }
                Console.Out.WriteLine("Title!" + et);
            }
            else if (s == gameScreen)
            {
                if(et == MenuEventType.Load){
                        loadingScreen = new LoadingScreen();
                        loadingScreen.Initialize(Services);
                        loadingScreen.LoadContent();
                        nextScreen = loadingScreen;
                        toBeRemoved.Add(s);
                }
                if (et == MenuEventType.Pause)
                {
                    pauseScreen = new PauseScreen();
                    pauseScreen.Initialize(Services);
                    pauseScreen.LoadContent();
                    pauseScreen.Event += new PauseScreen.EventHandler(MenuEventHandler);
                    nextScreen = pauseScreen;
                    toBeRemoved.Add(s);
                }
                else if (et == MenuEventType.Exit)
                {
                    gameScreen = null;
                    nextScreen = titleScreen;
                    toBeRemoved.Add(s);
                }
            }
        }
        #endregion
    }
}
