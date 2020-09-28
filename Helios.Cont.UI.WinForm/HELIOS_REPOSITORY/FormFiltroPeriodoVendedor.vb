Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormFiltroPeriodoVendedor
#Region "Atributos"

    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA

#End Region

#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        datetimeFecha.Value = DateTime.Now
        ' Add any initialization after the InitializeComponent() call.
        GetMeses()
    End Sub
#End Region

#Region "methods"
    Sub GetMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = General.ListaDeMeses
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        TExtAnio.DecimalValue = DateTime.Now.Year

        cboVendedores.DataSource = UsuariosList
        cboVendedores.ValueMember = "IDUsuario"
        cboVendedores.DisplayMember = "Nombres"

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim datos As List(Of item) = item.Instance()
        datos.Clear()
        Dim c As New item

        Dim periodo As New Date(TExtAnio.DecimalValue, CInt(cboMesCompra.SelectedValue), 1)
        Tag = periodo


        c.tipo = cboTipoBusqueda.Text


        If c.tipo = "PERIODO" Then
            c.fechaActualizacion = periodo
        ElseIf c.tipo = "DIA" Then
            c.fechaActualizacion = datetimeFecha.Value
        End If
        c.descripcion = cboTipoOperacion.Text
        c.idEntidad = cboVendedores.SelectedValue

        datos.Add(c)

        Close()
    End Sub

    Private Sub cboTipoBusqueda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoBusqueda.SelectedValueChanged
        Select Case cboTipoBusqueda.Text
            Case "PERIODO"
                datetimeFecha.Visible = False
                lblTipoBusqueda.Text = "Seleccione Periodo:"
                cboMesCompra.Visible = True
                TExtAnio.Visible = True
            Case "DIA"
                lblTipoBusqueda.Text = "Seleccione una Fecha:"
                cboMesCompra.Visible = False
                TExtAnio.Visible = False
                datetimeFecha.Visible = True
                datetimeFecha.Value = DateTime.Now
        End Select
    End Sub

    Private Sub cboTipoBusqueda_Click(sender As Object, e As EventArgs) Handles cboTipoBusqueda.Click

    End Sub




#End Region
End Class