using System;
using System.Windows.Forms;
using System.Data.Common;
using System.Drawing;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Formula1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String connString =
            "Server = VH287.spaceweb.ru; Database = beavisabra_cars;" +
            "port = 3306; User Id = beavisabra_cars; password = Beavis1989";

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            conn.Close();
        }
    }
}
