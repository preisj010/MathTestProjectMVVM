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

namespace MathTestProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(string name)
        {
            InitializeComponent();
            name1 = name;
            UserName.Text = $"Hello! {name1}";
        }

        private string name1;

        private void SubmitButton_Click1(object sender, RoutedEventArgs e)
        {
            string userName = name1;

            if (!string.IsNullOrEmpty(userName))
            {
                MessageBox.Show($"Hello, {userName}!", "Welcome");
            }
            else
            {
                MessageBox.Show("Please enter your name.", "Error");
            }
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if both the name and grade are entered
            if (string.IsNullOrEmpty(name1) || !(Grade1RadioButton.IsChecked.HasValue && Grade2RadioButton.IsChecked.HasValue
                && Grade3RadioButton.IsChecked.HasValue && Grade4RadioButton.IsChecked.HasValue &&
                (Grade1RadioButton.IsChecked.Value || Grade2RadioButton.IsChecked.Value ||
                Grade3RadioButton.IsChecked.Value || Grade4RadioButton.IsChecked.Value)))
            {
                MessageBox.Show("Please select a grade.", "Error");
                return; // Exit the method if conditions are not met
            }

            // Get the selected grade
            string selectedGrade = GetSelectedGrade();

            // Display a message indicating the selected grade
            MessageBox.Show($"You selected Grade {selectedGrade}", "Selected Grade");

            // Navigate to the appropriate quiz window based on the selected grade
            switch (selectedGrade)
            {
                case "1":
                    Grade1QuizWindow grade1Window = new Grade1QuizWindow();
                    this.Close();
                    grade1Window.Show();
                    break;
                case "2":
                    Grade2QuizWindow grade2Window = new Grade2QuizWindow();
                    this.Close();
                    grade2Window.Show();
                    break;
                case "3":
                    Grade3QuizWindow grade3Window = new Grade3QuizWindow();
                    this.Close();
                    grade3Window.Show();
                    break;
                case "4":
                    Grade4QuizWindow grade4Window = new Grade4QuizWindow();
                    this.Close();
                    grade4Window.Show();
                    break;
                default:
                    MessageBox.Show("Invalid grade selection.", "Error");
                    break;
            }
        }

        private string GetSelectedGrade()
        {
            if (Grade1RadioButton.IsChecked.Value)
                return "1";
            else if (Grade2RadioButton.IsChecked.Value)
                return "2";
            else if (Grade3RadioButton.IsChecked.Value)
                return "3";
            else if (Grade4RadioButton.IsChecked.Value)
                return "4";
            else
                return null;
        }

    }
}
