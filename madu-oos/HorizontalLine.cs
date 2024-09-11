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

        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {

                Point p = new Point(x, y, sym);
                pList.Add(p);
                //Console.WriteLine(x);
            }
            foreach (Point p in pList)
            {
                //Console.WriteLine($"point horizontal | x = {p.x} , y = {p.y}");
            }
        }
    }
}
