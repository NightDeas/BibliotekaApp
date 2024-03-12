using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Логика взаимодействия для Parametrs.xaml
    /// </summary>
    public partial class Parametrs : UserControl, INotifyPropertyChanged
    {
        public string Parametr { get; set; }    
        public string TitleParametr { get; set; }
        public object Value { get; set; }
        public bool isHasComboBox { get;set; }
        public string Hint { get; set; }

        private string _textSearch { get; set; }

        private Visibility _isVisibleHint = Visibility.Visible;

        public Visibility IsVisibleHint
        {
            get  => _isVisibleHint;
            private set
            {
                _isVisibleHint = value;
                OnPropertyChanged();
            }
        }



        public Parametrs()
        {
            InitializeComponent();
            DataContext = this;
            resultCb.IsEnabled = false; 
            ErrorInComboBoxLabel.Visibility = Visibility.Visible;
        }

        public Parametrs(Info info) : this()
        {
            Parametr = info.Parametr;
            TitleParametr = info.TitleParametr;
            Value = info.Value;
            this.isHasComboBox = info.IsHasComboBox;
            Hint = info.Hint;
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
                IsVisibleHint =  Visibility.Collapsed;
                //Trace.WriteLineIf(!IsVisibleHint, IsVisibleHint);
            }
            else
                IsVisibleHint = Visibility.Visible;
            _textSearch = (sender as TextBox).Text;
        }
    }
}
