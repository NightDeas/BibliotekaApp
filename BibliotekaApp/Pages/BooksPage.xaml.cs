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
using static BibliotekaApp.Enums.Enums;

namespace BibliotekaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public bool IsHasErrorInInputData = false;
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
            Enums.Enums.OperationEntity operation = (OperationEntity)(sender as Button).Tag;
            
            //if (IsHasErrorInInputData)
            //{
            //    btnSave.IsEnabled = false;
            //    Messages.Message(MessageProgressTextBlock, "Невозможно сохранить данные, т.к обнаружены ошибки", Enums.Enums.StatusMessage.Bad);
            //    return;
            //}

            switch (operation)
            {
                case OperationEntity.Add:
                    AddEntity();
                    break;
                case OperationEntity.Edit:
                    EditEntity();
                    break;
                case OperationEntity.Delete:
                    DeleteEntity();
                    break;
                default:
                    throw new Exception();
            }
        }

        private void AddEntity()
        {
            try
            {
                App.Context.Entry(Book).State = EntityState.Added;
                App.Context.SaveChanges();
                MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Данные добавлены", StatusMessage.Good);
            }
            catch (Exception)
            {
                MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Ошибка при добавлении данных", StatusMessage.Bad);
            }
        }

        private void EditEntity()
        {
            try
            {
                App.Context.Entry(Book).State = EntityState.Modified;
                App.Context.SaveChanges();
                MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Данные изменены", StatusMessage.Good);
            }
            catch (Exception)
            {
                MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Ошибка при редактировании данных", StatusMessage.Bad);
            }
        }

        private void DeleteEntity()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите списать книгу?", "Предупреждение", MessageBoxButton.YesNo);
                if (result != MessageBoxResult.Yes)
                {
                    MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Удаление данных не завершена", StatusMessage.Warning);
                    return;
                }
                App.Context.Entry(Book).State = EntityState.Deleted;
                App.Context.SaveChanges();
                MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Удаление данных завершена", StatusMessage.Good);
            }
            catch (Exception)
            {
                MessageProgressTextBlock = Messages.Message(MessageProgressTextBlock, "Ошибка при удалении данных", StatusMessage.Bad);
            }
        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            GenerateStackPanel("Book", Enums.Enums.OperationEntity.Edit);
            btnSave.Tag = Enums.Enums.OperationEntity.Edit;
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            GenerateStackPanel("Book", Enums.Enums.OperationEntity.Delete);
            btnSave.Tag = Enums.Enums.OperationEntity.Delete;
        }

        // Book
        private void GenerateStackPanel(string key, Enums.Enums.OperationEntity operation)
        {
            Book = dataGrid.SelectedItem as Book;
            switch (operation)
            {
                case OperationEntity.Add:
                    btnSave.Content = "Добавить";
                    titleOperationTb.Text = $"Добавление книги";
                    Book = new();
                    break;
                case Enums.Enums.OperationEntity.Edit:
                    btnSave.Content = "Редактировать";
                    titleOperationTb.Text = $"Редактирование книги #{Book.Id}";
                    break;
                case Enums.Enums.OperationEntity.Delete:
                    btnSave.Content = "Удалить";
                    titleOperationTb.Text = $"Удаление книги #{Book.Id}";
                    break;
                default:
                    break;
            }
            listParametrsStackPanel.Children.Clear();
            Info info = new Info();
            var keyValuePairs = App.list.FirstOrDefault(x => x.Key == key);
            foreach (var item in keyValuePairs.Value)
            {

                info.Parametr = item.Key;
                info.TitleParametr = item.Value;
                if (operation == OperationEntity.Edit || operation == OperationEntity.Delete)
                {
                    switch (item.Key)
                    {
                        case "Name":
                            info.Value = Book.Name ?? "";
                            info.IsHasComboBox = false;
                            break;
                        case "Author.FullName":
                            info.Value = Book.Author.FullName ?? "";
                            info.IsHasComboBox = true;
                            info.Hint = "Введите ФИО автора для поиска в БД";
                            break;
                        case "Publisher.Name":
                            info.Value = Book.Publisher.Name ?? "";
                            info.IsHasComboBox = true;
                            info.Hint = "Введите название издательства для поиска в БД";
                            break;
                        case "Genre.Name":
                            info.Value = Book.Genre.Name ?? "";
                            info.IsHasComboBox = true;
                            info.Hint = "Введите жанр для поиска в БД";
                            break;
                        case "YearOfPublication":
                            info.Value = Book.YearOfPublication.ToString() ?? "";
                            info.IsHasComboBox = false;
                            break;
                        default:
                            Trace.WriteLine($"Не найден параметр в словаре: {item.Key}");
                            continue;
                    }
                }
                else
                {
                    switch (item.Key)
                    {
                        case "Name":
                            info.IsHasComboBox = false;
                            break;
                        case "Author.FullName":
                            info.IsHasComboBox = true;
                            info.Hint = "Введите ФИО автора для поиска в БД";
                            break;
                        case "Publisher.Name":
                            info.IsHasComboBox = true;
                            info.Hint = "Введите название издательства для поиска в БД";
                            break;
                        case "Genre.Name":
                            info.IsHasComboBox = true;
                            info.Hint = "Введите жанр для поиска в БД";
                            break;
                        case "YearOfPublication":
                            info.IsHasComboBox = false;
                            break;
                        default:
                            Trace.WriteLine($"Не найден параметр в словаре: {item.Key}");
                            continue;
                    }
                }
                if (string.IsNullOrEmpty(info.Parametr))
                    return;
                listParametrsStackPanel.Children.Add(new UserControls.Parametrs(Book, info, this));
            }
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            addorEditrBookGrid.Visibility = Visibility.Visible;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GenerateStackPanel("Book", OperationEntity.Add);
            btnSave.Tag = Enums.Enums.OperationEntity.Add;
        }
    }
}
