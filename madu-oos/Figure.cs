using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos
{
    public class Figure
    {
        public List<Point> pList = new List<Point>();
        public virtual void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
        public virtual void Draw(ConsoleColor color)
        {
            foreach (Point p in pList)
            {
                p.Draw(color);
            }
        }

        internal bool IsHit(Figure figure)
        {
            foreach(Point p in pList)
            { 
                if (figure.IsHit(p))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsHit(Point point)
        {
            foreach(var p in pList)
            {
                if (p.IsHit(point))
                {
                    return true;
                }

                
            }
            return false;
        }
    }
}
