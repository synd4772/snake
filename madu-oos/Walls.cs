﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos
{
    public class Walls
    {
        List<Figure> wallList;
        public int MapWidth, MapHeight;
        public ConsoleColor color;

        public Walls(int mapWidth, int mapHeight, ConsoleColor color)
        {
            this.color = color;
            this.MapWidth = mapWidth;
            this.MapHeight = mapHeight;

            wallList = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+', color);
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+', color);
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);

        }
        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
               
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw(this.color);
            }
        }


    }
}
