using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace BibliotekaApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для BookControl.xaml
    /// </summary>
    public partial class BookControl : UserControl
    {
        string _bookName;
        string _authorName;
        string _sourceName;
        public string BookName {  get; set; }
        public string AuthorName {  get; set; }
        public string SourceImage {  get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public BookControl()
        {
            InitializeComponent();
            DataContext = this;
            BookImage.Source = new BitmapImage(new Uri(@"/Resources/Нет_фото.png", UriKind.RelativeOrAbsolute));
        }

        public BookControl(string bookName, string authorName, string sourceImage) : this()
        {
            BookName = bookName;
            AuthorName = authorName;
            SourceImage = sourceImage;
        }
    }
}
