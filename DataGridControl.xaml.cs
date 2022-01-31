using System;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.Configuration;
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
using System.Data;

namespace WPFGridData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*  SqlConnection con = new SqlConnection("Data Source=HP-PAVILION-ATH;Initial Catalog=EmployeeDetails;Integrated Security=True;");
              SqlCommand cmd = new SqlCommand("Select * From EmpData;", con);

              DataTable dt = new DataTable();
              con.Open();
              SqlDataAdapter sdr = new SqlDataAdapter(cmd);
              sdr.Fill(dt);
              //DataGrid DGridView = new DataGrid();
              DGridView.ItemsSource = dt.DefaultView;
              con.Close();*/
            this.updatedatagrid();

            //  this.ConCreat();
        }
        public void ConCreat()
        {

        }
        public void updatedatagrid()
        {
            this.ConCreat();
            SqlConnection con = new SqlConnection("Data Source=HP-PAVILION-ATH;Initial Catalog=EmployeeDetails;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("Select * From EmpData;", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            try
            {
                con.Open();
                sdr.Fill(dt);
                DGridView.ItemsSource = dt.DefaultView;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();

            }
        }
        
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string sql= "insert into EmpData(EmpId, EmpName,Address,Mob,Email) values(@EmpId,@EmpName,@Address,@Mob,@Email)"; 
            SqlConnection con = new SqlConnection("Data Source=HP-PAVILION-ATH;Initial Catalog=EmployeeDetails;Integrated Security=True;");
           // SqlCommand cmd = new SqlCommand("Select * From EmpData;", con);
          //  DataTable dt = new DataTable();
          //  SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            this.QueryUpdate(sql, 0);
            BtnAdd.IsEnabled = false;
            BtnUpdate.IsEnabled = true;
            BtnDelete.IsEnabled = true;
            try
            {


                //con.Open();

               // sdr.Fill(dt);
                //DataGrid DGridView = new DataGrid();
                //DGridView.DataContext = dt;
                // DGridView.ItemsSource=null;
                // DGridView.AutoGenerateColumns=true;
                // DGridView.CanUserAddRows = false;

               // DGridView.ItemsSource = dt.DefaultView;
                // DGridView.DataContext = dt.DefaultView;
                //con.Close();.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
           // int Id = TxtId.Text;
            string sql = "update EmpData set EmpId=@EmpId, EmpName=@EmpName,Address=@Address,Mob=@Mob,Email=@Email where EmpId=@EmpId";
            SqlConnection con = new SqlConnection("Data Source=HP-PAVILION-ATH;Initial Catalog=EmployeeDetails;Integrated Security=True;");
            //SqlCommand cmd = new SqlCommand("Select * From EmpData;", con);
            // DataTable dt = new DataTable();
            //SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            this.QueryUpdate(sql, 1);
            BtnAdd.IsEnabled = false;
            BtnUpdate.IsEnabled = false;
            BtnDelete.IsEnabled = true;
                try
       

            { 

                
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string sql = "delete from EmpData where EmpId=@EmpId";
            SqlConnection con = new SqlConnection("Data Source=HP-PAVILION-ATH;Initial Catalog=EmployeeDetails;Integrated Security=True;");
           
            this.QueryUpdate(sql, 2);
            BtnAdd.IsEnabled = true;
            BtnUpdate.IsEnabled = true;
            BtnDelete.IsEnabled = false;
            try
            {



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void QueryUpdate(string Sqlquery, int Caseno)
        {
            SqlConnection con = new SqlConnection("Data Source=HP-PAVILION-ATH;Initial Catalog=EmployeeDetails;Integrated Security=True;");
           SqlCommand cmd = new SqlCommand(Sqlquery,con);
           // DataTable dt = new DataTable();
          // SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            string msg = "";
            //SqlCommand cmd = Con.createcommand();
            cmd.CommandText = Sqlquery;
            cmd.CommandType = CommandType.Text;
            con.Open();


            switch (Caseno)
            {
                case 0:
                    msg = "Record Inserted Successfully";
                    cmd.Parameters.AddWithValue("@EmpId", TxtId.Text);
                    cmd.Parameters.AddWithValue("@EmpName", TxtName.Text);
                    cmd.Parameters.AddWithValue("@Address", TxtAdd.Text);
                    cmd.Parameters.AddWithValue("@Mob", TxtMob.Text);
                    cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
                   
                    break;
                case 1:
                    msg = "Record Update Suceesfully";
                    cmd.Parameters.AddWithValue("@EmpId", TxtId.Text);
                    cmd.Parameters.AddWithValue("@EmpName", TxtName.Text);
                    cmd.Parameters.AddWithValue("@Address", TxtAdd.Text);
                    cmd.Parameters.AddWithValue("@Mob", TxtMob.Text);
                    cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
                   // TxtId.Text = "";
                    break;
                case 2:
                    msg = "Record Deleted Suceesfully";
                    cmd.Parameters.AddWithValue("@EmpId", TxtId.Text);

                    break;

            }
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show(msg);
                    this.updatedatagrid();

                }
            }
            finally
            {

                cmd.Dispose();
                con.Close();
            }
            
        
        }

        private void DGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGrid dg = (DataGrid)sender;
            DataGrid dg = new DataGrid();
            dg=(DataGrid)sender;
            
           DataRowView dr = (DataRowView)dg.SelectedItem;
            if (dg != null && dr!=null)
            {
                int i = 0;
              //  Convert.ToInt32(TxtId.Text);

                TxtId.Text= dr["EmpId"].ToString();
                TxtName.Text= dr["EmpName"].ToString();
                TxtAdd.Text= dr["Address"].ToString();
                TxtMob.Text= dr["Mob"].ToString();
                TxtEmail.Text= dr["Email"].ToString();
            }

        }
    }   
}
