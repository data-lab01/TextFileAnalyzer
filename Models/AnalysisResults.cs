using System.Collections.Generic;

namespace TextFileAnalyzer.Models
{
    public class AnalysisResult
    {
        public int LineCount { get; set; }
        public int WordCount { get; set; }
        public int MaxFrequency { get; set; }
        public List<string> MostFrequentWords { get; set; } = new();
    }
}
