using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcakeAcceptanceTests.Support.Context
{
    public class ParserContext
    {
        public BCake.Parser.Parser? Parser;
        public Exception? ParserError = null;
        public string Code => _code;
        private string _code = "";

        public void AddCode(string code)
        {
            _code += "\n\n" + code;
        }
    }
}
