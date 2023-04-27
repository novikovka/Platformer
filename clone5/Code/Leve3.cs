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
using static System.Formats.Asn1.AsnWriter;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace clone5
{
    class Level3
    {
        public static int Width, Height; //размеры экрана
        static public SpriteBatch SpriteBatch;
        static public Tile[] tiles1;

        static public Portal[] portals;
        static public Gem[] gems;
        static public int Score = 0;
        static public Text text;
        static public Text timer;
        static public int time = 0;
        public static Texture2D Finish { get; set; }

        //public static Texture2D YouWinner { get; set; }
        //public static Message YouWinner;
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
            }
            if (button.IsKeyDown(Keys.D))
            {
                player.Right();
            }

            if (player.Pos.Y <= 370 && !Collision())
            {
                player.Fall();
            }          
            
            WindowOut();
            DeleteGem();
            Teleportation();
            if(Game1.Stat == Stat.Scene3)
            {
                time++;
            }
            //time++;

            // DrawYouWinner();

            if ((time < 3000  && player.Pos.X > 280 && player.Pos.X < 360 && player.Pos.Y < 19 && Score == 17) ||  button.IsKeyDown(Keys.H)) //вот тут надо будет убрать переход по клавише 
            {
                Game1.Stat = Stat.YouWinner;
            }
            else if ((time >= 3000) || button.IsKeyDown(Keys.J))
            {
                Game1.Stat = Stat.GameOver;
            }

        }
        /*
        public static void TakeMessage()
        {
            if (time < 500 ) //вот тут надо будет убрать переход по клавише 
            {
                Game1.Stat = Stat.YouWinner;
            }

        }
        */
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
            gems = new Gem[17];
            gems[0] = new Gem(10, 400);
            gems[1] = new Gem(60, 92);
            gems[2] = new Gem(60, 312);
            gems[3] = new Gem(110, 180);
            gems[4] = new Gem(210, 92);

            gems[5] = new Gem(210, 268);
            gems[6] = new Gem(210, 400);

            gems[7] = new Gem(310, 180);
            gems[8] = new Gem(310, 400);

            gems[9] = new Gem(410, 92);
            gems[10] = new Gem(410, 268);
            gems[11] = new Gem(410, 400);

            gems[12] = new Gem(510, 180);

            gems[13] = new Gem(560, 312);

            gems[14] = new Gem(610, 91);

            gems[15] = new Gem(710, 91);
            gems[16] = new Gem(710, 224);


        }
        public static void CreatePortals()
        {
            portals = new Portal[10];
            portals[0] = new Portal(0, 92);
            portals[1] = new Portal(60, 224);
            portals[2] = new Portal(110, 400);
            portals[3] = new Portal(160, 136);
            portals[4] = new Portal(260, 400);
            portals[5] = new Portal(460, 92);
            portals[6] = new Portal(360, 400);
            portals[7] = new Portal(460, 312);
            portals[8] = new Portal(660, 92);
            portals[9] = new Portal(610, 312);

        }

        public static void DeleteGem()
        {
            for (int i = 0; i < gems.Length; i++)
            {
                if (player.Pos.X == gems[i].PositionX && (gems[i].PositionY - player.Pos.Y) <= 30 && (gems[i].PositionY - player.Pos.Y) >= 20)
                {
                    gems[i].Delete();
                    Score++;
                }
            }
        }
        public static void Teleportation()
        {
            for (int i = 0; i < portals.Length; i++)
            {
                if (player.Pos.X == portals[i].PositionX && (portals[i].PositionY - player.Pos.Y) <= 40 && (portals[i].PositionY - player.Pos.Y) >= 10)
                {
                    player.Pos.X = 720;
                    player.Pos.Y = 370;

                }
            }
        }

        static public void Init1(SpriteBatch SpriteBatch, int Width, int Height) //в этом методе должны создаваться тайлы
        {
            Scene.Width = Width;
            Scene.Height = Height;
            Scene.SpriteBatch = SpriteBatch;

            CreateTiles1();
            CreateGems();
            CreatePortals();
            text = new Text();
            timer = new Text();


            player = new Player(new Vector2(700, 370), 5); //начальная позиция и скорость           
            //DrawYouWinner();
        }
        /*
        public static void DrawYouWinner()
        {
            if(time == 500)
            {
                YouWinner = new Message(0, 0);
            }
        }
        */
        public static void CreateTiles1()
        {
            var boxs1 = new List<Tile>();
            //var listPortals = new List<Portal>();
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

            tiles1 = boxs1.ToArray();
            //portals = listPortals.ToArray();

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
            foreach (Portal portal in portals)
            {
                portal.Draw();
            }

            player.Draw();
            text.Draw(Score, gems.Length);
            timer.DrawTime(time);
            Scene.SpriteBatch.Draw(Finish, new Rectangle(280, 18, 90, 90), Color.White);
            //DrawYouWinner();
            //YouWinner.Draw();

        }
    }
}
/*
 * using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clone5
{
    class Message
    {
        public static Texture2D YouWinner { get; set; }

        public const int Width = 300;
        public const int Height = 200;
        public int PositionX;
        public int PositionY;

        public Message(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
        
        public void Draw()
        {
            Scene.SpriteBatch.Draw(YouWinner, new Rectangle(PositionX, PositionY, Width, Height), Color.White);
        }
    }
}
 */