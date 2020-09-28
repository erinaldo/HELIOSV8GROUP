Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormContratoAsignaUsuario

    Public Sub New(comision As detalleitemcatalogo_comision)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetControlsMapping()
        _Comision = comision
    End Sub

    Public ReadOnly Property _Comision As detalleitemcatalogo_comision

#Region "Méthods"
    Public Sub GetControlsMapping()
        ComboUsuarios.DataSource = UsuariosList
        ComboUsuarios.DisplayMember = "Full_Name"
        ComboUsuarios.ValueMember = "IDUsuario"
    End Sub

    Private Sub Grabar()
        Dim SA As New detalleitemcatalogo_comisiondetalleSA
        Dim obj As New detalleitemcatalogo_comisiondetalle
        obj.Action = BaseBE.EntityAction.INSERT
        obj.idComision = _Comision.idComision
        obj.IdUsuario = Integer.Parse(ComboUsuarios.SelectedValue)
        obj.tipoUsuario = "U"
        obj.vence = DateVigencia.Value
        obj.bloqueado = False
        obj.moneda = If(ComboMoneda.Text = "NACIONAL", "1", "2")
        obj.formaEntregaPago = If(ComboFormaPago.Text = "DEPOSITO", "D", "E")
        obj.dias_restringidos = GetDiasRestringidos()
        obj.importe_comisionMN = NumericValorComisionMN.Value
        obj.importe_comisionME = NumericValorComisionME.Value
        Dim entity = SA.detalleitemcatalogo_comisiondetalleSave(obj)
        MessageBox.Show("Usuario asigando a comisión!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Tag = entity
        Close()
    End Sub

    Private Function GetDiasRestringidos() As String
        Dim lista = GetListaRestricciones()
        Dim result As String = String.Empty
        If lista IsNot Nothing And lista.Count > 0 Then
            result = String.Join(",", lista)
        End If
        Return result
    End Function

    Private Function GetListaRestricciones() As List(Of String)
        GetListaRestricciones = New List(Of String)
        If (CheckL.Checked) Then
            GetListaRestricciones.Add("L")
        End If

        If (CheckM.Checked) Then
            GetListaRestricciones.Add("M")
        End If
        If (CheckMI.Checked) Then
            GetListaRestricciones.Add("MI")
        End If

        If (CheckJ.Checked) Then
            GetListaRestricciones.Add("J")
        End If

        If (CheckV.Checked) Then
            GetListaRestricciones.Add("V")
        End If

        If (CheckS.Checked) Then
            GetListaRestricciones.Add("S")
        End If

        If (CheckD.Checked) Then
            GetListaRestricciones.Add("D")
        End If

    End Function

#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Grabar()
    End Sub


#End Region

End Class