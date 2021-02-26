using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmeijka
{
    public class Score
    {
        private int score;
        public int level;
        public int Speed;
        public Score(int score, int level, int Speed)
        {
            this.score = score;
            this.level = level;
            this.Speed = Speed;
        }
        public bool ScoreUp()
        {
            score += 1;
            if (score % 10 == 0)
            {
                level += 1;
                return true;
            }
            else { return false; }
        }
        public void ScoreWrite()
        {
            Console.SetCursorPosition(105, 10);
            Console.WriteLine("Score:" + score.ToString());
            Console.SetCursorPosition(105, 11);
            Console.WriteLine("Level:" + level.ToString());

        }
    }
}

