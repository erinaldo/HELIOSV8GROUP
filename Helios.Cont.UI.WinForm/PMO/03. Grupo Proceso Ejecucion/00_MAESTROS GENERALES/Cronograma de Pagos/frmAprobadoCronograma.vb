Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmAprobadoCronograma
    Inherits frmMaster

    Dim docCompra As documentocompra


    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    'Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property lblTipoCambioOriginal() As Decimal
    Public Property ListaMontos As List(Of documentocompra)
    Public Property ListaMontosAsiento As List(Of documentoLibroDiarioDetalle)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvPagosVarios)
        GridCFG2(GridGroupingControl1)
        GetTableGridConcepto2()
        'GridCFG(dgvDistribucionME)
        'ObtenerTablaGenerales()
        'txtFechaTrans.Value = Date.Now
        'Me.WindowState = FormWindowState.Maximized
        'txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
        txtPeriodo.Value = PeriodoGeneral
        'txttipocambiop.Value = TmpTipoCambioTransaccionVenta
    End Sub



#Region "Manipulación data"

    Public Sub UpdateGastoListaAsiento(iddocpago As Integer)
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()
        Dim cronograma As New Cronograma
        Dim lista As New List(Of Cronograma)
        Try
            For Each i In ListaMontosAsiento


                cronograma = New Cronograma
                cronograma.idCronograma = i.idEstablecimiento
                cronograma.estado = "PG"
                cronograma.idDocumentoPago = iddocpago

                lista.Add(cronograma)

            Next

            LibroSA.ActualizarEstadoLista(lista)

            Dispose()
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub UpdateGastoLista(iddocpago As Integer)
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()
        Dim cronograma As New Cronograma
        Dim lista As New List(Of Cronograma)
        Try
            For Each i In ListaMontos


                cronograma = New Cronograma
                cronograma.idCronograma = i.idCentroCosto
                cronograma.estado = "PG"
                cronograma.idDocumentoPago = iddocpago

                lista.Add(cronograma)

            Next

            LibroSA.ActualizarEstadoLista(lista)

            Dispose()
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Sub PagoDocumentosme()

        Dim dt As New DataTable
        dt.Columns.Add("iddocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        'Dim dt As New DataTable

        For Each j In ListaMontos

            Dim nudSaldo As Decimal = j.importeUS * TmpTipoCambioTransaccionVenta
            Dim nudSaldoME As Decimal = j.importeUS
            'Dim nudSaldoME As Decimal = j.importeTotal / TmpTipoCambio
            Dim cSaldo As Decimal = 0
            Dim cSaldoex As Decimal = 0
            Dim cSaldoME As Decimal = 0
            Dim cSaldoexME As Decimal = 0

            For Each i As Record In dgvPagosVarios.Table.Records

                If i.GetValue("idDocumento") = j.idDocumento Then

                    If nudSaldo > 0 Then
                        cSaldo = Math.Round((CDec(i.GetValue("saldo"))), 2) - nudSaldo
                        If cSaldo >= 0 Then
                            i.SetValue("pago", nudSaldo)
                            i.SetValue("saldop", cSaldo)
                            nudSaldo = 0
                        Else
                            i.SetValue("pago", CDec(i.GetValue("saldo")))
                            i.SetValue("saldop", CDec(0.0))
                            nudSaldo = cSaldo * -1
                        End If

                    Else
                        i.SetValue("saldop", CDec(i.GetValue("saldo")))
                    End If



                    If nudSaldoME > 0 Then
                        cSaldoME = Math.Round((CDec(i.GetValue("saldome"))), 2) - nudSaldoME
                        If cSaldoME >= 0 Then


                            i.SetValue("pagome", nudSaldoME)
                            i.SetValue("saldopme", cSaldoME)
                            nudSaldoME = 0

                        Else
                            i.SetValue("pagome", CDec(i.GetValue("saldome")))
                            i.SetValue("saldopme", CDec(0.0))
                            nudSaldoME = cSaldoME * -1

                        End If

                    Else

                        i.SetValue("saldopme", CDec(i.GetValue("saldome")))

                    End If

                    If i.GetValue("pago") > 0 Then
                        dt.Rows.Add(i.GetValue("idDocumento"), i.GetValue("idsecuencia"), i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome"))
                    End If


                End If
            Next

        Next


        GridGroupingControl1.DataSource = dt


    End Sub


    Sub PagoDocumentosAsientome()


        Dim dt As New DataTable
        dt.Columns.Add("iddocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        'Dim dt As New DataTable

        For Each j In ListaMontosAsiento

            Dim nudSaldo As Decimal = j.importeME * TmpTipoCambioTransaccionVenta
            Dim nudSaldoME As Decimal = j.importeME
            'Dim nudSaldoME As Decimal = j.importeTotal / TmpTipoCambio
            Dim cSaldo As Decimal = 0
            Dim cSaldoex As Decimal = 0
            Dim cSaldoME As Decimal = 0
            Dim cSaldoexME As Decimal = 0

            For Each i As Record In dgvPagosVarios.Table.Records

                If i.GetValue("idDocumento") = j.idDocumento Then
                    If i.GetValue("idsecuencia") = j.secuencia Then
                        If nudSaldo > 0 Then
                            cSaldo = Math.Round((CDec(i.GetValue("saldo"))), 2) - nudSaldo
                            If cSaldo >= 0 Then
                                i.SetValue("pago", nudSaldo)
                                i.SetValue("saldop", cSaldo)
                                nudSaldo = 0
                            Else
                                i.SetValue("pago", CDec(i.GetValue("saldo")))
                                i.SetValue("saldop", CDec(0.0))
                                nudSaldo = cSaldo * -1
                            End If

                        Else
                            i.SetValue("saldop", CDec(i.GetValue("saldo")))
                        End If



                        If nudSaldoME > 0 Then
                            cSaldoME = Math.Round((CDec(i.GetValue("saldome"))), 2) - nudSaldoME
                            If cSaldoME >= 0 Then


                                i.SetValue("pagome", nudSaldoME)
                                i.SetValue("saldopme", cSaldoME)
                                nudSaldoME = 0

                            Else
                                i.SetValue("pagome", CDec(i.GetValue("saldome")))
                                i.SetValue("saldopme", CDec(0.0))
                                nudSaldoME = cSaldoME * -1

                            End If

                        Else

                            i.SetValue("saldopme", CDec(i.GetValue("saldome")))

                        End If

                        If i.GetValue("pago") > 0 Then
                            dt.Rows.Add(i.GetValue("idDocumento"), i.GetValue("idsecuencia"), i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome"))
                        End If

                    End If
                End If
            Next

        Next


        GridGroupingControl1.DataSource = dt


    End Sub

    Sub PagoDocumentosAsiento()



        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("iditem", GetType(Integer))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))

        'Dim dt As New DataTable

        For Each j In ListaMontosAsiento

            Dim nudSaldo As Decimal = j.importeMN
            'Dim nudSaldoME As Decimal = j.importeUS
            Dim nudSaldoME As Decimal = j.importeMN / TmpTipoCambioTransaccionVenta
            Dim cSaldo As Decimal = 0
            Dim cSaldoex As Decimal = 0
            Dim cSaldoME As Decimal = 0
            Dim cSaldoexME As Decimal = 0
            Dim PagoActual As Decimal = j.importeMN
            Dim PagoActualME As Decimal = j.importeMN / TmpTipoCambioTransaccionVenta

            For Each i As Record In dgvPagosVarios.Table.Records

                If i.GetValue("idDocumento") = j.idDocumento Then

                    If i.GetValue("idsecuencia") = j.secuencia Then
                        If nudSaldo > 0 Then
                            nudSaldo += Math.Round((CDec(i.GetValue("pago"))), 2)
                            cSaldo = Math.Round((CDec(i.GetValue("saldo"))), 2) - nudSaldo

                            If cSaldo >= 0 Then
                                i.SetValue("pago", nudSaldo)
                                i.SetValue("saldop", cSaldo)

                                i.SetValue("pagome", nudSaldo / TmpTipoCambioTransaccionVenta)
                                i.SetValue("saldopme", cSaldo / TmpTipoCambioTransaccionVenta)

                                nudSaldo = 0
                            Else
                                i.SetValue("pago", CDec(i.GetValue("saldo")))
                                i.SetValue("saldop", CDec(0.0))

                                i.SetValue("pagome", CDec(i.GetValue("saldo")) / TmpTipoCambioTransaccionVenta)
                                i.SetValue("saldopme", CDec(0.0))

                                nudSaldo = cSaldo * -1
                            End If

                        Else
                            i.SetValue("saldop", CDec(i.GetValue("saldo")))
                            i.SetValue("saldopme", CDec(i.GetValue("saldome")))
                        End If



                        'If nudSaldoME > 0 Then
                        '    cSaldoME = Math.Round((CDec(i.GetValue("saldome"))), 2) - nudSaldoME
                        '    If cSaldoME >= 0 Then


                        '        i.SetValue("pagome", nudSaldoME)
                        '        i.SetValue("saldopme", cSaldoME)
                        '        nudSaldoME = 0

                        '    Else
                        '        i.SetValue("pagome", CDec(i.GetValue("saldome")))
                        '        i.SetValue("saldopme", CDec(0.0))
                        '        nudSaldoME = cSaldoME * -1

                        '    End If

                        'Else

                        '    i.SetValue("saldopme", CDec(i.GetValue("saldome")))

                        'End If

                        If i.GetValue("pago") > 0 Then
                            dt.Rows.Add(i.GetValue("idDocumento"), i.GetValue("idsecuencia"), i.GetValue("detalle"), PagoActual, PagoActualME, CInt(0), i.GetValue("tipocambio"), i.GetValue("cuenta"))
                        End If

                    End If
                End If
            Next

        Next


        GridGroupingControl1.DataSource = dt


    End Sub



    Sub PagoDocumentos()

        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("iditem", GetType(Integer))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        'Dim dt As New DataTable

        For Each j In ListaMontos

            Dim nudSaldo As Decimal = j.importeTotal
            'Dim nudSaldoME As Decimal = j.importeUS
            Dim nudSaldoME As Decimal = j.importeTotal / TmpTipoCambioTransaccionVenta
            Dim cSaldo As Decimal = 0
            Dim cSaldoex As Decimal = 0
            Dim cSaldoME As Decimal = 0
            Dim cSaldoexME As Decimal = 0
            'Dim PagoActual As Decimal = j.importeTotal
            'Dim PagoActualME As Decimal = j.importeTotal / TmpTipoCambioTransaccionVenta
            Dim PagoActual As Decimal = CDec(0.0)
            Dim PagoActualME As Decimal = CDec(0.0)
            



            For Each i As Record In dgvPagosVarios.Table.Records

                If i.GetValue("idDocumento") = j.idDocumento Then



                    If nudSaldo > 0 Then
                        nudSaldo += Math.Round((CDec(i.GetValue("pago"))), 2)
                        cSaldo = Math.Round((CDec(i.GetValue("saldo"))), 2) - nudSaldo
                        If cSaldo >= 0 Then
                            i.SetValue("pago", nudSaldo)
                            i.SetValue("saldop", cSaldo)

                            i.SetValue("pagome", nudSaldo / TmpTipoCambioTransaccionVenta)
                            i.SetValue("saldopme", cSaldo / TmpTipoCambioTransaccionVenta)

                            PagoActual = nudSaldo
                            PagoActualME = nudSaldo / TmpTipoCambioTransaccionVenta


                            nudSaldo = 0
                        Else
                            i.SetValue("pago", CDec(i.GetValue("saldo")))
                            i.SetValue("saldop", CDec(0.0))

                            i.SetValue("pagome", CDec(i.GetValue("saldo")) / TmpTipoCambioTransaccionVenta)
                            i.SetValue("saldopme", CDec(0.0))

                            PagoActual = CDec(i.GetValue("saldo"))
                            PagoActualME = CDec(i.GetValue("saldo")) / TmpTipoCambioTransaccionVenta


                            nudSaldo = cSaldo * -1
                        End If

                    Else
                        i.SetValue("saldop", CDec(i.GetValue("saldo")))
                        i.SetValue("saldopme", CDec(i.GetValue("saldome")))
                    End If



                    'If nudSaldoME > 0 Then
                    '    cSaldoME = Math.Round((CDec(i.GetValue("saldome"))), 2) - nudSaldoME
                    '    If cSaldoME >= 0 Then


                    '        i.SetValue("pagome", nudSaldoME)
                    '        i.SetValue("saldopme", cSaldoME)
                    '        nudSaldoME = 0

                    '    Else
                    '        i.SetValue("pagome", CDec(i.GetValue("saldome")))
                    '        i.SetValue("saldopme", CDec(0.0))
                    '        nudSaldoME = cSaldoME * -1

                    '    End If

                    'Else

                    '    i.SetValue("saldopme", CDec(i.GetValue("saldome")))

                    'End If

                    If i.GetValue("pago") > 0 Then
                        dt.Rows.Add(i.GetValue("idDocumento"), i.GetValue("idsecuencia"), i.GetValue("detalle"), PagoActual, PagoActualME, i.GetValue("iditem"), i.GetValue("tipocambio"), i.GetValue("cuenta"))
                    End If


                End If
            Next

        Next


        GridGroupingControl1.DataSource = dt


    End Sub



    Sub listaAsientosPorPagar(lista As List(Of documentoLibroDiarioDetalle))

        Dim objLista As New DocumentoCajaDetalleSA
        Dim objLista2 As New documentoAnticipoDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim tablaSA As New tablaDetalleSA
        Dim nombredoc As String

        Dim deudatotal As Decimal = CDec(0.0)
        Dim deudatotalme As Decimal = CDec(0.0)


        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        ' Dim lista As New List(Of documentoCajaDetalle)

        dgvPagosVarios.TableDescriptor.Columns.Clear()
        dgvPagosVarios.TableDescriptor.Columns.Add("idDocumento")
        dgvPagosVarios.TableDescriptor.Columns(0).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(0).HeaderText = "idDocumento"
        dgvPagosVarios.TableDescriptor.Columns(0).MappingName = "idDocumento"

        dgvPagosVarios.TableDescriptor.Columns.Add("idsecuencia")
        dgvPagosVarios.TableDescriptor.Columns(1).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(1).HeaderText = "idsecuencia"
        dgvPagosVarios.TableDescriptor.Columns(1).MappingName = "idsecuencia"

        dgvPagosVarios.TableDescriptor.Columns.Add("comprobante")
        dgvPagosVarios.TableDescriptor.Columns(2).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(2).HeaderText = "comprobante"
        dgvPagosVarios.TableDescriptor.Columns(2).MappingName = "comprobante"

        dgvPagosVarios.TableDescriptor.Columns.Add("detalle")
        dgvPagosVarios.TableDescriptor.Columns(3).Width = 250
        dgvPagosVarios.TableDescriptor.Columns(3).HeaderText = "detalle"
        dgvPagosVarios.TableDescriptor.Columns(3).MappingName = "detalle"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldo")
        dgvPagosVarios.TableDescriptor.Columns(4).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(4).HeaderText = "Deuda"
        dgvPagosVarios.TableDescriptor.Columns(4).MappingName = "saldo"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldome")
        dgvPagosVarios.TableDescriptor.Columns(5).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(5).HeaderText = "saldome"
        dgvPagosVarios.TableDescriptor.Columns(5).MappingName = "saldome"


        dgvPagosVarios.TableDescriptor.Columns.Add("pago")
        dgvPagosVarios.TableDescriptor.Columns(6).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(6).HeaderText = "Monto a Pagar"
        dgvPagosVarios.TableDescriptor.Columns(6).MappingName = "pago"


        ''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("pagome")
        dgvPagosVarios.TableDescriptor.Columns(7).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(7).HeaderText = "Monto a Pagar ME"
        dgvPagosVarios.TableDescriptor.Columns(7).MappingName = "pagome"


        dgvPagosVarios.TableDescriptor.Columns.Add("saldop")
        dgvPagosVarios.TableDescriptor.Columns(8).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(8).HeaderText = "saldop"
        dgvPagosVarios.TableDescriptor.Columns(8).MappingName = "saldop"

        '''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("saldopme")
        dgvPagosVarios.TableDescriptor.Columns(9).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(9).HeaderText = "saldopme"
        dgvPagosVarios.TableDescriptor.Columns(9).MappingName = "saldopme"


        dgvPagosVarios.TableDescriptor.Columns.Add("tipocambio")
        dgvPagosVarios.TableDescriptor.Columns(10).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(10).HeaderText = "T.C"
        dgvPagosVarios.TableDescriptor.Columns(10).MappingName = "tipocambio"

        dgvPagosVarios.TableDescriptor.Columns.Add("cuenta")
        dgvPagosVarios.TableDescriptor.Columns(11).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(11).HeaderText = "cuenta"
        dgvPagosVarios.TableDescriptor.Columns(11).MappingName = "cuenta"


        'dgvPagosVarios.TableDescriptor.Columns.Add("iditem")
        'dgvPagosVarios.TableDescriptor.Columns(11).Width = 0
        'dgvPagosVarios.TableDescriptor.Columns(11).HeaderText = "iditem"
        'dgvPagosVarios.TableDescriptor.Columns(11).MappingName = "iditem"




        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("comprobante", GetType(String))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("saldop", GetType(Decimal))
        dt.Columns.Add("saldopme", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        'dt.Columns.Add("iditem", GetType(Integer))


        dgvPagosVarios.TableDescriptor.Columns("idDocumento").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("idsecuencia").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("comprobante").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("detalle").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldo").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldome").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("pago").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("pagome").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldop").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldopme").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("tipocambio").ReadOnly = True
        'dgvPagosVarios.TableDescriptor.Columns("iditem").ReadOnly = True

        dgvPagosVarios.TableDescriptor.Columns("saldo").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("saldome").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("pago").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("pagome").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("saldop").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        dgvPagosVarios.TableDescriptor.Columns("saldopme").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        'lista = objLista.ObtenerCuentasPorPagarTodDetails(idprov)

        If txtmonedaprog.Text = "NACIONAL" Then
            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarAsientoDetails(lista)

                'Dim dr As DataRow = dt.NewRow()

                If Not i.EstadoCobro = "PG" Then
                    'detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                    'martin
                    'Dim consulta = (From c In listaPago _
                    '              Where c.secuencia = i.secuencia).FirstOrDefault

                    'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn - consulta.MontoPagadoSoles
                    'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme - consulta.MontoPagadoUSD
                    'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                    'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme
                    cTotalmn = CDec(i.MontoDeudaSoles) - CDec(i.MontoPagadoSoles)
                    cTotalme = CDec(i.MontoDeudaUSD) - CDec(i.MontoPagadoUSD)


                    If cTotalmn > 0 Or cTotalme > 0 Then

                        nombredoc = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion

                        dt.Rows.Add(i.idDocumento, i.secuencia, (nombredoc & "/" & "-" & i.numeroDoc), i.DetalleItem, cTotalmn, cTotalme, CDec(0.0), CDec(0.0), CDec(0.0), CDec(0.0), i.tipoCambioTransacc, i.cuenta)

                        deudatotal += cTotalmn
                        deudatotalme += cTotalme

                        'Me.dgvPagosVarios.Table.AddNewRecord.SetCurrent()
                        'Me.dgvPagosVarios.Table.AddNewRecord.BeginEdit()
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("idsecuencia", i.secuencia)
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("detalle", i.DetalleItem)
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldo", cTotalmn)
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldome", cTotalme)
                        'Me.dgvPagosVarios.Table.AddNewRecord.EndEdit()

                    End If
                End If
            Next


        ElseIf txtmonedaprog.Text = "EXTRANJERO" Then

            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarAsientoDetails(lista)
                If Not i.EstadoCobro = "PG" Then
                    'detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                    'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                    'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.montoUsdTransacc) + detalle.ImporteDBME - detalle.ImporteAJme
                    cTotalme = CDec(i.MontoDeudaUSD) - CDec(i.montoUsdTransacc)
                    cTotalmn = CDec(cTotalme * TmpTipoCambio).ToString("N2")
                    If cTotalmn < 0 Then
                        cTotalmn = 0
                    End If
                    If cTotalme < 0 Then
                        cTotalme = 0
                    End If
                    saldomn += cTotalmn
                    saldome += cTotalme
                    If cTotalmn > 0 Or cTotalme > 0 Then


                        nombredoc = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion

                        dt.Rows.Add(i.idDocumento, i.secuencia, (nombredoc & "/" & "-" & i.numeroDoc), i.DetalleItem, cTotalmn, cTotalme, CDec(0.0), CDec(0.0), CDec(0.0), CDec(0.0), i.tipoCambioTransacc, i.cuenta)

                        deudatotal += cTotalmn
                        deudatotalme += cTotalme

                        '.dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                        '                           Nothing, cTotalmn, cTotalme,
                        '                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                    End If
                End If
            Next

        End If
        dgvPagosVarios.DataSource = dt
        dgvPagosVarios.ShowGroupDropArea = False
        dgvPagosVarios.TableDescriptor.GroupedColumns.Clear()
        dgvPagosVarios.TableDescriptor.GroupedColumns.Add("comprobante")

        txtdeudatotal.Value = deudatotal
        txtdeudatotalme.Value = deudatotalme





        If txtmonedaprog.Text = "NACIONAL" Then
            dgvPagosVarios.TableDescriptor.Columns("saldo").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("saldome").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("pago").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("pagome").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("saldop").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("saldopme").Width = 0

            PagoDocumentosAsiento()

        ElseIf txtmonedaprog.Text = "EXTRANJERO" Then
            dgvPagosVarios.TableDescriptor.Columns("saldo").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("saldome").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("pago").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("pagome").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("saldop").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("saldopme").Width = 70
            PagoDocumentosAsientome()
        End If

    End Sub



    Sub listaDocumentosPorPagar(lista As List(Of documentocompra))

        Dim objLista As New DocumentoCajaDetalleSA
        Dim objLista2 As New documentoAnticipoDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim tablaSA As New tablaDetalleSA
        Dim nombredoc As String

        Dim deudatotal As Decimal = CDec(0.0)
        Dim deudatotalme As Decimal = CDec(0.0)


        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        ' Dim lista As New List(Of documentoCajaDetalle)

        dgvPagosVarios.TableDescriptor.Columns.Clear()
        dgvPagosVarios.TableDescriptor.Columns.Add("idDocumento")
        dgvPagosVarios.TableDescriptor.Columns(0).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(0).HeaderText = "idDocumento"
        dgvPagosVarios.TableDescriptor.Columns(0).MappingName = "idDocumento"

        dgvPagosVarios.TableDescriptor.Columns.Add("idsecuencia")
        dgvPagosVarios.TableDescriptor.Columns(1).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(1).HeaderText = "idsecuencia"
        dgvPagosVarios.TableDescriptor.Columns(1).MappingName = "idsecuencia"

        dgvPagosVarios.TableDescriptor.Columns.Add("comprobante")
        dgvPagosVarios.TableDescriptor.Columns(2).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(2).HeaderText = "comprobante"
        dgvPagosVarios.TableDescriptor.Columns(2).MappingName = "comprobante"

        dgvPagosVarios.TableDescriptor.Columns.Add("detalle")
        dgvPagosVarios.TableDescriptor.Columns(3).Width = 250
        dgvPagosVarios.TableDescriptor.Columns(3).HeaderText = "detalle"
        dgvPagosVarios.TableDescriptor.Columns(3).MappingName = "detalle"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldo")
        dgvPagosVarios.TableDescriptor.Columns(4).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(4).HeaderText = "Deuda"
        dgvPagosVarios.TableDescriptor.Columns(4).MappingName = "saldo"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldome")
        dgvPagosVarios.TableDescriptor.Columns(5).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(5).HeaderText = "saldome"
        dgvPagosVarios.TableDescriptor.Columns(5).MappingName = "saldome"


        dgvPagosVarios.TableDescriptor.Columns.Add("pago")
        dgvPagosVarios.TableDescriptor.Columns(6).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(6).HeaderText = "Monto a Pagar"
        dgvPagosVarios.TableDescriptor.Columns(6).MappingName = "pago"


        ''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("pagome")
        dgvPagosVarios.TableDescriptor.Columns(7).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(7).HeaderText = "Monto a Pagar ME"
        dgvPagosVarios.TableDescriptor.Columns(7).MappingName = "pagome"


        dgvPagosVarios.TableDescriptor.Columns.Add("saldop")
        dgvPagosVarios.TableDescriptor.Columns(8).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(8).HeaderText = "saldop"
        dgvPagosVarios.TableDescriptor.Columns(8).MappingName = "saldop"

        '''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("saldopme")
        dgvPagosVarios.TableDescriptor.Columns(9).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(9).HeaderText = "saldopme"
        dgvPagosVarios.TableDescriptor.Columns(9).MappingName = "saldopme"


        dgvPagosVarios.TableDescriptor.Columns.Add("tipocambio")
        dgvPagosVarios.TableDescriptor.Columns(10).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(10).HeaderText = "T.C"
        dgvPagosVarios.TableDescriptor.Columns(10).MappingName = "tipocambio"


        dgvPagosVarios.TableDescriptor.Columns.Add("iditem")
        dgvPagosVarios.TableDescriptor.Columns(11).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(11).HeaderText = "iditem"
        dgvPagosVarios.TableDescriptor.Columns(11).MappingName = "iditem"




        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("comprobante", GetType(String))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("saldop", GetType(Decimal))
        dt.Columns.Add("saldopme", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("iditem", GetType(Integer))


        dgvPagosVarios.TableDescriptor.Columns("idDocumento").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("idsecuencia").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("comprobante").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("detalle").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldo").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldome").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("pago").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("pagome").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldop").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldopme").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("tipocambio").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("iditem").ReadOnly = True

        dgvPagosVarios.TableDescriptor.Columns("saldo").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("saldome").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("pago").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("pagome").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("saldop").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        dgvPagosVarios.TableDescriptor.Columns("saldopme").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        'lista = objLista.ObtenerCuentasPorPagarTodDetails(idprov)


        If txtmonedaprog.Text = "NACIONAL" Then
            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarDocumentoDetails(lista)

                'Dim dr As DataRow = dt.NewRow()

                If Not i.EstadoCobro = "PG" Then
                    detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                    'martin
                    'Dim consulta = (From c In listaPago _
                    '              Where c.secuencia = i.secuencia).FirstOrDefault

                    'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn - consulta.MontoPagadoSoles
                    'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme - consulta.MontoPagadoUSD
                    cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                    cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme



                    If cTotalmn > 0 Or cTotalme > 0 Then

                        nombredoc = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion

                        dt.Rows.Add(i.idDocumento, i.secuencia, (nombredoc & "/" & i.serie & "-" & i.numeroDoc), i.DetalleItem, cTotalmn, cTotalme, CDec(0.0), CDec(0.0), CDec(0.0), CDec(0.0), i.tipoCambioTransacc, i.idItem)

                        deudatotal += cTotalmn
                        deudatotalme += cTotalme

                        'Me.dgvPagosVarios.Table.AddNewRecord.SetCurrent()
                        'Me.dgvPagosVarios.Table.AddNewRecord.BeginEdit()
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("idsecuencia", i.secuencia)
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("detalle", i.DetalleItem)
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldo", cTotalmn)
                        'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldome", cTotalme)
                        'Me.dgvPagosVarios.Table.AddNewRecord.EndEdit()

                    End If
                End If
            Next


        ElseIf txtmonedaprog.Text = "EXTRANJERO" Then

            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarDocumentoDetailsME(lista)
                If Not i.EstadoCobro = "PG" Then
                    detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                    'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                    cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.montoUsdTransacc) + detalle.ImporteDBME - detalle.ImporteAJme
                    cTotalmn = CDec(cTotalme * TmpTipoCambio).ToString("N2")
                    If cTotalmn < 0 Then
                        cTotalmn = 0
                    End If
                    If cTotalme < 0 Then
                        cTotalme = 0
                    End If
                    saldomn += cTotalmn
                    saldome += cTotalme
                    If cTotalmn > 0 Or cTotalme > 0 Then


                        nombredoc = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion

                        dt.Rows.Add(i.idDocumento, i.secuencia, (nombredoc & "/" & i.serie & "-" & i.numeroDoc), i.DetalleItem, cTotalmn, cTotalme, CDec(0.0), CDec(0.0), CDec(0.0), CDec(0.0), i.tipoCambioTransacc, i.idItem)

                        deudatotal += cTotalmn
                        deudatotalme += cTotalme

                        '.dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                        '                           Nothing, cTotalmn, cTotalme,
                        '                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                    End If
                End If
            Next

        End If
        dgvPagosVarios.DataSource = dt
        dgvPagosVarios.ShowGroupDropArea = False
        dgvPagosVarios.TableDescriptor.GroupedColumns.Clear()
        dgvPagosVarios.TableDescriptor.GroupedColumns.Add("comprobante")

        txtdeudatotal.Value = deudatotal
        txtdeudatotalme.Value = deudatotalme





        If txtmonedaprog.Text = "NACIONAL" Then
            dgvPagosVarios.TableDescriptor.Columns("saldo").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("saldome").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("pago").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("pagome").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("saldop").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("saldopme").Width = 0

            PagoDocumentos()

        ElseIf txtmonedaprog.Text = "EXTRANJERO" Then
            dgvPagosVarios.TableDescriptor.Columns("saldo").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("saldome").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("pago").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("pagome").Width = 70
            dgvPagosVarios.TableDescriptor.Columns("saldop").Width = 0
            dgvPagosVarios.TableDescriptor.Columns("saldopme").Width = 70
            PagoDocumentosme()
        End If

    End Sub



    Public Sub UpdateGasto(idCronograma As Integer, estado As String, iddoc As Integer)
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()


        With nDocumentoLibro

            .idCronograma = idCronograma
            .estado = estado
            .idDocumentoPago = iddoc
            '.montoAutorizadoMN = txtImporteMN.Value
            '.montoAutorizadoME = txtImporteME.Value
            '.fechaoperacion = txtFecha.Value
            '.usuarioActualizacion = "Jiuni"
            '.fechaActualizacion = DateTime.Now

        End With

        LibroSA.ActualizarEstado(nDocumentoLibro)



    End Sub




    Public Function AS_DebeCajaDiferencia(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal, asientoDestino As String) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = asientoDestino,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_HaberCajaDiferencia(cMonto As Decimal, cMontoUS As Decimal, asientoDestino As String, cuenta As String, descripcion As String) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = cuenta,
      .descripcion = descripcion,
      .tipo = asientoDestino,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento

    End Function

    Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = cajaSeleccionada.depositohijo}
        Return nMovimiento
    End Function

    Public Function AS_HaberCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberCliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = cajaSeleccionada.cuenta,
      .descripcion = cajaSeleccionada.depositohijo,
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberAsiento(descrip As String, cuentaAsiento As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = cuentaAsiento,
      .descripcion = descrip,
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function



    Function Glosa() As String
        Dim strGlosa As String = Nothing
        strGlosa = "Por pagos con programacion"
        Return strGlosa
    End Function
#End Region


#Region "Metodos"

    Sub calculototalpagos()
        Dim dt As New DataTable
        dt.Columns.Add("iddocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))

        For Each i As Record In dgvPagosVarios.Table.Records

            If i.GetValue("pago") > 0 Then
                dt.Rows.Add(i.GetValue("idDocumento"), i.GetValue("idsecuencia"), i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome"))
            End If
        Next

        GridGroupingControl1.DataSource = dt
    End Sub

    Function asientoCajaModulo() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'nAsiento.idEntidad = lblIdProveedor
        nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.nombreEntidad = txtProveedor.Text
        'nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.tipoEntidad = txttipoProveedor.Text
        nAsiento.fechaProceso = cajaSeleccionada.fechatransferencia
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
        'correccin asientos
        nAsiento.importeMN = cajaSeleccionada.importe ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = cajaSeleccionada.importeme  ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        'For Each i As DataGridViewRow In dgvDetalleItems.Rows

        'aquiiiiiiiiiiiiiiiiii!()
        For Each i As Record In dgvPagosVarios.Table.Records



            'For Each i As DataGridViewRow In dgvPagosVarios.Rows
            If CDec(i.GetValue("pago")) > 0 Then

                Select Case cajaSeleccionada.moneda
                    Case 1
                        If (cajaSeleccionada.moneda = 1 And txtmonedaprog.Text = "EXTRANJERO") Then
                            nAsiento.movimiento.Add(AS_HaberAsiento(i.GetValue("detalle"), i.GetValue("cuenta"), i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))

                        ElseIf (cajaSeleccionada.moneda = 1 And txtmonedaprog.Text = "NACIONAL") Then
                            nAsiento.movimiento.Add(AS_HaberAsiento(i.GetValue("detalle"), i.GetValue("cuenta"), i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))

                        End If
                    Case 2
                        If (cajaSeleccionada.moneda = 2 And txtmonedaprog.Text = "EXTRANJERO") Then
                            nAsiento.movimiento.Add(AS_HaberAsiento(i.GetValue("detalle"), i.GetValue("cuenta"), i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))
                        ElseIf (cajaSeleccionada.moneda = 2 And txtmonedaprog.Text = "NACIONAL") Then
                            nAsiento.movimiento.Add(AS_HaberAsiento(i.GetValue("detalle"), i.GetValue("cuenta"), i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))
                        End If
                End Select
            End If
        Next

        'Corregir
        'For Each r As Record In dgvDiferencia.Table.Records

        For Each r In listamov



            Select Case cajaSeleccionada.moneda
                Case 1 '    nacional
                    'Select Case tb19.ToggleState
                    'Case ToggleButton2.ToggleButtonState.OFF 'dolares


                    If txtmonedaprog.Text = "EXTRANJERO" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = r.monto
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, "4212", lblNomProveedor))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1)
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, "4212", lblNomProveedor))
                        End If

                    End If

                    'Case ToggleButton2.ToggleButtonState.ON 'soles
                    If txtmonedaprog.Text = "NACIONAL" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = CDec(r.monto)
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1)
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                        End If
                    End If
                    'End Select

                Case 2 ' extranjero
                    'Select Case tb19.ToggleState
                    'Case ToggleButton2.ToggleButtonState.OFF 'dolares
                    If txtmonedaprog.Text = "EXTRANJERO" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = CDec((r.monto)).ToString("N2")
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1).ToString("N2")
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                        End If
                    End If
                    'Case ToggleButton2.ToggleButtonState.ON 'soles
                    If txtmonedaprog.Text = "NACIONAL" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = CDec((r.monto)).ToString("N2")
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1).ToString("N2")
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                        End If
                    End If
                    ' End Select
            End Select

        Next

        Return nAsiento
    End Function


    Function asientoCaja() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'nAsiento.idEntidad = lblIdProveedor
        nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.nombreEntidad = txtProveedor.Text
        'nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.tipoEntidad = txttipoProveedor.Text
        nAsiento.fechaProceso = cajaSeleccionada.fechatransferencia
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
        'correccin asientos
        nAsiento.importeMN = cajaSeleccionada.importe ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = cajaSeleccionada.importeme  ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        'For Each i As DataGridViewRow In dgvDetalleItems.Rows

        'aquiiiiiiiiiiiiiiiiii!()
        For Each i As Record In dgvPagosVarios.Table.Records



            'For Each i As DataGridViewRow In dgvPagosVarios.Rows
            If CDec(i.GetValue("pago")) > 0 Then

                Select Case cajaSeleccionada.moneda
                    Case 1
                        If (cajaSeleccionada.moneda = 1 And txtmonedaprog.Text = "EXTRANJERO") Then
                            nAsiento.movimiento.Add(AS_HaberCliente(i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))
                           
                        ElseIf (cajaSeleccionada.moneda = 1 And txtmonedaprog.Text = "NACIONAL") Then
                            nAsiento.movimiento.Add(AS_HaberCliente(i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))
                        End If
                    Case 2
                        If (cajaSeleccionada.moneda = 2 And txtmonedaprog.Text = "EXTRANJERO") Then
                            nAsiento.movimiento.Add(AS_HaberCliente(i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))
                        ElseIf (cajaSeleccionada.moneda = 2 And txtmonedaprog.Text = "NACIONAL") Then
                            nAsiento.movimiento.Add(AS_HaberCliente(i.GetValue("pago"), i.GetValue("pagome")))
                            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cajaSeleccionada.depositohijo).cuenta, i.GetValue("detalle"), i.GetValue("pago"), i.GetValue("pagome")))
                        End If
                End Select
            End If
        Next

        'Corregir
        'For Each r As Record In dgvDiferencia.Table.Records

        For Each r In listamov



            Select Case cajaSeleccionada.moneda
                Case 1 '    nacional
                    'Select Case tb19.ToggleState
                    'Case ToggleButton2.ToggleButtonState.OFF 'dolares


                    If txtmonedaprog.Text = "EXTRANJERO" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = r.monto
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, "4212", lblNomProveedor))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1)
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, "4212", lblNomProveedor))
                        End If

                    End If

                    'Case ToggleButton2.ToggleButtonState.ON 'soles
                    If txtmonedaprog.Text = "NACIONAL" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = CDec(r.monto)
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1)
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                        End If
                    End If
                    'End Select

                Case 2 ' extranjero
                    'Select Case tb19.ToggleState
                    'Case ToggleButton2.ToggleButtonState.OFF 'dolares
                    If txtmonedaprog.Text = "EXTRANJERO" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = CDec((r.monto)).ToString("N2")
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1).ToString("N2")
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                        End If
                    End If
                    'Case ToggleButton2.ToggleButtonState.ON 'soles
                    If txtmonedaprog.Text = "NACIONAL" Then
                        If (CDec(r.monto > 0)) Then
                            sumaAsientocajaMN = CDec((r.monto)).ToString("N2")
                            'cuentas Maykol de tratamiento de caja
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("776", "Por la utlidad de las diferencias de tipo de cambio", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER))
                        ElseIf (CDec(r.monto < 0)) Then
                            sumaAsientocajaMN = CDec((r.monto) * -1).ToString("N2")
                            nAsiento.movimiento.Add(AS_DebeCajaDiferencia("676", "Por la pérdida por la diferencias de tipo de cambio ", sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.DEBE))
                            nAsiento.movimiento.Add(AS_HaberCajaDiferencia(sumaAsientocajaMN, 0.0, ASIENTO_CONTABLE.UBICACION.HABER, cajaSeleccionada.cuenta, cajaSeleccionada.depositohijo))
                        End If
                    End If
                    ' End Select
            End Select

        Next

        Return nAsiento
    End Function


    Public Sub GrabarPagoAsiento()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim ListadocumentoCajaDetalle2 As New List(Of documentoCajaDetalle)
        Dim ndocumentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim SaldoMonedaExt As Decimal = 0
        Dim MontoMonedaExt As Decimal = 0
        Dim MontoSoles As Decimal = 0
        Dim n As New RecolectarDatos()
        'Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        'datos.Clear()
        Try

            With ndocumento
                '.idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                ' .tipoDoc = cboTipoDoc.SelectedValue
                .tipoDoc = cajaSeleccionada.tipoDoc
                '.fechaProceso = txtFechaTrans.Value
                .fechaProceso = cajaSeleccionada.fechatransferencia
                '.nroDoc = txtNumeroCompr.Text.Trim
                .idOrden = Nothing
                .tipoOperacion = "9907"
                .usuarioActualizacion = usuario.IDUsuario
                '.fechaActualizacion = txtFechaTrans.Value
                .fechaActualizacion = cajaSeleccionada.fechatransferencia
            End With

            With ndocumentoCaja
                .codigoLibro = "1"
                .tipoOperacion = "9907"
                .periodo = PeriodoGeneral
                '.idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                .tipoDocPago = cajaSeleccionada.tipoDoc
                If cajaSeleccionada.tipoDoc = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = cajaSeleccionada.txtNumOper
                    .ctaCorrienteDeposito = cajaSeleccionada.CuentaCorriente
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cajaSeleccionada.bancoEntidad
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "SI"
                ElseIf cajaSeleccionada.tipoDoc = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = cajaSeleccionada.txtNumOper
                    .ctaCorrienteDeposito = Nothing
                    .bancoEntidad = cajaSeleccionada.bancoEntidad
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "SI"
                    '.ctaIntebancaria = txtCtaInterbancaria.Text
                ElseIf cajaSeleccionada.tipoDoc = "007" Then ' cheques
                    '.numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "NO"
                ElseIf cajaSeleccionada.tipoDoc = "111" Then
                    '.numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "NO"
                ElseIf cajaSeleccionada.tipoDoc = "109" Then
                    '.numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .entregado = "NO"
                End If
                .moneda = cajaSeleccionada.moneda
                .entidadFinanciera = cajaSeleccionada.depositohijo
                .tipoCambio = CDec(cajaSeleccionada.tipocambio).ToString("N3")
                .montoSoles = cajaSeleccionada.importe
                .montoUsd = cajaSeleccionada.importeme
                .glosa = "Por Pago Cronograma"
                .usuarioModificacion = cajaSeleccionada.depositohijo
                .fechaModificacion = cajaSeleccionada.fechatransferencia
                '.DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                '.DeudaEvalME = CDec(lblDeudaPendienteme.Text)
                .codigoProveedor = CInt(txtProveedor.Tag)
            End With

            ndocumento.documentoCaja = ndocumentoCaja

            'For Each i As Record In dgvPagosVarios.Table.Records
            For Each i As Record In GridGroupingControl1.Table.Records

                If CDec(i.GetValue("monto")) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = cajaSeleccionada.fechatransferencia
                    'ndocumentoCajaDetalle.idItem = i.GetValue("iditem")
                    ndocumentoCajaDetalle.DetalleItem = i.GetValue("detalle")

                    Select Case cajaSeleccionada.moneda
                        Case 1
                            ndocumentoCajaDetalle.moneda = cajaSeleccionada.moneda
                            ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("monto"))
                            ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("montome"))
                            If cboMonedaProveedor.Text = "NACIONAL" Then
                                ndocumentoCajaDetalle.monedaDoc = "1"
                            ElseIf cboMonedaProveedor.Text = "EXTRANJERA" Then
                                ndocumentoCajaDetalle.monedaDoc = "2"
                            End If
                        Case 2
                          

                            If txtmonedaprog.Text = "EXTRANJERO" Then
                                ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("montome") * txttipocambiop.Value).ToString("N2")
                                ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("montome"))
                                ndocumentoCajaDetalle.moneda = cajaSeleccionada.moneda

                            ElseIf txtmonedaprog.Text = "NACIONAL" Then
                                ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("monto"))
                                ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("montome"))
                                ndocumentoCajaDetalle.moneda = cajaSeleccionada.moneda
                            End If

                            If cboMonedaProveedor.Text = "NACIONAL" Then
                                ndocumentoCajaDetalle.monedaDoc = "1"
                            ElseIf cboMonedaProveedor.Text = "EXTRANJERA" Then
                                ndocumentoCajaDetalle.monedaDoc = "2"
                            End If
                    End Select



                    ndocumentoCajaDetalle.entregado = "SI"
                    ndocumentoCajaDetalle.tipoCambioTransacc = CDec(cajaSeleccionada.tipocambio).ToString("N3")

                    ndocumentoCajaDetalle.documentoAfectado = i.GetValue("idDocumento")
                    ndocumentoCajaDetalle.usuarioModificacion = CStr(cajaSeleccionada.depositohijo)
                    ndocumentoCajaDetalle.fechaModificacion = cajaSeleccionada.fechatransferencia
                    ndocumentoCajaDetalle.idCajaPadre = cajaSeleccionada.depositohijo
                    ndocumentoCajaDetalle.documentoAfectadodetalle = i.GetValue("idsecuencia")
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                    
                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cajaSeleccionada.tipoDoc
                Case "109", "003", "001"
                    'asiento = asientoCaja()
                    asiento = asientoCajaModulo()
                    ListaAsiento.Add(asiento)
                    ndocumento.asiento = ListaAsiento
                Case "007", "111"
                    cajaUsarioBE = Nothing
            End Select

            Dim iddoc As Integer


            iddoc = documentoCajaSA.SaveGroupCajaMEAsiento(ndocumento, cajaUsarioBE, ListadocumentoCajaDetalle2)


            'UpdateGasto(CInt(lblIdCronograma.Text), "PG", iddoc)
            UpdateGastoListaAsiento(iddoc)
            'datos.Add(n)
            Dim datos As List(Of item) = item.Instance()
            datos.Clear()
            Dim c As New item
            c.idItem = iddoc
            ' c.idItem = 1
            datos.Add(c)
            'Dispose()


            lblEstado.Text = "Transacción realizada con éxito!"
            lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Public Sub Grabar()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim ListadocumentoCajaDetalle2 As New List(Of documentoCajaDetalle)
        Dim ndocumentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim SaldoMonedaExt As Decimal = 0
        Dim MontoMonedaExt As Decimal = 0
        Dim MontoSoles As Decimal = 0
        Dim n As New RecolectarDatos()
        'Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        'datos.Clear()
        Try

            With ndocumento
                '.idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                ' .tipoDoc = cboTipoDoc.SelectedValue
                .tipoDoc = cajaSeleccionada.tipoDoc
                '.fechaProceso = txtFechaTrans.Value
                .fechaProceso = cajaSeleccionada.fechatransferencia
                '.nroDoc = txtNumeroCompr.Text.Trim
                .idOrden = Nothing
                .tipoOperacion = "9907"
                .usuarioActualizacion = usuario.IDUsuario
                '.fechaActualizacion = txtFechaTrans.Value
                .fechaActualizacion = cajaSeleccionada.fechatransferencia
            End With

            With ndocumentoCaja
                .codigoLibro = "1"
                .tipoOperacion = "9907"
                .periodo = PeriodoGeneral
                '.idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                .tipoDocPago = cajaSeleccionada.tipoDoc
                If cajaSeleccionada.tipoDoc = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = cajaSeleccionada.txtNumOper
                    .ctaCorrienteDeposito = cajaSeleccionada.CuentaCorriente
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cajaSeleccionada.bancoEntidad
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "SI"
                ElseIf cajaSeleccionada.tipoDoc = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = cajaSeleccionada.txtNumOper
                    .ctaCorrienteDeposito = Nothing
                    .bancoEntidad = cajaSeleccionada.bancoEntidad
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "SI"
                    '.ctaIntebancaria = txtCtaInterbancaria.Text
                ElseIf cajaSeleccionada.tipoDoc = "007" Then ' cheques
                    '.numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "NO"
                ElseIf cajaSeleccionada.tipoDoc = "111" Then
                    '.numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .entregado = "NO"
                ElseIf cajaSeleccionada.tipoDoc = "109" Then
                    '.numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaCobro = cajaSeleccionada.fechatransferencia
                    .fechaProceso = cajaSeleccionada.fechatransferencia
                    .entregado = "NO"
                End If
                .moneda = cajaSeleccionada.moneda
                .entidadFinanciera = cajaSeleccionada.depositohijo
                .tipoCambio = CDec(cajaSeleccionada.tipocambio).ToString("N3")
                .montoSoles = cajaSeleccionada.importe
                .montoUsd = cajaSeleccionada.importeme
                .glosa = "Por Pago Cronograma"
                .usuarioModificacion = cajaSeleccionada.depositohijo
                .fechaModificacion = cajaSeleccionada.fechatransferencia
                '.DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                '.DeudaEvalME = CDec(lblDeudaPendienteme.Text)
                .codigoProveedor = CInt(txtProveedor.Tag)
            End With

            ndocumento.documentoCaja = ndocumentoCaja

            'For Each i As Record In dgvPagosVarios.Table.Records
            For Each i As Record In GridGroupingControl1.Table.Records


                If CDec(i.GetValue("monto")) > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = cajaSeleccionada.fechatransferencia
                    ndocumentoCajaDetalle.idItem = i.GetValue("iditem")
                    ndocumentoCajaDetalle.DetalleItem = i.GetValue("detalle")

                    Select Case cajaSeleccionada.moneda
                        Case 1
                            ndocumentoCajaDetalle.moneda = cajaSeleccionada.moneda
                            ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("monto"))
                            ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("montome"))

                        Case 2

                            If txtmonedaprog.Text = "EXTRANJERO" Then
                                ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("montome") * txttipocambiop.Value).ToString("N2")
                                ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("montome"))
                                ndocumentoCajaDetalle.moneda = cajaSeleccionada.moneda

                            ElseIf txtmonedaprog.Text = "NACIONAL" Then
                                ndocumentoCajaDetalle.montoSoles = CDec(i.GetValue("monto"))
                                ndocumentoCajaDetalle.montoUsd = CDec(i.GetValue("montome"))
                                ndocumentoCajaDetalle.moneda = cajaSeleccionada.moneda
                            End If

                    End Select



                    ndocumentoCajaDetalle.entregado = "SI"
                    ndocumentoCajaDetalle.tipoCambioTransacc = CDec(cajaSeleccionada.tipocambio).ToString("N3")

                    ndocumentoCajaDetalle.documentoAfectado = i.GetValue("idDocumento")
                    ndocumentoCajaDetalle.usuarioModificacion = CStr(cajaSeleccionada.depositohijo)
                    ndocumentoCajaDetalle.fechaModificacion = cajaSeleccionada.fechatransferencia
                    ndocumentoCajaDetalle.idCajaPadre = cajaSeleccionada.depositohijo
                    ndocumentoCajaDetalle.documentoAfectadodetalle = i.GetValue("idsecuencia")
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

                End If
            Next
            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            Select Case cajaSeleccionada.tipoDoc
                Case "109", "003", "001"
                    asiento = asientoCaja()
                    ListaAsiento.Add(asiento)
                    ndocumento.asiento = ListaAsiento
                Case "007", "111"
                    cajaUsarioBE = Nothing
            End Select


            Dim iddoc As Integer


            iddoc = documentoCajaSA.SaveGroupCajaDocsME(ndocumento, cajaUsarioBE, ListadocumentoCajaDetalle2)

            UpdateGastoLista(iddoc)
            'datos.Add(n)
            Dim datos As List(Of item) = item.Instance()
            datos.Clear()
            Dim c As New item
            c.idItem = iddoc
            ' c.idItem = 1
            datos.Add(c)
            'Dispose()


            lblEstado.Text = "Transacción realizada con éxito!"
            lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub





    'Public Sub CargarDiferenciasdeImporte()
    '    Dim dt As New DataTable
    '    Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
    '    Dim ListadocumentoCajaEtalle As New List(Of documentoCajaDetalle)
    '    Dim sumatoriaMN As Decimal
    '    Dim sumatoriaME As Decimal
    '    Dim DifsumatoriaMN As Decimal
    '    Dim DifsumatoriaME As Decimal
    '    Dim diferenciaCaja As Decimal


    '    Dim ListadocumentoCajaEtalle2 As New List(Of documentoCajaDetalle)

    '    dt.Columns.Add("idDocumento", GetType(Integer))
    '    dt.Columns.Add("TC", GetType(Decimal))
    '    dt.Columns.Add("importeMN", GetType(Decimal))
    '    dt.Columns.Add("importeME", GetType(Decimal))
    '    dt.Columns.Add("TCCompra", GetType(Decimal))
    '    dt.Columns.Add("importeCompraMN", GetType(Decimal))
    '    dt.Columns.Add("importeCompraME", GetType(Decimal))
    '    dt.Columns.Add("difMNCajaMN", GetType(Decimal))
    '    dt.Columns.Add("difMNCajaME", GetType(Decimal))

    '    If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
    '        ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)

    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

    '        Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
    '        gridStackedHeaderRowDescriptor1.Name = "Row1"

    '        Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
    '        gridStackedHeaderRowDescriptor1.Name = "Row2"

    '        ' Create an object for GridStackedHeaderDescriptor
    '        Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
    '        Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
    '        Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
    '        Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

    '        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
    '        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
    '        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

    '        gridStackedHeaderDescriptor1.HeaderText = "CAJA Y BANCOS - " & cboDepositoHijo.Text

    '        gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

    '        gridStackedHeaderDescriptor2.HeaderText = "CUENTAS POR PAGAR"
    '        gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

    '        gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
    '        gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

    '        gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CAJA"
    '        gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

    '        gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
    '                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
    '                                                                 New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
    '                                                                       New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})


    '        gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
    '                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
    '                                                                       New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

    '        gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
    '                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})

    '        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
    '        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
    '        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
    '        gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)
    '        Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True

    '        If Not IsNothing(ListadocumentoCajaEtalle) Then

    '            For Each i In ListadocumentoCajaEtalle
    '                Dim dr As DataRow = dt.NewRow()
    '                If (i.montoSoles > 0 And i.montoUsd > 0) Then
    '                    dr(0) = i.idDocumento
    '                    dr(1) = i.diferTipoCambio
    '                    dr(2) = i.montoSoles
    '                    dr(3) = i.montoUsd
    '                    dr(4) = txtTipoCambio.Value
    '                    sumatoriaMN = CDec(i.montoUsd * txtTipoCambio.Value).ToString("N2")
    '                    sumatoriaME = CDec(i.montoUsd)
    '                    dr(5) = sumatoriaMN
    '                    dr(6) = sumatoriaME
    '                    DifsumatoriaMN = CDec((txtTipoCambio.Value - i.diferTipoCambio) * i.montoUsd).ToString("N2")
    '                    DifsumatoriaME = CDec(i.montoUsd - sumatoriaME)
    '                    dr(7) = DifsumatoriaMN
    '                    dr(8) = DifsumatoriaME

    '                    diferenciaCaja += DifsumatoriaMN

    '                    dt.Rows.Add(dr)
    '                End If

    '            Next
    '            dgvDiferencia.DataSource = dt
    '            Me.dgvDiferencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '            'txtImporteCompramn.Value = sumatoriaMN
    '            txtDiferenciaMontos.Value = diferenciaCaja

    '        Else
    '        End If
    '    ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
    '        'ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)

    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

    '        Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
    '        gridStackedHeaderRowDescriptor1.Name = "Row1"

    '        Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
    '        gridStackedHeaderRowDescriptor1.Name = "Row2"

    '        ' Create an object for GridStackedHeaderDescriptor
    '        Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
    '        Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
    '        Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
    '        Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

    '        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
    '        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
    '        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

    '        gridStackedHeaderDescriptor1.HeaderText = "CUENTAS POR PAGAR"
    '        gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

    '        gridStackedHeaderDescriptor2.HeaderText = "FACTURA DE COMPRA"
    '        gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

    '        gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
    '        gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

    '        gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CUENTAS POR PAGAR"
    '        gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

    '        gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
    '                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
    '                                                                 New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
    '                                                                       New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})


    '        gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
    '                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
    '                                                                       New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

    '        gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
    '                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})


    '        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
    '        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
    '        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
    '        gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)

    '        ' Display Stacked Headers 
    '        Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True



    '        If (manipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
    '            Dim tipoCAmbio As Decimal
    '            Dim dr As DataRow = dt.NewRow()

    '            ' tipoCAmbio = CDec(txtImporteCompramn.Value / lblDeudaPendienteme.Text)
    '            tipoCAmbio = txtTipoCambio.Value
    '            dr(0) = 0
    '            dr(1) = txtTipoCambio.Value
    '            dr(2) = txtImporteCompramn.Value
    '            dr(3) = CDec(txtImporteCompramn.Value / (tipoCAmbio)).ToString("N2")
    '            dr(4) = txtTipoCambio.Value
    '            sumatoriaME = CDec(txtImporteCompramn.Value / tipoCAmbio).ToString("N2")
    '            sumatoriaMN = ((sumatoriaME) * txtTipoCambio.Value)


    '            dr(5) = sumatoriaMN
    '            dr(6) = sumatoriaME
    '            DifsumatoriaMN = CDec(sumatoriaMN - txtImporteCompramn.Value).ToString("N2")
    '            DifsumatoriaME = CDec(sumatoriaME - CDec(txtImporteCompramn.Value / tipoCAmbio)).ToString("N2")
    '            dr(7) = DifsumatoriaMN
    '            dr(8) = DifsumatoriaME

    '            dt.Rows.Add(dr)
    '            dgvDiferencia.DataSource = dt

    '            txtDiferenciaMontos.Value = DifsumatoriaMN
    '        Else
    '            Dim dr As DataRow = dt.NewRow()
    '            dr(0) = 0
    '            dr(1) = txtTipoCambio.Value
    '            dr(2) = txtImporteCompramn.Value
    '            dr(3) = CDec(txtImporteCompramn.Value / txtTipoCambio.Value).ToString("N2")
    '            dr(4) = txtTipoCambio.Value
    '            sumatoriaMN = CDec((CDec(txtImporteCompramn.Value / txtTipoCambio.Value) * txtTipoCambio.Value))
    '            sumatoriaME = CDec(txtImporteCompramn.Value / txtTipoCambio.Value).ToString("N2")

    '            dr(5) = sumatoriaMN
    '            dr(6) = sumatoriaME
    '            DifsumatoriaMN = CDec(sumatoriaMN - txtImporteCompramn.Value).ToString("N2")
    '            DifsumatoriaME = CDec(sumatoriaME - CDec(txtImporteCompramn.Value / txtTipoCambio.Value)).ToString("N2")
    '            dr(7) = DifsumatoriaMN
    '            dr(8) = DifsumatoriaME

    '            dt.Rows.Add(dr)
    '            dgvDiferencia.DataSource = dt

    '            txtDiferenciaMontos.Value = DifsumatoriaMN
    '        End If



    '    ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
    '        ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)

    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

    '        Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
    '        gridStackedHeaderRowDescriptor1.Name = "Row1"

    '        Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
    '        gridStackedHeaderRowDescriptor1.Name = "Row2"

    '        ' Create an object for GridStackedHeaderDescriptor
    '        Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
    '        Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
    '        Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
    '        Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

    '        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
    '        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
    '        gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

    '        gridStackedHeaderDescriptor1.HeaderText = "CAJA Y BANCOS"
    '        gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

    '        gridStackedHeaderDescriptor2.HeaderText = "CUENTAS POR PAGAR"
    '        gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

    '        gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
    '        gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

    '        gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CAJA"
    '        gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

    '        gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
    '                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
    '                                                                 New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
    '                                                                       New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})

    '        gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
    '                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
    '                                                                       New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

    '        gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
    '                                                                New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})


    '        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
    '        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
    '        gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
    '        gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
    '        Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)

    '        ' Display Stacked Headers 
    '        Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True

    '        If Not IsNothing(ListadocumentoCajaEtalle) Then

    '            For Each i In ListadocumentoCajaEtalle
    '                Dim dr As DataRow = dt.NewRow()

    '                dr(0) = i.idDocumento
    '                dr(1) = i.diferTipoCambio
    '                dr(2) = i.montoSoles
    '                dr(3) = i.montoUsd
    '                dr(4) = txtTipoCambio.Value
    '                sumatoriaMN = CDec((i.montoUsd * txtTipoCambio.Value)).ToString("N2")
    '                sumatoriaME = i.montoUsd
    '                dr(5) = sumatoriaMN
    '                dr(6) = sumatoriaME

    '                DifsumatoriaMN = CDec((txtTipoCambio.Text - i.diferTipoCambio) * i.montoUsd).ToString("N2")
    '                DifsumatoriaME = CDec(sumatoriaME - i.montoUsd)
    '                dr(7) = DifsumatoriaMN
    '                dr(8) = DifsumatoriaME

    '                diferenciaCaja += DifsumatoriaMN

    '                dt.Rows.Add(dr)

    '            Next
    '            dgvDiferencia.DataSource = dt
    '            Me.dgvDiferencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '            'txtImporteCompramn.Value = sumatoriaMN
    '            txtDiferenciaMontos.Value = diferenciaCaja
    '        Else
    '        End If
    '    End If

    'End Sub


    'Private Sub cargarDatosCuenta(idCaja As Integer)
    '    Dim estadoSA As New EstadosFinancierosSA
    '    Dim estadoBL As New estadosFinancieros
    '    Dim estadoSaldoBL As New estadosFinancieros


    '    If (manipulacionEstado = ENTITY_ACTIONS.UPDATE) Then

    '    Else
    '        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
    '        estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(cboDepositoHijo.SelectedValue, txtFechaTrans.Value)
    '        If (Not IsNothing(estadoBL)) Then
    '            cboMoneda.SelectedValue = estadoBL.codigo
    '            txtCuentaOrigen.Text = estadoBL.cuenta
    '            nudDeudaPendienteme.Value = estadoSaldoBL.importeBalanceME
    '            nudDeudaPendientemn.Value = estadoSaldoBL.importeBalanceMN
    '            'btOperacion.Visible = True
    '            'txtTipoCambio.Value = TmpTipoCambioTransaccionVenta
    '            cboTipoDoc.SelectedValue = "001"
    '            Select Case cboMoneda.SelectedValue
    '                Case 1
    '                    pnImpMEDisp.Location = New Point(170, 21)
    '                    pnImpMNDisp.Location = New Point(9, 21)
    '                    txtImporteComprame.Enabled = True
    '                    'txtImporteCompramn.Enabled = False
    '                    PictureBox5.Visible = False
    '                    pnDiferencia.Visible = False
    '                    'txtImporteCompramn.Value = 0.0
    '                    'txtImporteComprame.Value = 0.0
    '                    'txtDiferenciaMontos.Value = 0

    '                    Select Case tb19.ToggleState
    '                        Case ToggleButton2.ToggleButtonState.OFF 'dolares
    '                            'pnSaldoME.Visible = True
    '                            'pnSaldoMN.Visible = True
    '                            pnNacional.Location = New Point(420, 25)
    '                            pnExtranjero.Location = New Point(49, 25)
    '                            pnTipoCambio.Visible = True
    '                            pnExtranjero.Visible = True
    '                            pnDiferencia.Visible = True
    '                            pnDiferencia.Location = New Point(650, 25)
    '                            pnTipoCambio.Enabled = False
    '                            pnImpMEDisp.Visible = False
    '                            'pnTipoCambioCompra.Visible = True
    '                            pnTipoCambio.Visible = True
    '                            pnDiferencia.Visible = True
    '                            pnExtranjero.Visible = True
    '                            'colMN.Visible = False
    '                            'colSaldoMN.Visible = False
    '                            'colPagoMN.Visible = False
    '                            pnImpMNDisp.Visible = True
    '                            'colME.Visible = True
    '                            'colSaldoME.Visible = True
    '                            'colPagoME.Visible = True
    '                            'PanelDetallePagos.Enabled = True
    '                        Case ToggleButton2.ToggleButtonState.ON 'soles
    '                            'pnSaldoME.Visible = False
    '                            pnNacional.Location = New Point(49, 25)
    '                            pnExtranjero.Location = New Point(420, 25)
    '                            txtImporteCompramn.Enabled = True
    '                            pnTipoCambio.Visible = True
    '                            pnExtranjero.Visible = True
    '                            pnDiferencia.Visible = False
    '                            pnTipoCambio.Enabled = False
    '                            'txtTipoCambio.Value = TmpTipoCambio
    '                            pnImpMEDisp.Visible = False
    '                            'pnTipoCambioCompra.Visible = False
    '                            pnTipoCambio.Visible = False
    '                            pnDiferencia.Visible = False
    '                            pnExtranjero.Visible = False
    '                            ' colME.Visible = False
    '                            'colSaldoME.Visible = False
    '                            'colPagoME.Visible = False
    '                            'PanelDetallePagos.Enabled = True
    '                    End Select

    '                Case 2
    '                    pnImpMEDisp.Location = New Point(9, 21)
    '                    pnImpMNDisp.Location = New Point(170, 21)
    '                    PictureBox5.Visible = True
    '                    pnDiferencia.Visible = True
    '                    'txtImporteCompramn.Value = 0.0
    '                    'txtImporteComprame.Value = 0.0
    '                    txtDiferenciaMontos.Value = 0
    '                    Select Case tb19.ToggleState
    '                        Case ToggleButton2.ToggleButtonState.OFF 'dolares
    '                            'pnSaldoMN.Visible = False
    '                            pnTipoCambio.Visible = True
    '                            pnExtranjero.Visible = True
    '                            pnDiferencia.Visible = True
    '                            pnExtranjero.Enabled = True
    '                            pnNacional.Enabled = False
    '                            pnExtranjero.Location = New Point(49, 25)
    '                            pnNacional.Location = New Point(430, 25)
    '                            pnDiferencia.Location = New Point(650, 25)
    '                            ' txtTipoCambio.Value = TmpTipoCambio
    '                            pnTipoCambio.Enabled = False
    '                            pnImpMNDisp.Visible = False
    '                            'pnTipoCambioCompra.Visible = True
    '                            pnTipoCambio.Visible = True
    '                            pnDiferencia.Visible = True
    '                            pnExtranjero.Visible = True
    '                            'PanelDetallePagos.Enabled = True
    '                            'colMN.Visible = False
    '                            ' colSaldoMN.Visible = False
    '                            ' colPagoMN.Visible = False
    '                            'colME.Visible = True
    '                            'colSaldoME.Visible = True
    '                            'colPagoME.Visible = True
    '                        Case ToggleButton2.ToggleButtonState.ON 'soles
    '                            'pnSaldoME.Visible = True
    '                            pnTipoCambio.Visible = True
    '                            pnExtranjero.Visible = True
    '                            pnDiferencia.Visible = True
    '                            pnNacional.Location = New Point(49, 25)
    '                            pnExtranjero.Location = New Point(430, 25)
    '                            pnDiferencia.Location = New Point(650, 25)
    '                            pnTipoCambio.Enabled = False
    '                            pnNacional.Enabled = True
    '                            pnExtranjero.Enabled = False
    '                            pnImpMEDisp.Visible = True
    '                            'pnTipoCambioCompra.Visible = True
    '                            pnDiferencia.Visible = True
    '                            pnExtranjero.Visible = True
    '                            ' colMN.Visible = True
    '                            'colSaldoMN.Visible = True
    '                            ' colPagoMN.Visible = True
    '                            'colME.Visible = False
    '                            'colSaldoME.Visible = False
    '                            'colPagoME.Visible = False
    '                            txtImporteCompramn.Enabled = True
    '                            ' PanelDetallePagos.Enabled = True
    '                    End Select
    '            End Select
    '        End If
    '    End If
    'End Sub

    'Public Sub CargarCajasTipo(strBusqueda As String)
    '    Dim estadoSA As New EstadosFinancierosSA
    '    Dim taBLASA As New tablaDetalleSA
    '    Dim ListaestadoBL As New List(Of estadosFinancieros)
    '    Dim estadoBL As New estadosFinancieros

    '    Try
    '        Me.cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
    '        Me.cboDepositoHijo.DisplayMember = "descripcion"
    '        Me.cboDepositoHijo.ValueMember = "idestado"
    '        cboDepositoHijo.SelectedValue = -1

    '        cboMoneda.ValueMember = "codigoDetalle"
    '        cboMoneda.DisplayMember = "descripcion"
    '        cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
    '        cboMoneda.SelectedValue = -1

    '    Catch ex As Exception

    '    End Try
    'End Sub


    'Public Sub ListaDocPago(listaCuenta As List(Of String))
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim tabla As New List(Of tabladetalle)

    '    tabla = tablaSA.GetListaTablaDetalle(1, "1")
    '    tabla = (From n In tabla _
    '                 Where listaCuenta.Contains(n.codigoDetalle) _
    '                Select n).ToList
    '    cboTipoDoc.DataSource = tabla
    '    cboTipoDoc.ValueMember = "codigoDetalle"
    '    cboTipoDoc.DisplayMember = "descripcion"
    '    cboTipoDoc.SelectedValue = "001"

    'End Sub


    'Private Sub cargarCtasFinan()
    '    If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
    '        CargarCajasTipo("EF")
    '        Dim lista As New List(Of String)
    '        lista.Add("001")
    '        lista.Add("109")
    '        ListaDocPago(lista)
    '        cboTipoDoc.SelectedValue = "001"
    '    ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
    '        CargarCajasTipo("BC")
    '        Dim lista As New List(Of String)
    '        lista.Add("001")
    '        lista.Add("003")
    '        lista.Add("007")
    '        lista.Add("111")
    '        ListaDocPago(lista)
    '        cboTipoDoc.SelectedValue = "001"
    '    ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
    '        CargarCajasTipo("TC")
    '        Dim lista As New List(Of String)
    '        lista.Add("001")
    '        ListaDocPago(lista)
    '        cboTipoDoc.SelectedValue = "001"
    '    End If
    'End Sub

    'Public Sub ObtenerTablaGenerales()
    '    Dim tablaSA As New tablaDetalleSA

    '    cboEntidades.ValueMember = "codigoDetalle"
    '    cboEntidades.DisplayMember = "descripcion"
    '    cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
    'End Sub


    Sub GetTableGridConcepto2()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("iditem", GetType(Integer))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))

        'dt.Columns.Add("tipoCuenta", GetType(String))
        GridGroupingControl1.DataSource = dt
    End Sub





    '////////////cabezera factura
    Private Function getParentComprobante(RucCliente As Integer, intMoneda As String) As DataTable
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoVenta As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable("ParentTable")
        dt = New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("abonoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("abonoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estadoPago", GetType(String)))



        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        documentoVenta = documentoVentaSA.UbicarCompraPorProveedorXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intMoneda)

        Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoCompra
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.importeTotal
                dr(8) = i.tcDolLoc
                dr(9) = i.importeUS
                dr(10) = i.PagoSumaMN
                dr(11) = i.PagoSumaME
                dr(12) = CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(13) = CDec(i.importeUS - i.PagoSumaME).ToString("N2")

                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select
                dt.Rows.Add(dr)
            Next

            Select Case cboMonedaProveedor.Text
                Case "NACIONAL"
                    dgvPagosVarios.TableDescriptor.Columns("idDocumento").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("fecha").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("tipoVenta").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("tipoDoc").Width = 0

                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 70

                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


            'dgvPagosVarios.DataSource = dt
            'Me.dgvPagosVarios.TableOptions.ListBoxSelectionMode = SelectionMode.One

        Else




        End If

        '///////////////////////
        'Dim dt As New DataTable("ParentTable")
        'Dim servicioSA As New documentoLibroDiarioSA

        'dt = New DataTable("ParentTable")


        'dt.Columns.Add(New DataColumn("iddocumento", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        'dt.Columns.Add(New DataColumn("tipodoc", GetType(String)))
        'dt.Columns.Add(New DataColumn("nrodoc", GetType(String)))
        'dt.Columns.Add(New DataColumn("montomn", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montome", GetType(Decimal)))


        'Dim Str As String = Nothing
        'For Each i As documentoLibroDiario In servicioSA.GetProgramaPago(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        '    Dim dr As DataRow = dt.NewRow()
        '    dr(0) = i.idDocumento
        '    dr(1) = i.fecha
        '    dr(2) = i.tipoDoc
        '    dr(3) = i.nroDoc
        '    dr(4) = i.importeMN
        '    dr(5) = i.importeME
        '    dt.Rows.Add(dr)
        'Next

        'Return dt
        Return dt
    End Function

    '///// hijos cabezera

    Private Function getChildHijos(strMoneda As String, idprov As Integer) As DataTable
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable("ChildTable")
        dt = New DataTable("ChildTable")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("detalle", GetType(String)))
        dt.Columns.Add(New DataColumn("deuda", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("deudame", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idsecuencia", GetType(Integer)))

        Dim objLista As New DocumentoCajaDetalleSA
        Dim objLista2 As New documentoAnticipoDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0
        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        Select Case strMoneda
            Case "1"

                'martin
                'Dim listaPago As List(Of documentoAnticipoDetalle)
                'listaPago = objLista2.ObtenerCuentasPagadasAnticipo(IDDocumentoCompra)

                For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarTodDetails(idprov, strPeriodo)

                    Dim dr As DataRow = dt.NewRow()

                    If Not i.EstadoCobro = "PG" Then
                        detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                        'martin
                        'Dim consulta = (From c In listaPago _
                        '              Where c.secuencia = i.secuencia).FirstOrDefault

                        'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn - consulta.MontoPagadoSoles
                        'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme - consulta.MontoPagadoUSD
                        cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                        cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme


                        'If cTotalmn < 0 Then
                        '    cTotalmn = 0
                        'End If
                        'If cTotalme < 0 Then
                        '    cTotalme = 0
                        'End If
                        'saldomn += cTotalmn
                        'saldome += cTotalme
                        If cTotalmn > 0 Or cTotalme > 0 Then

                            '.dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                            '                          Nothing, cTotalmn, cTotalme,
                            '                          "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)

                            dr(0) = i.idDocumento
                            dr(1) = i.DetalleItem
                            dr(2) = cTotalmn
                            dr(3) = cTotalme
                            dr(4) = i.secuencia
                            dt.Rows.Add(dr)

                        End If
                    End If
                Next



            Case "EXT"


                'For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetailsME(IDDocumentoCompra)
                '    If Not i.EstadoCobro = "PG" Then
                '        detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                '        'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                '        cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme
                '        cTotalmn = CDec(cTotalme * tipoCambio).ToString("N2")
                '        If cTotalmn < 0 Then
                '            cTotalmn = 0
                '        End If
                '        If cTotalme < 0 Then
                '            cTotalme = 0
                '        End If
                '        saldomn += cTotalmn
                '        saldome += cTotalme
                '        If cTotalmn > 0 Or cTotalme > 0 Then



                '            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                '                                       Nothing, cTotalmn, cTotalme,
                '                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                '        End If
                '    End If
                'Next

        End Select

        Return dt

        'End Select
        Me.Cursor = Cursors.Arrow




        ''/////aquiii
        'Dim dt As New DataTable("ChildTable")
        'Dim entidadSA As New entidadSA
        'Dim PersonaSA As New PersonaSA
        'Dim servicioSA As New documentoLibroDiarioSA

        'dt = New DataTable("ChildTable")

        'dt.Columns.Add(New DataColumn("iddocumento", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("tipoidentificacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("ididentificacion", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("Nombres", GetType(String)))
        'dt.Columns.Add(New DataColumn("idsecuencia", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("montomn", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montome", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("estado", GetType(String)))


        'Dim Str As String = Nothing
        'For Each i As documentoLibroDiarioDetalle In servicioSA.ListadoLibroHijos()
        '    Dim dr As DataRow = dt.NewRow()
        '    dr(0) = i.idDocumento


        '    If IsNothing(i.ididentificacion) Then

        '    Else

        '        Select Case i.tipoIdentificacion
        '            Case TIPO_ENTIDAD.PROVEEDOR
        '                dr(1) = i.tipoIdentificacion
        '                dr(2) = i.ididentificacion
        '                With entidadSA.UbicarEntidadPorID(i.ididentificacion).First
        '                    dr(3) = .nombreCompleto
        '                End With
        '            Case TIPO_ENTIDAD.CLIENTE
        '                dr(1) = i.tipoIdentificacion
        '                dr(2) = i.ididentificacion
        '                With entidadSA.UbicarEntidadPorID(i.ididentificacion).First
        '                    dr(3) = .nombreCompleto
        '                End With
        '            Case "TR"
        '                dr(1) = i.tipoIdentificacion
        '                dr(2) = i.ididentificacion
        '                With PersonaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.ididentificacion, "TR")
        '                    dr(3) = .nombreCompleto
        '                End With
        '        End Select
        '    End If


        '    dr(4) = i.secuencia
        '    dr(5) = i.importeMN
        '    dr(6) = i.importeME
        '    dr(7) = i.estadoPago
        '    dt.Rows.Add(dr)
        'Next

        'Return dt
    End Function



    Dim parentTable As New DataTable
    Dim childTable As New DataTable
    Private Sub LoadFacturasDetalle(RucCliente As Integer, intMoneda As String)

        parentTable = New DataTable
        childTable = New DataTable
        Dim dSet As New DataSet()
        parentTable = getParentComprobante(RucCliente, intMoneda)
        childTable = getChildHijos("1", RucCliente)
        dSet.Tables.AddRange(New DataTable() {parentTable, childTable})

        'setup the relations
        If childTable.Rows.Count > 0 Then

        End If

        Dim parentColumn As DataColumn = parentTable.Columns("idDocumento")
        Dim childColumn As DataColumn = childTable.Columns("idDocumento")
        'dSet.Relations.Clear()
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvPagosVarios.DataSource = parentTable
        Me.dgvPagosVarios.Engine.BindToCurrencyManager = False

        'Me.dgvCajasAssig.GridVisualStyles = GridVisualStyles.Metro
        'Me.dgvCajasAssig.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.dgvPagosVarios.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvPagosVarios.TopLevelGroupOptions.ShowCaption = False

        dgvPagosVarios.TableModel.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)

    End Sub





    'Sub GetTableGrid()
    '    Dim dt As New DataTable()

    '    dt.Columns.Add("idDocumento", GetType(Integer))
    '    dt.Columns.Add("idsecuencia", GetType(Integer))
    '    dt.Columns.Add("detalle", GetType(String))
    '    dt.Columns.Add("saldo", GetType(Decimal))
    '    dt.Columns.Add("saldome", GetType(Decimal))





    '    dgvPagosVarios.DataSource = dt

    '    dgvPagosVarios.ShowGroupDropArea = False
    '    dgvPagosVarios.TableDescriptor.GroupedColumns.Clear()
    '    dgvPagosVarios.TableDescriptor.GroupedColumns.Add("idDocumento")

    '    'dgvPrestamoRO.TableDescriptor.Columns("idDocumento").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("idCuota").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("secuencia").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("cuota").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("descripcion").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("montomn").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("montome").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("FechaVct").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("FechaPlazo").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("cuenta").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("cuentaH").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("cuentaDev").ReadOnly = True
    '    'dgvPrestamoRO.TableDescriptor.Columns("cuentaDevH").ReadOnly = True

    'End Sub


    Sub loaddetalleAsientoManual(idprov As Integer, tipop As String, modulo As String)

        Dim objLista As New DocumentoCajaDetalleSA
        Dim objLista2 As New documentoAnticipoDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim tablaSA As New tablaDetalleSA
        Dim nombredoc As String

        Dim deudatotal As Decimal = CDec(0.0)
        Dim deudatotalme As Decimal = CDec(0.0)


        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        ' Dim lista As New List(Of documentoCajaDetalle)

        dgvPagosVarios.TableDescriptor.Columns.Clear()
        dgvPagosVarios.TableDescriptor.Columns.Add("idDocumento")
        dgvPagosVarios.TableDescriptor.Columns(0).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(0).HeaderText = "idDocumento"
        dgvPagosVarios.TableDescriptor.Columns(0).MappingName = "idDocumento"

        dgvPagosVarios.TableDescriptor.Columns.Add("idsecuencia")
        dgvPagosVarios.TableDescriptor.Columns(1).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(1).HeaderText = "idsecuencia"
        dgvPagosVarios.TableDescriptor.Columns(1).MappingName = "idsecuencia"

        dgvPagosVarios.TableDescriptor.Columns.Add("comprobante")
        dgvPagosVarios.TableDescriptor.Columns(2).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(2).HeaderText = "comprobante"
        dgvPagosVarios.TableDescriptor.Columns(2).MappingName = "comprobante"

        dgvPagosVarios.TableDescriptor.Columns.Add("detalle")
        dgvPagosVarios.TableDescriptor.Columns(3).Width = 250
        dgvPagosVarios.TableDescriptor.Columns(3).HeaderText = "detalle"
        dgvPagosVarios.TableDescriptor.Columns(3).MappingName = "detalle"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldo")
        dgvPagosVarios.TableDescriptor.Columns(4).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(4).HeaderText = "Deuda"
        dgvPagosVarios.TableDescriptor.Columns(4).MappingName = "saldo"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldome")
        dgvPagosVarios.TableDescriptor.Columns(5).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(5).HeaderText = "saldome"
        dgvPagosVarios.TableDescriptor.Columns(5).MappingName = "saldome"


        dgvPagosVarios.TableDescriptor.Columns.Add("pago")
        dgvPagosVarios.TableDescriptor.Columns(6).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(6).HeaderText = "Monto a Pagar"
        dgvPagosVarios.TableDescriptor.Columns(6).MappingName = "pago"


        ''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("pagome")
        dgvPagosVarios.TableDescriptor.Columns(7).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(7).HeaderText = "Monto a Pagar ME"
        dgvPagosVarios.TableDescriptor.Columns(7).MappingName = "pagome"


        dgvPagosVarios.TableDescriptor.Columns.Add("saldop")
        dgvPagosVarios.TableDescriptor.Columns(8).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(8).HeaderText = "saldop"
        dgvPagosVarios.TableDescriptor.Columns(8).MappingName = "saldop"

        '''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("saldopme")
        dgvPagosVarios.TableDescriptor.Columns(9).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(9).HeaderText = "saldopme"
        dgvPagosVarios.TableDescriptor.Columns(9).MappingName = "saldopme"


        dgvPagosVarios.TableDescriptor.Columns.Add("tipocambio")
        dgvPagosVarios.TableDescriptor.Columns(10).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(10).HeaderText = "T.C"
        dgvPagosVarios.TableDescriptor.Columns(10).MappingName = "tipocambio"


        dgvPagosVarios.TableDescriptor.Columns.Add("iditem")
        dgvPagosVarios.TableDescriptor.Columns(11).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(11).HeaderText = "iditem"
        dgvPagosVarios.TableDescriptor.Columns(11).MappingName = "iditem"




        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("comprobante", GetType(String))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("saldop", GetType(Decimal))
        dt.Columns.Add("saldopme", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("iditem", GetType(Integer))


        dgvPagosVarios.TableDescriptor.Columns("idDocumento").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("idsecuencia").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("comprobante").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("detalle").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldo").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldome").ReadOnly = True
        'dgvPagosVarios.TableDescriptor.Columns("pago").ReadOnly = True
        'dgvPagosVarios.TableDescriptor.Columns("pagome").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldop").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldopme").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("tipocambio").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("iditem").ReadOnly = True

        dgvPagosVarios.TableDescriptor.Columns("saldo").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("saldome").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("pago").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("pagome").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("saldop").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        dgvPagosVarios.TableDescriptor.Columns("saldopme").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        'lista = objLista.ObtenerCuentasPorPagarTodDetails(idprov)
        For Each i As documentoCajaDetalle In objLista.ObtenerPagosDetailsAsientoManual(idprov, strPeriodo, tipop, modulo)

            'Dim dr As DataRow = dt.NewRow()

            If Not i.EstadoCobro = "PG" Then
                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                'martin
                'Dim consulta = (From c In listaPago _
                '              Where c.secuencia = i.secuencia).FirstOrDefault

                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn - consulta.MontoPagadoSoles
                'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme - consulta.MontoPagadoUSD
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme



                If cTotalmn > 0 Or cTotalme > 0 Then

                    nombredoc = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion

                    dt.Rows.Add(i.idDocumento, i.secuencia, (nombredoc & "/" & i.numeroDoc), i.DetalleItem, cTotalmn, cTotalme, CDec(0.0), CDec(0.0), CDec(0.0), CDec(0.0), i.tipoCambioTransacc, 0)

                    deudatotal += cTotalmn
                    deudatotalme += cTotalme
                    'Me.dgvPagosVarios.Table.AddNewRecord.SetCurrent()
                    'Me.dgvPagosVarios.Table.AddNewRecord.BeginEdit()
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("idsecuencia", i.secuencia)
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("detalle", i.DetalleItem)
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldo", cTotalmn)
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldome", cTotalme)
                    'Me.dgvPagosVarios.Table.AddNewRecord.EndEdit()

                End If
            End If
        Next

        dgvPagosVarios.DataSource = dt
        dgvPagosVarios.ShowGroupDropArea = False
        dgvPagosVarios.TableDescriptor.GroupedColumns.Clear()
        dgvPagosVarios.TableDescriptor.GroupedColumns.Add("comprobante")

        txtdeudatotal.Value = deudatotal
        txtdeudatotalme.Value = deudatotalme

    End Sub


    Sub loaddetallefactura(idprov As Integer)

        Dim objLista As New DocumentoCajaDetalleSA
        Dim objLista2 As New documentoAnticipoDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim tablaSA As New tablaDetalleSA
        Dim nombredoc As String

        Dim deudatotal As Decimal = CDec(0.0)
        Dim deudatotalme As Decimal = CDec(0.0)


        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        ' Dim lista As New List(Of documentoCajaDetalle)

        dgvPagosVarios.TableDescriptor.Columns.Clear()
        dgvPagosVarios.TableDescriptor.Columns.Add("idDocumento")
        dgvPagosVarios.TableDescriptor.Columns(0).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(0).HeaderText = "idDocumento"
        dgvPagosVarios.TableDescriptor.Columns(0).MappingName = "idDocumento"

        dgvPagosVarios.TableDescriptor.Columns.Add("idsecuencia")
        dgvPagosVarios.TableDescriptor.Columns(1).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(1).HeaderText = "idsecuencia"
        dgvPagosVarios.TableDescriptor.Columns(1).MappingName = "idsecuencia"

        dgvPagosVarios.TableDescriptor.Columns.Add("comprobante")
        dgvPagosVarios.TableDescriptor.Columns(2).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(2).HeaderText = "comprobante"
        dgvPagosVarios.TableDescriptor.Columns(2).MappingName = "comprobante"

        dgvPagosVarios.TableDescriptor.Columns.Add("detalle")
        dgvPagosVarios.TableDescriptor.Columns(3).Width = 250
        dgvPagosVarios.TableDescriptor.Columns(3).HeaderText = "detalle"
        dgvPagosVarios.TableDescriptor.Columns(3).MappingName = "detalle"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldo")
        dgvPagosVarios.TableDescriptor.Columns(4).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(4).HeaderText = "Deuda"
        dgvPagosVarios.TableDescriptor.Columns(4).MappingName = "saldo"

        dgvPagosVarios.TableDescriptor.Columns.Add("saldome")
        dgvPagosVarios.TableDescriptor.Columns(5).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(5).HeaderText = "saldome"
        dgvPagosVarios.TableDescriptor.Columns(5).MappingName = "saldome"


        dgvPagosVarios.TableDescriptor.Columns.Add("pago")
        dgvPagosVarios.TableDescriptor.Columns(6).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(6).HeaderText = "Monto a Pagar"
        dgvPagosVarios.TableDescriptor.Columns(6).MappingName = "pago"


        ''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("pagome")
        dgvPagosVarios.TableDescriptor.Columns(7).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(7).HeaderText = "Monto a Pagar ME"
        dgvPagosVarios.TableDescriptor.Columns(7).MappingName = "pagome"


        dgvPagosVarios.TableDescriptor.Columns.Add("saldop")
        dgvPagosVarios.TableDescriptor.Columns(8).Width = 75
        dgvPagosVarios.TableDescriptor.Columns(8).HeaderText = "saldop"
        dgvPagosVarios.TableDescriptor.Columns(8).MappingName = "saldop"

        '''''''
        dgvPagosVarios.TableDescriptor.Columns.Add("saldopme")
        dgvPagosVarios.TableDescriptor.Columns(9).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(9).HeaderText = "saldopme"
        dgvPagosVarios.TableDescriptor.Columns(9).MappingName = "saldopme"


        dgvPagosVarios.TableDescriptor.Columns.Add("tipocambio")
        dgvPagosVarios.TableDescriptor.Columns(10).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(10).HeaderText = "T.C"
        dgvPagosVarios.TableDescriptor.Columns(10).MappingName = "tipocambio"


        dgvPagosVarios.TableDescriptor.Columns.Add("iditem")
        dgvPagosVarios.TableDescriptor.Columns(11).Width = 0
        dgvPagosVarios.TableDescriptor.Columns(11).HeaderText = "iditem"
        dgvPagosVarios.TableDescriptor.Columns(11).MappingName = "iditem"




        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("comprobante", GetType(String))
        dt.Columns.Add("detalle", GetType(String))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("saldop", GetType(Decimal))
        dt.Columns.Add("saldopme", GetType(Decimal))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("iditem", GetType(Integer))


        dgvPagosVarios.TableDescriptor.Columns("idDocumento").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("idsecuencia").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("comprobante").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("detalle").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldo").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldome").ReadOnly = True
        'dgvPagosVarios.TableDescriptor.Columns("pago").ReadOnly = True
        'dgvPagosVarios.TableDescriptor.Columns("pagome").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldop").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("saldopme").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("tipocambio").ReadOnly = True
        dgvPagosVarios.TableDescriptor.Columns("iditem").ReadOnly = True

        dgvPagosVarios.TableDescriptor.Columns("saldo").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("saldome").Appearance.AnyRecordFieldCell.BackColor = Color.LightBlue
        dgvPagosVarios.TableDescriptor.Columns("pago").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("pagome").Appearance.AnyRecordFieldCell.BackColor = Color.Gold
        dgvPagosVarios.TableDescriptor.Columns("saldop").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        dgvPagosVarios.TableDescriptor.Columns("saldopme").Appearance.AnyRecordFieldCell.BackColor = Color.Tomato
        'lista = objLista.ObtenerCuentasPorPagarTodDetails(idprov)
        For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarTodDetails(idprov, strPeriodo)

            'Dim dr As DataRow = dt.NewRow()

            If Not i.EstadoCobro = "PG" Then
                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)
                'martin
                'Dim consulta = (From c In listaPago _
                '              Where c.secuencia = i.secuencia).FirstOrDefault

                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn - consulta.MontoPagadoSoles
                'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme - consulta.MontoPagadoUSD
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme



                If cTotalmn > 0 Or cTotalme > 0 Then

                    nombredoc = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion

                    dt.Rows.Add(i.idDocumento, i.secuencia, (nombredoc & "/" & i.serie & "-" & i.numeroDoc), i.DetalleItem, cTotalmn, cTotalme, CDec(0.0), CDec(0.0), CDec(0.0), CDec(0.0), i.tipoCambioTransacc, i.idItem)

                    deudatotal += cTotalmn
                    deudatotalme += cTotalme
                    'Me.dgvPagosVarios.Table.AddNewRecord.SetCurrent()
                    'Me.dgvPagosVarios.Table.AddNewRecord.BeginEdit()
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("idsecuencia", i.secuencia)
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("detalle", i.DetalleItem)
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldo", cTotalmn)
                    'Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldome", cTotalme)
                    'Me.dgvPagosVarios.Table.AddNewRecord.EndEdit()

                End If
            End If
        Next

        dgvPagosVarios.DataSource = dt
        dgvPagosVarios.ShowGroupDropArea = False
        dgvPagosVarios.TableDescriptor.GroupedColumns.Clear()
        dgvPagosVarios.TableDescriptor.GroupedColumns.Add("comprobante")

        txtdeudatotal.Value = deudatotal
        txtdeudatotalme.Value = deudatotalme

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
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray

        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F


    End Sub


    Sub GridCFG2(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub



    Private Sub UbicarVentaNroSerie(RucCliente As Integer, intMoneda As String)
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoVenta As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))


        documentoVenta = documentoVentaSA.UbicarCompraPorProveedorXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intMoneda)
        Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoCompra
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.importeTotal
                dr(8) = i.tcDolLoc
                dr(9) = i.importeUS
                dr(10) = i.PagoSumaMN
                dr(11) = i.PagoSumaME
                dr(12) = CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(13) = CDec(i.importeUS - i.PagoSumaME).ToString("N2")

                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select
                dt.Rows.Add(dr)
            Next

            Select Case cboMonedaProveedor.Text
                Case "NACIONAL"
                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 70

                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


            dgvPagosVarios.DataSource = dt
            Me.dgvPagosVarios.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else




        End If
    End Sub
#End Region


#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean
        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            PanelError.Visible = False
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

    Private Sub frmAprobadoCronograma_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAprobadoCronograma_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        Dispose()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click


        Me.Cursor = Cursors.WaitCursor

        Dim pagotot As Decimal = CDec(0.0)
        For Each i As Record In dgvPagosVarios.Table.Records
            pagotot += i.GetValue("pago")
        Next

        If txtmontomn.Value = pagotot Then
        Else

            MessageBox.Show("Los Montos Ingresados a pagar no cuadran con el monto programado!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            
            Exit Sub
        End If


        If Not txtmontomn.Value <= txtdeudatotal.Value Then

            
            MessageBox.Show("El monto programado es mayor ala deuda no se puede desembolsar.!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNothing(cajaSeleccionada) Then

        Else

            MessageBox.Show("Seleccione una Caja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim FichaEFSaldo As New GFichaUsuario

        Try

            If txtmontomn.Value > 0 Then



                If manipulacionEstado = ENTITY_ACTIONS.INSERT Then

                    'obteniendo saldo  de la entidad financiera seleccionada
                    Select Case cajaSeleccionada.moneda
                        Case 1
                            'If txtImporteCompramn.Value > nudDeudaPendientemn.Value Then
                            '    Throw New Exception("El importe compra execede al monto de la cuenta financiera actual!")
                            'Else
                            If txtGlosa.Text = "POR PAGO A PROVEEDOR" Then
                                Grabar()
                            Else

                                GrabarPagoAsiento()
                            End If
                            'End If
                        Case 2
                            'If txtImporteComprame.Value > nudDeudaPendienteme.Value Then
                            '    Throw New Exception("El importe compra execede al monto de la cuenta financiera actual!")
                            'Else
                            If txtGlosa.Text = "POR PAGO A PROVEEDOR" Then
                                Grabar()
                            Else
                                GrabarPagoAsiento()
                            End If
                            'End If
                    End Select

                ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    '   Editar()
                End If
            Else
                lblEstado.Text = "Ingresar el importe a pagar!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

        End Try
        Me.Cursor = Cursors.Arrow





        '//////////////////////////
        'Dim datos As List(Of item) = item.Instance()
        'datos.Clear()
        'Dim c As New item
        'c.idItem = 1

        'datos.Add(c)
        'Dispose()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor

        If txttipo.Text = "Pago" Then

            Select Case cboMonedaProveedor.Text
                Case "NACIONAL"
                    'LoadFacturasDetalle(txtProveedor.Tag, "1")
                    If txtGlosa.Text = "POR PAGO A PROVEEDOR" Then
                        loaddetallefactura(txtProveedor.Tag)

                    Else
                        loaddetalleAsientoManual(txtProveedor.Tag, "P", txtGlosa.Text)

                    End If
                    ' UbicarVentaNroSerie(txtProveedor.Tag, "1")
                Case "EXTRANJERA"
                    ' UbicarVentaNroSerie(txtProveedor.Tag, "2")
            End Select


        End If

        Me.Cursor = Cursors.Arrow
    End Sub



  

 


    




    Dim listamov As New List(Of movimiento)
    Dim cajaSeleccionada As New CajaInfo
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click


        Dim listapagodocumento As New List(Of documentocompra)
        Dim docCompra As New documentocompra
        Dim montotot As Decimal = CDec(0.0)
        Dim montototme As Decimal = CDec(0.0)

        For Each i As Record In dgvPagosVarios.Table.Records

            If i.GetValue("pago") > 0 Then
                docCompra = New documentocompra
                docCompra.idDocumento = i.GetValue("idDocumento")
                docCompra.idCentroCosto = i.GetValue("idsecuencia")
                docCompra.importeTotal = i.GetValue("pago")
                docCompra.importeUS = i.GetValue("pagome")
                docCompra.tipocambio = i.GetValue("tipocambio")
                montotot += i.GetValue("pago")
                montototme += i.GetValue("pagome")

                listapagodocumento.Add(docCompra)
            End If
        Next


        Dim f As New frmcajapagos

        f.StartPosition = FormStartPosition.CenterParent
        f.txtImporteCompramn.Value = montotot
        f.txtImporteComprame.Value = montototme
        f.txtTipoCambio.Value = TmpTipoCambioTransaccionVenta
        f.listaPagosCompra = listapagodocumento
        If txtmonedaprog.Text = "NACIONAL" Then
            f.tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
        ElseIf txtmonedaprog.Text = "EXTRANJERO" Then
            f.tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
        End If

        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            cajaSeleccionada = CType(f.Tag, CajaInfo)

        End If



        listamov = f.movimientos()


    End Sub


    Private Sub dgvPagosVarios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPagosVarios.TableControlCellClick

    End Sub

    Private Sub dgvPagosVarios_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPagosVarios.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvPagosVarios.Table.CurrentRecord) Then
        '    Select Case ColIndex

        '        Case 8


        '            If Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pago") >= 0 Then

        '                If Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pago") <= Me.dgvPagosVarios.Table.CurrentRecord.GetValue("saldo") Then

        '                    Dim colPercepcionME As Decimal = 0
        '                    colPercepcionME = Math.Round(CDec(Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pago")) / TmpTipoCambio, 2)
        '                    Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pagome", colPercepcionME)



        '                    Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldop", Me.dgvPagosVarios.Table.CurrentRecord.GetValue("saldo") - Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pago"))
        '                    Me.dgvPagosVarios.Table.CurrentRecord.SetValue("saldopme", Me.dgvPagosVarios.Table.CurrentRecord.GetValue("saldome") - Me.dgvPagosVarios.Table.CurrentRecord.GetValue("pagome"))

        '                    'If Me.dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoMN") > 0 Then

        '                    '    ' Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("chBonif", True)
        '                    '    ' Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("val", "S")
        '                    'Else

        '                    '    'Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("chBonif", False)
        '                    '    ' Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("val", "N")

        '                    'End If

        '                Else

        '                    Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pago", CDec(0.0))
        '                    Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pagome", CDec(0.0))
        '                    ' MessageBox.Show("Ingrese un Monto Menor o Igual ala deuda")
        '                    MessageBox.Show("Ingrese un Monto Menor o Igual ala deuda!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)


        '                    'Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("chBonif", False)
        '                    'Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("val", "N")
        '                End If

        '            Else
        '                Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pago", CDec(0.0))
        '                Me.dgvPagosVarios.Table.CurrentRecord.SetValue("pagome", CDec(0.0))
        '            End If



        '            calculototalpagos()

        '    End Select
        'End If
    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCellClick

    End Sub
End Class