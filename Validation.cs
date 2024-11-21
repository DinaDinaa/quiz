namespace QwizzPlatform
{
    public static class Validation
    {
        public static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 1 || name.Length > 100)
                throw new ValidationException("Minimum1 and maximum 100 symbols.");
        }

        public static void ValidateEmail(string email, List<string> existingEmails)
        {
            if (string.IsNullOrEmpty(email))
                throw new ValidationException("Email must not be empty.");

            if (!email.Contains("@") || !email.Contains("."))
                throw new ValidationException("Email format must be example@mail.com.");

            if (email.Length >= 100)
                throw new ValidationException("Maximum 100 symbols");

            if (existingEmails.Contains(email))
                throw new ValidationException("Email is already registered");
        }

        public static void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8 || password.Length > 16)
                throw new ValidationException("Minimum 8 and maximum 8 symbols");
        }
    }
}
