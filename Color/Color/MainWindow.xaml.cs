using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Color
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
            Random rnd = new Random();
            bool yes = true;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Console.Out.WriteLine("cba");
            Console.Out.WriteLine("abc");
            int r = rnd.Next(0, 256);
            int g = rnd.Next(0, 256);
            int b = rnd.Next(0, 256);
            tlo.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(150, (byte)r, (byte)g, (byte)b));

        }
    }
}
