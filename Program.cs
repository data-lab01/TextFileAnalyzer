using System;
using TextFileAnalyzer.Services;

namespace TextFileAnalyzer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter path to text file:");
            string filePath = Console.ReadLine();

            var fileReader = new FileReader();
            var analyzer = new Analyzer();

            if (!fileReader.FileExists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var lines = fileReader.ReadLines(filePath);
            var analysisResult = analyzer.AnalyzeText(lines);

            Console.WriteLine($"Lines: {analysisResult.LineCount}");
            Console.WriteLine($"Words: {analysisResult.WordCount}");
            Console.WriteLine($"Most frequent word(s) (appeared {analysisResult.MaxFrequency} times): {string.Join(", ", analysisResult.MostFrequentWords)}");

            Console.WriteLine("Enter a word to search for (or press Enter to skip):");
            string searchWord = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(searchWord))
            {
                int count = analyzer.SearchWordFrequency(searchWord);
                Console.WriteLine(count > 0
                    ? $"The word '{searchWord}' appears {count} times."
                    : $"The word '{searchWord}' does not appear in the text.");
            }
        }
    }
}