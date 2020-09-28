using Helios.Cont.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
namespace Helios.Cont.Web.Models
{
    public class ItemViewModel
    {
        public List<item> Categories;

        public List<detalleitems> GetDetalleitems;

        public entidad EntidadVarios;

        public int TransferTransitCount { get; set; }      
    }
}