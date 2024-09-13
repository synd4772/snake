using System;
using System.Drawing;
using System.Xml.Linq;
using madu_oos.UI;
using static System.Formats.Asn1.AsnWriter;

namespace madu_oos
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            string Name;

            int wallWidth = 75;
            int wallHeight = 25;

            Score score = new Score(wallWidth + 1, 0);
            Speed speed = new Speed(wallWidth + 1, 0 + 2, 100, 7);

            List<IDraw> UIComponents = new List<IDraw>() { score , speed };
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            UsersManagment um = new UsersManagment(Path.Combine(docPath, "users.txt"));
            

            while (true) {
                Console.WriteLine("What is your name ?");
                Name = Console.ReadLine();
                Console.Clear();
                

                Walls walls = new Walls(wallWidth, wallHeight);
                walls.Draw();

                Point p = new Point(4, 5, '*');
                Snake snake = new Snake(p, 4, Direction.RIGHT);
                snake.Draw();

                FoodCreator foodCreator = new FoodCreator(wallWidth, wallHeight, '$');
                Point food = foodCreator.CreateFood();
                food.Draw();

                foreach(IDraw component in UIComponents)
                {
                    component.Draw();
                }


                while (true)
                {
                    if (walls.IsHit(snake) || snake.IsHitTail())
                    {
                        Console.Clear();
                        foreach (IDraw component in UIComponents)
                        {
                            component.Reset();
                        }

                        break;
                        
                    }

                    if (snake.Eat(food))
                    {
                        food = foodCreator.CreateFood();
                        food.Draw();

                        foreach (IDraw component in UIComponents)
                        {
                            component.Update();
                            component.Draw();
                        }

                    }
                    else
                    {
                        snake.Move();
                    }
                    Thread.Sleep(speed.currentSpeed);
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