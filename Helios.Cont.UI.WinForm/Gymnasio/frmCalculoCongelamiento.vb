Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class frmCalculoCongelamiento
    Protected Friend idDocumentoGlobal As Integer
    Public Sub New(lista As List(Of String), idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Calculo(lista)
        idDocumentoGlobal = idDocumento
    End Sub

    Sub Calculo(lista As List(Of String))
        ListView2.Items.Clear()
        'Agregando a listview
        '---------------------------------------------------------------------
        For x As Integer = 0 To lista.Count - 1 Step 2
            Dim n As New ListViewItem(lista(x))
            n.SubItems.Add(lista(x + 1))
            n.SubItems.Add(DateDiff(DateInterval.Day, CDate(lista(x)), CDate(lista(x + 1))) + 1)
            ListView2.Items.Add(n)
        Next
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Grabar()
    End Sub

    Private Sub Grabar()
        Dim lista As New List(Of membresia_congelamiento)

        For Each i As ListViewItem In ListView2.Items
            lista.Add(New membresia_congelamiento With
                      {
                      .idDocumento = idDocumentoGlobal,
                      .fecha = Date.Now,
                      .fechainicio = CDate(i.SubItems(0).Text),
                      .fechafin = CDate(i.SubItems(1).Text),
                      .costo = 0,
                      .usuarioActualizacion = usuario.IDUsuario,
                      .fechaActualizacion = Date.Now
                      })
        Next
        membresia_congelamientoSA.GrabarGrupoCongelamiento(lista)
        MessageBox.Show("Registro correcto")
        Close()
    End Sub
End Class