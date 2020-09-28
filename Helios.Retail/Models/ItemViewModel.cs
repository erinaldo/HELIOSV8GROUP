﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BE = Helios.Cont.Business.Entity;

namespace Helios.Retail.Models
{
    public class ItemViewModel 
    {
        public List<BE.item> items;

        [Display(Name = "Choose Mesa")]
        public int idDistribucion { get; set; }

        public List<BE.distribucionInfraestructura> ListaDistribucionInfraestructuras;

        public BE.distribucionInfraestructura distribucionInfraestructuras;

        public List<BE.item> Categories;

        public List<Seguridad.Business.Entity.Usuario> UsuariosSistema;
    }
}