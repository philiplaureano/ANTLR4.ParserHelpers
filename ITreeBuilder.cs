using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public interface ITreeBuilder
    {
        IParseTree CreateTree(ICharStream charStream);
    }
}