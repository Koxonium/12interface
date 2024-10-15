using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _12interface
{
    class dbHandler : IdbHandler
    {
        MySqlConnection connection;
        string tableName = "felhasznalok";
        public dbHandler()
        {
            string database = "interfacehez";
            string username = "root";
            string password = "";
            string host = "localhost";

            string connectionString = $"database={database};host={host};username={username};password={password}";
            connection = new MySqlConnection(connectionString);
        }
        public void DeleteAll()
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void DeleteOne(user oneUser)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tableName} WHERE ID = {oneUser.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                user.users.Remove(oneUser);
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void InsertOne(user oneUser)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {tableName}(username,password,points) VALUES('{oneUser.username}', '{oneUser.password}', {oneUser.point})";
                MySqlCommand command = new MySqlCommand(query,connection);
                command.ExecuteNonQuery();
                user.users.Add(oneUser);
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ReadAll()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";
                MySqlCommand command = new MySqlCommand(query,connection);

                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    user oneUser = new user();
                    oneUser.id = read.GetInt32(read.GetOrdinal("ID"));
                    oneUser.point = read.GetInt32(read.GetOrdinal("points"));
                    oneUser.username = read.GetString("username");
                    oneUser.password = read.GetString("password");
                    user.users.Add(oneUser);
                }
                read.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateOne(user oneUser)
        {
            try
            {
                connection.Open();
                string query = $"UPDATE {tableName} SET points = {oneUser.point} WHERE id = {oneUser.id}";
                MySqlCommand command = new MySqlCommand(query,connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}
