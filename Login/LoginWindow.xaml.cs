using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            string sqlCon = @"Data Source=LAB108PC03\SQLEXPRESS; Initial Catalog=LogInSS; Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(sqlCon);

            try
            {
                if(sqlConnection.State== System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                //create our query 
                string Query = "SELECT COUNT(1) FROM UserCredentials WHERE Username = @Username AND Password = @Password";

                SqlCommand cmd = new SqlCommand
                    (Query , sqlConnection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text); // connection between the value in the textbox and the database info
                cmd.Parameters.AddWithValue("@Password", passwordBox.Password);

                int count = Convert.ToInt32(cmd.ExecuteScalar()); 

                if (count == 1)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credentials are wrong. Try again!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
