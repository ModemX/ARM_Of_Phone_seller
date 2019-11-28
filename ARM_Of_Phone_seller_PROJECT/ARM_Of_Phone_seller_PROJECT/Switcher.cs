using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ARM_Of_Phone_seller_PROJECT
{
    class Switcher
    {
        static Frame window;

        public static void SetWindow(Frame win)
        {
            window = win;
        }
        public static void SetState(Page page)
        {
            window.Content = page;
        }
    }
}
