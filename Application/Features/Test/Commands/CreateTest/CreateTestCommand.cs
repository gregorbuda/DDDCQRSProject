using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Test.Commands.CreateTest
{
    public class CreateTestCommand : IRequest<int>
    {
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }
    }
}
