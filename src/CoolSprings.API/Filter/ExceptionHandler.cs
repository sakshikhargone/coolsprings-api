using Microsoft.AspNetCore.Http.Extensions;

namespace CoolSprings.API.Filter
{
    public class ApiException : ExceptionFilterAttribute
    {
        private IExceptionRepository _exceptionRepo;

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            _exceptionRepo = context.HttpContext.RequestServices.GetService<IExceptionRepository>();

            if (_exceptionRepo != null)
            {
                var exceptionDetail = new ExceptionLog
                {
                    Id = Guid.NewGuid(),
                    StackTrace = context.Exception.StackTrace,
                    Message = context.Exception.Message,
                    RequestUrl = context.HttpContext.Request.GetEncodedUrl(),
                    CreatedAt = DateTime.Now,
                };
                await _exceptionRepo.AddException(exceptionDetail);
            }

            var encodedUrl = context.HttpContext.Request.GetEncodedUrl();
            context.Result = new ObjectResult("An unexpected error occurred")
            {
                StatusCode = 500,
                Value = Uri.UnescapeDataString(encodedUrl)
            };

            await base.OnExceptionAsync(context);
        }
    }
}
