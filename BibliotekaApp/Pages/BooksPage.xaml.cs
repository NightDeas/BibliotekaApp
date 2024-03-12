﻿using System;
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
                        info.Hint = "Введите ФИО автора";
                        break;
                    case "Publisher.Name":
                        info.Value = book.Publisher.Name;
                        info.IsHasComboBox = true;
                        info.Hint = "Введите название издательства";
                        break;
                    case "Genre.Name":
                        info.Value = book.Publisher.Name;
                        info.IsHasComboBox = true;
                        info.Hint = "Введите жанр";
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
                listParametrsStackPanel.Children.Add(new UserControls.Parametrs(info));
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
