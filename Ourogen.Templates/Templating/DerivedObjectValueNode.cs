using Microsoft.CodeAnalysis.Text;
using Ourogen.Templates.Syntax;

namespace Ourogen.Templates.Templating
{
    internal class DerivedObjectValueNode : ValueNode
    {
        private readonly ValueNode _original;
        
        public DerivedObjectValueNode(string identifier, TextSpan textSpan, ValueNode original)
            : base(identifier, textSpan, ValueType.Object)
        {
            _original = original;
        }

        public override bool TryGetProperty(string identifier, out ValueNode property)
        {
            if (this.Properties.TryGetValue(identifier, out property))
            {
                return true;
            }

            if (_original.TryGetProperty(identifier, out var originalProperty))
            {
                property = new ValueNode(
                    this.GetSourceIdentifier(),
                    originalProperty.Identifier,
                    originalProperty.TextSpan,
                    originalProperty.Type,
                    originalProperty.IsArray);
                this.Properties.Add(identifier, property);
                return true;
            }

            return false;
        }

        public override ValueNode AddProperty(ValueSyntax valueSyntax)
        {
            var property = new ValueNode(
                this.GetSourceIdentifier(),
                valueSyntax.Identifier,
                valueSyntax.TextSpan,
                valueSyntax.Type,
                valueSyntax.IsArray);
            
            this.Properties.Add(valueSyntax.Identifier, property);
            _original.AddProperty(valueSyntax);
            return property;
        }
    }
}