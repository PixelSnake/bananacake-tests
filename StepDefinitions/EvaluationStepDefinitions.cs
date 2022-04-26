using BcakeAcceptanceTests.Support.Context;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace BcakeAcceptanceTests.StepDefinitions
{
    [Binding]
    public class EvaluationStepDefinitions
    {
        private ParserContext _parserContext;

        public EvaluationStepDefinitions(ParserContext parserContext)
        {
            _parserContext = parserContext;
        }

        [Then(@"""([^""]*)"" evaluates to ([0-9]+)")]
        public void ThenEvaluatesTo(string name, string value)
        {
            TestLogCompare<int>(name, value);
        }

        private void TestLogCompare<T>(string name, string expected)
        {
            Assert.IsNotNull(expected);
            if (expected == null) return; // to please the compiler

            if (typeof(T) == typeof(string))
                TestLogCompare(name, expected, str => str);
            else if (typeof(T) == typeof(int))
                TestLogCompare<int>(name, expected, str => int.Parse(str));
        }

        private void TestLogCompare<T>(string name, string expected, Func<string, T> convert)
        {
            var pattern = @"<%%TEST:([^%]+)%%>(.*)</%%TEST%%>";
            var options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(_parserContext.Output, pattern, options))
            {
                // Console.WriteLine(m.Groups[1].Value + " = " + m.Groups[2].Value);
                if (m.Groups[1].Value == name) Assert.AreEqual(convert(expected), convert(m.Groups[2].Value));
            }
        }
    }
}