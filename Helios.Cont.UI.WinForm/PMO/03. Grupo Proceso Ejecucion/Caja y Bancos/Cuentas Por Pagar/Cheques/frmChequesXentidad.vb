Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmChequesXentidad
    Inherits frmMaster

    Public Structure Proveedor
        Friend IdProveedor As Integer
        Friend NombreProveedor As String
    End Structure

    ''' <summary>
    ''' Variable set proveedor
    ''' </summary>
    ''' <remarks></remarks>
    Public cust As New Proveedor


#Region "Métodos"

    Private Sub DeshacerConciliacion(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCaja As New documentoCaja
        Dim documentoCaja2 As New documentoCaja
        Dim documento As New documento
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)


        Dim codCompra As String = documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento).First.documentoAfectado
        documentoCaja2 = documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)

        documento.idDocumento = intIdDocumento
        documento.IdDocumentoAfectado = codCompra
        documento.usuarioActualizacion = documentoCaja2.usuarioModificacion



        With documentoCaja
            .idDocumento = intIdDocumento
            .fechaCobro = Nothing
            .numeroOperacion = Nothing
            .entregado = "NO"
        End With

        'With cajaUsarioBE
        '    .idcajaUsuario = documentoCaja2.usuarioModificacion
        '    .otrosEgresosMN = CDec(txtImporteCompramn.Value)
        '    .otrosEgresosME = CDec(txtImporteComprame.Value)
        'End With
        'cajaUsariodetalleBE = New cajaUsuariodetalle
        'cajaUsariodetalleBE.idcajaUsuario = documentoCaja2.usuarioModificacion
        'cajaUsariodetalleBE.tipoDoc = DocumentoCompraSA.UbicarDocumentoCompra(codCompra).tipoDoc
        'cajaUsariodetalleBE.tipoVenta = TIPO_COMPRA.COMPRA_AL_CREDITO
        'cajaUsariodetalleBE.importeMN = CDec(txtImporteCompramn.Value)
        'cajaUsariodetalleBE.importeME = CDec(txtImporteComprame.Value)
        'cajaUsariodetalleListaBE.Add(cajaUsariodetalleBE)
        'cajaUsarioBE.cajaUsuariodetalle = cajaUsariodetalleListaBE


        '  Dim codCompra As String = documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(lblIdDocumento.Text).First.documentoAfectado


        documentoCajaSA.ConciliarCheque(documentoCaja, documento, Nothing)
        'PanelError.Visible = True
        'lblEstado.Text = "Conciliación eliminada!"
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
    End Sub

    Public Sub ListaChequesPeriodo()
        Dim dt As New DataTable()
        Dim personaSA As New PersonaSA
        '  Dim dt As New DataTable("Cheques - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim usuarioSA As New cajaUsuarioSA

        dt = New DataTable(cust.NombreProveedor)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaProceso", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("usuarioModificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("nomUser", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("entregado", GetType(String)))
        Dim str As String
        For Each row As documentoCaja In documentoCajaSA.ListaChequesPorProveedor(GEstableciento.IdEstablecimiento, cust.IdProveedor, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(row.fechaProceso).ToString("dd-MMM hh:mm tt ")
            dr(0) = row.idDocumento
            dr(1) = str
            dr(2) = row.NombreCaja
            dr(3) = row.tipoDocPago
            dr(4) = row.numeroDoc
            dr(5) = IIf(row.moneda = "1", "NAC", "USD")
            dr(6) = row.montoSoles
            dr(7) = row.montoUsd
            With usuarioSA.UbicarCajaUsuarioPorID(row.usuarioModificacion)
                dr(8) = row.usuarioModificacion
                dr(9) = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, .idPersona).nombreCompleto.ToLower
            End With
            If Not IsNothing(row.fechaCobro) Then
                dr(10) = CStr(row.fechaCobro)
            Else

            End If

            dr(11) = row.numeroOperacion
            dr(12) = row.entregado
            dt.Rows.Add(dr)
        Next

        'Dim parentTable As DataTable = getParentTableChequesPorPeriodo()
        'Me.dgvProforma.DataSource = parentTable
        dgvCheckes.DataSource = dt
        ' Me.dgvCheckes.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvCheckes.TableDescriptor.Relations.Clear()
        dgvCheckes.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvCheckes.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvCheckes.Appearance.AnyRecordFieldCell.Enabled = False
        dgvCheckes.GroupDropPanel.Visible = True
        dgvCheckes.TableDescriptor.GroupedColumns.Clear()
        dgvCheckes.TableDescriptor.GroupedColumns.Add("entregado")
        '   AddHandler dgvCheckes.TableControlCheckBoxClick, AddressOf gridGroupingControl1_TableControlCheckBoxClick
        '    dgvCheckes.TableDescriptor.GroupedColumns.Add("tipoDoc")
    End Sub
#End Region

    Private Sub frmChequesXentidad_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmChequesXentidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Dim docCaja As New documentoCaja
        Dim entidadSA As New entidadSA
        Dim documentoCajaSA As New DocumentoCajaSA

        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        Try
            If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
                docCaja.idDocumento = CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))
                docCaja.entregado = "SI"
                If documentoCajaSA.VerificarConciliarCheque(docCaja) = True Then
                    With documentoCajaSA.GetUbicar_documentoCajaPorID(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))
                        Dim form As New frmConciliarCheque
                        form.lblIdDocumento.Text = CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))
                        If form.TieneCuentaFinanciera(CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                            form.txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                            form.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                            form.txtTipoDoc.Text = "CHEQUE"
                            form.txtNumeroDoc.Text = .numeroDoc
                            form.txtMoneda.Text = IIf(.moneda = 1, "NAC", "USD")
                            form.lblIdProveedor = Nothing
                            form.lblNomProveedor = Nothing
                            form.lblCuentaProveedor = Nothing
                            With entidadSA.UbicarEntidadPorID(.codigoProveedor).First
                                form.lblIdProveedor = .idEntidad
                                form.lblNomProveedor = .nombreCompleto
                                form.lblCuentaProveedor = .cuentaAsiento
                            End With
                            form.txtImporteCompramn.Value = .montoSoles
                            form.txtImporteComprame.Value = .montoUsd
                            form.StartPosition = FormStartPosition.CenterParent
                            form.ShowDialog()
                            If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
                                If datos.Count > 0 Then
                                    Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 11).CellValue = datos(0).Codigo ' num operacion
                                    Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 10).CellValue = datos(0).NombreCampo 'fecha cobro
                                    Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 12).CellValue = "SI"
                                End If
                            End If
                        Else
                            'PanelError.Visible = True
                            'lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            'Timer1.Enabled = True
                            'TiempoEjecutar(10)
                        End If
                    End With
                End If


            End If
        Catch ex As Exception
            'PanelError.Visible = True
            'lblEstado.Text = ex.Message
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Dim docCaja As New documentoCaja
        Dim documentoCajaSA As New DocumentoCajaSA
        Try
            If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
                docCaja.idDocumento = CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))
                docCaja.entregado = "NO"
                If documentoCajaSA.VerificarConciliarCheque(docCaja) = True Then
                    DeshacerConciliacion(CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento")))
                    If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
                        Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 11).CellValue = String.Empty
                        Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 10).CellValue = String.Empty
                        Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 12).CellValue = "NO"
                    End If
                End If
            End If
        Catch ex As Exception
            'PanelError.Visible = True
            'lblEstado.Text = ex.Message
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub
End Class