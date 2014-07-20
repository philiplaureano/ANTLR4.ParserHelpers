using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public static class ListenerExtensions
    {
        public static void ListenTo(this IParseTreeListener listener, ICharStream input, ITreeBuilder treeBuilder,
            IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners, IEnumerable<IAntlrErrorListener<IToken>> errorListeners)
        {
            if (listener == null) 
                throw new ArgumentNullException("listener");

            if (input == null)
                throw new ArgumentNullException("input");

            if (treeBuilder == null)
                throw new ArgumentNullException("treeBuilder");

            if (lexerErrorListeners == null) 
                throw new ArgumentNullException("lexerErrorListeners");
            
            if (errorListeners == null) 
                throw new ArgumentNullException("errorListeners");

            var walker = new Walker(treeBuilder);
            walker.Walkthrough(input, listener, lexerErrorListeners, errorListeners);
        }

        public static void ListenTo(this IParseTreeListener listener, ICharStream input, ITreeBuilderStrategy treeBuilderStrategy,
            IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners, IEnumerable<IAntlrErrorListener<IToken>> errorListeners)
        {
            if (listener == null)
                throw new ArgumentNullException("listener");

            if (input == null)
                throw new ArgumentNullException("input");

            if (treeBuilderStrategy == null)
                throw new ArgumentNullException("treeBuilderStrategy");

            if (lexerErrorListeners == null)
                throw new ArgumentNullException("lexerErrorListeners");

            if (errorListeners == null)
                throw new ArgumentNullException("errorListeners");

            var walker = new Walker(treeBuilderStrategy);
            walker.Walkthrough(input, listener, lexerErrorListeners, errorListeners);
        }

        public static Action<ICharStream> Action<TTreeBuilderStrategy>(this IParseTreeListener listener, 
            IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners, IEnumerable<IAntlrErrorListener<IToken>> errorListeners)
            where TTreeBuilderStrategy : ITreeBuilderStrategy, new()
        {
            if (listener == null)
                throw new ArgumentNullException("listener");
            
            if (lexerErrorListeners == null)
                throw new ArgumentNullException("lexerErrorListeners");

            if (errorListeners == null)
                throw new ArgumentNullException("errorListeners");

            return input => listener.ListenTo(input, new TTreeBuilderStrategy(), lexerErrorListeners, errorListeners);
        }
    }
}