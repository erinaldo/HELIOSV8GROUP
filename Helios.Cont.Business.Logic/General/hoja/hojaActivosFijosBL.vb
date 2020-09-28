Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class hojaActivosFijosBL
    Inherits BaseBL

    Public Function Insert(ByVal hojaActivosFijosBE As hojaActivosFijos) As Integer
        Using ts As New TransactionScope
            HeliosData.hojaActivosFijos.Add(hojaActivosFijosBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return hojaActivosFijosBE.idInventario
        End Using
    End Function

    Public Sub Update(ByVal hojaActivosFijosBE As hojaActivosFijos)
        Using ts As New TransactionScope
            Dim hojaActivosFijos As hojaActivosFijos = HeliosData.hojaActivosFijos.Where(Function(o) _
                                            o.idInventario = hojaActivosFijosBE.idInventario).First()

            hojaActivosFijos.idEmpresa = hojaActivosFijosBE.idEmpresa
            hojaActivosFijos.idEstablecimiento = hojaActivosFijosBE.idEstablecimiento
            hojaActivosFijos.cuenta = hojaActivosFijosBE.cuenta
            hojaActivosFijos.fechaProceso = hojaActivosFijosBE.fechaProceso
            hojaActivosFijos.motivoIngreso = hojaActivosFijosBE.motivoIngreso
            hojaActivosFijos.cantidad = hojaActivosFijosBE.cantidad
            hojaActivosFijos.unidadMedida = hojaActivosFijosBE.unidadMedida
            hojaActivosFijos.tipoCambio = hojaActivosFijosBE.tipoCambio
            hojaActivosFijos.descripcionActivo = hojaActivosFijosBE.descripcionActivo
            hojaActivosFijos.tipoDoc = hojaActivosFijosBE.tipoDoc
            hojaActivosFijos.numeroDoc = hojaActivosFijosBE.numeroDoc
            hojaActivosFijos.tipoEntidad = hojaActivosFijosBE.tipoEntidad
            hojaActivosFijos.idEntidad = hojaActivosFijosBE.idEntidad
            hojaActivosFijos.nombreEntidad = hojaActivosFijosBE.nombreEntidad
            hojaActivosFijos.idActivo = hojaActivosFijosBE.idActivo
            hojaActivosFijos.marca = hojaActivosFijosBE.marca
            hojaActivosFijos.modelo = hojaActivosFijosBE.modelo
            hojaActivosFijos.numSerie = hojaActivosFijosBE.numSerie
            hojaActivosFijos.prUnitMN = hojaActivosFijosBE.prUnitMN
            hojaActivosFijos.prUnitME = hojaActivosFijosBE.prUnitME
            hojaActivosFijos.adquisionEjercicio = hojaActivosFijosBE.adquisionEjercicio
            hojaActivosFijos.idDocumentoCompra = hojaActivosFijosBE.idDocumentoCompra
            hojaActivosFijos.idDocRef = hojaActivosFijosBE.idDocRef
            hojaActivosFijos.montoRefMN = hojaActivosFijosBE.montoRefMN
            hojaActivosFijos.montoRefME = hojaActivosFijosBE.montoRefME
            hojaActivosFijos.totalMN = hojaActivosFijosBE.totalMN
            hojaActivosFijos.totalME = hojaActivosFijosBE.totalME
            hojaActivosFijos.relacionado = hojaActivosFijosBE.relacionado
            hojaActivosFijos.usuarioActualizacion = hojaActivosFijosBE.usuarioActualizacion
            hojaActivosFijos.fechaActualizacion = hojaActivosFijosBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(hojaActivosFijos).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal hojaActivosFijosBE As hojaActivosFijos)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(hojaActivosFijosBE)
    End Sub

    Public Function GetListar_hojaActivosFijos() As List(Of hojaActivosFijos)
        Return (From a In HeliosData.hojaActivosFijos Select a).ToList
    End Function

    Public Function GetUbicar_hojaActivosFijosPorID(idInventario As Integer) As hojaActivosFijos
        Return (From a In HeliosData.hojaActivosFijos
                 Where a.idInventario = idInventario Select a).First
    End Function
End Class
