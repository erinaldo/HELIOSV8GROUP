using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA = Helios.Cont.WCFService.ServiceAccess;
using BE = Helios.Cont.Business.Entity;
using Helios.Cont.Web.Models;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using SoftPackERP_Sunat;
using static Helios.General.Constantes;
using Microsoft.VisualBasic.Devices;
using System.Data;
using FastReport.Web;
using Helios.Cont.Web.Helpers;
using HtmlAgilityPack;
//using FastReport.Web;
//using FastReport;

namespace Helios.Cont.Web.Controllers
{
    public class OrderController : Controller
    {

        #region Print

        //public void ImprimirTicket(string imprimir, int intIdDocumento, string formato,BE.datosGenerales objDatosGenrales, BE.documento documentoBE  )
        //{
        //    switch (formato)
        //    {
        //        case "1":
        //            {
        //                Helios.General.TickeNuevoFormato a = new Helios.General.TickeNuevoFormato();
        //                // a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        //                decimal gravMN = 0;
        //                decimal gravME = 0;
        //                decimal ExoMN = 0;
        //                decimal ExoME = 0;
        //                decimal InaMN = 0;
        //                decimal InaME = 0;
        //                decimal precioUnit = 0;
        //                decimal PrecioTotal = 0;
                       
        //                // Dim documentoSA As New documentoVentaAbarrotesSA
        //                // Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        //                // Dim documentoBE.documentoventaAbarrotes = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        //                // Dim documentoBE.documentoventaAbarrotesDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        //                string nombreCliente;
        //                string rucCliente = string.Empty;

        //                if (My.Computer.Network.IsAvailable == true)
        //                {
        //                    // If My.Computer.Network.Ping("148.102.27.231") Then
        //                    if ((documentoBE.documentoventaAbarrotes.tipoDocumento == "01" & documentoBE.documentoventaAbarrotes.tipoVenta == "VELC") | (documentoBE.documentoventaAbarrotes.tipoDocumento == "07" & documentoBE.documentoventaAbarrotes.tipoVenta == "NTCE"))
        //                        XmlFactura(documentoBE.documentoventaAbarrotes, documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList);
        //                }

        //                if ((objDatosGenrales.logo.Length > 0))
        //                    // Logo de la Empresa
        //                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo);

        //                if ((objDatosGenrales.nombreImpresion == "C"))
        //                    a.tipoImagen = false;
        //                else if ((objDatosGenrales.nombreImpresion == "R"))
        //                    a.tipoImagen = true;

        //                // Direccion de La empresa general
        //                if ((objDatosGenrales.tipoImpresion == "S"))
        //                {
        //                    a.tipoEncabezado = true;
        //                    a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto);
        //                    a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial);
        //                }
        //                else if ((objDatosGenrales.tipoImpresion == "N"))
        //                {
        //                    a.tipoEncabezado = false;
        //                    a.AnadirLineaEmpresa(objDatosGenrales.razonSocial);
        //                }

        //                if ((objDatosGenrales.publicidad.Length > 0))
        //                {
        //                    a.tipoPublicidad = true;
        //                    a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad);
        //                }
        //                else
        //                    a.tipoPublicidad = false;

        //                // Dim nombreCliente As String
        //                // Dim rucCliente As String
        //                // Dim nombreCliente As String
        //                // Dim rucCliente As String

        //                // ruc
        //                a.TextoIzquierda("R.U.C.: " + objDatosGenrales.idEmpresa);
        //                // direccion de la empresa
        //                a.TextoIzquierda("Direccion Principal: " + objDatosGenrales.direccionPrincipal);
        //                // a.TextoIzquierda("Direccion Secundaria: " & objDatosGenrales.direccionSecudaria)
        //                // Telefono de la empresa
        //                if ((objDatosGenrales.telefono3.Length > 0))
        //                    a.TextoIzquierda("TELF: " + objDatosGenrales.telefono1 + " - " + objDatosGenrales.telefono2 + " - " + objDatosGenrales.telefono3);
        //                else if ((objDatosGenrales.telefono2.Length > 0))
        //                    a.TextoIzquierda("TELF: " + objDatosGenrales.telefono1 + " - " + objDatosGenrales.telefono2);
        //                else
        //                    a.TextoIzquierda("TELF: " + objDatosGenrales.telefono1);

        //                string nombreComprador = string.Empty;
        //                // If documentoBE.documentoventaAbarrotes.idCliente <> 0 Then

        //                string NBoletaElectronica = null;
        //                var entidad = documentoBE.documentoventaAbarrotes.CustomEntidad; // documentoBE.documentoventaAbarrotes.CustomEntidad ' entidadSA.UbicarEntidadPorID(documentoBE.documentoventaAbarrotes.idCliente).FirstOrDefault
        //                if (entidad.tipoEntidad == "VR")
        //                {
        //                    NBoletaElectronica = entidad.nombreCompleto;
        //                    nombreComprador = documentoBE.documentoventaAbarrotes.nombrePedido;
        //                }
        //                else
        //                {
        //                    NBoletaElectronica = entidad.nombreCompleto;
        //                    nombreComprador = "-";
        //                }

        //                nombreCliente = (NBoletaElectronica);
        //                if (entidad.nrodoc.Trim().Length == 11)
        //                    rucCliente = ("RUC.: " + entidad.nrodoc);
        //                else if (entidad.nrodoc.Trim().Length == 8)
        //                    rucCliente = ("DNI.: " + entidad.nrodoc);
        //                else
        //                    rucCliente = ("NRO DOC.: " + entidad.nrodoc);

        //                // Codigo qr

        //                if ((!IsNothing(HASH)))
        //                {
        //                    if (HASH.Trim.Length > 0)
        //                    {
        //                        QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + entidad.tipoDoc + "|" + entidad.nrodoc + "|" + HASH + "|" + CERTIFICADO);

        //                        QrCodeImgControl1.Text = QR;
        //                    }
        //                    else
        //                    {
        //                        QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date + "|" + entidad.tipoDoc + "|" + entidad.nrodoc);

        //                        QrCodeImgControl1.Text = QR;
        //                    }
        //                }

        //                QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + entidad.tipoDoc + "|" + entidad.nrodoc);

        //                QrCodeImgControl1.Text = QR;

        //                // QrCodeImgControl1.Image

        //                // Else
        //                // Dim NBoletaElectronica As String = documentoBE.documentoventaAbarrotes.nombrePedido
        //                // nombreCliente = (NBoletaElectronica)

        //                // 'Codigo qr
        //                // QR = (Gempresas.IdEmpresaRuc & "|" & documentoBE.documentoventaAbarrotes.tipoDocumento.ToString & "|" & documentoBE.documentoventaAbarrotes.serieVenta & "|" & documentoBE.documentoventaAbarrotes.numeroVenta & "|" & Format(documentoBE.documentoventaAbarrotes.igv01, 2) &
        //                // "|" & documentoBE.documentoventaAbarrotes.ImporteNacional & "|" & CDate(documentoBE.documentoventaAbarrotes.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

        //                // QrCodeImgControl1.Text = QR

        //                // End If

        //                switch (documentoBE.documentoventaAbarrotes.tipoDocumento)
        //                {
        //                    case "12.1":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = "1";
        //                            break;
        //                        }

        //                    case "12.2":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = "1";
        //                            break;
        //                        }

        //                    case "03":
        //                        {
        //                            if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VELC"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA ELECTRONICA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, nombreComprador, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = "2";
        //                            }
        //                            else if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VPOS"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " + System.Convert.ToString(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, '0') + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, nombreComprador, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = "1";
        //                            }

        //                            break;
        //                        }

        //                    case "01":
        //                        {
        //                            if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VELC"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, nombreComprador, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = "2";
        //                            }
        //                            else if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VPOS"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " + System.Convert.ToString(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, '0') + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, nombreComprador, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = "1";
        //                            }

        //                            break;
        //                        }

        //                    case "9903" // "9901"
        //             :
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "PROFORMA   N° " + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = "1";
        //                            break;
        //                        }

        //                    case "07":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "NOTA DE CREDITO ELECTRONICA N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = "2";
        //                            break;
        //                        }

        //                    default:
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, documentoBE.documentoventaAbarrotes.nombrePedido, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = "1";
        //                            break;
        //                        }
        //                }

        //                foreach (var i in documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet)
        //                {
        //                    OperacionGravada question = OperacionGravada.Grabado;
        //                    int value = (int)question;

        //                    switch (i.destino)
        //                    {
        //                        case (int)OperacionGravada.Grabado:
        //                            {
        //                                gravMN += System.Convert.ToDecimal(i.montokardex);
        //                                gravME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }

        //                        case OperacionGravada.Exonerado:
        //                            {
        //                                ExoMN += System.Convert.ToDecimal(i.montokardex);
        //                                ExoME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }

        //                        case  OperacionGravada.Inafecto:
        //                            {
        //                                InaMN += System.Convert.ToDecimal(i.montokardex);
        //                                InaME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }
        //                    }

        //                    precioUnit = (Math.Round(System.Convert.ToDouble(i.importeMN / (double)i.monto1), 2));
        //                    PrecioTotal = i.importeMN;

        //                    a.AnadirLineaElementosFactura(i.monto1, $"{i.nombreItem}({i.CustomEquivalencia.unidadComercial})", "", string.Format("{0:0.00}", precioUnit), string.Format("{0:0.00}", PrecioTotal));
        //                }


        //                a.AnadirDatosGenerales("S/", ExoMN);
        //                a.AnadirDatosGenerales("S/", InaMN);
        //                a.AnadirDatosGenerales("S/", gravMN);
        //                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01);
        //                a.AnadirDatosGenerales("S/", string.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional));

        //                a.headerImagenQR = QrCodeImgControl1.Image;

        //                var consultaNombre = (from b in UsuariosList
        //                                      where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                      select b).FirstOrDefault;

        //                a.AnadirLineaDatos("Vendedor: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno, "Representacion impresa del documentoBE.documentoventaAbarrotes", "http://facturador.softpack.com.pe/hlogin");

        //                // //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        //                // //parametro de tipo string que debe de ser el nombre de la impresora. 
        //                a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue);
        //                break;
        //            }

        //        case "2":
        //            {
        //                documentoVentaAbarrotesSA documentoSA = new documentoVentaAbarrotesSA();
        //                documentoVentaAbarrotesDetSA documentoDetSA = new documentoVentaAbarrotesDetSA();
        //                TicketForGrandeNota a = new TicketForGrandeNota();
        //                // a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        //                decimal gravMN = 0;
        //                decimal gravME = 0;
        //                decimal ExoMN = 0;
        //                decimal ExoME = 0;
        //                decimal InaMN = 0;
        //                decimal InaME = 0;
        //                decimal precioUnit = 0;
        //                decimal PrecioTotal = 0;

        //                string nombreCliente;
        //                string rucCliente = string.Empty;

        //                var comprobante = documentoSA.GetUbicar_NotaXID(intIdDocumento);
        //                var comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento);
        //                if (My.Computer.Network.IsAvailable == true)
        //                {
        //                    // If My.Computer.Network.Ping("148.102.27.231") Then
        //                    if ((documentoBE.documentoventaAbarrotes.tipoDocumento == "01" & documentoBE.documentoventaAbarrotes.tipoVenta == "VELC") | (documentoBE.documentoventaAbarrotes.tipoDocumento == "07" & documentoBE.documentoventaAbarrotes.tipoVenta == "NTCE"))
        //                        XmlFactura(documentoBE.documentoventaAbarrotes, documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList);
        //                }

        //                if ((objDatosGenrales.logo.Length > 0))
        //                    // Logo de la Empresa
        //                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo);

        //                if ((objDatosGenrales.nombreImpresion == "C"))
        //                    a.tipoImagen = false;
        //                else if ((objDatosGenrales.nombreImpresion == "R"))
        //                    a.tipoImagen = true;

        //                // Direccion de La empresa general
        //                if ((objDatosGenrales.tipoImpresion == "S"))
        //                {
        //                    a.tipoEncabezado = true;
        //                    a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto);
        //                    a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial);
        //                }
        //                else if ((objDatosGenrales.tipoImpresion == "N"))
        //                {
        //                    a.tipoEncabezado = false;
        //                    a.AnadirLineaEmpresa(objDatosGenrales.razonSocial);
        //                }

        //                if ((objDatosGenrales.publicidad.Length > 0))
        //                {
        //                    a.tipoPublicidad = true;
        //                    a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad);
        //                }
        //                else
        //                    a.tipoPublicidad = false;

        //                // Dim nombreCliente As String
        //                // Dim rucCliente As String
        //                // Dim nombreCliente As String
        //                // Dim rucCliente As String

        //                // ruc
        //                a.TextoIzquierda("R.U.C.: " + objDatosGenrales.idEmpresa);
        //                // direccion de la empresa
        //                a.TextoIzquierda("Direccion: " + objDatosGenrales.direccionPrincipal);
        //                // a.TextoIzquierda("Direccion Secundaria: " & objDatosGenrales.direccionSecudaria)
        //                // Telefono de la empresa
        //                if ((objDatosGenrales.telefono3.Length > 0))
        //                    a.TextoIzquierda("Telf: " + objDatosGenrales.telefono1 + " - " + objDatosGenrales.telefono2 + " - " + objDatosGenrales.telefono3);
        //                else if ((objDatosGenrales.telefono2.Length > 0))
        //                    a.TextoIzquierda("Telf: " + objDatosGenrales.telefono1 + " - " + objDatosGenrales.telefono2);
        //                else
        //                    a.TextoIzquierda("Telf: " + objDatosGenrales.telefono1);

        //                string DIRECCIONclIENTE = string.Empty;
        //                if (documentoBE.documentoventaAbarrotes.idCliente != 0)
        //                {
        //                    var entidad = documentoBE.documentoventaAbarrotes.CustomEntidad;  // entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
        //                    string NBoletaElectronica = entidad.nombreCompleto;
        //                    DIRECCIONclIENTE = entidad.DireccionSeleccionada;
        //                    nombreCliente = (NBoletaElectronica);
        //                    if (entidad.nrodoc.Trim.Length == 11)
        //                        rucCliente = ("RUC.: " + entidad.nrodoc);
        //                    else if (entidad.nrodoc.Trim.Length == 8)
        //                        rucCliente = ("DNI.: " + entidad.nrodoc);
        //                    else
        //                        rucCliente = ("NRO DOC.: " + entidad.nrodoc);

        //                    // Codigo qr

        //                    if ((!IsNothing(HASH)))
        //                    {
        //                        if (HASH.Trim.Length > 0)
        //                        {
        //                            QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + entidad.tipoDoc + "|" + entidad.nrodoc + "|" + HASH + "|" + CERTIFICADO);

        //                            QrCodeImgControl1.Text = QR;
        //                        }
        //                        else
        //                        {
        //                            QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date + "|" + entidad.tipoDoc + "|" + entidad.nrodoc);

        //                            QrCodeImgControl1.Text = QR;
        //                        }
        //                    }

        //                    QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + entidad.tipoDoc + "|" + entidad.nrodoc);

        //                    QrCodeImgControl1.Text = QR;
        //                }
        //                else
        //                {
        //                    string NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido;
        //                    nombreCliente = (NBoletaElectronica);

        //                    // Codigo qr
        //                    QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + "VARIOS" + "|" + "0");

        //                    QrCodeImgControl1.Text = QR;
        //                }

        //                switch (documentoBE.documentoventaAbarrotes.tipoDocumento)
        //                {
        //                    case "12.1":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = 1;
        //                            a.AnadirLineaComprobante("TICKET BOLETA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            break;
        //                        }

        //                    case "12.2":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = 1;
        //                            a.AnadirLineaComprobante("TICKET FACTURA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            break;
        //                        }

        //                    case "03":
        //                        {
        //                            if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VELC"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA DE VENTA ELECTRONICA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 2;
        //                                a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + System.Convert.ToString(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, '0'));

        //                                var consultaNombre = (from b in UsuariosList
        //                                                      where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                                      select b).FirstOrDefault;

        //                                if (!IsNothing(consultaNombre))
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno);
        //                                else
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + "VARIOS");

        //                                a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE");
        //                                a.AnadirLineasDatosFinales("VENTA ELECTRONICA");
        //                                a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login");
        //                                a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia");
        //                                a.AnadirLineasDatosFinales("034-005-0010982");

        //                                a.AnadirLineasDatosFinales("");

        //                                // a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
        //                                // a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
        //                                // a.AnadirLineasDatosFinales("maych_1@hotmail.com")
        //                                // a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
        //                                // a.AnadirLineasDatosFinales("(01)-12345678")
        //                                a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA");
        //                            }
        //                            else if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VPOS"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " + System.Convert.ToString(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, '0') + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 1;
        //                                a.AnadirLineaComprobante("BOLETA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            }

        //                            break;
        //                        }

        //                    case "01":
        //                        {
        //                            if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VELC"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 2;
        //                                a.AnadirLineaComprobante("FACTURA ELECTRONICA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + System.Convert.ToString(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, '0'));

        //                                var consultaNombre = (from b in UsuariosList
        //                                                      where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                                      select b).FirstOrDefault;

        //                                if (!IsNothing(consultaNombre))
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno);
        //                                else
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + "VARIOS");

        //                                a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE");
        //                                a.AnadirLineasDatosFinales("VENTA ELECTRONICA");
        //                                a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login");
        //                                a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia");
        //                                a.AnadirLineasDatosFinales("034-005-0010982");

        //                                a.AnadirLineasDatosFinales("");

        //                                // a.AnadirLineasDatosFinales("CUALQUIER CAMBIO O DEVOLUCION SERA HASTA")
        //                                // a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
        //                                // a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
        //                                // a.AnadirLineasDatosFinales("maych_1@hotmail.com")
        //                                // a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
        //                                // a.AnadirLineasDatosFinales("(01)-12345678")
        //                                a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA");
        //                            }
        //                            else if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VPOS"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " + System.Convert.ToString(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, '0') + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 1;
        //                                a.AnadirLineaComprobante("FACTURA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            }

        //                            break;
        //                        }

        //                    case "9901":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "PROFORMA   N° " + 0, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.AnadirLineaComprobante("PROFORMA");
        //                            a.AnadirLineaComprobante(0 + "-" + 0);
        //                            a.tipoComprobante = 1;
        //                            break;
        //                        }

        //                    case "07":
        //                        {
        //                            string tipoEmision = string.Empty;

        //                            // Select Case comprobante.estadoCobro
        //                            // Case "DC"
        //                            // tipoVenta = "CONTADO"
        //                            // Case "PN"
        //                            // tipoVenta = "CREDITO"
        //                            // End Select

        //                            switch (documentoBE.documentoventaAbarrotes.notaCredito)
        //                            {
        //                                case "01":
        //                                    {
        //                                        tipoEmision = "Anulación de la Operación";
        //                                        break;
        //                                    }

        //                                case "02":
        //                                    {
        //                                        tipoEmision = "Anulación por error en el RUC";
        //                                        break;
        //                                    }

        //                                case "03":
        //                                    {
        //                                        tipoEmision = "Anulación por error en la descripción";
        //                                        break;
        //                                    }

        //                                case "04":
        //                                    {
        //                                        tipoEmision = "Descuento global";
        //                                        break;
        //                                    }

        //                                case "05":
        //                                    {
        //                                        tipoEmision = "Descuento por item";
        //                                        break;
        //                                    }

        //                                case "06":
        //                                    {
        //                                        tipoEmision = "devolución total";
        //                                        break;
        //                                    }

        //                                case "07":
        //                                    {
        //                                        tipoEmision = "devolución por item";
        //                                        break;
        //                                    }

        //                                case "08":
        //                                    {
        //                                        tipoEmision = "Bonificación";
        //                                        break;
        //                                    }

        //                                case "09":
        //                                    {
        //                                        tipoEmision = "disminución en el valor";
        //                                        break;
        //                                    }

        //                                case "10":
        //                                    {
        //                                        tipoEmision = "Otros conceptos";
        //                                        break;
        //                                    }

        //                                case "11":
        //                                    {
        //                                        tipoEmision = "Ajustes de Operaciones de exportación";
        //                                        break;
        //                                    }
        //                            }

        //                            string NombreComprobante = string.Empty;
        //                            switch (documentoBE.documentoventaAbarrotes.TipoDocNota)
        //                            {
        //                                case "01":
        //                                    {
        //                                        NombreComprobante = "FACTURA ELECTRONICA";
        //                                        break;
        //                                    }

        //                                case "02":
        //                                    {
        //                                        NombreComprobante = "BOLETA ELECTRONICA";
        //                                        break;
        //                                    }
        //                            }

        //                            string numeroafect = string.Format("{0:00000000}", comprobante.numeroDoc);

        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(comprobante.fechaDoc.Value), NombreComprobante + comprobante.serie + "-" + numeroafect, nombreCliente, DIRECCIONclIENTE, documentoBE.documentoventaAbarrotes.fechaDoc, rucCliente, "NAC", tipoEmision);
        //                            a.tipoComprobante = 2;
        //                            a.AnadirLineaComprobante("NOTA DE CREDITO ELECTRONICA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + System.Convert.ToString(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, '0'));

        //                            var consultaNombre = (from b in UsuariosList
        //                                                  where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                                  select b).FirstOrDefault;

        //                            if (!IsNothing(consultaNombre))
        //                                a.AnadirLineasDatosFinales("VENDEDOR: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno);
        //                            else
        //                                a.AnadirLineasDatosFinales("VENDEDOR: " + "VARIOS");

        //                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE");
        //                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA");
        //                            a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login");
        //                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia");
        //                            a.AnadirLineasDatosFinales("034-005-0010982");

        //                            a.AnadirLineasDatosFinales("");

        //                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA");
        //                            break;
        //                        }

        //                    default:
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = 1;
        //                            a.AnadirLineaComprobante("NOTA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            break;
        //                        }
        //                }

        //                foreach (var i in comprobanteDetalle)
        //                {
        //                    switch (i.destino)
        //                    {
        //                        case  OperacionGravada.Grabado:
        //                            {
        //                                gravMN += System.Convert.ToDecimal(i.montokardex);
        //                                gravME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }

        //                        case  OperacionGravada.Exonerado:
        //                            {
        //                                ExoMN += System.Convert.ToDecimal(i.montokardex);
        //                                ExoME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }

        //                        case  OperacionGravada.Inafecto:
        //                            {
        //                                InaMN += System.Convert.ToDecimal(i.montokardex);
        //                                InaME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }
        //                    }

        //                    precioUnit = (Math.Round(System.Convert.ToDouble(i.importeMN / (double)i.monto1), 2));
        //                    PrecioTotal = i.importeMN;

        //                    a.AnadirLineaElementosFactura(i.monto1, i.nombreItem, i.unidad1, string.Format("{0:0.00}", precioUnit), string.Format("{0:0.00}", PrecioTotal));
        //                }




        //                a.AnadirDatosGenerales("S/", ExoMN);
        //                a.AnadirDatosGenerales("S/", InaMN);
        //                a.AnadirDatosGenerales("S/", gravMN);
        //                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01);
        //                a.AnadirDatosGenerales("S/", string.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional));

        //                a.AnadirLineasDatosDescripcionTotal(documentoBE.documentoventaAbarrotes.ImporteNacional);


        //                a.headerImagenQR = QrCodeImgControl1.Image;


        //                // a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://facturador.softpack.com.pe/login")

        //                // //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        //                // //parametro de tipo string que debe de ser el nombre de la impresora. 
        //                a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue);
        //                break;
        //            }

        //        case "3":
        //            {
        //                documentoVentaAbarrotesSA documentoSA = new documentoVentaAbarrotesSA();
        //                documentoVentaAbarrotesDetSA documentoDetSA = new documentoVentaAbarrotesDetSA();
        //                TicketForGrandev4 a = new TicketForGrandev4();
        //                // a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        //                decimal gravMN = 0;
        //                decimal gravME = 0;
        //                decimal ExoMN = 0;
        //                decimal ExoME = 0;
        //                decimal InaMN = 0;
        //                decimal InaME = 0;
        //                decimal precioUnit = 0;
        //                decimal PrecioTotal = 0;

        //                string nombreCliente;
        //                string rucCliente = string.Empty;
        //                decimal importeTotalMN;
        //                decimal importeSumMN;
        //                // Dim comprobante = documentoSA.GetUbicar_NotaXID(intIdDocumento)
        //                // Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        //                if (My.Computer.Network.IsAvailable == true)
        //                {
        //                    // If My.Computer.Network.Ping("148.102.27.231") Then
        //                    if ((documentoBE.documentoventaAbarrotes.tipoDocumento == "01" & documentoBE.documentoventaAbarrotes.tipoVenta == "VELC") | (documentoBE.documentoventaAbarrotes.tipoDocumento == "07" & documentoBE.documentoventaAbarrotes.tipoVenta == "NTCE"))
        //                        XmlFactura(documentoBE.documentoventaAbarrotes, documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList);
        //                }

        //                if ((objDatosGenrales.logo.Length > 0))
        //                    // Logo de la Empresa
        //                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo);

        //                if ((objDatosGenrales.nombreImpresion == "C"))
        //                    a.tipoImagen = false;
        //                else if ((objDatosGenrales.nombreImpresion == "R"))
        //                    a.tipoImagen = true;

        //                // Direccion de La empresa general
        //                if ((objDatosGenrales.tipoImpresion == "S"))
        //                {
        //                    a.tipoEncabezado = true;
        //                    a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto);
        //                    a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial);
        //                }
        //                else if ((objDatosGenrales.tipoImpresion == "N"))
        //                {
        //                    a.tipoEncabezado = false;
        //                    a.AnadirLineaEmpresa(objDatosGenrales.razonSocial);
        //                }

        //                if ((objDatosGenrales.publicidad.Length > 0))
        //                {
        //                    a.tipoPublicidad = true;
        //                    a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad);
        //                }
        //                else
        //                    a.tipoPublicidad = false;

        //                // Dim nombreCliente As String
        //                // Dim rucCliente As String
        //                // Dim nombreCliente As String
        //                // Dim rucCliente As String

        //                // ruc
        //                a.TextoIzquierda("R.U.C.: " + objDatosGenrales.idEmpresa);
        //                // direccion de la empresa
        //                a.TextoIzquierda("Direccion: " + objDatosGenrales.direccionPrincipal);
        //                // a.TextoIzquierda("Direccion Secundaria: " & objDatosGenrales.direccionSecudaria)
        //                // Telefono de la empresa
        //                if ((objDatosGenrales.telefono3.Length > 0))
        //                    a.TextoIzquierda("Telf: " + objDatosGenrales.telefono1 + " - " + objDatosGenrales.telefono2 + " - " + objDatosGenrales.telefono3);
        //                else if ((objDatosGenrales.telefono2.Length > 0))
        //                    a.TextoIzquierda("Telf: " + objDatosGenrales.telefono1 + " - " + objDatosGenrales.telefono2);
        //                else
        //                    a.TextoIzquierda("Telf: " + objDatosGenrales.telefono1);


        //                string DIRECCIONclIENTE = string.Empty;
        //                if (documentoBE.documentoventaAbarrotes.idCliente != 0)
        //                {
        //                    var entidad = documentoBE.documentoventaAbarrotes.CustomEntidad;  // entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
        //                    string NBoletaElectronica = entidad.nombreCompleto;
        //                    DIRECCIONclIENTE = entidad.DireccionSeleccionada; // entidad.direccion
        //                    nombreCliente = (NBoletaElectronica);
        //                    if (entidad.nrodoc.Trim.Length == 11)
        //                        rucCliente = ("RUC.: " + entidad.nrodoc);
        //                    else if (entidad.nrodoc.Trim.Length == 8)
        //                        rucCliente = ("DNI.: " + entidad.nrodoc);
        //                    else
        //                        rucCliente = ("NRO DOC.: " + entidad.nrodoc);

        //                    // Codigo qr

        //                    if ((!IsNothing(HASH)))
        //                    {
        //                        if (HASH.Trim.Length > 0)
        //                        {
        //                            QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + entidad.tipoDoc + "|" + entidad.nrodoc + "|" + HASH + "|" + CERTIFICADO);

        //                            QrCodeImgControl1.Text = QR;
        //                        }
        //                        else
        //                        {
        //                            QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date + "|" + entidad.tipoDoc + "|" + entidad.nrodoc);

        //                            QrCodeImgControl1.Text = QR;
        //                        }
        //                    }

        //                    QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + entidad.tipoDoc + "|" + entidad.nrodoc);

        //                    QrCodeImgControl1.Text = QR;
        //                }
        //                else
        //                {
        //                    string NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido;
        //                    nombreCliente = (NBoletaElectronica);

        //                    // Codigo qr
        //                    QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + "VARIOS" + "|" + "0");

        //                    QrCodeImgControl1.Text = QR;
        //                }

        //                switch (documentoBE.documentoventaAbarrotes.tipoDocumento)
        //                {
        //                    case "12.1":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = 1;
        //                            a.AnadirLineaComprobante("TICKET BOLETA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            break;
        //                        }

        //                    case "12.2":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = 1;
        //                            a.AnadirLineaComprobante("TICKET FACTURA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            break;
        //                        }

        //                    case "03":
        //                        {
        //                            if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VELC"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA DE VENTA ELECTRONICA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 2;
        //                                a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + System.Convert.ToString(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, '0'));

        //                                var consultaNombre = (from b in UsuariosList
        //                                                      where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                                      select b).FirstOrDefault;

        //                                if (!IsNothing(consultaNombre))
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno);
        //                                else
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + "VARIOS");


        //                                a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE");
        //                                a.AnadirLineasDatosFinales("VENTA ELECTRONICA");
        //                                a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login");
        //                                a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia");
        //                                a.AnadirLineasDatosFinales("034-005-0010982");

        //                                a.AnadirLineasDatosFinales("");

        //                                // a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
        //                                // a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
        //                                // a.AnadirLineasDatosFinales("maych_1@hotmail.com")
        //                                // a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
        //                                // a.AnadirLineasDatosFinales("(01)-12345678")
        //                                a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA");
        //                            }
        //                            else if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VPOS"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " + System.Convert.ToString(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, '0') + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 1;
        //                                a.AnadirLineaComprobante("BOLETA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            }

        //                            break;
        //                        }

        //                    case "01":
        //                        {
        //                            if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VELC"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 2;
        //                                a.AnadirLineaComprobante("FACTURA ELECTRONICA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + System.Convert.ToString(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, '0'));

        //                                var consultaNombre = (from b in UsuariosList
        //                                                      where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                                      select b).FirstOrDefault;

        //                                if (!IsNothing(consultaNombre))
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno);
        //                                else
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + "VARIOS");

        //                                a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE");
        //                                a.AnadirLineasDatosFinales("VENTA ELECTRONICA");
        //                                a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login");
        //                                a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia");
        //                                a.AnadirLineasDatosFinales("034-005-0010982");

        //                                a.AnadirLineasDatosFinales("");

        //                                // a.AnadirLineasDatosFinales("CUALQUIER CAMBIO O DEVOLUCION SERA HASTA")
        //                                // a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
        //                                // a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
        //                                // a.AnadirLineasDatosFinales("maych_1@hotmail.com")
        //                                // a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
        //                                // a.AnadirLineasDatosFinales("(01)-12345678")
        //                                a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA");
        //                            }
        //                            else if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VPOS"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " + System.Convert.ToString(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, '0') + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 1;
        //                                a.AnadirLineaComprobante("FACTURA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            }

        //                            break;
        //                        }

        //                    case "9901":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "PROFORMA   N° " + 0, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.AnadirLineaComprobante("PROFORMA");
        //                            a.AnadirLineaComprobante(0 + "-" + 0);
        //                            a.tipoComprobante = 1;
        //                            break;
        //                        }

        //                    case "07":
        //                        {
        //                            string tipoEmision = string.Empty;

        //                            // Select Case comprobante.estadoCobro
        //                            // Case "DC"
        //                            // tipoVenta = "CONTADO"
        //                            // Case "PN"
        //                            // tipoVenta = "CREDITO"
        //                            // End Select

        //                            switch (documentoBE.documentoventaAbarrotes.notaCredito)
        //                            {
        //                                case "01":
        //                                    {
        //                                        tipoEmision = "Anulación de la Operación";
        //                                        break;
        //                                    }

        //                                case "02":
        //                                    {
        //                                        tipoEmision = "Anulación por error en el RUC";
        //                                        break;
        //                                    }

        //                                case "03":
        //                                    {
        //                                        tipoEmision = "Anulación por error en la descripción";
        //                                        break;
        //                                    }

        //                                case "04":
        //                                    {
        //                                        tipoEmision = "Descuento global";
        //                                        break;
        //                                    }

        //                                case "05":
        //                                    {
        //                                        tipoEmision = "Descuento por item";
        //                                        break;
        //                                    }

        //                                case "06":
        //                                    {
        //                                        tipoEmision = "devolución total";
        //                                        break;
        //                                    }

        //                                case "07":
        //                                    {
        //                                        tipoEmision = "devolución por item";
        //                                        break;
        //                                    }

        //                                case "08":
        //                                    {
        //                                        tipoEmision = "Bonificación";
        //                                        break;
        //                                    }

        //                                case "09":
        //                                    {
        //                                        tipoEmision = "disminución en el valor";
        //                                        break;
        //                                    }

        //                                case "10":
        //                                    {
        //                                        tipoEmision = "Otros conceptos";
        //                                        break;
        //                                    }

        //                                case "11":
        //                                    {
        //                                        tipoEmision = "Ajustes de Operaciones de exportación";
        //                                        break;
        //                                    }
        //                            }

        //                            string NombreComprobante = string.Empty;
        //                            switch (documentoBE.documentoventaAbarrotes.TipoDocNota)
        //                            {
        //                                case "01":
        //                                    {
        //                                        NombreComprobante = "FACTURA ELECTRONICA";
        //                                        break;
        //                                    }

        //                                case "02":
        //                                    {
        //                                        NombreComprobante = "BOLETA ELECTRONICA";
        //                                        break;
        //                                    }
        //                            }

        //                            // Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)

        //                            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc, "", nombreCliente, DIRECCIONclIENTE, documentoBE.documentoventaAbarrotes.fechaDoc, rucCliente, "NAC", tipoEmision);
        //                            a.tipoComprobante = 2;
        //                            a.AnadirLineaComprobante("NOTA DE CREDITO ELECTRONICA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + System.Convert.ToString(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, '0'));



        //                            var consultaNombre = (from b in UsuariosList
        //                                                  where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                                  select b).FirstOrDefault;

        //                            if (!IsNothing(consultaNombre))
        //                                a.AnadirLineasDatosFinales("VENDEDOR: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno);
        //                            else
        //                                a.AnadirLineasDatosFinales("VENDEDOR: " + "VARIOS");
        //                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE");
        //                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA");
        //                            a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login");
        //                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia");
        //                            a.AnadirLineasDatosFinales("034-005-0010982");

        //                            a.AnadirLineasDatosFinales("");

        //                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA");
        //                            break;
        //                        }

        //                    default:
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = 1;
        //                            a.AnadirLineaComprobante("NOTA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            break;
        //                        }
        //                }

        //                foreach (var i in documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList)
        //                {
        //                    switch (i.destino)
        //                    {
        //                        case  OperacionGravada.Grabado:
        //                            {
        //                                gravMN += System.Convert.ToDecimal(i.montokardex);
        //                                gravME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }

        //                        case  OperacionGravada.Exonerado:
        //                            {
        //                                ExoMN += System.Convert.ToDecimal(i.montokardex);
        //                                ExoME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }

        //                        case  OperacionGravada.Inafecto:
        //                            {
        //                                InaMN += System.Convert.ToDecimal(i.montokardex);
        //                                InaME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }
        //                    }

        //                    precioUnit = (Math.Round(System.Convert.ToDouble(i.importeMN / (double)i.monto1), 2));
        //                    PrecioTotal = i.importeMN;

        //                    a.AnadirLineaElementosFactura(i.monto1, i.nombreItem, i.unidad1, string.Format("{0:0.00}", precioUnit), string.Format("{0:0.00}", i.descuentoMN.GetValueOrDefault), string.Format("{0:0.00}", PrecioTotal));

        //                    // a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
        //                    // a.AnadirNombreElemento(i.nombreItem)
        //                    importeTotalMN += i.importeMN;
        //                }

        //                a.AnadirDatosGenerales("S/", ExoMN);
        //                a.AnadirDatosGenerales("S/", InaMN);
        //                a.AnadirDatosGenerales("S/", gravMN);
        //                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01);
        //                a.AnadirDatosGenerales("S/", string.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional));

        //                a.AnadirLineasDatosDescripcionTotal(documentoBE.documentoventaAbarrotes.ImporteNacional);

        //                if ((!IsNothing(documentoBE.ListaCustomDocumento)))
        //                {
        //                    foreach (var item in documentoBE.ListaCustomDocumento.ToList)
        //                    {
        //                        a.AnadirLineasDescuento(item.documentoCaja.formaPagoName + ": " + item.documentoCaja.montoSoles);
        //                        importeSumMN += item.documentoCaja.montoSoles;
        //                    }

        //                    a.AnadirLineasDescuento("PENDIENTE: " + importeTotalMN - importeSumMN);
        //                }
        //                else
        //                {
        //                    foreach (var item in listaDocumento)
        //                    {
        //                        var formasPago = Helios.General.TablasGenerales.GetFormasDePago();
        //                        var formaSel = formasPago.Where(o => o.codigoDetalle == item.sustentado).SingleOrDefault;

        //                        // a.AnadirLineasDescuento(item.NombreEntidad & ": " & item.ImporteNacional & "     " & " N°" & item.NroDocEntidad & "  OPER." & item.numeroVenta)
        //                        a.AnadirLineasDescuento(formaSel.descripcion + ": " + item.ImporteNacional);
        //                        importeSumMN += item.ImporteNacional;
        //                    }

        //                    a.AnadirLineasDescuento("PENDIENTE: " + importeTotalMN - importeSumMN);
        //                }

        //                a.headerImagenQR = QrCodeImgControl1.Image;

        //                // a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://facturador.softpack.com.pe/login")
        //                // //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        //                // //parametro de tipo string que debe de ser el nombre de la impresora. 
        //                a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue);
        //                break;
        //            }

        //        case "6":
        //            {
        //                documentoVentaAbarrotesSA documentoSA = new documentoVentaAbarrotesSA();
        //                documentoVentaAbarrotesDetSA documentoDetSA = new documentoVentaAbarrotesDetSA();
        //                TicketForGrandeNota a = new TicketForGrandeNota();
        //                // a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        //                decimal gravMN = 0;
        //                decimal gravME = 0;
        //                decimal ExoMN = 0;
        //                decimal ExoME = 0;
        //                decimal InaMN = 0;
        //                decimal InaME = 0;
        //                decimal precioUnit = 0;
        //                decimal PrecioTotal = 0;

        //                string nombreCliente;
        //                string rucCliente = string.Empty;
        //                decimal importeTotalMN;
        //                decimal importeSumMN;
        //                // Dim comprobante = documentoSA.GetUbicar_NotaXID(intIdDocumento)
        //                // Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        //                if (My.Computer.Network.IsAvailable == true)
        //                {
        //                    // If My.Computer.Network.Ping("148.102.27.231") Then
        //                    if ((documentoBE.documentoventaAbarrotes.tipoDocumento == "01" & documentoBE.documentoventaAbarrotes.tipoVenta == "VELC") | (documentoBE.documentoventaAbarrotes.tipoDocumento == "07" & documentoBE.documentoventaAbarrotes.tipoVenta == "NTCE"))
        //                        XmlFactura(documentoBE.documentoventaAbarrotes, documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList);
        //                }

        //                if ((objDatosGenrales.logo.Length > 0))
        //                    // Logo de la Empresa
        //                    a.HeaderImage = Image.FromFile(objDatosGenrales.logo);

        //                if ((objDatosGenrales.nombreImpresion == "C"))
        //                    a.tipoImagen = false;
        //                else if ((objDatosGenrales.nombreImpresion == "R"))
        //                    a.tipoImagen = true;

        //                // Direccion de La empresa general
        //                if ((objDatosGenrales.tipoImpresion == "S"))
        //                {
        //                    a.tipoEncabezado = true;
        //                    a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto);
        //                    a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial);
        //                }
        //                else if ((objDatosGenrales.tipoImpresion == "N"))
        //                {
        //                    a.tipoEncabezado = false;
        //                    a.AnadirLineaEmpresa(objDatosGenrales.razonSocial);
        //                }

        //                if ((objDatosGenrales.publicidad.Length > 0))
        //                {
        //                    a.tipoPublicidad = true;
        //                    a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad);
        //                }
        //                else
        //                    a.tipoPublicidad = false;

        //                // Dim nombreCliente As String
        //                // Dim rucCliente As String
        //                // Dim nombreCliente As String
        //                // Dim rucCliente As String

        //                // ruc
        //                a.TextoIzquierda("R.U.C.: " + objDatosGenrales.idEmpresa);
        //                // direccion de la empresa
        //                a.TextoIzquierda("Direccion: " + objDatosGenrales.direccionPrincipal);
        //                // a.TextoIzquierda("Direccion Secundaria: " & objDatosGenrales.direccionSecudaria)
        //                // Telefono de la empresa
        //                if ((objDatosGenrales.telefono3.Length > 0))
        //                    a.TextoIzquierda("Telf: " + objDatosGenrales.telefono1 + " - " + objDatosGenrales.telefono2 + " - " + objDatosGenrales.telefono3);
        //                else if ((objDatosGenrales.telefono2.Length > 0))
        //                    a.TextoIzquierda("Telf: " + objDatosGenrales.telefono1 + " - " + objDatosGenrales.telefono2);
        //                else
        //                    a.TextoIzquierda("Telf: " + objDatosGenrales.telefono1);

        //                string DIRECCIONclIENTE = string.Empty;
        //                if (documentoBE.documentoventaAbarrotes.idCliente != 0)
        //                {
        //                    var entidad = documentoBE.documentoventaAbarrotes.CustomEntidad;  // entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
        //                    string NBoletaElectronica = entidad.nombreCompleto;
        //                    DIRECCIONclIENTE = entidad.DireccionSeleccionada;
        //                    nombreCliente = (NBoletaElectronica);
        //                    if (entidad.nrodoc.Trim.Length == 11)
        //                        rucCliente = ("RUC.: " + entidad.nrodoc);
        //                    else if (entidad.nrodoc.Trim.Length == 8)
        //                        rucCliente = ("DNI.: " + entidad.nrodoc);
        //                    else
        //                        rucCliente = ("NRO DOC.: " + entidad.nrodoc);

        //                    // Codigo qr

        //                    if ((!IsNothing(HASH)))
        //                    {
        //                        if (HASH.Trim.Length > 0)
        //                        {
        //                            QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + entidad.tipoDoc + "|" + entidad.nrodoc + "|" + HASH + "|" + CERTIFICADO);

        //                            QrCodeImgControl1.Text = QR;
        //                        }
        //                        else
        //                        {
        //                            QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date + "|" + entidad.tipoDoc + "|" + entidad.nrodoc);

        //                            QrCodeImgControl1.Text = QR;
        //                        }
        //                    }

        //                    QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + entidad.tipoDoc + "|" + entidad.nrodoc);

        //                    QrCodeImgControl1.Text = QR;
        //                }
        //                else
        //                {
        //                    string NBoletaElectronica = documentoBE.documentoventaAbarrotes.nombrePedido;
        //                    nombreCliente = (NBoletaElectronica);

        //                    // Codigo qr
        //                    QR = (Gempresas.IdEmpresaRuc + "|" + documentoBE.documentoventaAbarrotes.tipoDocumento.ToString + "|" + documentoBE.documentoventaAbarrotes.serieVenta + "|" + documentoBE.documentoventaAbarrotes.numeroVenta + "|" + Format(documentoBE.documentoventaAbarrotes.igv01, 2) + "|" + documentoBE.documentoventaAbarrotes.ImporteNacional + "|" + (DateTime)documentoBE.documentoventaAbarrotes.fechaDoc.Date.ToString(FormatoFecha) + "|" + "VARIOS" + "|" + "0");

        //                    QrCodeImgControl1.Text = QR;
        //                }

        //                switch (documentoBE.documentoventaAbarrotes.tipoDocumento)
        //                {
        //                    case "12.1":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET BOLETA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = 1;
        //                            a.AnadirLineaComprobante("TICKET BOLETA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            break;
        //                        }

        //                    case "12.2":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET FACTURA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = 1;
        //                            a.AnadirLineaComprobante("TICKET FACTURA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            break;
        //                        }

        //                    case "03":
        //                        {
        //                            if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VELC"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA DE VENTA ELECTRONICA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 2;
        //                                a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + System.Convert.ToString(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, '0'));

        //                                var consultaNombre = (from b in UsuariosList
        //                                                      where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                                      select b).FirstOrDefault;

        //                                if (!IsNothing(consultaNombre))
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno);
        //                                else
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + "VARIOS");


        //                                a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE");
        //                                a.AnadirLineasDatosFinales("VENTA ELECTRONICA");
        //                                a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login");
        //                                a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia");
        //                                a.AnadirLineasDatosFinales("034-005-0010982");

        //                                a.AnadirLineasDatosFinales("");

        //                                // a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
        //                                // a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
        //                                // a.AnadirLineasDatosFinales("maych_1@hotmail.com")
        //                                // a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
        //                                // a.AnadirLineasDatosFinales("(01)-12345678")
        //                                a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA");
        //                            }
        //                            else if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VPOS"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "BOLETA   N° " + System.Convert.ToString(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, '0') + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 1;
        //                                a.AnadirLineaComprobante("BOLETA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            }

        //                            break;
        //                        }

        //                    case "01":
        //                        {
        //                            if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VELC"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA ELECTRONICA   N° " + documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 2;
        //                                a.AnadirLineaComprobante("FACTURA ELECTRONICA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + System.Convert.ToString(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, '0'));

        //                                var consultaNombre = (from b in UsuariosList
        //                                                      where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                                      select b).FirstOrDefault;

        //                                if (!IsNothing(consultaNombre))
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno);
        //                                else
        //                                    a.AnadirLineasDatosFinales("VENDEDOR: " + "VARIOS");

        //                                a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE");
        //                                a.AnadirLineasDatosFinales("VENTA ELECTRONICA");
        //                                a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login");
        //                                a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia");
        //                                a.AnadirLineasDatosFinales("034-005-0010982");

        //                                a.AnadirLineasDatosFinales("");

        //                                // a.AnadirLineasDatosFinales("CUALQUIER CAMBIO O DEVOLUCION SERA HASTA")
        //                                // a.AnadirLineasDatosFinales("SIETE (7) DIAS DESPUES DE LA COMPRA")
        //                                // a.AnadirLineasDatosFinales("PRESENTAR TICKET ORIGINAL")
        //                                // a.AnadirLineasDatosFinales("maych_1@hotmail.com")
        //                                // a.AnadirLineasDatosFinales("TELEFONO DE ATENCION AL CLIENTE")
        //                                // a.AnadirLineasDatosFinales("(01)-12345678")
        //                                a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA");
        //                            }
        //                            else if ((documentoBE.documentoventaAbarrotes.tipoVenta == "VPOS"))
        //                            {
        //                                a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "FACTURA   N° " + System.Convert.ToString(documentoBE.documentoventaAbarrotes.serieVenta).PadLeft(3, '0') + "-" + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                                a.tipoComprobante = 1;
        //                                a.AnadirLineaComprobante("FACTURA");
        //                                a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            }

        //                            break;
        //                        }

        //                    case "9901":
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "PROFORMA   N° " + 0, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.AnadirLineaComprobante("PROFORMA");
        //                            a.AnadirLineaComprobante(0 + "-" + 0);
        //                            a.tipoComprobante = 1;
        //                            break;
        //                        }

        //                    case "07":
        //                        {
        //                            string tipoEmision = string.Empty;

        //                            // Select Case comprobante.estadoCobro
        //                            // Case "DC"
        //                            // tipoVenta = "CONTADO"
        //                            // Case "PN"
        //                            // tipoVenta = "CREDITO"
        //                            // End Select

        //                            switch (documentoBE.documentoventaAbarrotes.notaCredito)
        //                            {
        //                                case "01":
        //                                    {
        //                                        tipoEmision = "Anulación de la Operación";
        //                                        break;
        //                                    }

        //                                case "02":
        //                                    {
        //                                        tipoEmision = "Anulación por error en el RUC";
        //                                        break;
        //                                    }

        //                                case "03":
        //                                    {
        //                                        tipoEmision = "Anulación por error en la descripción";
        //                                        break;
        //                                    }

        //                                case "04":
        //                                    {
        //                                        tipoEmision = "Descuento global";
        //                                        break;
        //                                    }

        //                                case "05":
        //                                    {
        //                                        tipoEmision = "Descuento por item";
        //                                        break;
        //                                    }

        //                                case "06":
        //                                    {
        //                                        tipoEmision = "devolución total";
        //                                        break;
        //                                    }

        //                                case "07":
        //                                    {
        //                                        tipoEmision = "devolución por item";
        //                                        break;
        //                                    }

        //                                case "08":
        //                                    {
        //                                        tipoEmision = "Bonificación";
        //                                        break;
        //                                    }

        //                                case "09":
        //                                    {
        //                                        tipoEmision = "disminución en el valor";
        //                                        break;
        //                                    }

        //                                case "10":
        //                                    {
        //                                        tipoEmision = "Otros conceptos";
        //                                        break;
        //                                    }

        //                                case "11":
        //                                    {
        //                                        tipoEmision = "Ajustes de Operaciones de exportación";
        //                                        break;
        //                                    }
        //                            }

        //                            string NombreComprobante = string.Empty;
        //                            switch (documentoBE.documentoventaAbarrotes.TipoDocNota)
        //                            {
        //                                case "01":
        //                                    {
        //                                        NombreComprobante = "FACTURA ELECTRONICA";
        //                                        break;
        //                                    }

        //                                case "02":
        //                                    {
        //                                        NombreComprobante = "BOLETA ELECTRONICA";
        //                                        break;
        //                                    }
        //                            }

        //                            // Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)

        //                            a.AnadirLineaCaracteresDatosGEnerales(documentoBE.documentoventaAbarrotes.fechaDoc, "", nombreCliente, DIRECCIONclIENTE, documentoBE.documentoventaAbarrotes.fechaDoc, rucCliente, "NAC", tipoEmision);
        //                            a.tipoComprobante = 2;
        //                            a.AnadirLineaComprobante("NOTA DE CREDITO ELECTRONICA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + System.Convert.ToString(documentoBE.documentoventaAbarrotes.numeroVenta).PadLeft(8, '0'));



        //                            var consultaNombre = (from b in UsuariosList
        //                                                  where b.IDUsuario == documentoBE.documentoventaAbarrotes.usuarioActualizacion
        //                                                  select b).FirstOrDefault;

        //                            if (!IsNothing(consultaNombre))
        //                                a.AnadirLineasDatosFinales("VENDEDOR: " + consultaNombre.Nombres + " " + consultaNombre.ApellidoPaterno + " " + consultaNombre.ApellidoMaterno);
        //                            else
        //                                a.AnadirLineasDatosFinales("VENDEDOR: " + "VARIOS");
        //                            a.AnadirLineasDatosFinales("REPRESENTACION IMPRESA DEL COMPROBANTE");
        //                            a.AnadirLineasDatosFinales("VENTA ELECTRONICA");
        //                            a.AnadirLineasDatosFinales("http://facturador.softpack.com.pe/login");
        //                            a.AnadirLineasDatosFinales("Autorizado mediante resolución de intendencia");
        //                            a.AnadirLineasDatosFinales("034-005-0010982");

        //                            a.AnadirLineasDatosFinales("");

        //                            a.AnadirLineasDatosFinales("GRACIAS POR SU COMPRA");
        //                            break;
        //                        }

        //                    default:
        //                        {
        //                            a.AnadirLineaCaracteresDatosGEnerales(System.Convert.ToString(documentoBE.documentoventaAbarrotes.fechaDoc.Value), "TICKET NOTA   N° " + documentoBE.documentoventaAbarrotes.numeroVenta, nombreCliente, DIRECCIONclIENTE, "", rucCliente, "NAC", "966557413");
        //                            a.tipoComprobante = 1;
        //                            a.AnadirLineaComprobante("NOTA");
        //                            a.AnadirLineaComprobante(documentoBE.documentoventaAbarrotes.serieVenta + "-" + documentoBE.documentoventaAbarrotes.numeroVenta);
        //                            break;
        //                        }
        //                }

        //                foreach (var i in documentoBE.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList)
        //                {
        //                    switch (i.destino)
        //                    {
        //                        case  OperacionGravada.Grabado:
        //                            {
        //                                gravMN += System.Convert.ToDecimal(i.montokardex);
        //                                gravME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }

        //                        case  OperacionGravada.Exonerado:
        //                            {
        //                                ExoMN += System.Convert.ToDecimal(i.montokardex);
        //                                ExoME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }

        //                        case  OperacionGravada.Inafecto:
        //                            {
        //                                InaMN += System.Convert.ToDecimal(i.montokardex);
        //                                InaME += System.Convert.ToDecimal(i.montokardexUS);
        //                                break;
        //                            }
        //                    }

        //                    precioUnit = (Math.Round(System.Convert.ToDouble(i.importeMN / (double)i.monto1), 2));
        //                    PrecioTotal = i.importeMN;

        //                    a.AnadirLineaElementosFactura(i.monto1, i.nombreItem, i.unidad1, string.Format("{0:0.00}", precioUnit), string.Format("{0:0.00}", PrecioTotal));

        //                    // a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
        //                    // a.AnadirNombreElemento(i.nombreItem)
        //                    importeTotalMN += i.importeMN;
        //                }

        //                a.AnadirDatosGenerales("S/", ExoMN);
        //                a.AnadirDatosGenerales("S/", InaMN);
        //                a.AnadirDatosGenerales("S/", gravMN);
        //                a.AnadirDatosGenerales("S/", documentoBE.documentoventaAbarrotes.igv01);
        //                a.AnadirDatosGenerales("S/", string.Format("{0:0.00}", documentoBE.documentoventaAbarrotes.ImporteNacional));

        //                a.AnadirLineasDatosDescripcionTotal(documentoBE.documentoventaAbarrotes.ImporteNacional);

        //                a.headerImagenQR = QrCodeImgControl1.Image;

        //                // a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://facturador.softpack.com.pe/login")
        //                // //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        //                // //parametro de tipo string que debe de ser el nombre de la impresora. 
        //                a.ImprimeTicket(imprimir, txtNroImpresion.DecimalValue);
        //                break;
        //            }
        //    }
        //}



        private static DataSet DataSetGetir()
        {
            var resultDataSet = new DataSet();
            using (var valueTable = new DataTable("message"))
            {
                valueTable.Columns.Add("to");
                valueTable.Columns.Add("from");
                valueTable.Columns.Add("heading");
                valueTable.Columns.Add("body");

                var ilkRow = valueTable.NewRow();
                ilkRow["to"] = "ali";
                ilkRow["from"] = "veli";
                ilkRow["heading"] = "baslik1";
                ilkRow["body"] = "ilk mesajım";

                var ikinciRow = valueTable.NewRow();
                ikinciRow["to"] = "temel";
                ikinciRow["from"] = "dursun";
                ikinciRow["heading"] = "baslik2";
                ikinciRow["body"] = "ikinci mesajım";

                valueTable.Rows.Add(ilkRow);
                valueTable.Rows.Add(ikinciRow);

                resultDataSet.Tables.Add(valueTable);

                return resultDataSet;
            }
        }

        public ActionResult GetReportePrueba()
        {
            WebReport webReport = new WebReport(); //create instance of WebReport object.
                                                   //   string report_path = "J:\\Program Files (x86)\\FastReports\\FastReport.Net\\Demos\\Reports\\"; //reports directory
            string report_path = "D:\\"; //reports directory
                                         // string report_path = "App_Data/"; //reports directory
            System.Data.DataSet dataSet = new System.Data.DataSet(); //create data set
            dataSet = DataSetGetir();
            //dataSet.ReadXml(report_path + "testdata.xml"); //load xml data base

            webReport.Report.RegisterData(dataSet, "testdata"); //registry data source in the web report
            webReport.Report.Load(report_path + "testdata.frx"); //load the report to WebReport                        
            webReport.Report.Prepare();
            ViewBag.WebReport = webReport; //send the report to View
                                           // return View();

            //var model = new HomeModel()
            //{
            //    WebReport = new WebReport(),
            //    ReportsList = new[]
            //    {
            //        "Simple List",
            //        "Labels",
            //        "Master-Detail",
            //        "Badges",
            //        "Interactive Report, 2-in-1",
            //        "Hyperlinks, Bookmarks",
            //        "Outline",
            //        "Complex (Hyperlinks, Outline, TOC)",
            //        "Drill-Down Groups",
            //        "Mail Merge"
            //    },
            //};


            //model.WebReport.Report.Load(Path.Combine(report_path + "testdata.frx"));

            //var dataSet = new DataSet();
            //dataSet = DataSetGetir();
            ////dataSet.ReadXml(Path.Combine(ReportsFolder, "nwind.xml"));
            //model.WebReport.Report.RegisterData(dataSet, "NorthWind");

            return View();
        }

        #endregion

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
                var doc = ventaSA.GetVentaID(new BE.documento() { idDocumento = id });

                return View(doc);
            }            
        }


        [HttpGet]
        public JsonResult GetVentaID(int id)
        {
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            var doc = ventaSA.GetVentaID(new BE.documento() { idDocumento = id });
            return Json(doc, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EmpDetails(int id)
        {
            SA.EstadosFinancierosConfiguracionPagosSA configsA = new SA.EstadosFinancierosConfiguracionPagosSA();

            //Creating List    
            var listaCuentas = configsA.GetConfigurationPayCaja(new BE.estadosFinancierosConfiguracionPagos()
            {
                idEmpresa = LoginInformation.Empresa.idEmpresa,
                idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                IDCaja = id//usuariocaja.idcajaUsuario
            });
            ////return list as Json    
            //listaCuentas.Add(new BE.estadosFinancierosConfiguracionPagos()
            //{
            //    IDFormaPago = "1",
            //    FormaPago = "FECTIVO 2",
            //    idConfiguracion = 1,
            //    idEmpresa = "DSFSDF",
            //    idEstablecimiento = 3,
            //    identidad = 5,
            //    moneda = "1",
            //    tipo = "-",
            //    fecha = DateTime.Now,
            //    entidad = "JUAN"
            //});
            return Json(listaCuentas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPedidosPendientes()
        {
            var periodo = General.Constantes.GetPeriodo(DateTime.Now, true);
            SA.documentoVentaAbarrotesSA DocumentoVentaSA = new SA.documentoVentaAbarrotesSA();
            var ListaPedidos = DocumentoVentaSA.GetListarVentasPeriodoXTipo(LoginInformation.Empresa.idEmpresa, LoginInformation.Establecimiento.idCentroCosto, periodo, "VNP", StatusTipoConsulta .XUNIDAD_ORGANICA ).OrderByDescending(v => v.idDocumento).ToList();
            return Json(ListaPedidos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PagarVenta()
        {
            var UsuarioBE = new BE.cajaUsuario();
            SA.cajaUsuarioSA cajaUsuarioSA = new SA.cajaUsuarioSA();
            UsuarioBE.idEmpresa = LoginInformation.Empresa.idEmpresa;
            UsuarioBE.idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto;
            UsuarioBE.estadoCaja = "A";

            var listaActivas = cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE);

            //creamos una lista tipo SelectListItem
            List<SelectListItem> lst = new List<SelectListItem>();

            //De la siguiente manera llenamos manualmente,
            //Siendo el campo Text lo que ve el usuario y
            //el campo Value lo que en realidad vale nuestro valor
            lst.Add(new SelectListItem() { Text = "-Seleccionar-", Value = "0" });
            foreach (var item in listaActivas)
            {
                lst.Add(new SelectListItem() { Text = item.NombrePersona, Value = item.idcajaUsuario.ToString() });
            }
            SelectList miSL = new SelectList(lst, "Value", "Text");
            ViewBag.CityList = miSL;
            return View();
        }
        
        public ActionResult CobroPedidos()
        {
            var periodo = Helios.General.Constantes.GetPeriodo(DateTime.Now, true);

            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            var listaPedidos = ventaSA.GetListarAllVentasPeriodoPendiente(LoginInformation.Establecimiento.idCentroCosto, periodo);
            return View(listaPedidos.OrderByDescending(v=>v.fechaDoc).ToList());
        }


        public ActionResult LoadOrders(string mes, string anio)
        {
            var periodo = $"{mes}/{anio}";
            SA.documentoVentaAbarrotesSA DocumentoVentaSA = new SA.documentoVentaAbarrotesSA();
            var ListaPedidos = DocumentoVentaSA.GetListarVentasPeriodoXTipo(LoginInformation.Empresa.idEmpresa, LoginInformation.Establecimiento.idCentroCosto, periodo, "VNP", StatusTipoConsulta .XUNIDAD_ORGANICA ).OrderByDescending(v => v.idDocumento).ToList();
            return Json(new { data = ListaPedidos }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadVentas(string mes, string anio)
        {
            var periodo = $"{mes}/{anio}";
            SA.documentoVentaAbarrotesSA DocumentoVentaSA = new SA.documentoVentaAbarrotesSA();            
            var ListaPedidos = DocumentoVentaSA.GetListarVentasNotasPeriodo(LoginInformation.Establecimiento.idCentroCosto, periodo).OrderByDescending(v => v.idDocumento).ToList();
            return Json(new { data = ListaPedidos }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListadoOrdenes()
        {
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                if (Product.GetUsuariosSistemas == null)
                {
                    Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                    Product.GetUsuariosSistemas = usuarioSA.ListadoUsuariosv2();
                }
                return View(new ViewModelGeneral());
            }                        
        }

        public ActionResult ListadoVentas()
        {
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                if (Product.GetUsuariosSistemas == null)
                {
                    Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                    Product.GetUsuariosSistemas = usuarioSA.ListadoUsuariosv2();
                }
                return View(new ViewModelGeneral());
            }
        }


        public ActionResult NewSale()
        {
            var ClienteVarios = new BE.entidad();


            ItemViewModel itemViewModel = new ItemViewModel();
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                //SA.detalleitemsSA prodSA = new SA.detalleitemsSA();
                //idEmpresa = "20604303495",
                //if (Product.GetDetalleitems == null || Product.GetDetalleitems.Count == 0)
                //{
                //    var Products = prodSA.GetProductosWithInventario(new BE.detalleitems
                //    {
                //        idEmpresa = LoginInformation.Empresa.idEmpresa,
                //        idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                //        descripcionItem = ""
                //    });
                //    Product.GetDetalleitems = Products;
                //    itemViewModel.GetDetalleitems = Products;
                //}
                //else
                //{
                //    itemViewModel.GetDetalleitems = Product.GetDetalleitems;
                //}

                var UsuarioBE = new BE.cajaUsuario();
                SA.cajaUsuarioSA cajaUsuarioSA = new SA.cajaUsuarioSA();
                UsuarioBE.idEmpresa = LoginInformation.Empresa.idEmpresa;
                UsuarioBE.idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto;
                UsuarioBE.estadoCaja = "A";

                var listaActivas = cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE);

                //creamos una lista tipo SelectListItem
                List<SelectListItem> lst = new List<SelectListItem>();

                //De la siguiente manera llenamos manualmente,
                //Siendo el campo Text lo que ve el usuario y
                //el campo Value lo que en realidad vale nuestro valor
              //  lst.Add(new SelectListItem() { Text = "-Seleccionar-", Value = "0" });
                foreach (var item in listaActivas)
                {
                    lst.Add(new SelectListItem() { Text = item.NombrePersona, Value = item.idcajaUsuario.ToString() });
                }
                SelectList miSL = new SelectList(lst, "Value", "Text");
                ViewBag.CityList = miSL;

                SA.entidadSA entidadSA = new SA.entidadSA();

                ClienteVarios = entidadSA.UbicarEntidadVarios("VR", LoginInformation.Empresa.idEmpresa, "", LoginInformation.Establecimiento.idCentroCosto);
                //ViewBag.ClienteVarios = ClienteVarios;
                itemViewModel.EntidadVarios = ClienteVarios;
                return View(itemViewModel);
            }
        }

        public ActionResult NuevaVenta()
        {
            
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                SA.detalleitemsSA prodSA = new SA.detalleitemsSA();
                //idEmpresa = "20604303495",

                if (Product.GetDetalleitems == null  || Product.GetDetalleitems.Count == 0)
                {
                    var Products = prodSA.GetProductosWithInventario(new BE.detalleitems
                    {
                        idEmpresa = LoginInformation.Empresa.idEmpresa,
                        idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                        descripcionItem = ""
                    });
                    Product.GetDetalleitems = Products;                   
                }
                else
                {
                    
                }
                var UsuarioBE = new BE.cajaUsuario();
                SA.cajaUsuarioSA cajaUsuarioSA = new SA.cajaUsuarioSA();
                UsuarioBE.idEmpresa = LoginInformation.Empresa.idEmpresa;
                UsuarioBE.idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto;
                UsuarioBE.estadoCaja = "A";

                var listaActivas = cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE);

                //creamos una lista tipo SelectListItem
                List<SelectListItem> lst = new List<SelectListItem>();

                //De la siguiente manera llenamos manualmente,
                //Siendo el campo Text lo que ve el usuario y
                //el campo Value lo que en realidad vale nuestro valor
                lst.Add(new SelectListItem() { Text = "-Seleccionar-", Value = "0" });
                foreach (var item in listaActivas)
                {
                    lst.Add(new SelectListItem() { Text = item.NombrePersona, Value = item.idcajaUsuario.ToString() });
                }
                SelectList miSL = new SelectList(lst, "Value", "Text");
                ViewBag.CityList = miSL;
                return View();

            }
        }

        [HttpGet]
        public  ActionResult NuevaOrden2()
        {
            ItemViewModel itemViewModel = new ItemViewModel();
            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
             //   SA.detalleitemsSA prodSA = new SA.detalleitemsSA();
            //   // idEmpresa = "20604303495",
                //if (Product.GetDetalleitems == null || Product.GetDetalleitems.Count == 0)
                //{
                //    var Products = prodSA.GetProductosWithInventario(new BE.detalleitems
                //    {
                //        idEmpresa = LoginInformation.Empresa.idEmpresa,
                //        idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                //        descripcionItem = ""
                //    });
                //    Product.GetDetalleitems = Products;
                //    itemViewModel.GetDetalleitems = Products;
                //}
                //else
                //{
                //    itemViewModel.GetDetalleitems = Product.GetDetalleitems;
                //}

                itemViewModel.TransferTransitCount = LoginInformation.TransferTransitCount;

                return View(itemViewModel);
            }
        }

        public ActionResult NuevaOrden()
        {
            //Products = prodSA.GetProductosWithInventario(new BE.detalleitems
            //{
            //    idEmpresa = "10735115311",
            //    idEstablecimiento = 10,
            //    descripcionItem = ""
            //});

            if (Session["username"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                SA.detalleitemsSA prodSA = new SA.detalleitemsSA();
                //idEmpresa = "20604303495",
                if (Product.GetDetalleitems == null || Product.GetDetalleitems.Count == 0)
                {
                    var Products = prodSA.GetProductosWithInventario(new BE.detalleitems
                    {
                        idEmpresa = LoginInformation.Empresa.idEmpresa,
                        idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto,
                        descripcionItem = ""
                    });
                    Product.GetDetalleitems = Products;
                }
                else
                {

                }

                return View();
            }            
        }

        #region Vista Nuevo Pedido

        [HttpGet]
        public JsonResult GetProductSelText(string Text)
        {
            var productSA = new SA.detalleitemsSA();
            var listaProductos = productSA.GetProductosWithInventario(new BE.detalleitems()
            {
                idEmpresa = LoginInformation.Empresa.idEmpresa,
                idEstablecimiento = 3,
                descripcionItem = Text
            });

            return Json(listaProductos, JsonRequestBehavior.AllowGet);

        }

        public JsonResult EliminarPedido(int idDocumento)
        {
            if (Session["username"] != null)
            {
                SA.DocumentoSA ventaSA = new SA.DocumentoSA();
                ventaSA.EliminarPedidos(new BE.documento() { idDocumento = idDocumento });
                return new JsonResult { Data = new { status = true } };

            }
            else
            {
                return new JsonResult { Data = new { status = false } };
            }
            
        }

        public JsonResult AnularVenta(int idDocumento)
        {           
            if (Session["username"] != null)
            {

                BE.documento doc = new BE.documento();
                doc.idEmpresa = LoginInformation.Empresa.idEmpresa;
                doc.idCentroCosto = LoginInformation.Establecimiento.idCentroCosto;
                doc.idDocumento = idDocumento;

                SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
                ventaSA.EliminarVenta(doc);
                return new JsonResult { Data = new { status = true } };

            }
            else
            {
                return new JsonResult { Data = new { status = false } };
            }

        }

        public JsonResult GetUbicarVendedor(string codigoVendedor)
        {
            Helios.Seguridad.Business.Entity.Usuario usuarioSel;
            if (LoginInformation.ListUsers == null)
            {
                Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA usuarioSA = new Seguridad.WCFService.ServiceAccess.UsuarioSA();
                LoginInformation.ListUsers = usuarioSA.ListadoUsuariosv2();

                usuarioSel = LoginInformation.ListUsers.Where(u => u.codigo == codigoVendedor).SingleOrDefault();
            }
            else
            {
                usuarioSel = LoginInformation.ListUsers.Where(u => u.codigo == codigoVendedor).SingleOrDefault();
            }


            if (usuarioSel != null)
            {
                return Json(usuarioSel, JsonRequestBehavior.AllowGet);
            }
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetStudents(string term)
        {
            //  List<string> prods;
            //  prods = p.Detalleitems;
            term = term.ToUpper().Trim();
            if (Product.GetDetalleitems != null)
            {
                var prods2 = Product.GetDetalleitems.Where(x => x.descripcionItem.Contains(term)).Select(c => new { id = c.codigodetalle, value = c.descripcionItem });
                return Json(prods2, JsonRequestBehavior.AllowGet);
            }
            else
            {
                throw new Exception("Actualizar lista de productos");
                //return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        #region Entidades
        public JsonResult GetCliente(string nrodoc, string tipo)
        {
            SA.entidadSA entidadSA = new SA.entidadSA();
            BE.entidad ent = new BE.entidad();
            switch (tipo)
            {
                case "Varios":
                    var cli = entidadSA.UbicarEntidadVarios("VR", LoginInformation.Empresa.idEmpresa, "", LoginInformation.Establecimiento.idCentroCosto);
                    ent = cli;
                    break;

                case "Cliente":

                    if (nrodoc.ToString().Trim().Length == 8)
                    {
                        var nombres = GetConsultarDNIReniec(nrodoc);
                        ent.nrodoc = nrodoc;
                        ent.nombreCompleto = nombres;
                        ent.tipoDoc = "1";
                        ent.tipoPersona = "N";
                        ent.direccion = "-";

                        var existeEnDB = entidadSA.UbicarEntidadPorRucNro(LoginInformation.Empresa.idEmpresa, "CL", nrodoc);

                        if (existeEnDB == null)
                        {
                            ent = GrabarEntidadRapida(ent);

                        }
                        else
                        {
                            ent = existeEnDB;
                        }

                    }
                    else if (nrodoc.ToString().Trim().Length == 11)
                    {
                        var existeEnDB = entidadSA.UbicarEntidadPorRucNro(LoginInformation.Empresa.idEmpresa, "CL", nrodoc);

                        if (existeEnDB == null)
                        {
                            var obj = GetApi(nrodoc);
                            ent = obj;
                            ent = GrabarEntidadRapida(ent);
                        }
                        else
                        {
                            ent = existeEnDB;
                        }
                    }
                    break;
                default:
                    break;
            }
            return Json(ent, JsonRequestBehavior.AllowGet);
        }

        private BE.entidad GetApi(string nroruc)
        {
            BE.entidad SelRazon;
            SelRazon = new BE.entidad();
            using (var client = new HttpClient())
            {

                if (nroruc.ToString().Trim().Substring(0, 1) == "1")
                {
                    SelRazon.tipoPersona = "N";
                }
                else if (nroruc.ToString().Trim().Substring(0, 1) == "2")
                {
                    SelRazon.tipoPersona = "J";
                }

                //client.BaseAddress = new Uri("https://api.sunat.cloud/ruc/");
             //   client.BaseAddress = new Uri("https://api.peruonline.cloud/v1/?ruc=");
                //var responseTask = await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" + nroruc);

                //HTTP GET
                //if (responseTask.IsSuccessStatusCode)
                //{
                //    var readTask = responseTask.Content.ReadAsAsync<SunatContribuyente>();
                //    readTask.Wait();
                //    var students = readTask.Result;
                //    SelRazon.tipoDoc = "6";
                //    SelRazon.tipoEntidad = "PR";
                //    SelRazon.nombreCompleto = students.NombreORazonSocial;
                //    SelRazon.nombreContacto = students.NombreORazonSocial;                 
                //    SelRazon.estado = students.EstadoDelContribuyente;
                //    SelRazon.nrodoc = students.Ruc.ToString();
                //    SelRazon.direccion = students.Direccion;
                //    SelRazon.TipoVia = students.TipoDeVia;
                //    SelRazon.Via = students.NombreDeVia;
                //    SelRazon.Ubigeo = students.Ubigeo.ToString();                                      
                //}               

                var responseTask = client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" + nroruc);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SunatContribuyente>();
                    readTask.Wait();

                    var students = readTask.Result;

                    SelRazon.tipoDoc = "6";
                    SelRazon.tipoEntidad = "CL";
                    SelRazon.nombreCompleto = students.NombreORazonSocial;
                    SelRazon.nombreContacto = students.NombreORazonSocial;
                    SelRazon.estado = students.EstadoDelContribuyente;
                    SelRazon.nrodoc = students.Ruc.ToString();
                    SelRazon.direccion = students.Direccion;
                    SelRazon.TipoVia = students.TipoDeVia;
                    SelRazon.Via = students.NombreDeVia;
                    SelRazon.Ubigeo = students.Ubigeo.ToString();
                }
            }
            return SelRazon;
        }

        public JsonResult ClienteSelID(int idEntidad)
        {
            SA.entidadSA entidadSA = new SA.entidadSA();
            var entidad = entidadSA.UbicarEntidadPorID(idEntidad).First();
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertCliente(BE.entidad entidad)
        {
            SA.entidadSA entidadSA = new SA.entidadSA();

            switch (entidad.idEntidad)
            {
                case 0:
                    var codIdEntidad = entidadSA.GrabarEntidad(entidad);
                    entidad.idEntidad = codIdEntidad;
                    break;

                default:
                    entidadSA.UpdateEntidad(entidad);
                    break;
            }
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        private BE.entidad GrabarEntidadRapida(BE.entidad SelRazon)
        {
            BE.entidad obEntidad = new BE.entidad();
            SA.entidadSA entidadSA = new SA.entidadSA();
            try
            {
                // Se asigna cada uno de los datos registrados                   
                obEntidad.idEmpresa = LoginInformation.Empresa.idEmpresa;
                obEntidad.idOrganizacion = 3;
                obEntidad.tipoEntidad = "CL";
                obEntidad.tipoDoc = SelRazon.tipoDoc;
                obEntidad.tipoPersona = SelRazon.tipoPersona;
                obEntidad.nrodoc = SelRazon.nrodoc;
                obEntidad.nombreCompleto = SelRazon.nombreCompleto;
                obEntidad.cuentaAsiento = "1213";
                obEntidad.direccion = SelRazon.direccion;
                obEntidad.estado = General.Constantes.StatusEntidad.Activo;
                int codx = entidadSA.GrabarEntidad(obEntidad);
                obEntidad.idEntidad = codx;

            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception(ex.Message);
            }
            return obEntidad;
        }

        private string GetConsultarDNIReniec(string Dni)
        {
            WebClient CLIENTE = new WebClient();
            //Stream PAGINA = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" + Dni);
            Stream PAGINA = CLIENTE.OpenRead("http://clientes.reniec.gob.pe/padronElectoral2012/consulta.htm?hTipo=2&hDni=" + Dni);
            var LECTOR = new StreamReader(PAGINA);
            string MIHTML = LECTOR.ReadToEnd();
            string nombres = string.Empty;
            // Dim array = MIHTML.Split("|")
            int posicion = 0;
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(MIHTML);

            foreach (HtmlTextNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                switch (posicion)
                {
                    case 36:
                        {
                            nombres = node.Text;
                            break;                           
                        }

                    case 42:
                        {
                            break;
                        }

                    case 60:
                        {
                            break;
                        }

                    case 66:
                        {
                            break;
                        }

                    case 54:
                        {
                            break;
                        }
                }
                posicion = posicion + 1;
            }


            // nombres = MIHTML.Replace("|", Space(1))
            return nombres.ToString().Trim();
        }

        #endregion

        //public JsonResult getProductCategories()
        //{
        //    List<Category> categories;
        //    categories = Product.GetCategories();
        //    return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        public JsonResult getProducts(int categoryID)
        {
            //var ListProducts = Product.GetProducts();
            var consulta = (from n in Product.GetDetalleitems
                            from uni in n.detalleitem_equivalencias
                            from cat in uni.detalleitemequivalencia_catalogos
                            where cat.equivalencia_id.Equals(categoryID)
                            select cat).ToList();


            //  var Catalogos = Product.GetDetalleitems.Select(s => s.detalleitem_equivalencias.Select(q => q.detalleitemequivalencia_catalogos.Where(c => c.equivalencia_id == categoryID).Select(eq => new { eq.idCatalogo, eq.nombre_corto }))).ToList();
            //    var products = ListProducts.Where(a => a.CategoryId.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();

            return new JsonResult { Data = consulta, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetPrecios(int catalogoID)
        {
            //var ListProducts = Product.GetProducts();
            var consulta = (from n in Product.GetDetalleitems
                            from uni in n.detalleitem_equivalencias
                            from cat in uni.detalleitemequivalencia_catalogos
                            from price in cat.detalleitemequivalencia_precios
                            where price.idCatalogo.Equals(catalogoID)
                            select price).ToList();


            //  var Catalogos = Product.GetDetalleitems.Select(s => s.detalleitem_equivalencias.Select(q => q.detalleitemequivalencia_catalogos.Where(c => c.equivalencia_id == categoryID).Select(eq => new { eq.idCatalogo, eq.nombre_corto }))).ToList();
            //    var products = ListProducts.Where(a => a.CategoryId.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();

            return new JsonResult { Data = consulta, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getUnidades(int ProductID)
        {
            var ListProducts = Product.GetDetalleitems;
            var Produc = ListProducts.Where(s => s.codigodetalle == ProductID).SingleOrDefault();
            return new JsonResult { Data = Produc.detalleitem_equivalencias.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult save(BE.documentoventaAbarrotes order)
        {
            calculosVenta(order);
            DocumentoOperation.SaveDocumentoVenta(order);

            return new JsonResult { Data = new { status = true } };
        }


        #region VentaCaja

        private List<BE.documentoCajaDetalle> GetDetallePago(BE.documentoCaja objCaja, List<BE.documentoventaAbarrotesDet> ventaDetalle)
        {
            List<string> listaBeneficio = new List<string>();
            listaBeneficio.Add("OFERTA");
            listaBeneficio.Add("REGALO");
            var montoPago = objCaja.montoSoles.GetValueOrDefault();
            var DetallePago = new List<BE.documentoCajaDetalle>();
            foreach (var i in ventaDetalle.Where(o => !listaBeneficio.Contains(o.tipobeneficio)).ToList())
            {
                if (montoPago > 0)
                {
                    if (i.MontoSaldo > 0)
                    {
                        if (i.MontoSaldo > montoPago)
                        {
                            var canUso = montoPago;
                            i.MontoPago = canUso;
                            i.estadoPago = i.ItemPendiente;
                        }
                        else if (i.MontoSaldo == montoPago)
                        {
                            i.MontoPago = montoPago;
                            i.estadoPago = i.ItemSaldado;
                        }
                        else
                        {
                            var canUso = i.MontoSaldo;
                            i.MontoPago = canUso;
                            i.estadoPago = i.ItemSaldado;
                        }
                        montoPago -= i.MontoPago; // ImporteDisponible

                        // .codigoLote = Integer.Parse(i.codigoLote),

                        DetallePago.Add(new BE.documentoCajaDetalle()
                        {
                            destino = i.CodigoCosto,
                            fecha = DateTime.Now,
                            codigoLote = 0,
                            otroMN = 0,
                            idItem = i.idItem,
                            DetalleItem = i.nombreItem,
                            montoSoles = i.MontoPago,
                            montoUsd = 0,
                            diferTipoCambio = 1,
                            tipoCambioTransacc = 1,
                            entregado = "SI",
                            idCajaUsuario = objCaja.idCajaUsuario,
                            usuarioModificacion = objCaja.usuarioModificacion,
                            documentoAfectado = 0,
                            documentoAfectadodetalle =0,
                            EstadoCobro = i.estadoPago,
                            fechaModificacion = DateTime.Now
                        });
                        i.estadoPago = i.estadoPago;
                    }
                }
            }
            return DetallePago;
        }

     

        public List<BE.documento> ListaPagosCajas(BE.documentoventaAbarrotes venta, List<BE.documentoventaAbarrotesDet> ventaDetalle, EnvioImpresionVendedorPernos envio, BE.documento Order)
        {
            BE.documento nDocumentoCaja = new BE.documento();
            BE.documentoCaja objCaja = new BE.documentoCaja();
            List<BE.documento> ListaDoc = new List<BE.documento>();

            foreach (var i in Order.ListaCustomDocumentoCaja)
            {
                if (i.montoSoles > 0)
                {
                    nDocumentoCaja = new BE.documento();
                    nDocumentoCaja.idDocumento = 0; // CInt(Me.Tag)
                    nDocumentoCaja.idEmpresa = Order.idEmpresa;
                    nDocumentoCaja.idCentroCosto = Order.idCentroCosto;
                    nDocumentoCaja.fechaProceso = DateTime.Now;
                    nDocumentoCaja.tipoDoc = "9903"; // cbotipoDocPago.SelectedValue
                    nDocumentoCaja.nroDoc = "0";                  
                    nDocumentoCaja.idOrden = null;
                    nDocumentoCaja.moneda = i.moneda;
                    nDocumentoCaja.idEntidad = Order.idEntidad;
                    nDocumentoCaja.entidad = Order.entidad ;
                    nDocumentoCaja.nrodocEntidad = Order.nrodocEntidad;            
                    nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE;
                    nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES;
                    nDocumentoCaja.usuarioActualizacion = venta.usuarioActualizacion; // usuario.IDUsuario
                    nDocumentoCaja.fechaActualizacion = DateTime.Now;


                    // DOCUMENTO CAJA
                    objCaja = new BE.documentoCaja();
                    objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES;
                    objCaja.idDocumento = 0;
                    objCaja.periodo = venta.fechaPeriodo;
                    objCaja.idEmpresa = venta.idEmpresa;
                    objCaja.idEstablecimiento = venta.idEstablecimiento;
                    objCaja.fechaProceso = DateTime.Now;
                    objCaja.fechaCobro = DateTime.Now;
                    objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO;              
                    objCaja.codigoProveedor =i.codigoProveedor;
                    objCaja.IdProveedor = i.IdProveedor;
                    objCaja.idPersonal = i.idPersonal;
              
                    objCaja.TipoDocumentoPago = "9903"; 
                    objCaja.codigoLibro = "1";
                    objCaja.tipoDocPago = venta.tipoDocumento;
                    objCaja.formapago = i.formapago;
                    objCaja.formaPagoName = i.formaPagoName;
                    objCaja.NumeroDocumento = "-";             
                    var numeroop = i.numeroOperacion;

                    if (numeroop != null)
                        objCaja.numeroOperacion = numeroop;
                    //if (i.GetValue("idforma") == "006" | i.GetValue("idforma") == "007")
                    //    objCaja.estadopago = 1;

                    switch (venta.tipoDocumento)
                    {
                        case "9907":
                            {
                                objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA;
                                break;
                            }

                        case "9903":
                            {
                                objCaja.movimientoCaja = TIPO_VENTA.PROFORMA;
                                break;
                            }

                        default:
                            {
                                objCaja.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA;
                                break;
                            }
                    }

                  
                    objCaja.montoSoles = i.montoSoles;
                    objCaja.moneda = i.moneda;
                    objCaja.tipoCambio = i.tipoCambio;
                    objCaja.montoUsd = 0;
                    objCaja.estado = "1";
                    objCaja.glosa = "Por ventas";
                    objCaja.entregado = "SI";
                    objCaja.idCajaUsuario = i.idCajaUsuario;// envio.IDCaja; // GFichaUsuarios.IdCajaUsuario
                    objCaja.entidadFinanciera = i.entidadFinanciera;
                    objCaja.NombreEntidad = i.NombreEntidad;
                    objCaja.usuarioModificacion = venta.usuarioActualizacion; // usuario.IDUsuario
                    objCaja.fechaModificacion = DateTime.Now;
                    nDocumentoCaja.documentoCaja = objCaja;
                    nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle);
                    // asientoDocumento(nDocumentoCaja.documentoCaja)
                    ListaDoc.Add(nDocumentoCaja);
                }
            }          

            return ListaDoc;
        }

        private void MappingPagos(EnvioImpresionVendedorPernos envio, BE.documento obj, BE.documento orden)
        {
            var ListaPagos = ListaPagosCajas(obj.documentoventaAbarrotes, obj.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList(), envio, orden);
            obj.ListaCustomDocumento = ListaPagos.ToList();

            decimal SumaPagos = 0;
            foreach (var i in ListaPagos)
                SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault();
            if (SumaPagos == obj.documentoventaAbarrotes.ImporteNacional)
            {
                obj.documentoventaAbarrotes.terminos = "CONTADO";
                obj.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO;
            }
            else
            {
                // ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                obj.documentoventaAbarrotes.terminos = "CREDITO";
                obj.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO;
            }
        }


        private void MappingDocumentoVentaCabeceraDetalle(BE.documento obj, BE.documentoventaAbarrotes order)
        {
            BE.documentoventaAbarrotesDet objDet;

            foreach (var i in order.documentoventaAbarrotesDet.ToList())
            {
                var cod = System.Guid.NewGuid().ToString();

                //switch (tmpConfigInicio.FormatoVenta)
                //{
                //    case "FACT":
                //        {
                            i.AfectoInventario = false;
                //            break;
                //        }
                //}


                switch (i.tipoExistencia)
                {
                    case TipoExistencia.ServicioGasto:
                        {
                            objDet = new BE.documentoventaAbarrotesDet()
                            {
                                AfectoInventario = i.AfectoInventario,
                                CodigoCosto = cod,
                                catalogo_id = 0,
                                CustomCatalogo = null,
                                CustomEquivalencia = null,
                                CustomProducto = null,
                                idItem = "1",
                                nombreItem = i.nombreItem,
                                tipoExistencia = i.tipoExistencia,
                                destino = i.destino,
                                unidad1 = i.unidad1,
                                monto1 = i.monto1,
                                equivalencia_id = 0,
                                unidad2 = null,
                                monto2 = i.monto2,
                                precioUnitario = i.precioUnitario.GetValueOrDefault(),
                                precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                                importeMN = i.importeMN,
                                importeME = i.importeME.GetValueOrDefault(),
                                montokardex = i.montokardex,
                                montoIsc = 0,
                                montoIgv = i.montoIgv,
                                otrosTributos = 0,
                                montokardexUS = i.montokardex.GetValueOrDefault(),
                                montoIscUS = 0,
                                montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                                otrosTributosUS = 0,
                                entregado = "1",
                                estadoPago = i.estadoPago,
                                bonificacion = i.bonificacion,
                                descuentoMN = i.descuentoMN.GetValueOrDefault(),
                                usuarioModificacion = obj.usuarioActualizacion,
                                fechaModificacion = DateTime.Now
                            };
                            break;
                        }

                    default:
                        {
                            objDet = new BE.documentoventaAbarrotesDet()
                            {
                                AfectoInventario = i.AfectoInventario,
                                CodigoCosto = cod,
                                catalogo_id = i.CustomCatalogo.idCatalogo,
                                CustomCatalogo = i.CustomCatalogo,
                                CustomEquivalencia = i.CustomEquivalencia,
                                CustomProducto = i.CustomProducto,
                                idItem = i.CustomProducto.codigodetalle.ToString(),
                                nombreItem = i.CustomProducto.descripcionItem,
                                tipoExistencia = i.CustomProducto.tipoExistencia,
                                destino = i.CustomProducto.origenProducto,
                                unidad1 = i.CustomProducto.unidad1,
                                monto1 = i.monto1,
                                equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                                unidad2 = null,
                                monto2 = i.monto2,
                                precioUnitario = i.precioUnitario.GetValueOrDefault(),
                                precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                                importeMN = i.importeMN,
                                importeME = i.importeME.GetValueOrDefault(),
                                montokardex = i.montokardex,
                                montoIsc = 0,
                                montoIgv = i.montoIgv,
                                otrosTributos = 0,
                                montokardexUS = i.montokardex.GetValueOrDefault(),
                                montoIscUS = 0,
                                montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                                otrosTributosUS = 0,
                                entregado = "1",
                                estadoPago = i.estadoPago,
                                bonificacion = i.bonificacion,
                                descuentoMN = i.descuentoMN.GetValueOrDefault(),
                                usuarioModificacion = obj.usuarioActualizacion,
                                fechaModificacion = DateTime.Now
                            };
                            break;
                        }
                }
                obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet);
            }
        }

        private void MappingDocumentoVentaDetalle(BE.documento obj, List<BE.documentoventaAbarrotesDet> order)
        {
            BE.documentoventaAbarrotesDet objDet;

            foreach (var i in order)
            {
                var cod = System.Guid.NewGuid().ToString();

                //switch (tmpConfigInicio.FormatoVenta)
                //{
                //    case "FACT":
                //        {
              //  i.AfectoInventario = false;
                //            break;
                //        }
                //}

                //switch (i.tipoExistencia)
                //{
                //    case TipoExistencia.ServicioGasto:
                //        {
                //            objDet = new BE.documentoventaAbarrotesDet()
                //            {
                //                AfectoInventario = i.AfectoInventario,
                //                CodigoCosto = cod,
                //                catalogo_id = 0,
                //                CustomCatalogo = null,
                //                CustomEquivalencia = null,
                //                CustomProducto = null,
                //                idItem = "1",
                //                nombreItem = i.nombreItem,
                //                tipoExistencia = i.tipoExistencia,
                //                destino = i.destino,
                //                unidad1 = i.unidad1,
                //                monto1 = i.monto1,
                //                equivalencia_id = 0,
                //                unidad2 = null,
                //                monto2 = i.monto2,
                //                precioUnitario = i.precioUnitario.GetValueOrDefault(),
                //                precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                //                importeMN = i.importeMN,
                //                importeME = i.importeME.GetValueOrDefault(),
                //                montokardex = i.montokardex,
                //                montoIsc = 0,
                //                montoIgv = i.montoIgv,
                //                otrosTributos = 0,
                //                montokardexUS = i.montokardex.GetValueOrDefault(),
                //                montoIscUS = 0,
                //                montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                //                otrosTributosUS = 0,
                //                entregado = "1",
                //                estadoPago = i.estadoPago,
                //                bonificacion = i.bonificacion,
                //                descuentoMN = i.descuentoMN.GetValueOrDefault(),
                //                usuarioModificacion = obj.usuarioActualizacion,
                //                fechaModificacion = DateTime.Now
                //            };
                //            break;
                //        }

                //    default:
                //        {


                var prod = Product.GetDetalleitems.Where(s => s.codigodetalle == int.Parse(i.idItem)).SingleOrDefault();
                var UNidadComercial = prod.detalleitem_equivalencias.Where(q => q.equivalencia_id == i.equivalencia_id).SingleOrDefault();
                var catalogo = UNidadComercial.detalleitemequivalencia_catalogos.Where(cat => cat.idCatalogo == i.catalogo_id).SingleOrDefault();
                i.CustomProducto = prod;
                i.CustomEquivalencia = UNidadComercial;
                i.CustomCatalogo = catalogo;

                var Tasaiva = (decimal)1.18;
                var montototal =(decimal)i.importeMN.GetValueOrDefault();

                decimal baseImponible = 0;
                decimal iva = 0;

                switch (i.CustomProducto.origenProducto)
                {
                    case "1":

                        baseImponible = CalculoBaseImponible(montototal, Tasaiva).GetValueOrDefault();
                        baseImponible = Math.Round(baseImponible, 2);
                        iva = montototal - baseImponible;
                        break;

                    case "2":

                        baseImponible = montototal;                        
                        iva = 0;
                        break;

                    default:
                        break;
                }

            

                                 objDet = new BE.documentoventaAbarrotesDet()
                                {
                                    AfectoInventario = i.AfectoInventario,
                                    CodigoCosto = cod,
                                    catalogo_id = i.CustomCatalogo.idCatalogo,
                                    CustomCatalogo = i.CustomCatalogo,
                                    CustomEquivalencia = i.CustomEquivalencia,
                                    CustomProducto = i.CustomProducto,
                                    idItem = i.CustomProducto.codigodetalle.ToString(),
                                    nombreItem = i.CustomProducto.descripcionItem,
                                    tipoExistencia = i.CustomProducto.tipoExistencia,
                                    destino = i.CustomProducto.origenProducto,
                                    unidad1 = i.CustomProducto.unidad1,
                                    monto1 = i.monto1,
                                    equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                                    unidad2 = null,
                                    monto2 = i.monto2,
                                    precioUnitario = i.precioUnitario.GetValueOrDefault(),
                                    precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                                    importeMN = i.importeMN,
                                    importeME = i.importeME.GetValueOrDefault(),
                                    montokardex = baseImponible,
                                    montoIsc = 0,
                                    montoIgv = iva,
                                    otrosTributos = 0,
                                    montokardexUS = 0,
                                    montoIscUS = 0,
                                    montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                                    otrosTributosUS = 0,
                                    entregado = "1",
                                    estadoPago = i.estadoPago,
                                    bonificacion = i.bonificacion,
                                    descuentoMN = i.descuentoMN.GetValueOrDefault(),
                                    usuarioModificacion = obj.usuarioActualizacion,
                                    fechaModificacion = DateTime.Now
                                };
                        //    break;
                        //}
               // }
                obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet);
            }
        }

        private void MappingDocumentoCompraCabecera(BE.documento be, BE.documentoventaAbarrotes order)
        {     
            BE.documentoventaAbarrotes obj = new BE.documentoventaAbarrotes()
            {
                codigoLibro = order.codigoLibro,
                idEmpresa = be.idEmpresa,
                idEstablecimiento = be.idCentroCosto,
                fechaLaboral = DateTime.Now,
                fechaDoc = be.fechaProceso,
                fechaVcto = null,
                fechaPeriodo = GetPeriodo(be.fechaProceso, true),
                tipoDocumento = be.tipoDoc,
                idCliente = be.idEntidad,
                nombrePedido = be.entidad,
                moneda = be.moneda,
                tasaIgv = order.tasaIgv,
                tipoCambio = order.tipoCambio,
                bi01 = order.bi01,
                bi02 = order.bi02,
                isc01 = 0,
                isc02 = 0,
                igv01 = order.igv01,
                igv02 = 0,
                otc01 = 0,
                otc02 = 0,
                bi01us = order.bi01us,
                bi02us = order.bi02us,
                isc01us = 0,
                isc02us = 0,
                igv01us = order.igv01us,
                igv02us = 0,
                otc01us = 0,
                otc02us = 0,
                importeCostoMN = 0,
                terminos = "CONTADO",
                ImporteNacional = order.ImporteNacional,
                ImporteExtranjero = order.ImporteExtranjero,
                tipoVenta = "VELC",
                estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                glosa = "Venta de mercadería",
                sustentado = "S",
                idPadre = order.idPadre,
                estadoEntrega = "1",
                usuarioActualizacion = be.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };

            be.documentoventaAbarrotes = obj;
            be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO;

          if (be.TipoEnvio == "VENTA")
            {

            }
            else if(be.TipoEnvio == "PREVENTA")
            {
                be.documentoventaAbarrotes.documentoventaAbarrotesDet = order.documentoventaAbarrotesDet.ToList();
            }
           
        }

        private BE.documento MappingDocumento(BE.documento order)
        {     
            var fechaVenta = DateTime.Now;
            var doc = order;
            doc.idEmpresa = LoginInformation.Empresa.idEmpresa;
            doc.idCentroCosto = LoginInformation.Establecimiento.idCentroCosto;
            doc.TipoEnvio = order.TipoEnvio;//"PREVENTA";
            doc.fechaProceso = fechaVenta;

            return doc;
        }

        private void GrabarVentaEquivalencia(BE.documento docOrden)
        {            
            var ListaVentas = docOrden.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList();
            //cajaUsuarioSA cajaUsuaroSA = new cajaUsuarioSA();
            EnvioImpresionVendedorPernos envio = null/* TODO Change to default(_) if this is not a reference type */;
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            BE.documento obj = new BE.documento();
            try
            {              
                obj = MappingDocumento(docOrden);
                MappingDocumentoCompraCabecera(obj, docOrden.documentoventaAbarrotes);
                if (obj.TipoEnvio == "VENTA")
                {
                    MappingDocumentoVentaDetalle(obj, ListaVentas);
                }

                switch (obj.tipoDoc)
                    {
                        case "03":
                        case "01":
                        case "9907":
                            {
                                MappingPagos(envio, obj, docOrden);
                                break;
                            }
                        case "9903":
                        case "1000":
                            {
                                break;
                            }
                    }
                 
                    var docImpresion = obj;               
                    var ListaPagos = obj.ListaCustomDocumento;
                    var doc = ventaSA.GrabarVentaEquivalencia(obj);
                    docImpresion.idDocumento = obj.idDocumento;
                    docImpresion.documentoventaAbarrotes.idDocumento = obj.idDocumento;
                    if (docOrden.tipoDoc == "01" | docOrden.tipoDoc == "03")
                    {
                        //if (My.Computer.Network.IsAvailable == true)
                        //{
                        //    if (My.Computer.Network.Ping("138.128.171.106"))
                        //    {
                        //        if (Gempresas.ubigeo > 0)
                        //        {
                        //            var documentoSave = ventaSA.GetVentaID(new documento() { idDocumento = doc.idDocumento });
                        //            documento documentoEnvio = new documento() { idDocumento = doc.idDocumento };
                        //            documentoEnvio.documentoventaAbarrotes = documentoSave;
                        //            documentoEnvio.ListaCustomDocumento = ListaPagos;
                        //            EnviarFacturaElectronica(documentoEnvio, Gempresas.ubigeo);

                        //            FormImpresionNuevo = new FormImpresionEquivalencia(documentoEnvio);  // frmVentaNuevoFormato
                        //            FormImpresionNuevo.tienda = "";
                        //            FormImpresionNuevo.FormaPago = "";
                        //            FormImpresionNuevo.DocumentoID = doc.idDocumento;
                        //            FormImpresionNuevo.Email = "";
                        //            FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen;

                        //            FormImpresionNuevo.ShowDialog(this);
                        //        }
                        //    }
                        //}
                        //else
                        //    MessageBox.Show("Envio a Respositorio!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (docOrden.tipoDoc == "NOTA")
                    {
                        //var documentoSave = ventaSA.GetVentaID(new documento() { idDocumento = doc.idDocumento });
                        //documento documentoEnvio = new documento() { idDocumento = doc.idDocumento };
                        //documentoEnvio.documentoventaAbarrotes = documentoSave;
                        //documentoEnvio.ListaCustomDocumento = ListaPagos;

                      
                    }
                
            }
            catch (Exception ex)
            {
                throw ex;
                //btOperacion.Enabled = true;
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención");
            }
        }


        #endregion

        //[HttpPost]
        //public JsonResult saveVentaDirecta(BE.documento order)
        //{

        //    GrabarVentaEquivalencia(order);       

        //    return new JsonResult { Data = new { status = true } };
        //}

        [HttpPost]
        public JsonResult saveVentaCaja(BE.documento order)
        {            
            
            //GrabarVentaEquivalencia(order);
            
            //calculosVenta(order);
            DocumentoOperation.SaveSale(order);

            return new JsonResult { Data = new { status = true } };
        }

        

        private void calculosVenta(BE.documentoventaAbarrotes order)
        {
            var total = order.documentoventaAbarrotesDet.Sum(s => s.importeMN).GetValueOrDefault();
            var BaseImponible = Math.Round((decimal)General.Constantes.CalculoBaseImponible(total, (decimal)1.18), 2);
            var Iva = total - BaseImponible;

            order.igv01 = Iva;
            order.bi01 = BaseImponible;
            order.ImporteNacional = total;
            order.ImporteExtranjero = 0;

        }

        public JsonResult GetCalculoPrecio(int idCatalogo, decimal? cant)
        {
            BE.detalleitemequivalencia_precios prec = new BE.detalleitemequivalencia_precios();
            var consulta = (from n in Product.GetDetalleitems
                            from uni in n.detalleitem_equivalencias
                            from cat in uni.detalleitemequivalencia_catalogos
                            where cat.idCatalogo.Equals(idCatalogo)
                            select cat).SingleOrDefault();

            var precioVenta = Product.GetCalculoPrecioVenta(cant.GetValueOrDefault(), consulta.codigodetalle, consulta.equivalencia_id, consulta.idCatalogo);

            prec.precio = precioVenta;

            return Json(prec, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult saveOrder(BE.documento order)
        {
            DocumentoOperation.SaveOrder(order);
          //  ImprimirPedido(order);

            //SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            //ventaSA.GrabarVentaEquivalenciaXInfra(order);
            //calculosVenta(order);
            //DocumentoOperation.SaveDocumentoVenta(order);

            return new JsonResult { Data = new { status = true } };
            // return Json(ListaProducts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult saveSale(BE.documento order)
        {
            DocumentoOperation.SaveSale(order);
            //  ImprimirPedido(order);

            //SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            //ventaSA.GrabarVentaEquivalenciaXInfra(order);
            //calculosVenta(order);
            //DocumentoOperation.SaveDocumentoVenta(order);

            return new JsonResult { Data = new { status = true } };
            // return Json(ListaProducts, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}