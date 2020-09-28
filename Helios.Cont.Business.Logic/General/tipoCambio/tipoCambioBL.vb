Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity.DbFunctions
Public Class tipoCambioBL
    Inherits BaseBL


    Public Function ObtenerCambioXFecha(idempresa As String, fecha As Date, intIdEstablecimiento As Integer) As tipoCambio
        Return HeliosData.tipoCambio.Where(Function(o) o.idEmpresa = idempresa And o.idCentroCosto = intIdEstablecimiento And o.fechaIgv = fecha).FirstOrDefault
    End Function

    Public Function InsertTipoCambio(ByVal tipoCambioBE As tipoCambio) As Integer
        Dim ConfiguracionInicioBL As New ConfiguracionInicioBL
        Using ts As New TransactionScope
            HeliosData.tipoCambio.Add(tipoCambioBE)


            ConfiguracionInicioBL.EditarTipoCambio(tipoCambioBE.venta)


            HeliosData.SaveChanges()
            ts.Complete()
            Return tipoCambioBE.idRegulador
        End Using
    End Function

    Public Function Insert(ByVal tipoCambioBE As tipoCambio) As Integer
        Try
            Using ts As New TransactionScope

                Dim consulta = (From n In HeliosData.tipoCambio
                                Where n.idEmpresa = tipoCambioBE.idEmpresa And n.idCentroCosto = tipoCambioBE.idCentroCosto And n.fechaIgv.Year = tipoCambioBE.fechaIgv.Year _
                               And n.fechaIgv.Month = tipoCambioBE.fechaIgv.Month _
                               And n.fechaIgv.Day = tipoCambioBE.fechaIgv.Day).Count

                If consulta > 0 Then
                    Throw New Exception("Esta fecha ya esta registrada, ingrese otro!")
                Else
                    HeliosData.tipoCambio.Add(tipoCambioBE)
                End If

                HeliosData.SaveChanges()
                ts.Complete()
                Return tipoCambioBE.idRegulador
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update(ByVal tipoCambioBE As tipoCambio)
        Using ts As New TransactionScope
            Dim tipoCamb As tipoCambio = HeliosData.tipoCambio.Where(Function(o) _
                                            o.fechaIgv = tipoCambioBE.fechaIgv _
                                            And o.idRegulador = tipoCambioBE.idRegulador).First()

            tipoCamb.compra = tipoCambioBE.compra
            tipoCamb.venta = tipoCambioBE.venta
            tipoCamb.usuarioModificacion = tipoCambioBE.usuarioModificacion
            tipoCamb.fechaModificacion = tipoCambioBE.fechaModificacion
             

            'HeliosData.ObjectStateManager.GetObjectStateEntry(tipoCamb).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeleteTC(ByVal tipoCambioBE As tipoCambio)
        Using ts As New TransactionScope
            Dim tipocambio As tipoCambio = HeliosData.tipoCambio.Where(Function(o) o.idEmpresa = tipoCambioBE.idEmpresa And o.idCentroCosto = tipoCambioBE.idCentroCosto And o.fechaIgv = tipoCambioBE.fechaIgv And
                                                                          o.idRegulador = tipoCambioBE.idRegulador).FirstOrDefault


            If Not IsNothing(tipocambio) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(tipocambio)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetListar_tipoCambio() As List(Of tipoCambio)
        Return (From a In HeliosData.tipoCambio Select a).ToList
    End Function

    Public Function GetListar_tipoCambioByPeriodo(idempresa As String, mes As Integer, anio As Integer, intIdEstablecimiento As Integer) As List(Of tipoCambio)
        Return (From a In HeliosData.tipoCambio
                Where a.idEmpresa = idempresa And a.idCentroCosto = intIdEstablecimiento And a.fechaIgv.Month = mes _
                And a.fechaIgv.Year = anio Select a).ToList
    End Function

    Public Function GetUbicar_tipoCambioPorID(idRegulador As Integer) As tipoCambio
        Return (From a In HeliosData.tipoCambio
                 Where a.idRegulador = idRegulador Select a).First
    End Function

    Public Function GetListaTipoCambioMaxFecha(idEmpresa As String, intIdEstablecimiento As Integer) As tipoCambio
        Dim tipoCambioBE As New tipoCambio

        Dim q = (From n In HeliosData.tipoCambio
                 Where (n.fechaIgv) = (From x In HeliosData.tipoCambio
                                       Where x.idEmpresa = idEmpresa And x.idCentroCosto = intIdEstablecimiento
                                       Select x.fechaIgv).Max()).FirstOrDefault


        If Not IsNothing(q) Then
            tipoCambioBE = New tipoCambio
            tipoCambioBE.fechaIgv = q.fechaIgv
            tipoCambioBE.compra = q.compra
            tipoCambioBE.venta = q.venta
        End If

        Return tipoCambioBE
    End Function

    Public Function GeTipoCambioXfecha(idEmpresa As String, fecha As Date, intIdEstablecimiento As Integer) As tipoCambio
        Dim tipoCambioBE As New tipoCambio

        Dim q = (From n In HeliosData.tipoCambio
                 Where n.idEmpresa = idEmpresa _
                     And n.idCentroCosto = intIdEstablecimiento _
                     And TruncateTime(n.fechaIgv) = fecha.Date).FirstOrDefault


        If Not IsNothing(q) Then
            tipoCambioBE = New tipoCambio
            tipoCambioBE.fechaIgv = q.fechaIgv
            tipoCambioBE.compra = q.compra
            tipoCambioBE.venta = q.venta
        End If

        Return tipoCambioBE
    End Function

End Class
