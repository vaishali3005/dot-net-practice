using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFSample
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

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /*MessageBoxResult result = MessageBox.Show("Hello MessageBox");
            if (!string.IsNullOrWhiteSpace(TxtLogin.Text) && !LstBox.Items.Contains(TxtLogin.Text))
            {
                LstBox.Items.Add(TxtLogin.Text);
                TxtLogin.Clear();
            }*/
            SqlConnection sqlcon = new SqlConnection("Data Source=HP-PAVILION-ATH;Initial Catalog=LoginDb;Integrated Security=True");
              try
            {
                sqlcon.Open();
                string query = "insert into TableUser (UserLogin,UserPass) values (@UserLogin,@UserPass)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@UserLogin", TxtLogin.Text);
                sqlcmd.Parameters.AddWithValue("@UserPass",TxtPass.Text);
                sqlcmd.CommandType = System.Data.CommandType.Text;
                int i = sqlcmd.ExecuteNonQuery();
                if (i >0 )
                {
                    MessageBox.Show("Record Inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                sqlcon.Close();
            }
            

        }

        
    }
}
