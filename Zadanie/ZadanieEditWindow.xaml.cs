using Demo.AdminPanel;
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

namespace Demo.Zadanie
{
    /// <summary>
    /// Логика взаимодействия для ZadanieEditWindow.xaml
    /// </summary>
    public partial class ZadanieEditWindow : Window
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
        public ZadanieEditWindow()
        {
            InitializeComponent();
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
                //тут в скобках вместо zadanie написать имя своей базы данных
                //коментарий и похожие удалить
                sqlCommand =
                    new SqlCommand("Update dbo.[zadanie] Set " +
                    $"Zadanie='{Text0Tb.Text}'," +
                    $"Zadanie='{Text1Tb.Text}'," +
                    $"Zadanie='{Text2Tb.Text}'," +
                    $"Zadanie='{Text3Tb.Text}'," +
                    $"Zadanie='{Text4Tb.Text}'," +
                    $"Zadanie='{Text5Tb.Text}'," +
                    $"Zadanie='{Text6Tb.Text}'," +
                    $"Zadanie='{Text7Tb.Text}'," +
                    $"Zadanie='{Text8Tb.Text}'," +
                    $"Zadanie='{Text9Tb.Text}'" +
                    $"Where id='{VariableClass.ID}'", connection);
                //тут вместо zadanie пишешь имя столбца в базе данных
                //в кавычках пишешь имя тексбокса который относиться к этому 
                //столбцу и после имени .Text
                //коментарий и похожие удалить
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
            try
            {
                connection.Open();
                sqlCommand =
                    new SqlCommand("Select * From dbo.[zadanie] Where " +
                    $"id='{VariableClass.ID}'", connection);
                //тут в скобках вместо zadanie написать имя своей базы данных
                //коментарий и похожие удалить
                data = sqlCommand.ExecuteReader();
                data.Read();
                Text0Tb.Text = data[1].ToString();
                Text1Tb.Text = data[2].ToString();
                Text2Tb.Text = data[3].ToString();
                Text3Tb.Text = data[4].ToString();
                Text4Tb.Text = data[5].ToString();
                Text5Tb.Text = data[6].ToString();
                Text6Tb.Text = data[7].ToString();
                Text7Tb.Text = data[8].ToString();
                Text8Tb.Text = data[9].ToString();
                Text9Tb.Text = data[10].ToString();
                //если в базе данных больше столбцов
                //то берется имя добавленых тобой текстбоксов
                //допустим он называется example
                //и пишется example.Text, после него пишешь
                //data[тут число в последней строке этой хуйни + 1].ToString();
                //коментарий и похожие удалить
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
}
