namespace QwizzPlatform
{
    public class TestManagement
    {
        public string TestName { get; set; }
        public int TestTime { get; set; }
        public List<QuestionManagement> Questions { get; set; }
        private static List<TestManagement> AllTests = new List<TestManagement>();

        public TestManagement(string testName, int testTime)
        {
            if (testName.Length < 1 || testName.Length > 100)
                throw new ValidationException("Minimum 1 and maximum 100 symbols.");

            if (testTime < 1 || testTime > 60)
                throw new ValidationException("Minimum 1 and maximum 60 minutes.");

            TestName = testName;
            TestTime = testTime;
            Questions = new List<QuestionManagement>();

            AllTests.Add(this);
        }

        public void AddQuestion(QuestionManagement question)
        {
            if (Questions.Count >= 100)
                throw new ValidationException("Maximum 100 questions.");

            Questions.Add(question);
        }

        public static List<TestManagement> GetAllTests() => AllTests;
    }
}
