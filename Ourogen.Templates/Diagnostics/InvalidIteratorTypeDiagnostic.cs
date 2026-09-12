using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Ourogen.Templates.Extensions;

namespace Ourogen.Templates.Diagnostics
{
    internal class InvalidIteratorTypeDiagnostic : ITemplateDiagnostic
    {
        private readonly IValueDefinition _iteratorDefinition;
        private readonly IValueDefinition _arrayDefinition;

        public InvalidIteratorTypeDiagnostic(IValueDefinition iteratorDefinition, IValueDefinition arrayDefinition)
        {
            _iteratorDefinition = iteratorDefinition;
            _arrayDefinition = arrayDefinition;
        }

        public Diagnostic CreateDiagnostic(Location location, IEnumerable<Location> additionalLocations = null) =>
            Diagnostic.Create(
                descriptor: DiagnosticDescriptors.InvalidIteratorType,
                location: location,
                additionalLocations: additionalLocations,
                _iteratorDefinition.ToDiagnosticTypeName(),
                _arrayDefinition.ToDiagnosticTypeName());
    }
}