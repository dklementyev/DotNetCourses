using DotneCourses.AStarClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotneCourses
{
    class Program
    {
        static void Main(string[] args)
        {
            // for (int i = 0; i < 11; ++i)
            //{
            var path = Path.Combine(System.Environment.CurrentDirectory, "TestData", $"Map.txt");
            var fileHelper = new FileHelper(path);

            var mapHelper = new MapParser(fileHelper.LinesFromFile);

            var map = mapHelper.Parse();
            //}
            Console.WriteLine();
            Console.Write(" ");
            for (int i = 0; i < mapHelper.xMax / 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(j);
                }
            }
            Console.Write(0);
            Console.WriteLine();
            int k = 0;
            for (int i = 0; i < mapHelper.yMax; i++)
            {
                

                Console.Write(k);
                k++;
                if (k == 10)
                {
                    k = 0;
                }
                for (int j = 0; j < mapHelper.xMax; j++)
                {
                    Console.Write(map[i, j]);

                }
                Console.WriteLine();
            }

            Console.Read();

            var node = new Node();
            var bases = mapHelper.elements.Where(x => x.GetType().Equals(typeof(Base))).ToList()[0].GetPoints();
            var treasure = mapHelper.elements.Where(x => x.GetType().Equals(typeof(Treasure))).ToList()[0];
            var minDistance = Node.GetHeuristicPathLength(bases[0], treasure.GetPoints()[0]);
            Point start = null;
            foreach (var basee in bases)
            {
                var pathLength = Node.GetHeuristicPathLength(basee, treasure.GetPoints()[0]);
                if (pathLength < minDistance)
                {
                    minDistance = pathLength;
                    start = basee;
                }
            }
            var end = treasure.GetPoints()[0];
            var pathPoints = Node.FindPath(map, start, end);

            Console.Read();
            Console.Clear();

            foreach (var point in pathPoints)
            {
                map[point.Y, point.X] = Task1Consts.PathSymbol;
            }
            Console.WriteLine();
            Console.Write(" ");
            for (int i = 0; i < mapHelper.xMax / 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(j);
                }
            }
            Console.Write(0);
            Console.WriteLine();
            k = 0;
            for (int i = 0; i < mapHelper.yMax; i++)
            {


                Console.Write(k);
                k++;
                if (k == 10)
                {
                    k = 0;
                }
                for (int j = 0; j < mapHelper.xMax; j++)
                {
                    Console.Write(map[i, j]);

                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
