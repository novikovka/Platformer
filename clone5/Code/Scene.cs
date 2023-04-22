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
        static public Gem[] gems;
        //static public Gem gem { get; set; }

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
            
            
            if ((gems[0].Pos.X == player.Pos.X) && (gems[0].Pos.Y - player.Pos.Y == 30))
            {
                gems[0].Delete();
            }
            if ((gems[1].Pos.X == player.Pos.X) && (gems[1].Pos.Y - player.Pos.Y == 30))
            {
                gems[1].Delete();
            }
            if ((gems[2].Pos.X == player.Pos.X) && (gems[2].Pos.Y - player.Pos.Y == 30))
            {
                gems[2].Delete();
            }
            if ((gems[3].Pos.X == player.Pos.X) && (gems[3].Pos.Y - player.Pos.Y == 30))
            {
                gems[3].Delete();
            }
            if ((gems[4].Pos.X == player.Pos.X) && (gems[4].Pos.Y - player.Pos.Y == 30))
            {
                gems[4].Delete();
            }

            if ((gems[5].Pos.X == player.Pos.X) && (player.Pos.Y == 195))
            {
                gems[5].Delete();
            }
            if ((gems[6].Pos.X == player.Pos.X) && (player.Pos.Y == 195))
            {
                gems[6].Delete();
            }
            /*
            if ((gems[5].Pos.X == player.Pos.X) && (player.Pos.Y > 194) && (player.Pos.Y < 200))
            {
                gems[5].Delete();
            }
            if ((gems[6].Pos.X == player.Pos.X) && (player.Pos.Y > 194) && (player.Pos.Y < 200))
            {
                gems[6].Delete();
            }
            
            if ((gems[7].Pos.X == player.Pos.X) && (player.Pos.Y > 282) && (player.Pos.Y < 290))
            {
                gems[7].Delete();
            }
            if ((gems[8].Pos.X == player.Pos.X) && (player.Pos.Y > 282) && (player.Pos.Y < 290))
            {
                gems[8].Delete();
            }
            */
            if ((gems[7].Pos.X == player.Pos.X) && (player.Pos.Y == 285))
            {
                gems[7].Delete();
            }
            if ((gems[8].Pos.X == player.Pos.X) && (player.Pos.Y == 285))
            {
                gems[8].Delete();
            }

            if ((gems[9].Pos.X == player.Pos.X) && (player.Pos.Y > 62) && (player.Pos.Y < 70))
            {
                gems[9].Delete();
            }
            if ((gems[10].Pos.X == player.Pos.X) && (player.Pos.Y > 62) && (player.Pos.Y < 70))
            {
                gems[10].Delete();
            }
            if ((gems[11].Pos.X == player.Pos.X) && (player.Pos.Y > 62) && (player.Pos.Y < 70))
            {
                gems[11].Delete();
            }
            if ((gems[12].Pos.X == player.Pos.X) && (player.Pos.Y > 18) && (player.Pos.Y < 22))
            {
                gems[12].Delete();
            }
            if ((gems[13].Pos.X == player.Pos.X) && (player.Pos.Y > 18) && (player.Pos.Y < 22))
            {
                gems[13].Delete();
            }
            if ((gems[14].Pos.X == player.Pos.X) && (player.Pos.Y > 62) && (player.Pos.Y < 70))
            {
                gems[14].Delete();
            }
            
            
            /*
            for(int i = 0; i < gems.Length; i++)
            {
                if ((gems[i].Pos.X == player.Pos.X) && (gems[i].Pos.Y - player.Pos.Y == 30))
                {
                    gems[i].Delete();
                }
                
            }
            */
            
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
        }

        static public void Init(SpriteBatch SpriteBatch, int Width, int Height) //в этом методе должны создаваться тайлы
        {
            Scene.Width = Width;
            Scene.Height = Height;
            Scene.SpriteBatch = SpriteBatch;
            
            CreateTiles();
             gems = new Gem[15];
            CreateGem();
           
            player = new Player(new Vector2(0, 370),5); //начальная позиция и скорость
      
        }

        public static void CreateGem()
        {
            gems[0] = new Gem(new Vector2(260, 400));
            gems[1] = new Gem(new Vector2(310, 400));
            gems[2] = new Gem(new Vector2(360, 400));

            gems[3] = new Gem(new Vector2(710, 400));
            gems[4] = new Gem(new Vector2(760, 400));

            gems[5] = new Gem(new Vector2(210, 224));
            gems[6] = new Gem(new Vector2(260, 224));

            gems[7] = new Gem(new Vector2(560, 312));
            gems[8] = new Gem(new Vector2(610, 312));

            gems[9] = new Gem(new Vector2(60, 92));
            gems[10] = new Gem(new Vector2(110, 92));
            gems[11] = new Gem(new Vector2(160, 92));

            gems[12] = new Gem(new Vector2(410, 42));
            gems[13] = new Gem(new Vector2(460, 42));

            gems[14] = new Gem(new Vector2(610, 92));

        }



        public static void CreateTiles()
        {
            //var gemses = new List<Gem>();
            var boxs = new List<Tile>();
            var map = new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,0,0,0,0,1},
                {0,0,0,1,0,0,1,0,0,0,1},
                {0,0,0,0,0,0,1,0,0,2,1},
                {0,0,0,0,0,0,1,0,0,2,1},
                {0,0,1,0,0,0,1,0,0,0,1},
                {0,0,1,0,0,0,0,0,0,0,1},
                {0,0,1,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,1,0,1},
                {0,0,0,0,0,0,0,2,1,0,1},
                {0,0,0,1,0,0,0,2,1,0,1},
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
            
            foreach(Gem gem in gems)
            {
                gem.Draw();
            }
                       
            player.Draw();
            
        }
    }  
}
