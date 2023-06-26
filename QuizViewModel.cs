using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace QuizApp
{
    public class QuizViewModel : INotifyPropertyChanged
    {
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

        private QuizQuestion _currentQuestion;
        public QuizQuestion CurrentQuestion
        {
            get { return _currentQuestion; }
            set
            {
                _currentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
                OnPropertyChanged(nameof(Question));
                OnPropertyChanged(nameof(PotentialAnswers));
            }
        }

        public string Question => CurrentQuestion.Question;
        public ObservableCollection<QuizAnswer> PotentialAnswers
        {
            get
            {
                return CurrentQuestion?.PotentialAnswers;
            }
        }


        private string _selectedAnswer;
        public string SelectedAnswer
        {
            get { return _selectedAnswer; }
            set
            {
                _selectedAnswer = value;
                OnPropertyChanged(nameof(SelectedAnswer));
            }
        }

        private string _resultMessage;
        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                _resultMessage = value;
                OnPropertyChanged(nameof(ResultMessage));
            }
        }

        private SolidColorBrush _resultColor;
        public SolidColorBrush ResultColor
        {
            get { return _resultColor; }
            set
            {
                _resultColor = value;
                OnPropertyChanged(nameof(ResultColor));
            }
        }

        private bool _isFinished;
        public bool IsFinished
        {
            get { return _isFinished; }
            set
            {
                _isFinished = value;
                OnPropertyChanged(nameof(IsFinished));
            }
        }

        public QuizViewModel()
        {
            CurrentQuestion = _questions[0];
        }

        public void CheckAnswer()
        {
            QuizAnswer selectedAnswer = CurrentQuestion.PotentialAnswers.FirstOrDefault(a => a.Answer == SelectedAnswer);
            if (selectedAnswer != null && selectedAnswer.IsCorrect)
            {
                ResultMessage = "Correct!";
                ResultColor = Brushes.Green;
            }
            else
            {
                ResultMessage = "Incorrect!";
                ResultColor = Brushes.Red;
            }
            IsFinished = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}