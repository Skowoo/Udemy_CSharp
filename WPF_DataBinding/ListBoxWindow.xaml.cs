using System.Windows;
using WPF_DataBinding.Data;

namespace WPF_DataBinding
{
    /// <summary>
    /// Interaction logic for ListBoxWindow.xaml
    /// </summary>
    public partial class ListBoxWindow : Window
    {
        List<Person> Peoples = new List<Person>()
            {
                new Person() { Name = "Jan", Age = 11},
                new Person() { Name = "Adam", Age = 22},
                new Person() { Name = "Jacek", Age = 33},
                new Person() { Name = "Marek", Age = 44},
            };

        public ListBoxWindow()
        {
            InitializeComponent();

            ListBoxNames.ItemsSource = Peoples;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = ListBoxNames.SelectedItems;
            //Selected items return IList of object type - we need to cast them
            foreach (var item in selectedItems)
            {
                var person = (Person)item;
                MessageBox.Show(person.Name);
            }
        }
    }
}
