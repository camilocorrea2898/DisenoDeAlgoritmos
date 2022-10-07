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
            try
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
                        Password = "",
                        RolId = 1
                    };
                    objGetData.Add(row);
                }
            }
            catch(Exception ex){}
            return objGetData;
        }

        //POST  User/Insert
        [HttpPost("Insert")]
        public Dto.Response Insert(Dto.Users.Insert objInsert)
        {
            try
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
                    objReturn.SelectedResponse(true);
                }
                //string Pass = BCrypt.Net.BCrypt.HashPassword(objInsert.Password);
            }
            catch (Exception ex) {
                objReturn.SelectedResponse(false, ex.Message);
            }
            return objReturn;
        }

        //PUT  User/Edit/123456789
        [HttpPut("Edit/{Identification}")]
        public Dto.Response Edit(long Identification, Dto.Users.Edit objEdit)
        {
            try
            {
                var objAutores = _context.Autores.Find(Identification);
                _context.Entry(objAutores).State = EntityState.Modified;
                _context.SaveChanges();
                if (objAutores.Id > 0)
                {
                    objReturn.SelectedResponse(true);
                }
            }
            catch (Exception ex)
            {
                objReturn.SelectedResponse(false, ex.Message);
            }
            return objReturn;
        }

        //DELETE  User/Delete/123456789
        [HttpDelete("Delete/{Identification}")]
        public Dto.Response Delete(long Identification)
        {
            try
            {
                var objAutores = _context.Autores.Find(Identification);
                _context.Remove(objAutores);
                _context.SaveChanges();
                objReturn.SelectedResponse(true);
            }
            catch (Exception ex)
            {
                objReturn.SelectedResponse(false, ex.Message);
            }
            return objReturn;
        }

        //POST  User/Login
        [HttpPost("Login")]
        public Dto.Users.LoginResponse Login(Dto.Users.LoginRequest objInsert)
        {
            try
            {
                if (BCrypt.Net.BCrypt.Verify(objInsert.Password, "Encyprt"))
                {
                    loginResponse.Success = true;
                }
            }
            catch (Exception ex){}
            return loginResponse;
        }
    }
}
