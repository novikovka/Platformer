using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clone5
{
    class Exit1
    {
        public const int Width = 50;
        public const int Height = 42;
        public int PositionX;
        public int PositionY;
        public static Texture2D Texture2D;

        public Exit1(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public void Draw()
        {
            Scene.SpriteBatch.Draw(Texture2D, new Rectangle(PositionX, PositionY, Width, Height), Color.White);
        }
    }
}
