using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public static class ListenerExtensions
    {
        public static void ListenTo(this IParseTreeListener listener, ICharStream input, ITreeBuilderStrategy treeBuilderStrategy)
        {
            var walker = new Walker(treeBuilderStrategy);
            walker.Walkthrough(input, listener);
        }

        public static Action<ICharStream> Action<TTreeBuilderStrategy>(this IParseTreeListener listener)
            where TTreeBuilderStrategy : ITreeBuilderStrategy, new()
        {
            return input => listener.ListenTo(input, new TTreeBuilderStrategy());
        }
    }
}