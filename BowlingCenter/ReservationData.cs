using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BowlingCenter
{
    internal class ReservationData
    {
        private int _reservationId;
        private DateTime _time;
        private string _firstName;
        private string _secondName;
        private int _phoneNumber;
        private int _userId;
        private int _gameStation;

        public int ReservationId { get => _reservationId; set => _reservationId = value; }
        public DateTime Time { get => _time; set => _time = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string SecondName { get => _secondName; set => _secondName = value; }
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public int GameStation { get => _gameStation; set => _gameStation = value; }

        public static List<ReservationData> InitializeReservationData(DateTime date)
        {
            List<ReservationData> Reservations = new List<ReservationData>();

            for (int hour = 10; hour <= 22; hour++)
            {
                Reservations.Add(new ReservationData
                {
                    Time = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0), 
                    FirstName = "",
                    SecondName = "",
                    PhoneNumber = 0,
                    ReservationId = 0,
                    UserId = 0,
                    GameStation = 0,
                }) ; 
            }
            return Reservations;
        }
        
        public static void AddNewReservation(int userId, DateTime date, string firstName, string secondName, int phoneNumber, int typeId, int gameStation)
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO reservations (user_id, date, first_name, second_name, phone_number, type_id, game_station) VALUES (@user_id, @date, @first_name, @second_name, @phone_number, @type_id, @game_station)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@first_name", firstName);
                    command.Parameters.AddWithValue("@second_name", secondName);
                    command.Parameters.AddWithValue("@phone_number", phoneNumber);
                    command.Parameters.AddWithValue("@type_id", typeId);
                    command.Parameters.AddWithValue("@game_station", gameStation);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Reservation added succesfully!", "AdminTool", MessageBoxButtons.OK);
            }
        }


        public static List<ReservationData> GetReservations(DateTime date, int gameStation)
        {
            List<ReservationData> reservations = new List<ReservationData>();

            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM reservations WHERE CAST(date AS DATE) = @date AND game_station = @game_station";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@game_station", gameStation);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservations.Add(new ReservationData
                            {
                                Time = reader.GetDateTime(reader.GetOrdinal("date")),
                                FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                                SecondName = reader.GetString(reader.GetOrdinal("second_name")),
                                PhoneNumber = reader.GetInt32(reader.GetOrdinal("phone_number")),
                                ReservationId = reader.GetInt32(reader.GetOrdinal("reservation_id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                GameStation = reader.GetInt32(reader.GetOrdinal("game_station"))
                            });
                        }
                    }
                }
            }

            return reservations;
        }

    }
}
