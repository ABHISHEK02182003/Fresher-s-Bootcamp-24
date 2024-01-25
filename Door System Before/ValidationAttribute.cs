using System;

namespace DoorsSystem
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ValidationAttribute : Attribute
    {
        public string ErrorMessage { get; }

        public ValidationAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public abstract bool IsValid(object value);
    }
}
