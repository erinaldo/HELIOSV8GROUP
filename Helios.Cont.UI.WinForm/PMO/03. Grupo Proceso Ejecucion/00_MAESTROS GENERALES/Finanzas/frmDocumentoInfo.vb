Imports Helios.Cont.Business.Entity
Imports Helios.General
Public Class frmDocumentoInfo

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New(Operacion As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Select Case Operacion.ToString
            Case StatusTipoOperacion.COMPRA

            Case StatusTipoOperacion.VENTA

            Case StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO

            Case StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO

            Case StatusTipoOperacion.OTRAS_ENTRADAS_A_ALMACEN

            Case StatusTipoOperacion.OTRAS_SALIDAS_DE_ALMACEN


        End Select
    End Sub
#End Region

#Region "Methods"
    Sub UbicarDocumento(iddocumento As Integer)



    End Sub
#End Region

#Region "Events"

#End Region

End Class