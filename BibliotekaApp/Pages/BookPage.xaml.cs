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

namespace BibliotekaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        public BookPage()
        {
            InitializeComponent();
            listBookWrapPanel.Children.Add(new UserControls.BookControl("1", "2", ""));
            listBookWrapPanel.Children.Add(new UserControls.BookControl("1", "2", ""));
            listBookWrapPanel.Children.Add(new UserControls.BookControl("1", "2", ""));
            listBookWrapPanel.Children.Add(new UserControls.BookControl("1", "2", ""));
            listBookWrapPanel.Children.Add(new UserControls.BookControl("1", "2", ""));
        }
    }
}
