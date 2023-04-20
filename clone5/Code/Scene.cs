using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace clone5
{
    class Scene
    {
        public static int Width, Height; //размеры экрана
        static public SpriteBatch SpriteBatch { get; set; }
        static public Tile[] tiles;
        static public Player player { get; set; }
        


        public static bool Collision()
        {
            if((player.Pos.X > 470) && (player.Pos.X < 630) && (player.Pos.Y > 282) && (player.Pos.Y < 290))
            {
                return true;
            }
            if ((player.Pos.X > 180) && (player.Pos.X < 380) && (player.Pos.Y > 194) && (player.Pos.Y < 200))
            {
                return true;
            }
            if ((player.Pos.X > 30) && (player.Pos.X < 230) && (player.Pos.Y > 62) && (player.Pos.Y < 70))
            {
                return true;
            }
            if ((player.Pos.X > 330) && (player.Pos.X < 480) && (player.Pos.Y > 18) && (player.Pos.Y < 22))
            {
                return true;
            }
            if ((player.Pos.X > 570) && (player.Pos.X < 780) && (player.Pos.Y > 62) && (player.Pos.Y < 70))
            {
                return true;
            }

            return false;

        }
        public static void Update(GameTime gameTime)
        {
            

            KeyboardState button = Keyboard.GetState();
            
            if ((button.IsKeyDown(Keys.W) && (player.Pos.Y == 370)) || (button.IsKeyDown(Keys.W) && Collision()))
            {
                player.Up();                
            }           
            if (button.IsKeyDown(Keys.A))
            {
                player.Left();
            }
            if (button.IsKeyDown(Keys.D))
            {               
               player.Right();
            }
            
            if (player.Pos.Y < 370 && !(Collision()))
            {
                player.Fall();
            }
                                
            if (player.Pos.Y > 370) //чтобы персонаж не падал сквозь нижние плитки
            {
                player.Pos.Y -= 5;
            }                        
        }

        static public void Init(SpriteBatch SpriteBatch, int Width, int Height) //в этом методе должны создаваться тайлы
        {
            Scene.Width = Width;
            Scene.Height = Height;
            Scene.SpriteBatch = SpriteBatch;
            
            CreateTiles();

            player = new Player(new Vector2(0, 370),5); //начальная позиция и скорость
        } 

        public static void CreateTiles()
        {
            var boxs = new List<Tile>();
            var map = new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,1,0,0,0,1},
                {0,0,0,0,0,0,1,0,0,0,1},
                {0,0,0,0,0,0,1,0,0,0,1},
                {0,0,1,0,0,0,1,0,0,0,1},
                {0,0,1,0,0,0,0,0,0,0,1},
                {0,0,1,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,1,0,1},
                {0,0,0,0,0,0,0,0,1,0,1},
                {0,0,0,1,0,0,0,0,1,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,1}
            };

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j =0; j < map.GetLength(1); j++)
                {
                    int a = map[i,j];
                    if(a == 1)
                    {
                        Tile tile = new Tile(i * 50, j * 44);
                        boxs.Add(tile);
                    }
                }
            }
            tiles = boxs.ToArray(); 
        }
       
        public static void Draw()
        {
            foreach(Tile tile in tiles)
            {
                tile.Draw();
            }
            player.Draw();
        }
    }

   
}
