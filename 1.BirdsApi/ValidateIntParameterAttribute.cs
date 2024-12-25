using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace _1.BirdsApi
{
    public class ValidateIntParameterAttribute : ActionFilterAttribute
    {
        private readonly string _parameterName;

        public ValidateIntParameterAttribute(string parameterName)
        {
            _parameterName = parameterName;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey(_parameterName))
            {
                if (context.ActionArguments[_parameterName] is int)
                {
                    return;
                }
            }

            context.Result = new BadRequestObjectResult(new { message = $"The parameter '{_parameterName}' is invalid." });
        }
    }

}
