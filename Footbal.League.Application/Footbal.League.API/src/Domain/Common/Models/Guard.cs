namespace Domain.Common.Models
{
    using Domain.Common.Validation;
    using System;

    public static class Guard
    {
        public static void ForValidGuid<TException>(string value, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (Guid.TryParse(value, out _))
            {
                return;
            }

            ThrowException<TException>($"{name} is not valid Guid ID.");
        }

        public static void AgainstEmptyString<TException>(string value, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null ot empty.");
        }

        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        public static void ForValidUrl<TException>(string url, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (url.Length <= ModelConstants.Common.MaxUrlLength &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return;
            }

            ThrowException<TException>($"{name} must be a valid URL.");
        }

        public static void Against<TException>(object actualValue, object unexpectedValue, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!actualValue.Equals(unexpectedValue))
            {
                return;
            }

            ThrowException<TException>($"{name} must not be {unexpectedValue}.");
        }

        public static void ForValidEGN<TException>(string egn)
            where TException : BaseDomainException, new()
        {
            var isEgnValid = ValidateEgn.IsValid(egn);

            if (isEgnValid == true)
            {
                return;
            }

            ThrowException<TException>($"Egn {egn} is not valid!");
        }

        public static void ForValidEmail<TException>(string email)
            where TException : BaseDomainException, new()
        {
            var isEmailValid = ValidateEmail.IsValid(email);

            if (isEmailValid == true)
            {
                return;
            }

            ThrowException<TException>($"Email {email} is not valid!");
        }

        public static void ForValidPhoneNumber<TException>(string phoneNumber)
            where TException : BaseDomainException, new()
        {
            var isPhoneNumberValid = ValidatePhone.IsValid(phoneNumber);

            if (isPhoneNumberValid == true)
            {
                return;
            }

            ThrowException<TException>($"Phone number {phoneNumber} is not valid!");
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Error = message
            };

            throw exception;
        }
    }
}
