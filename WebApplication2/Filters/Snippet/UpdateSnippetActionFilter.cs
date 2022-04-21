using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication2.Service;

namespace WebApplication2.Filters.Snippet
{
    public class CheckSnippetExistFilter: Attribute, IAsyncActionFilter
    {
        // private readonly ISnippetService _snippetService;

        // public UpdateSnippetActionFilter(ISnippetService snippetService)
        // {
        //     _snippetService = snippetService;
        // }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = context.HttpContext.Request.RouteValues["id"];
            var snippetService = context.HttpContext.RequestServices.GetService(typeof(ISnippetService)) as ISnippetService;
            var sinppet = await snippetService.GetSnippetById(Convert.ToInt32(id));
            if (sinppet is null)
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}