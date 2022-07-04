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
using Demo.ClassFolder;

namespace Demo.AdminPanel
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        SqlConnection connection = new
            SqlConnection(@"Data Source=(local)\SQLEXPRESS;"
            + "Initial Catalog=Demo;"
            + "Integrated Security=True");
        //тут "Initial Catalog=* это Demo*;" убрать Demo и написать вместо нее
        //название твоей базы данных, так нужно сделать во sqlconnection
        //коментарий и подобные удалить
        SqlCommand sqlCommand;
        CBClass cB;

        public AddUserWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            new AdminPanelWindow().Show();
            Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            string cif = "1234567890";
            string buk = "qwertyuiopasdfghjklzxcvbnm";
            string bukBol = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string znak = "!@#$%^&*";
            if (string.IsNullOrEmpty(loginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                loginTb.Focus();
            }
            else if (string.IsNullOrEmpty(RegistrationTb.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                RegistrationTb.Focus();
            }
            else if (RoleCb.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Не выбрана роль");
                RoleCb.Focus();
            }
            else if (cif.IndexOfAny(RegistrationTb.Text.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать цифру");
                RegistrationTb.Focus();
            }
            else if (buk.IndexOfAny(RegistrationTb.Text.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать букву");
                RegistrationTb.Focus();
            }
            else if (bukBol.IndexOfAny(RegistrationTb.Text.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать заглавную букву");
                RegistrationTb.Focus();
            }
            else if (znak.IndexOfAny(RegistrationTb.Text.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать !@#$%^&*");
                RegistrationTb.Focus();
            }
            else
            {
                try
                {
                    connection.Open();
                    sqlCommand = new
                        SqlCommand("Insert Into dbo.[Users]" +
                        " (Login, Password, RoleID) Values " +
                        $"'{loginTb.Text}','{RegistrationTb.Text}'," +
                        $"'{RoleCb.SelectedValue.ToString()}'",
                        connection);
                    MBClass.InfoMB("Пользователь добавлен");
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.RoleCBLoad(RoleCb);
        }
    }
}
