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

            string FileData = @"d:\super\study.db"; // физический путь к базе данных, меняем его на свой
            conn.ConnectionString = @"Data Source=" + FileData + ";New=True;Version=3";
            conn.Open();
            DbCommand comm = conn.CreateCommand();
            comm.CommandText = @"SELECT  StudentId, FName, Email, Phone
                                 FROM Students ";

            var reader = comm.ExecuteReader();

            while (reader.Read())
            {
                //if (!reader.IsDBNull(0))
                //    Console.WriteLine((short)reader.GetInt32(0)); // StudentId
                if (!reader.IsDBNull(1))
                    Console.WriteLine(reader.GetString(1).Trim()); // FName
                if (!reader.IsDBNull(2))
                    Console.WriteLine(reader.GetString(2).Trim()); // LName
                if (!reader.IsDBNull(3))
                    Console.WriteLine(reader.GetString(3).Trim()); // Email
                if (!reader.IsDBNull(4))
                    Console.WriteLine(reader.GetString(4).Trim()); // Phone

            }
            reader.Close();
        }
    }
}
