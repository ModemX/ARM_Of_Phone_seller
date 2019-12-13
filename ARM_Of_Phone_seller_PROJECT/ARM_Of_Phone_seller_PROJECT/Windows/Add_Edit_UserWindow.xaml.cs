using ARM_Of_Phone_seller_PROJECT.Model;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace ARM_Of_Phone_seller_PROJECT.Windows
{
    public partial class AddUserWindow : Window
    {
        СпециалистModel специалистModel;
        Специалист_Поля SelectedItem;
        public AddUserWindow(object obj)
        {
            InitializeComponent();
            специалистModel = new СпециалистModel();

            if (!(obj is null))
            {
                SelectedItem = obj as Специалист_Поля;

                Имя_TextBox.Text = SelectedItem.Имя;
                Фамилия_TextBox.Text = SelectedItem.Фамилия;
                Отчество_TextBox.Text = SelectedItem.Отчество;
                ДатаРождения_DatePicker.SelectedDate = SelectedItem.Дата_рождения;
                ОснованиеРаботы_TextBox.Text = SelectedItem.Основание_работы;
                #region CheckAndShowPhone
                if (Phone(SelectedItem.Телефон.ToString()) != null)
                    PhoneNumber_TextBox.Text = Phone(SelectedItem.Телефон.ToString()).ToString();
                else
                {
                    MessageBox.Show($"Ошибка при обработке данных. Формат телефона не распознан: {SelectedItem.Телефон}", "Ошибка в данных", MessageBoxButton.OK, MessageBoxImage.Error)
                } 
                #endregion
                Login_TextBox.Text = SelectedItem.Логин;
                Password_TextBox.Text = Decryption(SelectedItem.Пароль);
                Статус_TextBox.Text = SelectedItem.Статус;
                AdminRights_CheckBox.IsChecked = SelectedItem.Администратор;
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Accept_Button_Click(object sender, RoutedEventArgs e)
        {
            Специалист_Поля ItemToUpdate = new Специалист_Поля();
            try
            {
                #region Имя
                if (IsWord(Имя_TextBox.Text))
                    ItemToUpdate.Имя = Имя_TextBox.Text;
                else
                    throw new System.Exception("Неверно введено имя");
                #endregion
                #region Фамилия
                if (IsWord(Фамилия_TextBox.Text))
                    ItemToUpdate.Фамилия = Фамилия_TextBox.Text;
                else
                    throw new System.Exception("Неверно введена фамилия");
                #endregion
                #region Отчество
                if (IsWord(Отчество_TextBox.Text))
                    ItemToUpdate.Отчество = Отчество_TextBox.Text;
                else
                    throw new System.Exception("Неверно введено отчество");
                #endregion
                #region ДатаРождения
                if (ДатаРождения_DatePicker.SelectedDate == null)
                    throw new System.Exception("Дата рождения не может быть пуста");
                else
                    ItemToUpdate.Дата_рождения = (System.DateTime)ДатаРождения_DatePicker.SelectedDate;
                #endregion
                #region ОснованиеРаботы

                #endregion
                #region Телефон

                #endregion
                #region Логин

                #endregion
                #region Пароль

                #endregion
                #region Статус

                #endregion
                #region ПраваАдминистратора

                #endregion
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                специалистModel.Update(ItemToUpdate);
            }
        }

        private string Decryption(string sPassword)
        {
            //byte[] saltBytes = new byte[] { 1, 222, 31, 20, 11, 23, 85, 6 };
            //byte[] saltedHashBytes = new HMACMD5(saltBytes).ComputeHash(Encoding.UTF8.GetBytes(sPassword));
            //System.Text.StringBuilder s = new System.Text.StringBuilder();
            //foreach (byte b in saltedHashBytes)
            //{
            //    s.Append(b.ToString("x2").ToUpper());
            //}
            //return s.ToString();
            return sPassword;
        }
        private long? Phone (string number)
        {
            long result = -1;
            while (number.IndexOf('(') != -1)
                number.Remove(number.IndexOf('('), 1);
            while (number.IndexOf(')') != -1)
                number.Remove(number.IndexOf(')'), 1);
            while (number.IndexOf('+') != -1)
                number.Remove(number.IndexOf('+'), 1);
            if (long.TryParse(number, out result))
                return result;
            else
                return null;
        }
        private string Phone (long number)
        {
            char [] CharedNumber = number.ToString().ToCharArray();
            return $"+{CharedNumber[0]}{CharedNumber[1]}{CharedNumber[2]}" + //+375
                $"({CharedNumber[3]}{CharedNumber[4]})" + //(29)
                $"{CharedNumber[5]}{CharedNumber[6]}{CharedNumber[7]}{CharedNumber[8]}{CharedNumber[9]}{CharedNumber[10]}{CharedNumber[11]}"; //0001122
        }
        private bool IsWord(string text)
        {
            foreach (var symbol in text)
            {
                if (!(char.IsLetter(symbol)))
                    return false;
            }
            return true;
        }
    }
}
