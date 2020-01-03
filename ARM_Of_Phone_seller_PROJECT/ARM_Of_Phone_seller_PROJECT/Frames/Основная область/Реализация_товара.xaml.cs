using ARM_Of_Phone_seller_PROJECT.View;
using ARM_Of_Phone_seller_PROJECT.Database_Logic.Таблицы_БД;
using System.Windows;
using System.Windows.Controls;

namespace ARM_Of_Phone_seller_PROJECT.Frames.Основная_область
{
    public partial class Реализация_товара : Page
    {
        MainWindow mainWindow;
        ПродажаModel продажаModel;
        public Реализация_товара(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            продажаModel = new ПродажаModel();
            JournalGrid.ItemsSource = продажаModel.Select();
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SetStateOfMainWindow(new Главная_страница(mainWindow));
        }

        private void SearchField_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchField_TextBox.Text.Length != 0)
                JournalGrid.ItemsSource = продажаModel.SearchInJournal(SearchField_TextBox.Text);
            else
                JournalGrid.ItemsSource = продажаModel.Select();
        }

        private void ExportToWord_Click(object sender, RoutedEventArgs e)
        {
            Export.DocumentWriter.WriteSellsJournal(JournalGrid.Items.Count, продажаModel.Select());
        }

        private void ClearField_Button_Click(object sender, RoutedEventArgs e)
        {
            SearchField_TextBox.Text = "";
        }
    }
}
