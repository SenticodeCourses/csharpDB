using System;
using System.Data.Common;
using System.Data.SQLite;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            ReadDb();

            Console.ReadLine();
        }


        public static void ReadDb()
        {

            var conn = new SQLiteConnection();

            string FileData = @"d:\super\newbd.db";
            conn.ConnectionString = @"Data Source=" + FileData + ";New=True;Version=3";
            conn.Open();
            DbCommand comm = conn.CreateCommand();
            comm.CommandText = @"SELECT  idOapsPanel, Description,  ipAddr1, ipAddr2, idType 
                                 FROM tblOAPSPanel ";

            var reader = comm.ExecuteReader();

            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                    Console.WriteLine((short)reader.GetInt32(0));
                if (!reader.IsDBNull(1))
                    Console.WriteLine(reader.GetString(1).Trim());
                if (!reader.IsDBNull(2))
                    Console.WriteLine(reader.GetString(2).Trim());
                if (!reader.IsDBNull(3))
                    Console.WriteLine(reader.GetString(3).Trim());
                if (!reader.IsDBNull(4))
                    Console.WriteLine((byte)reader.GetInt32(4));

            }
            reader.Close();
        }
    }
}
