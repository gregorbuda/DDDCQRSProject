using Application.Features.Test.Commands.CreateTest;
using Application.Features.Test.Queries.GetTestList;
using Application.Response;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class TestController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{name}", Name = "GetTest")]
        [ProducesResponseType(typeof(IEnumerable<TestClass>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<TestClass>>>> GetTestByUsername(string name)
        {
            var query = new GetTestListQuery(name);
            var test = await _mediator.Send(query);
            return Ok(test);
        }


        [HttpGet(Name = "GetTestAll")]
        [ProducesResponseType(typeof(IEnumerable<TestClass>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TestClass>>> GetTestAll()
        {
            var query = new GetListTestAsync();
            var test = await _mediator.Send(query);
            return Ok(test);
        }

        [HttpPost(Name = "CreateStreamer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateTestCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
