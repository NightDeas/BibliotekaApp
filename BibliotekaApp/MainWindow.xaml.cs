using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BibliotekaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (App.Frame.Content is Page page) { 
                titlePageLabel.Content = page.Title;
            }
            btnBack.Visibility = App.Frame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.Frame = mainFrame;
            titlePageLabel.DataContext = App.Frame;
            App.Frame.Navigate(new Pages.NavigationPage());


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (App.Frame.CanGoBack)
                App.Frame.GoBack();
        }
    }
}
