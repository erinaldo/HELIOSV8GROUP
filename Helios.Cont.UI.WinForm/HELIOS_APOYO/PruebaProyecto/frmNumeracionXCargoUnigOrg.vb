Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmNumeracionXCargoUnigOrg

#Region "Atributos"
    Dim listaOr As New List(Of organizacion)
    Dim UnidadOrganicaBE As organizacion
    Dim ListaUnidadOrganica As New List(Of organizacion)
    Private node As TreeNodeAdv = Nothing
    Public nodePadre = New TreeNode
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Dim centroCostoBE As New centrocosto
    Dim ListaPerfil As New List(Of perfilAnexo)
    Dim IDcargo As Integer
    Dim nombreCargo As String = String.Empty


#End Region

#Region "Constructor"

    Sub New(centrocostoBE As centrocosto, ListaPerfil As List(Of perfilAnexo))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        centrocostoBE = centrocostoBE
        ListaPerfil = ListaPerfil
        TextBoxExt1.Text = centrocostoBE.nombre
        TextBoxExt1.Tag = centrocostoBE.idCentroCosto

        GetListaCArgos(ListaPerfil)

    End Sub

#End Region

#Region "Metodos"


    Private Sub GetListaCArgos(listaCargo As List(Of perfilAnexo))
        Try

            Dim objRolSA As New perfilAnexoSA


            Dim dt As New DataTable("Datos Generales")
            dt.Columns.Add(New DataColumn("ID", GetType(Integer)))
            dt.Columns.Add(New DataColumn("CARGO", GetType(String)))
            dt.Columns.Add(New DataColumn("IDRol", GetType(Integer)))




            For Each i In objRolSA.GetObtenerPerfilIDestablecimiento(New perfilAnexo With {.idCentroCosto = TextBoxExt1.Tag}) 'listaCargo.ToList
                Dim dr As DataRow = dt.NewRow()

                dr(0) = (i.idCargo)
                dr(1) = i.descripcion
                dr(2) = i.idRol

                dt.Rows.Add(dr)
            Next

            dgPedidos.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Sub GETORGANIZACION()
    '    Dim ORGSA As New OrganizacionSA
    '    listaOr = ORGSA.GetObtenerOrganizacion(Gempresas.IdEmpresaRuc)
    'End Sub


    Private Sub GetListaDatosGenerales(idPerfilAnexo As Integer)
        Try

            Dim objNumeracionBoletaSA As New NumeracionBoletaSA
            Dim objNumeracionBoleta As New numeracionBoletas

            dgvNumeracion.Table.Records.DeleteAll()

            Dim dt As New DataTable("Datos Generales")
            dt.Columns.Add(New DataColumn("ID", GetType(Integer)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("serie", GetType(String)))
            dt.Columns.Add(New DataColumn("agreagar"))
            dt.Columns.Add(New DataColumn("idPerfilAnexo"))


            'objNumeracionBoleta.empresa = Gempresas.IdEmpresaRuc
            'objNumeracionBoleta.establecimiento = GEstableciento.IdEstablecimiento


            For Each i As numeracionBoletas In objNumeracionBoletaSA.GetListar_numeracionBoletasXCargo(New numeracionBoletas With {.empresa = Gempresas.IdEmpresaRuc, .establecimiento = TextBoxExt1.Tag, .idCargo = idPerfilAnexo}).ToList
                Dim dr As DataRow = dt.NewRow()

                dr(0) = (i.IdEnumeracion)
                dr(1) = i.descripcionModulo
                dr(2) = i.serie

                Select Case i.estadoNumeracion
                    Case True
                        dr(3) = True
                    Case False
                        dr(3) = False
                End Select
                dr(4) = idPerfilAnexo

                dt.Rows.Add(dr)
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
            dgvNumeracion.DataSource = table
        End If
    End Sub



    Private Sub grabar(Id As Integer)
        Try
            Dim perfilAnexoSA As New perfilAnexoSA
            Dim perfilAnexoBE As perfilAnexo
            Dim listPerfilAnexo As New List(Of perfilAnexo)

            'perfilAnexoBE = New perfilAnexo
            'perfilAnexoBE.idCargo = CInt(txtDescripcion.Tag)
            'perfilAnexoBE.idCentroCosto = CInt(Id)
            'perfilAnexoBE.descripcion = txtDescripcion.Text
            'perfilAnexoBE.tipo = txtDescripcion.Tag
            'perfilAnexoBE.estado = "A"
            'perfilAnexoBE.usuarioActualizacion = "ADMIN"
            'perfilAnexoBE.fechaActualizacion = Date.Now

            listPerfilAnexo.Add(perfilAnexoBE)

            perfilAnexoSA.SavePerfilAnexo(listPerfilAnexo)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Close()
    End Sub


    Private Sub GridGroupingControl1_TableControlCheckBoxClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvNumeracion.TableControlCheckBoxClick
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim obj As New documentocompra
            Dim RowIndex As Integer = e.Inner.RowIndex
            Dim cc As GridCurrentCell = dgvNumeracion.TableControl.CurrentCell
            cc.ConfirmChanges()

            If RowIndex > -1 Then
                e.TableControl.CurrentCell.EndEdit()
                e.TableControl.Table.TableDirty = True
                e.TableControl.Table.EndEdit()

                Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                If style3.Enabled Then
                    If style3.TableCellIdentity.Column.Name = "agreagar" Then

                        Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)

                        If sty.TableCellIdentity.DisplayElement.Kind = DisplayElementKind.Record Then
                            Dim record = sty.TableCellIdentity.DisplayElement.GetRecord()

                            Dim valCheck = record.GetValue("agreagar") 'Me.GridCompra.TableModel(RowIndex, 15).CellValue
                            Select Case valCheck
                                Case "False" 'TRUE
                                    Dim numeracionAOSA As New distribucionNumeracionAOSA
                                    Dim idCargo = (record.GetValue("idPerfilAnexo"))
                                    Dim RolID = (dgPedidos.Table.CurrentRecord.GetValue("IDRol"))
                                    Dim idNumeracion = (record.GetValue("ID"))
                                    Dim estado = "A"

                                    numeracionAOSA.InsertAreaOperativaNumeracion(New distribucionNumeracionAO With {.IdEnumeracion = idNumeracion, .idCargo = idCargo, .estado = estado, .idCentroCosto = TextBoxExt1.Tag, .idRol = RolID})

                                Case Else ' FALSE
                                    Dim numeracionAOSA As New distribucionNumeracionAOSA
                                    Dim idCargo = (record.GetValue("idPerfilAnexo"))
                                    Dim idNumeracion = (record.GetValue("ID"))
                                    Dim estado = "I"

                                    numeracionAOSA.InsertAreaOperativaNumeracion(New distribucionNumeracionAO With {.IdEnumeracion = idNumeracion, .idCargo = idCargo, .estado = estado})

                            End Select

                        End If

                    End If
                End If
            End If
            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgPedidos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgPedidos.TableControlCellClick
        Try

            If (Not IsNothing(dgPedidos.Table.CurrentRecord)) Then

                GetListaDatosGenerales(dgPedidos.Table.CurrentRecord.GetValue("ID"))
            Else

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            Dim numeracionAOSA As New distribucionNumeracionAOSA
            Dim idCargo = (dgPedidos.Table.CurrentRecord.GetValue("ID"))
            Dim RolID = (dgPedidos.Table.CurrentRecord.GetValue("IDRol"))
            Dim ListaEnumeracion As New List(Of distribucionNumeracionAO)
            Dim numeracionBE As distribucionNumeracionAO

            For Each ITEM In dgvNumeracion.Table.Records
                numeracionBE = New distribucionNumeracionAO With {
                .idCargo = idCargo,
                .idRol = RolID,
                .IdEnumeracion = ITEM.GetValue("ID"),
                .estado = "A",
                .fechaActualizacion = Date.Now,
                .usuarioActualizacion = "ADMINISTRADOR",
                .idCentroCosto = TextBoxExt1.Tag
                }

                ListaEnumeracion.Add(numeracionBE)

                ITEM.SetValue("agreagar", True)

            Next

            numeracionAOSA.InsertListaNumeracionAo(ListaEnumeracion)

            'numeracionAOSA.InsertAreaOperativaNumeracion(New distribucionNumeracionAO With {.IdEnumeracion = idNumeracion, .idCargo = idCargo, .estado = estado, .idCentroCosto = TextBoxExt1.Tag, .idRol = RolID})

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#End Region


End Class