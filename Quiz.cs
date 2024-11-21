namespace QwizzPlatform
{
    public class Quiz
    {
        private TestManagement _test;
        private int _timeLimit;
        private int _correctPoints;
        private int _totalPoints;
        private DateTime _startTime;

        public Quiz(TestManagement test)
        {
            _test = test;
            _timeLimit = test.TestTime * 60;
            _totalPoints = test.Questions.Sum(q => q.Points);
        }

        public void Start(List<List<int>> userAnswers)
        {
            _startTime = DateTime.Now;

            foreach (var question in _test.Questions)
            {
                if ((DateTime.Now - _startTime).TotalSeconds > _timeLimit)
                {
                    break;
                }

                List<int> answers = userAnswers.First();
                userAnswers.RemoveAt(0);

                bool isCorrect = ValidateAnswers(answers, question);
                if (isCorrect)
                {
                    _correctPoints += question.Points;
                }
            }

            EndTest();
        }

        private bool ValidateAnswers(List<int> userAnswers, QuestionManagement question)
        {
            if (question.AllowMultipleCorrectAnswers)
            {
                return userAnswers.OrderBy(x => x).SequenceEqual(question.CorrectAnswers.Select(a => question.PossibleAnswers.IndexOf(a) + 1).OrderBy(x => x));
            }
            else
            {
                return userAnswers.Count == 1 && userAnswers[0] == question.PossibleAnswers.IndexOf(question.CorrectAnswers.First()) + 1;
            }
        }

        private void EndTest()
        {
            double result = (double)_correctPoints / _totalPoints;
        }
    }
}
