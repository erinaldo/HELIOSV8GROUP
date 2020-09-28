Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class almacenPMBL
    Inherits BaseBL

    Public Sub Insert(ByVal almacenpmBE As almacenPM)
        Using ts As New TransactionScope
            HeliosData.almacenPM.Add(almacenpmBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Update(ByVal almacenpmBE As almacenPM)
        Using ts As New TransactionScope
            Dim almacen As almacenPM = HeliosData.almacenPM.Where(Function(o) _
                                            o.idAlmacenpm = almacenpmBE.idAlmacenpm).First()

            almacen.idEmpresa = almacenpmBE.idEmpresa
            almacen.idEstablecimiento = almacenpmBE.idEstablecimiento
            almacen.idAlmacen = almacenpmBE.idAlmacen
            almacen.fechaRegistro = almacenpmBE.fechaRegistro
            almacen.tipoCambio = almacenpmBE.tipoCambio
            almacen.idItem = almacenpmBE.idItem
            almacen.descripcion = almacenpmBE.descripcion
            almacen.importePMmn = almacenpmBE.importePMmn
            almacen.importePMme = almacenpmBE.importePMme
            almacen.usuarioActualizacion = almacenpmBE.usuarioActualizacion
            almacen.fechaActualizacion = almacenpmBE.fechaActualizacion
            'HeliosData.ObjectStateManager.GetObjectStateEntry(almacen).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


End Class
