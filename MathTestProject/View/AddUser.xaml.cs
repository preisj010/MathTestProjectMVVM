using MathTestProject.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathTestProject.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        private SharedViewModel _sharedViewModel;

        public AddUser(SharedViewModel sharedViewModel)
        {
            InitializeComponent();
            _sharedViewModel = sharedViewModel;

        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get data from textboxes
                int userId = int.Parse(txtUserId.Text);
                string firstName = txtFname.Text;
                string lastName = txtLname.Text;
                string city = txtCity.Text;
                string email = txtEmail.Text;

                // Create a new user
                User newUser = new User
                {
                    UserId = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    City = city,
                    State = "",
                    Country = "",
                    Email = email,
                    Password = "",

                };

                _sharedViewModel.UsersList.Add(newUser);
                MessageBox.Show("User added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


                // Optionally, clear the textboxes after adding the user
                ClearTextBoxes();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void ClearTextBoxes()
        {
            // Clear the content of all textboxes
            txtUserId.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtCity.Clear();
            txtEmail.Clear();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NavigationService != null)
                {
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("NavigationService is null.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error hh", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



    }
}

