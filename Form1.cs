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
            int x = 0;
            int y = 10;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT car, image FROM cars", conn);

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string car = reader.GetString(0);
                    string img = reader.GetString(1);

                    Label lbl = new Label();
                    lbl.Location = new Point(x, y);
                    lbl.Size = new Size(200, 30);
                    lbl.Font = new Font("Arial", 20);
                    lbl.Text = car;
                    Controls.Add(lbl);


                    PictureBox pb = new PictureBox();
                    pb.Location = new Point(x, y + 30);
                    pb.Size = new Size(200, 130);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Load("Pictures/" + img);
                    Controls.Add(pb);
                    

                    x = x + 230;
                    if (x + 230 > Width)
                    {
                        x = 0;
                        y += 180;
                    }
                }
            }

            conn.Close();
        }
    }
}
