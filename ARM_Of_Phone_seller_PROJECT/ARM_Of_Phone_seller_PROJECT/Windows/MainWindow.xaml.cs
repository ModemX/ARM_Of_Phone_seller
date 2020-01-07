using System.Windows;

namespace ARM_Of_Phone_seller_PROJECT
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Switcher.SetMainWindow(MainFrame);
            Switcher.SetAdditionalWindow(Info);
            Switcher.SetStateOfMainWindow(new Auth(this));
            Info.Content = "";
        }
    }
}
