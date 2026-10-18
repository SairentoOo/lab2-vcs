using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_PO.Analyzers
{
    public interface ITextAnalyzer
    {

        string Name { get; }
        string Analyze(string text);
    }
}
