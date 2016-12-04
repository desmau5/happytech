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

    public partial class landing_page : Form
    {
       

        public landing_page()
        {
            InitializeComponent();
            password_textbox.PasswordChar = '*';
        }

        private void landing_page_Load(object sender, EventArgs e)
        { }

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
                ("SELECT * FROM happytech.reviewer where reviewer_username = '" + username_textbox.Text + "' and password = '" + password_textbox.Text + "';", conn);

                reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct");
                    this.Hide();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate username and password. Access denied.");
                }
                else
                    MessageBox.Show("Username or password is incorrect.");
            }
            catch (MySqlException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void signup_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            signup reg = new signup();
            reg.ShowDialog();
        }
    }
}
