using Laba1_PO.Analyzers;
using Xunit;

namespace TextAnalyzerApp.Tests
{
    public class WordCounterTests
    {
        [Fact]
        public void Analyze_EmptyText_ReturnsZero()
        {
            var counter = new WordCounter();
            var result = counter.Analyze("");
            Assert.Contains("0", result);
        }

        [Fact]
        public void Analyze_ThreeWords_ReturnsThree()
        {
            var counter = new WordCounter();
            var result = counter.Analyze("привет мир тест");
            Assert.Contains("3", result);
        }

        [Fact]
        public void Name_ReturnsCorrectName()
        {
            var counter = new WordCounter();
            Assert.Equal("Подсчёт слов", counter.Name);
        }
    }
}