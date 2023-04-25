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

        public static string PrintScore(int Score)
        {
            var ScoreString = "Score: " + Score.ToString() + "/ 15";
            return ScoreString;
        }

        public void Draw(int Score)
        {
            Scene.SpriteBatch.DrawString(Font, PrintScore(Score), new Vector2(0, 0), Color.Black); //!!!
        }
    }
}
