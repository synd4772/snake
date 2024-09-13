using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos.UI
{
    public class Speed : IDraw
    {
        public int defaultSpeed, currentSpeed, minusMs;
        public int[] position;
        public Speed(int x, int y, int defaultSpeed, int minusMs) 
        {
            this.defaultSpeed = defaultSpeed;
            this.currentSpeed = defaultSpeed;
            this.minusMs = minusMs;
            position = new int[2] {x, y};
        }

        public void Draw()
        {
            Console.SetCursorPosition(this.position[0], this.position[1]);
            Console.Write($"Current speed: {this.currentSpeed} ms/p");
        }

        public void Reset()
        {
            this.currentSpeed = this.defaultSpeed;

        }
        public void Update() 
        {
            if ( this.currentSpeed > 10 )
            {
                this.currentSpeed = this.currentSpeed - this.minusMs;

            }
        }
    }
}
