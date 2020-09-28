
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class FormCobrarVentaVendedor
#Region "Attributes"
    Public Property BeneficioProduccionSA As New BeneficioProduccionConsumoSA
    Public Property ListaBeneficios As List(Of Business.Entity.beneficio)
    Public Property beneficioSA As New beneficioSA
    ' Public ListaEstadosFinancieros As List(Of estadosFinancieros)
    Public Property ListaAsientonTransito As New List(Of asiento)
    Dim entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Public Property listaClientes As List(Of entidad)
    Public Property TipoVentaGeneral As String
    'Public Property GridVenta As GridGroupingControl
    'Public TotalesXcanbeceras As TotalesXcanbecera
    Public Grid As GridGroupingControl
    Public Totales As TotalesXcanbecera
    Public Property formventa As FormVentaVendedorGeneral
    Public Property pagoAnticipo As documentoAnticipo
    Private listaAnticipoDetalle As List(Of documentoAnticipoConciliacion)
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F2
                btGrabar.PerformClick()
            Case Keys.F3
                ToolImportar.PerformClick()
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region

#Region "Constructors"
    Public Sub New(Grid As GridGroupingControl, Totales As TotalesXcanbecera, form As FormVentaVendedorGeneral)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCuentas, False, False, 10.0F)
        'GetColumnsGrid()
        ''GridVenta = Grid
        'formventa = form
        'Me.KeyPreview = True
        ''TotalesXcanbeceras = New TotalesXcanbecera
        ''TotalesXcanbeceras = Totales
        'threadClientes()
        'cargarCajas()
        'GetUbicarClienteGeneral()
    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Events"

#End Region
End Class