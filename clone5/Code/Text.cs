using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace clone5
{
    class Text
    {       
        public static SpriteFont Font { get; set; } //!!!

        public static string PrintScore(int Score, int count)
        {
            var ScoreString = "Gems: " + Score.ToString() + "/" + count.ToString();
            return ScoreString;
        }

        public void Draw(int Score, int count)
        {
            Scene.SpriteBatch.DrawString(Font, PrintScore(Score, count), new Vector2(0, 0), Color.Black); //!!!
        }

        public void DrawTime(int time)
        {
            Scene.SpriteBatch.DrawString(Font, "time: " + time.ToString(), new Vector2(500, 0), Color.Black); //!!!
        }
    }
}
