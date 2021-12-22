using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    class simulation
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306;username=root;password=root;database=proger");
        public bool Add_to_bron(string Name, string Surname, string Did, string Idkniga)
        {
            bool flag = false;
            MySqlCommand command = new MySqlCommand($"INSERT INTO bron (name, surname, did, idkniga) VALUES (@Name, @Surname, @Did, @idkniga)", connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Surname", Surname);
            command.Parameters.AddWithValue("@Did", Did);
            command.Parameters.AddWithValue("@idkniga", Idkniga);

            connection.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                flag = true;
            }
            connection.Close();
            return flag;
        }
    }
}
