Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class controlInversionesMoviliariasBL
    Inherits BaseBL

    Public Function Insert(ByVal controlInversionesMoviliariasBE As controlInversionesMoviliarias) As Integer
        Using ts As New TransactionScope
            HeliosData.controlInversionesMoviliarias.Add(controlInversionesMoviliariasBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return controlInversionesMoviliariasBE.idInventario
        End Using
    End Function

    Public Sub Update(ByVal controlInversionesMoviliariasBE As controlInversionesMoviliarias)
        Using ts As New TransactionScope
            Dim controlInvMoviliarias As controlInversionesMoviliarias = HeliosData.controlInversionesMoviliarias.Where(Function(o) _
                                            o.idInventario = controlInversionesMoviliariasBE.idInventario).First()

            controlInvMoviliarias.idEmpresa = controlInversionesMoviliariasBE.idEmpresa
            controlInvMoviliarias.idEstablecimiento = controlInversionesMoviliariasBE.idEstablecimiento
            controlInvMoviliarias.cuenta = controlInversionesMoviliariasBE.cuenta
            controlInvMoviliarias.motivoIngreso = controlInversionesMoviliariasBE.motivoIngreso
            controlInvMoviliarias.tipoOperacion = controlInversionesMoviliariasBE.tipoOperacion
            controlInvMoviliarias.codigoLibro = controlInversionesMoviliariasBE.codigoLibro
            controlInvMoviliarias.fechaProceso = controlInversionesMoviliariasBE.fechaProceso
            controlInvMoviliarias.tipoDoc = controlInversionesMoviliariasBE.tipoDoc
            controlInvMoviliarias.numeroDoc = controlInversionesMoviliariasBE.numeroDoc
            controlInvMoviliarias.glosa = controlInversionesMoviliariasBE.glosa
            controlInvMoviliarias.tipoCaja = controlInversionesMoviliariasBE.tipoCaja
            controlInvMoviliarias.idEntidadFinanciera = controlInversionesMoviliariasBE.idEntidadFinanciera
            controlInvMoviliarias.monedaCaja = controlInversionesMoviliariasBE.monedaCaja
            controlInvMoviliarias.idActivo = controlInversionesMoviliariasBE.idActivo
            controlInvMoviliarias.descripcionActivo = controlInversionesMoviliariasBE.descripcionActivo
            controlInvMoviliarias.idDocumentoCompra = controlInversionesMoviliariasBE.idDocumentoCompra
            controlInvMoviliarias.idDocRef = controlInversionesMoviliariasBE.idDocRef
            controlInvMoviliarias.totalMN = controlInversionesMoviliariasBE.totalMN
            controlInvMoviliarias.totalME = controlInversionesMoviliariasBE.totalME
            controlInvMoviliarias.relacionado = controlInversionesMoviliariasBE.relacionado
            controlInvMoviliarias.usuarioActualizacion = controlInversionesMoviliariasBE.usuarioActualizacion
            controlInvMoviliarias.fechaActualizacion = controlInversionesMoviliariasBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(controlInvMoviliarias).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal controlInversionesMoviliariasBE As controlInversionesMoviliarias)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(controlInversionesMoviliariasBE)
    End Sub

    Public Function GetListar_controlInversionesMoviliarias() As List(Of controlInversionesMoviliarias)
        Return (From a In HeliosData.controlInversionesMoviliarias Select a).ToList
    End Function

    Public Function GetUbicar_controlInversionesMoviliariasPorID(idInventario As Integer) As controlInversionesMoviliarias
        Return (From a In HeliosData.controlInversionesMoviliarias
                 Where a.idInventario = idInventario Select a).First
    End Function
End Class
