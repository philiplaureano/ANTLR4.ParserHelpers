using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public static class ListenerExtensions
    {
        public static void ListenTo(this IParseTreeListener listener, ICharStream input, ITreeBuilder treeBuilder,
            IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners = null, IEnumerable<IAntlrErrorListener<IToken>> errorListeners = null)
        {
            if (listener == null) 
                throw new ArgumentNullException("listener");

            if (input == null)
                throw new ArgumentNullException("input");

            if (treeBuilder == null)
                throw new ArgumentNullException("treeBuilder");


            var walker = new Walker(treeBuilder);
            walker.Walkthrough(input, listener, lexerErrorListeners ?? new IAntlrErrorListener<int>[0], errorListeners ?? new IAntlrErrorListener<IToken>[0]);
        }

        public static void ListenTo(this IParseTreeListener listener, ICharStream input, ITreeBuilderStrategy treeBuilderStrategy,
            IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners = null, IEnumerable<IAntlrErrorListener<IToken>> errorListeners = null)
        {
            if (listener == null)
                throw new ArgumentNullException("listener");

            if (input == null)
                throw new ArgumentNullException("input");

            if (treeBuilderStrategy == null)
                throw new ArgumentNullException("treeBuilderStrategy");

            var walker = new Walker(treeBuilderStrategy);
            walker.Walkthrough(input, listener, lexerErrorListeners ?? new IAntlrErrorListener<int>[0], errorListeners ?? new IAntlrErrorListener<IToken>[0]);
        }

        public static Action<ICharStream> Action<TTreeBuilderStrategy>(this IParseTreeListener listener, 
            IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners = null, IEnumerable<IAntlrErrorListener<IToken>> errorListeners = null)
            where TTreeBuilderStrategy : ITreeBuilderStrategy, new()
        {
            if (listener == null)
                throw new ArgumentNullException("listener");            

            return input => listener.ListenTo(input, new TTreeBuilderStrategy(), lexerErrorListeners ?? new IAntlrErrorListener<int>[0], errorListeners ?? new IAntlrErrorListener<IToken>[0]);
        }
    }
}