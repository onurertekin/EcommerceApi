using Contract.Response.Dashboard;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("library-api/dashboard")]
    public class DashboardController : BaseController
    {

        [HttpGet("most-viewed-products")]
        public ActionResult<SearchDashboardResponse> Get()
        {
            SearchDashboardResponse response= new SearchDashboardResponse();
            response.xValues = new List<string> { "Telefon", "Bilgisayar", "Tablet", "Klavye", "Mouse" };
            response.yValues = new List<string> { "55", "49", "44", "24", "15" };
            return new JsonResult(response);
        }
    }
}
