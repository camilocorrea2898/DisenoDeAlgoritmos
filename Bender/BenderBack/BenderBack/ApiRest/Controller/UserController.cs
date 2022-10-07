using ApiRest.Dto.Users;
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
        private readonly Model.Bender.BenderContext _context = new();
        private List<Dto.Users.GetData> objGetData = new();
        private Dto.Users.LoginResponse loginResponse = new(){Success = false};

        //GET  User/GetAll
        [HttpGet("GetAll")]
        public List<Dto.Users.GetData> GetAll()
        {
            try
            {
                List<Model.Bender.User> ObjData = _context.Users.ToList();
                foreach (var data in ObjData)
                {
                    Dto.Users.GetData row = new()
                    {
                        Identification = Convert.ToString(data.Iduser),
                        Name = data.Names,
                        Password = data.Password,
                        RolId = data.RolIdrol
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
            var objReturn = new Dto.Response();
            try
            {
                Model.Bender.User objUsers = new()
                {
                    Iduser = Convert.ToInt32(objInsert.Identification),
                    Names = objInsert.Name,
                    RolIdrol=objInsert.RolId,
                    Password = BCrypt.Net.BCrypt.HashPassword(objInsert.Password),
                    BranchIdbranch= objInsert.Idbranch
                };
                _context.Users.Add(objUsers);
                _context.SaveChanges();
                if (objUsers.Iduser > 0)
                {
                    objReturn=objReturn.SelectedResponse(true);
                }
            }
            catch (Exception ex) {
                objReturn=objReturn.SelectedResponse(false, ex.Message);
            }
            return objReturn;
        }

        //PUT  User/Edit/123456789
        [HttpPut("Edit/{Identification}")]
        public Dto.Response Edit(long Identification, Dto.Users.Edit objEdit)
        {
            var objReturn = new Dto.Response();
            try
            {
                var objUsers = _context.Users.Where(x=> x.Iduser==Identification).FirstOrDefault();
                objUsers.Password = String.IsNullOrEmpty(objEdit.Password) ? objUsers.Password : BCrypt.Net.BCrypt.HashPassword(objEdit.Password);
                _context.Entry(objUsers).State = EntityState.Modified;
                _context.SaveChanges();
                if (objUsers.Iduser > 0)
                {
                    objReturn=objReturn.SelectedResponse(true);
                }
            }
            catch (Exception ex)
            {
                objReturn=objReturn.SelectedResponse(false, ex.Message);
            }
            return objReturn;
        }

        //DELETE  User/Delete/123456789
        [HttpDelete("Delete/{Identification}")]
        public Dto.Response Delete(long Identification)
        {
            var objReturn = new Dto.Response();
            try
            {
                var objUsers = _context.Users.Where(x => x.Iduser == Identification).FirstOrDefault();
                _context.Remove(objUsers);
                _context.SaveChanges();
                objReturn=objReturn.SelectedResponse(true);
            }
            catch (Exception ex)
            {
                objReturn=objReturn.SelectedResponse(false, ex.Message);
            }
            return objReturn;
        }

        //POST  User/Login
        [HttpPost("Login")]
        public Dto.Users.LoginResponse Login(Dto.Users.LoginRequest objInsert)
        {
            try
            {
                var objUsers = _context.Users.Where(x => x.Iduser == Convert.ToInt32(objInsert.User)).FirstOrDefault();
                if (BCrypt.Net.BCrypt.Verify(objInsert.Password, objUsers.Password))
                {
                    loginResponse.Name = objUsers.Names;
                    loginResponse.RolId = objUsers.RolIdrol;
                    loginResponse.Success = true;
                }
            }
            catch (Exception ex){}
            return loginResponse;
        }
    }
}
