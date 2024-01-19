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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }
        string sqlConnection = @"Data Source=LAB108PC03\SQLEXPRESS; Initial Catalog=SignInPage; Integrated Security=True;";

       

        private bool CheckEmail()
        {
            if (Email.Text.Contains("@"))
            {
                return true;
            }
            else { return false; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char[] arr = { '!', '@', '*', '_', '?', '.', ','};

            string ran = arr.ToString();

            if(pswrdBox.Password.Length < 8 && !pswrdBox.Password.Contains(ran))
            {
                MessageBox.Show("Wrong Attempt! Go back and try again.");
            }
            else if (CheckEmail() == false)
            {
                MessageBox.Show("You entered an invalid email!");
            }
            else
            {
                MessageBox.Show($"Your Username is: {txtUsername.Text}\nYour Password is: {pswrdBox.Password}");
            }
        }

        private void usernameClear(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
        }

        private void FirstNameClear(object sender, RoutedEventArgs e)
        {
            FName.Text = "";
        }

        private void LastNameClear(object sender, RoutedEventArgs e)
        {
            LName.Text = "";
        }

        private void EmailClear(object sender, RoutedEventArgs e)
        {
            Email.Text = "";
        }

       

            
		private void Button_Click_1(object sender, RoutedEventArgs e) //Insert
        {


            SqlConnection conn = new SqlConnection(sqlConnection);

            try
            {
                conn.Open();
                string query = $"Insert into SignIn(Username, Firstname, LastName, Email, Password) values ('{txtUsername.Text}', '{FName.Text}', '{LName.Text}', '{Email.Text}', '{pswrdBox.Password}')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery(); //data is sent only one way; it is not going to return anything back to you

                MessageBox.Show("Success, it works!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Delete
        {
            SqlConnection conn = new SqlConnection(sqlConnection);

            try
            {
                conn.Open();
                string query = $"Delete from SignIn Where FirstName = 'Eric'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery(); //data is sent only one way; it is not going to return anything back to you

                MessageBox.Show("Success, it works!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}