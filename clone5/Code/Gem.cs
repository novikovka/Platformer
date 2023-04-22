using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;

namespace clone5
{
    class Gem
    {
        public const int Width = 30;
        public const int Height = 30;
        public Vector2 Pos;

        public Gem(Vector2 pos)
        {
            Pos = pos;
        }

        public static Texture2D Texture2D;


        
        
        public void Delete()
        {
            Pos.Y = 2000;
        }
        

        public void Draw()
        {            
            Scene.SpriteBatch.Draw(Texture2D, Pos, Color.White);
        }
    }
}
