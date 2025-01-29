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
using System.Windows.Shapes;

namespace _23._01
{
    
    /// <summary>
    /// Logika interakcji dla klasy Window_Kolor.xaml
    /// </summary>
    public partial class Window_Kolor : Window
    {
        public byte R_color { get; set; }
        public byte G_color { get; set; }
        public byte B_color { get; set; }
        public Window_Kolor()
        {
            InitializeComponent();
        }

        private void Button_Click_Zapisz(object sender, RoutedEventArgs e)
        {
            byte color_r;
            byte color_g;
            byte color_b;

            if(byte.TryParse(kolor_r.Text, out color_r))
            {
                R_color = color_r;
            }
            if (byte.TryParse(kolor_g.Text, out color_g))
            {
                G_color = color_g;
            }
            if (byte.TryParse(kolor_b.Text, out color_b))
            {
                B_color = color_b;
    

            }
            Close();
        }
    }
}
