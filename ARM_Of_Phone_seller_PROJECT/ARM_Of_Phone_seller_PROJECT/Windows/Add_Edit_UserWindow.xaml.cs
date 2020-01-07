using ARM_Of_Phone_seller_PROJECT.Database_Logic;
using ARM_Of_Phone_seller_PROJECT.Model;
using System;
using System.Windows;

namespace ARM_Of_Phone_seller_PROJECT.Windows
{
    public partial class AddUserWindow : Window
    {
        СпециалистModel специалистModel;
        Специалист_Поля SelectedItem;
        enum Mode
        {
            Edit,
            Add,
            Unknown
        }
        Mode mode = Mode.Unknown;
        public AddUserWindow(object obj)
        {
            InitializeComponent();
            специалистModel = new СпециалистModel();

            if (!(obj is null)) //Если было выбрано "Изменить" и пользователь выделил какую-нибудь строку
            {
                SelectedItem = obj as Специалист_Поля;

                Имя_TextBox.Text = SelectedItem.Имя;
                Фамилия_TextBox.Text = SelectedItem.Фамилия;
                Отчество_TextBox.Text = SelectedItem.Отчество;
                ДатаРождения_DatePicker.SelectedDate = SelectedItem.Дата_рождения;
                ОснованиеРаботы_TextBox.Text = SelectedItem.Основание_работы;
                #region CheckAndShowPhone
                if (Phone(SelectedItem.Телефон) != null)
                    PhoneNumber_TextBox.Text = Phone(SelectedItem.Телефон).ToString();
                else
                    MessageBox.Show($"Ошибка при обработке данных. Формат телефона не распознан: {SelectedItem.Телефон}", "Ошибка в данных", MessageBoxButton.OK, MessageBoxImage.Error);
                #endregion
                Login_TextBox.Text = SelectedItem.Логин;
                Password_TextBox.Text = Decryption(SelectedItem.Пароль);
                Статус_TextBox.Text = SelectedItem.Статус;
                AdminRights_CheckBox.IsChecked = SelectedItem.Администратор;

                mode = Mode.Edit;
            }
            else
                mode = Mode.Add;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Accept_Button_Click(object sender, RoutedEventArgs e)
        {
            bool IsOk = true;
            Специалист_Поля ItemToUpdateOrInsert = new Специалист_Поля();
            try
            {
                if (mode == Mode.Edit) ItemToUpdateOrInsert.ID_Специалиста = SelectedItem.ID_Специалиста;
                #region Имя
                if (IsWord(Имя_TextBox.Text) && Имя_TextBox.Text.Length != 0)
                    ItemToUpdateOrInsert.Имя = Имя_TextBox.Text;
                else
                    throw new System.Exception("Имя введено не верно. Ожидалось: [Аа-Яя] и длинна > 0.");
                #endregion
                #region Фамилия
                if (IsWord(Фамилия_TextBox.Text) && Фамилия_TextBox.Text.Length != 0)
                    ItemToUpdateOrInsert.Фамилия = Фамилия_TextBox.Text;
                else
                    throw new System.Exception("Фамилия введена не верно. Ожидалось: [Аа-Яя] и длинна > 0.");
                #endregion
                #region Отчество
                if (IsWord(Отчество_TextBox.Text) && Отчество_TextBox.Text.Length != 0)
                    ItemToUpdateOrInsert.Отчество = Отчество_TextBox.Text;
                else
                    throw new System.Exception("Отчество введено не верно. Ожидалось: [Аа-Яя] и длинна > 0.");
                #endregion
                #region ДатаРождения
                if (ДатаРождения_DatePicker != null)
                    ItemToUpdateOrInsert.Дата_рождения = (DateTime)ДатаРождения_DatePicker.SelectedDate;
                else
                    throw new Exception("Год введен не верно. Ожидалось: взаимодействие.");
                #endregion
                #region ОснованиеРаботы
                ItemToUpdateOrInsert.Основание_работы = ОснованиеРаботы_TextBox.Text;
                #endregion
                #region Телефон
                if (Phone(PhoneNumber_TextBox.Text) != null)
                    ItemToUpdateOrInsert.Телефон = (long)Phone(PhoneNumber_TextBox.Text);
                else
                    throw new System.Exception("Телефонный номер введен некорректно для страны: \"Беларусь\"");
                #endregion
                #region Логин
                if (Login_TextBox.Text.Length >= 5)
                    ItemToUpdateOrInsert.Логин = Login_TextBox.Text;
                else
                    throw new System.Exception("Логин введен не верно. Ожидалось: длинна > 5 символов.");
                #endregion
                #region Пароль
                if (Password_TextBox.Text.Length >= 5 && Password_TextBox.Text.Length != 32)
                    ItemToUpdateOrInsert.Пароль = HashingClass.Hashing(Password_TextBox.Text);
                else if (Password_TextBox.Text.Length >= 5 && Password_TextBox.Text.Length == 32)
                    ItemToUpdateOrInsert.Пароль = Password_TextBox.Text;
                else
                    throw new System.Exception("Пароль введен не верно. Ожидалось: длинна > 5.");
                #endregion
                #region Должность
                if (Статус_TextBox.Text.Length != 0)
                    ItemToUpdateOrInsert.Статус = Статус_TextBox.Text;
                else
                    throw new System.Exception("Должность введена не верно. Ожидалось: длинна > 0.");
                #endregion
                #region ПраваАдминистратора
                ItemToUpdateOrInsert.Администратор = (bool)AdminRights_CheckBox.IsChecked;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                IsOk = false;
            }
            finally
            {
                if (IsOk)
                {
                    if (mode == Mode.Edit) специалистModel.Update(ItemToUpdateOrInsert);
                    else if (mode == Mode.Add) специалистModel.Insert(ItemToUpdateOrInsert);
                    Close();
                }
            }
        }

        private string Decryption(string sPassword)
        {
            return sPassword;
        }
        private long? Phone(string number)
        {
            long result = -1;
            while (number.IndexOf('(') != -1)
                number = number.Remove(number.IndexOf('('), 1);
            while (number.IndexOf(')') != -1)
                number = number.Remove(number.IndexOf(')'), 1);
            while (number.IndexOf('+') != -1)
                number = number.Remove(number.IndexOf('+'), 1);
            if (long.TryParse(number, out result))
                return result;
            else
                return null;
        }
        private string Phone(long number)
        {
            char[] CharedNumber = number.ToString().ToCharArray();
            return $"+{CharedNumber[0]}{CharedNumber[1]}{CharedNumber[2]}" + //+375
                $"({CharedNumber[3]}{CharedNumber[4]})" + //(29)
                $"{CharedNumber[5]}{CharedNumber[6]}{CharedNumber[7]}{CharedNumber[8]}{CharedNumber[9]}{CharedNumber[10]}{CharedNumber[11]}"; //0001122
        }
        private bool IsWord(string text)
        {
            foreach (char symbol in text)
            {
                if (!(char.IsLetter(symbol)))
                    return false;
            }
            return true;
        }
    }
}
