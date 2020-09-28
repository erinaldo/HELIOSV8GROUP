Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class mascaraGeneralExistenciaBL
    Inherits BaseBL

    Public Function Insert(ByVal mascaraGeneralExistenciaBE As mascaraGeneralExistencia) As Integer
        Using ts As New TransactionScope
            HeliosData.mascaraGeneralExistencia.Add(mascaraGeneralExistenciaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaraGeneralExistenciaBE.IDMascara
        End Using
    End Function

    Public Sub Update(ByVal mascaraGeneralExistenciaBE As mascaraGeneralExistencia)
        Using ts As New TransactionScope
            Dim masckGeneralExist As mascaraGeneralExistencia = HeliosData.mascaraGeneralExistencia.Where(Function(o) _
                                            o.IDMascara = mascaraGeneralExistenciaBE.IDMascara).First()

            masckGeneralExist.tipoExistencia = mascaraGeneralExistenciaBE.tipoExistencia
            masckGeneralExist.cuentaCompra = mascaraGeneralExistenciaBE.cuentaCompra
            masckGeneralExist.descripcionCompra = mascaraGeneralExistenciaBE.descripcionCompra
            masckGeneralExist.asientoCompra = mascaraGeneralExistenciaBE.asientoCompra
            masckGeneralExist.destinoCompra = mascaraGeneralExistenciaBE.destinoCompra
            masckGeneralExist.descripcionDestino = mascaraGeneralExistenciaBE.descripcionDestino
            masckGeneralExist.asientoDestino = mascaraGeneralExistenciaBE.asientoDestino
            masckGeneralExist.destinoCompra2 = mascaraGeneralExistenciaBE.destinoCompra2
            masckGeneralExist.descripcionDestino2 = mascaraGeneralExistenciaBE.descripcionDestino2
            masckGeneralExist.asientoDestino2 = mascaraGeneralExistenciaBE.asientoDestino2
            masckGeneralExist.cuentaIngAlmacen = mascaraGeneralExistenciaBE.cuentaIngAlmacen
            masckGeneralExist.nameIngAlmacen = mascaraGeneralExistenciaBE.nameIngAlmacen
            masckGeneralExist.asientoIngAlmacen = mascaraGeneralExistenciaBE.asientoIngAlmacen
            masckGeneralExist.cuentaIngAlmacen2 = mascaraGeneralExistenciaBE.cuentaIngAlmacen2
            masckGeneralExist.nameIngAlmacen2 = mascaraGeneralExistenciaBE.nameIngAlmacen2
            masckGeneralExist.asientoIngAlmacen2 = mascaraGeneralExistenciaBE.asientoIngAlmacen2
            masckGeneralExist.cuentaSalida = mascaraGeneralExistenciaBE.cuentaSalida
            masckGeneralExist.descripcionSalida = mascaraGeneralExistenciaBE.descripcionSalida
            masckGeneralExist.asientoSalida = mascaraGeneralExistenciaBE.asientoSalida
            masckGeneralExist.cuentaSalida2 = mascaraGeneralExistenciaBE.cuentaSalida2
            masckGeneralExist.descripcionSalida2 = mascaraGeneralExistenciaBE.descripcionSalida2
            masckGeneralExist.asientoSalida2 = mascaraGeneralExistenciaBE.asientoSalida2
            masckGeneralExist.cuentaDestinocosto = mascaraGeneralExistenciaBE.cuentaDestinocosto
            masckGeneralExist.descripcionDestinocosto = mascaraGeneralExistenciaBE.descripcionDestinocosto
            masckGeneralExist.asientoDestinocosto = mascaraGeneralExistenciaBE.asientoDestinocosto
            masckGeneralExist.cuentaDestinocosto2 = mascaraGeneralExistenciaBE.cuentaDestinocosto2
            masckGeneralExist.descripcionDestinocosto2 = mascaraGeneralExistenciaBE.descripcionDestinocosto2
            masckGeneralExist.asientoDestinocosto2 = mascaraGeneralExistenciaBE.asientoDestinocosto2
            masckGeneralExist.cuentaFinCosto = mascaraGeneralExistenciaBE.cuentaFinCosto
            masckGeneralExist.nameFinCosto = mascaraGeneralExistenciaBE.nameFinCosto
            masckGeneralExist.asientoFinCosto = mascaraGeneralExistenciaBE.asientoFinCosto
            masckGeneralExist.cuentaFinCosto2 = mascaraGeneralExistenciaBE.cuentaFinCosto2
            masckGeneralExist.nameFinCosto2 = mascaraGeneralExistenciaBE.nameFinCosto2
            masckGeneralExist.asientoFinCosto2 = mascaraGeneralExistenciaBE.asientoFinCosto2
            masckGeneralExist.cuentaProduccion = mascaraGeneralExistenciaBE.cuentaProduccion
            masckGeneralExist.nameProduccion = mascaraGeneralExistenciaBE.nameProduccion
            masckGeneralExist.asientoProduccion = mascaraGeneralExistenciaBE.asientoProduccion
            masckGeneralExist.cuentaProduccion2 = mascaraGeneralExistenciaBE.cuentaProduccion2
            masckGeneralExist.nameProduccion2 = mascaraGeneralExistenciaBE.nameProduccion2
            masckGeneralExist.asientoProduccion2 = mascaraGeneralExistenciaBE.asientoProduccion2

             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(masckGeneralExist).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mascaraGeneralExistenciaBE As mascaraGeneralExistencia)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mascaraGeneralExistenciaBE)
    End Sub

    Public Function GetListar_mascaraGeneralExistencia() As List(Of mascaraGeneralExistencia)
        Return (From a In HeliosData.mascaraGeneralExistencia Select a).ToList
    End Function

    Public Function GetUbicar_mascaraGeneralExistenciaPorID(IDMascara As Integer) As mascaraGeneralExistencia
        Return (From a In HeliosData.mascaraGeneralExistencia
                 Where a.IDMascara = IDMascara Select a).First
    End Function

    
End Class
