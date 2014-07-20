using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public abstract class TreeBuilderStrategy : ITreeBuilderStrategy
    {
        public ITokenSource CreateTokenSource(ICharStream charStream, IEnumerable<IAntlrErrorListener<int>> errorListeners)
        {
            var tokenSource = CreateLexer(charStream);
            var currentListeners = errorListeners.ToArray();
            if (currentListeners.Any())
            {
                foreach (var listener in currentListeners)
                {
                    tokenSource.AddErrorListener(listener);
                }
            }

            return tokenSource;
        }

        public virtual ITokenStream CreateTokenStream(ITokenSource tokenSource)
        {
            return new CommonTokenStream(tokenSource);
        }

        public IParseTree CreateParseTree(ITokenStream tokenStream,
            IEnumerable<IAntlrErrorListener<IToken>> errorListeners)
        {
            var parser = CreateParser(tokenStream);

            var currentListeners = errorListeners.ToArray();
            if (currentListeners.Any())
            {
                foreach (var listener in currentListeners)
                {
                    parser.AddErrorListener(listener);
                }
            }

            return GetParseTree(parser);
        }

        protected abstract Lexer CreateLexer(ICharStream charStream);
        protected abstract Parser CreateParser(ITokenStream tokenStream);
        protected abstract IParseTree GetParseTree(Parser parser);
    }
}
