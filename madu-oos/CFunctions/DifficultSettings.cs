using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos.CFunctions
{
    public class DifficultSettings: IConsole
    {
        public int? Vastus;
        public int MinusSpeed;

        public DifficultSettings(int defaultMinusSpeed)
        {
            this.MinusSpeed = defaultMinusSpeed;
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
            Console.WriteLine("What kinf of difficult do you prefer more?\n" +
            "1. easy\n" +
            "2. hard\n" +
            "3. very hard\n" +
            "4. nightmare");
        }
        public int? GetChoice()
        {
            try
            {
                int vastus = int.Parse(Console.ReadLine());

                switch (vastus)
                {
                    case 1:
                        this.MinusSpeed = 0;
                        return vastus;
                        
                    case 2:
                        return vastus;
                    case 3:
                        this.MinusSpeed = (int)Math.Round((float)this.MinusSpeed * 1.5f);
                        return vastus;
                    case 4:
                        this.MinusSpeed = this.MinusSpeed = (int)Math.Round((float)this.MinusSpeed * 2f);
                        return vastus;

                    default:
                        return null;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return null;
        }
    }
}
