using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Lab_6_DML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn;
        SqlCommand cmd;
        private void Form1_Load(object sender, EventArgs e)
        {
          
            Connect();
            void Connect()
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-48T6SOF;Initial Catalog=alidb;Integrated Security=True");
                cmd = new SqlCommand();
                cmd.Connection = conn;
                Console.WriteLine("Connection Open!");
            }
            displaydata();

        }

        private void button1_Click(object sender, EventArgs e)
        {
    
            try
            {

                conn = new SqlConnection(@"Data Source=DESKTOP-48T6SOF;Initial Catalog=alidb;Integrated Security=True");
                cmd = new SqlCommand("INSERT INTO CityTable(_id,City,Post_Code) VALUES (@id,@Name,@code)", conn);
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@code", int.Parse(textBox3.Text));
                var i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Data is succcessfully inserted");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            displaydata();
        }
        private void displaydata()
        {
            
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.CommandText = "select * from CityTable";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
              
                cmd = new SqlCommand("UPDATE CityTable set City = @Name where _id=@id;",conn);
                cmd.Connection = conn;
                conn.Open();                
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                var i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Data UPDATED successfully!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            displaydata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
           
                cmd = new SqlCommand("delete from CityTable where _id = @id;",conn);
                cmd.Parameters.AddWithValue("@id",int.Parse(textBox1.Text));
                cmd.Connection = conn;
                conn.Open();
                var i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Data is succcessfully DELETED");
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("retry!");
            }

            displaydata();

        }
    }
    
}
