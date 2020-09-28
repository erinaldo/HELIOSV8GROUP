Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmHistorialCaja

#Region "Attributes"

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvUsuarioActivo)
    End Sub

#End Region

#Region "Methods"


    Public Sub GetCajaActivas()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCaja", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("DNI", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFullEstado()
            usuario = New Usuario
            usuario.IDUsuario = i.idPersona

            usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            If (Not IsNothing(usuario)) Then
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idPersona
                dr(1) = i.idcajaUsuario
                dr(2) = usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno
                dr(3) = usuario.NroDocumento
                Select Case i.estadoCaja
                    Case "A"
                        dr(4) = "ABIERTO"
                    Case "C"
                        dr(4) = "CERRADO"
                End Select

                dt.Rows.Add(dr)

            End If
        Next
        dgvUsuarioActivo.DataSource = dt


    End Sub

    
#Region "TIMER"

#End Region
#End Region

#Region "Events"
    Private Sub ToolStripButton41_Click(sender As Object, e As EventArgs) Handles ToolStripButton41.Click
        GetCajaActivas()
    End Sub
#End Region

End Class