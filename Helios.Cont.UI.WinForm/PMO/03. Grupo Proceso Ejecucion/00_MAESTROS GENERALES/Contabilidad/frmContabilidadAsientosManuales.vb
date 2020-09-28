Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class frmContabilidadAsientosManuales

#Region "Attributes"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property empresaPeriodoSA As New empresaPeriodoSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaPeriodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral

        FormatoGridPequeño(dgvCompra, True)
    End Sub
#End Region

#Region "Methods"

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCompra.DataSource = table
            Me.dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            ProgressBar1.Visible = False
        End If
    End Sub

    Public Sub ListadoItems(periodo As String)
        Dim listadoSA As New documentoLibroDiarioSA
        Dim objeto As New tablaDetalleSA
        Dim dt As New DataTable()
        Dim entidadSA As New entidadSA
        Dim personaSA As New Helios.Planilla.WCFService.ServiceAccess.PersonalSA

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoBen", GetType(String))
        dt.Columns.Add("beneficiario", GetType(String))
        dt.Columns.Add("tipodoc", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoc", GetType(Decimal))
        dt.Columns.Add("importemn", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechavct", GetType(Date))
        dt.Columns.Add("idBene", GetType(Integer))
        dt.Columns.Add("identificacion", GetType(String))



        'Dim str As String
        For Each i In listadoSA.ListarGastosModulo("GXM", periodo) 'periodo
            Dim dr As DataRow = dt.NewRow()
            'str = Nothing
            'If Not IsNothing(i.fecha) Then
            '    str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
            'End If
            dr(0) = i.idDocumento
            dr(1) = i.infoReferencial

            If IsNothing(i.razonSocial) Then

            Else
                Select Case i.tipoRazonSocial
                    Case TIPO_ENTIDAD.PROVEEDOR
                        dr(2) = "Proveedor"
                        With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                            dr(3) = .nombreCompleto
                        End With
                    Case TIPO_ENTIDAD.CLIENTE
                        dr(2) = "Cliente"
                        With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                            dr(3) = .nombreCompleto
                        End With
                    Case "TR"
                        dr(2) = "Trabajador"
                        With personaSA.PersonalSelxID(New Planilla.Business.Entity.Personal With {.IDPersonal = i.razonSocial})
                            '       dr(3) = .FullName
                        End With
                End Select
            End If


            dr(4) = "VOUCHER CONTABLE"
            dr(5) = i.nroDoc

            If i.moneda = "1" Then
                dr(6) = "NACIONAL"

            ElseIf i.moneda = "2" Then

                dr(6) = "EXTRANJERO"
            End If

            dr(7) = i.tipoCambio
            dr(8) = i.importeMN

            dr(9) = i.importeME
            dr(10) = i.fecha
            dr(11) = i.fechaVct


            If IsNothing(i.razonSocial) Then
                dr(13) = "N"
            Else
                dr(12) = i.razonSocial
                dr(13) = "S"
            End If
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)

    End Sub

    Public Sub EliminarGastoModulo(iddocumento As Integer)
        Dim objeto As New documentoLibroDiarioSA

        objeto.DeleteLibroDiario(iddocumento)

    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim cierreSA As New empresaCierreMensualSA
        Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If cboMesCompra.Text.Trim.Length > 0 Then
            With frmGastoXModulos
                .txtPeriodo.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                .txtFecha.Value = New DateTime(cboAnio.Text, Integer.Parse(cboMesCompra.SelectedValue), 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                ButtonAdv19_Click(sender, e)
            End With
        Else
            MessageBox.Show("Debe seleccionar un período válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim periodo = cboMesCompra.SelectedValue & "/" & Integer.Parse(cboAnio.Text)
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() ListadoItems(periodo)))
        thread.Start()
    End Sub

    Private Sub ButtonAdv12_Click(sender As Object, e As EventArgs) Handles ButtonAdv12.Click
        Dim cierreSA As New empresaCierreMensualSA
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            With frmGastoXModulos
                .txtPeriodo.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                .UbicarDocumento(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                .lblIdDocumento.Text = dgvCompra.Table.CurrentRecord.GetValue("idDocumento")


                If dgvCompra.Table.CurrentRecord.GetValue("identificacion") = "S" Then
                    .txtProveedor.Tag = dgvCompra.Table.CurrentRecord.GetValue("idBene")
                    .txtProveedor.Text = dgvCompra.Table.CurrentRecord.GetValue("beneficiario")
                    .CheckBox2.Checked = True
                End If

                .cboMoneda.ReadOnly = True
                .txtFecha.ReadOnly = True
                .ComboBoxAdv2.ReadOnly = True
                .txtPeriodo.ReadOnly = True
                .txtGlosa.ReadOnly = True
                .txtProveedor.ReadOnly = True
                .txtRuc.ReadOnly = True
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                ButtonAdv19_Click(sender, e)
            End With
        End If
    End Sub

    Private Sub ButtonAdv13_Click(sender As Object, e As EventArgs) Handles ButtonAdv13.Click
        Dim cierreSA As New empresaCierreMensualSA

        Me.Cursor = Cursors.WaitCursor
        Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
            EliminarGastoModulo(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
            dgvCompra.Table.CurrentRecord.Delete()
            ButtonAdv19_Click(sender, e)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub
#End Region


    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim cierreSA As New empresaCierreMensualSA
        Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If cboMesCompra.Text.Trim.Length > 0 Then
            With frmGastoCostoModulo
                .txtPeriodo.Text = cboMesCompra.SelectedValue & "/" & cboAnio.Text
                .txtFecha.Value = New DateTime(cboAnio.Text, Integer.Parse(cboMesCompra.SelectedValue), 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                ButtonAdv19_Click(sender, e)
            End With
        Else
            MessageBox.Show("Debe seleccionar un período válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class