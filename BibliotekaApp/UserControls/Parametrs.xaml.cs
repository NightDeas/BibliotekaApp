using BibliotekaApp.Entites;
using BibliotekaApp.Pages;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BibliotekaApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Parametrs.xaml
    /// </summary>
    public partial class Parametrs : UserControl, INotifyPropertyChanged
    {
        public string Parametr { get; set; }
        public string TitleParametr { get; set; }
        private object _value { get; set; }
        public object Value
        {
            get => _value; set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
        public bool isHasComboBox { get; set; }
        public string Hint { get; set; }

        private string _textSearch { get; set; }




        private Visibility _isVisibleHint = Visibility.Visible;

        public Visibility IsVisibleHint
        {
            get => _isVisibleHint;
            private set
            {
                _isVisibleHint = value;
                OnPropertyChanged();
            }
        }

        Book Book;

        public Parametrs()
        {
            InitializeComponent();
            DataContext = this;
            resultCb.IsEnabled = false;
            ErrorInComboBoxLabel.Visibility = Visibility.Visible;
        }

        public Parametrs(Book book, DataOfParametrPage info, bool isDelete) : this()
        {
            Parametr = info.Parametr;
            TitleParametr = info.TitleParametr;
            Value = info.Value;
            this.isHasComboBox = info.IsHasComboBox;
            Hint = info.Hint;
            Book = book;
            gridCb.Visibility = info.IsHasComboBox ? Visibility.Visible : Visibility.Collapsed;
            if (isDelete)
            {
                InputDataTextBox.IsReadOnly = true;
                errorSearchTextblock.Visibility = Visibility.Collapsed;
                ErrorInComboBoxLabel.Visibility = Visibility.Collapsed;
                ErrorInputData.Visibility = Visibility.Collapsed;
            }
            else
            {
                InputDataTextBox.IsReadOnly = isHasComboBox ? true : false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
            {
                IsVisibleHint = Visibility.Collapsed;
            }
            else
                IsVisibleHint = Visibility.Visible;
            _textSearch = (sender as TextBox).Text;
        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (Parametr)
            {
                case "Author.FullName":
                    if (_textSearch == null)
                        return;
                    string[] fio = _textSearch.Split("");
                    if (fio.Length > 3)
                    {
                        errorSearchTextblock.Text = @"Значение должно быть записано в формате""Фамилия Имя Отчество"". Например Иванов Иван Иванович";
                        return;
                    }
                    if (new Regex(@"^\S+$").IsMatch(_textSearch))
                    {
                        List<Author> authorList = new List<Author>();
                        if (fio.Length == 1)
                            authorList = await new DbContextBiblioteka().Authors.Where(x => x.LastName == fio[0]).ToListAsync();
                        if (fio.Length == 2)
                            authorList = await new DbContextBiblioteka().Authors.Where(x => x.LastName == fio[0] && x.FirstName == fio[1]).ToListAsync();
                        if (fio.Length == 3)
                            authorList = await new DbContextBiblioteka().Authors.Where(x => x.LastName == fio[0] && x.FirstName == fio[1] && x.Patronymic == fio[2]).ToListAsync();
                        if (authorList == null)
                        {
                            errorSearchTextblock = Messages.Message(errorSearchTextblock, "Ничего не найдено", Enums.Enums.StatusMessage.Bad);
                            resultCb.IsEnabled = false;
                            ErrorInComboBoxLabel.Visibility = Visibility.Visible;
                            return;
                        }
                        else
                        {
                            resultCb.ItemsSource = authorList;
                            resultCb.IsEnabled = true;
                            resultCb.DisplayMemberPath = "FullName";
                            ErrorInComboBoxLabel.Visibility = Visibility.Collapsed;
                        }
                        break;
                    }
                    else
                    {
                        errorSearchTextblock.Text = @"Значение не может содержать спец.символы или цифры, только буквы";
                        return;
                    }
                case "Publisher.Name":
                    if (new Regex(@"^\w$").IsMatch(_textSearch))
                    {
                        errorSearchTextblock = Messages.Message(errorSearchTextblock, "Значение не может содержать спец.символы или цифры, только буквы", Enums.Enums.StatusMessage.Bad);
                        return;
                    }
                    List<PublishingHouse> publishingHouseList = new List<PublishingHouse>();
                    publishingHouseList = new DbContextBiblioteka().PublishingHouses.Where(x => x.Name == _textSearch).ToList();
                    if (publishingHouseList == null)
                    {
                        errorSearchTextblock.Text = @"Ничего не найдено";
                        resultCb.IsEnabled = false;
                        ErrorInComboBoxLabel.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        resultCb.ItemsSource = publishingHouseList;
                        resultCb.IsEnabled = true;
                        resultCb.DisplayMemberPath = "Name";
                        ErrorInComboBoxLabel.Visibility = Visibility.Collapsed;
                    }
                    break;
                case "Genre.Name":
                    if (!new Regex(@"^\S+$").IsMatch(_textSearch))
                    {
                        errorSearchTextblock.Text = @"Значение не может содержать спец.символы или цифры, только буквы";
                        return;
                    }
                    List<Genre> GenreList = new List<Genre>();
                    GenreList = new DbContextBiblioteka().Genres.Where(x => x.Name == _textSearch).ToList();
                    if (GenreList.Count == 0)
                    {
                        errorSearchTextblock.Text = @"Ничего не найдено";
                        resultCb.IsEnabled = false;
                        ErrorInComboBoxLabel.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        resultCb.ItemsSource = GenreList;
                        resultCb.IsEnabled = true;
                        resultCb.DisplayMemberPath = "Name";
                        ErrorInComboBoxLabel.Visibility = Visibility.Collapsed;
                    }
                    break;
                default:
                    Trace.WriteLine($"Не найдено Parametr в словаре: {Parametr}");
                    break;
            }
        }

        private void resultCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = (sender as ComboBox).SelectedItem;
            if (selectedValue == null)
                return;

            switch (Parametr)
            {
                case "Author.FullName":
                    Value = (selectedValue as Author).FullName;
                    Book.AuthorId = (selectedValue as Author).Id;
                    Book.Author = selectedValue as Author;
                    break;
                case "Publisher.Name":
                    Value = (selectedValue as PublishingHouse).Name;
                    Book.PublisherId = (selectedValue as PublishingHouse).Id;
                    Book.Publisher = selectedValue as PublishingHouse;
                    break;
                case "Genre.Name":
                    Value = (selectedValue as Genre).Name;
                    Book.GenreId = (selectedValue as Genre).Id;
                    Book.Genre = (selectedValue as Genre);
                    break;
                case "YearOfPublication":
                    int.TryParse(InputDataTextBox.Text, out int year);
                    Book.YearOfPublication = year;
                    break;
                default:
                    Trace.WriteLine($"Не найдено Parametr в словаре: {Parametr}");
                    break;
            }
        }



        private void TextBoxInputData(object sender, TextChangedEventArgs e)
        {
            Value = (sender as TextBox).Text;
            switch (Parametr)
            {
                case "Name":
                    Book.Name = Value.ToString();
                    break;
                case "YearOfPublication":
                    int.TryParse(Value.ToString(), out int year);
                    Book.YearOfPublication = year;
                    break;
            }
        }

        private void InputDataTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            switch (Parametr)
            {
                case "YearOfPublication":
                    if (!new Regex(@"^\d$").IsMatch(e.Text))
                    {
                        ErrorInputData.Text = "Здесь разрешено писать только цифры";
                        e.Handled = true;
                    }
                    else
                    {
                        ErrorInputData.Text = "";
                    }
                    return;
            }
        }
    }
}
