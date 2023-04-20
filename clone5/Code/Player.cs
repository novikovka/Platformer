using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clone5
{
    class Player
    {
        public Vector2 Pos; // позиция
        public int Speed;
        

        public Player(Vector2 pos, int speed)
        {
            Pos = pos;
            Speed = speed;
        }

        Color color = Color.White;
       
        public static Texture2D Texture2D { get; set; }

        public void Up()
        {
            Pos.Y -= 200;             
        }
        public void Down()
        {
            Pos.Y += Speed;
        }
        public void Left()
        {
            Pos.X -= Speed;
        }
        public void Right()
        {
            Pos.X += Speed;     
        }
        public void Fall()
        {
            //Pos.Y ++;
            Pos.Y += Speed;
        }

        /*
       public void Jump()
       {
           for(int v = -20; v< 20; v = v+5)
           {
               Speed = v;
               Pos.Y += Speed;
           }

       }


       /*

       public void Velocity(int speedJump)
       {
           speedJump += 5;
           Pos.Y += speedJump;        
       }
        */



        public void Draw()
        {
            Scene.SpriteBatch.Draw(Texture2D, Pos, color);
        }


    }
}
