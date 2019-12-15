using System;
using System.Collections;
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
using ARM_Of_Phone_seller_PROJECT.Database_Logic;

namespace ARM_Of_Phone_seller_PROJECT.View
{
    /// <summary>
    /// Логика взаимодействия для Изменение_Источника.xaml
    /// </summary>
    public partial class Изменение_Источника : Page
    {
        MainWindow mainWindow;
        public Изменение_Источника(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            TextBox_DBName.Text = DBController.DBController_DBName;
            TextBox_User.Text = DBController.DBController_User;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ИмяПользователя = TextBox_User.Text;
            Properties.Settings.Default.ИмяСервера = TextBox_DBName.Text;
            Properties.Settings.Default.Save(); // Сохраняем переменные.

            Switcher.SetStateOfMainWindow(new Auth(mainWindow));
        }

        private void Abort_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SetStateOfMainWindow(new Auth(mainWindow));
        }
    }
}
