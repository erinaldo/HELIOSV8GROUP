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
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing

Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Public Class frmEntregable
    Inherits frmMaster

    Public Property IdProyecto() As Integer
    Public Property Manipulacion() As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadCombos()
    End Sub

    Public Sub New(idCosto As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadCombos()
        UbicarEntregable(idCosto)
    End Sub

#Region "Métodos"

    Sub UbicarEntregable(idCosto As Integer)
        Dim costo As New recursoCosto
        Dim costoSA As New recursoCostoSA
        Dim item As New detalleitems
        Dim itemSA As New detalleitemsSA

        costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = idCosto})
        If Not IsNothing(costo) Then
            Dim codProd = costo.codigo
            If Not IsNothing(codProd) Then
                If codProd.ToString.Trim.Length > 0 Then
                    item = itemSA.InvocarProductoID(costo.codigo)
                    If Not IsNothing(item) Then
                        txtDetalleItem.Text = item.descripcionItem
                        txtDetalleItem.Tag = item.codigodetalle
                        cboRecurso.SelectedValue = item.tipoExistencia
                        cboUM.SelectedValue = item.unidad1
                    End If
                End If
            End If
            txtEntregable.Text = costo.nombreCosto
            txtEntregable.Tag = costo.idCosto
            txtCantidad.DoubleValue = costo.cantidad.GetValueOrDefault
            txtDetalle.Text = costo.detalle
            txtFechaEntrega.Value = costo.finaliza.GetValueOrDefault
        End If

    End Sub

    Sub LoadCombos()
        Dim tablaSA As New tablaDetalleSA
        Dim listaTablas As New List(Of tabladetalle)

        listaTablas = tablaSA.GetListaTablaDetalle(5, "1")
        Dim array() As String = {TipoExistencia.ProductoTerminado, TipoExistencia.SubProductosDesechos}

        Dim lista2 = (From n In listaTablas _
                     Where array.Contains(n.codigoDetalle)).ToList

        cboRecurso.DataSource = lista2
        cboRecurso.DisplayMember = "descripcion"
        cboRecurso.ValueMember = "codigoDetalle"

        cboUM.DisplayMember = "descripcion"
        cboUM.ValueMember = "codigoDetalle2"
        cboUM.DataSource = tablaSA.GetListaTablaDetalle(6, "1")

    End Sub

    Sub Grabar()
        Dim proceso As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        proceso = New recursoCosto
        proceso.idpadre = IdProyecto
        proceso.tipo = "PT"
        proceso.subtipo = "PT"
        proceso.status = StatusProductosTerminados.Pendiente ' StatusCosto.Avance_Obra_Cartera
        proceso.nombreCosto = txtEntregable.Text.Trim
        proceso.codigo = txtDetalleItem.Tag
        proceso.detalle = txtDetalle.Text.Trim
        proceso.subdetalle = Nothing
        proceso.inicio = Nothing
        proceso.finaliza = txtFechaEntrega.Value
        proceso.procesado = "N"
        proceso.presupuesto = StatusPresupestoProyecto.Abierto
        If txtCantidad.DoubleValue <= 0 Then
            MessageBox.Show("Debe ingresar una cantidad > 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        proceso.cantidad = txtCantidad.DoubleValue
        proceso.precUnit = 0 ' CDec(r.GetValue("pu"))
        proceso.costo = 0 'CDec(r.GetValue("costo"))
        proceso.almacen = 0 ' Val(r.GetValue("almacen"))
        proceso.usuarioActualizacion = usuario.IDUsuario
        proceso.fechaActualizacion = DateTime.Now

        recursoSA.GrabarEntregable(proceso)
        MessageBox.Show("Entregable grabado con existo!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dispose()

    End Sub

    Sub Editar()
        Dim proceso As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        proceso = New recursoCosto
        proceso.idCosto = Val(txtEntregable.Tag)
        proceso.idpadre = IdProyecto
        proceso.tipo = "PT"
        proceso.subtipo = "PT"
        proceso.status = StatusProductosTerminados.Pendiente ' StatusCosto.Avance_Obra_Cartera
        proceso.nombreCosto = txtEntregable.Text.Trim
        proceso.codigo = txtDetalleItem.Tag
        proceso.detalle = txtDetalle.Text.Trim
        proceso.subdetalle = Nothing
        proceso.inicio = Nothing
        proceso.finaliza = txtFechaEntrega.Value
        proceso.procesado = "N"
        If txtCantidad.DoubleValue <= 0 Then
            MessageBox.Show("Debe ingresar una cantidad > 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        proceso.cantidad = txtCantidad.DoubleValue
        proceso.precUnit = 0 ' CDec(r.GetValue("pu"))
        proceso.costo = 0 'CDec(r.GetValue("costo"))
        proceso.almacen = 0 ' Val(r.GetValue("almacen"))
        proceso.usuarioActualizacion = usuario.IDUsuario
        proceso.fechaActualizacion = DateTime.Now

        recursoSA.EditarEntregable(proceso)
        MessageBox.Show("Entregable grabado con existo!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dispose()

    End Sub
#End Region

    Private Sub frmEntregable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Select Case Manipulacion
            Case ENTITY_ACTIONS.INSERT
                Grabar()
            Case ENTITY_ACTIONS.UPDATE
                Editar()
        End Select

        Cursor = Cursors.Arrow
    End Sub

    Private Sub frmEntregable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New frmBusquedaExistencia
        f.cboTipoExistencia.SelectedValue = TipoExistencia.ProductoTerminado
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, detalleitems)
            txtEntregable.Text = c.descripcionItem
            txtDetalleItem.Text = c.descripcionItem
            txtDetalleItem.Tag = c.codigodetalle
            cboUM.SelectedValue = c.unidad1
            cboRecurso.SelectedValue = c.tipoExistencia
        Else

        End If
    End Sub
End Class