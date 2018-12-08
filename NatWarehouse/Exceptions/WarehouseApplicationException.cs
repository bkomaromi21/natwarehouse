using System;
namespace NatWarehouse.Exceptions
{
    /// <summary>
    /// Warehouse application exception, for using with business-logic related problems.
    /// </summary>
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
