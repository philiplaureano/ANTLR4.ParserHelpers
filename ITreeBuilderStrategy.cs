using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public interface ITreeBuilderStrategy
    {
        ITokenSource CreateTokenSource(ICharStream charStream, IEnumerable<IAntlrErrorListener<int>> errorListeners);
        ITokenStream CreateTokenStream(ITokenSource tokenSource);
        IParseTree CreateParseTree(ITokenStream tokenStream, IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners,             
            IEnumerable<IAntlrErrorListener<IToken>> errorListeners);
    }
}