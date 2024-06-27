                            // Pythagoras Dokpesi BU/23/8941
using System;
using System.IO;
using System.Linq;

class OfficeFileSummary
{
    static void Main()
    {
        string directoryName = "FileCollection";
        string resultsFileName = "results.txt";
        string[] officeExtensions = { ".xlsx", ".docx", ".pptx" };

        Directory.CreateDirectory(directoryName);

        int fileCount = 0;
        long totalSize = 0;

        DirectoryInfo dirInfo = new DirectoryInfo(directoryName);

        foreach (var file in dirInfo.EnumerateFiles())
        {
            if (IsOfficeFile(file.Extension, officeExtensions))
            {
                fileCount++;
                totalSize += file.Length;
            }
        }

        using (StreamWriter sw = File.CreateText(resultsFileName))
        {
            sw.WriteLine($"Total number of Office files: {fileCount}");
            sw.WriteLine($"Total size of Office files: {totalSize} bytes");
        }

        Console.WriteLine("Summary generated successfully.");
    }

    static bool IsOfficeFile(string extension, string[] officeExtensions)
    {
        return officeExtensions.Contains(extension.ToLower());
    }
}
