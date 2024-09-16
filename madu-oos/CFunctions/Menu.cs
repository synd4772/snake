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
        public Menu() {
            while (true)
            {
                this.ShowChoice();
                vastus = this.GetChoice();

                if (vastus == null)
                {
                    continue;
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

