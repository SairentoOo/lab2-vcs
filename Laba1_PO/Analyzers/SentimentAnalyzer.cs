using System;
using System.Linq;

namespace Laba1_PO.Analyzers
{
    public class SentimentAnalyzer : ITextAnalyzer
    {
        public string Name => "Анализ тональности";

        // Основы слов (без окончаний)
        private static readonly string[] PositiveStems =
            { "хорош", "отличн", "прекрасн", "супер", "радост", "рад", "счастлив" };

        private static readonly string[] NegativeStems =
            { "плох", "ужасн", "отврат", "груст", "проблем", "бед" };

        public string Analyze(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "Тональность: нейтральная (+0 / -0)";

            // Разбиваем текст на отдельные слова
            var words = text.ToLower()
                .Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':', '-', '(', ')' },
                       StringSplitOptions.RemoveEmptyEntries);

            // Проверяем, начинается ли каждое ОТДЕЛЬНОЕ слово с одной из основ
            int positive = words.Count(word => PositiveStems.Any(stem => word.StartsWith(stem)));
            int negative = words.Count(word => NegativeStems.Any(stem => word.StartsWith(stem)));

            string sentiment = positive > negative ? "позитивная"
                             : negative > positive ? "негативная"
                             : "нейтральная";

            return $"Тональность: {sentiment} (+{positive} / -{negative})";
        }
    }
}