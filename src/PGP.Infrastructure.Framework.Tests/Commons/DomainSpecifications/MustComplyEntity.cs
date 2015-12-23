using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
