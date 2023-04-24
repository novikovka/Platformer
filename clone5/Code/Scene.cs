using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
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
        static public SpriteBatch SpriteBatch { get; set; }
        static public Tile[] tiles1;
        static public int Score = 0;

        static public Texture2D Exit;


        static public Gem[] gems;
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

        public static void DeleteGem()
        {
            for(int i =0; i < gems.Length; i++)
            {
                if (player.Pos.X == gems[i].PositionX && (gems[i].PositionY - player.Pos.Y) <= 30 && (gems[i].PositionY - player.Pos.Y) >= 20) 
                {
                    gems[i].Delete();
                    Score++;
                }
            }           
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

            DeleteGem();
            
            if(((player.Pos.X > 700) && (player.Pos.Y < 70) && Score == 15) || button.IsKeyDown(Keys.F)) //вот тут надо будет убрать переход по клавише 
            {
                Game1.Stat = Stat.Scene2;
            }
            CreateTiles1();
            
            
           

        }

        static public void Init1(SpriteBatch SpriteBatch, int Width, int Height) //в этом методе должны создаваться тайлы
        {
            Scene.Width = Width;
            Scene.Height = Height;
            Scene.SpriteBatch = SpriteBatch;

            CreateTiles1();
            CreateGems();
            player = new Player(new Vector2(0, 370), 5); //начальная позиция и скорость



            //player = new Player(new Vector2(0, 370),5); //начальная позиция и скорость
        }

        public static void CreateGems()
        {
            gems = new Gem[15];
            gems[0] = new Gem(260, 400);
            gems[1] = new Gem(310, 400);
            gems[2] = new Gem(360, 400);
          
            gems[3] = new Gem(710, 400);
            gems[4] = new Gem(760, 400);

            gems[5] = new Gem(210, 224);
            gems[6] = new Gem(260, 224);

            gems[7] = new Gem(560, 312);
            gems[8] = new Gem(610, 312);

            gems[9] = new Gem(60, 92);
            gems[10] = new Gem(110, 92);
            gems[11] = new Gem(160, 92);

            gems[12] = new Gem(410, 48);
            gems[13] = new Gem(460, 48);

            gems[14] = new Gem(610, 92);
        }

        public static void CreateTiles1()
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

            tiles1 = boxs1.ToArray();

        }
        
        public static void Draw()
        {
            foreach (Tile tile in tiles1)
            {
                tile.Draw();
            }
            foreach (Gem gem in gems)
            {
                gem.Draw();
            }
            player.Draw();
            SpriteBatch.Draw(Exit, new Rectangle(700, 90, 50, 42), Color.White);
        }
              
    }   
}
