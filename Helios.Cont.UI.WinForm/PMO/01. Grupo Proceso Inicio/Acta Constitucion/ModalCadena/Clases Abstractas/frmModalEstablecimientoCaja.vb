Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class frmModalEstablecimientoCaja
#Region "Métodos"

    Public StrParametroCarga As String = Nothing
    Public Structure TipoProceso
        Const CARGAR_ESTABLECIMIENTOS = "ET"
        Const CARGAR_ESTADOS_FINANCIEROS = "EF"
        Const CARGAR_ALMACENES = "ALM"
    End Structure

    'Public Sub load_almacen(ByVal intIdEstablecimiento As Integer)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS
    '    Dim objalmacen() As HeliosService.AlmacenBO
    '    Try
    '        objalmacen = objService.ObtenerAlmacenesxEstablecimiento(CEmpresa, intIdEstablecimiento, "AF")
    '        lsvTareas.Columns.Clear()
    '        lsvTareas.Items.Clear()
    '        lsvTareas.Columns.Add("codigo", 50) '0
    '        lsvTareas.Columns.Add("name", 280) '1
    '        For Each i As HeliosService.AlmacenBO In objalmacen
    '            Dim n As New ListViewItem(i.IdAlmacen)
    '            n.SubItems.Add(i.DescripcionAlmacen)
    '            lsvTareas.Items.Add(n)
    '        Next
    '        lsvTareas.Focus()
    '    Catch ex As Exception
    '        MsgBox("No se puedo cargar la información para los combos" & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Public Sub ObtenerEstadosFinancieros(ByVal intIdEstablecimiento As Integer, ByVal strTipoEF As String, ByVal strMoneda As String)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objEstados() As HeliosService.EstadosFinancierosBO
    '    Try
    '        objEstados = objService.GetObtenerMonedasEFPorEmpresaMoneda(CEmpresa, intIdEstablecimiento, strTipoEF, strMoneda)
    '        lsvTareas.Columns.Clear()
    '        lsvTareas.Items.Clear()
    '        lsvTareas.Columns.Add("ID", 0) '0
    '        lsvTareas.Columns.Add("cuenta", 0) '1
    '        lsvTareas.Columns.Add("codigo", 0) '2
    '        lsvTareas.Columns.Add("tipo", 0) '3
    '        lsvTareas.Columns.Add("Entidad Financiera", 290) '4
    '        For Each i As HeliosService.EstadosFinancierosBO In objEstados
    '            Dim n As New ListViewItem(i.pIdEstado)
    '            n.SubItems.Add(i.pCuenta)
    '            n.SubItems.Add(i.pCodigo)
    '            n.SubItems.Add(i.pTipo)
    '            n.SubItems.Add(i.pDescripcion)
    '            lsvTareas.Items.Add(n)
    '        Next
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información para la lista de EF." & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    Public Sub ObtenerEstablecimientos()
        Dim establecimientoSA = New establecimientoSA()
        Try
            lsvTareas.Columns.Clear()
            lsvTareas.Items.Clear()
            lsvTareas.Columns.Add("codigo", 50) '0
            lsvTareas.Columns.Add("name", 280) '1
            For Each i In establecimientoSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
                Dim n As New ListViewItem(i.idCentroCosto)
                n.SubItems.Add(String.Concat(i.nombre, ", ", i.ubigeo))
                lsvTareas.Items.Add(n)
            Next
            lsvTareas.Focus()
        Catch ex As Exception
            MsgBox("Error al cargar datos" & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmModalEstablecimientoCaja_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub frmModalEstablecimientoCaja_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub lsvTareas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lsvTareas.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If lsvTareas.SelectedItems.Count > 0 Then

                Select Case StrParametroCarga
                    Case TipoProceso.CARGAR_ESTABLECIMIENTOS
                        Dim n As New RecuperarTablas()
                        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                        datos.Clear()
                        n.ID = lsvTareas.SelectedItems(0).SubItems(0).Text
                        n.NombreCampo = lsvTareas.SelectedItems(0).SubItems(1).Text
                        datos.Add(n)
                        Dispose()
                    Case TipoProceso.CARGAR_ESTADOS_FINANCIEROS
                        Dim n As New RecuperarTablas()
                        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                        datos.Clear()
                        n.ID = lsvTareas.SelectedItems(0).SubItems(0).Text
                        n.Codigo = lsvTareas.SelectedItems(0).SubItems(1).Text
                        n.NombreCampo = lsvTareas.SelectedItems(0).SubItems(4).Text
                        datos.Add(n)
                        Dispose()
                    Case TipoProceso.CARGAR_ALMACENES
                        Dim n As New RecuperarTablas()
                        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                        datos.Clear()
                        n.ID = lsvTareas.SelectedItems(0).SubItems(0).Text
                        n.NombreCampo = lsvTareas.SelectedItems(0).SubItems(1).Text
                        datos.Add(n)
                        Dispose()
                End Select


            End If
        End If
    End Sub

    Private Sub lsvTareas_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvTareas.MouseDoubleClick
        If lsvTareas.SelectedItems.Count > 0 Then

            Select Case StrParametroCarga
                Case TipoProceso.CARGAR_ESTABLECIMIENTOS
                    Dim n As New RecuperarTablas()
                    Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                    datos.Clear()
                    n.ID = lsvTareas.SelectedItems(0).SubItems(0).Text
                    n.NombreCampo = lsvTareas.SelectedItems(0).SubItems(1).Text
                    datos.Add(n)
                    Dispose()
                Case TipoProceso.CARGAR_ESTADOS_FINANCIEROS
                    Dim n As New RecuperarTablas()
                    Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                    datos.Clear()
                    n.ID = lsvTareas.SelectedItems(0).SubItems(0).Text
                    n.Codigo = lsvTareas.SelectedItems(0).SubItems(1).Text
                    n.NombreCampo = lsvTareas.SelectedItems(0).SubItems(4).Text
                    datos.Add(n)
                    Dispose()
                Case TipoProceso.CARGAR_ALMACENES
                    Dim n As New RecuperarTablas()
                    Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
                    datos.Clear()
                    n.ID = lsvTareas.SelectedItems(0).SubItems(0).Text
                    n.NombreCampo = lsvTareas.SelectedItems(0).SubItems(1).Text
                    datos.Add(n)
                    Dispose()
            End Select


        End If
    End Sub

    Private Sub lsvTareas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvTareas.SelectedIndexChanged

    End Sub

    Private Sub txtBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBusqueda.TextChanged

    End Sub
End Class