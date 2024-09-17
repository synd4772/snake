using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos
{
    public class FoodCreator
    {
        int mapWidth, mapHeight;
        char sym;
        Snake snake { get; set; }

        Random random;
        public FoodCreator(int mapWidth, int mapHeight, char sym, Snake snake)
        {
            random = new Random();

            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
            this.snake = snake;
        }
        public Point CreateFood()
        {
            while (true)
            {
                bool status = true;
                int x = random.Next(2, mapWidth - 2);
                int y = random.Next(2, mapHeight - 2);
                foreach (Point p in snake.pList)
                {
                    if (p.x == x & p.y == y)
                    {
                        status = false;
                        break;
                    }

                }
                if (!status)
                {
                    continue;
                }
                return new Point(x, y, sym);

            }
        }
    }
}
