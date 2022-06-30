using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4b.Controllers
{
    [RoutePrefix("2")]
    public class AResearchController : Controller
    {
        [HttpGet]
        [Route("aa")]
        [ActionFilter]
        public ActionResult AA()
        {
            return Content("<p>Action 'AA' content</p>");
        }

        [HttpGet]
        [Route("ar")]
        [ResultFilter]
        public ActionResult AR()
        {
            return Content("<p>Action 'AR' content</p>");
        }

        [HttpGet]
        [Route("ae")]
        [ExecptionFilter]
        public ActionResult AE()
        {
            throw new Exception("Exception from action 'AE'");
            return Content("<p>Action 'AR' content</p>");
        }

        //action filter, result filter , exception filter

        public class ActionFilterAttribute : FilterAttribute, IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>Action Filter executed</p>");
            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>Action Filter executing</p>");
            }
        }

        public class ResultFilterAttribute : FilterAttribute, IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>Result Filter executed</p>");
            }

            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>Result Filter executing</p>");
            }
        }

        public class ExecptionFilterAttribute : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>Exception Filter executing</p>");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}