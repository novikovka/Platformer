using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clone5
{
    class Portal
    {
        public const int Width = 40;
        public const int Height = 40;
        public int PositionX;
        public int PositionY;
        public static Texture2D Texture2D;

        public Portal(int positionX, int positionY)
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
