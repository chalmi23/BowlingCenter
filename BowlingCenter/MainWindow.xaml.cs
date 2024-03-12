﻿using BowlingCenter.ViewModels;
using BowlingCenter.Views;
using System;
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

namespace BowlingCenter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //if(usernameTextBox.Text == "dupa") 
            //else MessageBox.Show("Nieprawidłowy login lub hasło.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);

            AdministratorWindow administratorWindow = new AdministratorWindow();
            administratorWindow.Show();

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Close();
        }

    }
}