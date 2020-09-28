using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BE = Helios.Cont.Business.Entity;
using BESG = Helios.Seguridad.Business.Entity;
namespace Helios.Cont.Web.Models
{
    public static class Product
    {
        public static List<BE.detalleitems> GetDetalleitems;

        public static List<BESG.Usuario> GetUsuariosSistemas;

        //public static List<Category> GetCategories()
        //{
        //    List<Category> Lista = new List<Category>();
        //    Lista.Add(new Category() { CategoryID = 1, CategortyName = "Leches" });
        //    Lista.Add(new Category() { CategoryID = 2, CategortyName = "Aceites" });
        //    Lista.Add(new Category() { CategoryID = 3, CategortyName = "Pinturas" });

        //    return Lista;
        //}

        //public static List<Item> GetProducts()
        //{
        //    List<Item> Lista = new List<Item>();
        //    Lista.Add(new Item() { CategoryId = 1, ProductID = 1, ProductName = "Leche Gloria", ProductUnit = "NIU" });
        //    Lista.Add(new Item() { CategoryId = 1, ProductID = 2, ProductName = "Leche Idel", ProductUnit = "NIU" });
        //    Lista.Add(new Item() { CategoryId = 1, ProductID = 3, ProductName = "Leche Anchor", ProductUnit = "NIU" });

        //    Lista.Add(new Item() { CategoryId = 2, ProductID = 4, ProductName = "Aceite Cil", ProductUnit = "NIU" });
        //    Lista.Add(new Item() { CategoryId = 2, ProductID = 5, ProductName = "Aceite Cocinero", ProductUnit = "NIU" });
        //    Lista.Add(new Item() { CategoryId = 2, ProductID = 6, ProductName = "Aceite Capri", ProductUnit = "NIU" });

        //    Lista.Add(new Item() { CategoryId = 3, ProductID = 7, ProductName = "Vencedor", ProductUnit = "NIU" });
        //    Lista.Add(new Item() { CategoryId = 3, ProductID = 8, ProductName = "Latex", ProductUnit = "NIU" });
        //    Lista.Add(new Item() { CategoryId = 3, ProductID = 9, ProductName = "Pintutax", ProductUnit = "NIU" });

        //    return Lista;
        //}

        private static List<BE.detalleitemequivalencia_precios> ConvertirPreciosArangos(List<BE.detalleitemequivalencia_precios> lista)
        {
            // Dim ListaEntera = GetConverToListInteger(lista)
            List<BE.detalleitemequivalencia_precios> listado = new List<BE.detalleitemequivalencia_precios>();
            //   ConvertirPreciosArangos = new List<BE.detalleitemequivalencia_precios>();

            decimal maxValor = lista.Max(o => o.rango_inicio).GetValueOrDefault();
            decimal max = 0;
            for (var index = 0; index <= lista.Count - 1; index++)
            {
                decimal rangoMinimo = lista[index].rango_inicio.GetValueOrDefault();
                if (rangoMinimo == maxValor)
                    max = 0;
                else
                    max = lista[index + 1].rango_inicio.GetValueOrDefault() - 1;
                listado.Add(AddItemNuevaListaPrecios(lista[index], rangoMinimo, max));
            }
            return listado;
        }

        private static BE.detalleitemequivalencia_precios AddItemNuevaListaPrecios(BE.detalleitemequivalencia_precios be, decimal? rangoMinimo, decimal max)
        {

            BE.detalleitemequivalencia_precios Precio = new BE.detalleitemequivalencia_precios();
            //Precio = new detalleitemequivalencia_precios();
            Precio = be;
            Precio.rango_inicio = rangoMinimo;
            Precio.rango_final = max;
            return Precio;
        }


        public static decimal GetCalculoPrecioVenta(decimal cantidadVenta, int idProducto, int idEquivalencia, int idCatalogo)
        {
            decimal GetCalculoPrecioVenta_return = 0;
            var objProducto = GetDetalleitems.Where(o => o.codigodetalle == idProducto).SingleOrDefault();

            if (objProducto != null)
            {
                var listaEquivalencias = objProducto.detalleitem_equivalencias.ToList();

                var objEQ = listaEquivalencias.Where(e => e.equivalencia_id == idEquivalencia).SingleOrDefault();

                var catalogoOBJ = objEQ.detalleitemequivalencia_catalogos.Where(c => c.idCatalogo == idCatalogo).SingleOrDefault();

                if (catalogoOBJ != null)
                {
                    var ListaPrecios = catalogoOBJ.detalleitemequivalencia_precios.ToList();
                    var listaDeRangos = ConvertirPreciosArangos(ListaPrecios);

                    if (listaDeRangos.Count == 0 | listaDeRangos == null)
                        throw new Exception("El producto no tiene precios de venta asignados");

                    foreach (var i in listaDeRangos)
                    {
                        var rango_inicio = i.rango_inicio;
                        var rango_fin = i.rango_final;
                        if (cantidadVenta >= rango_inicio && rango_fin == 0)
                        {
                            // Select Case UCEstructuraCabeceraVenta.ComboTerminosPago.Text
                            // Case "CONTADO"
                            // GetCalculoPrecioVenta = i.precio.GetValueOrDefault
                            // Case "CREDITO"
                            // GetCalculoPrecioVenta = i.precioCredito.GetValueOrDefault
                            // End Select

                            //if (UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text == "PRE VENTA")
                            //    GetCalculoPrecioVenta = i.precio.GetValueOrDefault;
                            //else
                            //    switch (UCEstructuraCabeceraVenta.ComboTerminosPago.Text)
                            //    {
                            //        case "CONTADO":
                            //            {
                            GetCalculoPrecioVenta_return = i.precio.GetValueOrDefault();
                            //     break;
                            //   }

                            //        case "CREDITO":
                            //            {
                            //                GetCalculoPrecioVenta_return = i.precioCredito.GetValueOrDefault();
                            //                break;
                            //            }
                            //    }

                            //return;
                        }
                        if (cantidadVenta >= rango_inicio && cantidadVenta <= rango_fin)
                        {
                            //if (UCEstructuraCabeceraVenta.FormPurchase.ComboComprobante.Text == "PRE VENTA")
                            //    GetCalculoPrecioVenta = i.precio.GetValueOrDefault;
                            //else
                            //    switch (UCEstructuraCabeceraVenta.ComboTerminosPago.Text)
                            //    {
                            //        case "CONTADO":
                            //            {
                            GetCalculoPrecioVenta_return = i.precio.GetValueOrDefault();
                            //                break;
                            //            }

                            //        case "CREDITO":
                            //            {
                            //                GetCalculoPrecioVenta_return = i.precioCredito.GetValueOrDefault();
                            //                break;
                            //            }
                            //    }
                            //return;
                        }
                    }
                }
                else
                    throw new Exception("Debe configurar los catálogos de precios!");
            }
            return GetCalculoPrecioVenta_return;
        }

    }
}