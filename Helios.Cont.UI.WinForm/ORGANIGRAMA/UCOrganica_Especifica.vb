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
Public Class UCOrganica_Especifica

#Region "ATTRIBUTES"
    Dim popup As Popup
    Public Event OKEvent()
    Public Property UCBusqueUnidadNegocio As UCBusqueUnidadNegocio


    Dim Oficina As New List(Of organizacion)
    Dim ConOrga As List(Of organizacion)
    Public VALOR As String
#End Region
#Region "CONSTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        UCBusqueUnidadNegocio = New UCBusqueUnidadNegocio(Me)
        popup = New Popup(UCBusqueUnidadNegocio)
        AddHandler UCBusqueUnidadNegocio.OKEvent, AddressOf ucB_OKEvent

        GetMappingColumnsGridUniOrgEs()
        GetMappingColumnsGridUniOrg()
        UnidadOrga()
        organigrama()

        DGUniOrEspecifica.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub
#End Region
#Region "METHOD"
    Private Sub UnidadOrga()
        Dim objSa As New OrganizacionSA
        'Dim variableBE As New organizacion With {
        '    .idEmpresa = Gempresas.IdEmpresaRuc
        '    }
        Oficina = objSa.GetObtenerOrganizacion(Gempresas.IdEmpresaRuc)
    End Sub

    Public Sub ucB_OKEvent()
        popup.Hide()
        RaiseEvent OKEvent()
    End Sub

    Private Sub GetMappingColumnsGridUniOrgEs()
        Dim dt As New DataTable
        With dt
            .Columns.Add("NroOrganizacion")
            .Columns.Add("descripcion")
            .Columns.Add("Estado")
            .Columns.Add("tipo")
        End With

        DGUniOrEspecifica.DataSource = dt
    End Sub


    Public Sub MOSTRARUNOESP(valor As Integer)
        Try

            ConOrga = (From I In Oficina
                       Where I.idPadre = valor _
                  And I.TipoOrganizacion = "ORGES").ToList


            If ConOrga.Count > 0 Then
                DGUniOrEspecifica.Table.Records.DeleteAll()
                For Each i In ConOrga
                    Me.DGUniOrEspecifica.Table.AddNewRecord.SetCurrent()
                    Me.DGUniOrEspecifica.Table.AddNewRecord.BeginEdit()
                    Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("NroOrganizacion", i.NroOrganizacion)
                    Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                    Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("Estado", "SI")
                    Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("tipo", i.tipo)

                    Me.DGUniOrEspecifica.Table.AddNewRecord.EndEdit()


                Next
            Else

                MessageBox.Show("No existe la descripción Especifica! ", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If


        Catch ex As Exception

        End Try
    End Sub

    Public Sub organigrama()
        Dim listaOrg As New List(Of TipoDirecM)
        Dim obj As New TipoDirecM


        obj = New TipoDirecM
        obj.Codigo = ""
        obj.Valor = ""
        listaOrg.Add(obj)

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


        Me.DGUniOrEspecifica.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.DGUniOrEspecifica.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.DisplayMember = "Valor"
        Me.DGUniOrEspecifica.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.ValueMember = "Codigo"
        Me.DGUniOrEspecifica.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.DataSource = listaOrg

        Me.DGUniOrEspecifica.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive

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

            ConOrga = (From I In Oficina
                       Where I.descripcion.Contains(txtBusqUniOrgaEspeci.Text) And I.TipoOrganizacion = "ORG").ToList


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
                DGUniOrEspecifica.Table.Records.DeleteAll()
            Else
                'MessageBox.Show("No existe la descripción de una Unidad Orgánica!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DGUniOrEspecifica.Table.Records.DeleteAll()
                'DGProceso.Table.Records.DeleteAll()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region



    Public Sub SAVEUNIOESP()
        Dim saveOr As New OrganizacionSA
        Dim ObjOrga As New organizacion
        Dim LisObj As New List(Of organizacion)

        Dim MENSAJE As String = String.Empty
        Try


            For Each JERAR In DGUniOrEspecifica.Table.Records
                ObjOrga = New organizacion

                If JERAR.GetValue("Estado") = "NO" Then

                    If JERAR.GetValue("descripcion") = String.Empty Then

                        MENSAJE = "NO"
                        MessageBox.Show("INGRESA DESCRIPCION")

                    Else
                        ObjOrga.idCentroCosto = GEstableciento.IdEstablecimiento
                        ObjOrga.idEmpresa = Gempresas.IdEmpresaRuc
                        ObjOrga.NroOrganizacion = CInt(JERAR.GetValue("NroOrganizacion"))
                        ObjOrga.TipoOrganizacion = "ORGES"
                        ObjOrga.descripcion = JERAR.GetValue("descripcion")
                        ObjOrga.tipo = JERAR.GetValue("tipo")
                        ObjOrga.idPadre = CInt(txtIdUO.Text)

                        LisObj.Add(ObjOrga)


                        saveOr.ListOrgani(LisObj)
                        MessageBox.Show("se guardo")

                    End If

                End If

            Next

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub txtBusqUniOrganica_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusqUniOrgaEspeci.KeyDown
        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                If txtBusqUniOrgaEspeci.Text.Trim.Length > 0 AndAlso txtBusqUniOrgaEspeci.Text.Trim.Length >= 2 Then
                    PictureBox2.Visible = True
                    UnidadOrga()
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        VALOR = "NO"
        Try
            Dim numero = DGUniOrEspecifica.Table.Records.Count.ToString()

            If numero = 0 Then
                Me.DGUniOrEspecifica.Table.AddNewRecord.SetCurrent()
                Me.DGUniOrEspecifica.Table.AddNewRecord.BeginEdit()

                Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("NroOrganizacion", 1)
                Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("descripcion", "")
                Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("Estado", VALOR)
                Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("tipo", "")


                Me.DGUniOrEspecifica.Table.AddNewRecord.EndEdit()
            Else
                Me.DGUniOrEspecifica.Table.AddNewRecord.SetCurrent()
                Me.DGUniOrEspecifica.Table.AddNewRecord.BeginEdit()

                Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("NroOrganizacion", numero + 1)
                Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("descripcion", "")
                Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("Estado", VALOR)
                Me.DGUniOrEspecifica.Table.CurrentRecord.SetValue("tipo", "")

                Me.DGUniOrEspecifica.Table.AddNewRecord.EndEdit()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DGUniOrEspecifica_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles DGUniOrEspecifica.TableControlCurrentCellKeyDown
        If e.Inner.KeyCode = Keys.Enter Then
            Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = DGUniOrEspecifica.TableControl.CurrentCell
            cc.ConfirmChanges()
            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                SAVEUNIOESP()
                UnidadOrga()
                MOSTRARUNOESP(CInt(txtIdUO.Text))
            End If

        End If
    End Sub
End Class
