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
        //static public Portal portal { get; set; }
        static public Portal[] portals;
        static public Gem[] gems;

        static public Player player { get; set; }
        //static public Texture2D Exit;
        //static public Texture2D Portal;

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

            if (player.Pos.Y <= 370 && !(Collision()))
            {
                player.Fall();
            }

            if (player.Pos.Y > 370) //чтобы персонаж не падал сквозь нижние плитки
            {
                player.Pos.Y -= 5;
            }
            /*
            if ((player.Pos.Y > 238) && (player.Pos.Y < 246) && (player.Pos.X == 400)) //пробуем делать порталы
            {
                player.Pos.X = 700;
                player.Pos.Y = 370;
            }
            */
            Teleportation();
            DeleteGem();

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
                if (player.Pos.X == gems[i].PositionX && (gems[i].PositionY - player.Pos.Y) <= 30 && (gems[i].PositionY - player.Pos.Y) >= 20)
                {
                    gems[i].Delete();
                    //Score++;
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
            player = new Player(new Vector2(0, 0), 5); //начальная позиция и скорость
            //portal = new Portal(370, 370);
        }

        public static bool Collision()
        {
            if ((player.Pos.X > 20) && (player.Pos.X < 130) && (player.Pos.Y > 194) && (player.Pos.Y < 200))
            {
                return true;
            }
            if ((player.Pos.X > 230) && (player.Pos.X < 330) && (player.Pos.Y > 150) && (player.Pos.Y < 160))
            {
                return true;
            }
            if ((player.Pos.X > 330) && (player.Pos.X < 430) && (player.Pos.Y > 238) && (player.Pos.Y < 246))
            {
                return true;
            }
            if ((player.Pos.X > 480) && (player.Pos.X < 580) && (player.Pos.Y > 150) && (player.Pos.Y < 160))
            {
                return true;
            }
            if ((player.Pos.X > 580) && (player.Pos.X < 680) && (player.Pos.Y > 62) && (player.Pos.Y < 70))
            {
                return true;
            }
            if ((player.Pos.X > 80) && (player.Pos.X < 280) && (player.Pos.Y > 18) && (player.Pos.Y < 25))
            {
                return true;
            }
            if ((player.Pos.X > 580) && (player.Pos.X < 680) && (player.Pos.Y > 326) && (player.Pos.Y < 335))
            {
                return true;
            }
            return false;

        }

        public static void CreateTiles1()
        {
            var boxs1 = new List<Tile>();
            //var listPortals = new List<Portal>();
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
            //portals = listPortals.ToArray();

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
            player.Draw();
            //portal.Draw();

        }

    }
}
