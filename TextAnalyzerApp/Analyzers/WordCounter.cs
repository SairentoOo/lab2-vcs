using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_PO.Analyzers
{
    public class WordCounter : ITextAnalyzer
    {

        public string Name => "Подсчёт слов";

        public string Analyze(string text)
        {
            var words = text.Split(
                new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':' },
                StringSplitOptions.RemoveEmptyEntries);

            return $"Количество слов: {words.Length}";
        }
    }
}
