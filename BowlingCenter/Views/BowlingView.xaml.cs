using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace BowlingCenter.Views
{
    public partial class BowlingView : UserControl
    {

        private List<ReservationData> reservations = new List<ReservationData>();

        public BowlingView()
        {
            InitializeComponent();
            reservations = ReservationData.InitializeReservationData();
            Loaded += LoadDataGrid;
        }

        private void LoadDataGrid(object sender, RoutedEventArgs e)
        {
            reservationsDataGrid.ItemsSource = reservations;
            reservationsDataGrid.Items.Refresh();
        }
        private void AddNewBowlingReservation(object sender, RoutedEventArgs e)
        {
            var reservationWindow = new ReservationWindow();
            reservationWindow.ShowDialog();

            //var selectedReservation = reservationsDataGrid.SelectedItem;
            //DateTime time = selectedReservation;

            DateTime time = new DateTime(2024, 03, 14, 10, 0, 0);
            ReservationData.AddNewReservation(1, time, reservationWindow.firstNameTextBox.Text, reservationWindow.secondNameTextBox.Text, int.Parse(reservationWindow.phoneNumberTextBox.Text), 1, 1);
 
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
        private void DeleteBowlingReservation(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

