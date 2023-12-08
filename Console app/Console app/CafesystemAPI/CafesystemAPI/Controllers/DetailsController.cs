using CafesystemAPI.Logics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafesystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly DetailsLogic logic;

        public DetailsController()
        {
            logic = new DetailsLogic();
        }
        [HttpGet]
        [Route("DetailsList")]
        public IActionResult DetailsList ()
        {
            try 
            {
                return Ok(logic.DetailsList());
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
