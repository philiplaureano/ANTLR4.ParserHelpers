using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    internal class Visitor : TreeWorker
    {
        public Visitor(ITreeBuilderStrategy treeBuilderStrategy) : base(treeBuilderStrategy)
        {
        }

        public void VisitWith<TResult>(ICharStream input, IParseTreeVisitor<TResult> parseTreeVisitor)
        {
            Func<ICharStream, IParseTree> createTree = base.CreateTree;
            var tree = createTree(input);
            if (tree != null && parseTreeVisitor != null)
                parseTreeVisitor.Visit(tree);
        }
    }
}