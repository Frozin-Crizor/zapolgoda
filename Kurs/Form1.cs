using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
          

        }
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string loginUser = textBox1.Text;
            string passUser = textBox2.Text;

            DB db = new DB();

            DataTable tabel = new DataTable();

            

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login = @ul AND password = @up", db.getConnection());

            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = loginUser;

            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = passUser;

            db.openConnection();
            MySqlDataReader mySqlData = command.ExecuteReader();


            if (mySqlData.HasRows)
            {
                this.Hide();
                osnov form1 = new osnov();

                form1.Show();
            }

            else
                MessageBox.Show("Введите данные правильно");
            db.closeConnection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            reg form1 = new reg();

            form1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
