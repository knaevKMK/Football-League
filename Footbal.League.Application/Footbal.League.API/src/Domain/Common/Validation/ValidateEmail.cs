namespace Domain.Common.Validation
{
    #region Usings
    using System.Text.RegularExpressions;
    #endregion

    public static class ValidateEmail
    {
        public static bool IsValid(string email)
        {
            return HandleValidation(email);
        }

        private static bool HandleValidation(string email)
        {
            string PATTERN = @"^[a-zA-Z]+[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            var isMatch = Regex.IsMatch(email, PATTERN);
            return isMatch;
        }
    }
}
