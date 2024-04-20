using Microsoft.AspNetCore.Mvc.Filters;

namespace AECProject.Fitters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        //after ,befor ,during
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";
            context.Result= viewResult;
        }
    }
}
