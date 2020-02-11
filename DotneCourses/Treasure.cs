using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotneCourses
{
    public class Treasure : IMapElement
    {
        public Point[] points;

        public void Parse(string line)
        {
            var parts = line.Split(',');
            points = new Point[] { new Point(parts[0], parts[1]) };
        }
        public Point[] GetPoints()
        {
            return points;
        }

        public string[,] FillMap(string[,] map)
        {
            map[points[0].Y, points[0].X] = Task1Consts.TreasureSymbol;
            return map;
        }

    }
}
