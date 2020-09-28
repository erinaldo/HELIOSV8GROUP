Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoEntregaProductosBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoEntregaProductosBE As documentoEntregaProductos) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoEntregaProductos.Add(documentoEntregaProductosBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoEntregaProductosBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoEntregaProductosBE As documentoEntregaProductos)
        Using ts As New TransactionScope
            Dim docEntregaProd As documentoEntregaProductos = HeliosData.documentoEntregaProductos.Where(Function(o) _
                                            o.idDocumento = documentoEntregaProductosBE.idDocumento).First()

            docEntregaProd.idEmpresa = documentoEntregaProductosBE.idEmpresa
            docEntregaProd.idEstablecimiento = documentoEntregaProductosBE.idEstablecimiento
            docEntregaProd.origenVenta = documentoEntregaProductosBE.origenVenta
            docEntregaProd.codigoLibro = documentoEntregaProductosBE.codigoLibro
            docEntregaProd.fechaEntrega = documentoEntregaProductosBE.fechaEntrega
            docEntregaProd.serie = documentoEntregaProductosBE.serie
            docEntregaProd.numeroDoc = documentoEntregaProductosBE.numeroDoc
            docEntregaProd.tipoDocumento = documentoEntregaProductosBE.tipoDocumento
            docEntregaProd.ImporteMN = documentoEntregaProductosBE.ImporteMN
            docEntregaProd.ImporteME = documentoEntregaProductosBE.ImporteME
            docEntregaProd.documentoRef = documentoEntregaProductosBE.documentoRef
            docEntregaProd.usuarioActualizacion = documentoEntregaProductosBE.usuarioActualizacion
            docEntregaProd.fechaActualizacion = documentoEntregaProductosBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docEntregaProd).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoEntregaProductosBE As documentoEntregaProductos)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoEntregaProductosBE)
    End Sub

    Public Function GetListar_documentoEntregaProductos() As List(Of documentoEntregaProductos)
        Return (From a In HeliosData.documentoEntregaProductos Select a).ToList
    End Function

    Public Function GetUbicar_documentoEntregaProductosPorID(idDocumento As Integer) As documentoEntregaProductos
        Return (From a In HeliosData.documentoEntregaProductos
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
