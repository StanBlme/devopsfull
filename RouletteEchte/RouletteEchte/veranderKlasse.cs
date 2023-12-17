using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RouletteEchte
{
    public class veranderKlasse
    {
        //connectie sql om naam in de tabel te vervangen
        private string connectionString = @"data source=C:/devopsDB/databasesRoulette.db";
        //functie om naam te veranderen, id = naamID ; newName = Nieuwe naam
        public void SetNaam(int id, string newName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = connection;
                    //query om de naam te vervangen
                    cmd.CommandText = "INSERT OR REPLACE INTO namen (naamID, naam) VALUES (@id, @newName)";

                    // De parameters voor de query
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@newName", newName);
                    //uitvoeren query
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
