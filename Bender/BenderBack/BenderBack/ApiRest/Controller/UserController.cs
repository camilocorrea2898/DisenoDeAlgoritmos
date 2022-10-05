using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Model.Bender.BenderContext _context = new();
        private Dto.Response objReturn = new();
        private List<Dto.Bender.User.GetData> objGetData = new();
        private Dto.Bender.User.LoginResponse loginResponse = new();

        // GET  User/GetAll
        [HttpGet("GetAll")]
        public List<Dto.Bender.User.GetData> GetAll()
        {
            return objGetData;
        }

        // POST  User/Insert
        [HttpPost("Insert")]
        public Dto.Response Insert(Dto.Bender.User.Insert objInsert)
        {
            return objReturn;
        }

        // PUT  User/Edit/123456789
        [HttpPut("Edit/{Identification}")]
        public Dto.Response Edit(long Identification, Dto.Bender.User.Edit objEdit)
        {
            return objReturn;
        }

        // DELETE  User/Delete/123456789
        [HttpDelete("Delete/{Identification}")]
        public Dto.Response Delete(long Identification)
        {
            return objReturn;
        }

        // POST  User/Login
        [HttpPost("Login")]
        public Dto.Bender.User.LoginResponse Login(Dto.Bender.User.LoginRequest objInsert)
        {
            return loginResponse;
        }
    }
}
