Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class UCModulos

#Region "Atributos"
    Public Property FrmConfiguracionPerfil As FrmConfiguracionPerfil
#End Region

#Region "Constructor"
    Sub New(be As FrmConfiguracionPerfil)

        ' This call is required by the designer.
        InitializeComponent()
        FrmConfiguracionPerfil = be
        ' Add any initialization after the InitializeComponent() call.
        ListarAsegurable()
    End Sub
#End Region

#Region "Metodos"

    Public Sub ListarAsegurable()

        Dim sa As New AsegurableSA

        Dim consulta = sa.ListadoAsegurables()




        Dim dt As New DataTable("Lista - modulos")
        dt.Columns.Add(New DataColumn("IDAsegurable", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))

        For Each i In consulta
            Dim dr As DataRow = dt.NewRow()


            dr(0) = i.IDAsegurable
            dr(1) = i.Nombre
            dr(2) = i.Descripcion
            dt.Rows.Add(dr)
        Next
        dgPermisos.DataSource = dt

    End Sub


#End Region

End Class
