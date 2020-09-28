Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCanastaNotas
#Region "Métodos"
    Public Sub UbicarDetalle(intIddocumento As Integer)
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Dim cCantidadNC As Decimal = 0
        Dim cCantidadDB As Decimal = 0
        Dim cTotalCantidad As Decimal = 0
        Try
            lsvCanasta.Items.Clear()
            For Each i As documentocompradetalle In detalleSA.UbicarDocumentoCompraDetalle(intIddocumento)
               
                Dim n As New ListViewItem(i.secuencia)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcionItem)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.unidad2)
                n.SubItems.Add(i.monto1)
                n.SubItems.Add(i.importe)
                n.SubItems.Add(i.importeUS)
                If IsNothing(i.almacenRef) Then
                    n.SubItems.Add("Sin asignar")
                Else
                    n.SubItems.Add(i.almacenRef)
                End If
                n.SubItems.Add(i.preEvento)
                n.SubItems.Add(i.tipoExistencia)
                '-------------------------------------------------------------------
                If IsNothing(i.notaCreditoMN) Then
                    n.SubItems.Add(0)
                    cCreditomn = 0
                Else
                    n.SubItems.Add(i.notaCreditoMN)
                    cCreditomn = i.notaCreditoMN
                End If

                If IsNothing(i.notaCreditoME) Then
                    n.SubItems.Add(0)
                    cCreditome = 0
                Else
                    n.SubItems.Add(i.notaCreditoME)
                    cCreditome = i.notaCreditoME
                End If

                If IsNothing(i.notaDebitoMN) Then
                    n.SubItems.Add(0)
                    cDebitomn = 0
                Else
                    n.SubItems.Add(i.notaDebitoMN)
                    cDebitomn = i.notaDebitoMN
                End If

                If IsNothing(i.notaDebitoME) Then
                    n.SubItems.Add(0)
                    cDebitome = 0
                Else
                    n.SubItems.Add(i.notaDebitoME)
                    cDebitome = i.notaDebitoME
                End If
                cTotalmn = Math.Round(CDec(i.importe) - cCreditomn + cDebitomn, 2)
                cTotalme = Math.Round(CDec(i.importeUS) - cCreditome + cDebitome, 2)
                n.SubItems.Add(cTotalmn)
                n.SubItems.Add(cTotalme)

                If IsNothing(i.cantidadCredito) Then
                    n.SubItems.Add(0)
                    cCantidadNC = 0
                Else
                    n.SubItems.Add(i.cantidadCredito)
                    cCantidadNC = i.cantidadCredito
                End If

                If IsNothing(i.cantidadDebito) Then
                    n.SubItems.Add(0)
                    cCantidadDB = 0
                Else
                    n.SubItems.Add(i.cantidadDebito)
                    cCantidadDB = i.cantidadDebito
                End If
                cTotalCantidad = Math.Round(CDec(i.monto1) - cCantidadNC + cCantidadDB, 2)
                n.SubItems.Add(cTotalCantidad)
                lsvCanasta.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub lsvCanasta_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvCanasta.MouseDoubleClick
        Dim nInsumoSA As New detalleitemsSA
        Dim n As New GInsumo()
        Dim tablaSA As New tablaDetalleSA
        Dim objInsumo As GInsumo = GInsumo.InstanceSingle
        Try
            If lsvCanasta.SelectedItems.Count > 0 Then

                objInsumo.Clear()
                objInsumo.Secuencia = lsvCanasta.SelectedItems(0).SubItems(0).Text
                If CStr(lsvCanasta.SelectedItems(0).SubItems(9).Text).Trim.Length > 0 Then
                    objInsumo.IdActividadRecurso = lsvCanasta.SelectedItems(0).SubItems(9).Text
                End If
                objInsumo.IdInsumo = lsvCanasta.SelectedItems(0).SubItems(1).Text
                objInsumo.descripcionItem = lsvCanasta.SelectedItems(0).SubItems(2).Text
                objInsumo.tipoExistencia = lsvCanasta.SelectedItems(0).SubItems(10).Text
                objInsumo.unidad1 = lsvCanasta.SelectedItems(0).SubItems(3).Text
                objInsumo.Cantidad = lsvCanasta.SelectedItems(0).SubItems(19).Text
                objInsumo.PU = 0 ' lsvCanasta.SelectedItems(0).SubItems(6).Text
                objInsumo.Total = lsvCanasta.SelectedItems(0).SubItems(15).Text
                With nInsumoSA.InvocarProductoID(lsvCanasta.SelectedItems(0).SubItems(1).Text)
                    objInsumo.origenProducto = .origenProducto
                    objInsumo.cuenta = .cuenta
                    objInsumo.presentacion = .presentacion
                    objInsumo.Nombrepresentacion = tablaSA.GetUbicarTablaID(21, .presentacion).descripcion
                End With
                objInsumo.IdAlmacen = lsvCanasta.SelectedItems(0).SubItems(8).Text
                Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
       
    End Sub

    Private Sub lsvCanasta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvCanasta.SelectedIndexChanged

    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonCaption1.ItemActivated

    End Sub

    Private Sub frmCanastaNotas_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        colCantidad.Width = 0
        colImportemn.Width = 0
        colImporteme.Width = 0
        colNotaMn.Width = 0
        colNotaME.Width = 0
        colDebitoMN.Width = 0
        colNBMe.Width = 0
        colCanCredito.Width = 0
        colCantDebito.Width = 0
    End Sub
End Class