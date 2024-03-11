using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace BibliotekaApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Parametrs.xaml
    /// </summary>
    public partial class Parametrs : UserControl
    {
        public string Parametr { get; set; }    
        public object Value { get; set; }
        public bool isHasComboBox { get;set; }
        public string Hint { get; set; }

        private string _textSearch { get; set; }

        public bool IsVisibleHint { get; set; } = true;
        public Parametrs()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
            {
                IsVisibleHint = false;
                Trace.WriteLineIf(!IsVisibleHint, IsVisibleHint);
            }
            else
                IsVisibleHint = true;
            _textSearch = (sender as TextBox).Text;
        }
    }
}
