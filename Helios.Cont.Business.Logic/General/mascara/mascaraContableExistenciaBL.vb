Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class mascaraContableExistenciaBL
    Inherits BaseBL

    Public Function Insert(ByVal mascaraContableExistenciaBE As mascaraContableExistencia) As Integer
        Using ts As New TransactionScope
            HeliosData.mascaraContableExistencia.Add(mascaraContableExistenciaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaraContableExistenciaBE.idEmpresa
        End Using
    End Function

    Public Sub Update(ByVal mascaraContableExistenciaBE As mascaraContableExistencia)
        Using ts As New TransactionScope
            Dim maskContableExist As mascaraContableExistencia = HeliosData.mascaraContableExistencia.Where(Function(o) _
                                            o.idEmpresa = mascaraContableExistenciaBE.idEmpresa _
                                            And o.tipoExistencia = mascaraContableExistenciaBE.tipoExistencia _
                                            And o.cuentaCompra = mascaraContableExistenciaBE.cuentaCompra).First()

            maskContableExist.descripcionCompra = mascaraContableExistenciaBE.descripcionCompra
            maskContableExist.asientoCompra = mascaraContableExistenciaBE.asientoCompra
            maskContableExist.destinoCompra = mascaraContableExistenciaBE.destinoCompra
            maskContableExist.descripcionDestino = mascaraContableExistenciaBE.descripcionDestino
            maskContableExist.asientoDestino = mascaraContableExistenciaBE.asientoDestino
            maskContableExist.destinoCompra2 = mascaraContableExistenciaBE.destinoCompra2
            maskContableExist.descripcionDestino2 = mascaraContableExistenciaBE.descripcionDestino2
            maskContableExist.asientoDestino2 = mascaraContableExistenciaBE.asientoDestino2
            maskContableExist.cuentaIngAlmacen = mascaraContableExistenciaBE.cuentaIngAlmacen
            maskContableExist.nameIngAlmacen = mascaraContableExistenciaBE.nameIngAlmacen
            maskContableExist.asientoIngAlmacen = mascaraContableExistenciaBE.asientoIngAlmacen
            maskContableExist.cuentaIngAlmacen2 = mascaraContableExistenciaBE.cuentaIngAlmacen2
            maskContableExist.nameIngAlmacen2 = mascaraContableExistenciaBE.nameIngAlmacen2
            maskContableExist.asientoIngAlmacen2 = mascaraContableExistenciaBE.asientoIngAlmacen2
            maskContableExist.cuentaSalida = mascaraContableExistenciaBE.cuentaSalida
            maskContableExist.descripcionSalida = mascaraContableExistenciaBE.descripcionSalida
            maskContableExist.asientoSalida = mascaraContableExistenciaBE.asientoSalida
            maskContableExist.cuentaSalida2 = mascaraContableExistenciaBE.cuentaSalida2
            maskContableExist.descripcionSalida2 = mascaraContableExistenciaBE.descripcionSalida2
            maskContableExist.asientoSalida2 = mascaraContableExistenciaBE.asientoSalida2
            maskContableExist.cuentaDestinocosto = mascaraContableExistenciaBE.cuentaDestinocosto
            maskContableExist.descripcionDestinocosto = mascaraContableExistenciaBE.descripcionDestinocosto
            maskContableExist.asientoDestinocosto = mascaraContableExistenciaBE.asientoDestinocosto
            maskContableExist.cuentaDestinocosto2 = mascaraContableExistenciaBE.cuentaDestinocosto2
            maskContableExist.descripcionDestinocosto2 = mascaraContableExistenciaBE.descripcionDestinocosto2
            maskContableExist.asientoDestinocosto2 = mascaraContableExistenciaBE.asientoDestinocosto2
            maskContableExist.cuentaFinCosto = mascaraContableExistenciaBE.cuentaFinCosto
            maskContableExist.nameFinCosto = mascaraContableExistenciaBE.nameFinCosto
            maskContableExist.asientoFinCosto = mascaraContableExistenciaBE.asientoFinCosto
            maskContableExist.cuentaFinCosto2 = mascaraContableExistenciaBE.cuentaFinCosto2
            maskContableExist.nameFinCosto2 = mascaraContableExistenciaBE.nameFinCosto2
            maskContableExist.asientoFinCosto2 = mascaraContableExistenciaBE.asientoFinCosto2
            maskContableExist.cuentaProduccion = mascaraContableExistenciaBE.cuentaProduccion
            maskContableExist.nameProduccion = mascaraContableExistenciaBE.nameProduccion
            maskContableExist.asientoProduccion = mascaraContableExistenciaBE.asientoProduccion
            maskContableExist.cuentaProduccion2 = mascaraContableExistenciaBE.cuentaProduccion2
            maskContableExist.nameProduccion2 = mascaraContableExistenciaBE.nameProduccion2
            maskContableExist.asientoProduccion2 = mascaraContableExistenciaBE.asientoProduccion2

            'HeliosData.ObjectStateManager.GetObjectStateEntry(maskContableExist).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mascaraContableExistenciaBE As mascaraContableExistencia)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mascaraContableExistenciaBE)
    End Sub

    Public Function GetListar_mascaraContableExistencia() As List(Of mascaraContableExistencia)
        Return (From a In HeliosData.mascaraContableExistencia Select a).ToList

    End Function

    Public Function ObtenerMascaraExistencias(ByVal strIdEmpresa As String, ByVal strTipoExistencia As String) As List(Of mascaraContableExistencia)
        Return (From n In HeliosData.mascaraContableExistencia _
                          Where n.idEmpresa = strIdEmpresa And n.tipoExistencia = strTipoExistencia _
                          Order By n.asientoCompra _
                          Select n).ToList

    End Function

    Public Function GetUbicar_mascaraContableExistenciaPorID(idEmpresa As String) As mascaraContableExistencia
        Return (From a In HeliosData.mascaraContableExistencia
                 Where a.idEmpresa = idEmpresa Select a).First
    End Function

    Public Function GetUbicar_mascaraContableExistenciaPorEmpresaCF(idEmpresa As String, strCuenta As String, strTipoEx As String) As mascaraContableExistencia
        Return (From a In HeliosData.mascaraContableExistencia
                 Where a.idEmpresa = idEmpresa And a.cuentaCompra = strCuenta _
                 And a.tipoExistencia = strTipoEx).First
    End Function

    Public Function InsertMascaraContableExistenciaSingle(ByVal mascaraContableExistenciaBE As mascaraContableExistencia) As String
        Dim maskContableExist As New mascaraContableExistencia
        Using ts As New TransactionScope

            maskContableExist = New mascaraContableExistencia

            maskContableExist.idEmpresa = maskContableExist.idEmpresa
            maskContableExist.tipoExistencia = maskContableExist.tipoExistencia
            maskContableExist.cuentaCompra = maskContableExist.cuentaCompra
            maskContableExist.descripcionCompra = mascaraContableExistenciaBE.descripcionCompra
            maskContableExist.asientoCompra = mascaraContableExistenciaBE.asientoCompra

            maskContableExist.destinoCompra = mascaraContableExistenciaBE.destinoCompra
            maskContableExist.descripcionDestino = mascaraContableExistenciaBE.descripcionDestino
            maskContableExist.asientoDestino = mascaraContableExistenciaBE.asientoDestino

            maskContableExist.destinoCompra2 = mascaraContableExistenciaBE.destinoCompra2
            maskContableExist.descripcionDestino2 = mascaraContableExistenciaBE.descripcionDestino2
            maskContableExist.asientoDestino2 = mascaraContableExistenciaBE.asientoDestino2

            maskContableExist.cuentaIngAlmacen = mascaraContableExistenciaBE.cuentaIngAlmacen
            maskContableExist.nameIngAlmacen = mascaraContableExistenciaBE.nameIngAlmacen
            maskContableExist.asientoIngAlmacen = mascaraContableExistenciaBE.asientoIngAlmacen

            maskContableExist.cuentaSalida = mascaraContableExistenciaBE.cuentaSalida
            maskContableExist.descripcionSalida = mascaraContableExistenciaBE.descripcionSalida
            maskContableExist.asientoSalida = mascaraContableExistenciaBE.asientoSalida

            HeliosData.mascaraContableExistencia.Add(mascaraContableExistenciaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaraContableExistenciaBE.cuentaCompra
        End Using
    End Function

    Public Function UpdateMascaraContableExistenciaSingle(ByVal mascaraContableExistenciaBE As mascaraContableExistencia) As String
        Using ts As New TransactionScope
            Dim maskContableExist As mascaraContableExistencia = HeliosData.mascaraContableExistencia.Where(Function(o) _
                                            o.idEmpresa = mascaraContableExistenciaBE.idEmpresa _
                                            And o.tipoExistencia = mascaraContableExistenciaBE.tipoExistencia _
                                            And o.cuentaCompra = mascaraContableExistenciaBE.cuentaCompra).First()

            maskContableExist.cuentaCompra = mascaraContableExistenciaBE.cuentaCompra
            maskContableExist.descripcionCompra = mascaraContableExistenciaBE.descripcionCompra

            maskContableExist.destinoCompra = mascaraContableExistenciaBE.destinoCompra
            maskContableExist.descripcionDestino = mascaraContableExistenciaBE.descripcionDestino
            maskContableExist.destinoCompra2 = mascaraContableExistenciaBE.destinoCompra2
            maskContableExist.descripcionDestino2 = mascaraContableExistenciaBE.descripcionDestino2

            maskContableExist.cuentaIngAlmacen = mascaraContableExistenciaBE.cuentaIngAlmacen
            maskContableExist.nameIngAlmacen = mascaraContableExistenciaBE.nameIngAlmacen
            maskContableExist.cuentaSalida = mascaraContableExistenciaBE.cuentaSalida
            maskContableExist.descripcionSalida = mascaraContableExistenciaBE.descripcionSalida

            'HeliosData.ObjectStateManager.GetObjectStateEntry(maskContableExist).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
            Return maskContableExist.cuentaCompra
        End Using

    End Function

End Class
