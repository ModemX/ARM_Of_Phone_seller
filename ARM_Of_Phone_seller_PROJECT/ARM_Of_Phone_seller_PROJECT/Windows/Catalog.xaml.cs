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
        Вызов_представлений_Базы_данных МоделиView = new Вызов_представлений_Базы_данных();
        public Catalog()
        {
            InitializeComponent();

            CatalogGrid.ItemsSource = МоделиView.Select();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in CatalogGrid.ItemsSource)
            {
                var data = item as Модели_И_Их_Характеристики_Поля;
                МоделиView.Update(item as Модели_И_Их_Характеристики_Поля);
            }
            CatalogGrid.ItemsSource = МоделиView.Select();
        }
        private void CatalogGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = CatalogGrid.SelectedItem as Модели_И_Их_Характеристики_Поля;
            
            Form_Модель.Content = "Модель: " + item.Название_модели;
            Form_ГодВыпуска.Content = "Год выпуска: " + item.Год_Выпуска_Модели_DataGridBinding;
            Form_ОЗУ.Content = "ОЗУ: " + item.ОЗУ_DataGridBinding;
            Form_КолвоПамяти.Content = "Флеш-память: " + item.Количество_встроенной_памяти_DataGridBinding;
            Form_MicroSD.Content = "Слот MicroSD: " + item.Слот_MicroSD_DataGridBinding;
            Form_ОС.Content = "ОС: " + item.ОС_DataGridBinding;
            Form_ВерсияОС.Content = "Версия ОС: " + item.Версия_ОС_DataGridBinding;
            Form_Камера.Content = "Разрешение камеры: " + item.Разрешение_камеры_DataGridBinding;
            Form_ЕмкостьАккума.Content = "Емкость аккумулятора: " + item.Емкость_аккумулятора_DataGridBinding;
            Form_КолвоSIM.Content = "Количество SIM: " + item.Количество_SIM;
            Form_Длинна.Content = "Длинна: " + item.Длинна_DataGridBinding;
            Form_Ширина.Content = "Ширина: " + item.Ширина_DataGridBinding;
            Form_Толщина.Content = "Толщина: " + item.Толщина_DataGridBinding;
            Form_Вес.Content = "Вес: " + item.Вес_DataGridBinding;
        }
        private void ShowFirst_Click(object sender, RoutedEventArgs e)
        {
            CatalogGrid.SelectedIndex = 0;
        }
        private void ShowLast_Click(object sender, RoutedEventArgs e)
        {
            CatalogGrid.SelectedIndex = CatalogGrid.Items.Count-2;
        }
        private void ShowPrevious_Click(object sender, RoutedEventArgs e)
        {
            CatalogGrid.SelectedIndex--;
        }
        private void ShowNext_Click(object sender, RoutedEventArgs e)
        {
            CatalogGrid.SelectedIndex++;
        }
        private void DeleteEntry_Click(object sender, RoutedEventArgs e)
        {
            var item = CatalogGrid.SelectedItem as Модели_И_Их_Характеристики_Поля;

            if (item == null)
            {
                return;
            }
            МоделиView.Delete(item);
            CatalogGrid.ItemsSource = МоделиView.Select();
        }
        private void AddEntry_Click(object sender, RoutedEventArgs e)
        {
            МоделиView.InsertEmptyEntry();
            CatalogGrid.ItemsSource = МоделиView.Select();
        }
    }
}
