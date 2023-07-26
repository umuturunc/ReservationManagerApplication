using ReservationManagerApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ReservationManagerApplication.Dao
{
    public class DataBase
    {
        private static string dbFilePath = "reservationdatabase.db";
        public static SQLiteConnection connection = new SQLiteConnection($"Data Source={dbFilePath};");
        static DataBase() { 
            connection.Open();
        }
        private static void initializeDatabase()
        {
            createDiningTable();
            populateDiningTable();
            createReservationTable();
        }

        private static void createDiningTable()
        {

            string createTableQuery = "CREATE TABLE IF NOT EXISTS DiningTable (Number INTEGER PRIMARY KEY, Capacity INTEGER)";

            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static void populateDiningTable()
        {
            
           Random random = new Random();
           for (int i = 0; i < 10; i++)
           {
               string insertDataQuery = String.Format("INSERT INTO DiningTable (Number, Capacity) VALUES ({0}, {1})", i+1, random.Next(1,7) );
               using (SQLiteCommand command = new SQLiteCommand(insertDataQuery, connection))
               {
                   command.ExecuteNonQuery();
               }
           } 
        }
        private static void createReservationTable()
        {

            string createTableQuery = "CREATE TABLE IF NOT EXISTS Reservation (Id INTEGER PRIMARY KEY, CustomerFullName TEXT, ReservationDate TEXT, NumberOfGuests INTEGER, TableNumber INTEGER)";

            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public static List<Table> getDiningTables()
        {
            List<Table> tableList = new List<Table>();

            string query = "SELECT * FROM DiningTable";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Number = Convert.ToInt32(reader["Number"]);
                        int Capacity = Convert.ToInt32(reader["Capacity"]);
                        Table table = new Table { Number = Number, Capacity = Capacity };
                        tableList.Add(table);
                    }
                }
            }

            return tableList;
        }
        public static List<Reservation> getReservations()
        {
            List<Reservation> reservationList = new List<Reservation>();

            string query = "SELECT * FROM Reservation";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        string CustomerFullName = reader.GetString(reader.GetOrdinal("CustomerFullName"));
                        DateTime ReservationDate = reader.GetDateTime(reader.GetOrdinal("ReservationDate"));
                        int NumberOfGuests = reader.GetInt32(reader.GetOrdinal("NumberOfGuests"));
                        int TableNumber = reader.GetInt32(reader.GetOrdinal("TableNumber"));

                        Reservation reservation = new Reservation
                        {
                            Id = Id,
                            CustomerFullName = CustomerFullName,
                            ReservationDate = ReservationDate,
                            NumberOfGuests = NumberOfGuests,
                            TableNumber = TableNumber
                        };
                        reservationList.Add(reservation);
                    }
                }
            }

            return reservationList;
        }

        public static void addReservation(Reservation reservation)
        {
            string insertDataQuery = String.Format("INSERT INTO Reservation (CustomerFullName, ReservationDate, NumberOfGuests, TableNumber ) " +
                "VALUES ('{0}', '{1}', {2}, {3})", reservation.CustomerFullName, reservation.ReservationDate.Date.ToString("yyyy-MM-dd HH:mm:ss"), reservation.NumberOfGuests, reservation.TableNumber);
            using (SQLiteCommand command = new SQLiteCommand(insertDataQuery, connection))
            {

                command.ExecuteNonQuery();
               
            }
            Console.WriteLine("Kayıt başarıyla tamamlandı");
        }

        public static List<Reservation> getReservationsByDate(DateTime dateTime)
        {
            List<Reservation> reservationList = new List<Reservation>();
            string query = "SELECT * FROM Reservation WHERE ReservationDate = '" + dateTime.Date.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        string CustomerFullName = reader.GetString(reader.GetOrdinal("CustomerFullName"));
                        DateTime ReservationDate = reader.GetDateTime(reader.GetOrdinal("ReservationDate"));
                        int NumberOfGuests = reader.GetInt32(reader.GetOrdinal("NumberOfGuests"));
                        int TableNumber = reader.GetInt32(reader.GetOrdinal("TableNumber"));

                        Reservation reservation = new Reservation
                        {
                            Id = Id,
                            CustomerFullName = CustomerFullName,
                            ReservationDate = ReservationDate,
                            NumberOfGuests = NumberOfGuests,
                            TableNumber = TableNumber
                        };
                        reservationList.Add(reservation);
                    }
                }
            }

            return reservationList;
        }

        private static void dropTable(string tableName)
        {
            string dropTableQuery = "DROP TABLE " + tableName;

            using (SQLiteCommand command = new SQLiteCommand(dropTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
