using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;


namespace Demo.ClassFolder
{
    internal class MBClass
    {
        public static void ExitMB()
        {
            if(MessageBox.Show("Вы действительно хотите выйти",
                "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
        }
        public static void ErrorMB(string text)
        {
            MessageBox.Show(text,
                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void ErrorMB(Exception exception)
        {
            MessageBox.Show(exception.Message,
                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void InfoMB(string txt)
        {
            MessageBox.Show(txt,
                "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
