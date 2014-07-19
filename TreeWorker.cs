using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    internal abstract class TreeWorker
    {
        private readonly ITreeBuilderStrategy _treeBuilderStrategy;

        protected TreeWorker(ITreeBuilderStrategy treeBuilderStrategy)
        {
            _treeBuilderStrategy = treeBuilderStrategy;
        }

        protected virtual IParseTree CreateTree(ICharStream input)
        {
            var builder = new TreeBuilder(_treeBuilderStrategy);
            var tree = builder.CreateTree(input);

            return tree;
        }
    }
}