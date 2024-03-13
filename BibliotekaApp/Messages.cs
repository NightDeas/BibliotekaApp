using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BibliotekaApp
{
    public static class Messages
    {


        public static TextBlock Message(TextBlock textBlock, string message, Enums.Enums.StatusMessage status)
        {
            textBlock.Text = message;
            switch (status)
            {
                case Enums.Enums.StatusMessage.Good:
                    textBlock.Foreground = new SolidColorBrush(Colors.Green);
                    break;
                case Enums.Enums.StatusMessage.Warning:
                    textBlock.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                case Enums.Enums.StatusMessage.Bad:
                    textBlock.Foreground = new SolidColorBrush(Colors.Red);
                    break;
            }
            return textBlock;
        }
    }
}
