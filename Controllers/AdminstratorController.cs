using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignPLAPI.Application.Adminstrator.Commands.AddAccountCredit;
using SignPLAPI.Application.Adminstrator.Commands.NewCustomerAccount;
using SignPLAPI.Contracts.Adminstrator.AddAccountCredit;
using SignPLAPI.Contracts.Adminstrator.NewCustomerAccount;
using System.Data;

namespace SignPLAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("/admin")]
    public class AdminstratorController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AdminstratorController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost("credit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddAccountCredit(TAddAccountCreditRequest request)
        {
            var command = _mapper.Map<AddAccountCreditCommand>(request);
            var authResult = await _mediator.Send(command);
            var response = _mapper.Map<TAddAccountCreditResponse>(authResult);
            return Ok(response);
        }

        [HttpPost("customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> NewCustomerAccount(TNewCustomerAccountRequest request)
        {
            var command = _mapper.Map<TNewCustomerAccountCommand>(request);
            var authResult = await _mediator.Send(command);
            var response = _mapper.Map<TNewCustomerAccountResponse>(authResult);
            return Ok(response);
        }
    }
}
