using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos.CFunctions
{
    public class Settings : IConsole
    {
        int quitIndex;
        public Dictionary<string, bool> boolSettings = new Dictionary<string, bool>()
        {
            { "cutscenes" , true },
            { "ask-map-settings-again", true }
        };
        public Dictionary<string, ConsoleColor> colorSettings = new Dictionary<string, ConsoleColor>()
        {
            { "snake", ConsoleColor.Green },
            { "walls", ConsoleColor.DarkGray },
            { "food", ConsoleColor.Cyan }
        };
        ConsoleColor[] colors = new ConsoleColor[]
        {
                ConsoleColor.Green,
                ConsoleColor.DarkGray,
                ConsoleColor.Cyan,
                ConsoleColor.White,
                ConsoleColor.Blue,
                ConsoleColor.Yellow,
                ConsoleColor.Magenta
        };
        public Settings()
        {
            
        }
        public void Run()
        {
            int? vastus;
            bool status = false;
            while (true)
            {
                this.ShowChoice();
                vastus = this.GetChoice();

                if (vastus == null) { continue; }
                if (vastus == this.quitIndex) { break; }
                if (vastus > boolSettings.Count + colorSettings.Count) { continue; }
                int index = 0;
                if (vastus <= boolSettings.Count)
                {
                    
                    foreach (var item in boolSettings)
                    {
                        index++;
                        if (index == vastus)
                        {
                            boolSettings[item.Key] = !item.Value;
                            break;
                        }
                    }
                }
                else
                {
                    index = boolSettings.Count;
                    foreach (var item in colorSettings)
                    {
                        index++;
                        if (index == vastus)
                        {
                            Console.Clear();
                            this.ShowColors();
                            int? vastus2 = this.GetChoice();
                            if (vastus2 == null || vastus2 > colors.Length) { break; }
                            ConsoleColor color = colors[(int)vastus2 - 1];
                            colorSettings[item.Key] = color;
                            break;
                        }
                    }
                }
                Console.Clear();
            }
            Console.Clear();
        }
        public void SetSettings(string key, ConsoleColor color)
        {
            colorSettings[key] = color;
        }
        public void SetSettings(string key, bool boolean)
        {
            boolSettings[key] = boolean;
        }
        public int? GetChoice()
        {
            int vastus;
            try
            {
                vastus = int.Parse(Console.ReadLine());
                return vastus;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }
        public string GetVariantOfSetting(string key)
        {
            string ret = (boolSettings[key]) ? "Disable" : "Enable";
            return ret;
        }
        public void ShowChoice()
        {
            int index = 0;
            Console.WriteLine("Main settings:");
            foreach(var item in this.boolSettings)
            {
                index++;
                Console.WriteLine($"{index}. {this.GetVariantOfSetting(item.Key)} {item.Key}");
            }
            Console.WriteLine("\nColor settings:");
            foreach (var item in this.colorSettings)
            {
                index++;
                Console.WriteLine($"{index}. Change color of {item.Key}");
            }
            index++;
            this.quitIndex = index;
            Console.WriteLine($"\n{index}. Quit");
        }

        public void ShowColors()
        {
            int index = 0;
            foreach (var color in colors)
            {
                index++;
                Console.WriteLine($"{index}. {color.ToString()}");
            }
        }
    }
}
