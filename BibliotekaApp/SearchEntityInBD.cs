using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace BibliotekaApp
{
    public static class SearchEntityInBD
    {


        // Поиск "всё или ничего одного типа"
        public static void SearchAllDataOneType(Type type)
        {
            var table = App.Context.Model.GetEntityTypes().FirstOrDefault().GetTableMappings();
        }
    }
}
