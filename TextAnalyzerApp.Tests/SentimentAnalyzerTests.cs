using Laba1_PO.Analyzers;
using Xunit;

namespace TextAnalyzerApp.Tests
{
    public class SentimentAnalyzerTests
    {
        [Fact]
        public void Analyze_PositiveText_ReturnsPositive()
        {
            var analyzer = new SentimentAnalyzer();
            var result = analyzer.Analyze("Сегодня отличная погода, я рад");
            Assert.Contains("позитивная", result);
        }

        [Fact]
        public void Analyze_NegativeText_ReturnsNegative()
        {
            var analyzer = new SentimentAnalyzer();
            var result = analyzer.Analyze("Ужасная погода, всё плохо");
            Assert.Contains("негативная", result);
        }

        [Fact]
        public void Analyze_EmptyText_ReturnsNeutral()
        {
            var analyzer = new SentimentAnalyzer();
            var result = analyzer.Analyze("");
            Assert.Contains("нейтральная", result);
        }
    }
}