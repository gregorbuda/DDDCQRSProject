using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public  class TestClass : BaseDomainModel
    {
        [Required]
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
    }
}
