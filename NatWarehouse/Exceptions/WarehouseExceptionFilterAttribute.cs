using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NatWarehouse.Exceptions
{
    public class WarehouseExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if ((context.Exception as WarehouseApplicationException) == null)
            {
                return;
            }

            var exception = context.Exception as WarehouseApplicationException;

            switch (exception.getExceptionCode()) {
                case ExceptionCode.EntityNotFound:
                    context.Result = new NotFoundResult();
                    break;
                case ExceptionCode.InvalidState:
                    context.Result = new BadRequestResult();
                    break;
            }
        }
    }
}
