Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Drawing
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCConductorTransportes
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread
    Dim filter As New GridExcelFilter()
    Public ListadoClientes As List(Of Helios.Cont.Business.Entity.Persona)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCliente, True, False, 9.0F)

        OrdenamientoGrid(dgvCliente, True)

    End Sub

    Private Sub GrabarEnFormBasico()
        Dim f As New formCrearConductor
        f.strTipo = TIPO_ENTIDAD.TRANSPORTE_CONDUCTOR
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim empresa As String = Gempresas.IdEmpresaRuc
            PictureLoad.Visible = True
            Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(empresa)))
            Thread.Start()
        End If
    End Sub

    Private Sub GetClientes(empresa As String)
        Dim entidadsa As New PersonaSA
        Dim dt As New DataTable
        With dt.Columns
            .Add("CODIGO")
            .Add("FECHANAC")
            .Add("TIPODOC")
            .Add("NRODOC")
            .Add("NOMBRE")
            .Add("NROLICENCIA")
            .Add("ESTADO")
        End With

        'ListadoClientes = (entidadsa.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                            .tipoPersona = "TR",
        '                                            .estado = "A"})).ToList

        For Each i In ListadoClientes
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.codigo
            Select Case i.tipoDoc
                Case "6"
                    dr(1) = "RUC"
                Case "1"
                    dr(1) = "DNI"
                Case "7"
                    dr(1) = "PASSAPORTE"
                Case "4"
                    dr(1) = "CARNET DE EXTRANJERIA"
            End Select

            dr(2) = i.fechaNac
            dr(3) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(4) = i.idPersona
            dr(5) = i.nombreCompleto
            'dr(6) = i.nroLicencia
            'dr(7) = i.estado
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCliente.DataSource = table
            PictureLoad.Visible = False
        End If
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Dim empresa As String = Gempresas.IdEmpresaRuc
        PictureLoad.Visible = True
        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(empresa)))
        Thread.Start()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        GrabarEnFormBasico()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim personaSA As New PersonaSA
        Dim personaBE As New Persona

        'If (Not IsNothing(dgvCliente.Table.CurrentRecord)) Then
        '    If (dgvCliente.Table.CurrentRecord.GetValue("ESTADO") = "A") Then
        '        personaBE = New Persona With {.estado = "I", .idPersona = dgvCliente.Table.CurrentRecord.GetValue("CODIGO")}

        '        personaSA.EditarPersona(personaBE)
        '    ElseIf (dgvCliente.Table.CurrentRecord.GetValue("ESTADO") = "I") Then
        '        personaBE = New Persona With {.estado = "A", .idPersona = dgvCliente.Table.CurrentRecord.GetValue("CODIGO")}

        '        personaSA.EditarPersona(personaBE)
        '    End If
        'End If



    End Sub
End Class
