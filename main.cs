using System;
using System.Collections.Generic;
using System.Linq;

namespace QwizzPlatform
{
    internal static class Program
    {
        static void Main()
        {
            List<string> existingEmails = new();

            try
            {
                string name = "John Doe";
                string email = "john.doe@example.com";
                string password = "Password123";

                Validation.ValidateName(name);
                Validation.ValidateEmail(email, existingEmails);
                existingEmails.Add(email);
                Validation.ValidatePassword(password);

                var user = new User(name, email, password);
            }
            catch (ValidationException)
            {
                throw new ValidationException();
            }

            try
            {
                var test = new TestManagement("C# basics", 30);

                var question1 = new QuestionManagement(
                    "What is it C#?",
                    new List<string> { "Programming language", "Framework", "Interface" },
                    new List<string> { "Programming language" },
                    false,
                    2
                );
                test.AddQuestion(question1);

                var quiz = new Quiz(test);
                var userAnswers = new List<List<int>> {
                    new List<int> { 1 }
                };
                quiz.Start(userAnswers);
            }
            catch (ValidationException)
            {
                throw new ValidationException();
            }
        }
    }
}
