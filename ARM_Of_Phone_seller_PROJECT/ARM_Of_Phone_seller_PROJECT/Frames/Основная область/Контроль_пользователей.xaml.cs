using ARM_Of_Phone_seller_PROJECT.Model;
using ARM_Of_Phone_seller_PROJECT.Windows;
using System.Windows.Controls;

namespace ARM_Of_Phone_seller_PROJECT.Frames.Основная_область
{
    public partial class Контроль_пользователей : Page
    {
        MainWindow mainWindow;
        СпециалистModel специалистModel;
        int ID_Выбранного_Пользователя = 0;
        public Контроль_пользователей(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            специалистModel = new СпециалистModel();

            UsersGrid.ItemsSource = специалистModel.Select();
            UsersGrid.SelectedItem = 0;
        }

        private void UsersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ID_Выбранного_Пользователя = UsersGrid.SelectedIndex;
            EditUser_Button.IsEnabled = true;
            if (UsersGrid.Items.Count > 1)
                DeleteUser_Button.IsEnabled = true;
        }

        private void AddUser_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }

        private void EditUser_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void DeleteUser_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
