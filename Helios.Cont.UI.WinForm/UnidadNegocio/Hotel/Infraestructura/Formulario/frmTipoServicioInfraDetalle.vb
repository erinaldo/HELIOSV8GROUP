Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Imports System.Threading

Public Class frmTipoServicioInfraDetalle
    Inherits frmMaster

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread
    Public Property IdTipoServicio As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ID As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarCombos()

        CargarCategoria(ID)
        BunifuFlatButton4.Visible = True
        IdTipoServicio = ID
    End Sub

    Private Sub CargarCombos()
        Dim componenteBE As New componente
        Dim componenteSA As New componenteSA
        Dim listaComponente As New List(Of componente)
        Try
            componenteBE.idEmpresa = Gempresas.IdEmpresaRuc
            componenteBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            componenteBE.tipo = "T"
            componenteBE.estado = "A"

            listaComponente = componenteSA.getListaComponenteXTipo(componenteBE)

            cboTipoComposicion.DataSource = Nothing

            If (Not IsNothing(listaComponente)) Then
                cboTipoComposicion.ValueMember = "idComponente"
                cboTipoComposicion.DisplayMember = "descripcionItem"
                cboTipoComposicion.DataSource = listaComponente
                cboTipoComposicion.SelectedValue = listaComponente(0).idComponente

                GetListaComponenteXID(cboTipoComposicion.SelectedValue)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetListaComponenteXID(ID As Integer)
        Try
            Dim componenteBE As New componente
            Dim componenteSA As New componenteSA
            Dim listaComponente As New List(Of componente)


            componenteBE.idEmpresa = Gempresas.IdEmpresaRuc
            componenteBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            componenteBE.tipo = "TD"
            componenteBE.idPadre = ID
            componenteBE.estado = "A"

            listaComponente = componenteSA.getListaComponenteXIdPadre(componenteBE)


            Dim dt As New DataTable
            With dt.Columns
                .Add("numero")
                .Add("idItem")
                .Add("tipo")
                .Add("descripcion")
                .Add("estado")
                .Add("seleccion")
                .Add("idPadre")
            End With

            For Each i As componente In listaComponente
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idComponente
                dr(1) = i.idItem
                dr(2) = i.tipo
                dr(3) = i.descripcionItem
                dr(4) = i.estado
                dr(5) = False
                dr(6) = i.idPadre
                dt.Rows.Add(dr)
            Next

            dgvComponente.DataSource = dt
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub CargarCategoria(ID As Integer)
        Try
            Dim distribucionTipoServicioSA As New distribucionTipoServicioSA
            Dim ListadistribucionTipoServicio As New List(Of distribucionTipoServicio)
            Dim distribucionTipoServicioBE As New distribucionTipoServicio
            Dim conteo As Integer = 1

            distribucionTipoServicioBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionTipoServicioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionTipoServicioBE.estado = "A"
            distribucionTipoServicioBE.idTipoServicio = ID

            ListadistribucionTipoServicio = distribucionTipoServicioSA.GetUbicarDistribucionTipoServicio(distribucionTipoServicioBE)

            Dim dt As New DataTable
            With dt.Columns
                .Add("idComponente")
                .Add("numeracion")
                .Add("descripcion")
                .Add("estado")
            End With

            For Each i In ListadistribucionTipoServicio
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idDistribucionTipoServicio
                dr(1) = conteo
                dr(2) = i.usuarioActualizacion
                dr(3) = i.estado
                dt.Rows.Add(dr)

                conteo += 1
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
            dgvCaracteristica.DataSource = table
        End If
    End Sub

    Private Sub ChSeleccion_CheckedChanged(sender As Object, e As EventArgs) Handles chSeleccion.CheckedChanged
        If (chSeleccion.Checked = True) Then
            chSeleccion.Checked = True
            For Each item In dgvComponente.Table.Records
                item.SetValue("seleccion", True)
            Next

        Else
            chSeleccion.Checked = False
            For Each item In dgvComponente.Table.Records
                item.SetValue("seleccion", False)
            Next
        End If
    End Sub

    Private Sub CboTipoComposicion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTipoComposicion.SelectionChangeCommitted
        GetListaComponenteXID(cboTipoComposicion.SelectedValue)
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim DisTipoBE As New distribucionTipoServicio
        Dim listaDisTipo As New List(Of distribucionTipoServicio)
        Dim DisTipoSA As New distribucionTipoServicioSA
        Try

            For Each ITEM In dgvComponente.Table.Records
                If (ITEM.GetValue("seleccion") = True) Then

                    DisTipoBE = New distribucionTipoServicio
                    DisTipoBE.idEmpresa = Gempresas.IdEmpresaRuc
                    DisTipoBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                    DisTipoBE.idTipoServicio = CInt(lblNombre.Tag)
                    DisTipoBE.idComponente = CInt(ITEM.GetValue("numero"))
                    DisTipoBE.usuarioActualizacion = usuario.IDUsuario
                    DisTipoBE.fechaActualizacion = Date.Now
                    listaDisTipo.Add(DisTipoBE)
                    ITEM.Delete()
                End If
            Next

            DisTipoSA.Save_ListaDistribucionTipoServicio(listaDisTipo)
            CargarCategoria(IdTipoServicio)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim DisTipoBE As New distribucionTipoServicio
        Dim listaDisTipo As New List(Of distribucionTipoServicio)
        Dim DisTipoSA As New distribucionTipoServicioSA
        Try

            For Each ITEM In dgvCaracteristica.Table.Records
                DisTipoBE = New distribucionTipoServicio
                DisTipoBE.idEmpresa = Gempresas.IdEmpresaRuc
                DisTipoBE.idDistribucionTipoServicio = ITEM.GetValue("idComponente")

                listaDisTipo.Add(DisTipoBE)

            Next

            DisTipoSA.DeleteTipoServicioFull(listaDisTipo)
            dgvCaracteristica.Table.Records.DeleteAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class