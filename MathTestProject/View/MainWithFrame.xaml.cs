using MathTestProject.ViewModel;
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
using System.Windows.Shapes;

namespace MathTestProject.View
{
    /// <summary>
    /// Interaction logic for MainWithFrame.xaml
    /// </summary>
    public partial class MainWithFrame : Window
    {
        private SharedViewModel _sharedViewModel;
        private UserViewModel _userViewModel;

        public MainWithFrame()
        {
            InitializeComponent();



            // Create an instance of SharedViewModel
            _sharedViewModel = new SharedViewModel();

            // Pass the SharedViewModel instance to UserViewModel
            _userViewModel = new UserViewModel(_sharedViewModel);

            // Set DataContext to _userViewModel
            DataContext = _userViewModel;

            // check if _sharedViewModel.UsersList is null
            if (_sharedViewModel.UsersList == null)
            {
                // Create a new list of users
            }

            // Navigate to MainPage (passing _sharedViewModel to MainPage constructor)

            mainFrame.Navigate(new LoginPage(_sharedViewModel));
            Application.Current.Windows[0].Height = 530;
            Application.Current.Windows[0].Width = 500;
        }




        private void ClickClose(object sender, RoutedEventArgs e)
        {
            // Close the window
            System.Windows.Application.Current.Shutdown();
            this.Close();
        }

        // In MainWithFrame.xaml.cs
        private void ClickLogout(object sender, RoutedEventArgs e)
        {


            mainFrame.Navigate(new LoginPage(_sharedViewModel));
            Application.Current.Windows[0].Height = 530;
            Application.Current.Windows[0].Width = 500;
        }
    }
}
