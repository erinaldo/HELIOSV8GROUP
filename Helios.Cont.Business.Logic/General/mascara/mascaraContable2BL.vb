Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class mascaraContable2BL
    Inherits BaseBL

    Public Function Insert(ByVal mascaraContable2BE As mascaraContable2) As Integer
        Using ts As New TransactionScope
            HeliosData.mascaraContable2.Add(mascaraContable2BE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaraContable2BE.cuentaCompra
        End Using
    End Function

    Public Sub Update(ByVal mascaraContable2BE As mascaraContable2)
        Using ts As New TransactionScope
            Dim maskContable2 As mascaraContable2 = HeliosData.mascaraContable2.Where(Function(o) _
                                            o.idEmpresa = mascaraContable2BE.idEmpresa _
                                            And o.cuentaCompra = mascaraContable2BE.cuentaCompra).First()

            maskContable2.tipoExistencia = mascaraContable2BE.tipoExistencia
            maskContable2.descripcionCompra = mascaraContable2BE.descripcionCompra
            maskContable2.asientoCompra = mascaraContable2BE.asientoCompra
            maskContable2.destinoCompra = mascaraContable2BE.destinoCompra
            maskContable2.descripcionDestino = mascaraContable2BE.descripcionDestino
            maskContable2.asientoDestino = mascaraContable2BE.asientoDestino
            maskContable2.destinoCompra2 = mascaraContable2BE.destinoCompra2
            maskContable2.descripcionDestino2 = mascaraContable2BE.descripcionDestino2
            maskContable2.asientoDestino2 = mascaraContable2BE.asientoDestino2
            maskContable2.cuentaDestinoKardex = mascaraContable2BE.cuentaDestinoKardex
            maskContable2.nameDestinoKardex = mascaraContable2BE.nameDestinoKardex
            maskContable2.asientoDestinoKardex = mascaraContable2BE.asientoDestinoKardex
            maskContable2.cuentaDestinoKardex2 = mascaraContable2BE.cuentaDestinoKardex2
            maskContable2.nameDestinoKardex2 = mascaraContable2BE.nameDestinoKardex2
            maskContable2.asientoDestinoKardex2 = mascaraContable2BE.asientoDestinoKardex2
            maskContable2.cuentaVenta = mascaraContable2BE.cuentaVenta
            maskContable2.descripcionVenta = mascaraContable2BE.descripcionVenta
            maskContable2.asientoVenta = mascaraContable2BE.asientoVenta
            maskContable2.cuentaKardex = mascaraContable2BE.cuentaKardex
            maskContable2.descripcionKardex = mascaraContable2BE.descripcionKardex
            maskContable2.asientoKardex = mascaraContable2BE.asientoKardex
            maskContable2.cuentaKardex2 = mascaraContable2BE.cuentaKardex2
            maskContable2.descripcionKardex2 = mascaraContable2BE.descripcionKardex2
            maskContable2.asientoKardex2 = mascaraContable2BE.asientoKardex2

            'HeliosData.ObjectStateManager.GetObjectStateEntry(maskContable2).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mascaraContable2BE As mascaraContable2)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mascaraContable2BE)
    End Sub

    Public Function GetListar_mascaraContable2() As List(Of mascaraContable2)
        Return (From a In HeliosData.mascaraContable2 Select a).ToList
    End Function

    Public Function GetUbicar_mascaraContable2PorID(cuentaCompra As String) As mascaraContable2
        Return (From a In HeliosData.mascaraContable2
                 Where a.cuentaCompra = cuentaCompra Select a).First
    End Function

    Public Function GetUbicar_mascaraContable2PorEmpresa(strEmpresa As String, strCuenta As String) As mascaraContable2
        Return (From a In HeliosData.mascaraContable2
                 Where a.idEmpresa = strEmpresa _
                 And a.cuentaCompra = strCuenta).First
    End Function

    Public Function ObtenerMascaraContableMercaderia(strEmpresa As String, InitCuenta As String) As IList(Of mascaraContable2)
        Return (From a In HeliosData.mascaraContable2
                 Where a.idEmpresa = strEmpresa _
                 And a.cuentaCompra.StartsWith(InitCuenta) Select a).ToList
    End Function

    Public Function ObtenerMascaraContable2PorEmpresa(strEmpresa As String) As IList(Of mascaraContable2)
        Dim lista4 As New List(Of mascaraContable2)
        Dim objMostrarEncaja As mascaraContable2
        Dim idDocumento As Integer = 0
        Dim m = (From t In HeliosData.mascaraContable2 Select t _
                 Where t.idEmpresa = strEmpresa).ToList

        For Each mascara In m
            Dim conteo As Integer = 3
            objMostrarEncaja = New mascaraContable2()
            objMostrarEncaja.idEmpresa = mascara.idEmpresa
            objMostrarEncaja.tipoExistencia = mascara.tipoExistencia
            objMostrarEncaja.cuentaCompra = mascara.cuentaCompra
            objMostrarEncaja.cuentraCompraFil = mascara.cuentaCompra

            objMostrarEncaja.CuentaAlmacenContado = mascara.cuentaDestinoKardex
            objMostrarEncaja.DescripciónAlmacenContado = mascara.nameDestinoKardex

            objMostrarEncaja.CuentaAlmacen = mascara.destinoCompra
            objMostrarEncaja.DescripciónAlmacen = mascara.descripcionDestino

            objMostrarEncaja.CuentaAlmacenFisico = mascara.cuentaDestinoKardex
            objMostrarEncaja.descripcionAlmacenFisico = mascara.nameDestinoKardex

            lista4.Add(objMostrarEncaja)

            For value As Integer = 1 To 1
                If (value = 1) Then
                    objMostrarEncaja = New mascaraContable2()
                    objMostrarEncaja.idEmpresa = mascara.idEmpresa
                    objMostrarEncaja.tipoExistencia = mascara.tipoExistencia
                    objMostrarEncaja.cuentraCompraFil = mascara.cuentaCompra

                    objMostrarEncaja.CuentaAlmacenContado = mascara.destinoCompra2
                    objMostrarEncaja.DescripciónAlmacenContado = mascara.descripcionDestino2

                    objMostrarEncaja.CuentaAlmacen = mascara.destinoCompra2
                    objMostrarEncaja.DescripciónAlmacen = mascara.descripcionDestino2

                    objMostrarEncaja.CuentaAlmacenFisico = mascara.destinoCompra
                    objMostrarEncaja.descripcionAlmacenFisico = mascara.descripcionDestino
                    lista4.Add(objMostrarEncaja)

                End If
            Next
        Next

        Dim m2 = (From t In HeliosData.mascaraContableExistencia Select t _
               Where t.idEmpresa = strEmpresa).ToList

        For Each mascaraContable In m2
            Dim conteo As Integer = 1
            objMostrarEncaja = New mascaraContable2()
            objMostrarEncaja.idEmpresa = mascaraContable.idEmpresa
            objMostrarEncaja.tipoExistencia = mascaraContable.tipoExistencia
            objMostrarEncaja.cuentaCompra = mascaraContable.cuentaCompra
            objMostrarEncaja.cuentraCompraFil = mascaraContable.cuentaCompra

            objMostrarEncaja.CuentaAlmacenContado = mascaraContable.cuentaIngAlmacen
            objMostrarEncaja.DescripciónAlmacenContado = mascaraContable.nameIngAlmacen

            objMostrarEncaja.CuentaAlmacen = mascaraContable.destinoCompra
            objMostrarEncaja.DescripciónAlmacen = mascaraContable.descripcionDestino

            objMostrarEncaja.CuentaAlmacenFisico = mascaraContable.cuentaIngAlmacen
            objMostrarEncaja.descripcionAlmacenFisico = mascaraContable.nameIngAlmacen

            lista4.Add(objMostrarEncaja)

            For value As Integer = 1 To 1
                If (value = 1) Then
                    objMostrarEncaja = New mascaraContable2()
                    objMostrarEncaja.idEmpresa = mascaraContable.idEmpresa
                    objMostrarEncaja.tipoExistencia = mascaraContable.tipoExistencia
                    objMostrarEncaja.cuentraCompraFil = mascaraContable.cuentaCompra

                    objMostrarEncaja.CuentaAlmacenContado = mascaraContable.cuentaSalida
                    objMostrarEncaja.DescripciónAlmacenContado = mascaraContable.descripcionSalida

                    objMostrarEncaja.CuentaAlmacen = mascaraContable.destinoCompra2
                    objMostrarEncaja.DescripciónAlmacen = mascaraContable.descripcionDestino2

                    objMostrarEncaja.CuentaAlmacenFisico = mascaraContable.destinoCompra
                    objMostrarEncaja.descripcionAlmacenFisico = mascaraContable.descripcionDestino
                    lista4.Add(objMostrarEncaja)

                End If
            Next
        Next
        Return lista4.ToList
    End Function

    Public Function ObtenerMascaraContable2PorItems(strEmpresa As String) As IList(Of mascaraContable2)
        Dim lista4 As New List(Of mascaraContable2)
        Dim objMostrarEncaja As mascaraContable2
        Dim idDocumento As Integer = 0

        Dim m2 = (From t In HeliosData.detalleitems Select t _
               Where t.idEmpresa = strEmpresa Join
               m In HeliosData.mascaraContable2
               On t.idEmpresa Equals m.idEmpresa _
               Where m.idEmpresa = strEmpresa _
               And m.cuentaCompra = "601111").ToList

        For Each detalle In m2

            objMostrarEncaja = New mascaraContable2()
            objMostrarEncaja.idEmpresa = detalle.t.idEmpresa
            objMostrarEncaja.tipoExistencia = detalle.t.tipoExistencia
            objMostrarEncaja.cuentaCompra = detalle.t.cuenta
            objMostrarEncaja.descripcionItem = detalle.t.descripcionItem

            objMostrarEncaja.CuentaAlmacenContado = detalle.m.cuentaDestinoKardex
            objMostrarEncaja.DescripciónAlmacenContado = detalle.m.nameDestinoKardex

            objMostrarEncaja.CuentaAlmacen = detalle.m.destinoCompra
            objMostrarEncaja.DescripciónAlmacen = detalle.m.descripcionDestino

            objMostrarEncaja.CuentaAlmacenFisico = detalle.m.cuentaDestinoKardex
            objMostrarEncaja.descripcionAlmacenFisico = detalle.m.nameDestinoKardex

            lista4.Add(objMostrarEncaja)

            For value As Integer = 1 To 1
                If (value = 1) Then
                    objMostrarEncaja = New mascaraContable2()
                    objMostrarEncaja.idEmpresa = detalle.m.idEmpresa
                    objMostrarEncaja.tipoExistencia = detalle.m.tipoExistencia


                    objMostrarEncaja.CuentaAlmacenContado = detalle.m.destinoCompra2
                    objMostrarEncaja.DescripciónAlmacenContado = detalle.m.descripcionDestino2

                    objMostrarEncaja.CuentaAlmacen = detalle.m.destinoCompra2
                    objMostrarEncaja.DescripciónAlmacen = detalle.m.descripcionDestino2

                    objMostrarEncaja.CuentaAlmacenFisico = detalle.m.destinoCompra
                    objMostrarEncaja.descripcionAlmacenFisico = detalle.m.descripcionDestino
                    lista4.Add(objMostrarEncaja)

                End If
            Next
        Next
        'Next

        Return lista4.ToList
    End Function

    Public Function InsertarMascaraSingle(ByVal mascaraContable2BE As mascaraContable2) As String
        Dim maskContable2 As New mascaraContable2
        Using ts As New TransactionScope

            maskContable2 = New mascaraContable2
            maskContable2.idEmpresa = mascaraContable2BE.idEmpresa
            maskContable2.tipoExistencia = mascaraContable2BE.tipoExistencia
            maskContable2.cuentaCompra = mascaraContable2BE.cuentaCompra
            maskContable2.descripcionCompra = mascaraContable2BE.descripcionCompra
            maskContable2.asientoCompra = mascaraContable2BE.asientoCompra

            maskContable2.destinoCompra = mascaraContable2BE.destinoCompra
            maskContable2.descripcionDestino = mascaraContable2BE.descripcionDestino
            maskContable2.asientoDestino = mascaraContable2BE.asientoDestino
            maskContable2.destinoCompra2 = mascaraContable2BE.destinoCompra2
            maskContable2.descripcionDestino2 = mascaraContable2BE.descripcionDestino2
            maskContable2.asientoDestino2 = mascaraContable2BE.asientoDestino2
            maskContable2.cuentaDestinoKardex = mascaraContable2BE.cuentaDestinoKardex
            maskContable2.nameDestinoKardex = mascaraContable2BE.nameDestinoKardex
            maskContable2.asientoDestinoKardex = mascaraContable2BE.asientoDestinoKardex

            HeliosData.mascaraContable2.Add(maskContable2)
            HeliosData.SaveChanges()
            ts.Complete()
            Return maskContable2.cuentaCompra
        End Using
    End Function

    Public Function UpdateMantenimientoMascarara2(ByVal mascaraContable2BE As mascaraContable2) As String
        Using ts As New TransactionScope
            Dim maskContable2 As mascaraContable2 = HeliosData.mascaraContable2.Where(Function(o) _
                                            o.idEmpresa = mascaraContable2BE.idEmpresa _
                                            And o.cuentaCompra = mascaraContable2BE.cuentaCompra).First()

            maskContable2.destinoCompra = mascaraContable2BE.destinoCompra
            maskContable2.descripcionDestino = mascaraContable2BE.descripcionDestino
            maskContable2.asientoDestino = mascaraContable2BE.asientoDestino
            maskContable2.destinoCompra2 = mascaraContable2BE.destinoCompra2
            maskContable2.descripcionDestino2 = mascaraContable2BE.descripcionDestino2
            maskContable2.asientoDestino2 = mascaraContable2BE.asientoDestino2
            maskContable2.cuentaDestinoKardex = mascaraContable2BE.cuentaDestinoKardex
            maskContable2.nameDestinoKardex = mascaraContable2BE.nameDestinoKardex
            maskContable2.asientoDestinoKardex = mascaraContable2BE.asientoDestinoKardex

            'HeliosData.ObjectStateManager.GetObjectStateEntry(maskContable2).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
            Return maskContable2.cuentaCompra
        End Using
    End Function

End Class
