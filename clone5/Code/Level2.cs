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
using static System.Formats.Asn1.AsnWriter;

namespace clone5
{
    class Level2
    {
        public static int Width, Height; //размеры экрана
        static public SpriteBatch SpriteBatch { get; set; }
        static public Tile[] tiles1;
        
        static public Portal[] portals;
        static public Gem[] gems;
        static public Exit1 Exit;
        
       

        static public Player Player { get; set; }
        
        static public int Score = 0;
        static public Text text;


        public static void Update(GameTime gameTime)
        {
            KeyboardState button = Keyboard.GetState();

            if (button.IsKeyDown(Keys.W) && (Player.Pos.Y == 370) || (button.IsKeyDown(Keys.W) && Collision()))
            {
                Player.Up();
            }
            if (button.IsKeyDown(Keys.A))
            {
                Player.Left();
            }
            if (button.IsKeyDown(Keys.D))
            {
                Player.Right();
            }

            if (Player.Pos.Y <= 370 && !(Collision()))
            {
                Player.Fall();
            }
            
            Teleportation();
            DeleteGem();
            WindowOut();

            if (((Player.Pos.X > 150) && (Player.Pos.X < 200) && (Player.Pos.Y < 25) && Score == 15) || button.IsKeyDown(Keys.G)) //вот тут надо будет убрать переход по клавише 
            {
                Game1.Stat = Stat.Scene3;
            }

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

        public static void Teleportation()
        {
            for (int i = 0; i < portals.Length; i++)
            {
                if (Player.Pos.X == portals[i].PositionX && (portals[i].PositionY - Player.Pos.Y) <= 40 && (portals[i].PositionY - Player.Pos.Y) >= 10)
                {
                    Player.Pos.X = 720;
                    Player.Pos.Y = 370;

                }
            }
        }

        public static void CreatePortals()
        {
            portals = new Portal[6];
            portals[0] = new Portal(0, 268);
            portals[1] = new Portal(550, 136);
            portals[2] = new Portal(100, 400);
            portals[3] = new Portal(250, 180);
            portals[4] = new Portal(450, 312);
            portals[5] = new Portal(700, 180);

        }
        public static void CreateGems()
        {
            gems = new Gem[15];
            gems[0] = new Gem(10, 400);
            gems[1] = new Gem(60, 400);
            gems[2] = new Gem(60, 224);
            gems[3] = new Gem(110, 224);
            gems[4] = new Gem(260, 48);
            gems[5] = new Gem(310, 180);
            gems[6] = new Gem(360, 268);
            gems[7] = new Gem(410, 268);
            gems[8] = new Gem(510, 180);
            gems[9] = new Gem(560, 180);
            gems[10] = new Gem(610, 92);
            gems[11] = new Gem(660, 92);
            gems[12] = new Gem(610, 356);
            gems[13] = new Gem(660, 356);
            gems[14] = new Gem(160, 400);
            

        }

        public static void DeleteGem()
        {
            for (int i = 0; i < gems.Length; i++)
            {
                if (Player.Pos.X == gems[i].PositionX && (gems[i].PositionY - Player.Pos.Y) <= 30 && (gems[i].PositionY - Player.Pos.Y) >= 20)
                {
                    gems[i].Delete();
                    Score++;
                }
            }
        }

        static public void Init1(SpriteBatch SpriteBatch, int Width, int Height) //в этом методе должны создаваться тайлы
        {
            Scene.Width = Width;
            Scene.Height = Height;
            Scene.SpriteBatch = SpriteBatch;

            CreateTiles1();
            CreatePortals();
            CreateGems();
            Player = new Player(new Vector2(720, 370), 5); //начальная позиция и скорость           
            text = new Text();
            Exit = new Exit1(150, 46);
        }

        public static bool Collision()
        {
            if ((Player.Pos.X > 20) && (Player.Pos.X < 130) && (Player.Pos.Y > 194) && (Player.Pos.Y < 200))
            {
                return true;
            }
            if ((Player.Pos.X > 230) && (Player.Pos.X < 330) && (Player.Pos.Y > 150) && (Player.Pos.Y < 160))
            {
                return true;
            }
            if ((Player.Pos.X > 330) && (Player.Pos.X < 430) && (Player.Pos.Y > 238) && (Player.Pos.Y < 246))
            {
                return true;
            }
            if ((Player.Pos.X > 480) && (Player.Pos.X < 580) && (Player.Pos.Y > 150) && (Player.Pos.Y < 160))
            {
                return true;
            }
            if ((Player.Pos.X > 580) && (Player.Pos.X < 680) && (Player.Pos.Y > 62) && (Player.Pos.Y < 70))
            {
                return true;
            }
            if ((Player.Pos.X > 80) && (Player.Pos.X < 280) && (Player.Pos.Y > 18) && (Player.Pos.Y < 25))
            {
                return true;
            }
            if ((Player.Pos.X > 580) && (Player.Pos.X < 680) && (Player.Pos.Y > 326) && (Player.Pos.Y < 335))
            {
                return true;
            }
            return false;

        }

        public static void CreateTiles1()
        {
            var boxs1 = new List<Tile>();
            
            var level1 = new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,1,0,0,0,1},
                {0,0,1,0,0,0,1,0,0,0,1},
                {0,0,1,0,0,0,0,0,0,0,1},
                {0,0,1,0,0,0,0,0,0,0,1},
                {0,0,1,0,0,1,0,0,0,0,1},
                {0,0,0,0,0,1,0,0,0,0,1},
                {0,0,0,0,0,0,0,1,0,0,1},
                {0,0,0,0,0,0,0,1,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,1,0,0,0,0,1},
                {0,0,0,0,0,1,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,0,1,1},
                {0,0,0,1,0,0,0,0,0,1,1},
                {0,0,0,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,1},
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
            foreach (Portal portal in portals)
            {
                portal.Draw();
            }
            foreach(Gem gem in gems)
            {
                gem.Draw();
            }
            
            Player.Draw();
            text.Draw(Score, gems.Length);
            Exit.Draw();
        }
    }
}
