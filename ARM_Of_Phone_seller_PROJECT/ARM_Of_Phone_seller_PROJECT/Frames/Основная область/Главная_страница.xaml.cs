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

namespace ARM_Of_Phone_seller_PROJECT.View
{
    /// <summary>
    /// Логика взаимодействия для Главная_страница.xaml
    /// </summary>
    public partial class Главная_страница : Page
    {
        MainWindow mainWindow;
        Catalog catalog;
        public Главная_страница(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Catalog_Button_Click(object sender, RoutedEventArgs e)
        {
            catalog = new Catalog();
            catalog.ShowDialog();
        }
    }
}
