Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class cajaUsuarioDetalleBL
    Inherits BaseBL


    Public Sub EliminarDetalle(be As cajaUsuario)
        Dim consulta = (From n In HeliosData.cajaUsuariodetalle Where n.idcajaUsuario = be.idcajaUsuario).ToList
        Using ts As New TransactionScope
            For Each i In consulta
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ResumenDetailVenta(be As cajaUsuario) As List(Of cajaUsuariodetalle)
        Dim obj As New cajaUsuariodetalle
        Dim lista As New List(Of cajaUsuariodetalle)

        Dim consulta = (From n In HeliosData.usp_ResumenDetailVenta(be.idcajaUsuario, be.idPersona) _
                       Select n).ToList

        For Each i In consulta
            obj = New cajaUsuariodetalle
            obj.Movimiento = i.MOVIMIENTO
            obj.idEntidad = i.idEntidad
            obj.NomEntidad = i.descripcion
            obj.moneda = i.moneda
            obj.INICIO_MN = i.INICIO_MN
            obj.INICIO_ME = i.INICIO_ME
            obj.TOTAL_MN = i.TOTAL_MN
            obj.TOTAL_ME = i.TOTAL_ME
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function ListaDetallePorCaja(intIdCajaUsuario As Integer) As List(Of cajaUsuariodetalle)
        Return (From n In HeliosData.cajaUsuariodetalle
                Where n.idcajaUsuario = intIdCajaUsuario Select n).ToList
    End Function

    Public Function ListaDetalleUsuarioXEntidades(be As cajaUsuario) As List(Of cajaUsuariodetalle)
        Dim lista As New List(Of cajaUsuariodetalle)
        Dim obj As New cajaUsuariodetalle

        Dim consulta = (From n In HeliosData.cajaUsuariodetalle _
                           Join EF In HeliosData.estadosFinancieros _
                        On EF.idestado Equals n.idEntidad _
                        Join cajausuario In HeliosData.cajaUsuario _
                        On cajausuario.idcajaUsuario Equals n.idcajaUsuario _
                       Where cajausuario.idcajaUsuario = be.idcajaUsuario And _
                       cajausuario.estadoCaja = "A").ToList

        For Each i In consulta
            obj = New cajaUsuariodetalle
            obj.Tipo = i.EF.tipo
            obj.idcajaUsuario = i.n.idcajaUsuario
            obj.secuencia = i.n.secuencia
            obj.idEntidad = i.n.idEntidad
            obj.NomEntidad = i.EF.descripcion
            obj.moneda = i.n.moneda
            obj.importeMN = i.n.importeMN
            obj.importeME = i.n.importeME
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function ListaDetalleUsuarioXUsuario(be As cajaUsuario) As List(Of cajaUsuariodetalle)
        Dim lista As New List(Of cajaUsuariodetalle)
        Dim obj As New cajaUsuariodetalle

        Dim consulta = (From n In HeliosData.cajaUsuariodetalle _
                        Join EF In HeliosData.estadosFinancieros _
                        On EF.idestado Equals n.idEntidad _
                        Join cajausuario In HeliosData.cajaUsuario _
                        On cajausuario.idcajaUsuario Equals n.idcajaUsuario _
                        Where cajausuario.idPersona = be.idPersona).ToList

        For Each i In consulta
            obj = New cajaUsuariodetalle
            obj.Tipo = i.EF.tipo
            obj.idcajaUsuario = i.n.idcajaUsuario
            obj.secuencia = i.n.secuencia
            obj.idEntidad = i.n.idEntidad
            obj.moneda = i.n.moneda
            obj.importeMN = i.n.importeMN
            obj.importeME = i.n.importeME
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Sub InsertarNuevoIngreso(objUsuarioDetalle As cajaUsuariodetalle)
        Dim cajausuariodetalle As New cajaUsuariodetalle

        Dim consultaExiste = (From n In HeliosData.cajaUsuariodetalle _
                             Where n.idcajaUsuario = objUsuarioDetalle.idcajaUsuario).FirstOrDefault

        Using ts As New TransactionScope
            If IsNothing(consultaExiste) Then
                Insert(objUsuarioDetalle)
            Else
                If IsNothing(consultaExiste.importeMN) Then
                    consultaExiste.importeMN = 0
                End If

                If IsNothing(consultaExiste.importeME) Then
                    consultaExiste.importeME = 0
                End If

                consultaExiste.importeMN = CDec(consultaExiste.importeMN) + CDec(objUsuarioDetalle.importeMN)
                consultaExiste.importeME = CDec(consultaExiste.importeME) + CDec(objUsuarioDetalle.importeME)
                'HeliosData.ObjectStateManager.GetObjectStateEntry(consultaExiste).State.ToString()
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertarNuevo(objUsuarioDetalle As cajaUsuariodetalle)
        Dim cajausuariodetalle As New cajaUsuariodetalle

        Using ts As New TransactionScope
            cajausuariodetalle.idcajaUsuario = objUsuarioDetalle.idcajaUsuario
            cajausuariodetalle.idEntidad = objUsuarioDetalle.idEntidad
            cajausuariodetalle.moneda = objUsuarioDetalle.moneda
            cajausuariodetalle.importeMN = objUsuarioDetalle.importeMN
            cajausuariodetalle.importeME = objUsuarioDetalle.importeME
            cajausuariodetalle.tipoCambio = objUsuarioDetalle.tipoCambio
            cajausuariodetalle.idConfiguracion = objUsuarioDetalle.idConfiguracion
            cajausuariodetalle.usuarioActualizacion = objUsuarioDetalle.usuarioActualizacion
            cajausuariodetalle.fechaActualizacion = objUsuarioDetalle.fechaActualizacion

            HeliosData.cajaUsuariodetalle.Add(cajausuariodetalle)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Insert(objUsuarioDetalle As cajaUsuariodetalle)
        Using ts As New TransactionScope
            HeliosData.cajaUsuariodetalle.Add(objUsuarioDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertUpdateMontos(objUsuarioDetalle As cajaUsuariodetalle)
        Using ts As New TransactionScope
            HeliosData.cajaUsuariodetalle.Add(objUsuarioDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeleteTotalesCajaUsuarioDetalle(ByVal intIdDocumentoVenta As Integer, intIdCajaUsuario As Integer)
        Dim objNuevo As New cajaUsuariodetalle()
        Try
            Using ts As New TransactionScope()

                Dim objBackDoc = (From k In HeliosData.documentoventaAbarrotes _
                                 Where k.idDocumento = intIdDocumentoVenta).First

                'objNuevo = HeliosData.cajaUsuariodetalle.Where(Function(o) o.idcajaUsuario = intIdCajaUsuario And
                '                                                   o.tipoDoc = objBackDoc.tipoDocumento And
                '                                                   o.tipoVenta = objBackDoc.tipoVenta).FirstOrDefault

                'If Not IsNothing(objNuevo) Then
                '    objNuevo.importeMN = objNuevo.importeMN - objBackDoc.ImporteNacional
                '    objNuevo.importeME = objNuevo.importeME - objBackDoc.ImporteExtranjero
                'End If

                'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteTotalesCajaUsuarioDetalleCompra(ByVal intIdDocumentoCompra As Integer, intIdCajaUsuario As Integer)
        Dim objNuevo As New cajaUsuariodetalle()
        Try
            Using ts As New TransactionScope()

                Dim objBackDoc = (From k In HeliosData.documentocompra _
                                 Where k.idDocumento = intIdDocumentoCompra).First

                'objNuevo = HeliosData.cajaUsuariodetalle.Where(Function(o) o.idcajaUsuario = intIdCajaUsuario And
                '                                                   o.tipoDoc = objBackDoc.tipoDoc And
                '                                                   o.tipoVenta = objBackDoc.tipoCompra).FirstOrDefault

                'If Not IsNothing(objNuevo) Then
                '    objNuevo.importeMN = objNuevo.importeMN - objBackDoc.importeTotal
                '    objNuevo.importeME = objNuevo.importeME - objBackDoc.importeUS
                'End If

                'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteTotalesCajaUsuarioDetalleCaja(ByVal intIdDocCaja As Integer, intIdCajaUsuario As Integer, intIDCompra As Integer)
        Dim objNuevo As New cajaUsuariodetalle()

        Try
            Using ts As New TransactionScope()

                Dim objBackDoc = (From k In HeliosData.documentoCaja _
                                 Where k.idDocumento = intIdDocCaja).FirstOrDefault

                If Not IsNothing(objBackDoc) Then

                    Dim compraResult As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = intIDCompra).FirstOrDefault

                    'objNuevo = HeliosData.cajaUsuariodetalle.Where(Function(o) o.idcajaUsuario = intIdCajaUsuario And
                    '                                                   o.tipoDoc = compraResult.tipoDoc And
                    '                                                   o.tipoVenta = "CAC").FirstOrDefault

                    'If Not IsNothing(objNuevo) Then
                    '    objNuevo.importeMN = objNuevo.importeMN - objBackDoc.montoSoles
                    '    objNuevo.importeME = objNuevo.importeME - objBackDoc.montoUsd
                    '    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                    'End If

                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteTotalesCajaUsuarioDetalleCajaPrestamoOT(ByVal intIdDocCaja As Integer, intIdCajaUsuario As Integer, intIdPrestamo As Integer)
        Dim objNuevo As New cajaUsuariodetalle()

        Try
            Using ts As New TransactionScope()

                Dim objBackDoc = (From k In HeliosData.documentoCaja _
                                 Where k.idDocumento = intIdDocCaja).FirstOrDefault

                If Not IsNothing(objBackDoc) Then

                    Dim compraResult As prestamos = HeliosData.prestamos.Where(Function(o) o.idDocumento = intIdPrestamo).FirstOrDefault


                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
