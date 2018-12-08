using Microsoft.AspNetCore.Mvc;
using NatWarehouse.Exceptions;

namespace NatWarehouse.Controllers
{
    /// <summary>
    /// Base class for the web api controllers. Only function is to add the custom exception filter for the chain.
    /// </summary>
    [WarehouseExceptionFilter]
	public class WarehouseController : Controller
    {
    }
}
