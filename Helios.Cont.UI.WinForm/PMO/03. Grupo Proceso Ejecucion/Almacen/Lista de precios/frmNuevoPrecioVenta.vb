Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class frmNuevoPrecioVenta
    Inherits frmMaster

    'Public Property txtAlmacen() As Integer
    Public Property lblDestino() As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CargraCombos()
        nudUtilidadPorc.Select()
    End Sub

#Region "Manipulación Data"
    Public Sub CargraCombos()
        Dim objLista As New TablaDetallesa

        Try
            cbomenor.DataSource = objLista.GetListaTablaDetalle(104, "1")
            cbomenor.DisplayMember = "descripcion"
            cbomenor.ValueMember = "codigoDetalle"

            cboMayor.DataSource = objLista.GetListaTablaDetalle(104, "1")
            cboMayor.DisplayMember = "descripcion"
            cboMayor.ValueMember = "codigoDetalle"

            cboGranMayor.DataSource = objLista.GetListaTablaDetalle(104, "1")
            cboGranMayor.DisplayMember = "descripcion"
            cboGranMayor.ValueMember = "codigoDetalle"


            cboXmenorSinIVA.DataSource = objLista.GetListaTablaDetalle(104, "1")
            cboXmenorSinIVA.DisplayMember = "descripcion"
            cboXmenorSinIVA.ValueMember = "codigoDetalle"

            cboXMayorNoIVA.DataSource = objLista.GetListaTablaDetalle(104, "1")
            cboXMayorNoIVA.DisplayMember = "descripcion"
            cboXMayorNoIVA.ValueMember = "codigoDetalle"

            cboXGMayorNoIva.DataSource = objLista.GetListaTablaDetalle(104, "1")
            cboXGMayorNoIva.DisplayMember = "descripcion"
            cboXGMayorNoIva.ValueMember = "codigoDetalle"
        Catch ex As Exception

        End Try
    End Sub

#End Region


    Private Sub Grabar()
        Dim TC As Decimal = txtTipoCambio.Value
        Dim objConfiEO As New listadoPrecios
        Dim ListadoSA As New ListadoPrecioSA
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim ListaPrecioFull As New List(Of listadoPrecios)

        Dim tipoExistencia As String
        Dim destinoGravado As String
        Dim presentacion As String
        Dim unidad As String

        Try

            With totalesAlmacenSA.GetUbicarProductoTAlmacen(txtAlmacenDestino.ValueMember, txtProducto.ValueMember)
                tipoExistencia = .tipoExistencia
                destinoGravado = .origenRecaudo
                presentacion = .Presentacion
                unidad = Nothing ' lblUnidad.Text
            End With

            objConfiEO = New listadoPrecios
            With objConfiEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                '      .idAlmacen = txtAlmacenDestino.ValueMember  ' frmListaPreciosExistencias.txtAlmacen.ValueMember

                .tipoExistencia = tipoExistencia
                .destinoGravado = destinoGravado
                .idItem = txtProducto.ValueMember ' frmListaPreciosExistencias.lsvListado.SelectedItems(0).SubItems(5).Text
                .descripcion = txtProducto.Text
                .presentacion = presentacion
                .unidad = Nothing ' lblUnidad.Text


                .fecha = txtFechaRegistro.Value
                .valcompraIgvMN = txtValorIngresoIVA.Text
                .valcompraIgvME = Math.Round(CDec(txtValorIngresoIVA.Text / TC), 2)

                .valcompraSinIgvMN = 0
                .valcompraSinIgvME = 0
                .tipoConfiguracion = "SIVA"

                .montoUtilidad = txtUtilidadIVA.Text
                .montoUtilidadME = Math.Round(CDec(txtUtilidadIVA.Text / TC), 2)

                .utilidadsinIgvMN = 0
                .utilidadsinIgvME = 0

                .valorVentaMN = txtValorVentaIVA.Text
                .valorVentaME = Math.Round(CDec(txtValorVentaIVA.Text / TC), 2)

                .igvMN = txtIVA.Text
                .iscMN = 0
                .otcMN = 0
                .igvME = Math.Round(CDec(txtIVA.Text / TC), 2)
                .iscME = 0
                .otcME = 0

                .precioVentaMN = txtPrecioVantaIVA.Text
                .precioVentaME = Math.Round(CDec(txtPrecioVantaIVA.Text / TC), 2)


                .PorDsctounitMenor = nupPorXMenorIVA.Value
                .montoDsctounitMenorMN = txtImporteXMenorIVA.Text
                .montoDsctounitMenorME = Math.Round(CDec(txtImporteXMenorIVA.Text / TC), 2)
                .precioVentaFinalMenorMN = txtPrecioFinalXMenorIVA.Text
                .precioVentaFinalMenorME = Math.Round(CDec(txtPrecioFinalXMenorIVA.Text / TC), 2)

                .PorDsctounitMayor = nupPorXMayorIVA.Value
                .montoDsctounitMayorMN = txtImporteXmayorIVA.Text
                .montoDsctounitMayorME = Math.Round(CDec(txtImporteXmayorIVA.Text / TC), 2)
                .precioVentaFinalMayorMN = txtPrecioFinalXmayotIVA.Text
                .precioVentaFinalMayorME = Math.Round(CDec(txtPrecioFinalXmayotIVA.Text / TC), 2)

                .PorDsctounitGMayor = nupPorXGmayorIVA.Value
                .montoDsctounitGMayorMN = txtImporteXGMayorIVA.Text
                .montoDsctounitGMayorME = Math.Round(CDec(txtImporteXGMayorIVA.Text / TC), 2)
                .precioVentaFinalGMayorMN = txtPrecioFinalXGMayorIVA.Text
                .precioVentaFinalGMayorME = Math.Round(CDec(txtPrecioFinalXGMayorIVA.Text / TC), 2)

                .detalleMenor = cbomenor.SelectedValue
                .detalleMayor = cboMayor.SelectedValue
                .detalleGMayor = cboGranMayor.SelectedValue

                .cantidadMenor = 0 ' nudMenor.Value
                .cantidadMayor = 0 'nudMayor.Value
                .cantidadGMayor = 0 ' nudGMayor.Value
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = Date.Now

                ListaPrecioFull.Add(objConfiEO)
            End With

            objConfiEO = New listadoPrecios
            With objConfiEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoExistencia = tipoExistencia
                .destinoGravado = destinoGravado
                .idItem = txtProducto.ValueMember ' frmListaPreciosExistencias.lsvListado.SelectedItems(0).SubItems(5).Text
                .descripcion = txtProducto.Text
                .presentacion = presentacion
                .unidad = Nothing ' lblUnidad.Text

                .fecha = txtFechaRegistro.Value
                .valcompraIgvMN = 0
                .valcompraIgvME = 0

                .valcompraSinIgvMN = txtValorIngresoNoIVA.Text
                .valcompraSinIgvME = Math.Round(CDec(txtValorIngresoNoIVA.Text / TC), 2)
                .tipoConfiguracion = "NIVA"

                .montoUtilidad = 0
                .montoUtilidadME = 0

                .utilidadsinIgvMN = txtUtilidadNoIVA.Text
                .utilidadsinIgvME = Math.Round(CDec(txtUtilidadNoIVA.Text / TC), 2)

                .valorVentaMN = txtPrecioVentaNoIVA.Text
                .valorVentaME = Math.Round(CDec(txtPrecioVentaNoIVA.Text / TC), 2)

                .igvMN = txtNoIVA.Text
                .iscMN = 0
                .otcMN = 0
                .igvME = Math.Round(CDec(txtNoIVA.Text / TC), 2)
                .iscME = 0
                .otcME = 0

                .precioVentaMN = txtPrecioVentaNoIVA.Text
                .precioVentaME = Math.Round(CDec(txtPrecioVentaNoIVA.Text / TC), 2)


                .PorDsctounitMenor = nupPorXmenorNoIVA.Value
                .montoDsctounitMenorMN = txtImporteXMenorNoIVA.Text
                .montoDsctounitMenorME = Math.Round(CDec(txtImporteXMenorNoIVA.Text / TC), 2)
                .precioVentaFinalMenorMN = txtPrecioFinalXMenorNoIVA.Text
                .precioVentaFinalMenorME = Math.Round(CDec(txtPrecioFinalXMenorNoIVA.Text / TC), 2)

                .PorDsctounitMayor = nupPorXMayorNoIVA.Value
                .montoDsctounitMayorMN = txtImporteXmayorNoIVA.Text
                .montoDsctounitMayorME = Math.Round(CDec(txtImporteXmayorNoIVA.Text / TC), 2)
                .precioVentaFinalMayorMN = txtPrecioFinalXmayotNoIVA.Text
                .precioVentaFinalMayorME = Math.Round(CDec(txtPrecioFinalXmayotNoIVA.Text / TC), 2)

                .PorDsctounitGMayor = nupPorXGMayorNoIVA.Value
                .montoDsctounitGMayorMN = txtImporteXGMayorNoIVA.Text
                .montoDsctounitGMayorME = Math.Round(CDec(txtImporteXGMayorNoIVA.Text / TC), 2)
                .precioVentaFinalGMayorMN = txtPrecioFinalXGMayorNoIVA.Text
                .precioVentaFinalGMayorME = Math.Round(CDec(txtPrecioFinalXGMayorNoIVA.Text / TC), 2)

                .detalleMenor = cboXmenorSinIVA.SelectedValue
                .detalleMayor = cboXMayorNoIVA.SelectedValue
                .detalleGMayor = cboXGMayorNoIva.SelectedValue

                .cantidadMenor = 0 ' nudMenor.Value
                .cantidadMayor = 0 'nudMayor.Value
                .cantidadGMayor = 0 ' nudGMayor.Value
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = Date.Now
                ListaPrecioFull.Add(objConfiEO)
            End With

            ListadoSA.InsertListadoPrecioSL(ListaPrecioFull)
            Dispose()

        Catch ex As Exception
            MsgBox("No se grabó correctamente." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub


    Private Sub frmNuevoPrecioVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If txtTipoCambio.Text > 0 Then

            If nudUtilidadPorc.Value > 0 Then

                If Not IsDate(txtFechaRegistro.Text) Then
                    MsgBox("Ingrese un formato válido.", MsgBoxStyle.Information, "Atención.!")
                    txtFechaRegistro.Focus()
                    '      txtFechaRegistro.Select(0, txtFechaRegistro.Text.Length)
                Else
                    If nupValorIngresoNeto.MaxLength > 0 Then
                        Grabar()
                    End If
                End If


            Else
                'lblEstado.Text = "Ingrese utilidad"
                'lblEstado.Visible = True
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
            End If

        Else

            'lblEstado.Text = "Ingrese Tipo de cambio"
            'lblEstado.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(5)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        With frmUltimasCompras
            .txtItem.ValueMember = txtProducto.ValueMember
            .txtItem.Text = txtProducto.Text
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub nudUtilidadPorc_KeyDown(sender As Object, e As KeyEventArgs) Handles nudUtilidadPorc.KeyDown
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nupValorIngresoNeto.Select()

            If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
                IGV = CDec(TmpIGV / 100)
                SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
                Utilidad = nudUtilidadPorc.Value
                PrecioUnitarioMN = nupValorIngresoNeto.Value

                SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
                txtValorIngresoIVA.Text = Math.Round(CDec(nupValorIngresoNeto.Value / SIVA), 2)
                txtUtilidadIVA.Text = Math.Round((Utilidad / 100) * (PrecioUnitarioMN / SIVA), 2)
                txtValorVentaIVA.Text = Math.Round(SIVAvalorVentaMN, 2)
                nupPorIVA.Value = TmpIGV
                txtIVA.Text = Math.Round(CDec(SIVAvalorVentaMN) * (IGV), 2)
                txtPrecioVantaIVA.Text = Math.Round(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV), 2)
                'nupPorXMenorIVA.value =
                txtImporteXMenorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100), 2)
                txtPrecioFinalXMenorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100)), 2)
                'nupPorXMayorIVA.value =
                txtImporteXmayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100), 2)
                txtPrecioFinalXmayotIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100)), 2)
                'nupPorXGmayorIVA.value =
                txtImporteXGMayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100), 2)
                txtPrecioFinalXGMayorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100)), 2)

                NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
                txtValorIngresoNoIVA.Text = CDec(nupValorIngresoNeto.Value)
                txtUtilidadNoIVA.Text = Math.Round(CDec(Utilidad / 100) * (PrecioUnitarioMN), 2)
                txtValorVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
                txtNoIVA.Text = Math.Round(CDec(NIVAvalorVentaMN) * (IGV), 2)
                nupPorNoIVA.Value = TmpIGV
                txtPrecioVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
                'nupPorXmenorNoIVA.value =
                txtImporteXMenorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100)), 2)
                txtPrecioFinalXMenorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100))), 2)
                'nupPorXMayorNoIVA.value =
                txtImporteXmayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100)), 2)
                txtPrecioFinalXmayotNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100))), 2)
                'nupPorXGMayorNoIVA.value = 
                txtImporteXGMayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100)), 2)
                txtPrecioFinalXGMayorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100))), 2)
            End If
        End If

    End Sub

    Private Sub nupValorIngresoNeto_KeyDown(sender As Object, e As KeyEventArgs) Handles nupValorIngresoNeto.KeyDown
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadPorc.Select()

            If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
                IGV = CDec(TmpIGV / 100)
                SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
                Utilidad = nudUtilidadPorc.Value
                PrecioUnitarioMN = nupValorIngresoNeto.Value

                SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
                txtValorIngresoIVA.Text = Math.Round(CDec(nupValorIngresoNeto.Value / SIVA), 2)
                txtUtilidadIVA.Text = Math.Round((Utilidad / 100) * (PrecioUnitarioMN / SIVA), 2)
                txtValorVentaIVA.Text = Math.Round(SIVAvalorVentaMN, 2)
                nupPorIVA.Value = TmpIGV
                txtIVA.Text = Math.Round(CDec(SIVAvalorVentaMN) * (IGV), 2)
                txtPrecioVantaIVA.Text = Math.Round(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV), 2)
                'nupPorXMenorIVA.value =
                txtImporteXMenorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100), 2)
                txtPrecioFinalXMenorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100)), 2)
                'nupPorXMayorIVA.value =
                txtImporteXmayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100), 2)
                txtPrecioFinalXmayotIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100)), 2)
                'nupPorXGmayorIVA.value =
                txtImporteXGMayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100), 2)
                txtPrecioFinalXGMayorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100)), 2)

                NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
                txtValorIngresoNoIVA.Text = CDec(nupValorIngresoNeto.Value)
                txtUtilidadNoIVA.Text = Math.Round(CDec(Utilidad / 100) * (PrecioUnitarioMN), 2)
                txtValorVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
                txtNoIVA.Text = Math.Round(CDec(NIVAvalorVentaMN) * (IGV), 2)
                nupPorNoIVA.Value = TmpIGV
                txtPrecioVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
                'nupPorXmenorNoIVA.value =
                txtImporteXMenorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100)), 2)
                txtPrecioFinalXMenorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100))), 2)
                'nupPorXMayorNoIVA.value =
                txtImporteXmayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100)), 2)
                txtPrecioFinalXmayotNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100))), 2)
                'nupPorXGMayorNoIVA.value = 
                txtImporteXGMayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100)), 2)
                txtPrecioFinalXGMayorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100))), 2)
            End If
        End If
    End Sub

    Private Sub nupPorIVA_KeyDown(sender As Object, e As KeyEventArgs) Handles nupPorIVA.KeyDown
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadPorc.Select()

            If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
                IGV = CDec(nupPorIVA.Value / 100)
                SIVA = Math.Round(CDec(nupPorIVA.Value / 100) + 1, 2)
                Utilidad = nudUtilidadPorc.Value
                PrecioUnitarioMN = nupValorIngresoNeto.Value

                SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
                nupPorNoIVA.Value = nupPorIVA.Value
                txtIVA.Text = Math.Round(CDec(SIVAvalorVentaMN) * (IGV), 2)
                txtPrecioVantaIVA.Text = Math.Round(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV), 2)


                txtImporteXMenorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100), 2)
                txtPrecioFinalXMenorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100)), 2)
                txtImporteXmayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100), 2)
                txtPrecioFinalXmayotIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100)), 2)
                txtImporteXGMayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100), 2)
                txtPrecioFinalXGMayorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100)), 2)

                NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
                txtValorIngresoNoIVA.Text = CDec(nupValorIngresoNeto.Value)
                txtUtilidadNoIVA.Text = Math.Round(CDec(Utilidad / 100) * (PrecioUnitarioMN), 2)
                txtValorVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
                txtNoIVA.Text = Math.Round(CDec(NIVAvalorVentaMN) * (IGV), 2)
                'nupPorNoIVA.Value = TmpIGV
                txtPrecioVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)

                txtImporteXMenorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100)), 2)
                txtPrecioFinalXMenorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100))), 2)
                txtImporteXmayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100)), 2)
                txtPrecioFinalXmayotNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100))), 2)
                txtImporteXGMayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100)), 2)
                txtPrecioFinalXGMayorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100))), 2)
            End If
        End If
    End Sub

    Private Sub nupPorIVA_ValueChanged(sender As Object, e As EventArgs) Handles nupPorIVA.ValueChanged
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
            IGV = CDec(nupPorIVA.Value / 100)
            SIVA = Math.Round(CDec(nupPorIVA.Value / 100) + 1, 2)
            Utilidad = nudUtilidadPorc.Value
            PrecioUnitarioMN = nupValorIngresoNeto.Value

            SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
            nupPorNoIVA.Value = nupPorIVA.Value
            txtIVA.Text = Math.Round(CDec(SIVAvalorVentaMN) * (IGV), 2)
            txtPrecioVantaIVA.Text = Math.Round(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV), 2)

            txtImporteXMenorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100), 2)
            txtPrecioFinalXMenorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100)), 2)
            txtImporteXmayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100), 2)
            txtPrecioFinalXmayotIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100)), 2)
            txtImporteXGMayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100), 2)
            txtPrecioFinalXGMayorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100)), 2)

            NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
            txtValorIngresoNoIVA.Text = CDec(nupValorIngresoNeto.Value)
            txtUtilidadNoIVA.Text = Math.Round(CDec(Utilidad / 100) * (PrecioUnitarioMN), 2)
            txtValorVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
            txtNoIVA.Text = Math.Round(CDec(NIVAvalorVentaMN) * (IGV), 2)
            'nupPorNoIVA.Value = TmpIGV
            txtPrecioVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)

            txtImporteXMenorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100)), 2)
            txtPrecioFinalXMenorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100))), 2)
            txtImporteXmayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100)), 2)
            txtPrecioFinalXmayotNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100))), 2)
            txtImporteXGMayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100)), 2)
            txtPrecioFinalXGMayorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100))), 2)
        End If

    End Sub

    Private Sub nudUtilidadPorc_ValueChanged(sender As Object, e As EventArgs) Handles nudUtilidadPorc.ValueChanged
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
            IGV = CDec(TmpIGV / 100)
            SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
            Utilidad = nudUtilidadPorc.Value
            PrecioUnitarioMN = nupValorIngresoNeto.Value

            SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
            txtValorIngresoIVA.Text = Math.Round(CDec(nupValorIngresoNeto.Value / SIVA), 2)
            txtUtilidadIVA.Text = Math.Round((Utilidad / 100) * (PrecioUnitarioMN / SIVA), 2)
            txtValorVentaIVA.Text = Math.Round(SIVAvalorVentaMN, 2)
            nupPorIVA.Value = TmpIGV
            txtIVA.Text = Math.Round(CDec(SIVAvalorVentaMN) * (IGV), 2)
            txtPrecioVantaIVA.Text = Math.Round(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV), 2)
            'nupPorXMenorIVA.value =
            txtImporteXMenorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100), 2)
            txtPrecioFinalXMenorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100)), 2)
            'nupPorXMayorIVA.value =
            txtImporteXmayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100), 2)
            txtPrecioFinalXmayotIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100)), 2)
            'nupPorXGmayorIVA.value =
            txtImporteXGMayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100), 2)
            txtPrecioFinalXGMayorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100)), 2)

            NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
            txtValorIngresoNoIVA.Text = CDec(nupValorIngresoNeto.Value)
            txtUtilidadNoIVA.Text = Math.Round(CDec(Utilidad / 100) * (PrecioUnitarioMN), 2)
            txtValorVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
            txtNoIVA.Text = Math.Round(CDec(NIVAvalorVentaMN) * (IGV), 2)
            nupPorNoIVA.Value = TmpIGV
            txtPrecioVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
            'nupPorXmenorNoIVA.value =
            txtImporteXMenorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100)), 2)
            txtPrecioFinalXMenorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100))), 2)
            'nupPorXMayorNoIVA.value =
            txtImporteXmayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100)), 2)
            txtPrecioFinalXmayotNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100))), 2)
            'nupPorXGMayorNoIVA.value = 
            txtImporteXGMayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100)), 2)
            txtPrecioFinalXGMayorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100))), 2)

        End If

    End Sub

    Private Sub nupValorIngresoNeto_ValueChanged(sender As Object, e As EventArgs) Handles nupValorIngresoNeto.ValueChanged
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
            IGV = CDec(TmpIGV / 100)
            SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
            Utilidad = nudUtilidadPorc.Value
            PrecioUnitarioMN = nupValorIngresoNeto.Value

            SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
            txtValorIngresoIVA.Text = Math.Round(CDec(nupValorIngresoNeto.Value / SIVA), 2)
            txtUtilidadIVA.Text = Math.Round((Utilidad / 100) * (PrecioUnitarioMN / SIVA), 2)
            txtValorVentaIVA.Text = Math.Round(SIVAvalorVentaMN, 2)
            nupPorIVA.Value = TmpIGV
            txtIVA.Text = Math.Round(CDec(SIVAvalorVentaMN) * (IGV), 2)
            txtPrecioVantaIVA.Text = Math.Round(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV), 2)
            'nupPorXMenorIVA.value =
            txtImporteXMenorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100), 2)
            txtPrecioFinalXMenorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100)), 2)
            'nupPorXMayorIVA.value =
            txtImporteXmayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100), 2)
            txtPrecioFinalXmayotIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100)), 2)
            'nupPorXGmayorIVA.value =
            txtImporteXGMayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100), 2)
            txtPrecioFinalXGMayorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100)), 2)

            NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
            txtValorIngresoNoIVA.Text = CDec(nupValorIngresoNeto.Value)
            txtUtilidadNoIVA.Text = Math.Round(CDec(Utilidad / 100) * (PrecioUnitarioMN), 2)
            txtValorVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
            txtNoIVA.Text = Math.Round(CDec(NIVAvalorVentaMN) * (IGV), 2)
            nupPorNoIVA.Value = TmpIGV
            txtPrecioVentaNoIVA.Text = Math.Round(NIVAvalorVentaMN, 2)
            'nupPorXmenorNoIVA.value =
            txtImporteXMenorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100)), 2)
            txtPrecioFinalXMenorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100))), 2)
            'nupPorXMayorNoIVA.value =
            txtImporteXmayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100)), 2)
            txtPrecioFinalXmayotNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100))), 2)
            'nupPorXGMayorNoIVA.value = 
            txtImporteXGMayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100)), 2)
            txtPrecioFinalXGMayorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100))), 2)
        End If
    End Sub

    Private Sub nupPorXMenorIVA_ValueChanged(sender As Object, e As EventArgs) Handles nupPorXMenorIVA.ValueChanged
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
            IGV = CDec(TmpIGV / 100)
            SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
            Utilidad = nudUtilidadPorc.Value
            PrecioUnitarioMN = nupValorIngresoNeto.Value

            SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
            txtImporteXMenorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100), 2)
            txtPrecioFinalXMenorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100)), 2)
        End If
    End Sub

    Private Sub nupPorXMenorIVA_KeyDown(sender As Object, e As KeyEventArgs) Handles nupPorXMenorIVA.KeyDown
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim IGV As Decimal
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadPorc.Select()

            If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
                IGV = CDec(TmpIGV / 100)
                SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
                Utilidad = nudUtilidadPorc.Value
                PrecioUnitarioMN = nupValorIngresoNeto.Value

                SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
                txtImporteXMenorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100), 2)
                txtPrecioFinalXMenorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMenorIVA.Value / 100)), 2)
            End If
        End If
    End Sub

    Private Sub nupPorXMayorIVA_ValueChanged(sender As Object, e As EventArgs) Handles nupPorXMayorIVA.ValueChanged
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
            IGV = CDec(TmpIGV / 100)
            SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
            Utilidad = nudUtilidadPorc.Value
            PrecioUnitarioMN = nupValorIngresoNeto.Value

            SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
            'nupPorXMayorIVA.value =
            txtImporteXmayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100), 2)
            txtPrecioFinalXmayotIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100)), 2)
        End If
    End Sub

    Private Sub nupPorXMayorIVA_KeyDown(sender As Object, e As KeyEventArgs) Handles nupPorXMayorIVA.KeyDown
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadPorc.Select()

            If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
                IGV = CDec(TmpIGV / 100)
                SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
                Utilidad = nudUtilidadPorc.Value
                PrecioUnitarioMN = nupValorIngresoNeto.Value

                SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
                txtImporteXmayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100), 2)
                txtPrecioFinalXmayotIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXMayorIVA.Value / 100)), 2)
            End If
        End If
    End Sub

    Private Sub nupPorXGmayorIVA_ValueChanged(sender As Object, e As EventArgs) Handles nupPorXGmayorIVA.ValueChanged
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
            IGV = CDec(TmpIGV / 100)
            SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
            Utilidad = nudUtilidadPorc.Value
            PrecioUnitarioMN = nupValorIngresoNeto.Value

            SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
            txtImporteXGMayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100), 2)
            txtPrecioFinalXGMayorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100)), 2)

        End If
    End Sub

    Private Sub nupPorXGmayorIVA_KeyDown(sender As Object, e As KeyEventArgs) Handles nupPorXGmayorIVA.KeyDown
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim SIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadPorc.Select()

            If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
                IGV = CDec(TmpIGV / 100)
                SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
                Utilidad = nudUtilidadPorc.Value
                PrecioUnitarioMN = nupValorIngresoNeto.Value

                SIVAvalorVentaMN = CDec((PrecioUnitarioMN / SIVA) + ((PrecioUnitarioMN / SIVA) * (Utilidad / 100)))
                txtImporteXGMayorIVA.Text = Math.Round(CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100), 2)
                txtPrecioFinalXGMayorIVA.Text = Math.Round(CDec(SIVAvalorVentaMN + (SIVAvalorVentaMN * IGV)) - (CDec(PrecioUnitarioMN / SIVA) * CDec(nupPorXGmayorIVA.Value / 100)), 2)
            End If
        End If
    End Sub

    Private Sub nupPorXmenorNoIVA_ValueChanged(sender As Object, e As EventArgs) Handles nupPorXmenorNoIVA.ValueChanged
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
            IGV = CDec(TmpIGV / 100)
            SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
            Utilidad = nudUtilidadPorc.Value
            PrecioUnitarioMN = nupValorIngresoNeto.Value

            NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
            txtImporteXMenorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100)), 2)
            txtPrecioFinalXMenorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100))), 2)
        End If
    End Sub

    Private Sub nupPorXmenorNoIVA_KeyDown(sender As Object, e As KeyEventArgs) Handles nupPorXmenorNoIVA.KeyDown
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadPorc.Select()

            If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
                IGV = CDec(TmpIGV / 100)
                SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
                Utilidad = nudUtilidadPorc.Value
                PrecioUnitarioMN = nupValorIngresoNeto.Value

                NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
                txtImporteXMenorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100)), 2)
                txtPrecioFinalXMenorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXmenorNoIVA.Value / 100))), 2)
            End If
        End If
    End Sub

    Private Sub nupPorXMayorNoIVA_ValueChanged(sender As Object, e As EventArgs) Handles nupPorXMayorNoIVA.ValueChanged
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
            IGV = CDec(TmpIGV / 100)
            SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
            Utilidad = nudUtilidadPorc.Value
            PrecioUnitarioMN = nupValorIngresoNeto.Value

            NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
            txtImporteXmayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100)), 2)
            txtPrecioFinalXmayotNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100))), 2)
        End If
    End Sub

    Private Sub nupPorXMayorNoIVA_KeyDown(sender As Object, e As KeyEventArgs) Handles nupPorXMayorNoIVA.KeyDown
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadPorc.Select()

            If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
                IGV = CDec(TmpIGV / 100)
                SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
                Utilidad = nudUtilidadPorc.Value
                PrecioUnitarioMN = nupValorIngresoNeto.Value

                NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
                txtImporteXmayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100)), 2)
                txtPrecioFinalXmayotNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXMayorNoIVA.Value / 100))), 2)
            End If
        End If
    End Sub

    Private Sub nupPorXGMayorNoIVA_ValueChanged(sender As Object, e As EventArgs) Handles nupPorXGMayorNoIVA.ValueChanged
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
            IGV = CDec(TmpIGV / 100)
            SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
            Utilidad = nudUtilidadPorc.Value
            PrecioUnitarioMN = nupValorIngresoNeto.Value

            NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
            txtImporteXGMayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100)), 2)
            txtPrecioFinalXGMayorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100))), 2)
        End If
    End Sub

    Private Sub nupPorXGMayorNoIVA_KeyDown(sender As Object, e As KeyEventArgs) Handles nupPorXGMayorNoIVA.KeyDown
        Dim SIVA As Decimal = 0
        Dim Utilidad As Decimal = 0
        Dim PrecioUnitarioMN As Decimal = 0
        Dim NIVAvalorVentaMN As Decimal
        Dim IGV As Decimal

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadPorc.Select()

            If (nupValorIngresoNeto.MaxLength > 0 And nudUtilidadPorc.MaxLength >= 0) Then
                IGV = CDec(TmpIGV / 100)
                SIVA = Math.Round(CDec(TmpIGV / 100) + 1, 2)
                Utilidad = nudUtilidadPorc.Value
                PrecioUnitarioMN = nupValorIngresoNeto.Value

                NIVAvalorVentaMN = CDec((PrecioUnitarioMN) + ((PrecioUnitarioMN) * (Utilidad / 100)))
                txtImporteXGMayorNoIVA.Text = Math.Round(CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100)), 2)
                txtPrecioFinalXGMayorNoIVA.Text = Math.Round((NIVAvalorVentaMN) - (CDec(PrecioUnitarioMN * CDec(nupPorXGMayorNoIVA.Value / 100))), 2)
            End If
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class