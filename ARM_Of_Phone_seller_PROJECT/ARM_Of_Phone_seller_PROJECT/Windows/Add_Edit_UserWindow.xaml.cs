using System.Windows;

namespace ARM_Of_Phone_seller_PROJECT.Windows
{
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();

        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Accept_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Не реализовано", "Work In Progress", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
