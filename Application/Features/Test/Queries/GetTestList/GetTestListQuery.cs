using Application.Response;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Test.Queries.GetTestList
{
    public class GetTestListQuery : IRequest<ApiResponse<IEnumerable<TestClass>>>
    {
        public string _Nombre { get; set; } = String.Empty;

        public GetTestListQuery(string nombre)
        {
            _Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        }
    }
}
