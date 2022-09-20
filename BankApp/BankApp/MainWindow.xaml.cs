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

namespace BankApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int number = 15;
            number = number + 10;
            number = 36 * 15;

            output.Text = number.ToString();

            int count = 0;
            count++;
            count--;

            string result = "czesc";
            result += " i znowu " + result;
            output.Text = result;

            result = "wartosc wynosi: " + count;
            result = "";
            bool yesNo = false;
            bool yesNo2 = true;
            yesNo2 = !yesNo;

        }
    }
}
