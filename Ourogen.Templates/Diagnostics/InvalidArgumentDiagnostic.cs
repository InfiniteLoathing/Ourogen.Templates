using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Ourogen.Templates.Extensions;

namespace Ourogen.Templates.Diagnostics
{
    internal class InvalidArgumentDiagnostic : ITemplateDiagnostic
    {
        private readonly string _directiveName;

        private readonly IValueDefinition _valueDefinition;
        
        public InvalidArgumentDiagnostic(string directiveName, IValueDefinition valueDefinition)
        {
            _directiveName = directiveName;
            _valueDefinition = valueDefinition;
        }

        public Diagnostic CreateDiagnostic(Location location, IEnumerable<Location> additionalLocations = null) =>
            Diagnostic.Create(
                descriptor: DiagnosticDescriptors.InvalidArgument,
                location: location,
                additionalLocations: additionalLocations,
                _directiveName,
                _valueDefinition.ToDiagnosticTypeName());
    }
}