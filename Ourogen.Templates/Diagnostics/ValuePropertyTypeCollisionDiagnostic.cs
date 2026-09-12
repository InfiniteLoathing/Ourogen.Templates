using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Ourogen.Templates.Extensions;
using Ourogen.Templates.Syntax;
using Ourogen.Templates.Templating;

namespace Ourogen.Templates.Diagnostics
{
    
    internal class ValuePropertyTypeCollisionDiagnostic : ITemplateDiagnostic
    {
        private readonly ValueNode _parentNode;
        private readonly ValueNode _existingPropertyNode;
        private readonly ValueSyntax _newPropertySyntax;

        public ValuePropertyTypeCollisionDiagnostic(
            ValueNode parentNode,
            ValueNode existingPropertyNode,
            ValueSyntax newPropertySyntax)
        {
            _parentNode = parentNode;
            _existingPropertyNode = existingPropertyNode;
            _newPropertySyntax = newPropertySyntax;
        }

        public Diagnostic CreateDiagnostic(Location location, IEnumerable<Location> additionalLocations = null) =>
            Diagnostic.Create(
                descriptor: DiagnosticDescriptors.ValuePropertyTypeCollision,
                location: location,
                additionalLocations: additionalLocations,
                messageArgs: new object[]
                {
                    _parentNode.Identifier,
                    _existingPropertyNode.Identifier,
                    _newPropertySyntax.ToDiagnosticTypeName(),
                    _existingPropertyNode.ToDiagnosticTypeName()
                });
    }
}