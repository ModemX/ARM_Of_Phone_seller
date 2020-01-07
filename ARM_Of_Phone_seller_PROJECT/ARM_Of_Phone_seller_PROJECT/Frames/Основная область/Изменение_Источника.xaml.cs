using ARM_Of_Phone_seller_PROJECT.Database_Logic;
using System.Windows;
using System.Windows.Controls;

namespace ARM_Of_Phone_seller_PROJECT.View
{
    public partial class Изменение_Источника : Page
    {
        MainWindow mainWindow;
        public Изменение_Источника(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            TextBox_DBName.Text = DBController.DBController_DBName;
            TextBox_User.Text = DBController.DBController_User;
            ChangesWarning.Visibility = Visibility.Hidden;

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

        private void CreateDB_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Rewrite_CreateResult = MessageBox.Show("Вы уверены что хотите создать/пересоздать базу данных для приложения? Все сохраненные данные могут быть утеряны! \n\nПродолжить?", "Создание базы данных на устройстве", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (Rewrite_CreateResult == MessageBoxResult.Yes)
            {
                using (DBController db = new DBController(true))
                {
                    db.ExecuteNonQueryCommand(SqlFiles.SQL_DB_Creation);
                    db.ExecuteNonQueryCommand(SqlFiles.SQL_AddAdmin);
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ChangesWarning.Visibility = Visibility.Visible;
            }
            catch { }
        }
    }
}
