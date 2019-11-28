using ARM_Of_Phone_seller_PROJECT.Model;
using ARM_Of_Phone_seller_PROJECT.View;
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
        public СпециалистModel model = new СпециалистModel();
        public MainWindow mainWindow;
        public Auth(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }

        private string Hashing(string data) //ToDo алгоритм расшифрования
        {
            return data;
        }

        private void Auth_Button_Login_Click(object sender, RoutedEventArgs e)
        {
            var list = model.Select().ToList();
            var hash = Hashing(Auth_Password.Password);

            if (list.FirstOrDefault(it => it.Логин == Auth_Login.Text && it.Пароль == hash) != null)
            {
                Switcher.SetState(new Главная_страница());
            }
            else
            {
                HintBlock.Text = "Неверный Логин/Пароль. Проверьте корректность введенных данных";
            }
          // Нет таких данных
        }

        private void Auth_Button_Guest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
