using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text.Tagging;

namespace Hunspellchecker.Definitions
{
    public interface IMisspellingTag : ITag
    {
        IEnumerable<string> Suggestions { get; }
    }
}
