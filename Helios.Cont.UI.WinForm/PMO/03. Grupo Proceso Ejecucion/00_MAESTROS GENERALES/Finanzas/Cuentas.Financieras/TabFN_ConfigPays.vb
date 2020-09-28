Imports Helios.General
Public Class TabFN_ConfigPays

#Region "Variables"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridPagos, False, False, 11.0F)
    End Sub
#End Region


#Region "Methdos"
    Sub GetDataPays()
        Dim dt As New DataTable
        dt.Columns.Add("cuenta")
        dt.Columns.Add("identidad")
        dt.Columns.Add("entidad")
        dt.Columns.Add("codigocontable")
        dt.Columns.Add("importe")

        Dim efectivo = ListConfigurationPays.Where(Function(o) o.tipo = "EF").SingleOrDefault

        If efectivo IsNot Nothing Then
            dt.Rows.Add("EFECTIVO", efectivo.identidad, efectivo.entidad, String.Empty, 0)
        Else
            dt.Rows.Add("EFECTIVO", 0, String.Empty, String.Empty, 0)
        End If

        dt.Rows.Add("DEPOSITO", 0, String.Empty, String.Empty, 0)
        dt.Rows.Add("TARJETA", 0, String.Empty, String.Empty, 0)
        dt.Rows.Add("CHEQUE", 0, String.Empty, String.Empty, 0)
        dt.Rows.Add("VALE", 0, String.Empty, String.Empty, 0)
        dt.Rows.Add("COMPENSACION", 0, String.Empty, String.Empty, 0)

        GridPagos.DataSource = dt
    End Sub
#End Region

#Region "Events"

#End Region

End Class
