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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Demo.ClassFolder;
using Demo.AdminPanel;
using Demo.Zadanie;
//переименовать папку и написать выше после Demo. имя папки, все такие коменатарии удалить 

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        SqlConnection connection = 
            new SqlConnection(@"Data Source=(local)\SQLEXPRESS;" +
                "Initial catalog=Demo;" +
                "Integrated Security=True");
        //тут "Initial Catalog=* это Demo*;" убрать Demo и написать вместо нее
        //название твоей базы данных, так нужно сделать во sqlconnection
        //коментарий и подобные удалить
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(loginTb.Text))
            {
                MBClass.ErrorMB("Не введен логин");
                loginTb.Focus();
            }
            else if (string.IsNullOrEmpty(RegistrationTb.Text))
            {
                MBClass.ErrorMB("Не введен пароль");
                RegistrationTb.Focus();
            }
            else
            {
                try
                {
                    connection.Open();
                    sqlCommand = new SqlCommand("Select * FROM " +
                        "dbo.[Users] Where " +
                        $"Login='{loginTb.Text}'", connection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    sqlDataReader.Read();
                    if (sqlDataReader[2].ToString() == RegistrationTb.Text)
                    {
                        switch(sqlDataReader[3].ToString())
                        {
                            case "1":
                                new AdminPanelWindow().Show();
                                Close();
                                break;
                            case "2":
                                //Переименовать окно под задание и написать тут его название, все такие коменатрии удалить
                                new ZadaniePanelWindow().Show();
                                Close();
                                break;
                        }
                    }
                    else
                    {
                        MBClass.ErrorMB("Не верный пароль");
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }
    }
}
