using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace madu_oos.CFunctions
{
    class Cutscenes
    {
        static public void DeathCutscene(Snake snake)
        {
            foreach (Point point in snake.pList)
            {
                point.Draw(ConsoleColor.Red);
            }
            Thread.Sleep(1000);
            foreach (Point point in snake.pList)
            {
                point.Clear();
                Thread.Sleep(400);
            }

            Console.Clear();
        }
    }
}
