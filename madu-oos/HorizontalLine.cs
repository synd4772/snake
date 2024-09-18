using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos
{
    public class HorizontalLine : Figure
    {
        public ConsoleColor color;
        public HorizontalLine(int xLeft, int xRight, int y, char sym, ConsoleColor color)
        {
            this.color = color;
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
        public override void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
        public override void Draw(ConsoleColor color)
        {
            foreach (Point p in pList)
            {
                p.Draw(color);
            }
        }
    }
}
