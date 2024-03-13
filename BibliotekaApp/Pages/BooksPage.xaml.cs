using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client.NativeInterop;

namespace BibliotekaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        Book Book = new Book();

        public BooksPage()
        {
            InitializeComponent();
            addorEditrBookGrid.Visibility = Visibility.Collapsed;
        }
        private async void Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Загрузка данных", Enums.Enums.StatusMessage.Warning);
            try
            {
            dataGrid.ItemsSource = await new DbContextBiblioteka().Books
                    .Include(x => x.Author)
                    .Include(x => x.Publisher)
                    .Include(x => x.Genre)
                    .ToListAsync();
                MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Данные загружены", Enums.Enums.StatusMessage.Good);
            }
            catch (Exception)
            {
                MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Произошла ошибка при загрузке данных", Enums.Enums.StatusMessage.Bad);
            }
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
            using (var context = new DbContextBiblioteka())
            {
                context.Entry(Book).State = EntityState.Modified;
                context.SaveChanges();
            }
            MessageBox.Show("Данные сохранены");
        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            listParametrsStackPanel.Children.Clear();
            Book = dataGrid.SelectedItem as Book;
            if (Book is null)
                return;
            titleOperationTb.Text = $"Редактирование книги #{Book.Id}";
            Info info = new Info();
            var keyValuePairs = App.list.FirstOrDefault(x => x.Key == "Book");
            foreach (var item in keyValuePairs.Value)
            {
                info.Parametr = item.Key;
                info.TitleParametr = item.Value;
                switch (item.Key)
                {
                    case "Name":
                        info.Value = Book.Name;
                        info.IsHasComboBox = false;
                        break;
                    case "Author.FullName":
                        info.Value = Book.Author.FullName;
                        info.IsHasComboBox = true;
                        info.Hint = "Введите ФИО автора для поиска в БД";
                        break;
                    case "Publisher.Name":
                        info.Value = Book.Publisher.Name;
                        info.IsHasComboBox = true;
                        info.Hint = "Введите название издательства для поиска в БД";
                        break;
                    case "Genre.Name":
                        info.Value = Book.Genre.Name;
                        info.IsHasComboBox = true;
                        info.Hint = "Введите жанр для поиска в БД";
                        break;
                    case "YearOfPublication":
                        info.Value = Book.YearOfPublication.ToString();
                        info.IsHasComboBox = false;
                        break;
                    default:
                        Trace.WriteLine($"Не найден параметр в словаре: {item.Key}");
                        continue;
                }
                if (string.IsNullOrEmpty(info.Parametr) || string.IsNullOrEmpty(info.Value))
                    return;
                listParametrsStackPanel.Children.Add(new UserControls.Parametrs(Book, info));
            }
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            addorEditrBookGrid.Visibility = Visibility.Visible;
        }

     
    }
}
