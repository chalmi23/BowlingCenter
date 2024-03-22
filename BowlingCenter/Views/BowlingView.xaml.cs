using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BowlingCenter.Views
{
    public partial class BowlingView : UserControl
    {

        private List<ReservationData> reservations = new List<ReservationData>();
        private List<ReservationData> reservationsFromDatabase = ReservationData.GetReservations(DateTime.UtcNow, 1, 1);
        public BowlingView()
        {
            InitializeComponent();
            reservationCalendar.SelectedDate = DateTime.Now.Date;
            Loaded += LoadDataGrid;
            FillComboBox();
            reservationsDataGrid.Background = Brushes.LightBlue;
        }
        private void LoadDataGrid(object sender, RoutedEventArgs e)
        {
            reservations = ReservationData.InitializeReservationData(reservationCalendar.SelectedDate.Value);
            reservationsFromDatabase = ReservationData.GetReservations(reservationCalendar.SelectedDate.Value, 1, comboBoxBowlingAlleys.SelectedIndex + 1);
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
                        reservation.UserName = reservationfromdatabase.UserName;
                        break;
                    }
                }
            }
            reservationsDataGrid.ItemsSource = reservations;
            reservationsDataGrid.Items.Refresh();
        }
        private void AddNewBowlingReservation(object sender, RoutedEventArgs e)
        {
            var selectedReservation = reservationsDataGrid.SelectedItem;
            if(selectedReservation == null)
            {
                MessageBox.Show("First select the right date!", "AdminTool");
            }
            else
            {
                try
                {
                    var reservationWindow = new ReservationWindow();
                    reservationWindow.ShowDialog();
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
                catch(System.FormatException)
                {
                    MessageBox.Show("Enter valid data!", "AdminTool");
                }
            }
        }
        private void DeleteReservationButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = reservationsDataGrid.SelectedItem;
            if(((BowlingCenter.ReservationData)selectedReservation).ReservationId == 0)
            {
                MessageBox.Show("Select the right reservation!", "AdminTool");
            }
            else
            {
                ReservationData.DeleteReservation(((BowlingCenter.ReservationData)selectedReservation).ReservationId);
                LoadDataGrid(sender, e);
            }
        }
        private void FillComboBox()
        {
            for (int i = 1; i <= 3; i++)
            {
                string trackName = $"alley: {i}";
                comboBoxBowlingAlleys.Items.Add(trackName);
            }
            comboBoxBowlingAlleys.SelectedIndex = 0;
        }
        private void ChangeDataByCalendar(object sender, SelectionChangedEventArgs e)
        {
            LoadDataGrid(sender, e);
        }
        private void ComboBoxBowlingAlleys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDataGrid(sender, e);
        }
    }
}

