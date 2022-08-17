using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace HospitalManagementSystemv1._0
{
    /// <summary>
    /// Interaction logic for editRegister.xaml
    /// </summary>
    public partial class editRegister : Window
    {
        

        public editRegister()
        {
            InitializeComponent();
            this.Left = SystemParameters.PrimaryScreenWidth - (this.Width) * 1.5;
            LoadGrid();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Msi\Desktop\HospitalManagementSystemv1.0\HospitalManagementSystemv1.0\LoginDatabase.mdf;Integrated Security=True");
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT id,SSN,Name,Surname,Gender,Doctor,Explanation FROM Pregister", sqlCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            myDataGrid.ItemsSource = dt.DefaultView;

        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainPage = new MainWindow();
            mainPage.Show();
            this.Close();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            /*  DataRowView drv = myDataGrid.SelectedItem as DataRowView;
              if (drv != null)
              {
                  DataView dataView = myDataGrid.ItemsSource as DataView;
                  dataView.Table.Rows.Remove(drv.Row);
              }*/
            if (myDataGrid.SelectedItems.Count > 0)
            {
                DataRowView drv = (DataRowView)myDataGrid.SelectedItem;
                string id = drv.Row[0].ToString();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Msi\Desktop\HospitalManagementSystemv1.0\HospitalManagementSystemv1.0\LoginDatabase.mdf;Integrated Security=True");
                con.Open();
                SqlCommand comm = new SqlCommand("delete from Pregister where id=@id", con);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                LoadGrid();
            }
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            string gender="a";
            if (rbMan.IsChecked == true)
                gender = "Male";
            else
                gender = "Female";

            
                if (myDataGrid.SelectedItems.Count > 0)
                {
                    DataRowView drv = (DataRowView)myDataGrid.SelectedItem;
                    string id = drv.Row[0].ToString();
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Msi\Desktop\HospitalManagementSystemv1.0\HospitalManagementSystemv1.0\LoginDatabase.mdf;Integrated Security=True");
                    ComboBoxItem typeItem = (ComboBoxItem)cbDoctor.SelectedItem;
                    ListBoxItem anothertypeItem = (ListBoxItem)lstbox.SelectedItem;
                con.Open();
                    SqlCommand comm = new SqlCommand("update Pregister set SSN=@SSN,Name=@Name,Surname=@Surname,Gender=@Gender,Doctor=@Doctor,Explanation=@Explanation where id=@id", con);
                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@SSN", txtSSN.Text);
                    comm.Parameters.AddWithValue("@Name", txtName.Text);
                    comm.Parameters.AddWithValue("@Surname", txtSurname.Text);
                    comm.Parameters.AddWithValue("@Gender", gender);
                    comm.Parameters.AddWithValue("@Doctor", typeItem.Content.ToString());
                    comm.Parameters.AddWithValue("@Explanation", anothertypeItem.Content.ToString());
                    comm.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                
            }
            else
            {
                MessageBox.Show("Fill all spaces!!!");
            }
        }

        private void Save_List(object sender, RoutedEventArgs e)
        {
            try
            {
                string gender="a";

                



                    SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Msi\Desktop\HospitalManagementSystemv1.0\HospitalManagementSystemv1.0\LoginDatabase.mdf;Integrated Security=True");

                
                if (rbMan.IsChecked == true)
                    gender = "Male";
                else
                    gender = "Female";

                SqlCommand cmd = new SqlCommand("INSERT INTO Pregister ([SSN],[Name],[Surname],[Gender],[Doctor],[Explanation],[Time]) VALUES (@SSN, @Name, @Surname, @Gender, @Doctor, @Explanation, @Time)", sqlCon);
                ComboBoxItem typeItem = (ComboBoxItem)cbDoctor.SelectedItem;
                ListBoxItem anothertypeItem = (ListBoxItem)lstbox.SelectedItem;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SSN", txtSSN.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Surname", txtSurname.Text);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Doctor", typeItem.Content.ToString());
                cmd.Parameters.AddWithValue("@Explanation", anothertypeItem.Content.ToString());
                cmd.Parameters.AddWithValue("@Time", DateTime.Now);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Saved");
                LoadGrid();
                

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
