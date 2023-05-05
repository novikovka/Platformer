using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace clone5
{
    class SplashScreen
    {
        public static Texture2D Texture2D { get; set; }        
        public static SpriteFont GameName { get; set; }
        public static SpriteFont Space { get; set; }
        static public void Draw()
        {
            Scene.SpriteBatch.Draw(Texture2D, new Rectangle(0, 0, 800, 500), Color.White);
            Scene.SpriteBatch.DrawString(GameName, "gem collector", new Vector2(130, 150), Color.Black);
            Scene.SpriteBatch.DrawString(Space, "click \"space\" to start the game", new Vector2(200,0), Color.Black);
        }

        static public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                Game1.Stat = Stat.Scene1;
            }
        }
    }
}
