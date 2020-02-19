using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotneCourses.AStarClasses;

namespace DotneCourses
{


    public class Water : IMapElement
    {
        public Point[] points;

        public void Parse(string line)
        {
            var coordsSequence = line.Replace("->", "-").Split('-');
            points = new Point[coordsSequence.Length];
            for (int i = 0; i < coordsSequence.Length; i++)
            {
                var coord = coordsSequence[i];
                var parts = coord.Split(',');
                points[i] = new Point(parts[0], parts[1]);
            }
        }

        public Point[] GetPoints()
        {
            return points;
        }

        public string[,] FillMap(string[,] map)
        {

            
            var prevPoint = points[0];

            for (var i = 1; i < points.Length; ++i)
            {
                if (points[i] == prevPoint)
                {
                    prevPoint = points[i];
                    continue;
                }

                var path = Node.FindPath(map, prevPoint, points[i], true);
                foreach (var p in path)
                {
                    if (map[p.Y, p.X] == Task1Consts.BridgeSymbol)
                        continue;
                    map[p.Y, p.X] = Task1Consts.WaterSymbol;
                }

                prevPoint = points[i];
            }
            /*
            for (int i = 1; i < points.Length; i++)
            {
                var curPoint = points[i];
                if (prevPoint == curPoint)
                {
                    prevPoint = curPoint;
                    continue;
                }

                if (prevPoint.X == curPoint.X)
                {
                    for (int j = 0; j <= curPoint.Y; j++)
                    {
                        if (map[j, curPoint.X] == Task1Consts.BridgeSymbol)
                            continue;
                        map[j, curPoint.X] = Task1Consts.WaterSymbol;
                    }
                    prevPoint = curPoint;
                    continue;
                }
                else
                {
                    var m = (double) (prevPoint.Y - curPoint.Y) / (prevPoint.X - curPoint.X);
                    var c = prevPoint.Y - prevPoint.X * m;

                    int step = 1;
                    int minX = prevPoint.X;
                    int maxX = curPoint.X;
                    if (prevPoint.X > curPoint.X)
                    {
                        for (int x = minX; x >= maxX; --x)
                        {
                            var y = (int) Math.Ceiling(m * x + c);
                            if (map[y, x] == Task1Consts.BridgeSymbol)
                                continue;
                            map[y, x] = Task1Consts.WaterSymbol;
                        }
                    }
                    else
                    {
                        for (int x = minX; x <= maxX; x += step)
                        {
                            var y = (int) Math.Ceiling(m * x + c);
                            if (map[y, x] == Task1Consts.BridgeSymbol)
                                continue;
                            map[y, x] = Task1Consts.WaterSymbol;
                        }
                    }
                    prevPoint = curPoint;
                }
            }
            */
            return map;
        }

    }
}
