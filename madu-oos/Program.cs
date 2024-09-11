using System.Drawing;
using System.Xml.Linq;

namespace madu_oos
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            while (true) { 
            Walls walls = new Walls(75, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(75, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                        Console.Clear();
                        break;
                        
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(5);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            }
        }
        static void Draw(Figure figure)
        {
            figure.Draw();
        }


    }
}