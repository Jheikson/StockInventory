using System;
using System.ComponentModel.DataAnnotations;
namespace StockInventory.CustomAttributes
{
    public class CustomAttribute
    {
    }

    [AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
    public class NotEmptyAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not be empty";
        public NotEmptyAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            else if (value.GetType() == typeof(Guid))
            {
                return (Guid)value != Guid.Empty;
            }
            return true;
        }
    }
}


