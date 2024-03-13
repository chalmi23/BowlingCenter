using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
