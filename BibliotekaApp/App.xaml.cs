using BibliotekaApp.Entites;
using System;
using System.Reflection;
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
        public static DbContextBiblioteka Context = new DbContextBiblioteka();
        public static Type type = new Book().GetType();
        public static PropertyInfo[] infos = type.GetProperties();



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
