using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly Model.biblioteca.bibliotecaContext _context = new();
        private List<Dto.Roles.GetData> objGetData = new();

        //GET  Roles/GetAll
        [HttpGet("GetAll")]
        public List<Dto.Roles.GetData> GetAll()
        {
            try
            {
                List<Model.biblioteca.Autore> ObjData = _context.Autores
                //.Where(x => x.Id == 1)
                .ToList();
                foreach (var data in ObjData)
                {
                    Dto.Roles.GetData row = new()
                    {
                        RolId = Convert.ToInt64(data.Id),
                        RolName = data.Nombre
                    };
                    objGetData.Add(row);
                }
            }
            catch (Exception ex) { }
            return objGetData;
        }
    }
}
