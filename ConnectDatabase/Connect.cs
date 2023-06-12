using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectDatabase
{
    class Connect
    {
        string server = "localhost";
        string database = "test_db";
        string username = "root";
        string password = "!Ber217an";

        string conString = "SERVER=" + "localhost" + ";" +
                            "DATABASE=" + "test_db" + ";" +
                            "UID=" + "root" + ";" +
                            "PASSWORD=" + "!Ber217an" + ";";

        public void Connect2DB()
        {            
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            string query = "select * from data";
            MySqlCommand command = new MySqlCommand(query, conn);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["id"].ToString() + " " + reader["name"]);
            }

            Console.ReadLine();
        }

        public void Select()
        {
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            string query = "select * from data";
            MySqlCommand command = new MySqlCommand(query, conn);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["id"].ToString() + " " + reader["humidity"]);
            }
            conn.Close();
        }

        public void Truncate()
        {
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            string query = "truncate table data";

            MySqlCommand command = new MySqlCommand(query, conn);

            command.ExecuteNonQuery();

            Console.WriteLine("DB Cleared");
        }

        public void Insert(string[] arr)
        {
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            string query = "insert into data " +              
                "(source, productioncenter, domain, timestamp, year, month, day, hour, minute, second, id, latitude, longitude, coordinate, type, region, level, description, domain2, tags, name, ns1_lang, id2, description2, type2, type3, h, datetime, day2, value, unit) values" +
                "(@source, @productioncenter, @domain, @timestamp, @year, @month, @day, @hour, @minute, @second, @id, @latitude, @longitude, @coordinate, @type, @region, @level, @description, @domain2, @tags, @name, @ns1_lang, @id2, @description2, @type2, @type3, @h, @datetime, @day2, @value, @unit);";     
            MySqlCommand command = new MySqlCommand(query, conn);

            command.Parameters.AddWithValue("@source", arr[0]);
            command.Parameters.AddWithValue("@productioncenter", arr[1]);
            command.Parameters.AddWithValue("@domain", arr[2]);
            command.Parameters.AddWithValue("@timestamp", arr[3]);
            command.Parameters.AddWithValue("@year", arr[4]);
            command.Parameters.AddWithValue("@month", arr[5]);
            command.Parameters.AddWithValue("@day", arr[6]);
            command.Parameters.AddWithValue("@hour", arr[7]);
            command.Parameters.AddWithValue("@minute", arr[8]);
            command.Parameters.AddWithValue("@second", arr[9]);
            command.Parameters.AddWithValue("@id", arr[10]);
            command.Parameters.AddWithValue("@latitude", arr[11]);
            command.Parameters.AddWithValue("@longitude", arr[12]);
            command.Parameters.AddWithValue("@coordinate", arr[13]);
            command.Parameters.AddWithValue("@type", arr[14]);
            command.Parameters.AddWithValue("@region", arr[15]);
            command.Parameters.AddWithValue("@level", arr[16]);
            command.Parameters.AddWithValue("@description", arr[17]);
            command.Parameters.AddWithValue("@domain2", arr[18]);
            command.Parameters.AddWithValue("@tags", arr[19]);
            command.Parameters.AddWithValue("@name", arr[20]);
            command.Parameters.AddWithValue("@ns1_lang", arr[21]);
            command.Parameters.AddWithValue("@id2", arr[22]);
            command.Parameters.AddWithValue("@description2", arr[23]);
            command.Parameters.AddWithValue("@type2", arr[24]);
            command.Parameters.AddWithValue("@type3", arr[25]);
            command.Parameters.AddWithValue("@h", arr[26]);
            command.Parameters.AddWithValue("@datetime", arr[27]);
            command.Parameters.AddWithValue("@day2", arr[28]);
            command.Parameters.AddWithValue("@value", arr[29]);
            command.Parameters.AddWithValue("@unit", arr[30]);

            command.ExecuteNonQuery();

            ParseXML.arrayCount++;
        }
    }
}
