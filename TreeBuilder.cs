using System;
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

        public virtual IParseTree CreateTree(ICharStream charStream)
        {
            if (charStream == null) 
                throw new ArgumentNullException("charStream");

            Func<ICharStream, ITokenSource> createTokenSource = _strategy.CreateTokenSource;
            Func<ITokenSource, ITokenStream> createTokenStream = _strategy.CreateTokenStream;
            Func<ITokenStream, IParseTree> createParseTree = _strategy.CreateParseTree;
                
            Func<IParseTree> createTree = () => createParseTree(createTokenStream(createTokenSource(charStream)));

            return createTree();
        }
    }
}