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
    public class MenuScreen : Screen
    {
        #region Fields
        Texture2D _background;
        public Texture2D Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }
        ContentManager _content;
        public ContentManager Content
        {
            get
            {
                return _content;
            }
        }
        SpriteFont _menuFont;
        public SpriteFont MenuFont
        {
            get
            {
                return _menuFont;
            }
            set
            {
                _menuFont=value;
            }
        }
        Button _currentSelect;
        List<Button> _menuButtons;
        #endregion
        #region Constructor
        public MenuScreen()
        {
            _menuButtons = new List<Button>();
        }
        #endregion
        #region Methods
        public override void Initialize(IServiceProvider services)
        {
            _content = new ContentManager(services);
            _content.RootDirectory = "Content";

        }

        public override void LoadContent()

        {
        }

        public override void UnloadContent() 

        {

        }

        public override void Update(GameTime gameTime)
        {
            if ((ScreenManager.KeyStateAfter.IsKeyDown(Keys.Down) && ScreenManager.KeyStateBefore.IsKeyUp(Keys.Down))
                || (ScreenManager.GamePadAfter.IsButtonDown(GameControls.GMenuDown) && ScreenManager.GamePadBefore.IsButtonUp(GameControls.GMenuDown)))
            {
                int next = _menuButtons.IndexOf(_currentSelect)+1;
                if (next < _menuButtons.Count)
                    _currentSelect = _menuButtons.ElementAt<Button>(next);
                else _currentSelect = _menuButtons.ElementAt<Button>(0);
            }
            else if ((ScreenManager.KeyStateAfter.IsKeyDown(Keys.Up) && ScreenManager.KeyStateBefore.IsKeyUp(Keys.Up)) 
                || (ScreenManager.GamePadAfter.IsButtonDown(GameControls.GMenuUp) && ScreenManager.GamePadBefore.IsButtonUp(GameControls.GMenuUp)))
            {
                int next = _menuButtons.IndexOf(_currentSelect) - 1;
                if (next >= 0)
                    _currentSelect = _menuButtons.ElementAt<Button>(next);
                else _currentSelect = _menuButtons.ElementAt<Button>(_menuButtons.Count-1);
            }
            else if (ScreenManager.KeyStateAfter.IsKeyDown(Keys.Enter) && ScreenManager.KeyStateBefore.IsKeyUp(Keys.Enter)
                 || (ScreenManager.GamePadAfter.IsButtonDown(GameControls.GAction) && ScreenManager.GamePadBefore.IsButtonUp(GameControls.GAction)))
            {
                
                _currentSelect.Click();
            }

        }

        public override void Draw(SpriteBatch spriteBatch)

        {
            spriteBatch.Begin();
            //spriteBatch.Draw(background, new Rectangle(0,0,ScreenManager.Graphics.PreferredBackBufferWidth, ScreenManager.Graphics.PreferredBackBufferHeight),
            //   background.Bounds, Color.White);
            spriteBatch.End();

            foreach (Button b in _menuButtons)
            {
                bool selected = false;
                if (b == _currentSelect) selected = true;
                b.Draw(spriteBatch, _menuFont, selected);
            }
        }
        public void AddButton(Button b)
        {
            if (_currentSelect == null) _currentSelect = b;
            _menuButtons.Add(b);
        }
        #endregion
    }
}
