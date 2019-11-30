using ARM_Of_Phone_seller_PROJECT.Database_Logic.Таблицы_БД;
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
using System.Windows.Shapes;

namespace ARM_Of_Phone_seller_PROJECT
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        КлиентModel клиентModel = new КлиентModel();

        public Catalog()
        {
            InitializeComponent();

            CatalogGrid.ItemsSource = клиентModel.Select();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in CatalogGrid.ItemsSource)
            {
                var data = item as Клиент_Поля;

                if (IsEmpty(data))
                    клиентModel.Delete(data);
                else if (data.ID_Клиента != 0)
                    клиентModel.Update(item as Клиент_Поля);
                else
                    клиентModel.Insert(data);
            }
            CatalogGrid.ItemsSource = клиентModel.Select();
        }

        private bool IsEmpty(Клиент_Поля data)
        {
            bool IsSmthEmpty = false;

            if (data.Имя == "")
                IsSmthEmpty = true;
            if (data.Номер_паспорта == "")
                IsSmthEmpty = true;
            if (data.Отчество == "")
                IsSmthEmpty = true;
            if (data.Фамилия == "")
                IsSmthEmpty = true;

            return IsSmthEmpty;
        }

        private void CatalogGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = CatalogGrid.SelectedItem as Клиент_Поля;
            
            Form_Фамилия.Content = "Фамилия: " + item.Фамилия;
        }
    }
}
