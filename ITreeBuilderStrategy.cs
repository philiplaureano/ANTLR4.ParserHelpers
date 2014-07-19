using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public interface ITreeBuilderStrategy
    {
        ITokenSource CreateTokenSource(ICharStream charStream);
        ITokenStream CreateTokenStream(ITokenSource tokenSource);
        IParseTree CreateParseTree(ITokenStream tokenStream);
    }
}