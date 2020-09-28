using Helios.Cont.Business.Entity;
using Helios.Cont.Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Helios.Web.API.Controllers
{
    public class ProductController : ApiController
    {
        detalleitemsBL ProductBL = new detalleitemsBL();

        [ResponseType(typeof(detalleitems))]
        public IEnumerable<detalleitems> GetAllProducts()
        {         
            return ProductBL.GetExistenciasByempresa();
        }

        [ResponseType( typeof(detalleitems))]
        public IHttpActionResult GetProduct(int id)
        {            
            var product = ProductBL.GetUbicaProductoID(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
