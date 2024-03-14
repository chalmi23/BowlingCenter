﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BowlingCenter.Views
{
    public partial class BowlingView : UserControl
    {
        public BowlingView()
        {
            InitializeComponent();
            Loaded += BowlingView_Loaded;
        }
        private static void BowlingView_Loaded(object sender, RoutedEventArgs e)
        {
            BowlingView bowlingView = (BowlingView)sender;
            DataGrid reservationsDataGrid = bowlingView.FindName("reservationsDataGrid") as DataGrid;
            if (reservationsDataGrid != null)
            {
                reservationsDataGrid.ItemsSource = ReservationData.InitializeReservationData();
            }
        }
        private void addNewBowlingReservation(object sender, RoutedEventArgs e)
        {
            DateTime time = new DateTime(2024, 03, 14, 10, 0, 0);
            ReservationData.addNewReservation(1, time, "Michal", "Nowak", 1234562137, 1, 1);
        }
    }
}
