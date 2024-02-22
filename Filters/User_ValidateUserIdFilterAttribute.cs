using Microsoft.AspNetCore.Mvc.Filters;
using bankApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.Filters
{

  public class ValidateUserIdFilterAttribute : ActionFilterAttribute
  {

    public override void OnActionExecuting(ActionExecutingContext context)
    {
      base.OnActionExecuting(context);

      var id = context.ActionArguments["id"] as int?;

      if (id.HasValue)
      {

        if (id.Value < 1)
        {
          context.ModelState.AddModelError("Id", "Id must be greater than 0");
          var problemDetails = new ValidationProblemDetails(context.ModelState)
          {
            Status=StatusCodes.Status400BadRequest

          };

          context.Result = new BadRequestObjectResult(problemDetails);


        }

        else if (!LoanRepository.UserExists(id.Value))
        {
          context.ModelState.AddModelError("Id", "User does not exist");
          var problemDetails = new ValidationProblemDetails(context.ModelState)
          {
            Status=StatusCodes.Status404NotFound

          };

          context.Result = new NotFoundObjectResult(problemDetails);

        }
      }
    }
  }
}
