using Laba1_PO.Analyzers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_PO.Services
{
    public class TextAnalysisService
    {
        private readonly IEnumerable<ITextAnalyzer> _analyzers;

        // Внедрение зависимостей через конструктор.
        public TextAnalysisService(IEnumerable<ITextAnalyzer> analyzers)
        {
            _analyzers = analyzers;
        }

        // Возвращаем список строк — форму это устроит, а сервис не знает про UI.
        public List<string> AnalyzeText(string text)
        {
            var results = new List<string>();
            foreach (var analyzer in _analyzers)
            {
                results.Add($"[{analyzer.Name}] {analyzer.Analyze(text)}");
            }
            return results;
        }
    }
}
