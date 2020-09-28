Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FrmProductosConexos

    Public Sub New(listaProducts As List(Of totalesAlmacen))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(DgvProducts, False, False)
        GeLSVProducts(listaProducts)
    End Sub

    Private Sub GeLSVProducts(listaProducts As List(Of totalesAlmacen))
        Dim dt As New DataTable

        With dt.Columns
            .Add("ID")
            .Add("descripcion")
            .Add("unidad")
            .Add("cantidad")
        End With
        For Each i In listaProducts
            dt.Rows.Add(i.idMovimiento,
                        i.descripcion,
                        i.unidadMedida,
                        i.tipoExistencia)
        Next
        DgvProducts.DataSource = dt
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If DgvProducts.Table.Records.Count > 0 Then
            If txtProductoNew.Text.Trim.Length > 0 Then
                Grabar()
            Else
                MsgBox("Debe identificar el producto padre!", MsgBoxStyle.Exclamation, "Identificar producto")
            End If
        Else
            MsgBox("Debe tener productos en la canasta", MsgBoxStyle.Exclamation, "Validar productos")
        End If
    End Sub

    Private Sub Grabar()
        Dim totalesSA As New TotalesAlmacenSA
        Dim lista As New List(Of totalesAlmacen)
        Dim tipo As String = Nothing
        Select Case cboTipo.Text
            Case "OFERTA"
                tipo = "O"
            Case "PROMOCION"
                tipo = "P"
            Case "NEGOCIACION"
                tipo = "N"
            Case "REGALO"
                tipo = "R"
        End Select

        For Each i In DgvProducts.Table.Records
            If i.GetValue("ID") = txtProductoNew.Tag Then
                lista.Add(New totalesAlmacen With {
                      .idMovimiento = i.GetValue("ID"),
                      .TipoAcces = "P"
                      })
            Else
                lista.Add(New totalesAlmacen With {
                      .idMovimiento = i.GetValue("ID"),
                      .TipoAcces = "H",
                      .cantidad2 = CDec(i.GetValue("cantidad")),
                      .tipoEnlace = tipo
                      })
            End If
        Next
        totalesSA.ProductosConexos(lista)
        Close()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If DgvProducts.Table.Records.Count > 0 Then
            With DgvProducts.Table.CurrentRecord
                txtProductoNew.Tag = .GetValue("ID")
                txtProductoNew.Text = .GetValue("descripcion")
                TxtUnid.Text = .GetValue("unidad")
            End With
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If DgvProducts.Table.Records.Count > 0 Then
            DgvProducts.Table.CurrentRecord.Delete()
        End If
    End Sub
End Class