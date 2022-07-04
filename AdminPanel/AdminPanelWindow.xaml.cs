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
using Demo.ClassFolder;
using Demo.AdminPanel;
using System.Formats.Asn1;

namespace Demo.AdminPanel
{
    /// <summary>
    /// Логика взаимодействия для AdminPanelWindow.xaml
    /// </summary>
    public partial class AdminPanelWindow : Window
    {
        DGClass dG;
        public AdminPanelWindow()
        {
            InitializeComponent();
            dG = new DGClass(grd);
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().Show();
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            dG.LoadDG("Select * FROM dbo.[Users] " +
                $"Where Login Like '%{SearchTb.Text}%'");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dG.LoadDG("Select * FROM dbo.[Users]");
        }

        private void grd_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(grd.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали пользователя");
            }
            else
            {
                try
                {
                    VariableClass.UserID = dG.SelectId();
                    dG.LoadDG("Select * From dbo.[Users]");
                    new EditUserWindow().Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
