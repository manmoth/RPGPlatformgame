using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    class TitleScreen : MenuScreen
    {
        #region Fields
        public event EventHandler Event;
        public delegate void EventHandler(Screen s, MenuEventType et);
        #endregion
        #region Constructor
        public TitleScreen()
        {
        }
        #endregion
        #region Methods
        public override void LoadContent()
        {
           MenuFont = Content.Load<SpriteFont>("gameFont");
           Background = Content.Load<Texture2D>("1_bg-tree");
           Button start = new Button(new Point(Settings.SCREEN_WIDTH / 2 - 100, 100), 200, 100, "", Content.Load<Texture2D>("start_hl"), Content.Load<Texture2D>("start"));
           start.ClickEvent += new Button.ClickHandler(StartGame);
           AddButton(start);
           Button exit = new Button(new Point(Settings.SCREEN_WIDTH / 2 - 100, 300), 200, 100, "", Content.Load<Texture2D>("exit_hl"), Content.Load<Texture2D>("exit"));
           exit.ClickEvent += new Button.ClickHandler(ExitGame);
           AddButton(exit);
        }


        /// <summary>
        /// Unload content for the screen.
        /// </summary>
        public override void UnloadContent() 

        {

        }
        private void StartGame()
        {
            if (Event != null)
            {
                Event(this, MenuEventType.Start);
            }
        }
        private void ExitGame()
        {
            if (Event != null)
            {
                Event(this, MenuEventType.Exit);
            }
        }
        #endregion
    }
}
