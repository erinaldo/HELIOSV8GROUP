Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmAddNumeracion
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CMOB()
    End Sub

#Region "Métodos"

    Sub CMOB()
        Dim tablaSA As New tablaDetalleSA

        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(10, "1")

    End Sub

    Public Sub GrabarSerieModulo()
        Dim numeracionSA As New NumeracionBoletaSA
        Dim numeracion As New numeracionBoletas

        With numeracion
            .empresa = Gempresas.IdEmpresaRuc
            .establecimiento = GEstableciento.IdEstablecimiento
            .codigoNumeracion = CodModulo
            .tipo = cboTipoDoc.SelectedValue
            .serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieNew.Text))
            .valorInicial = nudValInicialNew.Value
            .valorMinimo = 0
            .valorMaximo = 1000000000
            .incremento = nudValIncrementoNew.Value

            If CodModulo = "VT2" Then
                .tipo1 = "01"
                .serie1 = String.Format("{0:00000}", Convert.ToInt32(txtSerieFac.Text.Trim))
                .valorInicial1 = nudValInicial2.Value
                .valorMinimo1 = 0
                .valorMaximo1 = 1000000000
                .incremento1 = nudValIncremento2.Value
            End If
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        numeracionSA.InsertNumBoletas(numeracion)
    End Sub
#End Region

    Public Property CodModulo() As String

    Private Sub frmAddNumeracion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAddNumeracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If Not txtSerieNew.Text.Trim.Length > 0 Then
            txtSerieNew.Select()
            MessageBox.Show("Ingrese un numero de serie", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If CodModulo = "VT2" Then
            If Not txtSerieFac.Text.Trim.Length > 0 Then
                txtSerieFac.Select()
                MessageBox.Show("Ingrese un numero de serie de la factura", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        GrabarSerieModulo()
    End Sub
End Class