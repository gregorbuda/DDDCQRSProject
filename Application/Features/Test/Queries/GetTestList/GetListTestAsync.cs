using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Test.Queries.GetTestList
{
    public class GetListTestAsync : IRequest<List<TestVm>>
    {
    }
}
