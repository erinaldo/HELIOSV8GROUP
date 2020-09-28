Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Femiani.Forms.UI.Input
Public Class frmNuevoMaterial
    Public Property strEstadoManipulacion() As String


    Private Sub GrabarButton()
        Try
            If lblEstado.Tag = "NEX" Then
                lblEstado.Text = "válidar la cuenta contable!"
                lblEstado.Image = My.Resources.warning2
            Else
                Dim objItem As New ItemDS(txtDescripcion.Text, txtClasifID.Text, txtPresenID.Text, txtumID.Text, txtExistenciaID.Text, txtCuentaID.Text)
                Select Case strEstadoManipulacion
                    Case ENTITY_ACTIONS.INSERT
                        GrabarItemEstablec(objItem)
                    Case ENTITY_ACTIONS.UPDATE
                        EditarItemEstablec(objItem)
                End Select
                Dispose()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey( _
     ByRef msg As System.Windows.Forms.Message, _
     ByVal keyData As System.Windows.Forms.Keys) As Boolean


        If (keyData <> Keys.Control + Keys.G) And (keyData <> Keys.F2) Then _
            Return MyBase.ProcessCmdKey(msg, keyData)


        If Keys.Control + Keys.G Then

            Me.Cursor = Cursors.WaitCursor
            GrabarButton()
            Me.Cursor = Cursors.Arrow
        End If

        Return True

    End Function

#Region "Métodos"
    Enum Filtro
        PorNombre = 2
        PorCodigo = 1
    End Enum
    Dim ACTDBSuggestions As New AutoCompleteStringCollection()
    Public Sub ObtenerMascaraMercaderia()
        Dim cuentaSA As New mascaraContable2SA

        Try
            ACTDBSuggestions.Clear()
            txtCuentaID.Items.Clear()
            Me.txtCuentaID.Text = String.Empty
            For Each i As mascaraContable2 In cuentaSA.ObtenerMascaraContableMercaderia(Gempresas.IdEmpresaRuc, "6")
                ACTDBSuggestions.Add(i.cuentaCompra)
                Me.txtCuentaID.Items.Add(New AutoCompleteEntry(i.cuentaCompra, i.cuentaCompra, i.cuentaCompra))
                Me.Validate()
            Next
        Catch ex As Exception
            lblEstado.Text = "No se pudo cargar la información para las cuentas. " & ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Public Sub ObtenerMascaraExistencia(strTipoExistencia As String)
        Dim cuentaSA As New mascaraContableExistenciaSA
        Try
            ACTDBSuggestions.Clear()
            txtCuentaID.Items.Clear()
            Me.txtCuentaID.Text = String.Empty
            For Each i As mascaraContableExistencia In cuentaSA.ObtenerMascaraExistencias(Gempresas.IdEmpresaRuc, strTipoExistencia)
                ACTDBSuggestions.Add(i.cuentaCompra)
                Me.txtCuentaID.Items.Add(New AutoCompleteEntry(i.cuentaCompra, i.cuentaCompra, i.cuentaCompra))
                Me.Validate()
            Next
        Catch ex As Exception
            lblEstado.Text = "No se pudo cargar la información para las cuentas. " & ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub
    'ObtenerMascaraExistencias
    Public Sub ObtenerPorCodigoExistencia(intCodigoDetalle As Integer)

        Dim objItem As New detalleitemsSA
        Dim nItem As New detalleitems
        Dim objTabla As New tablaDetalleSA
        Dim objCat As New itemSA
        Try
            nItem = objItem.InvocarProductoID(intCodigoDetalle)
            If Not IsNothing(nItem) Then

                txtCodigo.Text = nItem.codigodetalle
                txtDescripcion.Text = nItem.descripcionItem

                With objTabla.GetUbicarTablaID(5, nItem.tipoExistencia)
                    txtExistencia.Text = .descripcion
                    txtExistenciaID.Text = .codigoDetalle
                End With
                If nItem.tipoExistencia = "03" Then
                    ObtenerMascaraExistencia("03")
                ElseIf nItem.tipoExistencia = "04" Then
                    ObtenerMascaraExistencia("04")
                ElseIf nItem.tipoExistencia = "05" Then
                    ObtenerMascaraExistencia("05")
                ElseIf nItem.tipoExistencia = "01" Then
                    ObtenerMascaraMercaderia()
                End If

                With objCat.UbicarCategoriaPorID(nItem.idItem)
                    txtClasif.Text = .descripcion
                    txtClasifID.Text = .idItem

                    With objTabla.GetUbicarTablaID(6, nItem.unidad1)
                        txtum.Text = .descripcion
                        txtumID.Text = .codigoDetalle
                    End With
               

                    With objTabla.GetUbicarTablaID(21, nItem.presentacion)
                        txtPresen.Text = .descripcion
                        txtPresenID.Text = .codigoDetalle
                    End With

                    ' txtCuenta.Text = "Costo"
                    txtCuentaID.Text = nItem.cuenta
                End With

                If nItem.origenProducto = "1" Then
                    rbAfecta.Checked = True
                Else
                    rbnoAfecta.Checked = True
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Enum Tablas
        TipoExistencia = 5
        Clasificacion = 0
        UnidadMedidad = 6
        Presentacion = 21
        Cuenta = 3
    End Enum
    'Sub ComprobanteShows(caso As Tablas)
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '    datos.Clear()
    '    With frmModalComprobantesTabla
    '        .x_Establecimiento = GEstableciento.IdEstablecimiento
    '        .lblTipo.Text = caso
    '        Select Case caso
    '            Case Tablas.Clasificacion
    '                .ToolStrip1.Enabled = True
    '                .Tablax = frmModalComprobantesTabla.Tablas.Clasificacion
    '        End Select
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        If datos.Count > 0 Then
    '            Select Case caso
    '                Case Tablas.TipoExistencia
    '                    txtCuenta.Text = "Costo"
    '                    Select Case datos(0).ID
    '                        Case "01"
    '                            ObtenerMascaraMercaderia()
    '                            txtCuentaID.Text = "601111"
    '                        Case "03"
    '                            ObtenerMascaraExistencia("03")
    '                            txtCuentaID.Text = "602111"
    '                        Case "04"
    '                            ObtenerMascaraExistencia("04")
    '                            txtCuentaID.Text = "604111"
    '                        Case "05"
    '                            ObtenerMascaraExistencia("05")
    '                            txtCuentaID.Text = "603111"
    '                    End Select
    '                    txtExistenciaID.Text = datos(0).ID
    '                    txtExistencia.Text = datos(0).NombreCampo
    '                    Me.lblEstado.Image = My.Resources.ok4
    '                    Me.lblEstado.Text = "Done!: Tipo existencia." ' String.Empty
    '                    Me.lblEstado.ForeColor = Color.Black
    '                Case Tablas.Clasificacion

    '                    txtClasifID.Text = datos(0).ID
    '                    txtClasif.Text = datos(0).NombreCampo
    '                    Me.lblEstado.Image = My.Resources.ok4
    '                    Me.lblEstado.Text = "Done!: Clasificación." ' String.Empty
    '                    Me.lblEstado.ForeColor = Color.Black
    '                Case Tablas.UnidadMedidad
    '                    txtumID.Text = datos(0).ID
    '                    txtum.Text = datos(0).NombreCampo
    '                    Me.lblEstado.Image = My.Resources.ok4
    '                    Me.lblEstado.Text = "Done!: Unidad de Medida." ' String.Empty
    '                    Me.lblEstado.ForeColor = Color.Black
    '                Case Tablas.Presentacion
    '                    txtPresenID.Text = datos(0).ID
    '                    txtPresen.Text = datos(0).NombreCampo
    '                    Me.lblEstado.Image = My.Resources.ok4
    '                    Me.lblEstado.Text = "Done!: Presentación." ' String.Empty
    '                    Me.lblEstado.ForeColor = Color.Black
    '                Case Tablas.Cuenta
    '                    txtCuentaID.Text = datos(0).ID
    '                    txtCuenta.Text = datos(0).NombreCampo
    '            End Select
    '            Timer1.Enabled = False
    '        Else
    '            'Select Case caso
    '            '    Case Tablas.TipoExistencia
    '            '        txtExistenciaID.Text = String.Empty
    '            '        txtExistencia.Text = String.Empty
    '            '    Case Tablas.Clasificacion
    '            '        txtClasifID.Text = String.Empty
    '            '        txtClasif.Text = String.Empty
    '            '    Case Tablas.UnidadMedidad
    '            '        txtumID.Text = String.Empty
    '            '        txtum.Text = String.Empty
    '            '    Case Tablas.Presentacion
    '            '        txtPresenID.Text = String.Empty
    '            '        txtPresen.Text = String.Empty
    '            '    Case Tablas.Cuenta
    '            '        txtCuentaID.Text = String.Empty
    '            '        txtCuenta.Text = String.Empty
    '            ' End Select
    '            '    MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
    '        End If
    '    End With
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Public Sub GrabarItemEstablec(ByVal mat As ItemDS)
        Dim objitem As New detalleitems
        Dim itemSA As New detalleitemsSA
        Try
            'Se asigna cada uno de los datos registrados
            objitem.idItem = mat.Clasificacion   ' Trim(txtCodigoDocumento.Text)
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.cuenta = mat.Cuenta
            objitem.descripcionItem = mat.DescripcionItem
            objitem.presentacion = mat.Presentacion
            objitem.unidad1 = mat.UnidadMedida
            ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
            objitem.tipoExistencia = mat.TipoEx
            objitem.origenProducto = IIf(rbAfecta.Checked = True, "1", "2")
            objitem.tipoProducto = "I"

            objitem.usuarioActualizacion = "Jiuni"
            objitem.fechaActualizacion = DateTime.Now

            itemSA.InsertNuevaItems(objitem)
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Item registrado!"
          
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el Producto." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub EditarItemEstablec(ByVal mat As ItemDS)
        Dim objitem As New detalleitems
        Dim itemSA As New detalleitemsSA
        Try
            'Se asigna cada uno de los datos registrados
            objitem.codigodetalle = txtCodigo.Text
            objitem.idItem = mat.Clasificacion   ' Trim(txtCodigoDocumento.Text)
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.cuenta = mat.Cuenta
            objitem.descripcionItem = mat.DescripcionItem
            objitem.presentacion = mat.Presentacion
            objitem.unidad1 = mat.UnidadMedida
            ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
            objitem.tipoExistencia = mat.TipoEx
            objitem.origenProducto = IIf(rbAfecta.Checked = True, "1", "2")
            objitem.tipoProducto = "I"

            objitem.usuarioActualizacion = "Jiuni"
            objitem.fechaActualizacion = DateTime.Now

            itemSA.UpdateProducto(objitem)
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Item actualizado!"
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el Producto." & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
    Private Sub frmNuevoMaterial_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevoMaterial_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        txtDescripcion.Select()
        txtDescripcion.Focus()
    End Sub

    Private Sub Label10_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        '     Call ComprobanteShows(Tablas.TipoExistencia)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        '    Call ComprobanteShows(Tablas.Clasificacion)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        '   Call ComprobanteShows(Tablas.UnidadMedidad)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        '   Call ComprobanteShows(Tablas.Presentacion)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        '    Call ComprobanteShows(Tablas.Cuenta)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtDescripcion.Focus()
            txtDescripcion.Select(0, txtDescripcion.Text.Length)
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtCodigo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If Me.txtCodigo.Text.Trim.Length = 0 Then
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique el código!"
            ErrorProvider1.SetError(Me.txtCodigo, "Indique el código!")
            txtCodigo.Select(0, txtCodigo.Text.Length)
            Timer1.Enabled = True
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtCodigo, "")
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Timer1.Enabled = False
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: Código." ' String.Empty
            Me.lblEstado.ForeColor = Color.Black
        End If
    End Sub


    Private Sub txtExistencia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtExistencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtClasif.Focus()
            txtClasif.Select(0, txtClasif.Text.Length)
        End If
    End Sub

    Private Sub txtExistencia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtExistencia.TextChanged

    End Sub

    Private Sub txtClasif_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClasif.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtum.Focus()
            txtum.Select(0, txtum.Text.Length)
        End If
    End Sub

    Private Sub txtClasif_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClasif.TextChanged

    End Sub

    Private Sub txtum_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtum.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtPresen.Focus()
            txtPresen.Select(0, txtPresen.Text.Length)
        End If
    End Sub

    Private Sub txtum_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtum.TextChanged

    End Sub

    Private Sub txtPresen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPresen.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtCuenta.Focus()
            txtCuenta.Select(0, txtCuenta.Text.Length)
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtExistencia.Focus()
            txtExistencia.Select(0, txtExistencia.Text.Length)
        End If
    End Sub

    Private Sub txtDescripcion_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub txtDescripcion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDescripcion.Validating
        If Me.txtDescripcion.Text.Trim.Length = 0 Then
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique la descripción del item!"
            ErrorProvider1.SetError(Me.txtDescripcion, "Indique la descripción del item!")
            txtDescripcion.Select(0, txtDescripcion.Text.Length)
            Timer1.Enabled = True
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtDescripcion, "")
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Timer1.Enabled = False
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: Descripción." ' String.Empty
            Me.lblEstado.ForeColor = Color.Black
        End If
    End Sub

   
    Private Sub QRibbonApplicationButton1_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRibbonApplicationButton1.ItemActivating
        Try
            If lblEstado.Tag = "NEX" Then
                lblEstado.Text = "válidar la cuenta contable!"
                lblEstado.Image = My.Resources.warning2
            Else
                Dim objItem As New ItemDS(txtDescripcion.Text, txtClasifID.Text, txtPresenID.Text, txtumID.Text, txtExistenciaID.Text, txtCuentaID.Text)
                Select Case strEstadoManipulacion
                    Case ENTITY_ACTIONS.INSERT
                        GrabarItemEstablec(objItem)
                    Case ENTITY_ACTIONS.UPDATE
                        EditarItemEstablec(objItem)
                End Select
                Dispose()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try

     
    End Sub

    Private Sub txtCuentaID_Enter(sender As Object, e As System.EventArgs) Handles txtCuentaID.Enter
   
    End Sub

    Private Sub txtCuentaID_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaID.KeyDown
   
    End Sub

    Private Sub txtCuentaID_Load(sender As System.Object, e As System.EventArgs) Handles txtCuentaID.Load

    End Sub

    Private Sub txtCuentaID_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtCuentaID.MouseClick

    End Sub

    Private Sub txtCuentaID_MouseEnter(sender As Object, e As System.EventArgs) Handles txtCuentaID.MouseEnter
       
    End Sub

    Private Sub txtCuentaID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCuentaID.Validating
        If txtCuentaID.Text.Trim.Length > 0 Then
            If ACTDBSuggestions.Contains(txtCuentaID.Text.Trim) Then
                lblEstado.Text = "Ingreso correcto - cuenta contable"
                lblEstado.Image = My.Resources.ok4
                lblEstado.Tag = "EX"
                e.Cancel = False

            Else
                lblEstado.Text = "cuenta contable no existente!"
                lblEstado.Image = My.Resources.warning2
                lblEstado.Tag = "NEX"
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        If txtCuentaID.Text.Trim.Length > 0 Then
            If ACTDBSuggestions.Contains(txtCuentaID.Text.Trim) Then
                '  lblEstado.Text = "Ingreso correcto - cuenta contable"
                lblEstado.Image = My.Resources.ok4
                lblEstado.Tag = "EX"
                txtCuenta.Text = cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, txtCuentaID.Text).descripcion
            Else
                lblEstado.Text = "cuenta contable no existente!"
                lblEstado.Image = My.Resources.warning2
                lblEstado.Tag = "NEX"
                txtCuenta.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonCaption1.ItemActivated

    End Sub
End Class