using Microsoft.AspNetCore.Mvc;
using WareHouseAPI.Database;

namespace WareHouseAPI.Controllers
{
    /// <summary>
    /// Base controller for API controllersstockElementToAdd
    /// </summary>
    public class BaseAPIController : Controller
    {
        protected WarehouseDbContext context;

        public BaseAPIController(WarehouseDbContext context)
        {
            this.context = context;
        }
    }
}
