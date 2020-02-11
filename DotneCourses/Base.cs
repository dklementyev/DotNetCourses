using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace DotneCourses
{
    public class Base : IMapElement
    {
        public Point[] points;
        public void Parse(string line)
        {
            var metrics = line.Split(':');
            points = new Point[metrics.Length];
            for (var i = 0; i< metrics.Length; ++i)
            {
                var metric = metrics[i];
                var parts = metric.Split(',');
                points[i] = new Point(parts[0], parts[1]);
            }
        }

        public Point[] GetPoints()
        {
            return points;
        }

        public string[,] FillMap(string [,] map)
        {
            for (var i = points[0].Y- 1; i <= points[1].Y; i++)
            {
                for (var j = points[0].X - 1; j <= points[1].X; j++)
                {
                    map[i, j] = Task1Consts.BaseSymbol;
                }
            }
            return map;
        }
    }
}
