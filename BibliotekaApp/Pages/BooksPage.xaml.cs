using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
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
using BibliotekaApp.Entites;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        List<Book> books = new List<Book>();
        public BooksPage()
        {
            InitializeComponent();
            books = new Entites.DbContextBiblioteka().Books.Include(x=> x.Author).Include(x=> x.Publisher).Include(x=> x.Genre).ToList();
            dataGrid.ItemsSource = books;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            titleOperationTb.DataContext = sender as ComboBox;
            listParametrsStackPanel.Children.Clear();
            var book = dataGrid.SelectedItem as Book;
            if (book is null)
                return;

            var keyValuePairs = App.list.FirstOrDefault(x => x.Key == "Book");
            foreach (var item in keyValuePairs.Value)
            {
                string parametr = "";
                string value = "";
                switch (item.Key)
                {
                    case "Name":
                        value = book.Name;
                        break;
                    case "Author.FullName":
                        value = book.Author.FullName;
                        break;
                    case "Publisher.Name":
                        value = book.Publisher.Name;
                        break;
                    case "Genre.Name":
                        value = book.Genre.Name;
                        break;
                    case "YearOfPublication":
                        value = book.YearOfPublication.ToString();
                        break;
                    default:
                        Trace.WriteLine($"Не найден параметр в словаре: {item.Key}");
                        continue;
                }
                parametr = item.Value;
                if (string.IsNullOrEmpty(parametr) || string.IsNullOrEmpty(value))
                    return;
                listParametrsStackPanel.Children.Add(new UserControls.Parametrs()
                {
                    Parametr = parametr,
                    Value = value,
                    Hint = "Введите текст для поиска"
                });
            }
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            addorEditrBookGrid.Visibility = Visibility.Visible;



        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            addorEditrBookGrid.Visibility = Visibility.Collapsed;
        }
    }
}
