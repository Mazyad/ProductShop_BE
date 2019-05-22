using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Data;
using testshop.Data;
using System.Threading.Tasks;
using testshop.Data.Entity;
using System.Web.Http.Cors;

namespace testshop.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class productController : ApiController
    {
        public IproductRepository _repository;
        public object _mapper;

        public productController()
        {
            _repository = new productRepository();
        }
        public async Task<IHttpActionResult> GET()
        {
            var result = await _repository.GetAllproductAsync();

            return Ok(result);
        }

        
        public async Task<IHttpActionResult> POST(product product)
        {
            _repository.Addproduct(product);

            await _repository.SaveChangesAsync();

            return Ok();
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var product = await _repository.GetProductAsync(id);

                _repository.Deleteproduct(product);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch
            {

                return InternalServerError();
            }
        }
        public async Task<IHttpActionResult> PUT(int id, product productt)
        {
            try
            {
                var productid = await _repository.GetProductAsync(id);
                if (productid == null) return NotFound();

                _repository.map(productid, productt);


                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        //public void
    }
}

