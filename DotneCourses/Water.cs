using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotneCourses
{
    public struct Point
    {
        public int X;
        public int Y;
    }

    public class Water : IMapElement
    {
        public Point[] points;

        public void Parse(string line)
        {
            var coordsSequence = line.Replace("->", "-").Split('-');
            points = new Point[coordsSequence.Length];
            int i = 0;
            foreach (var coord in coordsSequence)
            {
                points[i].X = Convert.ToInt16(coord.Split(',')[1]);
                points[i].Y = Convert.ToInt16(coord.Split(',')[0]);
                ++i;
            }
        }

        public string[,] FillMap(string[,] map)
        {
            var prevPoint = points[0];
            for (int i = 1; i < points.Length; i++)
            {
                var curPoint = points[i];

                if (prevPoint.X == curPoint.X)
                {
                    for (int j = 0; j < curPoint.Y; j++)
                    {
                        map[j, curPoint.X] = Task1Consts.WaterSymbol;
                    }
                }
                else
                {


                    var m = curPoint.X == prevPoint.X ? 0 : (prevPoint.Y - curPoint.Y) / (prevPoint.X - curPoint.X);
                    var c = prevPoint.Y - prevPoint.X * m;


                    int step = 1;
                    int minX = prevPoint.X;
                    int maxX = curPoint.X;
                    if (prevPoint.X > curPoint.X)
                    {
                        step = -1;
                    }

                    for (int x = minX; x < maxX; x += step)
                    {
                        var y = (m * x) + c;
                        if (map[y, x] == Task1Consts.BridgeSymbol)
                            continue;
                        map[y, x] = Task1Consts.WaterSymbol;
                    }
                    prevPoint = curPoint;
                }
            }
            return map;
        }

    }
}
