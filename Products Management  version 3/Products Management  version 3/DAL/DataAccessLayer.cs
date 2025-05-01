using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Products_Management__version_3.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlConnection;

        //This Constructor Inisialize the connection object !!?    // كود الاتصال
        public DataAccessLayer()
        {
            string mode = Properties.Settings.Default.Mode;
            if (mode == "SQL")
            {
                //sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; Database=Product_DB; Integrated Security=true");
                //sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; AttachDbFilename=|datadirectory|Product_DB; Integrated Security=true"); // لا تعمل 
                sqlConnection = new SqlConnection(@"Data Source=" + Properties.Settings.Default.Server + ";Initial Catalog=" + 
                                                    Properties.Settings.Default.Database + ";Integrated Security=false; User ID ="+
                                                    Properties.Settings.Default.ID + "; Password=" + Properties.Settings.Default.Password +"" );

            }
            else
            {
                //sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; Database=Product_DB; Integrated Security=true");
                //sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; AttachDbFilename=|datadirectory|Product_DB; Integrated Security=true"); // لا تعمل 
                sqlConnection = new SqlConnection(@"Data Source=" + Properties.Settings.Default.Server + ";Initial Catalog=" + Properties.Settings.Default.Database + ";Integrated Security=True");

            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////

        //Method To Open Connection !!?   // كود فتح الاتصال
        public void Open()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

        }

        //Method To Close Connection !!?   // كود إغلاق الاتصال
        public void Close()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Close();
            }

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////

        //Method To Read Data From Database !!?    // select كود جملة 
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlConnection;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Method To Insert , Update and Delete Data From Database !!?    // Insert,Updata,Delete  كود جملة 
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;  //!!?
            sqlcmd.CommandText = stored_procedure;   //!!?
            sqlcmd.Connection = sqlConnection;

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }

    }
}
