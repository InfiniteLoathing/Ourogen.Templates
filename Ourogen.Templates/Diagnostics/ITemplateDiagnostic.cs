using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Ourogen.Templates.Diagnostics
{
    internal interface ITemplateDiagnostic
    {
        Diagnostic CreateDiagnostic(Location location, IEnumerable<Location> additionalLocations = null);
    }
}