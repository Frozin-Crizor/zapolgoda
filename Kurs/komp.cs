using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Kurs
{
    public partial class komp : Form
    {
        public komp()
        {
            InitializeComponent();
        }


        private void komp_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable data = new DataTable();
            data.Clear();
            string sql = String.Format("SELECT * FROM komp ");
            db.openConnection();
            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader sqldr = command.ExecuteReader();
            data.Load(sqldr);
            db.closeConnection();
            dataGridView2.DataSource = data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komp_Load(null, null);
        }
    }
}
