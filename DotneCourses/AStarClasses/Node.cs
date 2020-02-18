using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotneCourses.AStarClasses
{
    public class Node
    {

        public Point Position { get; set; }

        public int PathLengthFromStart { get; set; }

        public Node CameFrom { get; set; }

        public int HeuristicEstimatePathLength { get; set; }

        public static void PrintMap(string[,] field)
        {
            Console.WriteLine();
            Console.Write(" ");
            for (int i = 0; i < 20 / 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(j);
                }
            }
            Console.Write(0);
            Console.WriteLine();
            int k = 0;
            for (int i = 0; i < 35; i++)
            {


                Console.Write(k);
                k++;
                if (k == 10)
                {
                    k = 0;
                }
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(field[i, j]);

                }
                Console.WriteLine();
            }

            Console.Read();
        }

        public int EstimateFullPathLength
        {
            get
            {
                return this.PathLengthFromStart + this.HeuristicEstimatePathLength;
            }
        }
        private static int GetDistanceBetweenNeighbours()
        {
            return 1;
        }
        
        private static Collection<Node> GetNeighbours(Node pathNode, Point goal, string[,] field)
        {
            var result = new Collection<Node>();
            var xRange = field.GetLength(1);
            var yRange = field.GetLength(0);

            Point[] neighbourPoints = new Point[8];
            neighbourPoints[0] = new Point(pathNode.Position.X + 1, pathNode.Position.Y);
            neighbourPoints[1] = new Point(pathNode.Position.X - 1, pathNode.Position.Y);
            neighbourPoints[2] = new Point(pathNode.Position.X, pathNode.Position.Y + 1);
            neighbourPoints[3] = new Point(pathNode.Position.X, pathNode.Position.Y - 1);
            neighbourPoints[4] = new Point(pathNode.Position.X + 1, pathNode.Position.Y + 1);
            neighbourPoints[5] = new Point(pathNode.Position.X - 1, pathNode.Position.Y - 1);
            neighbourPoints[6] = new Point(pathNode.Position.X - 1, pathNode.Position.Y + 1);
            neighbourPoints[7] = new Point(pathNode.Position.X + 1, pathNode.Position.Y - 1);

            if (!neighbourPoints[0].IsOutOfRange(xRange, yRange) && !neighbourPoints[3].IsOutOfRange(xRange, yRange))
            {
                if (field[neighbourPoints[0].Y, neighbourPoints[0].X] == Task1Consts.WaterSymbol && field[neighbourPoints[3].Y, neighbourPoints[3].X] == Task1Consts.WaterSymbol)
                {
                    neighbourPoints[7].X = -155;
                }
            }
            if (!neighbourPoints[0].IsOutOfRange(xRange, yRange) && !neighbourPoints[2].IsOutOfRange(xRange, yRange))
            {
                if (field[neighbourPoints[0].Y, neighbourPoints[0].X] == Task1Consts.WaterSymbol && field[neighbourPoints[2].Y, neighbourPoints[2].X] == Task1Consts.WaterSymbol)
                {
                    neighbourPoints[4].X = -155;
                }
            }
            if (!neighbourPoints[1].IsOutOfRange(xRange, yRange) && !neighbourPoints[2].IsOutOfRange(xRange, yRange))
            {
                if (field[neighbourPoints[1].Y, neighbourPoints[1].X] == Task1Consts.WaterSymbol && field[neighbourPoints[2].Y, neighbourPoints[2].X] == Task1Consts.WaterSymbol)
                {
                    neighbourPoints[6].X = -155;
                }
            }
            if (!neighbourPoints[1].IsOutOfRange(xRange, yRange) && !neighbourPoints[3].IsOutOfRange(xRange, yRange))
            {
                if (field[neighbourPoints[1].Y, neighbourPoints[1].X] == Task1Consts.WaterSymbol && field[neighbourPoints[3].Y, neighbourPoints[3].X] == Task1Consts.WaterSymbol)
                {
                    neighbourPoints[5].X = -155;
                }
            }

            foreach (var point in neighbourPoints)
            {
                if (point.X == -155) continue;

                if (point.X < 0 || point.X >= field.GetLength(1))
                    continue;
                if (point.Y < 0 || point.Y >= field.GetLength(0))
                    continue;
                var fieldSymbol = field[point.Y, point.X];

                if (fieldSymbol == Task1Consts.WaterSymbol)
                    continue;
               
                var neighbourNode = new Node()
                {
                    Position = point,
                    CameFrom = pathNode,
                    PathLengthFromStart = pathNode.PathLengthFromStart +
                    GetDistanceBetweenNeighbours(),
                    HeuristicEstimatePathLength = GetHeuristicPathLength(point, goal)
                };
                result.Add(neighbourNode);
            }
            return result;
        }

        public static int GetHeuristicPathLength(Point from, Point to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }

        public static List<Point> FindPath(string[,] field, Point start, Point goal)
        {
            var closedSet = new Collection<Node>();

            var openSet = new Collection<Node>();
            Node startNode = new Node()
            {
                Position = start,
                CameFrom = null,
                PathLengthFromStart = 0,
                HeuristicEstimatePathLength = GetHeuristicPathLength(start, goal)
            };
            openSet.Add(startNode);
            while (openSet.Count > 0)
            {
                var currentNode = openSet.OrderBy(node =>
                  node.EstimateFullPathLength).First();
                //field[currentNode.Position.Y, currentNode.Position.X] = "?";
                //PrintMap(field);

                if (currentNode.Position == goal)
                    return GetPathForNode(currentNode);

                var nodesToDelete = openSet.Where(x => x.Position == currentNode.Position).ToList();
                foreach (var node in nodesToDelete)
                {
                    openSet.Remove(node);
                }
                closedSet.Add(currentNode);

                foreach (var neighbourNode in GetNeighbours(currentNode, goal, field))
                {

                    if (closedSet.Count(node => node.Position == neighbourNode.Position) > 0)
                        continue;
                    var openNode = openSet.FirstOrDefault(node =>
                      node.Position == neighbourNode.Position);

                    if (openNode == null)
                        openSet.Add(neighbourNode);
                    else
                      if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                    {

                        openNode.CameFrom = currentNode;
                        openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                    }
                }
            }

            return null;
        }

        private static List<Point> GetPathForNode(Node pathNode)
        {
            var result = new List<Point>();
            var currentNode = pathNode;
            while (currentNode != null)
            {
                result.Add(currentNode.Position);
                currentNode = currentNode.CameFrom;
            }
            result.Reverse();
            return result;
        }

    }
}

