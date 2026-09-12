using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Ourogen.Templates.Extensions;
using Ourogen.Templates.Syntax;
using Ourogen.Templates.Templating;

namespace Ourogen.Templates.Diagnostics
{
    internal class ValueTypeCollisionDiagnostic : ITemplateDiagnostic
    {
        private readonly ValueSyntax _syntax;
        private readonly ValueNode _node;

        public ValueTypeCollisionDiagnostic(
            ValueSyntax syntax,
            ValueNode node)
        {
            _syntax = syntax;
            _node = node;
        }
        
        public Diagnostic CreateDiagnostic(Location location, IEnumerable<Location> additionalLocations = null)
        {
            return Diagnostic.Create(
                descriptor: DiagnosticDescriptors.ValueTypeMismatch,
                location: location,
                additionalLocations: additionalLocations,
                messageArgs: new object[]
                {
                    _syntax.Identifier,
                    _syntax.ToDiagnosticTypeName(),
                    _node.ToDiagnosticTypeName()
                });
        }
    }
}