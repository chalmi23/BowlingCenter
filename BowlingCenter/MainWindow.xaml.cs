using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace BowlingCenter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"] ;

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string loginQuery = "SELECT * FROM users WHERE username = @username AND password = @password";
                using (SqlCommand command = new SqlCommand(loginQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", usernameTextBox.Text.ToString());
                    command.Parameters.AddWithValue("@password", passwordTextBox.Text.ToString());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            AdministratorWindow administratorWindow = new AdministratorWindow();
                            administratorWindow.Show();

                            MainWindow mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;
                            mainWindow.Close();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Invalid username or password!", "BowlingCenter", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }
        
    }
}