using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaApp.Enums
{
    public static class Enums
    {
        public enum StatusMessage
        {
            Good,
            Bad,
            Warning
        }

        public enum OperationEntity
        {
            Add,
            Edit,
            Delete
        }

        public enum SymbolSet
        {
            All,
            LetterAndSpecSymbol,
            Letter,
            NumberAndSpecSymbol,
            Number
        }
    }
}
