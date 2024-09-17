using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using madu_oos.CFunctions;
using madu_oos.UI;
using static System.Formats.Asn1.AsnWriter;

namespace madu_oos
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            Console.SetBufferSize(1700,1700);
            Console.SetWindowSize(200,200);
            string Name;
            int defaultWallWidth = 75;
            int defaultWallHeight = 25;

            int defaultSpeed = 100;
            int defaultMinusSpeed = 7;

            Score score = new Score(0, 0);
            Speed speed = new Speed(0, 0, defaultSpeed, defaultMinusSpeed);

            List<IDraw> UIComponents = new List<IDraw>() { score, speed };

            string docPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            UsersManagment um = new UsersManagment(Path.Combine(docPath, "users.txt"));

            Console.WriteLine("What is your name ?");
            Name = Console.ReadLine();
            int userIndex = um.HasUser(Name);
            if (userIndex != -1)
            {
                score.BestScore = int.Parse(um.currentLines[userIndex + 1]);
            }
            else
            {
                um.AddUser(Name, score.BestScore);
            }

            while (true) {

                Console.Clear();

                int wallWidth, wallHeight;

                MapSettings mapSettings = new MapSettings(defaultWallWidth, defaultWallHeight);
                wallWidth = mapSettings.WallWidth;
                wallHeight = mapSettings.WallHeight;

                Console.Clear();

                DifficultSettings difficultSettings = new DifficultSettings(defaultMinusSpeed);
                speed.minusMs = difficultSettings.MinusSpeed;

                Console.Clear();

                mapSettings.walls.Draw();

                Point p = new Point(4, 5, '*');
                Snake snake = new Snake(p, 4, Direction.RIGHT);
                snake.Draw();
                FoodCreator foodCreator = new FoodCreator(wallWidth, wallHeight, '$', snake);
                Point food = foodCreator.CreateFood();
                food.Draw();

                foreach(IDraw component in UIComponents)
                {
                    component.ChangeFormat(mapSettings.walls);
                    component.Draw();
                }

                while (true)
                {
                    if (mapSettings.walls.IsHit(snake) || snake.IsHitTail())
                    {
                        Console.Clear();
                        foreach (IDraw component in UIComponents)
                        { 
                            component.Reset();
                        }
                        um.UpdateUser(Name, score.BestScore);
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