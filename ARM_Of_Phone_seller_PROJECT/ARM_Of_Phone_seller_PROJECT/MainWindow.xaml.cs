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
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ARM_Of_Phone_seller_PROJECT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Switcher.SetWindow(MainFrame);
            OpenPage(pages.login);
        }

        public enum pages
        {
            login,
            info
        }

        void OpenPage(pages pages)
        {
            if (pages == pages.login)
            {
                // MainFrame.Navigate(new Auth(this));
                Switcher.SetState(new Auth(this));
            }
            //else if(pages == pages.info)
            //{
            //    MainFrame.Navigate(new /*TODO*/(this));
            //}
        }
    }
}
