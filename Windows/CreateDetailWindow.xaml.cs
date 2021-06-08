using Microsoft.Win32;
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

namespace IT_Center.Windows
{
    /// <summary>
    /// Interaction logic for CreateDetailWindow.xaml
    /// </summary>
    public partial class CreateDetailWindow : Window
    {
        public CreateDetailWindow()
        {
            InitializeComponent();
        }

        private void BtnPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

            }
        }
    }
}
