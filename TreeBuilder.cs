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

            Func<ICharStream, IEnumerable<IAntlrErrorListener<int>>, ITokenSource> createTokenSource = 
                _strategy.CreateTokenSource;
            Func<ITokenSource, ITokenStream> createTokenStream = _strategy.CreateTokenStream;
            Func<ITokenStream, IEnumerable<IAntlrErrorListener<IToken>>, IParseTree> createParseTree = _strategy.CreateParseTree;
                
            Func<IParseTree> createTree = () =>
            {
                IAntlrErrorListener<int>[] antlrErrorListeners = lexerErrorListeners.ToArray();

                ITokenSource tokenSource = createTokenSource(charStream, antlrErrorListeners);
                ITokenStream tokenStream = createTokenStream(tokenSource);
                return createParseTree(tokenStream, errorListeners);
            };

            return createTree();
        }
    }
}