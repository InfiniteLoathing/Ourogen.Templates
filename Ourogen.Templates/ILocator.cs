using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Ourogen.Templates
{
    internal interface ILocator
    {
        Location Locate(TextSpan textSpan);

        IEnumerable<Location> Locate(IEnumerable<TextSpan> textSpans);
    }
}