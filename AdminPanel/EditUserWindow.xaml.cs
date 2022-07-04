using Demo.ClassFolder;
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

namespace Demo.AdminPanel
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        SqlConnection connection = new
            SqlConnection(@"Data Source=(local)\SQLEXPRESS;"
            + "Initial Catalog=Demo;"
            + "Integrated Security=True");
        //тут "Initial Catalog=* это Demo*;" убрать Demo и написать вместо нее
        //название твоей базы данных, так нужно сделать во sqlconnection
        //коментарий и подобные удалить
        SqlCommand sqlCommand;
        SqlDataReader data;
        CBClass cB;
        public EditUserWindow()
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
            try
            {
                connection.Open();
                sqlCommand =
                    new SqlCommand("Update dbo.[Users] Set " +
                    $"Login='{loginTb.Text}'," +
                    $"Password='{RegistrationTb.Text}'," +
                    $"RoleID='{RoleCb.SelectedValue.ToString()}'" +
                    $"Where UserID='{VariableClass.UserID}'", connection);
                sqlCommand.ExecuteNonQuery();
                MBClass.InfoMB("Пользователь отредактирован");
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.RoleCBLoad(RoleCb);
            try
            {
                connection.Open();
                sqlCommand =
                    new SqlCommand("Select * From dbo.[Users] Where " +
                    $"UserID='{VariableClass.UserID}'", connection);
                data = sqlCommand.ExecuteReader();
                data.Read();
                loginTb.Text = data[1].ToString();
                RegistrationTb.Text = data[2].ToString();
                RoleCb.SelectedValue = data[3].ToString();
            }
            catch(Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
