
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Public Class FormOtroDocumentoRelacion
    Private Sub FormOtroDocumentoRelacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim OBJ As New OTROSTIPODOCUMENTO
        Dim LISTA As New List(Of OTROSTIPODOCUMENTO)


        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "0"
        OBJ.Valor = " "
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "1"
        OBJ.Valor = "NÚMERO DE ORDEN DE ENTREGA"
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "2"
        OBJ.Valor = "NÚMERO DE SCOP"
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "3"
        OBJ.Valor = "NÚMERO DE MANIFIESTO DE CARGA"
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "4"
        OBJ.Valor = "NÚMERO DE CONSTANCIA DE DETRACCIÓN"
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "5"
        OBJ.Valor = "OTROS"
        LISTA.Add(OBJ)

        cbOtroDocRelac.DataSource = LISTA
        cbOtroDocRelac.ValueMember = "Codigo"
        cbOtroDocRelac.DisplayMember = "Valor"
    End Sub

    Private Sub btnGuarOtroDoc_Click(sender As Object, e As EventArgs) Handles btnGuarOtroDoc.Click
        If txtotroDocNum.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtotroDocNum, "Ingrese un NUMERO de documento")
        ElseIf cbOtroDocRelac.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(cbOtroDocRelac, "Ingrese un TIPO de documento")


        Else
            Dim traslado As New OTROSTIPODOCUMENTO With {
        .Codigo = cbOtroDocRelac.SelectedValue,
        .Valor = cbOtroDocRelac.Text,
        .NumDoc = txtotroDocNum.Text
        }
            Tag = traslado

            Me.Close()
        End If


    End Sub
End Class