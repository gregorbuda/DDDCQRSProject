using Application.Contracts.Persistence;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Test.Commands.CreateTest
{
    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTestCommandHandler> _logger;

        public CreateTestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateTestCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            var testEntity = _mapper.Map<TestClass>(request);

            _unitOfWork.TestRepository.AddEntity(testEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el registro de streamer");
            }
            _logger.LogInformation($"Streamer {testEntity.Id} fue creado existosamente");

            return testEntity.Id;
        }
    }
}
