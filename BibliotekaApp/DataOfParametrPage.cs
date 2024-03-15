using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BibliotekaApp
{
    public class DataOfParametrPage
    {
        public string Parametr { get; set; }
        public string TitleParametr { get;set; }
        public string Value { get; set; }
        public bool IsHasComboBox { get; set; }
        // значение если null
        public string Hint { get; set; }
    }
}
