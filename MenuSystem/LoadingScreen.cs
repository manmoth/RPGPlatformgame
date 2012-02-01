using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    class LoadingScreen : Screen
    {
        ContentManager Content;
        Texture2D Background;
        Texture2D Text;
        SpriteFont Font;
        int floater = 0;
        public LoadingScreen()
        {

        }
        public override void Initialize(IServiceProvider services)
        {
            Content = new ContentManager(services);
            Content.RootDirectory = "Content";
        }
        public override void LoadContent()
        {
            Font = Content.Load<SpriteFont>("font");
            Background = Content.Load<Texture2D>("Textures/loading");
        }
        public override void UnloadContent() 
        {

        }
        public override void Update(GameTime gameTime)
        {
            floater++;
            floater %=(int)(100*2*(float)Math.PI);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT), Background.Bounds, Color.White);
            spriteBatch.End();
        }
    }
}
