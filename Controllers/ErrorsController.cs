using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignPLAPI.Application.Common.Errors;

namespace SignPLAPI.Controllers
{

    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            //accessing the thrown exception.
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "User already exists."),
                TInvalidUser => (StatusCodes.Status404NotFound, "User doesn't exists."),
                TInvalidAccount => (StatusCodes.Status404NotFound, "Invalid UserAccount."),
                TInvalidPassword => (StatusCodes.Status400BadRequest, "Invalid Password or Username combination."),
                TInvalidFrequency => (StatusCodes.Status400BadRequest, "Invalid Frequency or Authentication Token."),
                TInvalidTransferAmount => (StatusCodes.Status400BadRequest, "The Transfer Amount Must Be Positive."),
                TInvalidTransferOperation => (StatusCodes.Status400BadRequest, "No such transfer operation, See Documentation for further information."),
                TInvalidTransfer => (StatusCodes.Status400BadRequest, "Invalid Account Ownership or account not in existence"),
                TInsufficientFunds => (StatusCodes.Status400BadRequest, "Insufficient funds or you're not the owner of both accounts, change operation!"),
                TInternalServerError => (StatusCodes.Status500InternalServerError, "Internal server error."),
                TRequieredFrequencyForSavingAcc => (StatusCodes.Status400BadRequest, "Invalid Frequency interval for a Savings Account"),
                TInvalidCustomer => (StatusCodes.Status400BadRequest, "Something went wrong! No customer in database."),
                _ => (StatusCodes.Status500InternalServerError, "An error occurred.") // default response for unhandled exceptions
            };
            return Problem(statusCode: statusCode, title: message);
        }
    }
}
