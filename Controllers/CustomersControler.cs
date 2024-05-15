using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignPLAPI.Application.Accounts.Commands.CreateAccount;
using SignPLAPI.Application.Accounts.Queries.GetAccounts;
using SignPLAPI.Application.Customers.Commands;
using SignPLAPI.Application.Customers.Commands.CreateCustomerFriendsDetailsCommand;
using SignPLAPI.Application.Customers.Commands.DeleteCustomerDetails;
using SignPLAPI.Application.Customers.Commands.UpdateCustomerDetails;
using SignPLAPI.Application.Customers.Queries.GetCustomerById;
using SignPLAPI.Application.Customers.Queries.GetCustomerFriends;
using SignPLAPI.Application.Customers.Queries.GetCustomers;
using SignPLAPI.Contracts.Accounts.CreateAccount;
using SignPLAPI.Contracts.Accounts.GetAccounts;
using SignPLAPI.Contracts.Customers.CreateCustomerFriendsDetails;
using SignPLAPI.Contracts.Customers.CreateCustomers;
using SignPLAPI.Contracts.Customers.DeleteCustomerDetails;
using SignPLAPI.Contracts.Customers.GetCustomerFriends;
using SignPLAPI.Contracts.Customers.GetCustomers;
using SignPLAPI.Contracts.Customers.GetCustomersById;
using SignPLAPI.Contracts.Customers.UpdateCustomerDetails;
using SignPLAPI.Domain.Customers;
using SignPLAPI.Infrastructure.Presistence;
using SignPLAPI.Service;

namespace SignPLAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CustomersControler : ControllerBase
    {
            private readonly JwtService _jwtService;

            private readonly ISender _mediator;
            private readonly IMapper _mapper;
        private readonly Customers _customerModels;

            public CustomersControler(IMediator mediator, IMapper mapper, JwtService jwtService)
            {
                _mediator = mediator;
                _mapper = mapper;
                _jwtService = jwtService;
            }

        [HttpGet("/GetCustomerAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccounts()
        {
            Guid UserId = _jwtService.ExtractJwt();
            var request = new TGetCustomerRequest(UserId);
            var query = _mapper.Map<GetCustomersRequest>(request);
            var authResult = await _mediator.Send(query);
            var response = _mapper.Map<TGetCustomerResponse>(authResult); 
            return Ok(response);
        }

        [HttpPost("/CreateCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAccount(TCreateCustomersRequest request)
        {
            var command = _mapper.Map<CreateCustomersCommand>(request);
            var authResult = await _mediator.Send(command);
            var response = _mapper.Map<TCreateCustomersResponse>(authResult);

            return Ok(response);
        }

        [HttpPut("/UpdateCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateCustomersDetails(TUpdateCustomersDetailsReq request)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(request);
            var authResult = await _mediator.Send(command);
            var response = _mapper.Map<TUpdateCustomersDetailsRes>(authResult);

            return Ok(response);
        }

        [HttpDelete("/DeleteCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> DeleteCustomerDetails([FromQuery]TDeleteCustomersDetailsReq request)
        {
          
            var query = _mapper.Map<DeleteCustomerCommands>(request);
            var authResult = await _mediator.Send(query);
            var response = _mapper.Map<TDeleteCustomersDetailsRes>(authResult);
            return Ok(response);
        }

        [HttpGet("/GetCustomersById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> GetCustomersById([FromQuery]TGetCustomersByIdReq getCustomersByIdReq)
        {
            var query = _mapper.Map<GetCustByIdQuery>(getCustomersByIdReq);
            var authResult = await _mediator.Send(query);
            var response = _mapper.Map<TGetCustomersByIdRes>(authResult);
            return Ok(response);
        }

        [HttpGet("/CustomerFriendsDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> GetCustomerFriend()
        {
            var request = new GetCustomerFriendsQuery();
            //var query = _mapper.Map<GetCustomerFriendsQuery>(request);
            var authResult = await _mediator.Send(request);
            var response = _mapper.Map<GetCustomerFriendRes>(authResult);
            return Ok(response);
        }

        [HttpPost("/CreateCustomerFriendsDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<IActionResult> CreateCustomerFriend(CreateCustomersFriendsDetailsRequest request)
        {
            var command = _mapper.Map<CreateCustomerFriendsDetailsCommand>(request);
            var authResult = await _mediator.Send(command);
            var response = _mapper.Map<CreateCustomersFriendsDetailsResponse>(authResult);
            return Ok(response);
        }
    }
        
}
