using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace clone5
{
    class Scene
    {
        public static int Width, Height; //размеры экрана
        public static SpriteBatch SpriteBatch;
        public static Tile[] Tiles;
        public static int Score = 0;
        public static Exit1 Exit;
        public static Gem[] Gems;
        public static Player Player { get; set; }
        public static Text Text;
        
  
        public static bool Collision()
        {
            if((Player.Pos.X > 470) && (Player.Pos.X < 630) && (Player.Pos.Y > 282) && (Player.Pos.Y < 290))
            {
                return true;
            }
            if ((Player.Pos.X > 180) && (Player.Pos.X < 380) && (Player.Pos.Y > 194) && (Player.Pos.Y < 200))
            {
                return true;
            }
            if ((Player.Pos.X > 30) && (Player.Pos.X < 230) && (Player.Pos.Y > 62) && (Player.Pos.Y < 70))
            {
                return true;
            }
            if ((Player.Pos.X > 330) && (Player.Pos.X < 480) && (Player.Pos.Y > 18) && (Player.Pos.Y < 22))
            {
                return true;
            }
            if ((Player.Pos.X > 570) && (Player.Pos.X < 780) && (Player.Pos.Y > 62) && (Player.Pos.Y < 70))
            {
                return true;
            }
            return false;
        }

        public static void DeleteGem()
        {
            for(int i =0; i < Gems.Length; i++)
            {
                if (Player.Pos.X == Gems[i].PositionX && (Gems[i].PositionY - Player.Pos.Y) <= 30 && (Gems[i].PositionY - Player.Pos.Y) >= 20) 
                {
                    Gems[i].Delete();
                    Score++;
                }
            }           
        }
       
        public static void Update(GameTime gameTime)
        {           
            KeyboardState button = Keyboard.GetState();
            
            if ((button.IsKeyDown(Keys.W) && (Player.Pos.Y == 370)) || (button.IsKeyDown(Keys.W) && Collision()))
            {
                Player.Up();                
            }           
            if (button.IsKeyDown(Keys.A))
            {
                Player.Left();
                Player.Direction = 0;
            }
            if (button.IsKeyDown(Keys.D))
            {               
               Player.Right();
                Player.Direction = 1;
              
            }          
            if (Player.Pos.Y < 370 && !(Collision()))
            {
                Player.Fall();
            }           
            DeleteGem();
            
            if(((Player.Pos.X > 700) && (Player.Pos.Y < 70) && Score == 15) || button.IsKeyDown(Keys.F)) //вот тут надо будет убрать переход по клавише 
            {
                Game1.Stat = Stat.Scene2;
            }
            
            WindowOut();           
        }

        public static void WindowOut() //предотвращает выход игрока за рамки окна
        {
            if (Player.Pos.Y > 370) //снизу
            {
                Player.Pos.Y -= 5;
            }

            if (Player.Pos.X > 760) // справа
            {
                Player.Pos.X -= 5;
            }

            if (Player.Pos.X < 0) //слева
            {
                Player.Pos.X += 5;
            }
        }

        static public void Init1(SpriteBatch SpriteBatch, int Width, int Height) 
        {
            Scene.Width = Width;
            Scene.Height = Height;
            Scene.SpriteBatch = SpriteBatch;

            CreateTiles();
            CreateGems();
            Player = new Player(new Vector2(0, 370), 5); 
            Text = new Text();
            Exit = new Exit1(700, 90);
        }

        public static void CreateGems()
        {
            Gems = new Gem[15];
            Gems[0] = new Gem(260, 400);
            Gems[1] = new Gem(310, 400);
            Gems[2] = new Gem(360, 400);
          
            Gems[3] = new Gem(710, 400);
            Gems[4] = new Gem(760, 400);

            Gems[5] = new Gem(210, 224);
            Gems[6] = new Gem(260, 224);

            Gems[7] = new Gem(560, 312);
            Gems[8] = new Gem(610, 312);

            Gems[9] = new Gem(60, 92);
            Gems[10] = new Gem(110, 92);
            Gems[11] = new Gem(160, 92);

            Gems[12] = new Gem(410, 48);
            Gems[13] = new Gem(460, 48);

            Gems[14] = new Gem(610, 92);
        }

        public static void CreateTiles()
        {
            var boxs1 = new List<Tile>();
            var level1 = new int[,]
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

            for (int i = 0; i < level1.GetLength(0); i++)
            {
                for (int j = 0; j < level1.GetLength(1); j++)
                {
                    int a = level1[i, j];
                    if (a == 1)
                    {
                        Tile tile = new Tile(i * 50, j * 44);
                        boxs1.Add(tile);
                    }
                }
            }

            Tiles = boxs1.ToArray();
        }
        
        public static void Draw()
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw();
            }
            foreach (Gem gem in Gems)
            {
                gem.Draw();
            }

            Player.Draw();          
            Exit.Draw();
            Text.Draw(Score, Gems.Length);          
        }             
    }   
}
