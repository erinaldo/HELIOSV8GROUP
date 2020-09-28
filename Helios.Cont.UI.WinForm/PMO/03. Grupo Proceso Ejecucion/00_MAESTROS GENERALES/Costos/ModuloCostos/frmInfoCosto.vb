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
Public Class frmInfoCosto
    Inherits frmMaster

    Public Sub New(intIdPadreSec As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetInfoItemComprobante(intIdPadreSec)
    End Sub

#Region "mÉTODOS"
    Public Sub GetInfoItemComprobante(intIdPadreSec As Integer)
        Dim compraDeta As New documentocompradetalle
        Dim compraDetSA As New DocumentoCompraDetalleSA
        Dim recursoSA As New recursoCostoSA
        Dim recurso As New recursoCosto
        Dim compra As New documentocompra
        Dim compraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Try

            compraDeta = compraDetSA.GetUbicar_documentocompradetallePorID(intIdPadreSec)

            compra = compraSA.UbicarDocumentoCompra(compraDeta.idDocumento)
            txtfecha.Text = compra.fechaDoc
            txtTipoDoc.Text = compra.tipoDoc
            txtNro.Text = compra.serie & "-" & compra.numeroDoc
            txtMoned.Text = compra.monedaDoc
            txttipocambio.Text = compra.tcDolLoc
            txtmontoMN.Text = compra.importeTotal
            txtmontoME.Text = compra.importeUS
            txtProveedor.Text = entidadSA.UbicarEntidadPorID(compra.idProveedor).FirstOrDefault.nombreCompleto

            If Not IsNothing(compraDeta) Then
                txtitem.Text = compraDeta.descripcionItem
                recurso = recursoSA.GetCostoById(New recursoCosto With {.idCosto = compraDeta.idCosto})
                If Not IsNothing(recurso) Then
                    txtCosto.Text = recurso.nombreCosto
                Else
                    txtCosto.Text = "Sin asignar"
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmInfoCosto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmInfoCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dispose()
    End Sub
End Class