using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class Button
    {
        #region Fields
        Texture2D _textureNotSelect;
        Texture2D _textureSelect;
        Rectangle _buttonRect;
        String _buttonText;
        int _textOffset;
        public event ClickHandler ClickEvent;
        public delegate void ClickHandler();
        #endregion
        #region Constructor
        public Button(Point position, int width, int height, String buttonText, Texture2D select, Texture2D notSelect)
        {
            _textureNotSelect = notSelect;
            _textureSelect = select;
            _buttonRect = new Rectangle(position.X,position.Y,width,height);
            _buttonText = buttonText;
            _textOffset = 20;
        }
        #endregion
        #region Methods
        public void Draw(SpriteBatch spriteBatch, SpriteFont font, bool selected)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_textureNotSelect, _buttonRect, _textureNotSelect.Bounds, Color.White);
            if (selected) spriteBatch.Draw(_textureSelect, _buttonRect, _textureSelect.Bounds, Color.White);
            else spriteBatch.DrawString(font, _buttonText, new Vector2(_buttonRect.X + _textOffset, _buttonRect.Y + _textOffset), Color.Green);
            spriteBatch.End();
        }
        public void Click()
        {
            if (ClickEvent != null)
            {
                ClickEvent();
            }

        }
        #endregion
    }
}
