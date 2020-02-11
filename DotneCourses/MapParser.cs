using System;
using System.Collections.Generic;

namespace DotneCourses
{

    public class MapParser
    {

        private readonly string[] _lines;
        public int xMax;
        public int yMax;
        public List<IMapElement> elements;
        public MapParser(string [] inputLines)
        {
            _lines = inputLines;
        }

        public string[,] Parse()
        {

            elements = new List<IMapElement>();

            foreach (var line in _lines)
            {
                var mapElementType = line.Split(Task1Consts.MapElementSeparator)[0];
                var mapElementCoords = line.Split(Task1Consts.MapElementSeparator)[1].Replace(")", string.Empty);

                //Determ map element type
                switch (mapElementType)
                {
                    case Task1Consts.BaseElementType:
                        var basee = new Base();
                        basee.Parse(mapElementCoords);
                        elements.Add(basee);
                        break;
                    case Task1Consts.BridgeElementType:
                        var bridge = new Bridge();
                        bridge.Parse(mapElementCoords);
                        elements.Add(bridge);
                        break;
                    case Task1Consts.TreasureElementType:
                        var treasure = new Treasure();
                        treasure.Parse(mapElementCoords);
                        elements.Add(treasure);
                        break;
                    case Task1Consts.WaterElementType:
                        var water = new Water();
                        water.Parse(mapElementCoords);
                        elements.Add(water);
                        break;
                    default:
                        Console.WriteLine($"Skip unsupported type: {mapElementType}");
                        break;
                }
            }
            xMax = 0;
            yMax = 0;
            foreach (var el in elements)
            {
                var points = el.GetPoints();
                foreach (var point in points)
                {
                    if (point.X > xMax) xMax = point.X;
                    if (point.Y > yMax) yMax = point.Y;
                }
            }
            xMax += 1;
            yMax += 1;
            string[,] map = new string[yMax, xMax];
            for (int i = 0; i < yMax; i++)
            {
                for (int j = 0; j < xMax; j++)
                {
                    map[i, j] = Task1Consts.EmptySymbol;
                }
            }

            foreach (var el in elements)
            {
                map = el.FillMap(map);
            }



            return map;
        }


    }
}
