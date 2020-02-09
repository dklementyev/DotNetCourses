using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotneCourses
{
    public class Bridge : IMapElement
    {
        public int XPoint;
        public int YPoint;

        public void Parse(string line)
        {
            XPoint = Convert.ToInt16(line.Split(',')[0]);
            YPoint = Convert.ToInt16(line.Split(',')[1]);
        }

        public string[,] FillMap(string[,] map)
        {
            map[YPoint, XPoint] = Task1Consts.BridgeSymbol;
            return map;
        }
    }
}
