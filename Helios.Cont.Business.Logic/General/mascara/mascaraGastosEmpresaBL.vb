Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class mascaraGastosEmpresaBL
    Inherits BaseBL

    Public Function Insert(ByVal mascaraGastosEmpresaBE As mascaraGastosEmpresa) As Integer
        Using ts As New TransactionScope
            HeliosData.mascaraGastosEmpresa.Add(mascaraGastosEmpresaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaraGastosEmpresaBE.idEmpresa
        End Using
    End Function

    Public Sub Update(ByVal mascaraGastosEmpresaBE As mascaraGastosEmpresa)
        Using ts As New TransactionScope
            Dim maskGastosEmp As mascaraGastosEmpresa = HeliosData.mascaraGastosEmpresa.Where(Function(o) _
                                            o.idEmpresa = mascaraGastosEmpresaBE.idEmpresa _
                                            And o.cuentaCompra = mascaraGastosEmpresaBE.cuentaCompra).First()

            maskGastosEmp.descripcionCompra = mascaraGastosEmpresaBE.descripcionCompra
            maskGastosEmp.cuentaCostoProcesoDebe = mascaraGastosEmpresaBE.cuentaCostoProcesoDebe
            maskGastosEmp.descripcionCostoProcesoDebe = mascaraGastosEmpresaBE.descripcionCostoProcesoDebe
            maskGastosEmp.cuentaCostoProcesoHaber = mascaraGastosEmpresaBE.cuentaCostoProcesoHaber
            maskGastosEmp.descripcionCostoProcesoHaber = mascaraGastosEmpresaBE.descripcionCostoProcesoHaber
            maskGastosEmp.cuentaConclusionProcesoDebe = mascaraGastosEmpresaBE.cuentaConclusionProcesoDebe
            maskGastosEmp.descripcionConclusionDebe = mascaraGastosEmpresaBE.descripcionConclusionDebe
            maskGastosEmp.cuentaConclusionProcesoHaber = mascaraGastosEmpresaBE.cuentaConclusionProcesoHaber
            maskGastosEmp.descripcionConclusionHaber = mascaraGastosEmpresaBE.descripcionConclusionHaber
            maskGastosEmp.cuentaDestinoDebe = mascaraGastosEmpresaBE.cuentaDestinoDebe
            maskGastosEmp.descripcionDestinoDebe = mascaraGastosEmpresaBE.descripcionDestinoDebe
            maskGastosEmp.cuentaDestinoHaber = mascaraGastosEmpresaBE.cuentaDestinoHaber
            maskGastosEmp.descripcionDestinoHaber = mascaraGastosEmpresaBE.descripcionDestinoHaber
            maskGastosEmp.usuarioActualizacion = mascaraGastosEmpresaBE.usuarioActualizacion
            maskGastosEmp.fechaActualizacion = mascaraGastosEmpresaBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(maskGastosEmp).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mascaraGastosEmpresaBE As mascaraGastosEmpresa)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mascaraGastosEmpresaBE)
    End Sub

    Public Function GetListar_mascaraGastosEmpresa() As List(Of mascaraGastosEmpresa)
        Return (From a In HeliosData.mascaraGastosEmpresa Select a).ToList
    End Function

    Public Function GetUbicar_mascaraGastosEmpresaPorID(idEmpresa As String) As mascaraGastosEmpresa
        Return (From a In HeliosData.mascaraGastosEmpresa
                 Where a.idEmpresa = idEmpresa Select a).First
    End Function

    Public Function ObtenerMascaraGastos(ByVal strIdEmpresa As String, ByVal strCuentaPadre As String) As List(Of mascaraGastosEmpresa)
        Dim objTablaDetalleBO As New mascaraGastosEmpresa
        Dim LIstaGasto As New List(Of mascaraGastosEmpresa)
        Try
            Dim consulta = (From i In HeliosData.mascaraGastosEmpresa _
                            Where i.idEmpresa = strIdEmpresa _
                            And i.cuentaCompra.StartsWith(strCuentaPadre) _
                             Select New With {.CuentaCompra = i.cuentaCompra,
                                            .Descripcion = i.descripcionCompra}
                            ).Distinct

            For Each obj In consulta
                objTablaDetalleBO = New mascaraGastosEmpresa With _
                                            {.cuentaCompra = IIf(IsDBNull(obj.CuentaCompra), Nothing, obj.CuentaCompra), _
                                             .descripcionCompra = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion) _
                                             }
                LIstaGasto.Add(objTablaDetalleBO)
            Next

            Return LIstaGasto.ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarCuentasServiciosPublicos(ByVal strIdEmpresa As String) As List(Of mascaraGastosEmpresa)
        Dim objTablaDetalleBO As New mascaraGastosEmpresa
        Dim LIstaGasto As New List(Of mascaraGastosEmpresa)
        Dim ListaCuentasHabilitadas As New List(Of String)
        Try
            ListaCuentasHabilitadas.Add("636")
            ListaCuentasHabilitadas.Add("6361")
            ListaCuentasHabilitadas.Add("6362")
            ListaCuentasHabilitadas.Add("6363")
            ListaCuentasHabilitadas.Add("6364")
            ListaCuentasHabilitadas.Add("6365")
            ListaCuentasHabilitadas.Add("6366")
            ListaCuentasHabilitadas.Add("6367")

            Dim consulta = (From i In HeliosData.mascaraGastosEmpresa _
                            Where i.idEmpresa = strIdEmpresa _
                            And ListaCuentasHabilitadas.Contains(i.cuentaCompra) _
                             Select New With {.CuentaCompra = i.cuentaCompra,
                                            .Descripcion = i.descripcionCompra}
                            ).Distinct

            For Each obj In consulta
                objTablaDetalleBO = New mascaraGastosEmpresa With _
                                            {.cuentaCompra = IIf(IsDBNull(obj.CuentaCompra), Nothing, obj.CuentaCompra), _
                                             .descripcionCompra = IIf(IsDBNull(obj.Descripcion), Nothing, obj.Descripcion) _
                                             }
                LIstaGasto.Add(objTablaDetalleBO)
            Next

            Return LIstaGasto.ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
