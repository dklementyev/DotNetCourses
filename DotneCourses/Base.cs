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
        public int XStart;
        public int YStart;
        public int XFinish;
        public int YFinish;

        public void Parse(string line)
        {
            var start = line.Split(':')[0];
            var finish = line.Split(':')[1];

            XStart = Convert.ToInt16(start.Split(',')[0]);
            YStart = Convert.ToInt16(start.Split(',')[1]);

            XFinish = Convert.ToInt16(finish.Split(',')[0]);
            YFinish = Convert.ToInt16(finish.Split(',')[1]);
        }

        public string[,] FillMap(string [,] map)
        {
            for (var i = YStart; i < YFinish + 1; i++)
            {
                for (var j = XStart; j < XFinish + 1; j++)
                {
                    map[i, j] = Task1Consts.BaseSymbol;
                }
            }
            return map;
        }
    }
}
