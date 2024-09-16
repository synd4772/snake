using madu_oos.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos.CFunctions
{
    public class MapSettings: IConsole
    {
        public int? Vastus;
        public int WallWidth, WallHeight;
        public Walls walls;

        public MapSettings(int wallWidth, int wallHeight) 
        { 
            this.WallWidth = wallWidth;
            this.WallHeight = wallHeight;
            while (true)
            {
                this.ShowChoice();
                this.Vastus = this.GetChoice();
                if (this.Vastus == null)
                {
                    continue;
                }
                break;
            }

        }

        public void ShowChoice() 
        {
            Console.WriteLine("What size of map do you prefer more?\n" +
            "1. small\n" +
            "2. medium\n" +
            "3. big");
            
        }
        public int? GetChoice()
        {
            try
            {
                int vastus = 2;/*int.Parse(Console.ReadLine());*/
                switch (vastus)
                {
                    case 1:
                        this.WallWidth = this.WallWidth / 2;
                        this.WallHeight = this.WallHeight / 2;
                        walls = new Walls(this.WallWidth, this.WallHeight);
                        return 1;
                    case 2:
                        walls = new Walls(this.WallWidth, this.WallHeight);
                        return 2;
                    case 3:
                        this.WallHeight = (int)Math.Round((float)this.WallWidth * 1.3f);
                        this.WallHeight = (int)Math.Round((float)this.WallHeight * 1.3f);

                        walls = new Walls(this.WallWidth, this.WallHeight);
                        return 3;
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                
            }
            return null;
        }
    }
}
