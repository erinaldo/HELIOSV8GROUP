Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmViewNota
    Inherits frmMaster

    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UbicarDocumento(intIdDocumento)
    End Sub

#Region "Métodos"
    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle
        Dim compra As New documentocompra
        Dim tablaSA As New tablaDetalleSA
        Try
            'DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            'If Not IsNothing(DocumentoGuia) Then
            '    With DocumentoGuia
            '        txtSerieGuia.Text = .Serie
            '        txtNumeroGuia.Text = .Numero
            '    End With
            'End If

            'CABECERA COMPROBANTE
            lblRucEmpresa.Text = "R.U.C. N° " & Gempresas.IdEmpresaRuc
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                lblFecNota.Text = .fechaDoc
                'lblIdDocumento.Text = .idDocumento
                PeriodoGeneral = .fechaContable
                lblNumeroNota.Text = .serie & "-" & .numeroDoc
                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                lblRucEntidad.Text = nEntidad.nrodoc
                lblEntidad.Text = nEntidad.nombreCompleto

                txtTotalBase.DecimalValue = .bi01
                TXTiVA.DecimalValue = .igv01
                txtTotal.DecimalValue = .importeTotal
                compra = objDocCompra.UbicarDocumentoCompra(.idPadre)
                lblDocCompra.Text = tablaSA.GetUbicarTablaID(10, compra.tipoDoc).descripcion
                lblNumCompra.Text = compra.serie & "-" & compra.numeroDoc
                lblFecCompra.Text = compra.fechaDoc
            End With

            'DETALLE DE LA COMPRA
            ListView1.Items.Clear()
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)
                Dim n As New ListViewItem(i.monto1)
                n.UseItemStyleForSubItems = False
                With n.SubItems.Add(i.descripcionItem)
                    .Font = New Font("Segoe UI Semibold", 7.5, Drawing.FontStyle.Regular Or Drawing.FontStyle.Italic)
                    .ForeColor = Color.Black
                End With
                Select Case i.operacionNota
                    Case "9913"
                        With n.SubItems.Add("DISMINUIR CANTIDAD")
                            .Font = New Font("Segoe UI Semibold", 7.5, Drawing.FontStyle.Regular Or Drawing.FontStyle.Italic)
                            .ForeColor = Color.Black
                        End With
                    Case "9914"
                        With n.SubItems.Add("DISMINUIR IMPORTE")
                            .Font = New Font("Segoe UI Semibold", 7.5, Drawing.FontStyle.Regular Or Drawing.FontStyle.Italic)
                            .ForeColor = Color.Black
                        End With
                    Case "9916"
                        With n.SubItems.Add("DEVOLUCION DE EXISTENCIAS")
                            .Font = New Font("Segoe UI Semibold", 7.5, Drawing.FontStyle.Regular Or Drawing.FontStyle.Italic)
                            .ForeColor = Color.Black
                        End With
                    Case "9925"
                        With n.SubItems.Add("DESCUENTOS OBTENIDOS POR PRONTO PAGO")
                            .Font = New Font("Segoe UI Semibold", 7.5, Drawing.FontStyle.Regular Or Drawing.FontStyle.Italic)
                            .ForeColor = Color.Black
                        End With

                End Select
                n.SubItems.Add(i.precioUnitario)
                n.SubItems.Add(i.importe)
                ListView1.Items.Add(n)
            Next
         
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub
#End Region

    Private Sub frmViewNota_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmViewNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class