using ARM_Of_Phone_seller_PROJECT.Frames.Основная_область;
using ARM_Of_Phone_seller_PROJECT.View.Информационная_панель;
using System.Windows;
using System.Windows.Controls;

namespace ARM_Of_Phone_seller_PROJECT.View
{
    public partial class Главная_страница : Page
    {
        MainWindow mainWindow;
        Catalog catalog;
        public Главная_страница(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Catalog_Button_Click(object sender, RoutedEventArgs e)
        {
            catalog = new Catalog();
            catalog.ShowDialog();
        }

        private void UserContol_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SetStateOfMainWindow(new Главная_страница(mainWindow));
            Switcher.SetStateOfAdditionalWindow(new Информация_о_входе_Главная_панель(mainWindow));
        }

        private void SellItemWindow_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SetStateOfMainWindow(new Реализация_товара(mainWindow));
        }
    }
}
