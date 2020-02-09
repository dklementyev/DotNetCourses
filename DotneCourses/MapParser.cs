using System;

namespace DotneCourses
{

    public class MapParser
    {

        private readonly string[] _lines;
        public MapParser(string [] inputLines)
        {
            _lines = inputLines;
        }

        public string[,] Parse()
        {
            string[,] map = new string[Task1Consts.YLimit, Task1Consts.XLimit];
            for (int i = 0; i < Task1Consts.YLimit; i++)
            {
                for (int j = 0; j < Task1Consts.XLimit; j++)
                {
                    map[i, j] = Task1Consts.EmptySymbol;
                }
            }

            foreach (var line in _lines)
            {
                var mapElementType = line.Split(Task1Consts.MapElementSeparator)[0];
                IMapElement element;
                //Determ map element type
                switch(mapElementType)
                {
                    case Task1Consts.BaseElementType:
                        element = new Base();
                        break;
                    case Task1Consts.BridgeElementType:
                        element = new Bridge();
                        break;
                    case Task1Consts.TreasureElementType:
                        element = new Treasure();
                        break;
                    case Task1Consts.WaterElementType:
                        element = new Water();
                        break;
                    default:
                        Console.WriteLine($"Skip unsupported type: {mapElementType}");
                        element = null;
                        break;
                }
                var mapElementCoords = line.Split(Task1Consts.MapElementSeparator)[1].Replace(")", string.Empty);
                element.Parse(mapElementCoords);
                map = element.FillMap(map);
            }
            return map;
        }
    }
}
