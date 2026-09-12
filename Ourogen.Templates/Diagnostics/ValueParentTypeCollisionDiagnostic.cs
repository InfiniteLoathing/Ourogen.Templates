using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Ourogen.Templates.Extensions;
using Ourogen.Templates.Syntax;
using Ourogen.Templates.Templating;

namespace Ourogen.Templates.Diagnostics
{
    internal class ValueParentTypeCollisionDiagnostic : ITemplateDiagnostic
    {
        private readonly ValueParentSyntax _syntax;
        private readonly ValueNode _node;

        public ValueParentTypeCollisionDiagnostic(
            ValueParentSyntax syntax,
            ValueNode node)
        {
            _syntax = syntax;
            _node = node;
        }

        public Diagnostic CreateDiagnostic(Location location, IEnumerable<Location> additionalLocations = null) =>
            Diagnostic.Create(
                descriptor: DiagnosticDescriptors.ValueParentTypeCollision,
                location: location,
                additionalLocations: additionalLocations,
                messageArgs: new object[]
                {
                    _syntax.Identifier,
                    _node.ToDiagnosticTypeName()
                });
    }
}