Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class ModuloConfiguracionBL
    Inherits BaseBL

    Function ListaModulosConfigurados(moduloConfiguracionBE As moduloConfiguracion) As List(Of moduloConfiguracion)
        'Return (From n In HeliosData.moduloConfiguracion Where n.idEmpresa = moduloConfiguracionBE.idEmpresa And n.idEstablecimiento = moduloConfiguracionBE.idEstablecimiento).ToList
        Return (From n In HeliosData.moduloConfiguracion Select n).ToList
    End Function

    Function UbicarConfiguracionPorID(intIdConfig As Integer) As moduloConfiguracion
        Return (From n In HeliosData.moduloConfiguracion Where n.idConfiguracion = intIdConfig).First
    End Function

    Function UbicarConfiguracionPorEmpresaModulo(strIdModulo As String, strIdEmpresa As String, intIdEstablecimiento As Integer) As moduloConfiguracion
        Return (From n In HeliosData.moduloConfiguracion Where n.idModulo = strIdModulo And
                n.idEmpresa = strIdEmpresa And n.idEstablecimiento = intIdEstablecimiento).FirstOrDefault
    End Function

    Function TieneConfiguracionComprobante(strIdEmpresa As String, strIdModulo As String) As Boolean
        Dim consulta As Integer = HeliosData.moduloConfiguracion.Where(Function(o) o.idEmpresa = strIdEmpresa _
                                                                                          And o.idModulo = strIdModulo).Count

        If consulta > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function Grabar(objConfiguracion As moduloConfiguracion) As Integer
        Using ts As New TransactionScope
            Dim consulta As Integer = HeliosData.moduloConfiguracion.Where(Function(o) o.idEmpresa = objConfiguracion.idEmpresa _
                                                                                           And o.idModulo = objConfiguracion.idModulo).Count
            If Not consulta > 0 Then
                HeliosData.moduloConfiguracion.Add(objConfiguracion)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objConfiguracion.idConfiguracion
            Else
                Throw New Exception("La configuración para este módulo ya existe, ingrese otro!")
            End If
        End Using
    End Function

    Sub Update(objConfiguracion As moduloConfiguracion)
        Using ts As New TransactionScope
            Dim consulta = HeliosData.moduloConfiguracion.Where(Function(o) o.idConfiguracion = objConfiguracion.idConfiguracion).First
            With consulta
                .configAlmacen = objConfiguracion.configAlmacen
                .ConfigentidadFinanciera = objConfiguracion.ConfigentidadFinanciera
            End With
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Function Update2(objConfiguracion As moduloConfiguracion) As Integer
        Using ts As New TransactionScope
            Dim consulta As moduloConfiguracion = HeliosData.moduloConfiguracion.Where(Function(o) o.idEmpresa = objConfiguracion.idEmpresa _
                                                                                        And o.idModulo = objConfiguracion.idModulo).First
            With consulta
                .tipoConfiguracion = objConfiguracion.tipoConfiguracion
                .configComprobante = objConfiguracion.configComprobante
                If Not IsNothing(objConfiguracion.ConfigentidadFinanciera) Then
                    .ConfigentidadFinanciera = objConfiguracion.ConfigentidadFinanciera
                Else
                    .ConfigentidadFinanciera = Nothing
                End If
            End With
            HeliosData.SaveChanges()
            ts.Complete()
            Return consulta.idConfiguracion
        End Using
    End Function

    Sub Delete(objConfiguracion As moduloConfiguracion)
        Using ts As New TransactionScope
            Dim consulta = HeliosData.moduloConfiguracion.Where(Function(o) o.idConfiguracion = objConfiguracion.idConfiguracion).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Function InsertarModulo(idNumeracion As Integer, be As numeracionBoletas) As moduloConfiguracion
        Try
            Dim objModulo As New moduloConfiguracion
            Using ts As New TransactionScope
                'objModulo.idEmpresa = be.empresa
                'objModulo.idEstablecimiento = be.establecimiento
                objModulo.idModulo = be.codigoNumeracion
                objModulo.tipoConfiguracion = "P"
                objModulo.descripcionModulo = be.descripcionModulo
                objModulo.tipoDoc = be.tipo
                'objModulo.configComprobante = idNumeracion
                HeliosData.moduloConfiguracion.Add(objModulo)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objModulo
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
