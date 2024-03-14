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
        private string _lastName;
        private int _phoneNumber;

        public int ReservationId { get => _reservationId; set => _reservationId = value; }
        public DateTime Time { get => _time; set => _time = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

        public static ObservableCollection<ReservationData> InitializeReservationData()
        {
            ObservableCollection<ReservationData> Reservations = new ObservableCollection<ReservationData>();

            for (int hour = 10; hour <= 22; hour++)
            {
                Reservations.Add(new ReservationData
                {
                    Time = new DateTime(1, 1, 1, hour, 0, 0), 
                    FirstName = "",
                    LastName = "",
                    PhoneNumber = 0,
                    ReservationId = 0
                }) ; 
            }

            return Reservations;
        }

        public static void addNewReservation(int userId, DateTime date, string firstName, string secondName, int phoneNumber, int typeId, int gameStation)
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO reservations (user_id, date, first_name, second_name, phone_number, type_id, game_station) VALUES (@user_id, @date, @first_name, @second_name, @phone_number, @type_id, @game_station)", connection);
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@first_name", firstName);
                command.Parameters.AddWithValue("@second_name", secondName);
                command.Parameters.AddWithValue("@phone_number", phoneNumber);
                command.Parameters.AddWithValue("@type_id", typeId);
                command.Parameters.AddWithValue("@game_station", gameStation);

                command.ExecuteNonQuery();
                

                MessageBox.Show("Reservation added succesfully!", "AdminTool", MessageBoxButtons.OK);
            }
        }
    }
}
