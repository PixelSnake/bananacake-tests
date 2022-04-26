using BCake.Parser.Syntax.Expressions.Nodes.Value;
using BCake.Parser.Syntax.Scopes;
using BCake.Parser.Syntax.Types;
using BCake.Runtime;
using BCake.Runtime.Nodes.Value;

namespace BcakeAcceptanceTests.Support.Context
{
    public class TestPrint : NativeFunctionType
    {
        public TestPrint(Scope scope) : base(
            scope,
            IntValueNode.Type,
            "TEST",
            new ParameterType[] {
                new ParameterType(null, StringValueNode.Type, "name"),
                new ParameterType(null, IntValueNode.Type, "value")
            }
        )
        {
            Scope.Declare(
                new ParameterType(DefiningToken, StringValueNode.Type, "name"),
                new ParameterType(DefiningToken, IntValueNode.Type, "value")
            );
        }

        public override RuntimeValueNode Evaluate(RuntimeScope scope, RuntimeValueNode[] arguments)
        {
            var name = (string)arguments[0].Value;
            var value = (int)arguments[1].Value;
            Console.WriteLine($"%%TEST%%name>{ value }<%%TEST%%");

            return null;
        }
    }
}
