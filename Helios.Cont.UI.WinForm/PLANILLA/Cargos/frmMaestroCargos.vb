Imports Helios.General
Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Grouping

Public Class frmMaestroCargos

#Region "Attributes"
    Private Property CargosSA As New CargosSA
    Public Property Action As BaseBE.EntityAction
    Private SelCargo As New Cargos
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridPequeño(dgIngresos, True)
        GetCargos()
    End Sub

    Public Sub New(IdCargo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        UbicarCargo(IdCargo)
    End Sub

#End Region

#Region "Methods"
    Private Sub UbicarCargo(idCargo As Integer)
        SelCargo = New Cargos
        SelCargo = CargosSA.CargosSelxID(New Planilla.Business.Entity.Cargos With {.IDCargo = idCargo})
        If Not IsNothing(SelCargo) Then
            txtAbreviatura.Text = SelCargo.DescripcionCorta
            txtDetalle.Text = SelCargo.DescripcionLargo
            Action = BaseBE.EntityAction.UPDATE
        End If
    End Sub

    Private Sub GetCargos()
        dgIngresos.DataSource = CargosSA.CargosSelAll()
    End Sub

    Private Sub GrabarCargo()
        Dim codigoCargo As Integer = 0
        If Action = BaseBE.EntityAction.UPDATE Then
            codigoCargo = SelCargo.IDCargo
            Action = BaseBE.EntityAction.UPDATE
        Else
            codigoCargo = 0
            Action = BaseBE.EntityAction.INSERT
        End If
        CargosSA.CargosSave(New Planilla.Business.Entity.Cargos With
                            {
                            .Action = Action,
                            .IDCargo = codigoCargo,
                            .DescripcionCorta = txtAbreviatura.Text.Trim,
                            .DescripcionLargo = txtDetalle.Text.Trim,
                            .Importe = 0,
                            .UsuarioModificacion = usuario.IDUsuario,
                            .FechaModificacion = Date.Now
                            }, UserManager.TransactionData)

        If Action = BaseBE.EntityAction.UPDATE Then
            dgIngresos.Table.CurrentRecord.SetValue("DescripcionCorta", txtAbreviatura.Text.Trim)
            dgIngresos.Table.CurrentRecord.SetValue("DescripcionLargo", txtDetalle.Text.Trim)
        Else
            GetCargos()
        End If
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If txtAbreviatura.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtAbreviatura, "Ingrese el nombre del cargo")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtAbreviatura, Nothing)
        End If

        If txtDetalle.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtDetalle, "Ingrese el detalle del cargo")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtDetalle, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        GetCargos()
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If ValidarGrabado() = True Then
            GrabarCargo()
        End If
    End Sub

    Private Sub dgIngresos_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgIngresos.TableControlCellClick

    End Sub

    Private Sub dgIngresos_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgIngresos.SelectedRecordsChanged
        If Not IsNothing(e.SelectedRecord) Then
            UbicarCargo(Integer.Parse(e.SelectedRecord.Record.GetValue("IDCargo")))
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        txtAbreviatura.Clear()
        txtDetalle.Clear()
        Action = BaseBE.EntityAction.INSERT
    End Sub

#End Region

End Class