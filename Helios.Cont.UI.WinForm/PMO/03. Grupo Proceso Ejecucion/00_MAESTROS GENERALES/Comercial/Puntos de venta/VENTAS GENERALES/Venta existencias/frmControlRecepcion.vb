Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools
Public Class frmControlRecepcion
    Inherits frmMaster

    Public Sub New(idDocumento As Integer, secuencia As Integer)

        InitializeComponent()
        GridCFG(dgvOrdenCompra)
        GetTableGrid()
        UbicarDocumentoFull(idDocumento, secuencia)

    End Sub

    Public Sub New(idDocumento As Integer)

        InitializeComponent()
        GridCFG(dgvOrdenCompra)
        GetTableGrid()
        UbicarDocumentoPendiente(idDocumento)

    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TopLevelGroupOptions.ShowCaption = False
        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        grid.TableOptions.SelectionBackColor = Color.Gray
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("nombreItem", GetType(String))
        dt.Columns.Add("CantEntregado", GetType(Integer))
        dt.Columns.Add("CantObservado", GetType(Integer))
        dt.Columns.Add("nombreRecepcion", GetType(String))
        dt.Columns.Add("dniRecepcion", GetType(Integer))
        dt.Columns.Add("FechaRecepcion", GetType(String))

        dgvOrdenCompra.DataSource = dt

    End Sub


    Public Sub UbicarDocumentoFull(ByVal intIdDocumento As Integer, secuencia As Integer)
        Dim objDocCompra As New DocumentoGuiaSA
        Dim objDocCompraDet As New DocumentoGuiaDetalleSA
        Dim objDocCompraDetCondicion As New DocumentoGuiaDetalleCondicionSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim listaCondicion As New List(Of documentoguiaDetalleCondicion)
        'Dim objListaOtros As New List(Of documentoOtrosDatos)

        Try
            listaCondicion = objDocCompraDetCondicion.UbicarDocumentoGuiaDetCondicionFull(intIdDocumento)



            For Each i In listaCondicion

                If (secuencia = i.secuencia) Then
                    Me.dgvOrdenCompra.Table.AddNewRecord.SetCurrent()
                    Me.dgvOrdenCompra.Table.AddNewRecord.BeginEdit()
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("nombreItem", i.descripcionCondicion)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("CantEntregado", i.cantConforme)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("CantObservado", i.cantObservado)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("nombreRecepcion", i.nombreRececpcion)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("dniRecepcion", i.dniRecepcion)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("FechaRecepcion", i.fechaActualizacion)
                    Me.dgvOrdenCompra.Table.AddNewRecord.EndEdit()
                End If

            Next


        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub UbicarDocumentoPendiente(ByVal intIdDocumento As Integer)
        Dim objDocCompra As New DocumentoGuiaSA
        Dim objDocCompraDet As New DocumentoGuiaDetalleSA
        Dim objDocCompraDetCondicion As New DocumentoGuiaDetalleCondicionSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim listaCondicion As New List(Of documentoguiaDetalleCondicion)
        'Dim objListaOtros As New List(Of documentoOtrosDatos)

        Try
            listaCondicion = objDocCompraDetCondicion.UbicarDocumentoGuiaDetCondicionFull(intIdDocumento)

            For Each i In listaCondicion

                Me.dgvOrdenCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvOrdenCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("nombreItem", i.descripcionCondicion)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("CantEntregado", i.cantConforme)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("CantObservado", i.cantObservado)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("nombreRecepcion", i.nombreRececpcion)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("dniRecepcion", i.dniRecepcion)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("FechaRecepcion", i.fechaActualizacion)
                Me.dgvOrdenCompra.Table.AddNewRecord.EndEdit()
            Next


        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

End Class