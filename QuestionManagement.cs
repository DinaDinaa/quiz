namespace QwizzPlatform
{
    public class QuestionManagement
    {
        public string QuestionText { get; set; }
        public List<string> PossibleAnswers { get; set; }
        public List<string> CorrectAnswers { get; set; }
        public bool AllowMultipleCorrectAnswers { get; set; }
        public int Points { get; set; }

        public QuestionManagement(string questionText, List<string> possibleAnswers, List<string> correctAnswers, bool allowMultipleCorrectAnswers, int points)
        {
            if (questionText.Length < 1 || questionText.Length > 2000)
                throw new ValidationException("Minimum 1 and maximum 2000 symbols.");

            if (possibleAnswers.Count < 2 || possibleAnswers.Count > 8)
                throw new ValidationException("Minumum 2 and maximum 8 possible answers.");

            foreach (var answer in possibleAnswers)
            {
                if (answer.Length < 1 || answer.Length > 250)
                    throw new ValidationException("Minimum 1 and maximum 250 symbols.");
            }

            if (correctAnswers.Distinct().Count() != correctAnswers.Count)
                throw new ValidationException("Correct answers must be unique.");

            if (correctAnswers.Count < 1 || (allowMultipleCorrectAnswers && correctAnswers.Count < 1))
                throw new ValidationException("At least 1 correct answer.");

            if (points < 1 || points > 5)
                throw new ValidationException("Minimum 1 and maximum 5 points.");

            QuestionText = questionText;
            PossibleAnswers = possibleAnswers;
            CorrectAnswers = correctAnswers;
            AllowMultipleCorrectAnswers = allowMultipleCorrectAnswers;
            Points = points;
        }
    }
}
