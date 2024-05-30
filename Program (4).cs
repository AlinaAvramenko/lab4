using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string sourceDir;
        string targetDir;

        if (args.Length >= 2)
        {
            sourceDir = args[0];
            targetDir = args[1];
        }
        else
        {
            Console.WriteLine("Enter the path to the source directory:");
            sourceDir = Console.ReadLine();

            Console.WriteLine("Enter the path to the target directory:");
            targetDir = Console.ReadLine();
        }

        if (!Directory.Exists(sourceDir))
        {
            Console.WriteLine("Error! The specified source directory does not exist!");
            Environment.ExitCode = 1;
            Console.WriteLine("The program ended with the code 1");
            return;
        }

        if (!Directory.Exists(targetDir))
        {
            Console.WriteLine("Error! The specified target directory does not exist!");
            Environment.ExitCode = 1;
            Console.WriteLine("The program ended with the code 1");
            return;
        }

        Console.WriteLine("Enter a pattern to search for files (for example, *.exe or *.txt):");
        string searchPattern = Console.ReadLine();

        try
        {
            string[] files = Directory.GetFiles(sourceDir, searchPattern, SearchOption.AllDirectories);
            long totalSize = CalculateTotalSize(files);

            Console.WriteLine($"The total amount of files in the directory: {totalSize} bytes");
            Environment.ExitCode = 0;
            Console.WriteLine("The program ended with the code 0");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Environment.ExitCode = 1;
            Console.WriteLine("The program ended with the code 0");
        }
    }

    static long CalculateTotalSize(string[] files)
    {
        long totalSize = 0;

        foreach (string file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            totalSize += fileInfo.Length;
        }

        return totalSize;
    }
}