using Demo.ClassFolder;
//Поменять Demo на название твоего проекта
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Demo.AdminPanel;
//Поменять Demo на название твоего проекта

namespace Demo.Zadanie
{
    /// <summary>
    /// Логика взаимодействия для ZadaniePanelWindow.xaml
    /// </summary>
    public partial class ZadaniePanelWindow : Window
    {
        DGClass dG;
        public ZadaniePanelWindow()
        {
            InitializeComponent();
            dG = new DGClass(grd);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dG.LoadDG("Select * From dbo.[zadanie]");
            //тут в скобках вместо zadanie написать имя своей базы данных
            //коментарий и похожие удалить
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new ZadanieAddWindow().Show();
            Close();
        }

        private void ExitIm_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void BackIm_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

        private void grd_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (grd.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали пользователя");
            }
            else
            {
                try
                {
                    VariableClass.ID = dG.SelectId();
                    dG.LoadDG("Select * From dbo.[zadanie]");
                    //тут в скобках вместо zadanie написать имя своей базы данных
                    //коментарий и похожие удалить
                    new ZadanieEditWindow().Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dG.LoadDG("Select * FROM dbo.[zadanie] " +
                $"Where Login Like '%{SearchTb.Text}%'");
            //тут в скобках вместо zadanie написать имя своей базы данных
            //коментарий и похожие удалить
        }
    }
}
