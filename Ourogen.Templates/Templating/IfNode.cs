using System.CodeDom.Compiler;

namespace Ourogen.Templates.Templating
{
    internal class IfNode : ParentNode
    {
        private readonly bool _inverted;
        private readonly ValueNode _condition;
        
        public IfNode(bool inverted, ValueNode condition)
        {
            _inverted = inverted;
            _condition = condition;
        }
        
        public override void Render(IndentedTextWriter writer)
        {
            writer.WriteLine($"if ({(_inverted ? "!" : string.Empty)}{_condition.GetSourceIdentifier()})");
            writer.WriteLine("{");
            writer.Indent++;
            base.Render(writer);
            writer.Indent--;
            writer.WriteLine("}");
        }
    }
}