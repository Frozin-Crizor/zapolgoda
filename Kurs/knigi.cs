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
    public partial class knigi: Form
    {
        
        public knigi()
        {
            InitializeComponent();
        }



       
        private void knigi_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable data = new DataTable();
            data.Clear();
            string sql = String.Format("SELECT * FROM knigi ");
            db.openConnection();
            MySqlCommand command = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader sqldr = command.ExecuteReader();
            data.Load(sqldr);
            db.closeConnection();
            dataGridView1.DataSource = data;
        }
        


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            knigi_Load(null, null);
        }
    }
}

