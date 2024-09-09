using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos
{
    class Point
    {
        public int y; public int x; public char sym;

        public Point() { }
        public Point(int y, int x, char sym)
        {
            this.y = y; this.x = x; this.sym = sym;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                y = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y + offset;
            }
            else if (direction == Direction.DOWN) {
                y = y - offset;
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(sym);
        }
        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }

    }
}
