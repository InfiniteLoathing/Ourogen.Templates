using System.Linq;
using Microsoft.CodeAnalysis;

namespace Ourogen.Templates.Syntax
{
    internal static class RootValidator
    {
        private const string UnclosedRegionId = "CS1038"; 
        
        public static bool RegionsAreValid(SyntaxNode syntaxNode) =>
            syntaxNode.GetDiagnostics().All(x => x.Id != UnclosedRegionId);
    }
}