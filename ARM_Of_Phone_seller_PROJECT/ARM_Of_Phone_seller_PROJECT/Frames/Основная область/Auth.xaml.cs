using ARM_Of_Phone_seller_PROJECT.Model;
using ARM_Of_Phone_seller_PROJECT.View;
using ARM_Of_Phone_seller_PROJECT.View.Информационная_панель;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ARM_Of_Phone_seller_PROJECT
{
    public partial class Auth : Page
    {
        public СпециалистModel model = new СпециалистModel();
        public MainWindow mainWindow;
        public Auth(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }

        private string Hashing(string data)
        {
            string hash = "";
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, data);
            }
            return hash.ToUpper();
        }

        private void Auth_Button_Login_Click(object sender, RoutedEventArgs e)
        {
            var list = model.Select().ToList();
            var hash = Hashing(Auth_Password.Password);
            Специалист_Поля User;
            if ((User = list.FirstOrDefault(it => it.Логин == Auth_Login.Text && it.Пароль == hash)) != null)
            {
                Shared_Data.ФИО_Пользователя = $"{User.Фамилия} {User.Имя[0]}. {User.Отчество[0]}.";
                Switcher.SetStateOfMainWindow(new Главная_страница(mainWindow));
                Switcher.SetStateOfAdditionalWindow(new Информация_о_входе_Главная_панель(mainWindow));
            }
            else
            {
                Auth_Password.Password = "";
                HintBlock.Text = "Неверный Логин/Пароль. Проверьте корректность введенных данных";
            }
        }

        private void Auth_Button_Guest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данный функционал еще не реализован", "Alpha-Build", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SetStateOfMainWindow(new Изменение_Источника(mainWindow));
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Auth_Password_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Auth_Button_Login_Click(new object(), new RoutedEventArgs());
            }
        }
    }
}