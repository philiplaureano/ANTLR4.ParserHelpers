using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public static class VisitorExtensions
    {
        public static void Visit<TResult>(this IParseTreeVisitor<TResult> visitor, ICharStream input, ITreeBuilderStrategy treeBuilderStrategy)
        {
            var treeVisitor = new Visitor(treeBuilderStrategy);
            treeVisitor.VisitWith(input, visitor);
        }
    }
}