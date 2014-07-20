using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    internal class Walker : TreeWorker
    {
        public Walker(ITreeBuilder treeBuilder)
            : base(treeBuilder)
        {
        }

        public Walker(ITreeBuilderStrategy treeBuilderStrategy)
            : base(new TreeBuilder(treeBuilderStrategy))
        {
        }

        public void Walkthrough(ICharStream input, IParseTreeListener listener)
        {
            if (input == null) 
                throw new ArgumentNullException("input");

            if (listener == null) 
                throw new ArgumentNullException("listener");

            var tree = CreateTree(input);
            var walker = new ParseTreeWalker();
            walker.Walk(listener, tree);
        }
    }
}