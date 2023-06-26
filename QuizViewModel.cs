using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace QuizApp
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        private int _currentQuestionIndex = 0;

        public QuizQuestion CurrentQuestion => _questions[_currentQuestionIndex];

        private List<QuizQuestion> _questions = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Question = "What keyword is used to create an instance of a class?",
                PotentialAnswers = new ObservableCollection<QuizAnswer>
                {
                    new QuizAnswer { Answer = "class", IsCorrect = false },
                    new QuizAnswer { Answer = "new", IsCorrect = true },
                    new QuizAnswer { Answer = "this", IsCorrect = false }
                }
            },
            new QuizQuestion
            {
                Question = "What symbol is used to denote the start of a block of code?",
                PotentialAnswers = new ObservableCollection<QuizAnswer>
                {
                    new QuizAnswer { Answer = "(", IsCorrect = false },
                    new QuizAnswer { Answer = "{", IsCorrect = true },
                    new QuizAnswer { Answer = "[", IsCorrect = false }
                }
            }
        };

        private string _resultMessage = "";
        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                _resultMessage = value;
                OnPropertyChanged(nameof(ResultMessage));
            }
        }

        private SolidColorBrush _resultColor = Brushes.Black;
        public SolidColorBrush ResultColor
        {
            get { return _resultColor; }
            set
            {
                _resultColor = value;
                OnPropertyChanged(nameof(ResultColor));
            }
        }

        public void CheckAnswer()
        {
            QuizAnswer selectedAnswer = CurrentQuestion.PotentialAnswers.FirstOrDefault(a => a.IsSelected);

            if (selectedAnswer != null)
            {
                if (selectedAnswer.IsCorrect)
                {
                    ResultMessage = "Correct!";
                    ResultColor = Brushes.Green;
                }
                else
                {
                    ResultMessage = "Incorrect!";
                    ResultColor = Brushes.Red;
                }
            }
            else
            {
                ResultMessage = "No answer selected!";
                ResultColor = Brushes.Orange;
            }
        }

        public void NextQuestion()
        {
            if (_currentQuestionIndex < _questions.Count - 1)
            {
                _currentQuestionIndex++;
                OnPropertyChanged(nameof(CurrentQuestion));
            }

            foreach (QuizAnswer answer in CurrentQuestion.PotentialAnswers)
            {
                answer.IsSelected = false;
            }

            ResultMessage = "";
            ResultColor = Brushes.Black;
        }

        public void RestartQuiz()
        {
            _currentQuestionIndex = 0;
            OnPropertyChanged(nameof(CurrentQuestion));

            foreach (QuizAnswer answer in CurrentQuestion.PotentialAnswers)
            {
                answer.IsSelected = false;
            }

            ResultMessage = "";
            ResultColor = Brushes.Black;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
