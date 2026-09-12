using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Ourogen.Templates.Templating
{
    internal class ParentNode : ITemplateNode
    {
        public virtual void Render(IndentedTextWriter writer)
        {
            foreach (var child in Children)
            {
                child.Render(writer);
            }
        }
        
        public readonly List<ITemplateNode> Children = new List<ITemplateNode>();
    }
}
