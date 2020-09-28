Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class totalesAlmacenRPT
    Inherits BaseBL

    Public Function ObtenerProrAlmacenesPeriodoRPT(intIdAlmacen As Integer, strTipoEx As Integer, strBusqueda As String) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                Join prod In HeliosData.detalleitems _
                On a.idItem Equals prod.codigodetalle _
                 Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                   Join cat In HeliosData.item _
                   On cat.idItem Equals prod.idItem _
                Where a.idAlmacen = intIdAlmacen _
                And prod.tipoExistencia = strTipoEx _
                 And tbl.idtabla = 6 _
                 And a.descripcion.Contains(strBusqueda)).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.Clasificicacion = i.cat.descripcion
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

End Class
