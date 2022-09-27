using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace odczyt_zapis
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string folder = "C:\\Users\\Admin\\Source\\Repos\\praktyki\\odczyt_zapis";
            StreamWriter writer = new StreamWriter(folder + "\\zapis.txt");
            StreamReader reader = new StreamReader(folder + "\\odczyt.txt");
            writer.WriteLine("Nowy zapis");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                writer.WriteLine(line);
            }
            writer.Close();
            reader.Close();

        }

    }
}
