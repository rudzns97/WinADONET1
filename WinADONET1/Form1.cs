using MySql.Data.MySqlClient;
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

namespace WinADONET1
{
    public partial class Form1 : Form
    {
        string strConn = "Server=127.0.0.1,3306;Uid=root;Pwd=1234;Database=employees";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                MySqlConnection conn = new MySqlConnection(strConn);
                {
                    
                    conn.Open();
                    MessageBox.Show("DB연결성공");
                    conn.Close(); 
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strConn);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select emp_no, concat(first_name,' ', last_name) emp_name
                                    from employees
                                    where emp_no < 10004; ";
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                label1.Text = reader["emp_no"].ToString();
                textBox1.Text = reader["emp_name"].ToString();

                reader.Read();
                label2.Text = reader["emp_no"].ToString();
                textBox2.Text = reader["emp_name"].ToString();

                reader.Read();
                label3.Text = reader.GetString("emp_no");
                textBox3.Text = reader.GetString("emp_name").ToString();

                conn.Close();

            } 
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strConn);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select emp_no, concat(first_name,' ', last_name) emp_name
                                    from employees
                                    where emp_no < 10004; ";
                MySqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                //if (reader.Read()) //select 의 결과 건수가 1건일 때
                //{

                //}
                while (reader.Read())
                {
                    if (i == 0)
                    {
                        label1.Text = reader["emp_no"].ToString();
                        textBox1.Text = reader["emp_name"].ToString();
                    }
                    if (i == 1)
                    {
                        label2.Text = reader[0].ToString();
                        textBox2.Text = reader[1].ToString();
                    }
                    if (i == 2)
                    {

                        label3.Text = reader.GetString("emp_no");
                        textBox3.Text = reader.GetString("emp_name");
                    }
                }
                

                conn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(strConn);
            

            string sql = @"select emp_no, concat(first_name,' ', last_name) emp_name
                                    from employees
                                    where emp_no < 10004; ";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            label6.Text = ds.Tables[0].Rows[0]["emp_no"].ToString();
            textBox6.Text = ds.Tables[0].Rows[0]["emp_name"].ToString();

            label5.Text = ds.Tables[0].Rows[1]["emp_no"].ToString();
            textBox5.Text = ds.Tables[0].Rows[1]["emp_name"].ToString();

            label4.Text = ds.Tables[0].Rows[2]["emp_no"].ToString();
            textBox4.Text = ds.Tables[0].Rows[2]["emp_name"].ToString();
        }
    }
}
