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

namespace WpfApp_Udemy
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            //Creating and positioning Button using C# code (dynamic creation)
            Button myButton = new Button();
            myButton.Content = "B";
            Grid.SetRow(myButton, 3);
            Grid.SetColumn(myButton, 4);
            Grid myGrid = (Grid)FindName("MainGrid");
            myGrid.Children.Add(myButton);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new TaskManager();
            window.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new LoginView();
        }
    }
}
