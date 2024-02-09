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
    /// Interaction logic for Grade4QuizWindow.xaml
    /// </summary>
    public partial class Grade4QuizWindow : Window
    {
        private int currentQuestionIndex = 0;
        private int correctAnswers = 0;
        private int incorrectAnswers = 0;
        private int totalQuestions = 10;
        private Random random = new Random();

        public Grade4QuizWindow()
        {
            InitializeComponent();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            int num1, num2;

            // Randomly decide between multiplication and division
            bool isMultiplication = random.Next(0, 2) == 0;

            if (isMultiplication)
            {
                // For multiplication, use numbers between 1 and 10
                num1 = random.Next(1, 11);
                num2 = random.Next(1, 11);
            }
            else
            {
                // For division, use numbers between 1 and 100 with no remainder
                num2 = random.Next(1, 101);

                // Ensure that num1 is a multiple of num2 to avoid decimals
                int maxQuotient = random.Next(1, 101 / num2);
                num1 = num2 * maxQuotient;
            }

            // Calculate correct answer
            int correctAnswer = isMultiplication ? num1 * num2 : num1 / num2;

            // Display the question based on the operation
            string operationSymbol = isMultiplication ? "*" : "/";
            QuestionTextBlock.Text = $"{num1} {operationSymbol} {num2} = ?";
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

            // Randomly decide between multiplication and division
            bool isMultiplication = QuestionTextBlock.Text.Contains("*");

            // For Grade 4, perform multiplication or division
            return isMultiplication ? num1 * num2 : num1 / num2;
        }
    }
}
