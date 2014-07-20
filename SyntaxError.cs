using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace ANTLR4.ParserHelpers
{
    public class SyntaxError
    {
        private readonly IRecognizer _recognizer;
        private readonly IToken _offendingSymbol;
        private readonly int _line;
        private readonly int _charPositionInLine;
        private readonly string _message;
        private readonly RecognitionException _thrownRecognitionException;

        public SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string message, RecognitionException thrownRecognitionException)
        {
            _recognizer = recognizer;
            _offendingSymbol = offendingSymbol;
            _line = line;
            _charPositionInLine = charPositionInLine;
            _message = message;
            _thrownRecognitionException = thrownRecognitionException;
        }

        public IRecognizer Recognizer
        {
            get { return _recognizer; }
        }

        public IToken OffendingSymbol
        {
            get { return _offendingSymbol; }
        }

        public int Line
        {
            get { return _line; }
        }

        public int CharPositionInLine
        {
            get { return _charPositionInLine; }
        }

        public string Message
        {
            get { return _message; }
        }

        public RecognitionException ThrownRecognitionException1
        {
            get { return _thrownRecognitionException; }
        }
    }    
}
