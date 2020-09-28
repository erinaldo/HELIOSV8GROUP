Imports Helios.Cont.Business.Entity

Public Class UCHospedados
    Public Sub GetDetallePersonaBeneficio(ListaEntidad As List(Of personaBeneficio))
        ListInventario.Items.Clear()

        For Each i In ListaEntidad
            Dim n As New ListViewItem(i.idPersonaBeneficio)
            n.SubItems.Add(i.nombrePersona)
            n.SubItems.Add(i.nroDocumento.GetValueOrDefault)
            n.SubItems.Add(i.nacionalidad)
            n.SubItems.Add(i.sexo)
            ListInventario.Items.Add(n)
        Next
    End Sub


    Public Sub GetDetallePersonaBeneficioID(ListaEntidad As List(Of personaBeneficio), ID As Integer)
        ListInventario.Items.Clear()

        Dim CONSULTA = ListaEntidad.Where(Function(O) O.distribucionID = ID)

        For Each i In CONSULTA
            Dim n As New ListViewItem(i.idPersonaBeneficio)
            n.SubItems.Add(i.nombrePersona)
            n.SubItems.Add(i.nroDocumento.GetValueOrDefault)
            n.SubItems.Add(i.nacionalidad)
            n.SubItems.Add(i.sexo)
            ListInventario.Items.Add(n)
        Next
    End Sub

End Class
