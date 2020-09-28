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

Public Class frmEstadoCronograma
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'GridCFG(dgvCompra)

        'Loadcontroles()
        'GetTableGrid()
        'ConfiguracionInicio()

      
    End Sub

#Region "Metodos"


    Public Sub UpdateGastoLista()
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()
        Dim cronograma As New Cronograma
        Dim lista As New List(Of Cronograma)
        Try
            For Each i As Record In GridGroupingControl1.Table.Records

                If i.GetValue("valBonif") = "S" Then
                    cronograma = New Cronograma
                    cronograma.idCronograma = i.GetValue("idcronograma")
                    cronograma.estado = txttipo.Text
                    cronograma.idDocumentoPago = 0

                    lista.Add(cronograma)
                End If
            Next

            LibroSA.ActualizarEstadoLista(lista)

            Dispose()
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub




    'Public Sub UbicarDocumentosPagosProgramados(intIdItem As Integer, tipoRazon As String, tipoestado As String, fechaprog As DateTime)

    '    Dim documentoVentaSA As New CronogramaSA
    '    Dim documentoLibro As New List(Of Cronograma)
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim dt As New DataTable
    '    Dim entidadSA As New entidadSA
    '    Dim personaSA As New PersonaSA
    '    Dim monto As Decimal = CDec(0.0)
    '    Dim montome As Decimal = CDec(0.0)


    '    Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


    '    dt.Columns.Add("nombres", GetType(String))
    '    dt.Columns.Add("serie", GetType(String))
    '    dt.Columns.Add("nrodoc", GetType(String))
    '    dt.Columns.Add("monto", GetType(Decimal))
    '    dt.Columns.Add("montome", GetType(Decimal))
    '    dt.Columns.Add("tipo", GetType(String))
    '    dt.Columns.Add("importe", GetType(Decimal))
    '    dt.Columns.Add("importeme", GetType(Decimal))
    '    dt.Columns.Add("glosa", GetType(String))
    '    dt.Columns.Add("fecha", GetType(Date))
    '    dt.Columns.Add("fechaPago", GetType(Date))
    '    dt.Columns.Add("estado", GetType(String))
    '    dt.Columns.Add("idcronograma", GetType(Integer))
    '    dt.Columns.Add("id", GetType(Integer))
    '    dt.Columns.Add("idDocRef", GetType(Integer))
    '    dt.Columns.Add("chBonif", GetType(Boolean))
    '    dt.Columns.Add("valBonif", GetType(String))

    '    documentoLibro = documentoVentaSA.GetPagosxProgramacion(intIdItem, tipoRazon, tipoestado, fechaprog)

    '    If Not IsNothing(documentoLibro) Then


    '        For Each i In documentoLibro
    '            Dim dr As DataRow = dt.NewRow()



    '            If IsNothing(i.identidad) Then

    '            Else

    '                Select Case i.tipoRazon
    '                    Case TIPO_ENTIDAD.PROVEEDOR
    '                        dr(13) = i.identidad
    '                        With entidadSA.UbicarEntidadPorID(i.identidad).First
    '                            dr(0) = .nombreCompleto
    '                        End With
    '                    Case TIPO_ENTIDAD.CLIENTE
    '                        dr(13) = i.identidad
    '                        With entidadSA.UbicarEntidadPorID(i.identidad).First
    '                            dr(0) = .nombreCompleto
    '                        End With
    '                    Case "TR"
    '                        dr(13) = i.identidad
    '                        With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
    '                            dr(0) = .nombreCompleto
    '                        End With
    '                End Select
    '            End If

    '            dr(1) = i.serie
    '            dr(2) = i.nrodoc

    '            dr(3) = i.montoAutorizadoMN
    '            dr(4) = i.montoAutorizadoME

    '            If i.tipo = "P" Then
    '                dr(5) = "Pago"
    '            ElseIf i.tipo = "C" Then
    '                dr(5) = "Cobro"
    '            End If

    '            dr(6) = CDec(0.0)
    '            dr(7) = CDec(0.0)
    '            dr(8) = i.glosa




    '            dr(9) = i.fechaoperacion
    '            dr(10) = i.fechaPago.GetValueOrDefault

    '            If i.estado = "PN" Then
    '                dr(11) = "Pendiente"
    '            ElseIf i.estado = "AP" Then
    '                dr(11) = "Aprobado"
    '            ElseIf i.estado = "OB" Then
    '                dr(11) = "Observado"
    '            ElseIf i.estado = "PG" Then
    '                dr(11) = "Desembolsado"
    '            End If

    '            dr(12) = i.idCronograma

    '            dr(14) = i.idDocumentoRef
    '            dr(14) = i.idDocumentoRef

    '            dr(15) = False
    '            dr(16) = "N"
    '            dr(15) = True
    '            dr(16) = "S"


    '            monto += i.montoAutorizadoMN
    '            montome += i.montoAutorizadoME


    '            dt.Rows.Add(dr)

    '        Next

    '        txtImporteMN.Value = monto
    '        txtImporteME.Value = montome

    '        GridGroupingControl1.DataSource = dt
    '        dgvProcesoCrono.ShowGroupDropArea = False
    '        dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
    '        dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

    '        Me.GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One


    '    Else

    '    End If


    'End Sub



    Public Sub UbicarDocumentoDetalleCobros(intIdItem As Integer, tipoRazon As String, tipoestado As String, fechaprog As DateTime, tipomoneda As String)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))
        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))

        documentoLibro = documentoVentaSA.GetCronogramaDetalleTipoCobros(intIdItem, tipoRazon, tipoestado, fechaprog, tipomoneda)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()



                If IsNothing(i.identidad) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(13) = i.identidad
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                dr(0) = .nombreCompleto
                            End With
                    End Select
                End If

                dr(1) = i.serie
                dr(2) = i.nrodoc

                dr(3) = i.montoAutorizadoMN
                dr(4) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(5) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(5) = "Cobro"
                End If

                dr(6) = CDec(0.0)
                dr(7) = CDec(0.0)
                dr(8) = i.glosa




                dr(9) = i.fechaoperacion
                dr(10) = i.fechaPago.GetValueOrDefault

                If i.estado = "PN" Then
                    dr(11) = "Pendiente"
                ElseIf i.estado = "AP" Then
                    dr(11) = "Aprobado"
                ElseIf i.estado = "OB" Then
                    dr(11) = "Observado"
                ElseIf i.estado = "PG" Then
                    dr(11) = "Desembolsado"
                End If

                dr(12) = i.idCronograma

                'dr(14) = i.idDocumentoRef
                dr(14) = i.idDocumentoRef

                'dr(15) = False
                'dr(16) = "N"
                dr(15) = True
                dr(16) = "S"


                monto += i.montoAutorizadoMN
                montome += i.montoAutorizadoME


                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            GridGroupingControl1.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub


    Public Sub UbicarDocumentoDetalleAsiento(intIdItem As Integer, tipoRazon As String, tipoestado As String, mes As Integer, tipoProg As String, tipoMoneda As String)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))
        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))
        dt.Columns.Add("idDocRefDetalle", GetType(Integer))

        documentoLibro = documentoVentaSA.GetCronogramaTipoAsientoMes(intIdItem, tipoRazon, tipoestado, mes, tipoProg, tipoMoneda)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()



                If IsNothing(i.identidad) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(15) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(15) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(15) = i.identidad
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                dr(0) = .nombreCompleto
                            End With
                    End Select
                End If

                dr(1) = i.cuenta
                dr(2) = i.descripcion

                dr(3) = " "
                dr(4) = i.nrodoc

                dr(5) = i.montoAutorizadoMN
                dr(6) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(7) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(7) = "Cobro"
                ElseIf i.tipo = "PA" Then
                    dr(7) = "Pago Asiento"
                End If

                dr(8) = CDec(0.0)
                dr(9) = CDec(0.0)
                dr(10) = i.glosa




                dr(11) = i.fechaoperacion
                dr(12) = i.fechaPago.GetValueOrDefault

                If i.estado = "PN" Then
                    dr(13) = "Pendiente"
                ElseIf i.estado = "AP" Then
                    dr(13) = "Aprobado"
                ElseIf i.estado = "OB" Then
                    dr(13) = "Observado"
                ElseIf i.estado = "PG" Then
                    dr(13) = "Desembolsado"
                End If

                dr(14) = i.idCronograma

                'dr(14) = i.idDocumentoRef
                dr(16) = i.idDocumentoRef

                'dr(15) = False
                'dr(16) = "N"
                dr(17) = True
                dr(18) = "S"

                dr(19) = i.idDocumentoDetalleRef
                'monto += i.montoAutorizadoMN
                'montome += i.montoAutorizadoME


                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            GridGroupingControl1.DataSource = dt

            If tipoMoneda = "1" Then
                GridGroupingControl1.TableDescriptor.Columns("montome").Width = 0
                GridGroupingControl1.TableDescriptor.Columns("serie").Width = 0

            ElseIf tipoMoneda = "2" Then
                GridGroupingControl1.TableDescriptor.Columns("montomn").Width = 0
                GridGroupingControl1.TableDescriptor.Columns("serie").Width = 0
            End If

            GridGroupingControl1.TableDescriptor.Columns("cuenta").Width = 70
            GridGroupingControl1.TableDescriptor.Columns("descripcion").Width = 180


            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub
    Public Sub UbicarDocumentoDetalleMes(intIdItem As Integer, tipoRazon As String, tipoestado As String, mes As Integer, tipoProg As String, TipoMoneda As String)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))
        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))

        documentoLibro = documentoVentaSA.GetCronogramaDetalleTipoMes(intIdItem, tipoRazon, tipoestado, mes, tipoProg, TipoMoneda)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()



                If IsNothing(i.identidad) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(13) = i.identidad
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                dr(0) = .nombreCompleto
                            End With
                    End Select
                End If

                dr(1) = i.serie
                dr(2) = i.nrodoc

                dr(3) = i.montoAutorizadoMN
                dr(4) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(5) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(5) = "Cobro"
                End If

                dr(6) = CDec(0.0)
                dr(7) = CDec(0.0)
                dr(8) = i.glosa




                dr(9) = i.fechaoperacion
                dr(10) = i.fechaPago.GetValueOrDefault

                If i.estado = "PN" Then
                    dr(11) = "Pendiente"
                ElseIf i.estado = "AP" Then
                    dr(11) = "Aprobado"
                ElseIf i.estado = "OB" Then
                    dr(11) = "Observado"
                ElseIf i.estado = "PG" Then
                    dr(11) = "Desembolsado"
                End If

                dr(12) = i.idCronograma

                'dr(14) = i.idDocumentoRef
                dr(14) = i.idDocumentoRef

                'dr(15) = False
                'dr(16) = "N"
                dr(15) = True
                dr(16) = "S"


                monto += i.montoAutorizadoMN
                montome += i.montoAutorizadoME


                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            GridGroupingControl1.DataSource = dt



            If TipoMoneda = "1" Then
                GridGroupingControl1.TableDescriptor.Columns("montome").Width = 0

            ElseIf TipoMoneda = "2" Then
                GridGroupingControl1.TableDescriptor.Columns("montomn").Width = 0
            End If
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub


    Public Sub UbicarDocumentoDetalle(intIdItem As Integer, tipoRazon As String, tipoestado As String, fechaprog As DateTime, tipomoneda As String, fechaVen As DateTime)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))
        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))

        documentoLibro = documentoVentaSA.GetCronogramaDetalleTipo(intIdItem, tipoRazon, tipoestado, fechaprog, tipomoneda, fechaVen)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()



                If IsNothing(i.identidad) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(13) = i.identidad
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                dr(0) = .nombreCompleto
                            End With
                    End Select
                End If

                dr(1) = i.serie
                dr(2) = i.nrodoc

                dr(3) = i.montoAutorizadoMN
                dr(4) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(5) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(5) = "Cobro"
                End If

                dr(6) = CDec(0.0)
                dr(7) = CDec(0.0)
                dr(8) = i.glosa




                dr(9) = i.fechaoperacion
                dr(10) = i.fechaPago.GetValueOrDefault

                If i.estado = "PN" Then
                    dr(11) = "Pendiente"
                ElseIf i.estado = "AP" Then
                    dr(11) = "Aprobado"
                ElseIf i.estado = "OB" Then
                    dr(11) = "Observado"
                ElseIf i.estado = "PG" Then
                    dr(11) = "Desembolsado"
                End If

                dr(12) = i.idCronograma

                'dr(14) = i.idDocumentoRef
                dr(14) = i.idDocumentoRef

                'dr(15) = False
                'dr(16) = "N"
                dr(15) = True
                dr(16) = "S"


                monto += i.montoAutorizadoMN
                montome += i.montoAutorizadoME


                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            GridGroupingControl1.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub


#End Region

    Private Sub frmEstadoCronograma_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GridGroupingControl1_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridGroupingControl1.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chBonif" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If
    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCellClick
        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub


    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub GridGroupingControl1_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.GridGroupingControl1.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal
                Case 18

                  
                Case 16

                    '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                    If style.Enabled Then
                        Dim column As Integer = Me.GridGroupingControl1.TableModel.NameToColIndex("chBonif")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.GridGroupingControl1.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chBonif" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '      MsgBox(False)
                                Me.GridGroupingControl1.TableModel(RowIndex, 17).CellValue = "N" ' curStatus

                                '******************************************************************

                            Else
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                Me.GridGroupingControl1.TableModel(RowIndex, 17).CellValue = "S"

                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
            End Select

            Me.GridGroupingControl1.TableControl.Refresh()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        If GridGroupingControl1.Table.Records.Count > 0 Then
            If txttipo.Text = "PG" Then


                Dim lista As New List(Of documentocompra)
                Dim docCompra As New documentocompra
                Dim montopago As Decimal
                Dim montopagome As Decimal

                For Each i As Record In GridGroupingControl1.Table.Records

                    If i.GetValue("valBonif") = "S" Then
                        docCompra = New documentocompra
                        docCompra.idCentroCosto = i.GetValue("idcronograma")
                        docCompra.idDocumento = i.GetValue("idDocRef")
                        docCompra.importeTotal = i.GetValue("monto")
                        docCompra.importeUS = i.GetValue("montome")
                        montopago += i.GetValue("monto")
                        montopagome += i.GetValue("montome")

                        lista.Add(docCompra)
                    End If
                Next

                If Not lista.Count > 0 Then
                    MessageBox.Show("Seleccione al menos 1 item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim f As New frmAprobadoCronograma


                f.ListaMontos = lista
                f.txtGlosa.Text = "POR PAGO A PROVEEDOR"
                f.txtProveedor.Text = txtProveedor.Text
                f.txtProveedor.Tag = txtProveedor.Tag


                'f.txtmonedaprog.Text = "NACIONAL"
                'f.txtmontomn.Value = montopago
                'f.txtmontome.Value = montopago / TmpTipoCambioTransaccionVenta

                f.txtmonedaprog.Text = TextBox1.Text
                If TextBox1.Text = "NACIONAL" Then
                    f.txtmontomn.Value = montopago
                    f.txtmontome.Value = montopago / TmpTipoCambioTransaccionVenta
                ElseIf TextBox1.Text = "EXTRANJERO" Then
                    f.txtmontomn.Value = montopagome * TmpTipoCambioTransaccionVenta
                    f.txtmontome.Value = montopagome
                End If


                f.manipulacionEstado = ENTITY_ACTIONS.INSERT
                f.txttipoProveedor.Text = txttipoProveedor.Text
                f.listaDocumentosPorPagar(lista)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                'Programacion()
                Close()

            ElseIf txttipo.Text = "PGA" Then




                Dim lista As New List(Of documentoLibroDiarioDetalle)
                Dim docCompra As New documentoLibroDiarioDetalle
                Dim montopago As Decimal
                Dim montopagome As Decimal

                For Each i As Record In GridGroupingControl1.Table.Records

                    If i.GetValue("valBonif") = "S" Then
                        docCompra = New documentoLibroDiarioDetalle
                        docCompra.idEstablecimiento = i.GetValue("idcronograma")
                        docCompra.idDocumento = i.GetValue("idDocRef")
                        docCompra.secuencia = i.GetValue("idDocRefDetalle")
                        docCompra.importeMN = i.GetValue("monto")
                        docCompra.importeME = i.GetValue("montome")
                        montopago += i.GetValue("monto")
                        montopagome += i.GetValue("montome")

                        lista.Add(docCompra)
                    End If
                Next

                If Not lista.Count > 0 Then
                    MessageBox.Show("Seleccione al menos 1 item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim f As New frmAprobadoCronograma


                f.ListaMontosAsiento = lista
                f.txtGlosa.Text = "POR ASIENTO MANUAL"
                f.txtProveedor.Text = txtProveedor.Text
                f.txtProveedor.Tag = txtProveedor.Tag



                f.txtmonedaprog.Text = TextBox1.Text
                If TextBox1.Text = "NACIONAL" Then
                    f.txtmontomn.Value = montopago
                    f.txtmontome.Value = montopago / TmpTipoCambioTransaccionVenta
                ElseIf TextBox1.Text = "EXTRANJERO" Then
                    f.txtmontomn.Value = montopagome * TmpTipoCambioTransaccionVenta
                    f.txtmontome.Value = montopagome
                End If

                f.manipulacionEstado = ENTITY_ACTIONS.INSERT
                f.txttipoProveedor.Text = txttipoProveedor.Text
                f.listaAsientosPorPagar(lista)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                'Programacion()
                Close()


            Else
                UpdateGastoLista()
            End If
        Else
            MessageBox.Show("No hay documentos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class