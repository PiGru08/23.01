using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _23._01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string NazwaPliku { get; set; } = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Nowy(object sender, RoutedEventArgs e)
        {
            WpisanyText_TextBox.Text = "";
        }

        private void MenuItem_Click_Otworz(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "plik tekstowy | *.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                NazwaPliku = openFileDialog.FileName;
                Title = NazwaPliku;
                WpisanyText_TextBox.Text = File.ReadAllText(NazwaPliku);
            }
        }

        private void MenuItem_Click_Zapisz(object sender, RoutedEventArgs e)
        {
            if(NazwaPliku == "")
            {
                MenuItem_Click_Zapisz_Jako(sender, e);
            }
            else
            {
                File.WriteAllText(NazwaPliku, WpisanyText_TextBox.Text);
            }
        }

        private void MenuItem_Click_Zapisz_Jako(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "pliki tekstowe | *.txt";
            if(saveFileDialog.ShowDialog() == true)
            {
                NazwaPliku = saveFileDialog.FileName;
                Title = NazwaPliku;
                File.WriteAllText(NazwaPliku, WpisanyText_TextBox.Text);
            }
        }

        private void MenuItem_Click_Zamknij(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy chesz zapisać zmiany przed zamknięciem?","Pytanie", MessageBoxButton.YesNoCancel);
            if(messageBoxResult == MessageBoxResult.Cancel)
            {
                return;
            }else if(messageBoxResult == MessageBoxResult.No)
            {
                Close();
            }else if(messageBoxResult == MessageBoxResult.Yes)
            {
                if(NazwaPliku == "")
                {
                    MenuItem_Click_Zapisz_Jako(sender, e);
                    Close();
                }
                else
                {
                    MenuItem_Click_Zapisz(sender, e);
                    Close();
                }
            }
            
            
        }

        private void MenuItem_Click_O_Autorze(object sender, RoutedEventArgs e)
        {
            WindowAutor windowAutor = new WindowAutor();
            windowAutor.Show();
        }

        private void MenuItem_Click_O_Aplikacji(object sender, RoutedEventArgs e)
        {
            WindowApka windowApka = new WindowApka();
            windowApka.ShowDialog();//showDialog: Nie da się nic klikać w podstawowym oknie, nie jak przy dialog
        }
        
    }
}
