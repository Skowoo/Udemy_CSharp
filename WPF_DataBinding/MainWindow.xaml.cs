using System.Windows;
using WPF_DataBinding.Data;

namespace WPF_DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person = new Person
        {
            Name = "Barry",
            Age = 19
        };

        public MainWindow()
        {
            InitializeComponent();

            //Setting data context.
            //OneWay binding - ReadOnly binding
            //OneWayToSource - WriteOnly binding
            //TwoWay - read/write binding
            //OneTime - it will load only ONCE - at the load.
            this.DataContext = person;
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e) => MessageBox.Show(person.ToString());

        private void ArrayOpen_Click(object sender, RoutedEventArgs e)
        {
            var window = new ListBoxWindow();
            window.Show();
        }
    }
}