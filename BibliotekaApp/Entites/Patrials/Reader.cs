using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaApp.Entites
{
    public partial class Reader
    {
        public int Age => (int)(DateTime.Now.Date - DateOfBirth.Date).TotalDays / 30 / 365;
    }
}
