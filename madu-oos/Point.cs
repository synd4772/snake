using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos
{
    public class Point
    {
        public int y; public int x; public char sym; public ConsoleColor color;

        public Point(int x, int y, char sym, ConsoleColor color)
        {
            this.x = x; this.y = y; this.sym = sym; this.color = color;
        }
        public Point(int x, int y, char sym)
        {
            this.x = x; this.y = y; this.sym = sym;
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
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
        public void Draw()
        {
            Console.ForegroundColor = this.color;
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Draw(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

    }
}
