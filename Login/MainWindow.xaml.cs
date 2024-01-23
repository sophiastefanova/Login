using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("stefanovasophia@gmail.com");
                mailMessage.To.Add(txtTo.Text);
                mailMessage.Subject = txtSubject.Text;
                mailMessage.Body = txtText.Text;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "stmp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "stefanovasophia@gmail.com";
                ntcd.Password = "";

                smtp.Credentials = ntcd;
                smtp.Port = 587;
                smtp.Send(mailMessage);

                MessageBox.Show("Message successfully sent!");  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            txtTo.Text=string.Empty;
            txtSubject.Text="";
            txtText.Text = string.Empty;
        }
    }
}
