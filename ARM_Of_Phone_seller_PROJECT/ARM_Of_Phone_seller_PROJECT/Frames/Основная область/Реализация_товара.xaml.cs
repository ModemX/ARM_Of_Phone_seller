using ARM_Of_Phone_seller_PROJECT.View;
using System.Windows;
using System.Windows.Controls;

namespace ARM_Of_Phone_seller_PROJECT.Frames.Основная_область
{
    public partial class Реализация_товара : Page
    {
        MainWindow mainWindow;
        public Реализация_товара(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SetStateOfMainWindow(new Главная_страница(mainWindow));
        }
    }
}
