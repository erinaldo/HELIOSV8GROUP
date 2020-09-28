Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormConfiguracionPago
#Region "Variables"
    Public listaCajas As List(Of estadosFinancieros)
    Dim cuentasSA As New EstadosFinancierosSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCuentas, False, False, 10.5F)
        GetMappingColumnsGrid()
        listaCajas = New List(Of estadosFinancieros)

        listaCajas = cuentasSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XEmpresa})
        cboCajas.Enabled = True
        CboFormaPago.Enabled = True
        ChEfectivo.Checked = True
        PagosLoading()
    End Sub
#End Region

#Region "MEthods"
    Private Sub GetMappingColumnsGrid()
        Dim dt As New DataTable
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("moneda")
        End With

        For Each i In SA.GetConfigurationPay(New estadosFinancierosConfiguracionPagos With
                                             {
                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                             .idEstablecimiento = GEstableciento.IdEstablecimiento
                                             })
            'dt.Rows.Add(String.Empty, i.identidad, i.entidad, i.IDFormaPago, i.FormaPago)

            If i.moneda = "1" Then
                dt.Rows.Add(i.tipoCaja, i.identidad, i.entidad, i.IDFormaPago, i.FormaPago, "NACIONAL")
            Else
                dt.Rows.Add(i.tipoCaja, i.identidad, i.entidad, i.IDFormaPago, i.FormaPago, "EXTRANJERA")
            End If
        Next
        dgvCuentas.DataSource = dt
    End Sub

    Private Sub GetComboCuentas(listaCajas As List(Of estadosFinancieros))
        'Dim especial = listaCajas.Where(Function(o) o.tipo = "EE").ToList
        'listaCajas.AddRange(especial)

        cboCajas.DataSource = listaCajas
        cboCajas.DisplayMember = "descripcion"
        cboCajas.ValueMember = "idestado"
    End Sub

    Private Sub PagosLoading()

        Dim Efectivo As New List(Of String)
        Efectivo.Add("EF")
        Efectivo.Add("EP")

        If ChEfectivo.Checked = True AndAlso ChBanco.Checked = True Then
            Dim lista = listaCajas.ToList
            GetComboCuentas(lista)
        ElseIf ChEfectivo.Checked = True AndAlso ChBanco.Checked = False Then
            'Dim lista = listaCajas.Where(Function(o) o.tipo = "EF").ToList
            Dim lista = listaCajas.Where(Function(o) Efectivo.Contains(o.tipo)).ToList
            GetComboCuentas(lista)
        ElseIf ChEfectivo.Checked = False AndAlso ChBanco.Checked = True Then
            Dim lista = listaCajas.Where(Function(o) o.tipo <> "EF").ToList
            lista = lista.Where(Function(o) o.tipo <> "EP").ToList
            GetComboCuentas(lista)
        End If
    End Sub

    Private Sub ValidaCajaDuplicada()
        For Each i In dgvCuentas.Table.Records
            If Integer.Parse(i.GetValue("identidad")) = cboCajas.SelectedValue And Integer.Parse(i.GetValue("idforma")) = CboFormaPago.SelectedValue Then
                Throw New Exception("No puede agregar la caja seleccionada, ya está agregada.")
            End If
        Next
    End Sub

    Private Sub AgregarCaja()

        Dim caja = cuentasSA.GetUbicar_estadosFinancierosPorID(cboCajas.SelectedValue)

        Me.dgvCuentas.Table.AddNewRecord.SetCurrent()
        Me.dgvCuentas.Table.AddNewRecord.BeginEdit()
        Me.dgvCuentas.Table.CurrentRecord.SetValue("tipo", caja.tipo)
        Me.dgvCuentas.Table.CurrentRecord.SetValue("identidad", caja.idestado)
        Me.dgvCuentas.Table.CurrentRecord.SetValue("entidad", caja.descripcion)
        Me.dgvCuentas.Table.CurrentRecord.SetValue("idforma", CboFormaPago.SelectedValue)
        Me.dgvCuentas.Table.CurrentRecord.SetValue("formaPago", CboFormaPago.Text)
        If caja.codigo = "1" Then

            Me.dgvCuentas.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
        ElseIf caja.codigo = "2" Then
            Me.dgvCuentas.Table.CurrentRecord.SetValue("moneda", "EXTRANJERA")
        End If
        Me.dgvCuentas.Table.AddNewRecord.EndEdit()
        dgvCuentas.Table.TableDirty = True
    End Sub

    Private Sub GrabarConfiguracionPagos()
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        Dim lista As New List(Of estadosFinancierosConfiguracionPagos)
        Dim obj As estadosFinancierosConfiguracionPagos
        For Each i In dgvCuentas.Table.Records
            obj = New estadosFinancierosConfiguracionPagos
            obj.idEmpresa = Gempresas.IdEmpresaRuc
            obj.idEstablecimiento = GEstableciento.IdEstablecimiento
            obj.identidad = Integer.Parse(i.GetValue("identidad"))
            Select Case i.GetValue("tipo")
                Case "EE"
                    obj.tipo = "EE"
                Case Else
                    obj.tipo = i.GetValue("idforma").ToString()
            End Select

            obj.tipoCaja = i.GetValue("tipo")
            obj.fecha = Date.Now
            obj.entidad = i.GetValue("entidad").ToString()
            obj.usuarioActualizacion = usuario.IDUsuario
            obj.fechaActualizacion = Date.Now

            If i.GetValue("moneda").ToString() = "NACIONAL" Then
                obj.moneda = "1"
            ElseIf i.GetValue("moneda").ToString() = "EXTRANJERA" Then
                obj.moneda = "2"
            End If

            lista.Add(obj)
        Next
        SA.GrabarConfiguracionList(lista)
        MessageBox.Show("Configuración grabada", "Grabado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ListConfigurationPays = New List(Of estadosFinancierosConfiguracionPagos)
        ListConfigurationPays = SA.GetConfigurationPay(New estadosFinancierosConfiguracionPagos With
                {
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                                                           })
        ListaCuentasFinancierasConfiguradas = ListConfigurationPays
        Close()
    End Sub
#End Region

#Region "Events"
    Private Sub ChEfectivo_OnChange(sender As Object, e As EventArgs) Handles ChEfectivo.OnChange
        PagosLoading()
    End Sub

    Private Sub ChBanco_OnChange(sender As Object, e As EventArgs) Handles ChBanco.OnChange
        PagosLoading()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Try
            If cboCajas.Text.Trim.Length > 0 Then
                ValidaCajaDuplicada()
                AgregarCaja()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validar cajas")
        End Try
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If dgvCuentas.Table.CurrentRecord IsNot Nothing Then
            dgvCuentas.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim CODIGO As Integer = 0
        Dim cajausuarioSA As New cajaUsuarioSA
        Try
            If ListaCuentasFinancierasConfiguradas.Count > 0 Then
                Dim conf = ListaCuentasFinancierasConfiguradas.First.idConfiguracion

                Dim estadoSA As New EstadosFinancierosConfiguracionPagosSA
                '  CODIGO = estadoSA.BuscarConfiguracionCreada(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, conf)
                Dim request = estadoSA.ConfiguracionTieneCajasActivas(conf)
                If request = True Then
                    If MessageBox.Show("Cerrar todas las cajas activas ?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim FormCajaActivas As New FormCajaActivas(ListaCajasActivas)
                        FormCajaActivas.StartPosition = FormStartPosition.CenterParent
                        FormCajaActivas.ShowDialog(Me)

                        If dgvCuentas.Table.Records.Count > 0 Then
                            GrabarConfiguracionPagos()
                        Else
                            MsgBox("Debe agregar cuentas a la canasta", MsgBoxStyle.Critical, "Validar cajas")
                        End If

                    End If
                Else
                    If dgvCuentas.Table.Records.Count > 0 Then
                        GrabarConfiguracionPagos()
                    Else
                        MsgBox("Debe agregar cuentas a la canasta", MsgBoxStyle.Critical, "Validar cajas")
                    End If
                End If
            Else
                If dgvCuentas.Table.Records.Count > 0 Then
                    GrabarConfiguracionPagos()
                Else
                    MsgBox("Debe agregar cuentas a la canasta", MsgBoxStyle.Critical, "Validar cajas")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboCajas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCajas.SelectedValueChanged
        Dim codigo As Object
        codigo = cboCajas.SelectedValue
        If IsNumeric(codigo) Then
            GetFillComboFormaPago(codigo)
        End If
    End Sub

    Private Sub GetFillComboFormaPago(codigo As Integer)
        Dim entidadSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(codigo)
        Select Case ef.tipo
            Case "BC", "TC"
                Dim tablas() As String = {"001", "003", "005", "006", "007", "011", "102", "111", "9993"}
                CboFormaPago.DataSource = tablaSA.GetListaTablaDetalle(1, "1").Where(Function(o) tablas.Contains(o.codigoDetalle)).ToList
                CboFormaPago.DisplayMember = "descripcion"
                CboFormaPago.ValueMember = "codigoDetalle"
                CboFormaPago.SelectedValue = "001"
            Case "EF", "EP"
                Dim tablas() As String = {"004", "008", "009", "109", "9903", "9991"}
                CboFormaPago.DataSource = tablaSA.GetListaTablaDetalle(1, "1").Where(Function(o) tablas.Contains(o.codigoDetalle)).ToList
                CboFormaPago.DisplayMember = "descripcion"
                CboFormaPago.ValueMember = "codigoDetalle"
                CboFormaPago.SelectedValue = "109"

        End Select
    End Sub

#End Region
End Class