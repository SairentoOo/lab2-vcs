using System.Linq;

namespace Laba1_PO.Analyzers
{
    // Новый узел — добавлен без изменения TextAnalysisService.
    public class LanguageDetector : ITextAnalyzer
    {
        public string Name
        {
            get { return "Определение языка"; }
        }

        public string Analyze(string text)
        {
            bool hasCyrillic = text.Any(c => c >= 'А' && c <= 'я');
            string lang = hasCyrillic ? "русский" : "английский";
            return "Язык текста: " + lang;
        }
    }
}