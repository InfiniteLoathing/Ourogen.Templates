namespace Ourogen.Templates.Syntax
{
    internal abstract class DirectiveSyntax
    {
        public virtual bool IsValid => true;
        
        public abstract DirectiveSyntaxKind Kind { get; }
    }
}