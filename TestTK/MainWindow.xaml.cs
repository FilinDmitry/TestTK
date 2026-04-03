using System;
using System.Collections.Generic;
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

namespace TestTK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string defaultText = "Стоимость билетов с учетом комфортабельности: ";
        int ticketClass = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            switch (rb.Content)
            {
                case "плацкарт":
                    ticketClass = 0;
                    break;
                case "купе":
                    ticketClass = 1;
                    break;
                case "полулюкс":
                    ticketClass = 2;
                    break;
                case "люкс":
                    ticketClass = 3;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB_result.Text = defaultText + Calculations.TicketPrice(TB_dist.Text, TB_kol.Text, ticketClass).ToString("N2") + "руб.";
        }

        

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Name == "TB_kol")
            {
                e.Handled = !char.IsDigit(e.Text[0]);
            }
            else
            {
                e.Handled = !char.IsDigit(e.Text[0]) && e.Text[0] != ',' && e.Text[0] != '.';
            }
        }
    }
}
