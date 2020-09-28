Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmModulosUnidOrganicas

#Region "Atributos"

    Dim IdUnidOrganica As Integer
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructor"

    Sub New(ID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        IdUnidOrganica = ID

    End Sub

#End Region

#Region "Metodos"

    Public Sub ListarCargosPadre()
        Dim sa As New negocioComercial

        Dim consulta = sa.centroCostosXNComercial()

        'cboNegocioOrg.ValueMember = "IdNegocioComercial"
        'cboNegocioOrg.DisplayMember = "nombreRubro"
        'cboNegocioOrg.DataSource = consulta

    End Sub

    Private Sub GetListaDatosGenerales()
        Try
            Dim sa As New negocioComercialSA

            Dim dt As New DataTable("Datos Generales")
            dt.Columns.Add(New DataColumn("ID", GetType(String)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("tipo", GetType(String)))
            dt.Columns.Add(New DataColumn("agreagar", GetType(String)))

            Dim consulta = sa.GetListaNEgocioComercialXUnidOrg(New negocioComercial With {.IdCentroCosto = IdUnidOrganica})

            For Each i In consulta
                Dim dr As DataRow = dt.NewRow()

                dr(0) = (i.IdNegocioComercial)
                dr(1) = i.nombreRubro
                dr(2) = i.tipo
                dr(3) = i.seleccionNegocio

                dt.Rows.Add(dr)
            Next

            setDatasource(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvNumeracion.DataSource = table
        End If
    End Sub

#End Region


End Class