using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;


namespace Application.Features.Test.Queries.GetTestList
{
    public class GetListTestAsyncHandler : IRequestHandler<GetListTestAsync, List<TestVm>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetListTestAsyncHandler(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _UnitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TestVm>> Handle(GetListTestAsync request, CancellationToken cancellationToken)
        {
            var testList = await _UnitOfWork.TestRepository.GetAllAsync();

            return _mapper.Map<List<TestVm>>(testList);
        }
    }
}
