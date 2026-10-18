using System.Collections.Generic;
using Laba1_PO.Analyzers;
using Laba1_PO.Services;
using Moq;
using Xunit;

namespace TextAnalyzerApp.Tests
{
    public class TextAnalysisServiceTests
    {
        [Fact]
        public void AnalyzeText_UsesAllAnalyzers()
        {
            // Mock-объекты через Moq
            var mock1 = new Mock<ITextAnalyzer>();
            mock1.Setup(a => a.Name).Returns("Mock1");
            mock1.Setup(a => a.Analyze(It.IsAny<string>())).Returns("Result1");

            var mock2 = new Mock<ITextAnalyzer>();
            mock2.Setup(a => a.Name).Returns("Mock2");
            mock2.Setup(a => a.Analyze(It.IsAny<string>())).Returns("Result2");

            var service = new TextAnalysisService(
                new List<ITextAnalyzer> { mock1.Object, mock2.Object });

            var results = service.AnalyzeText("тест");

            Assert.Equal(2, results.Count);
            Assert.Contains("Mock1", results[0]);
            Assert.Contains("Result1", results[0]);
            Assert.Contains("Mock2", results[1]);
            Assert.Contains("Result2", results[1]);
        }

        [Fact]
        public void AnalyzeText_EmptyAnalyzers_ReturnsEmptyList()
        {
            var service = new TextAnalysisService(new List<ITextAnalyzer>());
            var results = service.AnalyzeText("тест");
            Assert.Empty(results);
        }
    }
}