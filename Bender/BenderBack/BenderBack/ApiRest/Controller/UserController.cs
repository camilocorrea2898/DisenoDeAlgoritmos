using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml;

namespace ApiRest.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Model.biblioteca.bibliotecaContext _context = new();
        private Dto.Response objReturn = new();
        private List<Dto.Users.GetData> objGetData = new();
        private Dto.Users.LoginResponse loginResponse = new(){Success = false};

        //GET  User/GetAll
        [HttpGet("GetAll")]
        public List<Dto.Users.GetData> GetAll()
        {
            List<Model.biblioteca.Autore> ObjData = _context.Autores
                //.Where(x => x.Id == 1)
                .ToList();
            foreach (var data in ObjData)
            {
                Dto.Users.GetData row = new()
                {
                    Identification = Convert.ToString(data.Id),
                    Name = data.Nombre,
                    Password="",
                    RolId =1
                };
                objGetData.Add(row);
            }
            return objGetData;
        }

        //POST  User/Insert
        [HttpPost("Insert")]
        public Dto.Response Insert(Dto.Users.Insert objInsert)
        {
            Model.biblioteca.Autore objAutores = new()
            {
                Id = Convert.ToInt32(objInsert.Identification),
                Nombre = objInsert.Name
            };
            _context.Autores.Add(objAutores);
            _context.SaveChanges();
            if (objAutores.Id > 0)
            {
                objReturn.Success = true;
            }
            //string Pass = BCrypt.Net.BCrypt.HashPassword(objInsert.Password);
            return objReturn;
        }

        //PUT  User/Edit/123456789
        [HttpPut("Edit/{Identification}")]
        public Dto.Response Edit(long Identification, Dto.Users.Edit objEdit)
        {
            var objAutores = _context.Autores.Find(Identification);
            _context.Entry(objAutores).State = EntityState.Modified;
            _context.SaveChanges();
            if (objAutores.Id > 0)
            {
                objReturn.Success = true;
            }
            return objReturn;
        }

        //DELETE  User/Delete/123456789
        [HttpDelete("Delete/{Identification}")]
        public Dto.Response Delete(long Identification)
        {
            var objAutores = _context.Autores.Find(Identification);
            _context.Remove(objAutores);
            _context.SaveChanges();
            objReturn.Success = true;
            return objReturn;
        }

        //POST  User/Login
        [HttpPost("Login")]
        public Dto.Users.LoginResponse Login(Dto.Users.LoginRequest objInsert)
        {
            if (BCrypt.Net.BCrypt.Verify(objInsert.Password,"Encyprt"))
            {
                loginResponse.Success = true;
            }
            return loginResponse;
        }
    }
}
