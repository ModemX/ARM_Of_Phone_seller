using System.Windows.Controls;

namespace ARM_Of_Phone_seller_PROJECT
{
    class Switcher
    {
        static Frame MainWindow;
        static Frame AdditionalWindow;

        public static void SetMainWindow(Frame win)
        {
            MainWindow = win;
        }
        public static void SetAdditionalWindow(Frame win)
        {
            AdditionalWindow = win;
        }
        public static void SetStateOfMainWindow(Page page)
        {
            MainWindow.Content = page;
        }
        public static void SetStateOfAdditionalWindow(Page page)
        {
            AdditionalWindow.Content = page;
        }
    }
}
