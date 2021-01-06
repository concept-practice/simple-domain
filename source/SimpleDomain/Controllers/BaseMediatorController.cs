using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleDomain.Validation;

namespace SimpleDomain.Controllers
{
    public abstract class BaseMediatorController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        protected BaseMediatorController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected async Task<IActionResult> HandleOk<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => Ok(response));
        }

        protected async Task<IActionResult> HandleCreated<TResponse>(IRequest<TResponse> request, Func<TResponse, Uri> uriFunc)
        {
            return await Execute(request, response => Created(uriFunc.Invoke(response), response));
        }

        protected async Task<IActionResult> HandleNoContent<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => NoContent());
        }

        private async Task<IActionResult> Execute<TResponse>(IRequest<TResponse> request, Func<TResponse, IActionResult> responseFunc)
        {
            IActionResult response;

            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var result = await _mediator.Send(request);

                response = responseFunc.Invoke(result);
            }
            catch (Exception exception)
            {
                _logger.Log(LogLevel.Error, exception.Message, exception, exception);

                return BadRequest(exception.Message);
            }

            return response;
        }
    }
}
