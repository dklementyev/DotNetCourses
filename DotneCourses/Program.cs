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
            Console.Clear();
            Console.Write(" ");
            for (int i = 0; i < Task1Consts.YLimit/10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(j);
                }
            }
            Console.Write(0);
            Console.WriteLine();
            int k = 0;
            for (int i = 0; i < Task1Consts.YLimit; i++)
            {
                

                Console.Write(k);
                k++;
                if (k == 10)
                {
                    k = 0;
                }
                for (int j = 0; j < Task1Consts.XLimit; j++)
                {
                    Console.Write(map[i, j]);

                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
