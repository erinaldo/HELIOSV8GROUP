Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports Syncfusion.Windows.Forms.Grid
Imports System.Runtime.Serialization
Imports Syncfusion.GroupingGridExcelConverter
Imports System.Threading
Imports Helios.General.Constantes
Imports Syncfusion.Drawing
Public Class UCPrincipalProveedores

#Region "Atributos"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    'Public Property UCClientes As UCClientes
    Public ListadoClientes As List(Of Helios.Cont.Business.Entity.entidad)
#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'UCProveedor = New UCProveedor With {.Dock = DockStyle.Fill}
        FormatoGridAvanzado(DgvProveedores, False, False, 7.0F)
        ' Add any initialization after the InitializeComponent() call.
        'UCClientes = New UCClientes With {.Dock = DockStyle.Fill}
        FormatoGridPrincipal(DgvProveedores)
        'PanelBody.Controls.Add(UCProveedor)
    End Sub
#End Region
#Region "Metodos"

    Private Sub GetPorveedores(empresa As String, filter As String)
        Dim entidadsa As New entidadSA
        Dim dt As New DataTable
        Dim MyClients As New List(Of entidad)
        With dt.Columns
            .Add("idEntidad")
            .Add("tipoDoc")
            .Add("nroDoc")
            .Add("tipo")
            .Add("razon")
            .Add("fono")
            .Add("celular")
            .Add("email")
            .Add("direc")
        End With




        ListadoClientes = (entidadsa.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})).Where(Function(o) o.tipoEntidad <> "VR").ToList

        'Dim MyVarious As New entidad
        'MyVarious.nombreCompleto = VarClienteGeneral.nombreCompleto
        'MyVarious.idEntidad = VarClienteGeneral.idEntidad
        'MyVarious.tipoDoc = "0"
        'MyVarious.tipoPersona = "N"
        'MyVarious.telefono = "-"
        'MyVarious.celular = "-"
        'MyVarious.email = "-"
        'MyVarious.direccion = "-"
        'MyVarious.nrodoc = "0"

        MyClients = (From i In ListadoClientes Where i.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR And i.nombreCompleto.Contains(filter)).ToList


        'MyClients.Add(MyVarious)



        For Each i In MyClients
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEntidad
            Select Case i.tipoDoc
                Case "6"
                    dr(1) = "RUC"
                Case "1"
                    dr(1) = "DNI"
                Case "7"
                    dr(1) = "PASSAPORTE"
                Case "4"
                    dr(1) = "CARNET DE EXTRANJERIA"
                Case "0"
                    dr(1) = "-"
            End Select

            dr(2) = i.nrodoc
            dr(3) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(4) = i.nombreCompleto
            dr(5) = i.telefono
            dr(6) = i.celular
            dr(7) = i.email
            dr(8) = i.direccion
            dt.Rows.Add(dr)
        Next



        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            DgvProveedores.DataSource = table
            'PictureLoad.Visible = False
        End If
    End Sub

#End Region

    Private Sub txtBuscarProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProveedor.TextChanged

    End Sub

    Private Sub txtBuscarProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProveedor.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Dim empresa As String = Gempresas.IdEmpresaRuc
                GetPorveedores(empresa, txtBuscarProveedor.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim f As New frmCrearENtidades With
        {
        .strTipo = TIPO_ENTIDAD.PROVEEDOR,
        .ManipulacionEstado = ENTITY_ACTIONS.INSERT,
        .StartPosition = FormStartPosition.CenterParent
        }
        f.CaptionLabels(0).Text = "Nuevo Proveedor"
        f.ShowDialog(Me)
    End Sub

    Private Sub btnEditarCliente_Click(sender As Object, e As EventArgs) Handles btnEditarCliente.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(DgvProveedores.Table.CurrentRecord) Then
            Dim f As New frmCrearENtidades(CInt(DgvProveedores.Table.CurrentRecord.GetValue("idEntidad")))
            f.CaptionLabels(0).Text = "Editar Proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            '   f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE 
            f.intIdEntidad = DgvProveedores.Table.CurrentRecord.GetValue("idEntidad")
            'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            Dim empresa As String = Gempresas.IdEmpresaRuc

            GetPorveedores(empresa, "")
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub
End Class
