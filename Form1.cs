using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Farmacie
{
    public partial class Form1 : Form
    {
        string sqlConn = "datasource=127.0.0.1;port=3306;username=root;password=;database=farmacie";
        public Form1()
        {
            InitializeComponent();
            connectDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=farmacie");
            conn.Open();
            string query = "SELECT SUM(medicamente.pret * comenzi.cantitate) from medicamente inner JOIN comenzi ON medicamente.nume = comenzi.medicament where comenzi.data BETWEEN '2021-08-01' and '2021-08-31' and comenzi.farmacie = 'Dona'";
            MySqlCommand command = new MySqlCommand(query,conn);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox1.Text = mdr.GetString("SUM(medicamente.pret * comenzi.cantitate)");
            }
            else
            {
                MessageBox.Show("No result");
            }
            conn.Close();

        }
        private void connectDB()
        {
            string sqlConn = "datasource=127.0.0.1;port=3306;username=root;password=;database=farmacie";
            MySqlConnection databaseConnection = new MySqlConnection(sqlConn);
            try
            {
                databaseConnection.Open();
                MessageBox.Show("DB connected");
            }catch(Exception e)
            {
                MessageBox.Show("DB connection error");
                databaseConnection.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=farmacie");
            conn.Open();
            string query = "SELECT AVG(medicamente.pret * comenzi.cantitate) from medicamente inner JOIN comenzi ON medicamente.nume = comenzi.medicament where comenzi.data BETWEEN '2021-08-01' and '2021-08-31' and comenzi.farmacie='Dona'";
            MySqlCommand command = new MySqlCommand(query, conn);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox2.Text = mdr.GetString("AVG(medicamente.pret * comenzi.cantitate)");
            }
            else
            {
                MessageBox.Show("No result");
            }
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=farmacie");
            conn.Open();
            string query = "SELECT COUNT(comenzi.id) FROM comenzi inner JOIN medicamente on comenzi.medicament=medicamente.nume WHERE comenzi.farmacie = 'Vlad' and medicamente.antibiotic=1 and comenzi.data BETWEEN '2021-01-01' and '2021-12-31' ";
            MySqlCommand command = new MySqlCommand(query, conn);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox3.Text = mdr.GetString("COUNT(comenzi.id)");
            }
            else
            {
                MessageBox.Show("No result");
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=farmacie");
            conn.Open();
            string query = "SELECT SUM(medicamente.pret * comenzi.cantitate), comenzi.farmacie from medicamente inner JOIN comenzi ON medicamente.nume = comenzi.medicament where comenzi.data BETWEEN '2021-01-01' and '2021-12-31' GROUP BY comenzi.farmacie ASC";
            MySqlCommand command = new MySqlCommand(query, conn);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox4.Text = mdr.GetString("farmacie");
            }
            else
            {
                MessageBox.Show("No result");
            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=farmacie");
            conn.Open();
            string query = "SELECT medicament, SUM(cantitate), farmacie from comenzi GROUP by medicament, farmacie";

            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
          
            conn.Close();
        }
    }
}
