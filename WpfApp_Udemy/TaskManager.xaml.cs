﻿using System;
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
using System.Windows.Shapes;

namespace WpfApp_Udemy
{
    /// <summary>
    /// Interaction logic for TaskManager.xaml
    /// </summary>
    public partial class TaskManager : Window
    {
        public TaskManager()
        {
            InitializeComponent();
        }

        private void AddBuddton_Click(object sender, RoutedEventArgs e)
        {
            TextBlock.Text += "- " + inputBox.Text + Environment.NewLine;
            inputBox.Text = string.Empty;
        }
    }
}
