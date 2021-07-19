using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlDataReader dataReader;
            string user = "";
            string pass = "";
            string connectionString = "Data Source=localhost;Initial Catalog=VSSQL;User ID=sa;Password=farhan";
            string sql = "Select * from LoginInfo";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    if (textBoxUser.Text == dataReader.GetValue(1).ToString() && textBoxPassword.Text == dataReader.GetValue(2).ToString())
                    {
                        MessageBox.Show(dataReader.GetValue(1) + " - " + dataReader.GetValue(2) + "\n Logged In!");
                        user = dataReader.GetValue(1).ToString();
                        pass = dataReader.GetValue(2).ToString();
                        continue;
                    }
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Can not open connection ! ");
            }
            MessageBox.Show(user + pass);
        }
    }
}
