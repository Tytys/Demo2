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
    /// Логика взаимодействия для ZadanieAddWindow.xaml
    /// </summary>
    public partial class ZadanieAddWindow : Window
    {
        SqlConnection connection = new
            SqlConnection(@"Data Source=(local)\SQLEXPRESS;"
            + "Initial Catalog=Demo;"
            + "Integrated Security=True");
        //тут "Initial Catalog=* это Demo*;" убрать Demo и написать вместо нее
        //название твоей базы данных, так нужно сделать во sqlconnection
        //коментарий и подобные удалить
        SqlCommand sqlCommand;

        public ZadanieAddWindow()
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
            if (string.IsNullOrEmpty(Text0Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text0Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text0Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text0Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text1Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text1Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text2Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text2Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text3Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text3Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text4Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text4Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text5Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text5Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text6Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text5Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text7Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text5Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text8Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text5Tb.Focus();
            }
            else if (string.IsNullOrEmpty(Text9Tb.Text))
            {
                MBClass.ErrorMB("Введите что-то");
                Text5Tb.Focus();
                //если в базе данных больше стобцов, то пишешь 
                //имя тексбокса привязаного к столбцу потом .Text
                //и в MBClass.ErrorMB(*тут*); пишешь что не введено
                //Потом меняешь все эти хуйни по заданию
            }
            else
            {
                try
                {
                    connection.Open();
                    sqlCommand = new
                        SqlCommand("Insert Into dbo.[zadanie]" +
                        " (Zadanie, Zadanie, Zadanie, Zadanie, Zadanie, " +
                        "Zadanie, Zadanie, Zadanie, Zadanie, Zadanie) Values " +
                        $"'{Text0Tb.Text}','{Text1Tb.Text}'," +
                        $"'{Text2Tb.Text}','{Text3Tb.Text}'," +
                        $"'{Text4Tb.Text}','{Text5Tb.Text}'," +
                        $"'{Text6Tb.Text}','{Text7Tb.Text}'," +
                        $"'{Text8Tb.Text}'," +
                        $"'{Text9Tb.Text}'",
                        connection);
                    //тут где в скобках куча Zadanie, меняешь их на
                    //названия столбцов в базе данных, причем в таком же порядке как и там
                    //потом то что в кавычках меняешь на имя 
                    //текстбокса привязаному к столбцу в базе данных
                    //если в базе данных больше столбцов чем здесь
                    //добавляешь по аналогии, самое главное проверь
                    //перед круглой скобкой чтобы не бвло запятой 
                    //и чтобы в последней штуке чтобы перед кавычкой не было
                    //запятой
                    //коменятарий и подобные удали
                    MBClass.InfoMB("Тут по заданию добавлен");
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

}
