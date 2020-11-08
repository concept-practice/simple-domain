using System.ComponentModel.DataAnnotations;

namespace SimpleDomain.Tests.Validation
{
    public class ObjectVerificationTest
    {
        [Required]
        public string Value { get; set; }
    }
}
