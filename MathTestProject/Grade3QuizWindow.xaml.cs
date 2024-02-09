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
    /// Interaction logic for Grade3QuizWindow.xaml
    /// </summary>
    public partial class Grade3QuizWindow : Window
    {
        private int currentQuestionIndex = 0;
        private int correctAnswers = 0;
        private int incorrectAnswers = 0;
        private int totalQuestions = 10; // Set the total number of questions
        private Random random = new Random();

        public Grade3QuizWindow()
        {
            InitializeComponent();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            int num1 = random.Next(1, 11);
            int num2 = random.Next(1, 11);

            // For Grade 3, perform multiplication
            int correctAnswer = num1 * num2;

            QuestionTextBlock.Text = $"{num1} * {num2} = ?";
            CounterTextBlock.Text = $"Question {currentQuestionIndex + 1} of {totalQuestions}";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AnswerTextBox.Text, out int userAnswer))
            {
                CheckAnswer(userAnswer);
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Error");
            }
            AnswerTextBox.Text = "";
        }


        private void CheckAnswer(int userAnswer)
        {

            if (userAnswer == GetCorrectAnswer())
            {
                correctAnswers++;
            }
            else
            {
                incorrectAnswers++;
            }

            // Move to the next question or finish the quiz
            currentQuestionIndex++;

            if (currentQuestionIndex < totalQuestions)
            {
                GenerateQuestion();
            }
            else
            {
                ShowResultWindow();
            }
        }

        private void ShowResultWindow()
        {
            double averageGrade = (double)correctAnswers / totalQuestions * 100;
            ResultWindow resultWindow = new ResultWindow(correctAnswers, incorrectAnswers, averageGrade);
            resultWindow.Show();


            this.Close();
        }

        private int GetCorrectAnswer()
        {
            int num1 = int.Parse(QuestionTextBlock.Text.Split(' ')[0]);
            int num2 = int.Parse(QuestionTextBlock.Text.Split(' ')[2]);

            // For Grade 3, perform multiplication
            return num1 * num2;
        }
    }
}
