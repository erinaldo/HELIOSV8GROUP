
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
Public Class UCJerarquia

#Region "ATRIBUTOS"

    Public LISTAUNIDAD As List(Of centrocosto)
    Public VALOR As String
    Dim IDS As Integer
#End Region
#Region "CONSTRUCTOR"
    'Sub New(ID As Integer)

    '    ' Esta llamada es exigida por el diseñador.
    '    InitializeComponent()
    '    'LISTARUNIDADES()
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    GetMappingColumnsGrid()
    '    RELOAD(ID)
    '    IDS = ID
    '    'RELOAD()

    '    'FormatoGridAvanzado(DGJerarquia, True, False)
    'End Sub
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        'InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InitializeComponent()
        LISTARUNIDADES()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetMappingColumnsGrid()
        'RELOAD(ID)
        RELOAD()
        'IDS = ID
    End Sub
#End Region
#Region "METODOS"

    Public Sub LISTARUNIDADES()

        Try
            Dim SA As New CentrocostosSA

            LISTAUNIDAD = New List(Of centrocosto)
            LISTAUNIDAD = SA.GetObtenerEstablecimiento2(Gempresas.IdEmpresaRuc)


            'Dim Listrubro = (From i In LISTAUNIDAD
            '                 Where i.TipoEstab = "RU").ToList

            'cbrubro.DisplayMember = "nombre"
            'cbrubro.ValueMember = "idCentroCosto"
            'cbrubro.DataSource = Listrubro
        Catch ex As Exception

        End Try


    End Sub

    'Public Sub RELOAD(ID As Integer)
    Public Sub RELOAD()
        'Public Sub RELOAD()
        Dim CC = (From I In LISTAUNIDAD
                  Where I.idCentroCosto = GEstableciento.IdEstablecimiento And
                      I.TipoEstab = "UN"
                  Select I.jerarquia).FirstOrDefault


        If CC.Count > 0 Then
            DGJerarquia.Table.Records.DeleteAll()
            For Each i In CC
                Me.DGJerarquia.Table.AddNewRecord.SetCurrent()
                Me.DGJerarquia.Table.AddNewRecord.BeginEdit()
                Me.DGJerarquia.Table.CurrentRecord.SetValue("idCentroCosto", i.idCentroCosto)
                Me.DGJerarquia.Table.CurrentRecord.SetValue("nivel", i.nivel)
                Me.DGJerarquia.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                Me.DGJerarquia.Table.CurrentRecord.SetValue("Estado", "SI")

                Me.DGJerarquia.Table.AddNewRecord.EndEdit()

            Next
            Me.DGJerarquia.Refresh()
        Else
            DGJerarquia.Table.Records.DeleteAll()
        End If
    End Sub




    'Public Sub BuscarSegmento(idRubro As Integer)

    '    Dim ListSegmento = (From i In LISTAUNIDAD
    '                        Where i.TipoEstab = "SE" And i.idpadre = idRubro).ToList

    '    cbsegmento.DisplayMember = "nombre"
    '    cbsegmento.ValueMember = "idCentroCosto"
    '    cbsegmento.DataSource = ListSegmento


    'End Sub


    'Public Sub BuscarUnidades(idSegmento As Integer)

    '    Dim ListUnidad = (From i In LISTAUNIDAD
    '                      Where i.TipoEstab = "UN" And i.idpadre = idSegmento).ToList

    '    cbunidadnegocio.DisplayMember = "nombre"
    '    cbunidadnegocio.ValueMember = "idCentroCosto"
    '    cbunidadnegocio.DataSource = ListUnidad
    'End Sub

    Public Sub SAVEJERARQUIA()
        Dim MENSAJE As String = String.Empty
        Try
            Dim jeraSA As New JerarquiaSA
            Dim jerarBL As New jerarquia
            Dim LISTJER As New List(Of jerarquia)


            For Each JERAR In DGJerarquia.Table.Records
                jerarBL = New jerarquia
                If JERAR.GetValue("Estado") = "NO" Then
                    If JERAR.GetValue("descripcion") = String.Empty Then

                        MENSAJE = "NO"
                        MessageBox.Show("INGRESA DESCRIPCION")

                    Else
                        jerarBL.idCentroCosto = GEstableciento.IdEstablecimiento
                        jerarBL.nivel = CInt(JERAR.GetValue("nivel"))
                        jerarBL.descripcion = JERAR.GetValue("descripcion")

                        LISTJER.Add(jerarBL)

                    End If

                End If
            Next
            If MENSAJE = "NO" Then
            Else
                jeraSA.SaveJerarquia(LISTJER)
                MessageBox.Show("se guardo")
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetMappingColumnsGrid()
        Dim dt As New DataTable
        With dt
            .Columns.Add("idCentroCosto")
            .Columns.Add("nivel")
            .Columns.Add("descripcion")
            .Columns.Add("Estado")
        End With

        DGJerarquia.DataSource = dt
    End Sub

#End Region

    Private Sub btnGuard_Click(sender As Object, e As EventArgs) Handles btnGuard.Click
        'If cbunidadnegocio.Text.Trim.Length > 0 Then
        'ErrorProvider1.SetError(cbunidadnegocio, Nothing)
        'If DGJerarquia.Table.Records.Count > 0 Then
        '    'ValidaCajaDuplicada()
        '    SAVEJERARQUIA()
        '    LISTARUNIDADES()
        '    'RELOAD(IDS)
        '    RELOAD()
        '    'RELOAD()
        '    'Me.Close()
        'Else
        '    MessageBox.Show("INGRESE NIVELES")
        'End If

        'Else
        '    ErrorProvider1.SetError(cbunidadnegocio, "Ingrese UNIDAD DE NEGOCIO")
        'End If

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        VALOR = "NO"
        Try
            Dim numero = DGJerarquia.Table.Records.Count.ToString()

            If numero = 0 Then
                Me.DGJerarquia.Table.AddNewRecord.SetCurrent()
                Me.DGJerarquia.Table.AddNewRecord.BeginEdit()
                'Me.DGJerarquia.Table.CurrentRecord.SetValue("idCentroCosto", cbunidadnegocio.SelectedValue.ToString.ToUpper)
                Me.DGJerarquia.Table.CurrentRecord.SetValue("idCentroCosto", lblUninegoc.Tag)
                Me.DGJerarquia.Table.CurrentRecord.SetValue("nivel", 1)
                Me.DGJerarquia.Table.CurrentRecord.SetValue("descripcion", "")
                Me.DGJerarquia.Table.CurrentRecord.SetValue("Estado", VALOR)

                Me.DGJerarquia.Table.AddNewRecord.EndEdit()
            Else
                Me.DGJerarquia.Table.AddNewRecord.SetCurrent()
                Me.DGJerarquia.Table.AddNewRecord.BeginEdit()
                'Me.DGJerarquia.Table.CurrentRecord.SetValue("idCentroCosto", cbunidadnegocio.SelectedValue.ToString.ToUpper)
                Me.DGJerarquia.Table.CurrentRecord.SetValue("idCentroCosto", lblUninegoc.Tag)
                Me.DGJerarquia.Table.CurrentRecord.SetValue("nivel", numero + 1)
                Me.DGJerarquia.Table.CurrentRecord.SetValue("descripcion", "")
                Me.DGJerarquia.Table.CurrentRecord.SetValue("Estado", VALOR)

                Me.DGJerarquia.Table.AddNewRecord.EndEdit()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnElmi_Click(sender As Object, e As EventArgs) Handles btnElmi.Click

    End Sub

    Private Sub DGJerarquia_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles DGJerarquia.TableControlCurrentCellKeyDown
        If e.Inner.KeyCode = Keys.Enter Then
            Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = DGJerarquia.TableControl.CurrentCell
            cc.ConfirmChanges()
            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If DGJerarquia.Table.Records.Count > 0 Then
                    'ValidaCajaDuplicada()
                    SAVEJERARQUIA()
                    LISTARUNIDADES()
                    'RELOAD(IDS)
                    RELOAD()
                    'RELOAD()
                    'Me.Close()
                Else
                    MessageBox.Show("INGRESE NIVELES")
                End If

            End If
        End If

    End Sub
End Class
