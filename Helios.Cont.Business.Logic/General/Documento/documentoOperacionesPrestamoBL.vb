Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoOperacionesPrestamoBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoOperacionesPrestamoBE As documentoOperacionesPrestamo) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoOperacionesPrestamo.Add(documentoOperacionesPrestamoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoOperacionesPrestamoBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoOperacionesPrestamoBE As documentoOperacionesPrestamo)
        Using ts As New TransactionScope
            Dim docOperacionesPrestamo As documentoOperacionesPrestamo = HeliosData.documentoOperacionesPrestamo.Where(Function(o) _
                                            o.idDocumento = documentoOperacionesPrestamoBE.idDocumento).First()

            docOperacionesPrestamo.idEmpresa = documentoOperacionesPrestamoBE.idEmpresa
            docOperacionesPrestamo.idEstablecimiento = documentoOperacionesPrestamoBE.idEstablecimiento
            docOperacionesPrestamo.cuentaContable = documentoOperacionesPrestamoBE.cuentaContable
            docOperacionesPrestamo.idBeneficiario = documentoOperacionesPrestamoBE.idBeneficiario
            docOperacionesPrestamo.tipoBeneficiario = documentoOperacionesPrestamoBE.tipoBeneficiario
            docOperacionesPrestamo.tipoMovimiento = documentoOperacionesPrestamoBE.tipoMovimiento
            docOperacionesPrestamo.tipoDocumento = documentoOperacionesPrestamoBE.tipoDocumento
            docOperacionesPrestamo.numeroDocumento = documentoOperacionesPrestamoBE.numeroDocumento
            docOperacionesPrestamo.fechaOperacion = documentoOperacionesPrestamoBE.fechaOperacion
            docOperacionesPrestamo.fechaCobro = documentoOperacionesPrestamoBE.fechaCobro
            docOperacionesPrestamo.glosa = documentoOperacionesPrestamoBE.glosa
            docOperacionesPrestamo.entidadFinanciera = documentoOperacionesPrestamoBE.entidadFinanciera
            docOperacionesPrestamo.numeroOperacion = documentoOperacionesPrestamoBE.numeroOperacion
            docOperacionesPrestamo.moneda = documentoOperacionesPrestamoBE.moneda
            docOperacionesPrestamo.tipoCambio = documentoOperacionesPrestamoBE.tipoCambio
            docOperacionesPrestamo.montoSoles = documentoOperacionesPrestamoBE.montoSoles
            docOperacionesPrestamo.montoDolares = documentoOperacionesPrestamoBE.montoDolares
            docOperacionesPrestamo.montoInteresSoles = documentoOperacionesPrestamoBE.montoInteresSoles
            docOperacionesPrestamo.montoInteresUSD = documentoOperacionesPrestamoBE.montoInteresUSD
            docOperacionesPrestamo.montoITFSoles = documentoOperacionesPrestamoBE.montoITFSoles
            docOperacionesPrestamo.montoITFUSD = documentoOperacionesPrestamoBE.montoITFUSD
            docOperacionesPrestamo.entregado = documentoOperacionesPrestamoBE.entregado
            docOperacionesPrestamo.usuarioActualizacion = documentoOperacionesPrestamoBE.usuarioActualizacion
            docOperacionesPrestamo.fechaActualizacion = documentoOperacionesPrestamoBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(docOperacionesPrestamo).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoOperacionesPrestamoBE As documentoOperacionesPrestamo)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoOperacionesPrestamoBE)
    End Sub

    Public Function GetListar_documentoOperacionesPrestamo() As List(Of documentoOperacionesPrestamo)
        Return (From a In HeliosData.documentoOperacionesPrestamo Select a).ToList
    End Function

    Public Function GetUbicar_documentoOperacionesPrestamoPorID(idDocumento As Integer) As documentoOperacionesPrestamo
        Return (From a In HeliosData.documentoOperacionesPrestamo
                 Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
