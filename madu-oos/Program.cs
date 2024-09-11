using System.Drawing;
using System.Xml.Linq;

namespace madu_oos
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            VerticalLine v1 = new VerticalLine(0, 10, 5, '%');
            Draw(v1);

            Point p = new Point(4, 5, '*');
            Figure fSnake = new Snake(p, 4, Direction.RIGHT);
            Draw(fSnake);
            Snake snake = (Snake)fSnake;

            HorizontalLine h1 = new HorizontalLine(0, 5, 6, '&');

            List<Figure> figures = new List<Figure>();
            figures.Add(fSnake);
            figures.Add(v1);
            figures.Add(h1);

            foreach (var f in figures)
            {
                f.Draw();
            }

        }
        static void Draw(Figure figure)
        {
            figure.Draw();
        }


    }
}