using System.Drawing;

namespace madu_oos
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            HorizontalLine upLine = new HorizontalLine(0, 48, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 48, 48, '+');
            VerticalLine leftLine = new VerticalLine(0, 14, 0 , '+');
            VerticalLine rightLine = new VerticalLine(0, 14, 48, '+');

            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            Console.ReadLine();
        }
        


    }
}