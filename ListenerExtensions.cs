using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public static class ListenerExtensions
    {
        public static void ListenTo(this IParseTreeListener listener, ICharStream input, ITreeBuilder treeBuilder)
        {
            if (listener == null) 
                throw new ArgumentNullException("listener");

            if (input == null)
                throw new ArgumentNullException("input");

            if (treeBuilder == null)
                throw new ArgumentNullException("treeBuilder");

            var walker = new Walker(treeBuilder);
            walker.Walkthrough(input, listener);
        }

        public static void ListenTo(this IParseTreeListener listener, ICharStream input, ITreeBuilderStrategy treeBuilderStrategy)
        {
            if (listener == null)
                throw new ArgumentNullException("listener");

            if (input == null)
                throw new ArgumentNullException("input");

            if (treeBuilderStrategy == null)
                throw new ArgumentNullException("treeBuilderStrategy");

            var walker = new Walker(treeBuilderStrategy);
            walker.Walkthrough(input, listener);
        }

        public static Action<ICharStream> Action<TTreeBuilderStrategy>(this IParseTreeListener listener)
            where TTreeBuilderStrategy : ITreeBuilderStrategy, new()
        {
            if (listener == null)
                throw new ArgumentNullException("listener");

            return input => listener.ListenTo(input, new TTreeBuilderStrategy());
        }
    }
}