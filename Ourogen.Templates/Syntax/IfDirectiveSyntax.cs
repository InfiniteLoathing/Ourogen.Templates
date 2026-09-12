namespace Ourogen.Templates.Syntax
{
    internal class IfDirectiveSyntax : DirectiveSyntax
    {
        public override bool IsValid => this.Condition != null;

        public override DirectiveSyntaxKind Kind => DirectiveSyntaxKind.If;
        
        public bool Inverted { get; }

        public ValueSyntax Condition { get; }

        public IfDirectiveSyntax(bool inverted, ValueSyntax condition)
        {
            this.Inverted = inverted;
            this.Condition = condition;
        }
    }
}