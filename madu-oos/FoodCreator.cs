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

        Random random = new Random();
        public FoodCreator(int mapWidth, int mapHeight, char sym, Snake snake)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
            this.snake = snake;
        }
        public Point CreateFood()
        {
            while (true)
            {
                foreach (Point p in snake.pList)
                {
                    int x = random.Next(2, mapWidth - 2);
                    int y = random.Next(2, mapHeight - 2);
                    if (p.y == y && p.y == y)
                    {
                        continue;
                    }
                    else
                    {
                        return new Point(x, y, sym);
                    }
                }
            }
        }
    }
}
