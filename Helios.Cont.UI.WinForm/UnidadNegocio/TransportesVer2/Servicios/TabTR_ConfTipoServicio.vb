Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Imports System.Net.Http
Imports Syncfusion.Windows.Forms

Public Class TabTR_ConfTipoServicio


#Region "Attributes"


    Dim listaDistribucion As New List(Of distribucionInfraestructura)

    Dim ListaConfiguracion As New List(Of configuracionPrecio)

    Public Property listaeTALLEiTEMS As List(Of detalleitems)

    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of detalleitems))

#End Region

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Methods"

    Public Sub GetDocumentoVentaID()
        Dim dt As New DataTable
        Dim tipoServicioInfraestructuraSA As New servicioSA
        Dim tipoServicioInfraestructuraBE As New servicio
        Dim listatipoServicioInfraestructura As New List(Of servicio)

        tipoServicioInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc


        listatipoServicioInfraestructura = tipoServicioInfraestructuraSA.ListadoServicios(New servicio With {.idEmpresa = Gempresas.IdEmpresaRuc}).ToList

        GridSERVICIO.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("DESCRIPCION")
        End With

        For Each i In listatipoServicioInfraestructura

            dt.Rows.Add(i.idServicio,
                    i.descripcion)

        Next
        GridSERVICIO.DataSource = dt

    End Sub



    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs)
        Dim frmNuevaExistencia As New frmNuevaExistencia
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            If Gempresas.Regimen = "1" Then
                .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            Else
                .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            End If

            '.UCNuenExistencia.chClasificacion.Checked = False
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "GS"
            .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        If frmNuevaExistencia.Tag IsNot Nothing Then
            Dim c = CType(frmNuevaExistencia.Tag, detalleitems)
            txtFiltrar.Text = c.descripcionItem
            txtFiltrar.Tag = c.idItem
            'GetProductos()
        End If
    End Sub

    Private Sub GridSERVICIO_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridSERVICIO.TableControlCellClick
        Try
            If (Not IsNothing(GridSERVICIO.Table.CurrentRecord)) Then

                txtFiltrar.Text = GridSERVICIO.Table.CurrentRecord.GetValue("DESCRIPCION")
                txtFiltrar.Tag = GridSERVICIO.Table.CurrentRecord.GetValue("ID")
            Else
                Throw New Exception("DEBE SELECCIONAR UN DATO")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        Try
            If (IsNothing(txtFiltrar.Tag)) Then
                MessageBox.Show("DEBE INGRESAR UN ACTIVO")
                Exit Sub
            End If

            If (IsNothing(TextBoxExt1.Tag)) Then
                MessageBox.Show("DEBE INGRESAR UN SERVICIO")
                Exit Sub
            End If

            Dim DISTRIBUCIONsa As New distribucionInfraestructuraSA
            Dim DISTRIBUCIONbe As New distribucionInfraestructura

            DISTRIBUCIONbe.idActivo = TextBoxExt1.Tag
            DISTRIBUCIONbe.idEmpresa = Gempresas.IdEmpresaRuc
            DISTRIBUCIONbe.idDetalleItem = CInt(txtFiltrar.Tag)

            DISTRIBUCIONsa.GetDistribucionAsignacionItem(DISTRIBUCIONbe)

            MessageBox.Show("Se enlazo el servicio con el bus")
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



#End Region

End Class
