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
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;

            textBox1.Text = "Введите логин";
            textBox2.Text = "Введите пароль";
            textBox3.Text = "Введите имя";
            textBox4.Text = "Введите фамилию";
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void label1_Click(object sender, EventArgs e)
        {
         
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

  

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
         
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
       
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите логин"){
                textBox1.Text = "";
            }
            
        }
  
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == " "){
                textBox1.Text = "Введите логин";
                textBox1.ForeColor = Color.Gray;
                
            }
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

            if (textBox2.Text == "Введите пароль")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == " ")
            {
                textBox2.Text = "Введите пароль";
                textBox2.ForeColor = Color.Gray;

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Введите имя")
            {
                textBox3.Text = " ";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == " ")
            {
                textBox3.Text = "Введите имя";
                textBox3.ForeColor = Color.Gray;

            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Введите фамилию")
            {
                textBox4.Text = " ";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == " ")
            {
                textBox4.Text = "Введите фамилию";
                textBox4.ForeColor = Color.Gray;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }

            if (checkUser())
                return;




            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO users (login, password, nane, surname) VALUES ( @login, @pass, @name, @surname)", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBox4.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был создан");
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан");
            }



            db.closeConnection();
        }

        public Boolean checkUser()
        {
            DB db = new DB();

            DataTable tabel = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @uL",  db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1.Text;

            db.openConnection();

            adapter.SelectCommand = command;

            adapter.Fill(tabel);

            if (tabel.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже усть, введите другой");
                return true;
            }

            else
                return false;
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();

            form1.Show();
        }

       
    }
}
