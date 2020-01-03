using ARM_Of_Phone_seller_PROJECT.Database_Logic.Таблицы_БД;
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

namespace ARM_Of_Phone_seller_PROJECT.Frames.Основная_область
{
    public partial class Клиенты : Page
    {
        MainWindow mainWindow;
        КлиентModel клиентModel;
        public Клиенты(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            клиентModel = new КлиентModel();
            ClientsGrid.ItemsSource = клиентModel.Select();
            #region Логика_кнопок
            if(ClientsGrid.Items.Count != 0)
            {
                ClientsGrid.SelectedItem = 1;
                DeleteEntry_Button.IsEnabled = true;
            }
            else
            {
                DeleteEntry_Button.IsEnabled = false;
            }
            #endregion
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SetStateOfMainWindow(new Главная_страница(mainWindow));
        }

        private void DeleteEntry_Click(object sender, RoutedEventArgs e)
        {
            var item = ClientsGrid.SelectedItem as Клиент_Поля;

            if (item == null)
            {
                return;
            }
            клиентModel.Delete(item);
            ClientsGrid.ItemsSource = клиентModel.Select();
        }
        private void AddEntry_Click(object sender, RoutedEventArgs e)
        {
            клиентModel.Insert();
            ClientsGrid.ItemsSource = клиентModel.Select();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in ClientsGrid.ItemsSource)
            {
                var data = item as Клиент_Поля;
                клиентModel.Update(item as Клиент_Поля);
            }
            ClientsGrid.ItemsSource = клиентModel.Select();
        }
    }
}
