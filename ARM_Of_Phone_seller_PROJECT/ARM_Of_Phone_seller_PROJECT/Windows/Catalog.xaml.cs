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

        }
    }
}
