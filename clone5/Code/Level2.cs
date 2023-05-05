using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace clone5
{
    class Level2
    {
        static public SpriteBatch SpriteBatch { get; set; }
        static public Tile[] Tiles;      
        static public Portal[] Portals;
        static public Gem[] Gems;
        static public Exit1 Exit;     
        static public Player Player { get; set; }     
        static public int Score = 0;
        static public Text Text;

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
                Player.Direction = 0;
            }
            if (button.IsKeyDown(Keys.D))
            {
                Player.Right();
                Player.Direction = 1;
            }
            if (Player.Pos.Y <= 370 && !(Collision()))
            {
                Player.Fall();
            }
            
            Teleportation();
            DeleteGem();
            WindowOut();

            if ((Player.Pos.X > 150) && (Player.Pos.X < 200) && (Player.Pos.Y < 25) && Score == 15) 
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
            for (int i = 0; i < Portals.Length; i++)
            {
                if (Player.Pos.X == Portals[i].PositionX && (Portals[i].PositionY - Player.Pos.Y) <= 40 && (Portals[i].PositionY - Player.Pos.Y) >= 10)
                {
                    Player.Pos.X = 720;
                    Player.Pos.Y = 370;

                }
            }
        }

        public static void CreatePortals()
        {
            Portals = new Portal[6];
            Portals[0] = new Portal(0, 268);
            Portals[1] = new Portal(550, 136);
            Portals[2] = new Portal(100, 400);
            Portals[3] = new Portal(250, 180);
            Portals[4] = new Portal(450, 312);
            Portals[5] = new Portal(700, 180);
        }
        public static void CreateGems()
        {
            Gems = new Gem[15];
            Gems[0] = new Gem(10, 400);
            Gems[1] = new Gem(60, 400);
            Gems[2] = new Gem(60, 224);
            Gems[3] = new Gem(110, 224);
            Gems[4] = new Gem(260, 48);
            Gems[5] = new Gem(310, 180);
            Gems[6] = new Gem(360, 268);
            Gems[7] = new Gem(410, 268);
            Gems[8] = new Gem(510, 180);
            Gems[9] = new Gem(560, 180);
            Gems[10] = new Gem(610, 92);
            Gems[11] = new Gem(660, 92);
            Gems[12] = new Gem(610, 356);
            Gems[13] = new Gem(660, 356);
            Gems[14] = new Gem(160, 400);
            

        }

        public static void DeleteGem()
        {
            for (int i = 0; i < Gems.Length; i++)
            {
                if (Player.Pos.X == Gems[i].PositionX && (Gems[i].PositionY - Player.Pos.Y) <= 30 && (Gems[i].PositionY - Player.Pos.Y) >= 20)
                {
                    Gems[i].Delete();
                    Score++;
                }
            }
        }

        static public void Init1(SpriteBatch SpriteBatch, int Width, int Height) 
        {
            Scene.Width = Width;
            Scene.Height = Height;
            Scene.SpriteBatch = SpriteBatch;

            CreateTiles1();
            CreatePortals();
            CreateGems();
            Player = new Player(new Vector2(720, 370), 5);        
            Text = new Text();
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
            var boxs = new List<Tile>();
            
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
                        boxs.Add(tile);
                    }
                }
            }
            Tiles = boxs.ToArray();          
        }
        
        public static void Draw()
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw();
            }
            foreach (Portal portal in Portals)
            {
                portal.Draw();
            }
            foreach(Gem gem in Gems)
            {
                gem.Draw();
            }
            
            Player.Draw();
            Text.Draw(Score, Gems.Length);
            Exit.Draw();
        }
    }
}
