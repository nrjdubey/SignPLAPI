using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignPLAPI.Application.Accounts.Commands.CreateAccount;
using SignPLAPI.Application.Accounts.Queries.GetAccounts;
using SignPLAPI.Application.Accounts.Queries.GetTransactionsByAccId;
using SignPLAPI.Application.Transactions.Transfer;
using SignPLAPI.Contracts.Accounts.CreateAccount;
using SignPLAPI.Contracts.Accounts.GetAccount;
using SignPLAPI.Contracts.Accounts.GetAccounts;
using SignPLAPI.Contracts.Transactions.Transfer;
using SignPLAPI.Service;
using System.Data;

namespace SignPLAPI.Controllers
{

    [Route("/Accounts")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly JwtService _jwtService;

        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CustomersController(IMediator mediator, IMapper mapper, JwtService jwtService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAccount(TCreateAccountRequest request)
        {
            // API act as client, login function replicate regular login system therefore extract JWT.
            Guid userId = _jwtService.ExtractJwt();
            var requestData = new TCreateAccountRequestData(userId, request.Frequency, request.AccountTypesId);

            var command = _mapper.Map<TCreateAccountCommand>(requestData);
            var authResult = await _mediator.Send(command);
            var response = _mapper.Map<TCreateAccountResponse>(authResult);

            return Ok(response);
        }

        [HttpPost("transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Transfer(TTransferRequest request)
        {
            // API act as client, login function replicate regular login system therefore extract JWT.
            Guid userId = _jwtService.ExtractJwt();
            var requestData = new TTransferRequestData(userId, request.AccountId, request.Operation, request.Amount, request.Account);

            var command = _mapper.Map<TTransferCommand>(requestData);
            var authResult = await _mediator.Send(command);
            var response = _mapper.Map<TTransferResponse>(authResult);

            return Ok(response);
        }

        [HttpGet("/GetAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccounts()
        {
            Guid UserId = _jwtService.ExtractJwt();
            var request = new TGetAccountsRequest(UserId);

            var query = _mapper.Map<TGetAccountsQuery>(request);
            var authResult = await _mediator.Send(query);
            var response = _mapper.Map<TGetAccountsResponse>(authResult);

            return Ok(response);
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTransactionsByAccId([FromQuery] TGetTransactionsByAccIdResultRequest request)
        {
            Guid userId = _jwtService.ExtractJwt();

            var requestData = new TGetTransactionsByAccIdResultRequestData(userId, request.AccountId);

            var query = _mapper.Map<TGetTransactionsByAccIdQuery>(requestData);

            var authResult = await _mediator.Send(query);

            var response = _mapper.Map<TGetTransactionsByAccIdResultResponse>(authResult);

            return Ok(response);
        }
    }
}
