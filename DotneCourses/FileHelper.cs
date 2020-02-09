using System;
using System.IO;
using System.Linq;

namespace DotneCourses
{
    public class FileHelper
    {

        public string[] LinesFromFile;

        public FileHelper(string filePath)
        {
            LinesFromFile = File.ReadAllLines(filePath);
            PreprocessLines(LinesFromFile);
        }

        private void PreprocessLines(string[] lines)
        {
            var linesAfterProcessing = lines.Select(x => x.ToLower().Trim().Replace(" ", string.Empty)).ToArray();

            Console.WriteLine(string.Join(System.Environment.NewLine, linesAfterProcessing));
            LinesFromFile = linesAfterProcessing;
            Console.WriteLine();
        }
    }
}
