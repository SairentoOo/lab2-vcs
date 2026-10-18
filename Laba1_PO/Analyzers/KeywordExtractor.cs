using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_PO.Analyzers
{
    public class KeywordExtractor : ITextAnalyzer
    {
        public string Name => "Ключевые слова";

        private static readonly HashSet<string> StopWords =
            new HashSet<string> { "и", "в", "на", "с", "по", "а", "но", "что", "это", "я", "не" };

        public string Analyze(string text)
        {
            var words = text.ToLower()
                .Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':' },
                       StringSplitOptions.RemoveEmptyEntries)
                .Where(w => !StopWords.Contains(w) && w.Length > 2)
                .ToList();

            if (words.Count == 0)
                return "Ключевые слова: (нет)";

            var top = words.GroupBy(w => w)
                           .OrderByDescending(g => g.Count())
                           .Take(3)
                           .Select(g => $"{g.Key} ({g.Count()})");

            return $"Ключевые слова: {string.Join(", ", top)}";
        }
    }
}
