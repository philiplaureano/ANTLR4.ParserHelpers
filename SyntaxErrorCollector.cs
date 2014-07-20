using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace ANTLR4.ParserHelpers
{
    public class SyntaxErrorCollector : BaseErrorListener, IObservable<SyntaxError>
    {
        private readonly ReplaySubject<SyntaxError> _syntaxErrorSubject = new ReplaySubject<SyntaxError>();

        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            var error = new SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
            _syntaxErrorSubject.OnNext(error);
        }

        public IDisposable Subscribe(IObserver<SyntaxError> observer)
        {
            return _syntaxErrorSubject.SubscribeSafe(observer);
        }
    }
}
