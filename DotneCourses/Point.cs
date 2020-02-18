using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotneCourses
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point(string x, string y)
        {
            X = Convert.ToInt16(x);
            Y = Convert.ToInt16(y);
        }
        public bool IsOutOfRange(int xRange, int yRange)
        {
            return X < 0 || X >= xRange || Y < 0 || Y >= yRange;
        }
        public static bool operator ==(Point leftPoint, Point rightPoint)
        {
            return leftPoint.X == rightPoint.X && leftPoint.Y == rightPoint.Y;
        }
        public static bool operator !=(Point leftPoint, Point rightPoint)
        {
            return leftPoint.X != rightPoint.X && leftPoint.Y != rightPoint.Y;
        }
        public static bool operator >(Point leftPoint, Point rightPoint)
        {
            return leftPoint.X > rightPoint.X && leftPoint.Y > rightPoint.Y;
        }
        public static bool operator <(Point leftPoint, Point rightPoint)
        {
            return leftPoint.X < rightPoint.X && leftPoint.Y < rightPoint.Y;
        }
    }
}
