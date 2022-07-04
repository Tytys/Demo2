using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Demo.ClassFolder
{
    internal class DGClass
    {
        SqlConnection connection =
            new SqlConnection(@"Data Source=(local)\SQLEXPRESS;" +
                "Initial Catalog=Demo;" +
                "Integrated Security=True");
        //тут "Initial Catalog=* это Demo*;" убрать Demo и написать вместо нее
        //название твоей базы данных, так нужно сделать во sqlconnection
        //коментарий и подобные удалить
        DataGrid grd;
        DataTable dataTable;
        SqlDataAdapter dataAdapter;
        public DGClass(DataGrid grid)
        {
            grd = grid;
        }

        public void LoadDG(string command)
        {
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter(command, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                grd.ItemsSource = dataTable.DefaultView;
                
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

        public string SelectId()
        {
            object[] mass = null;
            string id = "";
            try
            {
                if (grd != null)
                {
                    DataRowView dataRow = grd.SelectedItem as DataRowView;
                    if(dataRow != null)
                    {
                        DataRow row = dataRow.Row;
                        mass = row.ItemArray;
                    }
                }
                id = mass[0].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            return id;
        }
    }
}
