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
            (DataContext as QuizViewModel).NextQuestion();
        }

        private void OnRestartQuizClick(object sender, RoutedEventArgs e)
        {
            (DataContext as QuizViewModel).RestartQuiz();
        }
    }
}
