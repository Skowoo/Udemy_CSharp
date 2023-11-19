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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Databases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["WPF_Databases.Properties.Settings.UdemyTutorialDBConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);

            ShowZoos();
        }

        private void ShowZoos()
        {
            string query = "Select * from Zoo";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            using (adapter)
            {
                DataTable zooTable = new DataTable();
                adapter.Fill(zooTable);

                //Which information from table will be displayed
                ZooListBox.DisplayMemberPath = "Location";
                //Which information from table will be delivered when item is selected
                ZooListBox.SelectedValuePath = "Id";
                //Reference to data
                ZooListBox.ItemsSource = zooTable.DefaultView;
            }
        }

        private void ZooListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Query to be executed with variable
            string query = "Select * from Animal a INNER JOIN ZooAnimal za ON a.Id = za.AnimalId WHERE za.ZooId = @ZooId";

            //Command - takes defuned above query and connection string
            SqlCommand command = new SqlCommand(query, connection);
            //Adapter initialized with command created above
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            using (adapter)
            {
                //Assigning parameter to used command BEFORE EXECUTION
                command.Parameters.AddWithValue("@ZooId", ZooListBox.SelectedValue);

                //Create DataTable and fill it with data from command
                DataTable animalsFromZoo = new DataTable();
                adapter.Fill(animalsFromZoo);

                //Which information from table will be displayed
                AssociatedAnimalsListBox.DisplayMemberPath = "Name";
                //Which information from table will be delivered when item is selected (might be ID)
                AssociatedAnimalsListBox.SelectedValuePath = "Id";
                //Reference to data
                AssociatedAnimalsListBox.ItemsSource = animalsFromZoo.DefaultView;
            }
        }
    }
}
