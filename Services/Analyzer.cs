using System;
using System.Collections.Generic;
using System.Linq;
using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.Services
{
    public class Analyzer
    {
        private Dictionary<string, int> wordFrequency = new(StringComparer.OrdinalIgnoreCase);

        public AnalysisResult AnalyzeText(string[] lines)
        {
            int wordCount = 0;

            foreach (var line in lines)
            {
                var words = line.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\t' },
                                       StringSplitOptions.RemoveEmptyEntries);
                wordCount += words.Length;

                foreach (var word in words)
                {
                    if (wordFrequency.ContainsKey(word))
                        wordFrequency[word]++;
                    else
                        wordFrequency[word] = 1;
                }
            }

            int maxFreq = wordFrequency.Values.Any() ? wordFrequency.Values.Max() : 0;
            var mostFrequentWords = wordFrequency
                .Where(kvp => kvp.Value == maxFreq)
                .Select(kvp => kvp.Key)
                .ToList();

            return new AnalysisResult
            {
                LineCount = lines.Length,
                WordCount = wordCount,
                MaxFrequency = maxFreq,
                MostFrequentWords = mostFrequentWords
            };
        }

        public int SearchWordFrequency(string word)
        {
            wordFrequency.TryGetValue(word, out int count);
            return count;
        }
    }
}