using DiffApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Controllers
{
    public abstract class ApiControllerBase : Controller, IAsyncActionFilter
    {
        protected IDataService DataService { get; private set; }


        protected ApiControllerBase(IDataService dataService)
        {
            DataService = dataService;
        }

        [NonAction]
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();
        }

    }
}
