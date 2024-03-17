using BibliotekaApp.Entites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            {"Book", new Dictionary<PropertyInfo, string>()
                {
                    { new typeof(), "Название"},
                    { "Author.FullName", "ФИО автора"}, // ?
                    { "Publisher.Name", "Издатель"}, // ?
                    { "YearOfPublication", "Год издания"},
                    { "Genre.Name", "Жанр"}, // ?
                }
            }
        };
        public static DbContextBiblioteka Context = new DbContextBiblioteka();
        public static Type type = new Book().GetType();
        public static PropertyInfo[] infos =  type.GetProperties();

      

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.ToString());
        }
    }
}
