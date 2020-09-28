Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Public Class HistorialCajasUsuario

#Region "Attributes"

#End Region

#Region "constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Value = Date.Now
        txtFecha.Enabled = True
        txtFecha.ReadOnly = False
        GetConsultaPorDia()
    End Sub
#End Region

#Region "Methods"
    Public Sub GetAsignaciones()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull

        ListResumen.Items.Clear()
        ListDetalle.Items.Clear()

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFull(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

            Dim n As New ListViewItem(i.idPersona)
            usuario = New Usuario
            usuario.IDUsuario = i.idPersona

            usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            If (Not IsNothing(usuario)) Then
                'Select Case i.estadoCaja
                '    Case "A"
                n.SubItems.Add(i.idcajaUsuario)
                n.SubItems.Add(usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno)
                n.SubItems.Add(usuario.NroDocumento)
                Select Case i.estadoCaja
                    Case "A"
                        n.SubItems.Add("ABIERTO")
                    Case Else
                        n.SubItems.Add("CERRADO")
                End Select
                n.SubItems.Add(i.fechaRegistro)
                ListResumen.Items.Add(n)
                '     End Select
            End If
        Next
        ListResumen.Refresh()
    End Sub

    Public Sub ObtenerListaCajaAsignacionDetalle(idCajausuario As Integer, idpersona As Integer, fechaRegistro As DateTime)
        Dim cajausuariosa As New cajaUsuarioSA
        Dim finanza As New estadosFinancieros
        Dim finanzaSA As New EstadosFinancierosSA
        Dim cajausuario As New List(Of cajaUsuario)


        ListDetalle.Items.Clear()

        cajausuario = cajausuariosa.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = idCajausuario, .idPersona = idpersona, .fechaRegistro = fechaRegistro})


        For Each i In cajausuario
            finanza = finanzaSA.GetUbicar_estadosFinancierosPorID(i.idEntidad)

            Dim n As New ListViewItem(i.idcajaUsuario)

                    n.SubItems.Add(i.idPersona)

                    n.SubItems.Add(i.NombreEntidad)

                    n.SubItems.Add(i.Tipo)

                    n.SubItems.Add(If(i.moneda = "1", "NACIONAL", "EXT"))

                    n.SubItems.Add(i.fondoMN)

                    n.SubItems.Add("0")

                    n.SubItems.Add(i.ingresoAdicMN)

                    n.SubItems.Add("0")

                    n.SubItems.Add(i.Saldo)

                    n.SubItems.Add("0")

                    n.SubItems.Add(finanza.idEmpresa)

                    n.SubItems.Add(finanza.idEstablecimiento)

                    n.SubItems.Add(i.otrosEgresosMN)

                    n.SubItems.Add("0")
            ListDetalle.Items.Add(n)
        Next
        ListDetalle.Refresh()
    End Sub

    Private Sub ListResumen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListResumen.SelectedIndexChanged
        If ListResumen.SelectedItems.Count > 0 Then
            Cursor = Cursors.WaitCursor
            Dim r = ListResumen.SelectedItems(0)
            ObtenerListaCajaAsignacionDetalle(Integer.Parse(r.SubItems(1).Text), Integer.Parse(r.SubItems(0).Text), Date.Parse(r.SubItems(5).Text))
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RoundButton21_Click_1(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Cursor = Cursors.WaitCursor
        GetConsultaPorDia()
        Cursor = Cursors.Default
    End Sub

    Private Sub GetConsultaPorDia()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull

        ListResumen.Items.Clear()
        ListDetalle.Items.Clear()

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioDia(New cajaUsuario With {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .fechaRegistro = txtFecha.Value
                                                          })

            Dim n As New ListViewItem(i.idPersona)
            usuario = New Usuario
            usuario.IDUsuario = i.idPersona

            usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            If (Not IsNothing(usuario)) Then
                'Select Case i.estadoCaja
                '    Case "A"
                n.SubItems.Add(i.idcajaUsuario)
                n.SubItems.Add(usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno)
                n.SubItems.Add(usuario.NroDocumento)
                Select Case i.estadoCaja
                    Case "A"
                        n.SubItems.Add("ABIERTO")
                    Case Else
                        n.SubItems.Add("CERRADO")
                End Select
                n.SubItems.Add(i.fechaRegistro)
                n.SubItems.Add(If(i.fechaCierre.HasValue = True, i.fechaCierre, "-"))
                ListResumen.Items.Add(n)
                '     End Select
            End If
        Next
        ListResumen.Refresh()
    End Sub
#End Region

#Region "Events"

#End Region
End Class
