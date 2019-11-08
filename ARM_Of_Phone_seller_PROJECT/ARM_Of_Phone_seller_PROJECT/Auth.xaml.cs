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

namespace ARM_Of_Phone_seller_PROJECT
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public MainWindow mainWindow;
        public Auth(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }

        private void Auth_Button_Login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Auth_Button_Guest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
