using ARM_Of_Phone_seller_PROJECT.Frames.Основная_область;
using ARM_Of_Phone_seller_PROJECT.Model;
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

namespace ARM_Of_Phone_seller_PROJECT.View.Информационная_панель
{
    /// <summary>
    /// Логика взаимодействия для Информация_о_входе_Главная_панель.xaml
    /// </summary>
    public partial class Информация_о_входе_Главная_панель : Page
    {
        MainWindow mainWindow;
        bool IsUserConrtolActive = false;
        public Информация_о_входе_Главная_панель(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            LoginedAs.Content = $"Вход выполнен как: {Shared_Data.ФИО_Пользователя}";
        }

        private void UserConrol_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!IsUserConrtolActive)
            {
                UserConrol_Button.Background = new SolidColorBrush(Color.FromRgb(185, 255, 190));
                IsUserConrtolActive = true;
                Switcher.SetStateOfMainWindow(new Контроль_пользователей(mainWindow));

            }
            else
            {
                UserConrol_Button.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                IsUserConrtolActive = false;
                Switcher.SetStateOfMainWindow(new Главная_страница(mainWindow));
            }
        }
    }
}
