using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos.CFunctions
{
    public class Menu: IConsole
    {
        public int? vastus;
        Settings settings;
        Leaderstats ls;
        public Menu(Settings settings, Leaderstats ls) {
            this.settings = settings;
            this.ls = ls;
            while (true)
            {
                Console.Clear();
                this.ShowChoice();
                vastus = this.GetChoice();

                if (vastus == null)
                {
                    continue;
                }
                switch (vastus)
                {
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        settings.Run();
                        continue;
                    case 3:
                        Console.Clear();
                        ls.ShowBestUsers();
                        Console.ReadKey();
                        continue;
                    default:continue;
                }
                break;
            }
        }

        public void ShowChoice()
        {
            Console.WriteLine("Choose one of variants: \n" +
                    "1. Play\n" +
                    "2. Settings\n" +
                    "3. Leaderstats");
        }

        public int? GetChoice()
            {
            try
            {
                int vastus = int.Parse(Console.ReadLine());
                return vastus;
            }
            catch (Exception e)
            {
                Console.WriteLine($"error: {e}");
                return null;
            }
        }

        }
    }

