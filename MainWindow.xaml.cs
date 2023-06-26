using System.Windows;

namespace QuizApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new QuizViewModel();
        }

        private void OnCheckAnswerClick(object sender, RoutedEventArgs e)
        {
            (DataContext as QuizViewModel).CheckAnswer();
        }

        private void OnNextQuestionClick(object sender, RoutedEventArgs e)
        {
            // Add logic to move to next question
        }

        private void OnRestartQuizClick(object sender, RoutedEventArgs e)
        {
            // Add logic to restart the quiz
        }
    }
}