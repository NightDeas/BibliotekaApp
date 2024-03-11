using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BibliotekaApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Frame Frame { get; set; }
        public static Dictionary<string, Dictionary<string, string>> list = new Dictionary<string, Dictionary<string, string>>()
        {
            {"Book", new Dictionary<string, string>()
                {
                    { "Name", "Название"},
                    { "Author.FullName", "ФИО автора"},
                    { "Publisher.Name", "Издатель"},
                    { "YearOfPublication", "Год издания"},
                    { "Genre.Name", "Жанр"},
                }
            }
        };
    }
}
