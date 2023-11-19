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
            ShowAnimals();
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

        private void ShowAnimals()
        {
            string query = "SELECT * FROM Animal";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            using (adapter)
            {
                DataTable allAnimals = new DataTable();
                adapter.Fill(allAnimals);

                AnimalListBox.DisplayMemberPath = "Name";
                AnimalListBox.SelectedValuePath = "Id";
                AnimalListBox.ItemsSource = allAnimals.DefaultView;
            }
        }

        private void ZooListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ZooListBox.SelectedValue is null)
                return;

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

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            //Remeber about ON DELETE CASCADE!!!
            string query = "DELETE FROM Zoo WHERE Id = @IdVariable";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@IdVariable", ZooListBox.SelectedValue);
            command.ExecuteScalar();
            connection.Close();

            ShowZoos();
        }

        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputBox.Text))
                return;

            string query = "INSERT INTO Zoo VALUES (@Location)";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                cmd.Parameters.AddWithValue("@Location", InputBox.Text);
                connection.Open();
                cmd.ExecuteScalar();
                InputBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                ShowZoos();
            }
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputBox.Text))
                return;

            string query = "INSERT INTO Animal VALUES (@Name)";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                cmd.Parameters.AddWithValue("@Name", InputBox.Text);
                connection.Open();
                cmd.ExecuteScalar();
                InputBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                ShowAnimals();
            }
        }

        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalListBox.SelectedValue is null)
                return;

            string query = "DELETE FROM Animal WHERE Id = @IdVariable";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@IdVariable", AnimalListBox.SelectedValue);
                connection.Open();
                command.ExecuteScalar();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                ShowAnimals();
            }
        }

        private void AddAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {
            if (ZooListBox.SelectedValue is null || AnimalListBox.SelectedValue is null) 
                return;

            string query = "INSERT INTO ZooAnimal VALUES (@ZooId, @AnimalId)";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@ZooId", ZooListBox.SelectedValue);
                command.Parameters.AddWithValue("@AnimalId", AnimalListBox.SelectedValue);
                connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                ZooListBox_SelectionChanged(sender, null);
            }
        }

        private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (ZooListBox.SelectedValue is null || AssociatedAnimalsListBox.SelectedValue is null)
                return;

            string query = "DELETE FROM ZooAnimal WHERE ZooId = @ZooIdVar AND AnimalId = @AnimalIdVar";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@ZooIdVar", ZooListBox.SelectedValue);
                command.Parameters.AddWithValue("@AnimalIdVar", AssociatedAnimalsListBox.SelectedValue);
                connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                ZooListBox_SelectionChanged(sender, null);
            }
        }

        private void UpdateZoo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputBox.Text) || ZooListBox.SelectedValue is null) 
                return;

            string query = "UPDATE Zoo SET Location = @NewLocation WHERE Id = @IdVar";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@NewLocation", InputBox.Text);
                command.Parameters.AddWithValue("@IdVar", ZooListBox.SelectedValue);
                connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                ShowZoos();
            }
        }

        private void UpdateAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputBox.Text) || AnimalListBox.SelectedValue is null)
                return;

            string query = "UPDATE Animal SET Name = @NewName WHERE Id = @IdVar";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                command.Parameters.AddWithValue("@NewName", InputBox.Text);
                command.Parameters.AddWithValue("@IdVar", AnimalListBox.SelectedValue);
                connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                ShowAnimals();
            }
        }
    }
}
