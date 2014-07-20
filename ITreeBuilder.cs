using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public interface ITreeBuilder
    {
        IParseTree CreateTree(ICharStream charStream, IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners, 
            IEnumerable<IAntlrErrorListener<IToken>> errorListeners);
    }
}