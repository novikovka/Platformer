using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clone5
{
    class Gem
    {
        public const int Width = 30;
        public const int Height = 30;
        public int PositionX;
        public int PositionY;
        public static Texture2D Texture2D;
        public static int Sdvig = 2;


        public Gem(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public void Delete()
        {
            PositionY += 2000;
        }
        //!!!
        public void ToRight()
        {
            for(int i = 0; i < Sdvig; i++)
            {
                PositionX += 1;
            }
            
        }

        public void ToLeft()
        {
            for (int i = 0; i < Sdvig; i++)
            {
                PositionX -= 1;
            }

        }
        //!!!



        /*
        public void RunToRight()
        {
            for(int i = 0; i < Sdvig; i++)

                PositionX += 3;
        }
        
        public void RunToLeft()
        {
            for (int i = 0; i < Sdvig; i++)

                PositionX -= 3;
        }
        */


        //!!!

        public void Draw()
        {
            Scene.SpriteBatch.Draw(Texture2D, new Rectangle(PositionX, PositionY, Width, Height), Color.White);
        }
    }
}
