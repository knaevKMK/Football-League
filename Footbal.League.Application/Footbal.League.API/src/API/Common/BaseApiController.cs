namespace Web.Controllers
{

    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters; 
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]/[action]")]
    public abstract class BaseApiController<T> : Controller
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";

        private IMediator? mediator;
        protected readonly ILogger<T> _logger;
        private readonly IConfiguration _configfuration; 

        protected BaseApiController(ILogger<T> logger, IConfiguration configfuration)
        {
            _logger = logger;
            _configfuration = configfuration;
        }

        protected BaseApiController(
            ILogger<T> logger,
            IConfiguration configfuration,
            IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _configfuration = configfuration; 
        }

        protected IMediator _mediator
            => this.mediator ??= this.HttpContext
                    .RequestServices
                    .GetService<IMediator>()!;

        public override void OnActionExecuted(ActionExecutedContext context)
        {
          //todo implement it 

            base.OnActionExecuted(context);
        }
    }
}
