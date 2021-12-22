using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class otchet : Form
    {
        public otchet()
        {
            InitializeComponent();
        }


        simulation f = new simulation();
        //simulation f = new Func();
        private void otchet_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable data = new DataTable();
            data.Clear();
            string sql = String.Format("SELECT * FROM bron ");
            db.openConnection();
            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader sqldr = command.ExecuteReader();
            data.Load(sqldr);
            db.closeConnection();
            dgw.DataSource = data;
        }


        private bool flag;

        string[] Name = { "Андрей", "Дмитрий", "Леня", "Никита", "Сергей" };
        string[] Surname = { "Алексеев", "Иванов", "Хлюпиков", "Человеков", "Спартанцев" };
        string[] Did = { "Забронировал", "Арендовал" };
        string[] Idkniga = { "1", "2", "3", "4", "5" };

        Random rng = new Random();
        int count = 0;

        public void NewAnimal()
        {
            while (flag)
            {
                string name = Name[rng.Next(0, Name.Length)];
                string surname = Surname[rng.Next(0, Surname.Length)];
                string did = Did[rng.Next(0, Did.Length)];
                string idkniga = Idkniga[rng.Next(0, Idkniga.Length)];
                f.Add_to_bron(name, surname, did, idkniga);
                count++;
                label1.Invoke(new Action(() => label1.Text = count.ToString()));
                Thread.Sleep(1000);
            }
        }




        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            Task.Run(() => NewAnimal());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            otchet_Load(null, null);
        }
    }
}
