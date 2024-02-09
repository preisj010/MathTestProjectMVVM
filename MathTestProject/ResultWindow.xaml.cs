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
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow(int correctAnswers, int incorrectAnswers, double averageGrade)
        {
            InitializeComponent();

            CorrectAnswersTextBlock.Text = $"Correct Answers: {correctAnswers}";
            IncorrectAnswersTextBlock.Text = $"Incorrect Answers: {incorrectAnswers}";
            AverageGradeTextBlock.Text = $"Your average grade is: {averageGrade}%";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
