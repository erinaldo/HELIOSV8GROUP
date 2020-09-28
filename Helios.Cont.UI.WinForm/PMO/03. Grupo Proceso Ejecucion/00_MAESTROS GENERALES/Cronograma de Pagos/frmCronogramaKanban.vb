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

Imports Syncfusion.Diagnostics
Imports Syncfusion.Styles
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms



Public Class frmCronogramaKanban


    Public Property MonedaTrabajo() As String
    'Public Property fechaprogramada As DateTime

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvProcesoCrono)
        GridCFG(dgvProcesoAprobado)
        GridCFG(dgvProcesoObservado)
        GridCFG(dgvProcesoPago)
        GetTableGrid1()
        GetTableGrid2()
        GetTableGrid3()
        GetTableGrid4()
        MonedaTrabajo = "1"
        'Programacion(fechaprogramada)
        'SumarioColumnas()
    End Sub

#Region "Metodos"


    Sub GetTableGrid1()
        Dim dt As New DataTable()
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("nurmeroDoc", GetType(String))
        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechapago", GetType(Date))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("iddocumentopago", GetType(Integer))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoPago", GetType(String))
        dgvProcesoCrono.DataSource = dt
    End Sub

    Sub GetTableGrid2()
        Dim dt As New DataTable()

        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechapago", GetType(Date))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("iddocumentopago", GetType(Integer))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoPago", GetType(String))
        dgvProcesoAprobado.DataSource = dt
    End Sub

    Sub GetTableGrid3()
        Dim dt As New DataTable()

        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechapago", GetType(Date))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("iddocumentopago", GetType(Integer))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoPago", GetType(String))
        dgvProcesoObservado.DataSource = dt
    End Sub

    Sub GetTableGrid4()
        Dim dt As New DataTable()

        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechapago", GetType(Date))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("iddocumentopago", GetType(Integer))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoPago", GetType(String))
        dgvProcesoPago.DataSource = dt
    End Sub


    Public Sub UpdateGastoDeleteCobro(idCronograma As Integer, estado As String, iddoc As Integer)
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()


        With nDocumentoLibro

            .idCronograma = idCronograma
            .estado = estado
            .idDocumentoPago = 0
            '.montoAutorizadoMN = txtImporteMN.Value
            '.montoAutorizadoME = txtImporteME.Value
            '.fechaoperacion = txtFecha.Value
            '.usuarioActualizacion = "Jiuni"
            '.fechaActualizacion = DateTime.Now

        End With

        LibroSA.ActualizarEstadoDeleteCobro(nDocumentoLibro, iddoc)



    End Sub

    Public Sub UpdateGastoDelete(idCronograma As Integer, estado As String, iddoc As Integer)
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()


        With nDocumentoLibro

            .idCronograma = idCronograma
            .estado = estado
            .idDocumentoPago = 0
            '.montoAutorizadoMN = txtImporteMN.Value
            '.montoAutorizadoME = txtImporteME.Value
            '.fechaoperacion = txtFecha.Value
            '.usuarioActualizacion = "Jiuni"
            '.fechaActualizacion = DateTime.Now

        End With

        LibroSA.ActualizarEstadoDelete(nDocumentoLibro, iddoc)



    End Sub


    Public Sub UpdateGasto(idCronograma As Integer, estado As String)
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()


        With nDocumentoLibro

            .idCronograma = idCronograma
            .estado = estado
            .idDocumentoPago = 0
            '.montoAutorizadoMN = txtImporteMN.Value
            '.montoAutorizadoME = txtImporteME.Value
            '.fechaoperacion = txtFecha.Value
            '.usuarioActualizacion = "Jiuni"
            '.fechaActualizacion = DateTime.Now

        End With

        LibroSA.ActualizarEstado(nDocumentoLibro)



    End Sub




    Public Sub ProgramacionXMes(mes As Integer, Moneda As String)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)

        dgvProcesoCrono.Table.Records.DeleteAll()
        dgvProcesoAprobado.Table.Records.DeleteAll()
        dgvProcesoObservado.Table.Records.DeleteAll()
        dgvProcesoPago.Table.Records.DeleteAll()
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("iddocumentopago", GetType(Integer))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoPago", GetType(String))


        documentoLibro = documentoVentaSA.GetCronogramaTrabajo(mes, Moneda)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro

                If i.estado = "PN" Then

                    Me.dgvProcesoCrono.Table.AddNewRecord.SetCurrent()
                    Me.dgvProcesoCrono.Table.AddNewRecord.BeginEdit()

                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipo", i.tipo)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipocambio", CDec(0.0))
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("moneda", i.moneda)
                    If i.tipo = "P" Then
                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipoPago", "C")
                    ElseIf i.tipo = "PA" Then
                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipoPago", "P")
                    End If


                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR

                            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case "TR"
                            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("id", i.identidad)
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                    End Select


                    Me.dgvProcesoCrono.Table.AddNewRecord.EndEdit()
                    If cboMoneda.Text = "NACIONAL" Then
                        dgvProcesoCrono.TableDescriptor.Columns("montome").Width = 0
                    ElseIf cboMoneda.Text = "EXTRANJERO" Then
                        dgvProcesoCrono.TableDescriptor.Columns("montomn").Width = 0
                    End If


                ElseIf i.estado = "AP" Then

                    Me.dgvProcesoAprobado.Table.AddNewRecord.SetCurrent()
                    Me.dgvProcesoAprobado.Table.AddNewRecord.BeginEdit()

                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipo", i.tipo)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipocambio", CDec(0.0))
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("moneda", i.moneda)
                    If i.tipo = "P" Then
                        Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipoPago", "C")
                    ElseIf i.tipo = "PA" Then
                        Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipoPago", "P")
                    End If

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR

                            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case "TR"
                            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                    End Select

                    Me.dgvProcesoAprobado.Table.AddNewRecord.EndEdit()

                    If cboMoneda.Text = "NACIONAL" Then
                        dgvProcesoAprobado.TableDescriptor.Columns("montome").Width = 0
                    ElseIf cboMoneda.Text = "EXTRANJERO" Then
                        dgvProcesoAprobado.TableDescriptor.Columns("montomn").Width = 0
                    End If

                ElseIf i.estado = "OB" Then


                    Me.dgvProcesoObservado.Table.AddNewRecord.SetCurrent()
                    Me.dgvProcesoObservado.Table.AddNewRecord.BeginEdit()

                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipo", i.tipo)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipocambio", CDec(0.0))
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("moneda", i.moneda)
                    If i.tipo = "P" Then
                        Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipoPago", "C")
                    ElseIf i.tipo = "PA" Then
                        Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipoPago", "P")
                    End If

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR

                            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case "TR"
                            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                    End Select



                    Me.dgvProcesoObservado.Table.AddNewRecord.EndEdit()
                    If cboMoneda.Text = "NACIONAL" Then
                        dgvProcesoObservado.TableDescriptor.Columns("montome").Width = 0
                    ElseIf cboMoneda.Text = "EXTRANJERO" Then
                        dgvProcesoObservado.TableDescriptor.Columns("montomn").Width = 0
                    End If

                ElseIf i.estado = "PG" Then


                    Me.dgvProcesoPago.Table.AddNewRecord.SetCurrent()
                    Me.dgvProcesoPago.Table.AddNewRecord.BeginEdit()

                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipo", i.tipo)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipocambio", CDec(0.0))
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("moneda", i.moneda)
                    If i.tipo = "P" Then
                        Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipoPago", "C")
                    ElseIf i.tipo = "PA" Then
                        Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipoPago", "P")
                    End If

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR

                            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoPago.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoPago.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case "TR"
                            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("id", i.identidad)
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                Me.dgvProcesoPago.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                    End Select

                    Me.dgvProcesoPago.Table.AddNewRecord.EndEdit()

                    If cboMoneda.Text = "NACIONAL" Then
                        dgvProcesoPago.TableDescriptor.Columns("montome").Width = 0
                    ElseIf cboMoneda.Text = "EXTRANJERO" Then
                        dgvProcesoPago.TableDescriptor.Columns("montomn").Width = 0
                    End If

                End If

            Next



            Me.dgvProcesoPago.TopLevelGroupOptions.ShowCaption = False



        Else

        End If

    End Sub


    Public Sub Programacion(fechaprog As DateTime, tipoprog As String, fechaVen As DateTime)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)

        dgvProcesoCrono.Table.Records.DeleteAll()
        dgvProcesoAprobado.Table.Records.DeleteAll()
        dgvProcesoObservado.Table.Records.DeleteAll()
        dgvProcesoPago.Table.Records.DeleteAll()
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechapago", GetType(Date))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("iddocumentopago", GetType(Integer))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("moneda", GetType(String))

        documentoLibro = documentoVentaSA.GetCronogramaTipo(fechaprog, tipoprog, fechaVen)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro

                If i.estado = "PN" Then

                    Me.dgvProcesoCrono.Table.AddNewRecord.SetCurrent()
                    Me.dgvProcesoCrono.Table.AddNewRecord.BeginEdit()
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipocambio", i.tipocambio)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("glosa", i.glosa)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("moneda", i.moneda)

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR

                            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case "TR"
                            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("id", i.identidad)
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                    End Select

                    If i.tipo = "P" Then
                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipo", "Pago")
                    ElseIf i.tipo = "C" Then
                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipo", "Cobro")
                    ElseIf i.tipo = "PA" Then
                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipo", "Pago Asiento")
                    End If

                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("fecha", i.fechaoperacion)
                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("fechapago", i.fechaPago)


                    Me.dgvProcesoCrono.Table.AddNewRecord.EndEdit()


                ElseIf i.estado = "AP" Then

                    Me.dgvProcesoAprobado.Table.AddNewRecord.SetCurrent()
                    Me.dgvProcesoAprobado.Table.AddNewRecord.BeginEdit()
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipocambio", i.tipocambio)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("glosa", i.glosa)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("moneda", i.moneda)

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR

                            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case "TR"
                            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                    End Select

                    If i.tipo = "P" Then
                        Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipo", "Pago")
                    ElseIf i.tipo = "C" Then
                        Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipo", "Cobro")
                    End If

                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("fecha", i.fechaoperacion)
                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("fechapago", i.fechaPago)

                    Me.dgvProcesoAprobado.Table.AddNewRecord.EndEdit()

                ElseIf i.estado = "OB" Then


                    Me.dgvProcesoObservado.Table.AddNewRecord.SetCurrent()
                    Me.dgvProcesoObservado.Table.AddNewRecord.BeginEdit()
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipocambio", i.tipocambio)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("glosa", i.glosa)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("moneda", i.moneda)
                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR

                            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case "TR"
                            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("id", i.identidad)
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                    End Select

                    If i.tipo = "P" Then
                        Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipo", "Pago")
                    ElseIf i.tipo = "C" Then
                        Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipo", "Cobro")
                    End If

                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("fecha", i.fechaoperacion)
                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("fechapago", i.fechaPago)

                    Me.dgvProcesoObservado.Table.AddNewRecord.EndEdit()

                ElseIf i.estado = "PG" Then


                    Me.dgvProcesoPago.Table.AddNewRecord.SetCurrent()
                    Me.dgvProcesoPago.Table.AddNewRecord.BeginEdit()
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipocambio", i.tipocambio)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("glosa", i.glosa)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("moneda", i.moneda)

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR

                            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoPago.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("id", i.identidad)
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                Me.dgvProcesoPago.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                        Case "TR"
                            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("id", i.identidad)
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                Me.dgvProcesoPago.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
                            End With
                    End Select

                    If i.tipo = "P" Then
                        Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipo", "Pago")
                    ElseIf i.tipo = "C" Then
                        Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipo", "Cobro")
                    End If

                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("fecha", i.fechaoperacion)
                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("fechapago", i.fechaPago)

                    Me.dgvProcesoPago.Table.AddNewRecord.EndEdit()

                End If

            Next

            Me.dgvProcesoPago.TopLevelGroupOptions.ShowCaption = False



        Else

        End If
        'Dim documentoVentaSA As New CronogramaSA
        'Dim documentoLibro As New List(Of Cronograma)
        'Dim tablaSA As New tablaDetalleSA
        'Dim dt As New DataTable
        'Dim entidadSA As New entidadSA
        'Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        ''Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        'dt.Columns.Add("nombres", GetType(String))
        'dt.Columns.Add("monto", GetType(Decimal))
        'dt.Columns.Add("tipo", GetType(String))
        'dt.Columns.Add("idcronograma", GetType(Integer))
        'dt.Columns.Add("id", GetType(Integer))
        'dt.Columns.Add("tipoProv", GetType(String))
        'dt.Columns.Add("fecha", GetType(Date))
        'dt.Columns.Add("fechapago", GetType(Date))
        'dt.Columns.Add("montome", GetType(Decimal))
        'dt.Columns.Add("tipocambio", GetType(Decimal))
        'dt.Columns.Add("iddocumentopago", GetType(Integer))
        'dt.Columns.Add("glosa", GetType(String))

        'documentoLibro = documentoVentaSA.GetCronograma()

        'If Not IsNothing(documentoLibro) Then


        '    For Each i In documentoLibro

        '        If i.estado = "PN" Then

        '            Me.dgvProcesoCrono.Table.AddNewRecord.SetCurrent()
        '            Me.dgvProcesoCrono.Table.AddNewRecord.BeginEdit()
        '            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
        '            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
        '            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
        '            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
        '            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipocambio", i.tipocambio)
        '            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
        '            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("glosa", i.glosa)

        '            Select Case i.tipoRazon
        '                Case TIPO_ENTIDAD.PROVEEDOR

        '                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With entidadSA.UbicarEntidadPorID(i.identidad).First
        '                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '                Case TIPO_ENTIDAD.CLIENTE
        '                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With entidadSA.UbicarEntidadPorID(i.identidad).First
        '                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '                Case "TR"
        '                    Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
        '                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '            End Select

        '            If i.tipo = "P" Then
        '                Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipo", "Pago")
        '            ElseIf i.tipo = "C" Then
        '                Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("tipo", "Cobro")
        '            End If

        '            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("fecha", i.fechaoperacion)
        '            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("fechapago", i.fechaPago)


        '            Me.dgvProcesoCrono.Table.AddNewRecord.EndEdit()


        '        ElseIf i.estado = "AP" Then

        '            Me.dgvProcesoAprobado.Table.AddNewRecord.SetCurrent()
        '            Me.dgvProcesoAprobado.Table.AddNewRecord.BeginEdit()
        '            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
        '            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
        '            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
        '            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
        '            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipocambio", i.tipocambio)
        '            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
        '            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("glosa", i.glosa)

        '            Select Case i.tipoRazon
        '                Case TIPO_ENTIDAD.PROVEEDOR

        '                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With entidadSA.UbicarEntidadPorID(i.identidad).First
        '                        Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '                Case TIPO_ENTIDAD.CLIENTE
        '                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With entidadSA.UbicarEntidadPorID(i.identidad).First
        '                        Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '                Case "TR"
        '                    Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
        '                        Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '            End Select

        '            If i.tipo = "P" Then
        '                Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipo", "Pago")
        '            ElseIf i.tipo = "C" Then
        '                Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("tipo", "Cobro")
        '            End If

        '            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("fecha", i.fechaoperacion)
        '            Me.dgvProcesoAprobado.Table.CurrentRecord.SetValue("fechapago", i.fechaPago)

        '            Me.dgvProcesoAprobado.Table.AddNewRecord.EndEdit()

        '        ElseIf i.estado = "OB" Then


        '            Me.dgvProcesoObservado.Table.AddNewRecord.SetCurrent()
        '            Me.dgvProcesoObservado.Table.AddNewRecord.BeginEdit()
        '            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
        '            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
        '            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
        '            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
        '            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipocambio", i.tipocambio)
        '            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
        '            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("glosa", i.glosa)
        '            Select Case i.tipoRazon
        '                Case TIPO_ENTIDAD.PROVEEDOR

        '                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With entidadSA.UbicarEntidadPorID(i.identidad).First
        '                        Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '                Case TIPO_ENTIDAD.CLIENTE
        '                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With entidadSA.UbicarEntidadPorID(i.identidad).First
        '                        Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '                Case "TR"
        '                    Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
        '                        Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '            End Select

        '            If i.tipo = "P" Then
        '                Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipo", "Pago")
        '            ElseIf i.tipo = "C" Then
        '                Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("tipo", "Cobro")
        '            End If

        '            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("fecha", i.fechaoperacion)
        '            Me.dgvProcesoObservado.Table.CurrentRecord.SetValue("fechapago", i.fechaPago)

        '            Me.dgvProcesoObservado.Table.AddNewRecord.EndEdit()

        '        ElseIf i.estado = "PG" Then


        '            Me.dgvProcesoPago.Table.AddNewRecord.SetCurrent()
        '            Me.dgvProcesoPago.Table.AddNewRecord.BeginEdit()
        '            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("monto", i.montoAutorizadoMN)
        '            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("idcronograma", i.idCronograma)
        '            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipoProv", i.tipoRazon)
        '            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("montome", i.montoAutorizadoME)
        '            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipocambio", i.tipocambio)
        '            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("iddocumentopago", i.idDocumentoPago)
        '            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("glosa", i.glosa)

        '            Select Case i.tipoRazon
        '                Case TIPO_ENTIDAD.PROVEEDOR

        '                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With entidadSA.UbicarEntidadPorID(i.identidad).First
        '                        Me.dgvProcesoPago.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '                Case TIPO_ENTIDAD.CLIENTE
        '                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With entidadSA.UbicarEntidadPorID(i.identidad).First
        '                        Me.dgvProcesoPago.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '                Case "TR"
        '                    Me.dgvProcesoPago.Table.CurrentRecord.SetValue("id", i.identidad)
        '                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
        '                        Me.dgvProcesoPago.Table.CurrentRecord.SetValue("nombres", .nombreCompleto)
        '                    End With
        '            End Select

        '            If i.tipo = "P" Then
        '                Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipo", "Pago")
        '            ElseIf i.tipo = "C" Then
        '                Me.dgvProcesoPago.Table.CurrentRecord.SetValue("tipo", "Cobro")
        '            End If

        '            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("fecha", i.fechaoperacion)
        '            Me.dgvProcesoPago.Table.CurrentRecord.SetValue("fechapago", i.fechaPago)

        '            Me.dgvProcesoPago.Table.AddNewRecord.EndEdit()

        '        End If

        '    Next

        '    Me.dgvProcesoPago.TopLevelGroupOptions.ShowCaption = False



        'Else

        'End If
    End Sub


    Dim colorx As New GridMetroColors()
    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub
#End Region

    Private Sub frmCronogramaKanban_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCronogramaKanban_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

        Me.Cursor = Cursors.WaitCursor

        'Dim idcrono As Integer

        


        If Not IsNothing(dgvProcesoCrono.Table.CurrentRecord) Then

            Dim r As Record = dgvProcesoCrono.Table.CurrentRecord
            Dim nom = r.GetValue("nombres")
            If Not IsNothing(nom) Then

                Dim f As New frmEstadoCronograma

                'If txtTipoProgramacion.Text = "PAGOS" Then
                If dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "P" Then
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 1, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 2, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 3, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 4, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 5, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 6, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 7, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 8, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 9, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 10, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 11, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 12, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "PA" Then
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 1, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 2, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 3, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 4, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 5, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 6, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 7, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 8, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 9, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 10, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 11, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 12, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                End If
               

                f.txtcabezera.Text = "APROBAR OBLIGACIONES"
                f.txttipo.Text = "AP"
                If dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda") = "1" Then
                    f.TextBox1.Text = "NACIONAL"
                ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda") = "2" Then
                    f.TextBox1.Text = "EXTRANJERO"
                End If

                f.txtProveedor.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("nombres")
                f.txtProveedor.Tag = dgvProcesoCrono.Table.CurrentRecord.GetValue("id")
                f.txttipoProveedor.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            
                Select Case cboMes.Text

                    Case "ENERO"
                        ProgramacionXMes(1, MonedaTrabajo)
                    Case "FEBRERO"
                        ProgramacionXMes(2, MonedaTrabajo)
                    Case "MARZO"
                        ProgramacionXMes(3, MonedaTrabajo)
                    Case "ABRIL"
                        ProgramacionXMes(4, MonedaTrabajo)
                    Case "MAYO"
                        ProgramacionXMes(5, MonedaTrabajo)
                    Case "JUNIO"
                        ProgramacionXMes(6, MonedaTrabajo)
                    Case "JULIO"
                        ProgramacionXMes(7, MonedaTrabajo)
                    Case "AGOSTO"
                        ProgramacionXMes(8, MonedaTrabajo)
                    Case "SETIEMBRE"
                        ProgramacionXMes(9, MonedaTrabajo)
                    Case "OCTUBRE"
                        ProgramacionXMes(10, MonedaTrabajo)
                    Case "NOVIEMBRE"
                        ProgramacionXMes(11, MonedaTrabajo)
                    Case "DICIEMBRE"
                        ProgramacionXMes(12, MonedaTrabajo)
                End Select



            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

            Me.Cursor = Cursors.Arrow



       

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim idcrono As Integer

        

        If Not IsNothing(dgvProcesoCrono.Table.CurrentRecord) Then
            Dim r As Record = dgvProcesoCrono.Table.CurrentRecord
            Dim nom = r.GetValue("nombres")
            If Not IsNothing(nom) Then

                Dim f As New frmEstadoCronograma


                'If txtTipoProgramacion.Text = "PAGOS" Then

                'f.UbicarDocumentoDetalle(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"), dgvProcesoCrono.Table.CurrentRecord.GetValue("fechapago"))
                If dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "P" Then
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 1, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 2, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 3, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 4, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 5, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 6, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 7, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 8, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 9, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 10, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 11, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 12, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "PA" Then
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 1, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 2, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 3, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 4, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 5, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 6, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 7, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 8, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 9, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 10, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 11, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"), "PN", 12, dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"), dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                End If
              


                If dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda") = "1" Then
                    f.TextBox1.Text = "NACIONAL"

                ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("moneda") = "2" Then
                    f.TextBox1.Text = "EXTRANJERO"
                End If
                f.txtcabezera.Text = "OBSERVAR OBLIGACIONES"
                f.txttipo.Text = "OB"
                f.txtProveedor.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("nombres")
                f.txtProveedor.Tag = dgvProcesoCrono.Table.CurrentRecord.GetValue("id")
                f.txttipoProveedor.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()


                Select Case cboMes.Text

                    Case "ENERO"
                        ProgramacionXMes(1, MonedaTrabajo)
                    Case "FEBRERO"
                        ProgramacionXMes(2, MonedaTrabajo)
                    Case "MARZO"
                        ProgramacionXMes(3, MonedaTrabajo)
                    Case "ABRIL"
                        ProgramacionXMes(4, MonedaTrabajo)
                    Case "MAYO"
                        ProgramacionXMes(5, MonedaTrabajo)
                    Case "JUNIO"
                        ProgramacionXMes(6, MonedaTrabajo)
                    Case "JULIO"
                        ProgramacionXMes(7, MonedaTrabajo)
                    Case "AGOSTO"
                        ProgramacionXMes(8, MonedaTrabajo)
                    Case "SETIEMBRE"
                        ProgramacionXMes(9, MonedaTrabajo)
                    Case "OCTUBRE"
                        ProgramacionXMes(10, MonedaTrabajo)
                    Case "NOVIEMBRE"
                        ProgramacionXMes(11, MonedaTrabajo)
                    Case "DICIEMBRE"
                        ProgramacionXMes(12, MonedaTrabajo)
                End Select


            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If


        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor


        

        Select Case cboMes.Text

            Case "ENERO"
                ProgramacionXMes(1, MonedaTrabajo)
            Case "FEBRERO"
                ProgramacionXMes(2, MonedaTrabajo)
            Case "MARZO"
                ProgramacionXMes(3, MonedaTrabajo)
            Case "ABRIL"
                ProgramacionXMes(4, MonedaTrabajo)
            Case "MAYO"
                ProgramacionXMes(5, MonedaTrabajo)
            Case "JUNIO"
                ProgramacionXMes(6, MonedaTrabajo)
            Case "JULIO"
                ProgramacionXMes(7, MonedaTrabajo)
            Case "AGOSTO"
                ProgramacionXMes(8, MonedaTrabajo)
            Case "SETIEMBRE"
                ProgramacionXMes(9, MonedaTrabajo)
            Case "OCTUBRE"
                ProgramacionXMes(10, MonedaTrabajo)
            Case "NOVIEMBRE"
                ProgramacionXMes(11, MonedaTrabajo)
            Case "DICIEMBRE"
                ProgramacionXMes(12, MonedaTrabajo)
        End Select

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim idcrono As Integer

       


        If Not IsNothing(dgvProcesoAprobado.Table.CurrentRecord) Then
            Dim r As Record = dgvProcesoAprobado.Table.CurrentRecord
            Dim nom = r.GetValue("nombres")
            If Not IsNothing(nom) Then

                Dim f As New frmEstadoCronograma

                'If txtTipoProgramacion.Text = "PAGOS" Then
                ' f.UbicarDocumentoDetalle(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", dgvProcesoAprobado.Table.CurrentRecord.GetValue("fecha"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("fechapago"))
                If dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo") = "P" Then
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 1, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 2, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 3, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 4, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 5, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 6, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 7, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 8, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 9, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 10, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 11, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 12, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                ElseIf dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo") = "PA" Then


                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 1, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 2, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 3, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 4, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 5, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 6, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 7, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 8, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 9, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 10, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 11, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 12, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                End If
                'ElseIf txtTipoProgramacion.Text = "COBROS" Then
                '    f.UbicarDocumentoDetalleCobros(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", dgvProcesoAprobado.Table.CurrentRecord.GetValue("fecha"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                'ElseIf txtTipoProgramacion.Text = "PAGOS ASIENTO" Then
                '    f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "PN", 12, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"))

                'End If


                If dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda") = "1" Then
                    f.TextBox1.Text = "NACIONAL"

                ElseIf dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda") = "2" Then
                    f.TextBox1.Text = "EXTRANJERO"
                End If
                f.txtcabezera.Text = "OBSERVAR OBLIGACIONES"
                f.txttipo.Text = "OB"
                f.txtProveedor.Text = dgvProcesoAprobado.Table.CurrentRecord.GetValue("nombres")
                f.txtProveedor.Tag = dgvProcesoAprobado.Table.CurrentRecord.GetValue("id")
                f.txttipoProveedor.Text = dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                Select Case cboMes.Text

                    Case "ENERO"
                        ProgramacionXMes(1, MonedaTrabajo)
                    Case "FEBRERO"
                        ProgramacionXMes(2, MonedaTrabajo)
                    Case "MARZO"
                        ProgramacionXMes(3, MonedaTrabajo)
                    Case "ABRIL"
                        ProgramacionXMes(4, MonedaTrabajo)
                    Case "MAYO"
                        ProgramacionXMes(5, MonedaTrabajo)
                    Case "JUNIO"
                        ProgramacionXMes(6, MonedaTrabajo)
                    Case "JULIO"
                        ProgramacionXMes(7, MonedaTrabajo)
                    Case "AGOSTO"
                        ProgramacionXMes(8, MonedaTrabajo)
                    Case "SETIEMBRE"
                        ProgramacionXMes(9, MonedaTrabajo)
                    Case "OCTUBRE"
                        ProgramacionXMes(10, MonedaTrabajo)
                    Case "NOVIEMBRE"
                        ProgramacionXMes(11, MonedaTrabajo)
                    Case "DICIEMBRE"
                        ProgramacionXMes(12, MonedaTrabajo)
                End Select

            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If
        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim idcrono As Integer

        

        If dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo") = "P" Then

            Dim r As Record = dgvProcesoAprobado.Table.CurrentRecord
            Dim nom = r.GetValue("nombres")
            If Not IsNothing(nom) Then
                If nom.ToString.Trim.Length > 0 Then


                    Dim f As New frmEstadoCronograma
                    'f.UbicarDocumentoDetalle(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", dgvProcesoAprobado.Table.CurrentRecord.GetValue("fecha"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("fechapago"))
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 1, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 2, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 3, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 4, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 5, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 6, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 7, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 8, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 9, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 10, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 11, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 12, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                    End Select



                    If dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda") = "1" Then
                        f.TextBox1.Text = "NACIONAL"

                    ElseIf dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda") = "2" Then
                        f.TextBox1.Text = "EXTRANJERO"
                    End If
                    f.txtcabezera.Text = "DESEMBOLSAR OBLIGACIONES"
                    If dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo") = "P" Then
                        f.txttipo.Text = "PG"
                    ElseIf dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo") = "PA" Then
                        f.txttipo.Text = "PGA"
                    End If

                    f.txtProveedor.Text = dgvProcesoAprobado.Table.CurrentRecord.GetValue("nombres")
                    f.txtProveedor.Tag = dgvProcesoAprobado.Table.CurrentRecord.GetValue("id")
                    f.txttipoProveedor.Text = dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()


                   Select Case cboMes.Text

                        Case "ENERO"
                            ProgramacionXMes(1, MonedaTrabajo)
                        Case "FEBRERO"
                            ProgramacionXMes(2, MonedaTrabajo)
                        Case "MARZO"
                            ProgramacionXMes(3, MonedaTrabajo)
                        Case "ABRIL"
                            ProgramacionXMes(4, MonedaTrabajo)
                        Case "MAYO"
                            ProgramacionXMes(5, MonedaTrabajo)
                        Case "JUNIO"
                            ProgramacionXMes(6, MonedaTrabajo)
                        Case "JULIO"
                            ProgramacionXMes(7, MonedaTrabajo)
                        Case "AGOSTO"
                            ProgramacionXMes(8, MonedaTrabajo)
                        Case "SETIEMBRE"
                            ProgramacionXMes(9, MonedaTrabajo)
                        Case "OCTUBRE"
                            ProgramacionXMes(10, MonedaTrabajo)
                        Case "NOVIEMBRE"
                            ProgramacionXMes(11, MonedaTrabajo)
                        Case "DICIEMBRE"
                            ProgramacionXMes(12, MonedaTrabajo)
                    End Select

                Else
                    ' MessageBox.Show("Seleccione un Item a Editar")
                    MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If
            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        ElseIf dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo") = "PA" Then

            Dim r As Record = dgvProcesoAprobado.Table.CurrentRecord
            Dim nom = r.GetValue("nombres")
            If Not IsNothing(nom) Then
                If nom.ToString.Trim.Length > 0 Then

                    'If Not IsNothing(dgvProcesoAprobado.Table.CurrentRecord) Then
                    If nom.ToString.Trim.Length > 0 Then

                        Dim f As New frmEstadoCronograma

                        Select Case cboMes.Text

                            Case "ENERO"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 1, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "FEBRERO"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 2, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "MARZO"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 3, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "ABRIL"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 4, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "MAYO"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 5, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "JUNIO"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 6, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "JULIO"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 7, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "AGOSTO"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 8, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "SETIEMBRE"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 9, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "OCTUBRE"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 10, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "NOVIEMBRE"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 11, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                            Case "DICIEMBRE"
                                f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 12, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        End Select

                        If dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda") = "1" Then
                            f.TextBox1.Text = "NACIONAL"

                        ElseIf dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda") = "2" Then
                            f.TextBox1.Text = "EXTRANJERO"
                        End If
                        f.txtcabezera.Text = "DESEMBOLSAR OBLIGACIONES"
                        f.txttipo.Text = "PGA"

                        f.txtProveedor.Text = dgvProcesoAprobado.Table.CurrentRecord.GetValue("nombres")
                        f.txtProveedor.Tag = dgvProcesoAprobado.Table.CurrentRecord.GetValue("id")
                        f.txttipoProveedor.Text = dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv")
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()

                        Select Case cboMes.Text

                            Case "ENERO"
                                ProgramacionXMes(1, MonedaTrabajo)
                            Case "FEBRERO"
                                ProgramacionXMes(2, MonedaTrabajo)
                            Case "MARZO"
                                ProgramacionXMes(3, MonedaTrabajo)
                            Case "ABRIL"
                                ProgramacionXMes(4, MonedaTrabajo)
                            Case "MAYO"
                                ProgramacionXMes(5, MonedaTrabajo)
                            Case "JUNIO"
                                ProgramacionXMes(6, MonedaTrabajo)
                            Case "JULIO"
                                ProgramacionXMes(7, MonedaTrabajo)
                            Case "AGOSTO"
                                ProgramacionXMes(8, MonedaTrabajo)
                            Case "SETIEMBRE"
                                ProgramacionXMes(9, MonedaTrabajo)
                            Case "OCTUBRE"
                                ProgramacionXMes(10, MonedaTrabajo)
                            Case "NOVIEMBRE"
                                ProgramacionXMes(11, MonedaTrabajo)
                            Case "DICIEMBRE"
                                ProgramacionXMes(12, MonedaTrabajo)
                        End Select

                    Else
                        ' MessageBox.Show("Seleccione un Item a Editar")
                        MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    ' MessageBox.Show("Seleccione un Item a Editar")
                    MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            End If

                Me.Cursor = Cursors.Arrow
    End Sub

    

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim idcrono As Integer

        

        If Not IsNothing(dgvProcesoAprobado.Table.CurrentRecord) Then

            Dim r As Record = dgvProcesoAprobado.Table.CurrentRecord
            Dim nom = r.GetValue("nombres")
            If Not IsNothing(nom) Then


                Dim f As New frmEstadoCronograma
                If dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo") = "P" Then
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 1, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 2, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 3, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 4, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 5, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 6, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 7, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 8, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 9, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 10, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 11, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 12, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                ElseIf dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo") = "PA" Then


                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 1, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 2, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 3, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 4, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 5, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 6, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 7, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 8, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 9, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 10, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 11, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoAprobado.Table.CurrentRecord.GetValue("id"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv"), "AP", 12, dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                End If

                If dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda") = "1" Then
                    f.TextBox1.Text = "NACIONAL"

                ElseIf dgvProcesoAprobado.Table.CurrentRecord.GetValue("moneda") = "2" Then
                    f.TextBox1.Text = "EXTRANJERO"
                End If
                f.txtcabezera.Text = "OBLIGACIONES PENDIENTES"
                f.txttipo.Text = "PN"
                f.txtProveedor.Text = dgvProcesoAprobado.Table.CurrentRecord.GetValue("nombres")
                f.txtProveedor.Tag = dgvProcesoAprobado.Table.CurrentRecord.GetValue("id")
                f.txttipoProveedor.Text = dgvProcesoAprobado.Table.CurrentRecord.GetValue("tipoProv")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                Select Case cboMes.Text

                    Case "ENERO"
                        ProgramacionXMes(1, MonedaTrabajo)
                    Case "FEBRERO"
                        ProgramacionXMes(2, MonedaTrabajo)
                    Case "MARZO"
                        ProgramacionXMes(3, MonedaTrabajo)
                    Case "ABRIL"
                        ProgramacionXMes(4, MonedaTrabajo)
                    Case "MAYO"
                        ProgramacionXMes(5, MonedaTrabajo)
                    Case "JUNIO"
                        ProgramacionXMes(6, MonedaTrabajo)
                    Case "JULIO"
                        ProgramacionXMes(7, MonedaTrabajo)
                    Case "AGOSTO"
                        ProgramacionXMes(8, MonedaTrabajo)
                    Case "SETIEMBRE"
                        ProgramacionXMes(9, MonedaTrabajo)
                    Case "OCTUBRE"
                        ProgramacionXMes(10, MonedaTrabajo)
                    Case "NOVIEMBRE"
                        ProgramacionXMes(11, MonedaTrabajo)
                    Case "DICIEMBRE"
                        ProgramacionXMes(12, MonedaTrabajo)
                End Select

            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


       

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim idcrono As Integer

      


            If Not IsNothing(dgvProcesoObservado.Table.CurrentRecord) Then
            Dim r As Record = dgvProcesoObservado.Table.CurrentRecord
            Dim nom = r.GetValue("nombres")
            If Not IsNothing(nom) Then

                Dim f As New frmEstadoCronograma

                If dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo") = "P" Then
                    ' f.UbicarDocumentoDetalle(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", dgvProcesoObservado.Table.CurrentRecord.GetValue("fecha"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"), dgvProcesoObservado.Table.CurrentRecord.GetValue("fechapago"))
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 1, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 2, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 3, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 4, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 5, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 6, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 7, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 8, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 9, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 10, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 11, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 12, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                    End Select

                ElseIf dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo") = "PA" Then
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 1, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 2, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 3, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 4, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 5, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 6, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 7, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 8, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 9, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 10, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 11, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 12, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                End If


                If dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda") = "1" Then
                    f.TextBox1.Text = "NACIONAL"

                ElseIf dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda") = "2" Then
                    f.TextBox1.Text = "EXTRANJERO"
                End If

                f.txtcabezera.Text = "OBLIGACIONES PENDIENTES"
                f.txttipo.Text = "PN"
                f.txtProveedor.Text = dgvProcesoObservado.Table.CurrentRecord.GetValue("nombres")
                f.txtProveedor.Tag = dgvProcesoObservado.Table.CurrentRecord.GetValue("id")
                f.txttipoProveedor.Text = dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()


                Select Case cboMes.Text

                    Case "ENERO"
                        ProgramacionXMes(1, MonedaTrabajo)
                    Case "FEBRERO"
                        ProgramacionXMes(2, MonedaTrabajo)
                    Case "MARZO"
                        ProgramacionXMes(3, MonedaTrabajo)
                    Case "ABRIL"
                        ProgramacionXMes(4, MonedaTrabajo)
                    Case "MAYO"
                        ProgramacionXMes(5, MonedaTrabajo)
                    Case "JUNIO"
                        ProgramacionXMes(6, MonedaTrabajo)
                    Case "JULIO"
                        ProgramacionXMes(7, MonedaTrabajo)
                    Case "AGOSTO"
                        ProgramacionXMes(8, MonedaTrabajo)
                    Case "SETIEMBRE"
                        ProgramacionXMes(9, MonedaTrabajo)
                    Case "OCTUBRE"
                        ProgramacionXMes(10, MonedaTrabajo)
                    Case "NOVIEMBRE"
                        ProgramacionXMes(11, MonedaTrabajo)
                    Case "DICIEMBRE"
                        ProgramacionXMes(12, MonedaTrabajo)
                End Select


            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim idcrono As Integer

        

        If Not IsNothing(dgvProcesoObservado.Table.CurrentRecord) Then
            Dim r As Record = dgvProcesoObservado.Table.CurrentRecord
            Dim nom = r.GetValue("nombres")
            If Not IsNothing(nom) Then


                Dim f As New frmEstadoCronograma

                If dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo") = "P" Then
                    ' f.UbicarDocumentoDetalle(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", dgvProcesoObservado.Table.CurrentRecord.GetValue("fecha"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"), dgvProcesoObservado.Table.CurrentRecord.GetValue("fechapago"))
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 1, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 2, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 3, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 4, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 5, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 6, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 7, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 8, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 9, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 10, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 11, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleMes(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 12, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                    End Select

                ElseIf dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo") = "PA" Then
                    Select Case cboMes.Text

                        Case "ENERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 1, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "FEBRERO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 2, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MARZO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 3, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "ABRIL"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 4, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "MAYO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 5, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JUNIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 6, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "JULIO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 7, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "AGOSTO"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 8, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "SETIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 9, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "OCTUBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 10, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "NOVIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 11, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                        Case "DICIEMBRE"
                            f.UbicarDocumentoDetalleAsiento(dgvProcesoObservado.Table.CurrentRecord.GetValue("id"), dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv"), "OB", 12, dgvProcesoObservado.Table.CurrentRecord.GetValue("tipo"), dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda"))
                    End Select
                End If
                If dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda") = "1" Then
                    f.TextBox1.Text = "NACIONAL"

                ElseIf dgvProcesoObservado.Table.CurrentRecord.GetValue("moneda") = "2" Then
                    f.TextBox1.Text = "EXTRANJERO"
                End If
                f.txtcabezera.Text = "APROBAR OBLIGACIONES"
                f.txttipo.Text = "AP"
                f.txtProveedor.Text = dgvProcesoObservado.Table.CurrentRecord.GetValue("nombres")
                f.txtProveedor.Tag = dgvProcesoObservado.Table.CurrentRecord.GetValue("id")
                f.txttipoProveedor.Text = dgvProcesoObservado.Table.CurrentRecord.GetValue("tipoProv")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()




              Select Case cboMes.Text

                    Case "ENERO"
                        ProgramacionXMes(1, MonedaTrabajo)
                    Case "FEBRERO"
                        ProgramacionXMes(2, MonedaTrabajo)
                    Case "MARZO"
                        ProgramacionXMes(3, MonedaTrabajo)
                    Case "ABRIL"
                        ProgramacionXMes(4, MonedaTrabajo)
                    Case "MAYO"
                        ProgramacionXMes(5, MonedaTrabajo)
                    Case "JUNIO"
                        ProgramacionXMes(6, MonedaTrabajo)
                    Case "JULIO"
                        ProgramacionXMes(7, MonedaTrabajo)
                    Case "AGOSTO"
                        ProgramacionXMes(8, MonedaTrabajo)
                    Case "SETIEMBRE"
                        ProgramacionXMes(9, MonedaTrabajo)
                    Case "OCTUBRE"
                        ProgramacionXMes(10, MonedaTrabajo)
                    Case "NOVIEMBRE"
                        ProgramacionXMes(11, MonedaTrabajo)
                    Case "DICIEMBRE"
                        ProgramacionXMes(12, MonedaTrabajo)
                End Select

            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If
        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

       
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv12_Click(sender As Object, e As EventArgs) Handles ButtonAdv12.Click
        Me.Cursor = Cursors.WaitCursor

        ' Dim idcrono As Integer
        ' Dim idpago As Integer

        Dim r As Record = dgvProcesoPago.Table.CurrentRecord
        Dim nom = r.GetValue("nombres")
        If Not IsNothing(nom) Then


            If Not IsNothing(dgvProcesoPago.Table.CurrentRecord) Then


                Dim f As New frmPagosDesembolsado
                'f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", dgvProcesoPago.Table.CurrentRecord.GetValue("fecha"))

                Select Case cboMes.Text

                    Case "ENERO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 1)
                    Case "FEBRERO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 2)
                    Case "MARZO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 3)
                    Case "ABRIL"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 4)
                    Case "MAYO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 5)
                    Case "JUNIO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 6)
                    Case "JULIO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 7)
                    Case "AGOSTO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 8)
                    Case "SETIEMBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 9)
                    Case "OCTUBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 10)
                    Case "NOVIEMBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 11)
                    Case "DICIEMBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 12)
                End Select




                f.txtcabezera.Text = "ELIMINAR PAGOS"
                f.txttipo.Text = "PN"
                f.txtProveedor.Text = dgvProcesoPago.Table.CurrentRecord.GetValue("nombres")
                f.txtProveedor.Tag = dgvProcesoPago.Table.CurrentRecord.GetValue("id")
                f.txttipoProveedor.Text = dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                Select Case cboMes.Text

                    Case "ENERO"
                        ProgramacionXMes(1, MonedaTrabajo)
                    Case "FEBRERO"
                        ProgramacionXMes(2, MonedaTrabajo)
                    Case "MARZO"
                        ProgramacionXMes(3, MonedaTrabajo)
                    Case "ABRIL"
                        ProgramacionXMes(4, MonedaTrabajo)
                    Case "MAYO"
                        ProgramacionXMes(5, MonedaTrabajo)
                    Case "JUNIO"
                        ProgramacionXMes(6, MonedaTrabajo)
                    Case "JULIO"
                        ProgramacionXMes(7, MonedaTrabajo)
                    Case "AGOSTO"
                        ProgramacionXMes(8, MonedaTrabajo)
                    Case "SETIEMBRE"
                        ProgramacionXMes(9, MonedaTrabajo)
                    Case "OCTUBRE"
                        ProgramacionXMes(10, MonedaTrabajo)
                    Case "NOVIEMBRE"
                        ProgramacionXMes(11, MonedaTrabajo)
                    Case "DICIEMBRE"
                        ProgramacionXMes(12, MonedaTrabajo)
                End Select

              


            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv11_Click(sender As Object, e As EventArgs) Handles ButtonAdv11.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim idcrono As Integer
        'Dim idpago As Integer

        Dim r As Record = dgvProcesoPago.Table.CurrentRecord
        Dim nom = r.GetValue("nombres")
        If Not IsNothing(nom) Then

            If Not IsNothing(dgvProcesoPago.Table.CurrentRecord) Then


                Dim f As New frmPagosDesembolsado
                ' f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", dgvProcesoPago.Table.CurrentRecord.GetValue("fecha"))

                Select Case cboMes.Text

                    Case "ENERO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 1)
                    Case "FEBRERO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 2)
                    Case "MARZO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 3)
                    Case "ABRIL"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 4)
                    Case "MAYO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 5)
                    Case "JUNIO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 6)
                    Case "JULIO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 7)
                    Case "AGOSTO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 8)
                    Case "SETIEMBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 9)
                    Case "OCTUBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 10)
                    Case "NOVIEMBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 11)
                    Case "DICIEMBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 12)
                End Select


                f.txtcabezera.Text = "ELIMINAR PAGOS"
                f.txttipo.Text = "AP"
                f.txtProveedor.Text = dgvProcesoPago.Table.CurrentRecord.GetValue("nombres")
                f.txtProveedor.Tag = dgvProcesoPago.Table.CurrentRecord.GetValue("id")
                f.txttipoProveedor.Text = dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                Select Case cboMes.Text

                    Case "ENERO"
                        ProgramacionXMes(1, MonedaTrabajo)
                    Case "FEBRERO"
                        ProgramacionXMes(2, MonedaTrabajo)
                    Case "MARZO"
                        ProgramacionXMes(3, MonedaTrabajo)
                    Case "ABRIL"
                        ProgramacionXMes(4, MonedaTrabajo)
                    Case "MAYO"
                        ProgramacionXMes(5, MonedaTrabajo)
                    Case "JUNIO"
                        ProgramacionXMes(6, MonedaTrabajo)
                    Case "JULIO"
                        ProgramacionXMes(7, MonedaTrabajo)
                    Case "AGOSTO"
                        ProgramacionXMes(8, MonedaTrabajo)
                    Case "SETIEMBRE"
                        ProgramacionXMes(9, MonedaTrabajo)
                    Case "OCTUBRE"
                        ProgramacionXMes(10, MonedaTrabajo)
                    Case "NOVIEMBRE"
                        ProgramacionXMes(11, MonedaTrabajo)
                    Case "DICIEMBRE"
                        ProgramacionXMes(12, MonedaTrabajo)
                End Select



                

            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim idcrono As Integer
        ' Dim idpago As Integer

        Dim r As Record = dgvProcesoPago.Table.CurrentRecord
        Dim nom = r.GetValue("nombres")
        If Not IsNothing(nom) Then



            If Not IsNothing(dgvProcesoPago.Table.CurrentRecord) Then



                Dim f As New frmPagosDesembolsado
                'f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", dgvProcesoPago.Table.CurrentRecord.GetValue("fecha"))

                Select Case cboMes.Text

                    Case "ENERO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 1)
                    Case "FEBRERO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 2)
                    Case "MARZO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 3)
                    Case "ABRIL"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 4)
                    Case "MAYO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 5)
                    Case "JUNIO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 6)
                    Case "JULIO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 7)
                    Case "AGOSTO"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 8)
                    Case "SETIEMBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 9)
                    Case "OCTUBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 10)
                    Case "NOVIEMBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 11)
                    Case "DICIEMBRE"
                        f.UbicarDocumentosPagosProgramados(dgvProcesoPago.Table.CurrentRecord.GetValue("id"), dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv"), "PG", 12)
                End Select


                f.txtcabezera.Text = "ELIMINAR PAGOS"
                f.txttipo.Text = "OB"
                f.txtProveedor.Text = dgvProcesoPago.Table.CurrentRecord.GetValue("nombres")
                f.txtProveedor.Tag = dgvProcesoPago.Table.CurrentRecord.GetValue("id")
                f.txttipoProveedor.Text = dgvProcesoPago.Table.CurrentRecord.GetValue("tipoProv")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()


                Select Case cboMes.Text

                    Case "ENERO"
                        ProgramacionXMes(1, MonedaTrabajo)
                    Case "FEBRERO"
                        ProgramacionXMes(2, MonedaTrabajo)
                    Case "MARZO"
                        ProgramacionXMes(3, MonedaTrabajo)
                    Case "ABRIL"
                        ProgramacionXMes(4, MonedaTrabajo)
                    Case "MAYO"
                        ProgramacionXMes(5, MonedaTrabajo)
                    Case "JUNIO"
                        ProgramacionXMes(6, MonedaTrabajo)
                    Case "JULIO"
                        ProgramacionXMes(7, MonedaTrabajo)
                    Case "AGOSTO"
                        ProgramacionXMes(8, MonedaTrabajo)
                    Case "SETIEMBRE"
                        ProgramacionXMes(9, MonedaTrabajo)
                    Case "OCTUBRE"
                        ProgramacionXMes(10, MonedaTrabajo)
                    Case "NOVIEMBRE"
                        ProgramacionXMes(11, MonedaTrabajo)
                    Case "DICIEMBRE"
                        ProgramacionXMes(12, MonedaTrabajo)
                End Select

               

            Else
                ' MessageBox.Show("Seleccione un Item a Editar")
                MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        If cboMoneda.Text = "NACIONAL" Then
            MonedaTrabajo = "1"
        ElseIf cboMoneda.Text = "EXTRANJERO" Then
            MonedaTrabajo = "2"
        End If
    End Sub
End Class