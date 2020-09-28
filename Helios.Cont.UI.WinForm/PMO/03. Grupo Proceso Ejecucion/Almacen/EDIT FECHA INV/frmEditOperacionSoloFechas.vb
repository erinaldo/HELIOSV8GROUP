Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Public Class frmEditOperacionSoloFechas
    Inherits frmMaster

    Public Property idDocumentoRef As Integer
    Public Property CodInventario As Integer

    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UbicarDocumento(intIdDocumento)
    End Sub

#Region "Métodos"

    Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim tablaSA As New tablaDetalleSA

        With documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)
            idDocumentoRef = .idDocumento
            txtComprobante.Text = tablaSA.GetUbicarTablaID(10, .tipoOperacion).descripcion
            txtOperacion.Text = tablaSA.GetUbicarTablaID(12, .tipoOperacion).descripcion
            txtfecOper.Text = .fechaDoc
            txtNewperiodo.Value = New DateTime(.fechaDoc.Value.Year, .fechaDoc.Value.Month, DateTime.Now.Day)
        End With

    End Sub

    Sub ActulizarFechaOperaciones(strOperacion As String)
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New documentocompra
        Select Case strOperacion
            Case "COMPRA", "OTRAS ENTRADAS A ALMACEN", "TRANSFERENCIA ENTRE ALMACENES", "OTRAS SALIDAS DE ALMACEN", "NC-DISMINUIR CANTIDAD", "NC-DISMINUIR IMPORTE", "NC-DISMINUIR CANTIDAD E IMPORTE", "NC-DEVOLUCION DE EXISTENCIAS"
                documentoCompra.idDocumento = idDocumentoRef
                documentoCompra.idPadre = CodInventario
                documentoCompra.fechaDoc = txtFecha.Value
                documentoCompra.fechaContable = String.Format("{0:00}", CInt(txtNewperiodo.Value.Year)) & "/" & txtNewperiodo.Value.Month
                'documentoCompraSA.ActulizarFechaOperaciones(documentoCompra)
            Case "VENTA" ', "OTRAS SALIDAS DE ALMACEN"

            Case "APORTES"

        End Select

        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

    Private Sub frmEditOperacionSoloFechas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmEditOperacionSoloFechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        ActulizarFechaOperaciones(txtOperacion.Text.Trim)
        Me.Cursor = Cursors.Arrow
    End Sub
End Class