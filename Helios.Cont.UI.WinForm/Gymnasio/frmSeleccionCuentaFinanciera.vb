Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class frmSeleccionCuentaFinanciera
    Public Property usuarioCajaSA As New cajaUsuarioSA
    Public Property estadosFinancierosSA As New EstadosFinancierosSA

    Public Property User As New cajaUsuario

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()


        If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

            User = (From i In ListaCajasActivas Where i.tipoCaja = Tipo_Caja.GENERAL).FirstOrDefault
        ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

            User = (From i In ListaCajasActivas Where i.idPersona = usuario.IDUsuario And i.IDRol = usuario.IDRol).FirstOrDefault
        End If


        LoadEntidadesTipo()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub LoadEntidadesTipo()
        If User IsNot Nothing Then
            If User.tipoCaja = Tipo_Caja.GENERAL Then
                cboTipo.Items.Clear()
                cboTipo.Items.Add("CUENTAS EN EFECTIVO")
                cboTipo.Items.Add("CUENTAS EN BANCO")
                cboTipo.Items.Add("TARJETA DE CREDITO")
                cboTipo.Text = "CUENTAS EN EFECTIVO"

            ElseIf User.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then
                cboTipo.Items.Clear()
                cboTipo.Items.Add("CUENTAS EN EFECTIVO CAJERO")
                'cboTipo.Items.Add("CUENTAS EN BANCO")
                cboTipo.Text = "CUENTAS EN EFECTIVO CAJERO"
            End If
        Else
            MessageBox.Show("No tiene Caja activas")
        End If
    End Sub


    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

        Try


            Cursor = Cursors.WaitCursor



            'Dim User = (From i In ListaCajasActivas Where i.idPersona = usuario.IDUsuario).FirstOrDefault

            If User.tipoCaja IsNot Nothing Then
                If User.tipoCaja = Tipo_Caja.GENERAL Then

                    GetCuentasFinancieras(cboTipo.Text)
                ElseIf User.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then
                    GetCuentasFinancierasXCajero(cboTipo.Text, User.idcajaUsuario)
                End If


            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub



    Public Sub GetCuentasFinancierasXCajero(tipo As String, idCajaUser As Integer)
        ListView1.Items.Clear()
        Select Case tipo
            'Case "CUENTAS EN EFECTIVO"
            '    tipo = "EF"
            'Case "CUENTAS EN BANCO"
            '    tipo = "BC"
            'Case "TARJETA DE CREDITO"
            '    tipo = "TC"
            Case "CUENTAS EN EFECTIVO CAJERO"
                tipo = "EP"
        End Select


        For Each i In estadosFinancierosSA.GetSaldoCuentasFinancieraCajeroActivo(New Business.Entity.estadosFinancieros With {
                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                       .tipo = tipo, .fechaBalance = txtPeriodo.Value,
                                       .IdCaja = idCajaUser
                                                                                  })
            Dim n As New ListViewItem(i.idestado)
            n.SubItems.Add(i.descripcion)
            n.SubItems.Add("-")
            n.SubItems.Add((i.SaldoAnterior.GetValueOrDefault + i.Cobros.GetValueOrDefault) - i.Pagos.GetValueOrDefault)
            ListView1.Items.Add(n)
        Next
        '    End Select


    End Sub

    Public Sub GetCuentasFinancieras(tipo As String)
        ListView1.Items.Clear()
        Select Case tipo
            Case "CUENTAS EN EFECTIVO"
                tipo = "EF"
            'Case "CUENTAS EN EFECTIVO CAJERO"
            '    tipo = "EP"
            Case "CUENTAS EN BANCO"
                tipo = "BC"
            Case "TARJETA DE CREDITO"
                tipo = "TC"
        End Select

        'Select Case usuario.TieneCaja
        '    Case True
        '        Dim listaCF As New List(Of Integer)
        '        Dim cajaUsuario = usuarioCajaSA.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = GFichaUsuarios.IdCajaUsuario, .idPersona = usuario.IDUsuario, .fechaRegistro = Date.Now})
        '        Dim query = (From n In cajaUsuario
        '                     Select n.idEntidad).Distinct.ToList

        '        For Each i In query
        '            listaCF.Add(i)
        '        Next

        '        If ((cajaUsuario.Count) > 0) Then
        '            Dim nuevaLista = estadosFinancierosSA.GetCuentasFinancierasEmpresaXtipoXidCaja(New Business.Entity.estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = tipo, .fechaBalance = txtPeriodo.Value, .IdCaja = cajaUsuario(0).idcajaUsuario})

        '            nuevaLista = nuevaLista.Where(Function(o) listaCF.Contains(o.idestado)).ToList
        '            For Each i In nuevaLista 'estadosFinancierosSA.GetCuentasFinancierasEmpresaXtipo(New Business.Entity.estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = tipo, .fechaBalance = txtPeriodo.Value})
        '                Dim n As New ListViewItem(i.idestado)
        '                n.SubItems.Add(i.descripcion)
        '                n.SubItems.Add("-")
        '                n.SubItems.Add((i.AperturaMN + i.SaldoAnterior.GetValueOrDefault + i.Cobros.GetValueOrDefault) - i.Pagos.GetValueOrDefault)
        '                ListView1.Items.Add(n)
        '            Next
        '        End If



        '    Case Else
        For Each i In estadosFinancierosSA.GetCuentasFinancierasEmpresaXtipoFecha(New Business.Entity.estadosFinancieros With {
                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                       .tipo = tipo, .fechaBalance = txtPeriodo.Value
                                                                                  })
            Dim n As New ListViewItem(i.idestado)
            n.SubItems.Add(i.descripcion)
            n.SubItems.Add("-")
            n.SubItems.Add((i.SaldoAnterior.GetValueOrDefault + i.Cobros.GetValueOrDefault) - i.Pagos.GetValueOrDefault)
            ListView1.Items.Add(n)
        Next
        '    End Select


    End Sub

    Public Sub GetCuentasFinancierasTransferencia(tipo As String, idEntidadOrigen As Integer)
        ListView1.Items.Clear()
        Select Case tipo
            Case "CUENTAS EN EFECTIVO"
                tipo = "EF"
            Case "CUENTAS EN BANCO"
                tipo = "BC"
            Case "TARJETA DE CREDITO"
                tipo = "TC"
        End Select

        Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
            Case 3, 4
                Dim listaCF As New List(Of Integer)
                Dim cajaUsuario = usuarioCajaSA.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = GFichaUsuarios.IdCajaUsuario, .idPersona = usuario.IDUsuario, .fechaRegistro = Date.Now})
                Dim query = (From n In cajaUsuario
                             Select n.idEntidad).Distinct.ToList

                For Each i In query
                    listaCF.Add(i)
                Next

                If ((cajaUsuario.Count) > 0) Then
                    Dim nuevaLista = estadosFinancierosSA.GetCuentasFinancierasEmpresaXtipoXidCaja(New Business.Entity.estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = tipo, .fechaBalance = txtPeriodo.Value, .idCaja = cajaUsuario(0).idcajaUsuario})

                    nuevaLista = nuevaLista.Where(Function(o) listaCF.Contains(o.idestado)).ToList
                    For Each i In nuevaLista 'estadosFinancierosSA.GetCuentasFinancierasEmpresaXtipo(New Business.Entity.estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = tipo, .fechaBalance = txtPeriodo.Value})
                        If (i.idestado <> idEntidadOrigen) Then
                            Dim n As New ListViewItem(i.idestado)
                            n.SubItems.Add(i.descripcion)
                            n.SubItems.Add("-")
                            n.SubItems.Add((i.AperturaMN + i.SaldoAnterior.GetValueOrDefault + i.Cobros.GetValueOrDefault) - i.Pagos.GetValueOrDefault)
                            ListView1.Items.Add(n)
                        End If
                    Next
                End If



            Case Else
                For Each i In estadosFinancierosSA.GetCuentasFinancierasEmpresaXtipo(New Business.Entity.estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = tipo, .fechaBalance = txtPeriodo.Value})
                    If (i.idestado <> idEntidadOrigen) Then
                        Dim n As New ListViewItem(i.idestado)
                        n.SubItems.Add(i.descripcion)
                        n.SubItems.Add("-")
                        n.SubItems.Add((i.SaldoAnterior.GetValueOrDefault + i.Cobros.GetValueOrDefault) - i.Pagos.GetValueOrDefault)
                        ListView1.Items.Add(n)
                    End If
                Next
        End Select


    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Cursor = Cursors.WaitCursor
        If ListView1.SelectedItems.Count > 0 Then
            Dim l = ListView1.SelectedItems(0)
            Dim c = estadosFinancierosSA.GetUbicar_estadosFinancierosPorID(l.SubItems(0).Text)
            c.importeBalanceMN = Decimal.Parse(l.SubItems(3).Text)
            Tag = c
            Close()
        Else
            MessageBox.Show("Debe seleccionra una cuenta financiera", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class