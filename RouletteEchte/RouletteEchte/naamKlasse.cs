using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace RouletteEchte
{
    public class naamKlasse
    {
        private string connectionString = "Data Source=C:/devopsDB/databasesRoulette.db;Version=3;";

        public string GetNaam(int number)
        {
            //connectie sql voor naam er uit te halen waar radnummer op geland is
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT naam FROM namen WHERE naamID = @number";
                    cmd.Parameters.AddWithValue("@number", number);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
                connection.Close();
            }
            //indien het niet werkt of geen nummer/naam gevonden
            return null; 
        }

    }
}
