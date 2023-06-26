using System.Collections.ObjectModel;

public class QuizQuestion
{
    public string Question { get; set; }
    public ObservableCollection<QuizAnswer> PotentialAnswers { get; set; }
}
