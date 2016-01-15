using System.ComponentModel.DataAnnotations;

namespace PGP.Infrastructure.Framework.Tests.Commons.DomainSpecifications
{
    public class MustComplyEntity
    {
        [Required]
        public string Name { get; set; }

        [MinLength(2)]
        public string NameMinLength { get; set; }
    }
}