using ApiRest.Dto.Purchase;
using ApiRest.Model.Bender;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly BenderContext _context = new();
        List<GetData> objGetData = new();
        GetData objGetDataObject = new();

        //GET Purchases/GetAll
        [HttpGet("GetAll")]
        public List<GetData> GetAll()
        {
            try
            {
                List<Purchase> ObjData = _context.Purchases.ToList();
                foreach (var data in ObjData)
                {

                    GetData row = new()
                    {
                        IdPurchase = data.IdPurchase,
                        Date = data.Date.ToString(),
                        Nitsupplier = data.Nitsupplier,
                        ProductIdproduct = data.ProductIdproduct,
                        Quantity = data.Quantity,
                        Supplier = data.Supplier 
                    };
                    objGetData.Add(row);
                }
            }
            catch (Exception ex) { }
            return objGetData;
        }

        //GET Purchases/GetById/123456798
        [HttpGet("GetById/{IdPurchase}")]
        public GetData GetById(int IdPurchase)
        {
            try
            {
                Purchase ObjData = _context.Purchases.Where(x => x.IdPurchase == IdPurchase).FirstOrDefault();

                objGetDataObject = new()
                {
                    IdPurchase = ObjData.IdPurchase,
                    Date = ObjData.Date.ToString(),
                    Nitsupplier = ObjData.Nitsupplier,
                    ProductIdproduct = ObjData.ProductIdproduct,
                    Quantity = ObjData.Quantity,
                    Supplier = ObjData.Supplier
                };
            }
            catch (Exception ex) { }
            return objGetDataObject;
        }

        //POST  Purchases/Insert
        [HttpPost("Insert")]
        public Dto.Response Insert(Insert objInsert)
        {
            var objReturn = new Dto.Response();
            try
            {
                Purchase objPurchase = new()
                {
                    Date = DateOnly.Parse(objInsert.Date),
                    Nitsupplier = objInsert.Nitsupplier,
                    ProductIdproduct = objInsert.ProductIdproduct,
                    Quantity = objInsert.Quantity,
                    Supplier = objInsert.Supplier
                };
                _context.Purchases.Add(objPurchase);
                _context.SaveChanges();
                if (objPurchase.IdPurchase > 0)
                {
                    objReturn = objReturn.SelectedResponse(true);
                }
            }
            catch (Exception ex)
            {
                objReturn = objReturn.SelectedResponse(false, ex.Message);
            }
            return objReturn;
        }

        //PUT  Purchases/Edit/123456789
        [HttpPut("Edit/{IdPurchase}")]
        public Dto.Response Edit(int IdPurchase, Edit objEdit)
        {
            var objReturn = new Dto.Response();
            try
            {
                var objPurchase = _context.Purchases.Where(x => x.IdPurchase == IdPurchase).FirstOrDefault();
                objPurchase.Date = objEdit.Date == null ? objPurchase.Date : DateOnly.Parse(objEdit.Date);
                objPurchase.Supplier = String.IsNullOrEmpty(objEdit.Supplier) ? objPurchase.Supplier : objEdit.Supplier;
                objPurchase.Nitsupplier = String.IsNullOrEmpty(objEdit.Nitsupplier) ? objPurchase.Nitsupplier : objEdit.Nitsupplier;
                objPurchase.Quantity = String.IsNullOrEmpty(objEdit.Quantity) ? objPurchase.Quantity : objEdit.Quantity;
                objPurchase.ProductIdproduct = objEdit.ProductIdproduct == 0 ? objPurchase.ProductIdproduct : objEdit.ProductIdproduct;
                _context.Entry(objPurchase).State = EntityState.Modified;
                _context.SaveChanges();
                if (objPurchase.IdPurchase > 0)
                {
                    objReturn = objReturn.SelectedResponse(true);
                }
            }
            catch (Exception ex)
            {
                objReturn = objReturn.SelectedResponse(false, ex.Message);
            }
            return objReturn;
        }

        //DELETE  Purchases/Delete/123456789
        [HttpDelete("Delete/{IdPurchase}")]
        public Dto.Response Delete(int IdPurchase)
        {
            var objReturn = new Dto.Response();
            try
            {
                var objPurchase = _context.Purchases.Where(x => x.IdPurchase == IdPurchase).FirstOrDefault();
                _context.Remove(objPurchase);
                _context.SaveChanges();
                objReturn = objReturn.SelectedResponse(true);
            }
            catch (Exception ex)
            {
                objReturn = objReturn.SelectedResponse(false, ex.Message);
            }
            return objReturn;
        }
    }
}
