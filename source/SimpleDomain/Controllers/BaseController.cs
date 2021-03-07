namespace SimpleDomain.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;
    using SimpleDomain.Validation;

    public abstract class BaseController : ControllerBase
    {
        private readonly ILogger _logger;

        protected BaseController(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OkResult<TRequest, TResponse>(Func<TRequest, Task<TResponse>> handlerFunc, TRequest request)
        {
            return await Execute(handlerFunc, request, response => Ok(response));
        }

        public async Task<IActionResult> CreatedResult<TRequest, TResponse>(Func<TRequest, Task<TResponse>> handlerFunc, TRequest request, string uri)
        {
            return await Execute(handlerFunc, request, response => Created(uri, response));
        }

        public async Task<IActionResult> NoContentResult<TRequest, TResponse>(Func<TRequest, Task<TResponse>> handlerFunc, TRequest request)
        {
            return await Execute(handlerFunc, request, response => NoContent());
        }

        private async Task<IActionResult> Execute<TRequest, TResponse>(Func<TRequest, Task<TResponse>> handlerFunc, TRequest request, Func<TResponse, IActionResult> responseFunc)
        {
            IActionResult response;

            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var result = await handlerFunc.Invoke(request);

                response = responseFunc.Invoke(result);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message, exception);

                return BadRequest(exception.Message);
            }

            return response;
        }
    }
}
