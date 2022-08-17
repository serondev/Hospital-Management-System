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
    /// Interaction logic for patientRegister.xaml
    /// </summary>
    public partial class patientRegister : Window
    {
        public patientRegister()
        {
            InitializeComponent();
            this.Left = SystemParameters.PrimaryScreenWidth - (this.Width)*1.8;
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainPage = new MainWindow();
            mainPage.Show();
            this.Close();
            
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {



            try
            {


                SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Msi\Desktop\HospitalManagementSystemv1.0\HospitalManagementSystemv1.0\LoginDatabase.mdf;Integrated Security=True");
                
                string gender;
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
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*
                          SqlCommand cmd = new SqlCommand("INSERT INTO Pregister VALUES (@SSN,@Name,@Surname", sqlCon);
                          cmd.CommandType = CommandType.Text;
                          cmd.Parameters.AddWithValue("@SSN", txtSSN.Text);
                          cmd.Parameters.AddWithValue("@Name", txtName.Text);
                          cmd.Parameters.AddWithValue("@Surname", txtSurname.Text);
                        //  cmd.Parameters.AddWithValue("@Gender", gender);
                         // cmd.Parameters.AddWithValue("@Doctor", cbDoctor.SelectedIndex);
                        //  cmd.Parameters.AddWithValue("@Explanation", txtExp.Text);
                       //   sqlCon.Open();
                          cmd.ExecuteNonQuery();
                          sqlCon.Close();
                          MessageBox.Show("Data Saved Succesfully");
                          }
                          catch(SqlException ex) 
                          {
                              MessageBox.Show(ex.Message);
                          }
                        */


            //SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Msi\Desktop\HospitalManagementSystemv1.0\HospitalManagementSystemv1.0\LoginDatabase.mdf;Integrated Security=True");
            // try
            // {
            //     if (sqlCon.State == ConnectionState.Closed)
            //         sqlCon.Open();
            //     String query = "INSERT INTO Pregister (SSN,Name,Surname,Gender,Doctor,Explanation,Time) VALUES('" + Convert.ToInt32(txtSSN.Text) + "','" + txtName.Text + "','" + txtSurname.Text + "','" + gender + "'," + cbDoctor.SelectedItem + "," + txtExp.Text + ",'" + DateTime.Now + "',false)"; ;
            //    MessageBox.Show("Data Saved Succesfully");
            //  try
            //  {



            //      LoginDatabaseDataSetTableAdapters.PregisterTableAdapter info = new LoginDatabaseDataSetTableAdapters.PregisterTableAdapter();
            //    info.InsertPregister(Convert.ToInt32(txtSSN.Text), txtName.Text, txtSurname.Text, gender, cbDoctor.SelectedIndex.ToString(), txtExp.Text, DateTime.Now.ToString());
            //    MessageBox.Show("Data Saved Succesfully");


            //string Query = "INSERT INTO Pregister (SSN,Name,Surname,Gender,Doctor,Explanation,Time) VALUES('" + txtSSN.Text + "','" + txtName.Text + "','" + txtSurname.Text + "','" + gender + "'," + cbDoctor.SelectedIndex.ToString() + "," + txtExp.Text + ",'" + DateTime.Now + "',false)";

            //  }
            // catch { }

        }
    }
}
