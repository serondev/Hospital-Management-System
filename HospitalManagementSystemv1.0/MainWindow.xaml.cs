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
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystemv1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            this.Left = SystemParameters.PrimaryScreenWidth - (this.Width) * 1.8;
            //LoadGrid();

        }
       // SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Msi\Desktop\HospitalManagementSystemv1.0\HospitalManagementSystemv1.0\LoginDatabase.mdf;Integrated Security=True");
        public void LoadGrid()
        {
           /* SqlCommand cmd = new SqlCommand("SELECT id,SSN,Name,Surname,Gender,Doctor,Explanation,Time FROM Pregister", sqlCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            myDataGrid1.ItemsSource = dt.DefaultView;*/

        }


        private void Editreg_Click(object sender, RoutedEventArgs e)
        {
            editRegister editReg = new editRegister();
            editReg.Show();
            this.Close();
        }


        private void Pregister(object sender, RoutedEventArgs e)
        {
            patientRegister register = new patientRegister();
            register.Show();
            this.Close();
        }
    }
}
