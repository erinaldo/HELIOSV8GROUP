Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Imports System.Text.RegularExpressions
Imports Syncfusion.Windows.Forms.Tools
Public Class UCUnidOrganica_Jerarq


#Region "ATTRIBUTES"
    Dim popup As Popup
    Public Event OKEvent()
    Public Property UCBusqueUnidadNegocio As UCBusqueUnidadNegocio
    Dim ConOrga As List(Of organizacion)

    Public LISTAUNIDAD As List(Of centrocosto)
    Dim LISTANUEVA As New List(Of jerarquia)
    Dim LISORGANIZ As New List(Of organizacion)
    Dim OBJ As New jerarquia
    Public VALOR As String
    Dim SA As New CentrocostosSA

    Public consulta As Integer
    Dim NIVELBER As Integer
#End Region
#Region "CONSTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        UCBusqueUnidadNegocio = New UCBusqueUnidadNegocio(Me)
        Popup = New Popup(UCBusqueUnidadNegocio)
        AddHandler UCBusqueUnidadNegocio.OKEvent, AddressOf ucB_OKEvent

        GETORGANIZACION()
        LISTARUNIDADES()
        GetMappingColumnsGridUniOrg()

        organigrama()
        RELOADORGANIGRAMA()
        GetMappingColumnsGrid()

        cbrubroOrg.SelectedValue = -1
        cbNivelesOrg.SelectedValue = -1

        'FormatoGridAvanzado(DGUnidJerarquia, True, False)

    End Sub
#End Region
#Region "METHOD"

    Public Sub ucB_OKEvent()
        popup.Hide()
        RaiseEvent OKEvent()
    End Sub

    Public Sub GETBASE()
        Dim SA As New CentrocostosSA
        LISTAUNIDAD = SA.GetObtenerEstablecimiento2(Gempresas.IdEmpresaRuc)
    End Sub

    Public Sub GETORGANIZACION()
        Dim ORGSA As New OrganizacionSA
        LISORGANIZ = ORGSA.GetObtenerOrganizacion(Gempresas.IdEmpresaRuc)
    End Sub

    Public Sub GETBASEJERAR()
        Dim JSA As New JerarquiaSA
        LISTANUEVA = JSA.GetObtenerJerar(GEstableciento.IdEstablecimiento)
    End Sub


    Public Sub BuscarSegmento(idRubro As Integer)

        Dim ListSegmento = (From i In LISTAUNIDAD
                            Where i.TipoEstab = "SE" And i.idpadre = idRubro).ToList

        cbsegmentoOrg.DisplayMember = "nombre"
        cbsegmentoOrg.ValueMember = "idCentroCosto"
        cbsegmentoOrg.DataSource = ListSegmento


    End Sub


    Public Sub LISTARUNIDADES()

        Try


            LISTAUNIDAD = New List(Of centrocosto)
            LISTAUNIDAD = SA.GetObtenerEstablecimiento2(Gempresas.IdEmpresaRuc)


            Dim Listrubro = (From i In LISTAUNIDAD
                             Where i.TipoEstab = "RU").ToList

            cbrubroOrg.DisplayMember = "nombre"
            cbrubroOrg.ValueMember = "idCentroCosto"
            cbrubroOrg.DataSource = Listrubro

        Catch ex As Exception

        End Try


    End Sub

    Public Sub RELOADORGANIGRAMA()

        Dim CC = (From I In LISTAUNIDAD
                  Where I.idCentroCosto = GEstableciento.IdEstablecimiento And
                      I.TipoEstab = "UN"
                  Select I.jerarquia).FirstOrDefault

        LISTANUEVA = New List(Of jerarquia)

        For Each I In CC
            OBJ = New jerarquia

            OBJ.descripcion = I.nivel & " - " & I.descripcion
            OBJ.nivel = I.nivel
            LISTANUEVA.Add(OBJ)
        Next


        If LISTANUEVA.Count > 0 Then
            cbNivelesOrg.DataSource = Nothing
            For Each i In CC
                cbNivelesOrg.DisplayMember = "descripcion"
                cbNivelesOrg.ValueMember = "nivel"
                cbNivelesOrg.DataSource = LISTANUEVA
            Next

        Else
            cbNivelesOrg.DataSource = Nothing
        End If

    End Sub


    Public Sub guardarOrganigrama()

        Dim saveOr As New OrganizacionSA
        Dim ObjOrga As New organizacion
        Dim LisObj As New List(Of organizacion)

        Dim MENSAJE As String = String.Empty
        Try


            For Each JERAR In DGUnidJerarquia.Table.Records
                ObjOrga = New organizacion

                If JERAR.GetValue("Estado") = "NO" Then

                    If JERAR.GetValue("descripcion") = String.Empty Then

                        MENSAJE = "NO"
                        MessageBox.Show("INGRESA DESCRIPCION")

                    Else
                        ObjOrga.idCentroCosto = GEstableciento.IdEstablecimiento
                        ObjOrga.idEmpresa = Gempresas.IdEmpresaRuc
                        ObjOrga.NroOrganizacion = CInt(JERAR.GetValue("NroOrganizacion"))
                        ObjOrga.TipoOrganizacion = "ORG"
                        ObjOrga.descripcion = JERAR.GetValue("descripcion")
                        ObjOrga.tipo = JERAR.GetValue("tipo")
                        ObjOrga.TipoSegmento = cbNivelesOrg.SelectedValue + 1
                        ObjOrga.nivel = cbNivelesOrg.SelectedValue + 1
                        ObjOrga.idRubro = cbrubroOrg.SelectedValue
                        ObjOrga.idSegmento = cbsegmentoOrg.SelectedValue

                        If cbNivelesOrg.SelectedValue = 1 Then
                            ObjOrga.idPadre = 0
                        Else
                            ObjOrga.idPadre = CInt(txtIdUOJe.Text)
                        End If

                        LisObj.Add(ObjOrga)


                        saveOr.ListOrgani(LisObj)
                        MessageBox.Show("se guardo")
                        GETORGANIZACION()
                        GetListUnidadOrganica(CInt(txtIdUOJe.Text))
                    End If

                End If

            Next

        Catch ex As Exception

        End Try

    End Sub


#Region "BUSCAR UNIDAD DE NEGOCIO"
    Private Sub GetMappingColumnsGridUniOrg()
        Dim dt As New DataTable
        With dt
            .Columns.Add("idOrganigrama")
            .Columns.Add("descripcion")

        End With

        UCBusqueUnidadNegocio.dgUnidaNegocio.DataSource = dt
    End Sub



    Public Sub BuscarUniOrganica()

        Try

            If consulta = 2 Then
                ConOrga = (From I In LISORGANIZ
                           Where I.descripcion.Contains(txtBusqUniOrgaJerar.Text) _
                                And I.nivel = cbNivelesOrg.SelectedValue).ToList
            Else
                ConOrga = (From I In LISORGANIZ
                           Where  I.nivel = cbNivelesOrg.SelectedValue).ToList
            End If




            If ConOrga.Count > 0 Then
                UCBusqueUnidadNegocio.dgUnidaNegocio.Table.Records.DeleteAll()
                For Each i In ConOrga
                    Me.UCBusqueUnidadNegocio.dgUnidaNegocio.Table.AddNewRecord.SetCurrent()
                    Me.UCBusqueUnidadNegocio.dgUnidaNegocio.Table.AddNewRecord.BeginEdit()
                    Me.UCBusqueUnidadNegocio.dgUnidaNegocio.Table.CurrentRecord.SetValue("idOrganigrama", i.idOrganigrama)
                    Me.UCBusqueUnidadNegocio.dgUnidaNegocio.Table.CurrentRecord.SetValue("descripcion", i.descripcion)


                    Me.UCBusqueUnidadNegocio.dgUnidaNegocio.Table.AddNewRecord.EndEdit()

                Next

                'Me.DGActividad.Refresh()
                DGUnidJerarquia.Table.Records.DeleteAll()
            Else
                'MessageBox.Show("No existe la descripción de una Unidad Orgánica!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DGUnidJerarquia.Table.Records.DeleteAll()
                'DGProceso.Table.Records.DeleteAll()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Private Sub GetMappingColumnsGrid()
        Dim dt As New DataTable
        With dt
            .Columns.Add("NroOrganizacion")
            .Columns.Add("descripcion")
            .Columns.Add("Estado")
            .Columns.Add("tipo")
            '.Columns.Add("idPadre")
        End With

        DGUnidJerarquia.DataSource = dt
    End Sub

    Public Sub organigrama()
        Dim listaOrg As New List(Of TipoDirecM)
        Dim obj As New TipoDirecM

        obj = New TipoDirecM
        obj.Codigo = "DIR"
        obj.Valor = "DIRECCIÓN"
        listaOrg.Add(obj)

        obj = New TipoDirecM
        obj.Codigo = "CNS"
        obj.Valor = "CONSULTORIA"
        listaOrg.Add(obj)

        obj = New TipoDirecM
        obj.Codigo = "ASE"
        obj.Valor = "ASESORIA"
        listaOrg.Add(obj)

        obj = New TipoDirecM
        obj.Codigo = "CTR"
        obj.Valor = "CONTROL"
        listaOrg.Add(obj)

        obj = New TipoDirecM
        obj.Codigo = "APY"
        obj.Valor = "APOYO"
        listaOrg.Add(obj)

        obj = New TipoDirecM
        obj.Codigo = "LIN"
        obj.Valor = "LINEA"
        listaOrg.Add(obj)


        Me.DGUnidJerarquia.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.DGUnidJerarquia.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.DisplayMember = "Valor"
        Me.DGUnidJerarquia.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.ValueMember = "Codigo"
        Me.DGUnidJerarquia.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.DataSource = listaOrg

        Me.DGUnidJerarquia.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Public Sub Idpadre()
        Dim NIVEL = cbNivelesOrg.SelectedValue
        NIVEL = NIVEL - 1
        Dim conulta = (From O In LISORGANIZ
                       Where O.nivel = NIVEL
                       Select O.idOrganigrama, O.descripcion).ToList


        Me.DGUnidJerarquia.TableDescriptor.Columns("idPadre").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.DGUnidJerarquia.TableDescriptor.Columns("idPadre").Appearance.AnyRecordFieldCell.DisplayMember = "descripcion"
        Me.DGUnidJerarquia.TableDescriptor.Columns("idPadre").Appearance.AnyRecordFieldCell.ValueMember = "idOrganigrama"
        Me.DGUnidJerarquia.TableDescriptor.Columns("idPadre").Appearance.AnyRecordFieldCell.DataSource = conulta

        Me.DGUnidJerarquia.TableDescriptor.Columns("idPadre").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive


    End Sub


    Public Sub GetListUnidadOrganica(valor As Integer)


        Dim consul = LISORGANIZ.Where(Function(d) d.nivel = NIVELBER And d.TipoOrganizacion = "ORG" And d.idPadre = valor).ToList


        If consul.Count > 0 Then
            DGUnidJerarquia.Table.Records.DeleteAll()

            For Each i In consul
                Me.DGUnidJerarquia.Table.AddNewRecord.SetCurrent()
                Me.DGUnidJerarquia.Table.AddNewRecord.BeginEdit()

                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("NroOrganizacion", i.NroOrganizacion)
                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("Estado", "SI")
                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("tipo", i.tipo)
                'Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("idPadre", i.idPadre)


                Me.DGUnidJerarquia.Table.AddNewRecord.EndEdit()

            Next

        Else
            DGUnidJerarquia.Table.Records.DeleteAll()

        End If
    End Sub

#End Region

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        VALOR = "NO"
        Try
            Dim numero = DGUnidJerarquia.Table.Records.Count.ToString()

            If numero = 0 Then
                Me.DGUnidJerarquia.Table.AddNewRecord.SetCurrent()
                Me.DGUnidJerarquia.Table.AddNewRecord.BeginEdit()

                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("NroOrganizacion", 1)
                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("descripcion", "")
                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("Estado", VALOR)
                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("tipo", "")
                'Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("tipo", "")

                Me.DGUnidJerarquia.Table.AddNewRecord.EndEdit()
            Else
                Me.DGUnidJerarquia.Table.AddNewRecord.SetCurrent()
                Me.DGUnidJerarquia.Table.AddNewRecord.BeginEdit()

                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("NroOrganizacion", numero + 1)
                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("descripcion", "")
                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("Estado", VALOR)
                Me.DGUnidJerarquia.Table.CurrentRecord.SetValue("tipo", "")

                Me.DGUnidJerarquia.Table.AddNewRecord.EndEdit()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cbNivelesOrg_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNivelesOrg.SelectionChangeCommitted

        Try


            If cbNivelesOrg.SelectedValue = 1 Then
                txtBusqUniOrgaJerar.Clear()

                'DGUnidJerarquia.TableDescriptor.Columns("idPadre").Width = 0
                NIVELBER = cbNivelesOrg.SelectedValue
                lblNroNiv.Text = NIVELBER
                DGUnidJerarquia.Table.Records.DeleteAll()
                txtBusqUniOrgaJerar.Select()

            Else
                'DGUnidJerarquia.TableDescriptor.Columns("idPadre").Width = 130
                txtBusqUniOrgaJerar.Clear()

                Dim nivel = cbNivelesOrg.SelectedValue
                NIVELBER = nivel + 1
                lblNroNiv.Text = nivel
                nivel = nivel - 1

                Dim liataxnivel = (From i In LISORGANIZ
                                   Where i.idCentroCosto = GEstableciento.IdEstablecimiento And
                                          i.nivel = nivel).ToList

                If liataxnivel.Count > 0 Then

                Else

                    MessageBox.Show("no existe organizacion creada en el nivel " & nivel)
                End If


            End If
            DGUnidJerarquia.Table.Records.DeleteAll()
            txtBusqUniOrgaJerar.Select()
            'GetListUnidadOrganica()
            'Idpadre()
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub cbrubroOrg_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbrubroOrg.SelectionChangeCommitted
        BuscarSegmento(cbrubroOrg.SelectedValue)
        'GETBASEJERAR()

    End Sub



    Private Sub DGUnidJerarquia_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles DGUnidJerarquia.TableControlCurrentCellKeyDown
        If e.Inner.KeyCode = Keys.Enter Then
            Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = DGUnidJerarquia.TableControl.CurrentCell
            cc.ConfirmChanges()
            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If cbrubroOrg.Text.Trim.Length > 0 Then
                    ErrorProvider1.SetError(cbrubroOrg, Nothing)
                    If cbsegmentoOrg.Text.Trim.Length > 0 Then
                        ErrorProvider1.SetError(cbsegmentoOrg, Nothing)
                        If cbNivelesOrg.Text.Trim.Length > 0 Then
                            ErrorProvider1.SetError(cbNivelesOrg, Nothing)
                            For Each JERAR In DGUnidJerarquia.Table.Records
                                If JERAR.GetValue("Estado") = "NO" Then
                                    If JERAR.GetValue("tipo") = "" Then
                                        MessageBox.Show("NO TIENE UN TIPO")
                                    Else

                                        'If Not IsDBNull(JERAR.GetValue("idPadre")) Then
                                        If txtIdUOJe.Text.Trim.Length > 0 Then

                                            guardarOrganigrama()
                                        Else
                                            If cbNivelesOrg.SelectedValue = 1 Then
                                                guardarOrganigrama()
                                            Else
                                                MessageBox.Show("NO TIENE UN IDPADRE")
                                            End If



                                        End If

                                    End If
                                End If
                            Next
                        Else
                            ErrorProvider1.SetError(cbNivelesOrg, "SELECCIONE UN NIVEL")
                        End If
                    Else
                        ErrorProvider1.SetError(cbsegmentoOrg, "SELECCIONE UN SEGMENTO")
                    End If
                Else
                    ErrorProvider1.SetError(cbrubroOrg, "SELECCIONE UN RUBRO")
                End If
            End If

        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dim M As New FormJerarquia
        M.StartPosition = FormStartPosition.CenterParent
        M.ShowDialog()
        LISTARUNIDADES()
        RELOADORGANIGRAMA()
        cbNivelesOrg.SelectedValue = -1
    End Sub

    Private Sub txtBusqUniOrgaJerar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusqUniOrgaJerar.KeyDown
        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                If cbNivelesOrg.Text.Trim.Length > 0 Then

                    If txtBusqUniOrgaJerar.Text.Trim.Length > 0 AndAlso txtBusqUniOrgaJerar.Text.Trim.Length >= 2 Then
                        PictureBox2.Visible = True
                        consulta = 2
                        BuscarUniOrganica()

                        If ConOrga.Count > 0 Then
                            popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                            PictureBox2.Visible = False

                            Dim colIndex As Integer = Me.UCBusqueUnidadNegocio.dgUnidaNegocio.TableDescriptor.FieldToColIndex(0)
                            Dim rowIndex As Integer = Me.UCBusqueUnidadNegocio.dgUnidaNegocio.Table.Records(0).GetRowIndex()
                            Me.UCBusqueUnidadNegocio.dgUnidaNegocio.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                            'Me.usercontrol.GridTotales.Focus()
                        Else

                            PictureBox2.Visible = False
                        End If

                    Else
                        consulta = 1
                        BuscarUniOrganica()

                        If ConOrga.Count > 0 Then
                            popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                            PictureBox2.Visible = False

                            Dim colIndex As Integer = Me.UCBusqueUnidadNegocio.dgUnidaNegocio.TableDescriptor.FieldToColIndex(0)
                            Dim rowIndex As Integer = Me.UCBusqueUnidadNegocio.dgUnidaNegocio.Table.Records(0).GetRowIndex()
                            Me.UCBusqueUnidadNegocio.dgUnidaNegocio.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                            'Me.usercontrol.GridTotales.Focus()
                        Else

                            PictureBox2.Visible = False
                        End If
                    End If
                Else
                    ErrorProvider1.SetError(cbNivelesOrg, "SELECCIONE UN NIVEL")
                End If
            End If
            If e.KeyCode = Keys.Down Then

                popup.Show(TryCast(sender, Syncfusion.Windows.Forms.Tools.TextBoxExt))
                Dim colIndex As Integer = Me.UCBusqueUnidadNegocio.dgUnidaNegocio.TableDescriptor.FieldToColIndex(0)
                Dim rowIndex As Integer = Me.UCBusqueUnidadNegocio.dgUnidaNegocio.Table.Records(0).GetRowIndex()
                Me.UCBusqueUnidadNegocio.dgUnidaNegocio.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
                'usercontrol.GridTotales.TableControl.CurrentCell.ShowDropDown()
            End If

            If e.KeyCode = Keys.Escape Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGuarTodo_Click(sender As Object, e As EventArgs) Handles btnGuarTodo.Click
        guardarOrganigrama()
    End Sub
End Class
