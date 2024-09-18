using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using madu_oos.CFunctions;
using madu_oos.UI;

namespace madu_oos
{
    internal class Program
    {
        static public void Main(string[] args)
        {
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
            Leaderstats ls = new Leaderstats(um);

            Settings settings = new Settings();
            Menu menu = new Menu(settings, ls);

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
            int wallWidth, wallHeight;

            int askMapTime = 0;

            MapSettings mapSettings;
            DifficultSettings difficultSettings;

            Console.Clear();

            mapSettings = new MapSettings(defaultWallWidth, defaultWallHeight, settings.colorSettings["walls"]);
            wallWidth = mapSettings.WallWidth;
            wallHeight = mapSettings.WallHeight;

            Console.Clear();

            difficultSettings = new DifficultSettings(defaultMinusSpeed);
            speed.minusMs = difficultSettings.MinusSpeed;

            while (true) {

                Console.Clear();
                if (askMapTime != 0 & settings.boolSettings["ask-map-settings-again"])
                {
                    Console.Clear();
                    mapSettings = new MapSettings(defaultWallWidth, defaultWallHeight, settings.colorSettings["walls"]);
                    wallWidth = mapSettings.WallWidth;
                    wallHeight = mapSettings.WallHeight;

                    Console.Clear();

                    difficultSettings = new DifficultSettings(defaultMinusSpeed);
                    speed.minusMs = difficultSettings.MinusSpeed;
                }
                askMapTime++;

                Console.Clear();
                mapSettings.walls.Draw();

                Point p = new Point(4, 5, '*');
                Snake snake = new Snake(p, 4, Direction.RIGHT, settings.colorSettings["snake"]);
                snake.Draw();
                FoodCreator foodCreator = new FoodCreator(wallWidth, wallHeight, '$', snake, settings.colorSettings["food"]);
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
                        if (settings.boolSettings["cutscenes"])
                        {
                            Cutscenes.DeathCutscene(snake);

                            foreach (IDraw component in UIComponents)
                            {
                                component.Reset();
                            }
                            um.UpdateUser(Name, score.BestScore);
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