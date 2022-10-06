using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        //private readonly Model.Bender.BenderContext _context = new();
        private List<Dto.Roles.GetData> objGetData = new();

        //GET  Roles/GetAll
        [HttpGet("GetAll")]
        public List<Dto.Roles.GetData> GetAll()
        {
            return objGetData;
        }
    }
}
