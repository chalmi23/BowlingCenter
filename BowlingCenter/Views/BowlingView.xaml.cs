using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace BowlingCenter.Views
{
    public partial class BowlingView : UserControl
    {

        private List<ReservationData> reservations = new List<ReservationData>();
        private List<ReservationData> reservationsFromDatabase = ReservationData.GetReservations(DateTime.UtcNow, 1);

        public BowlingView()
        {
            InitializeComponent();
            reservationCalendar.SelectedDate = DateTime.Now.Date;
            Loaded += LoadDataGrid;
            FillComboBoxWithTracks();
        }

        private void LoadDataGrid(object sender, RoutedEventArgs e)
        {
            reservations = ReservationData.InitializeReservationData(reservationCalendar.SelectedDate.Value);
            reservationsFromDatabase = ReservationData.GetReservations(reservationCalendar.SelectedDate.Value, comboBoxBowlingAlleys.SelectedIndex + 1);
            foreach (var reservationfromdatabase in reservationsFromDatabase)
            {
                foreach (var reservation in reservations)
                {
                    if (reservation.Time.ToString() == reservationfromdatabase.Time.ToString())
                    {
                        reservation.FirstName = reservationfromdatabase.FirstName;
                        reservation.SecondName = reservationfromdatabase.SecondName;
                        reservation.PhoneNumber = reservationfromdatabase.PhoneNumber;
                        reservation.ReservationId = reservationfromdatabase.ReservationId;
                        reservation.UserId = reservationfromdatabase.UserId;
                        break;
                    }
                }
            }
            reservationsDataGrid.ItemsSource = reservations;
            reservationsDataGrid.Items.Refresh();
        }
        private void AddNewBowlingReservation(object sender, RoutedEventArgs e)
        {
            var reservationWindow = new ReservationWindow();
            reservationWindow.ShowDialog();

            var selectedReservation = reservationsDataGrid.SelectedItem;
            DateTime time = ((BowlingCenter.ReservationData)selectedReservation).Time;

            ReservationData.AddNewReservation(1, time, reservationWindow.firstNameTextBox.Text, reservationWindow.secondNameTextBox.Text, int.Parse(reservationWindow.phoneNumberTextBox.Text), 1, comboBoxBowlingAlleys.SelectedIndex + 1);
 
            foreach (var reservation in reservations)
            {
                if (reservation.Time.ToString() == time.ToString())
                {
                    reservation.FirstName = reservationWindow.firstNameTextBox.Text;
                    reservation.SecondName = reservationWindow.secondNameTextBox.Text;
                    reservation.PhoneNumber = int.Parse(reservationWindow.phoneNumberTextBox.Text);
                    break;
                }
            }
            LoadDataGrid(sender, e);
        }
        private void FillComboBoxWithTracks()
        {
            for (int i = 1; i <= 3; i++)
            {
                string trackName = $"Alley {i}";
                comboBoxBowlingAlleys.Items.Add(trackName);
            }
            comboBoxBowlingAlleys.SelectedIndex = 0;
        }
        private void changeDataByCalendar(object sender, SelectionChangedEventArgs e)
        {
            LoadDataGrid(sender, e);
        }
        private void comboBoxBowlingAlleys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDataGrid(sender, e);
        }
    }
}

