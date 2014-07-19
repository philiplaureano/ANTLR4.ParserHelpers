using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    internal class Walker : TreeWorker
    {
        public Walker(ITreeBuilderStrategy treeBuilderStrategy) : base(treeBuilderStrategy)
        {
        }

        public void Walkthrough(ICharStream input, IParseTreeListener listener)
        {
            var tree = CreateTree(input);
            var walker = new ParseTreeWalker();
            walker.Walk(listener, tree);
        }
    }
}