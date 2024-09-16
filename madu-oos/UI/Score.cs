using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos.UI
{
    public class Score : IDraw
    {
        public int CurrentScore { get; set; }
        public int BestScore { get; set; }
        int[] position;

        public Score(int x, int y)
        {
            BestScore = 0;
            CurrentScore = 0;
            position = new int[2] { x, y };
        }

        public void Draw()
        {
            Console.SetCursorPosition(position[0], position[1]);
            Console.Write($"Score: {CurrentScore}");
            Console.SetCursorPosition(position[0], position[1] + 1);
            Console.Write($"Best score: {BestScore}");
        }

        public void Update()
        {
            CurrentScore++;
        }

        public void Reset()
        {
            if (BestScore < CurrentScore)
            {
                BestScore = CurrentScore;
                CurrentScore = 0;
            }
        }
    }
}
