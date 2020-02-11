using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotneCourses
{
    public interface IMapElement
    {
        Point[] GetPoints();
        void Parse(string line);
        string[,] FillMap(string[,] map);
    }
}
