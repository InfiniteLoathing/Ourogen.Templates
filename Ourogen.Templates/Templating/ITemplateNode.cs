using System.CodeDom.Compiler;

namespace Ourogen.Templates.Templating
{
    internal interface ITemplateNode
    {
        void Render(IndentedTextWriter writer);
    }
}