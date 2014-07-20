using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public class TreeBuilder : ITreeBuilder
    {
        private readonly ITreeBuilderStrategy _strategy;

        public TreeBuilder(ITreeBuilderStrategy strategy)
        {
            _strategy = strategy;
        }

        public virtual IParseTree CreateTree(ICharStream charStream, IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners, 
            IEnumerable<IAntlrErrorListener<IToken>> errorListeners)
        {
            if (charStream == null) 
                throw new ArgumentNullException("charStream");
            
            if (lexerErrorListeners == null) 
                throw new ArgumentNullException("lexerErrorListeners");
            
            if (errorListeners == null) 
                throw new ArgumentNullException("errorListeners");

            var antlrErrorListeners = lexerErrorListeners.ToArray();
            var tokenSource = _strategy.CreateTokenSource(charStream, antlrErrorListeners);
            var tokenStream = _strategy.CreateTokenStream(tokenSource);

            return _strategy.CreateParseTree(tokenStream, errorListeners);
        }
    }
}