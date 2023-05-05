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
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace clone5
{
    class Level3
    {
        static public Tile[] Tiles;
        static public Portal[] Portals;
        static public Gem[] Gems;
        static public int Score = 0;
        static public Text Text;
        static public Text timer;
        static public int time = 0;
        static public int Seconds = 0;
        public static Texture2D Finish { get; set; }
        static public Player player { get; set; }
        
        public static void Update(GameTime gameTime)
        {
            KeyboardState button = Keyboard.GetState();

            if (button.IsKeyDown(Keys.W) && (player.Pos.Y == 370) || (button.IsKeyDown(Keys.W) && Collision()))
            {
                player.Up();
            }
            if (button.IsKeyDown(Keys.A))
            {
                player.Left();
                player.Direction = 0;
            }
            if (button.IsKeyDown(Keys.D))
            {
                player.Right();
                player.Direction = 1;
            }
            if (player.Pos.Y <= 370 && !Collision())
            {
                player.Fall();
            }          
            
            WindowOut();
            DeleteGem();
            Teleportation();
            Timer();           
        }

        public static void Timer()
        {
            if (Game1.Stat == Stat.Scene3)
            {
                time++;               
            }
            if (time == 60)
            {
                Seconds++;
                time = 0;
            }
            if (Seconds < 60 && player.Pos.X > 280 && player.Pos.X < 360 && player.Pos.Y < 19 && Score == 17)  
            {
                Game1.Stat = Stat.YouWinner;
            }
            else if (Seconds >= 60)
            {
                Game1.Stat = Stat.GameOver;
            }
        }
        
        public static void WindowOut() //предотвращает выход игрока за рамки окна
        {
            if (player.Pos.Y > 370) //снизу
            {
                player.Pos.Y -= 5;
            }

            if (player.Pos.X > 760) // справа
            {
                player.Pos.X -= 5;
            }

            if (player.Pos.X < 0) //слева
            {
                player.Pos.X += 5;
            }
        }

        public static bool Collision()
        {
            if ((player.Pos.X > 20) && (player.Pos.X < 80) && (player.Pos.Y > 282) && (player.Pos.Y < 290)) //1
            {
                return true;
            }
            if ((player.Pos.X > 520) && (player.Pos.X < 640) && (player.Pos.Y > 282) && (player.Pos.Y < 290)) //2
            {
                return true;
            }
            if ((player.Pos.X > 170) && (player.Pos.X < 230) && (player.Pos.Y > 238) && (player.Pos.Y < 246)) //3
            {
                return true;
            }
            if ((player.Pos.X > 360) && (player.Pos.X < 440) && (player.Pos.Y > 238) && (player.Pos.Y < 246)) //4
            {
                return true;
            }
            if ((player.Pos.X > 80) && (player.Pos.X < 130) && (player.Pos.Y > 150) && (player.Pos.Y < 160)) //5
            {
                return true;
            }
            if ((player.Pos.X > 270) && (player.Pos.X < 330) && (player.Pos.Y > 150) && (player.Pos.Y < 160)) //6
            {
                return true;
            }
            if ((player.Pos.X > 470) && (player.Pos.X < 530) && (player.Pos.Y > 150) && (player.Pos.Y < 160)) //7
            {
                return true;
            }
            if ((player.Pos.X > -40) && (player.Pos.X < 80) && (player.Pos.Y > 62) && (player.Pos.Y < 70)) //8
            {
                return true;
            }
            if ((player.Pos.X > 170) && (player.Pos.X < 230) && (player.Pos.Y > 62) && (player.Pos.Y < 70)) //9
            {
                return true;
            }
            if ((player.Pos.X > 360) && (player.Pos.X < 440) && (player.Pos.Y > 62) && (player.Pos.Y < 70)) //10
            {
                return true;
            }
            if ((player.Pos.X > 560) && (player.Pos.X < 740) && (player.Pos.Y > 62) && (player.Pos.Y < 70)) //11
            {
                return true;
            }
            if ((player.Pos.X > 270) && (player.Pos.X < 330) && (player.Pos.Y > 18) && (player.Pos.Y < 22)) //12
            {
                return true;
            }
            if ((player.Pos.X > 660) && (player.Pos.X < 1000) && (player.Pos.Y > 194) && (player.Pos.Y < 200)) //13
            {
                return true;
            }
            return false;
        }

        public static void CreateGems()
        {
            Gems = new Gem[17];
            Gems[0] = new Gem(10, 400);
            Gems[1] = new Gem(60, 92);
            Gems[2] = new Gem(60, 312);
            Gems[3] = new Gem(110, 180);
            Gems[4] = new Gem(210, 92);

            Gems[5] = new Gem(210, 268);
            Gems[6] = new Gem(210, 400);

            Gems[7] = new Gem(310, 180);
            Gems[8] = new Gem(310, 400);

            Gems[9] = new Gem(410, 92);
            Gems[10] = new Gem(410, 268);
            Gems[11] = new Gem(410, 400);

            Gems[12] = new Gem(510, 180);

            Gems[13] = new Gem(560, 312);

            Gems[14] = new Gem(610, 91);

            Gems[15] = new Gem(710, 91);
            Gems[16] = new Gem(710, 224);


        }
        public static void CreatePortals()
        {
            Portals = new Portal[10];
            Portals[0] = new Portal(0, 92);
            Portals[1] = new Portal(60, 224);
            Portals[2] = new Portal(110, 400);
            Portals[3] = new Portal(160, 136);
            Portals[4] = new Portal(260, 400);
            Portals[5] = new Portal(460, 92);
            Portals[6] = new Portal(360, 400);
            Portals[7] = new Portal(460, 312);
            Portals[8] = new Portal(660, 92);
            Portals[9] = new Portal(610, 312);

        }

        public static void DeleteGem()
        {
            for (int i = 0; i < Gems.Length; i++)
            {
                if (player.Pos.X == Gems[i].PositionX && (Gems[i].PositionY - player.Pos.Y) <= 30 && (Gems[i].PositionY - player.Pos.Y) >= 20)
                {
                    Gems[i].Delete();
                    Score++;
                }
            }
        }
        public static void Teleportation()
        {
            for (int i = 0; i < Portals.Length; i++)
            {
                if (player.Pos.X == Portals[i].PositionX && (Portals[i].PositionY - player.Pos.Y) <= 40 && (Portals[i].PositionY - player.Pos.Y) >= 10)
                {
                    player.Pos.X = 720;
                    player.Pos.Y = 370;
                }
            }
        }

        static public void Init1(SpriteBatch SpriteBatch, int Width, int Height)
        {
            Scene.Width = Width;
            Scene.Height = Height;
            Scene.SpriteBatch = SpriteBatch;

            CreateTiles();
            CreateGems();
            CreatePortals();
            Text = new Text();
            timer = new Text();
            player = new Player(new Vector2(700, 370), 5);                  
        }
        
        public static void CreateTiles()
        {
            var boxs1 = new List<Tile>();
            var level1 = new int[,]
            {
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,1,0,1},
                {0,0,0,0,0,1,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,1,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,1},
                {0,0,1,0,0,1,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,1,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,1,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,1,0,1},
                {0,0,0,1,0,0,0,0,1,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,1,0,0,0,1},
                {0,0,0,0,0,0,1,0,0,0,1},
                {0,0,0,0,0,0,1,0,0,0,1}
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
            foreach (Portal portal in Portals)
            {
                portal.Draw();
            }

            player.Draw();
            Text.Draw(Score, Gems.Length);
            timer.DrawTime(Seconds);
            Scene.SpriteBatch.Draw(Finish, new Rectangle(280, 18, 90, 90), Color.White);           
        }
    }
}
