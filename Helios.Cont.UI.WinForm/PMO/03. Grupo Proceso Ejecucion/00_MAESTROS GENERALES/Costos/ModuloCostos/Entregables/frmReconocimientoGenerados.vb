Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses

Public Class frmReconocimientoGenerados

#Region "Atributosd"

    Sub New()
       
        ' This call is required by the designer.
        InitializeComponent()
        GridCFGDetetail(dgvCostos)
        GetItems()
        GetProyectosGeneralesCMB()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "mETODOS"

    Sub GetEntregables(idSubproyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)

        '     If Not IsNothing(cboSubProyecto.SelectedValue) Then

        costo = costoSA.GetOrdenesDeProduccionInfo(New recursoCosto With {.idCosto = idSubproyecto, .status = StatusProductosTerminados.Pendiente})
        cboEntregable.DisplayMember = "nombreCosto"
        cboEntregable.ValueMember = "idCosto"
        cboEntregable.DataSource = costo

        cboEntregable.SelectedIndex = -1
        '   End If
    End Sub

    Public Sub GetSubProyectos(idProyectoGeneral As Integer)
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of recursoCosto)
        lista = recursoSA.GetListaSubProyectos(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral, .status = StatusProductosTerminados.Pendiente})
        'lista = recursoSA.GetListaProtectosByProyGeneral(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral})
        Dim query = lista.Where(Function(o) o.subtipo <> TipoCosto.HC_Mercaderia).ToList
        cboSubProyecto.DataSource = query
        cboSubProyecto.DisplayMember = "nombreCosto"
        cboSubProyecto.ValueMember = "idCosto"
    End Sub

    Private Sub GetProyectosGeneralesCMB()
        Dim costoSA As New recursoCostoSA
        cboTipo.DisplayMember = "nombreCosto"
        cboTipo.ValueMember = "idCosto"
        cboTipo.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})

        'cboGastoGeneral.Items.Clear()
        'cboGastoGeneral.Items.Add("GASTO ADMINISTRATIVO")
        'cboGastoGeneral.Items.Add("GASTO DE VENTAS")
        'cboGastoGeneral.Items.Add("GASTO FINANCIERO")
    End Sub

    Public Sub GetItems()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("nroDoc")
        dt.Columns.Add("importe")
        dt.Columns.Add("tipoCliente")
        dt.Columns.Add("idCliente")
        dt.Columns.Add("montoFacturado")
        dt.Columns.Add("montopendiente")
        dt.Columns.Add("monto")
        dt.Columns.Add("montofactigv")
        dt.Columns.Add("pagos")
        dt.Columns.Add("gravado")
        dgvCostos.DataSource = dt

    End Sub

    Sub GridCFGDetetail(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub


    Public Sub ListaDeReconocimientosxEntregable(idEntregable As Integer)
        Dim documentoSA As New documentoLibroDiarioSA
        Dim Lista As New List(Of documentoLibroDiario)

        Me.dgvCostos.Table.Records.DeleteAll()

        Try
            Lista = documentoSA.ListaDeReconocimientosxEntregable(idEntregable)


            For Each i In Lista

                Me.dgvCostos.Table.AddNewRecord.SetCurrent()
                Me.dgvCostos.Table.AddNewRecord.BeginEdit()
                Me.dgvCostos.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.dgvCostos.Table.CurrentRecord.SetValue("fecha", i.fecha)
                Me.dgvCostos.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDoc)
                Me.dgvCostos.Table.CurrentRecord.SetValue("nroDoc", i.nroDoc)
                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", i.importeMN)
                Me.dgvCostos.Table.CurrentRecord.SetValue("tipoCliente", i.tipoRazonSocial)
                Me.dgvCostos.Table.CurrentRecord.SetValue("idCliente", i.razonSocial)
                Me.dgvCostos.Table.CurrentRecord.SetValue("montoFacturado", i.montoFacturado)
                Me.dgvCostos.Table.CurrentRecord.SetValue("montopendiente", i.importeMN - i.montoFacturado)
                Me.dgvCostos.Table.CurrentRecord.SetValue("montofactigv", i.montoFacturado + i.montoIgv)
                Me.dgvCostos.Table.CurrentRecord.SetValue("pagos", i.montoPago)
                Me.dgvCostos.Table.CurrentRecord.SetValue("monto", CDec(0.0))
                Me.dgvCostos.Table.CurrentRecord.SetValue("gravado", 1)
                Me.dgvCostos.Table.AddNewRecord.EndEdit()


            Next

        Catch ex As Exception

        End Try
    End Sub



    Public Sub ProduccionEnviada()
        Dim documentoSA As New documentoLibroDiarioSA
        Dim Lista As New List(Of documentoLibroDiario)

        Me.dgvCostos.Table.Records.DeleteAll()

        Try
            Lista = documentoSA.ListaDeReconocimientos()


            For Each i In Lista

                Me.dgvCostos.Table.AddNewRecord.SetCurrent()
                Me.dgvCostos.Table.AddNewRecord.BeginEdit()
                Me.dgvCostos.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.dgvCostos.Table.CurrentRecord.SetValue("fecha", i.fecha)
                Me.dgvCostos.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDoc)
                Me.dgvCostos.Table.CurrentRecord.SetValue("nroDoc", i.nroDoc)
                Me.dgvCostos.Table.CurrentRecord.SetValue("importe", i.importeMN)
                Me.dgvCostos.Table.CurrentRecord.SetValue("tipoCliente", i.tipoRazonSocial)
                Me.dgvCostos.Table.CurrentRecord.SetValue("idCliente", i.razonSocial)
                Me.dgvCostos.Table.CurrentRecord.SetValue("montoFacturado", i.montoFacturado)
                Me.dgvCostos.Table.CurrentRecord.SetValue("montopendiente", i.importeMN - i.montoFacturado)
                Me.dgvCostos.Table.CurrentRecord.SetValue("montofactigv", i.montoFacturado + i.montoIgv)
                Me.dgvCostos.Table.CurrentRecord.SetValue("pagos", i.montoPago)
                Me.dgvCostos.Table.CurrentRecord.SetValue("monto", CDec(0.0))
                Me.dgvCostos.Table.CurrentRecord.SetValue("gravado", 1)
                Me.dgvCostos.Table.AddNewRecord.EndEdit()


            Next

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub frmReconocimientoGenerados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProduccionEnviada()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim lista As New List(Of totalesAlmacen)
        Dim objeto As New totalesAlmacen

        Try
            'sddddd()
            For Each r As Record In dgvCostos.Table.Records
                If CDec(r.GetValue("monto")) > 0 Then
                    objeto = New totalesAlmacen
                    objeto.importeSoles = CDec(r.GetValue("monto"))
                    objeto.cantidad = CDec(1)
                    objeto.idDocumento = CInt(r.GetValue("idDocumento"))
                    objeto.descripcion = "RECONOCIMIENTO"
                    objeto.origenRecaudo = r.GetValue("gravado")



                    'dt.Columns.Add("idDocumento")
                    'dt.Columns.Add("fecha")
                    'dt.Columns.Add("tipoDoc")
                    'dt.Columns.Add("nroDoc")
                    'dt.Columns.Add("importe")
                    'dt.Columns.Add("tipoCliente")
                    'dt.Columns.Add("idCliente")

                    lista.Add(objeto)
                End If
            Next

            If Not lista.Count > 0 Then
                MessageBox.Show("Por lo menos debe haber 1 itewm con un monto pro facturar")
                Exit Sub

            End If


            'Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesPedido.SelectedValue), 1)
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesPedido.SelectedValue)})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realizar está operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    End If
            'End If
            'If cboMesPedido.Text.Trim.Length > 0 Then
            'Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            '  If Not IsNothing(cajaUsuario) Then
            'GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

            Dim f As New frmFacturarReconocimiento
            'f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & cboAnio.Text
            f.lblPerido.Text = PeriodoGeneral
            f.StartPosition = FormStartPosition.CenterScreen
            f.LlenarReconocimientos(lista)
            ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.ShowDialog()

            ProduccionEnviada()
            'Else
            '    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
            'Else
            '    MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    cboMesPedido.Select()
            '    cboMesPedido.DroppedDown = True
            'End If
        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvCostos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCostos.TableControlCellClick

    End Sub

    Private Sub dgvCostos_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCostos.TableControlKeyDown
        Dim cc As GridCurrentCell = dgvCostos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvCostos.Table.CurrentRecord) Then

                    If cc.ColIndex = 10 Then

                        ' If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "10.01" Then

                        If Me.dgvCostos.Table.CurrentRecord.GetValue("monto") > 0 Then


                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montopendiente")) >= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("monto")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)
                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("monto", 0)
                            End If

                        Else
                            Me.dgvCostos.Table.CurrentRecord.SetValue("monto", 0)
                            '  Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                        End If
                        'End If
                    ElseIf cc.ColIndex = 13 Then

                        If CInt(Me.dgvCostos.Table.CurrentRecord.GetValue("gravado")) = 1 Or CInt(Me.dgvCostos.Table.CurrentRecord.GetValue("gravado")) = 2 Then
                        Else
                            Me.dgvCostos.Table.CurrentRecord.SetValue("gravado", 1)
                        End If
                        'If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "02" Then
                        '    If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                        '        'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                        '    Else
                        '        Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                        '    End If

                        'ElseIf Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "9919" Then
                        '    If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                        '        'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                        '    Else
                        '        Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                        '    End If

                        'End If
                    End If

                End If
            End If

            ' calculardeficit()

        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvCostos_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCostos.TableControlKeyPress
        Dim cc As GridCurrentCell = dgvCostos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvCostos.Table.CurrentRecord) Then

                    If cc.ColIndex = 10 Then

                        ' If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "10.01" Then

                        If Me.dgvCostos.Table.CurrentRecord.GetValue("monto") > 0 Then


                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montopendiente")) >= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("monto")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)
                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("monto", 0)
                            End If

                        Else
                            Me.dgvCostos.Table.CurrentRecord.SetValue("monto", 0)
                            '  Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                        End If
                        'End If
                    ElseIf cc.ColIndex = 13 Then

                        If CInt(Me.dgvCostos.Table.CurrentRecord.GetValue("gravado")) = 1 Or CInt(Me.dgvCostos.Table.CurrentRecord.GetValue("gravado")) = 2 Then
                        Else
                            Me.dgvCostos.Table.CurrentRecord.SetValue("gravado", 1)
                        End If
                        'If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "02" Then
                        '    If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                        '        'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                        '    Else
                        '        Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                        '    End If

                        'ElseIf Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "9919" Then
                        '    If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                        '        'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                        '    Else
                        '        Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                        '    End If

                        'End If
                    End If

                End If
            End If

            ' calculardeficit()

        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dgvCostos_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCostos.TableControlKeyUp
        Dim cc As GridCurrentCell = dgvCostos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then
                If Not IsNothing(Me.dgvCostos.Table.CurrentRecord) Then

                    If cc.ColIndex = 10 Then

                        ' If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "10.01" Then

                        If Me.dgvCostos.Table.CurrentRecord.GetValue("monto") > 0 Then


                            If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montopendiente")) >= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("monto")) Then

                                'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                                'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)
                            Else
                                Me.dgvCostos.Table.CurrentRecord.SetValue("monto", 0)
                            End If

                        Else
                            Me.dgvCostos.Table.CurrentRecord.SetValue("monto", 0)
                            '  Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                        End If
                        'End If
                    ElseIf cc.ColIndex = 13 Then

                        If CInt(Me.dgvCostos.Table.CurrentRecord.GetValue("gravado")) = 1 Or CInt(Me.dgvCostos.Table.CurrentRecord.GetValue("gravado")) = 2 Then
                        Else
                            Me.dgvCostos.Table.CurrentRecord.SetValue("gravado", 1)
                        End If

                        'If Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "02" Then
                        '    If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                        '        'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                        '    Else
                        '        Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                        '    End If

                        'ElseIf Me.dgvCostos.Table.CurrentRecord.GetValue("operacion") = "9919" Then
                        '    If CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("importe")) <= CDec(Me.dgvCostos.Table.CurrentRecord.GetValue("montoMN")) Then

                        '        'Dim importeTotal = Me.dgvCostos.Table.CurrentRecord.GetValue("cantidad") * Me.dgvCostos.Table.CurrentRecord.GetValue("precio")
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("importe", importeTotal)

                        '    Else
                        '        Me.dgvCostos.Table.CurrentRecord.SetValue("importe", 0)
                        '        'Me.dgvCostos.Table.CurrentRecord.SetValue("cantidad", 0)
                        '    End If

                        'End If
                    End If

                End If
            End If

            ' calculardeficit()

        Catch ex As Exception
            'lblEstado.Text = "Error: " & ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Cursor = Cursors.WaitCursor
        GetSubProyectos(cboTipo.SelectedValue)
        cboSubProyecto.SelectedIndex = -1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboSubProyecto_Click(sender As Object, e As EventArgs) Handles cboSubProyecto.Click

    End Sub

    Private Sub cboSubProyecto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubProyecto.SelectedIndexChanged
        Dim costoSA As New recursoCostoSA
        cboEntregable.DataSource = Nothing
        'cboEdt.DataSource = Nothing
        If cboSubProyecto.SelectedIndex > -1 Then

            Dim recursoSA As New recursoCostoSA

            Dim codValue = cboSubProyecto.SelectedValue


            If IsNumeric(codValue) Then

                GetEntregables(codValue)

            End If
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If cboEntregable.Text.Trim.Length > 0 Then
            ListaDeReconocimientosxEntregable(cboEntregable.SelectedValue)
        End If
    End Sub
End Class