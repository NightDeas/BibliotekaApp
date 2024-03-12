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
            addorEditrBookGrid.Visibility = Visibility.Collapsed;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

       
        

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            addorEditrBookGrid.Visibility = Visibility.Collapsed;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            listParametrsStackPanel.Children.Clear();
            var book = dataGrid.SelectedItem as Book;
            if (book is null)
                return;
            titleOperationTb.Text = $"Редактирование книги #{book.Id}";
            Info info = new Info();
            var keyValuePairs = App.list.FirstOrDefault(x => x.Key == "Book");
            foreach (var item in keyValuePairs.Value)
            {
                info.Parametr = item.Key;
                info.TitleParametr = item.Value;
                switch (item.Key)
                {
                    case "Name":
                        info.Value = book.Name;
                        info.IsHasComboBox = false;
                        break;
                    case "Author.FullName":
                        info.Value = book.Author.FullName;
                        info.IsHasComboBox = true;
                        info.Hint = "Введите ФИО автора для поиска в БД";
                        break;
                    case "Publisher.Name":
                        info.Value = book.Publisher.Name;
                        info.IsHasComboBox = true;
                        info.Hint = "Введите название издательства для поиска в БД";
                        break;
                    case "Genre.Name":
                        info.Value = book.Genre.Name;
                        info.IsHasComboBox = true;
                        info.Hint = "Введите жанр для поиска в БД";
                        break;
                    case "YearOfPublication":
                        info.Value = book.YearOfPublication.ToString();
                        info.IsHasComboBox = false;
                        break;
                    default:
                        Trace.WriteLine($"Не найден параметр в словаре: {item.Key}");
                        continue;
                }
                if (string.IsNullOrEmpty(info.Parametr) || string.IsNullOrEmpty(info.Value))
                    return;
                listParametrsStackPanel.Children.Add(new UserControls.Parametrs(book, info));
            }
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            addorEditrBookGrid.Visibility = Visibility.Visible;
        }
    }
}
