using System;
using BCake.Parser;
using BcakeAcceptanceTests.Support.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BcakeAcceptanceTests.StepDefinitions
{
    [Binding]
    public class GenericTypesStepDefinitions
    {
        private ParserContext _parserContext;

        public GenericTypesStepDefinitions(ParserContext parserContext)
        {
            _parserContext = parserContext;
        }

        [Given(@"the following class is defined:")]
        public void GivenTheFollowingClassIsDefined(string multilineText)
        {
            _parserContext.AddCode(multilineText);
        }

        [When(@"the code is compiled")]
        public void WhenTheCodeIsCompiled()
        {
            _parserContext.Parser = Parser.FromMemory(_parserContext.Code);

            try
            {
                _parserContext.Parser.Parse();
            }
            catch (Exception e)
            {
                _parserContext.ParserError = e;
            }
        }

        [Then(@"there are no errors")]
        public void ThenThereAreNoErrors()
        {
            Assert.IsNull(_parserContext.ParserError);
        }

        [Given(@"the main function contains the following code:")]
        public void GivenTheMainFunctionContainsTheFollowingCode(string multilineText)
        {
            _parserContext.AddCode(@"
                int main() {
                    Collection<int> c = new Collection<int>(1337);
                    c.talk();

                    return 0;
                }
            ");
        }
    }
}
