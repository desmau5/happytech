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

namespace software_engineering_2016
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn;
                string myConnectionString;

                myConnectionString = "server=127.0.0.1;uid=root;pwd=1234;database=happytech;";

                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlDataReader reader;

                MySqlCommand command
                = new MySqlCommand
                ("INSERT INTO happytech.reviewer (reviewer_username, reviewer_name, password) values ('"+ username_textbox.Text +"','"+ name_textbox.Text +"','"+ password_textbox.Text +"');", conn);

                reader = command.ExecuteReader();

                MessageBox.Show("Thank you for signing up, press OK to go back to login page.");
                this.Hide();
                landing_page landing = new landing_page();
                landing.ShowDialog();

            }
            catch (MySqlException exc)
            {
                MessageBox.Show(exc.Message);
            }

            
        }
    }
}
