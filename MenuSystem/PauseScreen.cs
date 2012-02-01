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
    class PauseScreen : MenuScreen
    {
        #region Fields
        public event EventHandler Event;
        public delegate void EventHandler(Screen s, MenuEventType et);
        #endregion
        #region Constructor
        public PauseScreen()
        {
            
        }
        #endregion
        #region Methods
        public override void LoadContent()
        {
           MenuFont = Content.Load<SpriteFont>("gameFont");
           Background = Content.Load<Texture2D>("1_bg-tree");
           Button contGame = new Button(new Point(Settings.SCREEN_WIDTH / 2 - 100, 100), 200, 100, "", Content.Load<Texture2D>("continue_hl"), Content.Load<Texture2D>("continue"));
           contGame.ClickEvent += new Button.ClickHandler(ContinueGame);
           AddButton(contGame);
           Button exit = new Button(new Point(Settings.SCREEN_WIDTH / 2 - 100, 300), 200, 100, "", Content.Load<Texture2D>("exit_hl"), Content.Load<Texture2D>("exit"));
           exit.ClickEvent += new Button.ClickHandler(ExitGame);
           AddButton(exit);
        }
        public override void UnloadContent() 

        {

        }
        private void ContinueGame()
        {
            if (Event != null)
            {
                Event(this, MenuEventType.Continue);
            }
        }
        private void ExitGame()
        {
            if (Event != null)
            {
                Event(this, MenuEventType.MainMenu);
            }
        }
        #endregion
    }
}
