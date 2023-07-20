using System;
using System.IO;
using System.Linq;

namespace FileHandlingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // set the directory path
            string directoryPath = @"./";

            // getting all the files in the directory
            string[] allFiles = Directory.GetFiles(directoryPath);

            //  return the number of text files
            int numTextFiles = allFiles.Count(file => file.EndsWith(".txt"));
            Console.WriteLine($"Number of text files: {numTextFiles}");

            // get the number of files per extension type
            var filesByExtension = allFiles.GroupBy(file => Path.GetExtension(file))
                .Select(group => new { Extension = group.Key, Count = group.Count() });
            foreach (var fileGroup in filesByExtension)
            {
                Console.WriteLine($"Number of {fileGroup.Extension} files: {fileGroup.Count}");
            }

            //  return the top Five largest files
            var largestFiles = allFiles.Select(file => new { Name = file, Size = new FileInfo(file).Length })
                .OrderByDescending(file => file.Size).Take(5);
            Console.WriteLine("Top 5 largest files:");
            foreach (var file in largestFiles)
            {
                Console.WriteLine($"{file.Name} - {file.Size} bytes");
            }

            // return the file with greter length
            var fileWithMaxLength = allFiles.Select(file => new { Name = file, Size = new FileInfo(file).Length })
                .OrderByDescending(file => file.Size).First();
            Console.WriteLine($"File with maximum length: {fileWithMaxLength.Name} - {fileWithMaxLength.Size} bytes");
        }
    }
}