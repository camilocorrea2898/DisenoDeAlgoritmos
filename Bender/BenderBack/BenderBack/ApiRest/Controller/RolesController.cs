using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly Model.Bender.BenderContext _context = new();
        private List<Dto.Bender.Roles.GetData> objGetData = new();

        // GET  User/GetAll
        [HttpGet("GetAll")]
        public List<Dto.Bender.Roles.GetData> GetAll()
        {
            return objGetData;
        }
    }
}
