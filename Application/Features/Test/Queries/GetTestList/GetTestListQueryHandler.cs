using Application.Contracts.Persistence;
using Application.Response;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Test.Queries.GetTestList
{
    public class GetTestListQueryHandler : IRequestHandler<GetTestListQuery, ApiResponse<IEnumerable<TestClass>>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTestListQueryHandler(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _UnitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TestClass>>> Handle(GetTestListQuery request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IEnumerable<TestClass> testList = null;
            String CodeResult = "";

            try
            {
                testList = await _UnitOfWork.TestRepository.GetTestByName(request._Nombre);
                if(testList.Count() > 0)
                {
                    CodeResult = "200";
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = "404";
                    Message = "Test Not Found";
                    testList = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = "500";
                Message = "Server Error";
                testList = null;
                success = false;
            }

            ApiResponse<IEnumerable<TestClass>> response = new ApiResponse<IEnumerable<TestClass>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = testList,
                Success = success
            };

            return response;
        }
    }
}
