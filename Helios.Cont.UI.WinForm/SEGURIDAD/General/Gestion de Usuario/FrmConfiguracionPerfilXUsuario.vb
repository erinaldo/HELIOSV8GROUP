Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class FrmConfiguracionPerfilXUsuario

#Region "Atributos"
    Public Property IDUsario As Integer
    Public Property IDRol As Integer

    Public Property listaAutorizacionRol As New List(Of Asegurable)
    Public Property listaAsegurable As List(Of Asegurable)

    Public Property strEstadoManipulacion() As String

#End Region

#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(dgPermisos, False, True)
        ' Add any initialization after the InitializeComponent() call.
        BunifuFlatButton1.Visible = True
        ToolStripButton4.Visible =
              ToolStripButton2.Visible = False
    End Sub

    Sub New(IDCargo As Integer, IdUsuario As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(dgPermisos, False, True)
        ' Add any initialization after the InitializeComponent() call.
        BunifuFlatButton1.Visible = True
        cargarAsegurableXId(IdUsuario, IDCargo)
        ToolStripButton4.Visible = True
        BunifuFlatButton1.Visible = False
        ToolStripButton2.Visible = True

        IDUsario = IdUsuario
        IDRol = IDCargo
    End Sub

#End Region

#Region "Metodos"

    Public Sub cargarAsegurable()
        Try
            Dim SA As New AsegurableSA
            Dim objeto As New Asegurable


            Dim dt As New DataTable("Lista - permisos")
            dt.Columns.Add(New DataColumn("IDRol", GetType(Integer)))
            dt.Columns.Add(New DataColumn("IDAsegurable", GetType(String)))
            dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
            dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("estado", GetType(Boolean)))

            listaAsegurable = SA.GetAsegurableXidCliente(New Asegurable With {.IDEmpresa = Gempresas.IdEmpresaRuc, .IDEstablecimiento = GEstableciento.IdEstablecimiento})

            dgPermisos.Table.Records.DeleteAll()

            For Each i In listaAsegurable
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.IDModulo
                dr(1) = i.IDAsegurable
                dr(2) = i.Nombre
                dr(3) = i.Descripcion
                dr(4) = False
                dt.Rows.Add(dr)

            Next
            dgPermisos.DataSource = dt


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub cargarAsegurableXId(idUsuario As Integer, idRol As Integer)
        Try
            Dim SA As New AsegurableSA
            Dim objeto As New Asegurable


            Dim AutorizacionRolSA As New AutorizacionRolSA
            Dim listaAutorizacion As New List(Of AutorizacionRol)



            Dim dt As New DataTable("Lista - permisos")
            dt.Columns.Add(New DataColumn("IDRol", GetType(Integer)))
            dt.Columns.Add(New DataColumn("IDAsegurable", GetType(String)))
            dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
            dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("estado", GetType(Boolean)))

            listaAsegurable = SA.GetAsegurableXidCliente(New Asegurable With {.IDEmpresa = Gempresas.IdEmpresaRuc, .IDEstablecimiento = GEstableciento.IdEstablecimiento})

            listaAutorizacion = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = Gempresas.IdEmpresaRuc,
                                                               .IDEstablecimiento = GEstableciento.IdEstablecimiento,
                                                               .IDUsuario = idUsuario,
                                                               .IDRol = idRol})

            dgPermisos.Table.Records.DeleteAll()

            For Each i In listaAsegurable
                Dim dr As DataRow = dt.NewRow()
                Dim ESTADO As Boolean

                Dim CONSULTA = listaAutorizacion.Where(Function(O) O.IDAsegurable = i.IDAsegurable And O.IDModulo = i.IDModulo).FirstOrDefault

                If (Not IsNothing(CONSULTA)) Then
                    ESTADO = True
                Else
                    ESTADO = False
                End If

                dr(0) = i.IDModulo
                dr(1) = i.IDAsegurable
                dr(2) = i.Nombre
                dr(3) = i.Descripcion
                dr(4) = ESTADO
                dt.Rows.Add(dr)

            Next
            dgPermisos.DataSource = dt


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try
            If (dgPermisos.Table.Records.Count > 0) Then

                For Each items In (dgPermisos.Table.Records)
                    If (items.GetValue("estado") = True) Then

                        Dim sa As New AutorizacionRolSA
                        Dim objeto As New Asegurable
                        objeto.IDRol = txtIdRol.Text
                        objeto.IDAsegurable = items.GetValue("IDAsegurable")
                        objeto.IDModulo = items.GetValue("IDRol")
                        objeto.IDProducto = "39"
                        objeto.EstaAutorizado = True
                        objeto.UsuarioActualizacion = "ADMINISTRADOR"
                        objeto.FechaActualizacion = DateTime.Now

                        'sa.RegistrarPermisoRol(objeto)

                        listaAutorizacionRol.Add(objeto)
                    End If
                Next

                Me.Tag = listaAutorizacionRol
                Close()
            Else
                MessageBox.Show("NO CONTIENE NINGUN MODULO SELECCIONADO")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            If (strEstadoManipulacion = ENTITY_ACTIONS.UPDATE) Then

                For Each items In (dgPermisos.Table.Records)
                    If (items.GetValue("estado") = False) Then
                        Dim sa As New AutorizacionRolSA
                        Dim AutorizacionRolSA As New AutorizacionRolSA

                        AutorizacionRolSA.InsertItem(New AutorizacionRol With {.IDRol = txtIdRol.Text,
                                                                 .IDUsuario = IDUsario,
                                                                 .IDAsegurable = items.GetValue("IDAsegurable"),
                                                                 .IDModulo = items.GetValue("IDRol"),
                                                                 .IDProducto = "39",
                                                                 .EstaAutorizado = True,
                                                                 .UsuarioActualizacion = "Administrador",
                                                                 .FechaActualizacion = Date.Now,
                                                                 .Action = BaseBE.EntityAction.INSERT})
                    End If
                Next

                MessageBox.Show("SE GRABO TODO LOS PERMISOS")
                Close()
            Else
                For Each items In (dgPermisos.Table.Records)
                    items.SetValue("estado", True)
                Next
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgPermisos_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgPermisos.TableControlCheckBoxClick
        Try

            If (strEstadoManipulacion = ENTITY_ACTIONS.UPDATE) Then
                Me.Cursor = Cursors.WaitCursor

                Dim RowIndex As Integer = e.Inner.RowIndex
                Dim cc As GridCurrentCell = dgPermisos.TableControl.CurrentCell
                cc.ConfirmChanges()

                If RowIndex > -1 Then
                    e.TableControl.CurrentCell.EndEdit()
                    e.TableControl.Table.TableDirty = True
                    e.TableControl.Table.EndEdit()

                    Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                    If style3.Enabled Then
                        If style3.TableCellIdentity.Column.Name = "estado" Then

                            Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)

                            If sty.TableCellIdentity.DisplayElement.Kind = DisplayElementKind.Record Then
                                Dim record = sty.TableCellIdentity.DisplayElement.GetRecord()

                                Dim valCheck = record.GetValue("estado") 'Me.GridCompra.TableModel(RowIndex, 15).CellValue
                                Select Case valCheck
                                    Case "False" 'TRUE

                                        Dim AutorizacionRolSA As New AutorizacionRolSA

                                        Dim UsuarioID = IDUsario
                                        Dim RolID = IDRol
                                        Dim AsegurableId = (record.GetValue("IDAsegurable"))
                                        Dim moduloID = (record.GetValue("IDRol"))

                                        AutorizacionRolSA.InsertItem(New AutorizacionRol With {.IDRol = RolID,
                                                                 .IDUsuario = IDUsario,
                                                                 .IDAsegurable = AsegurableId,
                                                                 .IDModulo = moduloID,
                                                                 .IDProducto = "39",
                                                                 .EstaAutorizado = True,
                                                                 .UsuarioActualizacion = "Administrador",
                                                                 .FechaActualizacion = Date.Now,
                                                                 .Action = BaseBE.EntityAction.INSERT})

                                        MessageBox.Show("SE GRABO CORRECTAMENTE")


                                    Case Else ' FALSE
                                        Dim AutorizacionRolSA As New AutorizacionRolSA

                                        Dim UsuarioID = IDUsario
                                        Dim RolID = IDRol
                                        Dim AsegurableId = (record.GetValue("IDAsegurable"))
                                        Dim moduloID = (record.GetValue("IDRol"))

                                        AutorizacionRolSA.EliminarPermisoRol(New AutorizacionRol With {.IDRol = RolID,
                                                                 .IDUsuario = IDUsario,
                                                                 .IDAsegurable = AsegurableId,
                                                                 .IDModulo = moduloID})

                                        MessageBox.Show("SE ELIMINO CORRECTAMENTE")

                                End Select

                            End If

                        End If
                    End If
                End If
                Me.Cursor = Cursors.Arrow

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgPermisos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgPermisos.TableControlCellClick

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            If (strEstadoManipulacion = ENTITY_ACTIONS.UPDATE) Then

                For Each items In (dgPermisos.Table.Records)
                    If (items.GetValue("estado") = True) Then
                        Dim sa As New AutorizacionRolSA
                        Dim AutorizacionRolSA As New AutorizacionRolSA

                        AutorizacionRolSA.EliminarPermisoRol(New AutorizacionRol With {.IDRol = items.GetValue("IDRol"),
                                                            .IDUsuario = IDUsario,
                                                            .IDAsegurable = items.GetValue("IDAsegurable"),
                                                            .IDModulo = items.GetValue("IDRol")})

                    End If
                Next

                MessageBox.Show("SE ELIMINO TODO LOS PERMISOS")
                Close()
            Else
                For Each items In (dgPermisos.Table.Records)
                    items.SetValue("estado", True)
                Next
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




#End Region

End Class