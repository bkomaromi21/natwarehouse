using System;
namespace NatWarehouse.Exceptions
{
    public class WarehouseApplicationException : Exception
    {
        ExceptionCode exceptionCode;

        public WarehouseApplicationException(ExceptionCode exceptionCode)
        {
            this.exceptionCode = exceptionCode;
        }

        public ExceptionCode getExceptionCode() {
            return this.exceptionCode;
        }
    }
}
