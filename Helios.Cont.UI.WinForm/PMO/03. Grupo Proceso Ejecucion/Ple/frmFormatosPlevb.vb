Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO

Public Class frmFormatosPlevb

#Region "Attributes"
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
    Dim listaMeses As New List(Of MesesAnio)
    Dim cajaUsuario As New cajaUsuario
    Dim cajaUsuarioSA As New cajaUsuarioSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormatoGrid(dgvCompras)
        Meses()
    End Sub
#End Region

#Region "Methods"


    Public Sub generadorVentaTXT(strPeriodo As String, Ruta As String)


        Dim NombreDelTXT As String
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim tienemodificacion As String = "NO"
        Dim TipoAnotado As String = "NO"
        Dim listaObj As New List(Of documentoventaAbarrotes)
        Dim archivo As StreamWriter
        Dim Linea As String = Nothing

        'Dim periodo As String
        'periodo = años & meses & "00"

        Dim FechaNotaCredito As String = ""
        Dim FechaDetraccion As String = ""
        Dim nroConst As String = ""
        Dim FechaVct As String = ""
        Dim FechaEmision As String = ""
        Dim MonedaUso As String = ""
        Dim NotaSerie As String = ""
        Dim NotaNumero As String = ""
        Dim TipoDocNota As String = ""
        Dim FechaNota As String = ""

        Dim SerieDoc As String = ""
        Dim NumeroDoc As String = ""
        Dim TipoDocNuevo As String = ""

        Dim TipoDocClie As String = ""
        Dim NombreClie As String = ""
        Dim NumeroDocClie As String = ""


        Try

            listaObj = compraSA.GenerarTXTventa(GEstableciento.IdEstablecimiento, strPeriodo)
            If listaObj.Count > 0 Then
                NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "0014010000" & "1" & "1" & "1" & "1" & ".TXT"
            Else
                NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "0014010000" & "1" & "1" & "1" & "1" & ".TXT"
            End If

            If Strings.Right(Ruta, 1) = "\" Then
                archivo = New StreamWriter(Ruta & NombreDelTXT)
            Else
                archivo = New StreamWriter(Ruta & "\" & NombreDelTXT)
            End If


            For Each i In listaObj
                FechaNotaCredito = ""
                FechaDetraccion = ""
                nroConst = ""
                FechaVct = ""
                FechaEmision = ""

                NotaSerie = ""
                NotaNumero = ""
                TipoDocNota = ""
                FechaNota = ""

                SerieDoc = ""
                NumeroDoc = ""


                Dim PeriodoCont As String = Mid(i.fechaPeriodo, 4, 4) & Mid(i.fechaPeriodo, 1, 2)

                Dim PeriodoInfo = i.fechaDoc.Value.Year.ToString & String.Format("{0:00}", i.fechaDoc.Value.Month)

                FechaEmision = String.Format("{0:00}", i.fechaDoc.Value.Day) & "/" & String.Format("{0:00}", i.fechaDoc.Value.Month) & "/" & i.fechaDoc.Value.Year.ToString


                Dim valorCamp34 As Integer


                If PeriodoCont = PeriodoInfo Then

                    If i.estadoCobro = "ANU" Then
                        valorCamp34 = 2

                        FechaEmision = ""
                    Else
                        valorCamp34 = 1
                    End If
                Else
                    If TipoAnotado = "NO" Then
                        valorCamp34 = 8
                    Else
                        valorCamp34 = 9
                    End If

                End If


                If i.tipoDocumento = "14" Then
                    If Not valorCamp34 = 2 Then
                        FechaVct = String.Format("{0:00}", i.fechaVcto.Value.Day) & "/" & String.Format("{0:00}", i.fechaVcto.Value.Month) & "/" & i.fechaVcto.Value.Year.ToString
                    Else
                        FechaVct = ""
                    End If
                Else
                    FechaVct = ""
                End If


                'solo si es nota de credito debito etc"
                If i.tipoDocumento = "07" Or i.tipoDocumento = "08" Or i.tipoDocumento = "87" Or i.tipoDocumento = "88" Or i.tipoDocumento = "97" Or i.tipoDocumento = "98" Then
                    FechaNotaCredito = FechaEmision
                    'NotaSerie = i.SerieNota
                    'NotaNumero = i.NumeroNota
                    'TipoDocNota = i.TipoDocNota

                    If i.TipoDocNota = "12.1" Or i.TipoDocNota = "12.2" Then
                        TipoDocNota = "12"
                    Else
                        TipoDocNota = i.TipoDocNota
                    End If


                    FechaNota = String.Format("{0:00}", i.FechaNota.Day) & "/" & String.Format("{0:00}", i.FechaNota.Month) & "/" & i.FechaNota.Year.ToString

                    'datos del documento padre d ela nota de credito o debnito segun el tipo doc


                    If i.TipoDocNota = "23" Or i.TipoDocNota = "25" Or i.TipoDocNota = "34" Or i.TipoDocNota = "35" Or i.TipoDocNota = "48" Then
                        NotaSerie = Strings.Right(i.SerieNota, 4)
                        NotaNumero = Strings.Right(i.NumeroNota, 7)

                        NotaSerie = NotaSerie.PadLeft(4, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(7, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "01" Or i.TipoDocNota = "03" Or i.TipoDocNota = "04" Or i.TipoDocNota = "06" Or i.TipoDocNota = "07" Or i.TipoDocNota = "08" Or i.TipoDocNota = "36" Then

                        NotaSerie = Strings.Right(i.SerieNota, 4)
                        NotaNumero = Strings.Right(i.NumeroNota, 8)

                        NotaSerie = NotaSerie.PadLeft(4, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(8, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "05" Or i.TipoDocNota = "55" Then

                        NotaSerie = Strings.Right(i.SerieNota, 1)
                        NotaNumero = Strings.Right(i.NumeroNota, 11)

                        NotaSerie = NotaSerie.PadLeft(1, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(11, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "56" Then

                        NotaSerie = Strings.Right(i.SerieNota, 4)
                        NotaNumero = Strings.Right(i.NumeroNota, 11)

                        NotaSerie = NotaSerie.PadLeft(4, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(11, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "11" Then

                        NotaSerie = Strings.Right(i.SerieNota, 20)
                        NotaNumero = Strings.Right(i.NumeroNota, 15)

                        NotaSerie = NotaSerie.PadLeft(20, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(15, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "12" Or i.TipoDocNota = "12.1" Or i.TipoDocNota = "12.2" Or i.TipoDocNota = "13" Or i.TipoDocNota = "14" Or i.TipoDocNota = "15" Or i.TipoDocNota = "16" Or i.TipoDocNota = "17" Or i.TipoDocNota = "18" Or i.TipoDocNota = "19" _
                        Or i.TipoDocNota = "21" Or i.TipoDocNota = "24" Or i.TipoDocNota = "26" Or i.TipoDocNota = "27" Or i.TipoDocNota = "28" Or i.TipoDocNota = "29" Or i.TipoDocNota = "30" Or i.TipoDocNota = "32" Or i.TipoDocNota = "37" Or i.TipoDocNota = "42" Or i.TipoDocNota = "43" _
                         Or i.TipoDocNota = "44" Or i.TipoDocNota = "45" Or i.TipoDocNota = "49" Or i.TipoDocNota = "87" Or i.TipoDocNota = "88" Then

                        NotaSerie = Strings.Right(i.SerieNota, 20)
                        NotaNumero = Strings.Right(i.NumeroNota, 20)

                        NotaSerie = NotaSerie.PadLeft(20, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(20, "0" & NotaNumero)

                    End If

                Else
                    FechaNotaCredito = ""
                    NotaSerie = ""
                    NotaNumero = ""
                    TipoDocNota = ""
                    FechaNota = ""
                End If



                'segun el tipo de documento cantidad en serie y numero
                If i.tipoDocumento = "23" Or i.tipoDocumento = "25" Or i.tipoDocumento = "34" Or i.tipoDocumento = "35" Or i.tipoDocumento = "48" Then
                    SerieDoc = Strings.Right(i.serieVenta, 4)
                    NumeroDoc = Strings.Right(i.numeroVenta, 7)


                    SerieDoc = SerieDoc.PadLeft(4, "0" & SerieDoc)
                    NumeroDoc = NumeroDoc.PadLeft(7, "0" & NumeroDoc)

                ElseIf i.tipoDocumento = "01" Or i.tipoDocumento = "03" Or i.tipoDocumento = "04" Or i.tipoDocumento = "06" Or i.tipoDocumento = "07" Or i.tipoDocumento = "08" Or i.tipoDocumento = "36" Then

                    SerieDoc = Strings.Right(i.serieVenta, 4)
                    NumeroDoc = Strings.Right(i.numeroVenta, 8)

                    SerieDoc = SerieDoc.PadLeft(4, "0" & SerieDoc)
                    NumeroDoc = NumeroDoc.PadLeft(8, "0" & NumeroDoc)

                ElseIf i.tipoDocumento = "05" Or i.tipoDocumento = "55" Then

                    SerieDoc = Strings.Right(i.serieVenta, 1)
                    NumeroDoc = Strings.Right(i.numeroVenta, 11)

                    SerieDoc = SerieDoc.PadLeft(1, "0" & SerieDoc)
                    NumeroDoc = NumeroDoc.PadLeft(11, "0" & NumeroDoc)

                ElseIf i.tipoDocumento = "56" Then

                    SerieDoc = Strings.Right(i.serieVenta, 4)
                    NumeroDoc = Strings.Right(i.numeroVenta, 11)

                    SerieDoc = SerieDoc.PadLeft(4, "0" & SerieDoc)
                    NumeroDoc = NumeroDoc.PadLeft(11, "0" & NumeroDoc)

                ElseIf i.tipoDocumento = "11" Then

                    SerieDoc = Strings.Right(i.serieVenta, 20)
                    NumeroDoc = Strings.Right(i.numeroVenta, 15)

                    SerieDoc = SerieDoc.PadLeft(20, "0" & SerieDoc)
                    NumeroDoc = NumeroDoc.PadLeft(15, "0" & NumeroDoc)

                ElseIf i.tipoDocumento = "12" Or i.tipoDocumento = "12.1" Or i.tipoDocumento = "12.2" Or i.tipoDocumento = "13" Or i.tipoDocumento = "14" Or i.tipoDocumento = "15" Or i.tipoDocumento = "16" Or i.tipoDocumento = "17" Or i.tipoDocumento = "18" Or i.tipoDocumento = "19" _
                    Or i.tipoDocumento = "21" Or i.tipoDocumento = "24" Or i.tipoDocumento = "26" Or i.tipoDocumento = "27" Or i.tipoDocumento = "28" Or i.tipoDocumento = "29" Or i.tipoDocumento = "30" Or i.tipoDocumento = "32" Or i.tipoDocumento = "37" Or i.tipoDocumento = "42" Or i.tipoDocumento = "43" _
                     Or i.tipoDocumento = "44" Or i.tipoDocumento = "45" Or i.tipoDocumento = "49" Or i.tipoDocumento = "87" Or i.tipoDocumento = "88" Then

                    SerieDoc = Strings.Right(i.serieVenta, 20)
                    NumeroDoc = Strings.Right(i.numeroVenta, 20)

                    SerieDoc = SerieDoc.PadLeft(20, "0" & SerieDoc)
                    NumeroDoc = NumeroDoc.PadLeft(20, "0" & NumeroDoc)

                End If





                If i.moneda = "1" Then
                    MonedaUso = "PEN"
                ElseIf i.moneda = "2" Then
                    MonedaUso = "USD"
                End If

                If i.tipoDocumento = "12.1" Or i.tipoDocumento = "12.2" Then
                    TipoDocNuevo = "12"
                Else
                    TipoDocNuevo = i.tipoDocumento
                End If

                If i.tipoDocEntidad = "" Then
                    TipoDocClie = "0"
                    NumeroDocClie = "0"
                    NombreClie = "CLIENTES VARIOS"

                Else
                    TipoDocClie = i.tipoDocEntidad
                    NumeroDocClie = i.NroDocEntidad
                    NombreClie = i.NombreEntidad
                End If



                Linea = PeriodoCont & "00" & "|" & _
                        i.idDocumento & "|" & _
                         "M" & i.idDocumento & "|" & _
                         FechaEmision & "|" & _
                         FechaVct & "|" & _
                         TipoDocNuevo & "|" & _
                          SerieDoc & "|" & _
                          NumeroDoc & "|" & _
                          "" & "|" & _
                          TipoDocClie & "|" & _
                          NumeroDocClie & "|" & _
                          (NombreClie).Replace(",", "") & "|" & _
                          "" & "|" & _
                          String.Format("{0:0.00}", i.bi01) & "|" & _
                          "" & "|" & _
                          String.Format("{0:0.00}", i.igv01) & "|" & _
                          "" & "|" & _
                          String.Format("{0:0.00}", i.bi02) & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          String.Format("{0:0.00}", i.ImporteNacional) & "|" & _
                          MonedaUso & "|" & _
                          String.Format("{0:0.000}", i.tipoCambio) & "|" & _
                          FechaNotaCredito & "|" & _
                          TipoDocNota & "|" & _
                          NotaSerie & "|" & _
                          NotaNumero & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                         valorCamp34 & "|" & _
                         "" & "|"

                archivo.WriteLine(Linea)

            Next
            archivo.Close()

            MsgBox("Se Genero Correctamente el archivo txt." & vbCrLf)

        Catch ex As Exception
            MsgBox("No se pudo generar el archivo txt." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub generadorTXTNoDomiciliado(strPeriodo As String, Ruta As String)


        Dim NombreDelTXT As String
        Dim compraSA As New DocumentoCompraSA
        Dim tienemodificacion As String = "NO"
        Dim listaObj As New List(Of documentocompra)
        Dim archivo As StreamWriter
        Dim Linea As String = Nothing

        'Dim periodo As String
        'periodo = años & meses & "00"

        Dim FechaNotaCredito As String = ""
        Dim FechaDetraccion As String = ""
        Dim nroConst As String = ""
        Dim MonedaUso As String = ""

        Dim NotaSerie As String = ""
        Dim NotaNumero As String = ""
        Dim TipoDocNota As String = ""
        Dim FechaNota As String = ""
        Dim FechaVct As String = ""
        Dim Serie As String = ""
        Dim Numero As String = ""


        Try
            'listaObj = compraSA.GenerarTXTcompras(GEstableciento.IdEstablecimiento, strPeriodo)
            'If listaObj.Count > 0 Then
            '    NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "0008010000" & "1" & "1" & "1" & "1" & ".TXT"
            'Else
            NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "00080200001111" & ".TXT"
            'End If

            'archivo = New StreamWriter("c:/Sunat/LE2039265702020170800080100001111.TXT")
            'archivo = New StreamWriter(Ruta & "\" & NombreDelTXT)

            If Strings.Right(Ruta, 1) = "\" Then
                archivo = New StreamWriter(Ruta & NombreDelTXT)
            Else
                archivo = New StreamWriter(Ruta & "\" & NombreDelTXT)
            End If


            'For Each i In listaObj
            'FechaNotaCredito = ""
            'FechaDetraccion = ""
            'nroConst = ""
            'MonedaUso = ""
            'NotaSerie = ""
            'NotaNumero = ""
            'TipoDocNota = ""
            'FechaNota = ""
            'FechaVct = ""
            'Serie = ""
            'Numero = ""


            Dim PeriodoCont As String = Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2)

            'Dim PeriodoInfo = i.fechaDoc.Value.Year.ToString & String.Format("{0:00}", i.fechaDoc.Value.Month)

            'Dim FechaEmision = String.Format("{0:00}", i.fechaDoc.Value.Day) & "/" & String.Format("{0:00}", i.fechaDoc.Value.Month) & "/" & i.fechaDoc.Value.Year.ToString
            'If i.tipoDoc = "14" Then
            '    FechaVct = String.Format("{0:00}", i.fechaVcto.Value.Day) & "/" & String.Format("{0:00}", i.fechaVcto.Value.Month) & "/" & i.fechaVcto.Value.Year.ToString

            '    'Serie = i.serie
            '    'Numero = i.numeroDoc

            'ElseIf i.tipoDoc = "12" Then

            '    FechaVct = ""
            '    'Serie = i.serie
            '    'Numero = i.numeroDoc

            '    'Else

            '    '    FechaVct = ""
            '    '    Serie = Strings.Right(i.serie, 4)
            '    '    Numero = Strings.Right(i.numeroDoc, 8)

            'End If


            'If i.tipoDoc = "05" Or "55" Then

            '    Serie = Strings.Right(i.serie, 1)
            '    Numero = Strings.Right(i.numeroDoc, 11)

            'ElseIf i.tipoDoc = "50" Or "51" Or "52" Or "53" Or "54" Then

            '    Serie = Strings.Right(i.serie, 3)
            '    Numero = Strings.Right(i.numeroDoc, 6)

            'ElseIf i.tipoDoc = "54" Then

            '    Serie = Strings.Right(i.serie, 3)
            '    Numero = Strings.Right(i.numeroDoc, 20)


            'ElseIf i.tipoDoc = "02" Or "23" Or "25" Or "34" Or "35" Or "48" Or "89" Then

            '    Serie = Strings.Right(i.serie, 4)
            '    Numero = Strings.Right(i.numeroDoc, 7)

            'ElseIf i.tipoDoc = "36" Or "01" Or "03" Or "04" Or "06" Or "07" Or "08" Then

            '    Serie = Strings.Right(i.serie, 4)
            '    Numero = Strings.Right(i.numeroDoc, 8)

            'ElseIf i.tipoDoc = "56" Then

            '    Serie = Strings.Right(i.serie, 4)
            '    Numero = Strings.Right(i.numeroDoc, 11)

            'ElseIf i.tipoDoc = "10" Or "22" Or "46" Then

            '    Serie = Strings.Right(i.serie, 4)
            '    Numero = Strings.Right(i.numeroDoc, 20)

            'ElseIf i.tipoDoc = "11" Then

            '    Serie = Strings.Right(i.serie, 20)
            '    Numero = Strings.Right(i.numeroDoc, 15)

            'ElseIf i.tipoDoc = "12" Or "13" Or "14" Or "15" Or "16" Or "17" Or "18" Or "19" Or "21" _
            '    Or "24" Or "26" Or "27" Or "28" Or "29" Or "30" Or "32" Or "37" Or "42" Or "43" Or "44" _
            '    Or "45" Or "49" Or "87" Or "88" Or "91" Or "96" Or "97" Or "98" Then

            '    Serie = Strings.Right(i.serie, 20)
            '    Numero = Strings.Right(i.numeroDoc, 20)

            'End If




            'Dim valorCamp41 As Integer

            'If tienemodificacion = "SI" Then
            '    valorCamp41 = 9
            'Else
            '    If PeriodoCont = PeriodoInfo Then

            '        If i.igv01 > 0 Then
            '            valorCamp41 = 1
            '        Else
            '            valorCamp41 = 0
            '        End If
            '    Else
            '        If i.igv01 > 0 Then
            '            valorCamp41 = 6
            '        Else
            '            valorCamp41 = 7
            '        End If

            '    End If
            'End If

            'If i.tipoDoc = "07" Or "08" Or "87" Or "88" Or "97" Or "98" Then
            '    FechaNotaCredito = FechaEmision


            '    'NotaSerie = i.SerieNota
            '    'NotaNumero = i.NumeroNota
            '    TipoDocNota = i.TipoDocNota
            '    FechaNota = String.Format("{0:00}", i.FechaNota.Day) & "/" & String.Format("{0:00}", i.FechaNota.Month) & "/" & i.FechaNota.Year.ToString



            '    'documento padre  de la nota credito o debito  

            '    If i.TipoDocNota = "05" Or "55" Then

            '        NotaSerie = Strings.Right(i.SerieNota, 1)
            '        NotaNumero = Strings.Right(i.NumeroNota, 11)

            '    ElseIf i.TipoDocNota = "50" Or "51" Or "52" Or "53" Or "54" Then

            '        NotaSerie = Strings.Right(i.SerieNota, 3)
            '        NotaNumero = Strings.Right(i.NumeroNota, 6)

            '    ElseIf i.TipoDocNota = "54" Then

            '        NotaSerie = Strings.Right(i.SerieNota, 3)
            '        NotaNumero = Strings.Right(i.NumeroNota, 20)


            '    ElseIf i.TipoDocNota = "02" Or "23" Or "25" Or "34" Or "35" Or "48" Or "89" Then

            '        NotaSerie = Strings.Right(i.SerieNota, 4)
            '        NotaNumero = Strings.Right(i.NumeroNota, 7)

            '    ElseIf i.TipoDocNota = "36" Or "01" Or "03" Or "04" Or "06" Or "07" Or "08" Then

            '        NotaSerie = Strings.Right(i.SerieNota, 4)
            '        NotaNumero = Strings.Right(i.NumeroNota, 8)

            '    ElseIf i.TipoDocNota = "56" Then

            '        NotaSerie = Strings.Right(i.SerieNota, 4)
            '        NotaNumero = Strings.Right(i.NumeroNota, 11)

            '    ElseIf i.TipoDocNota = "10" Or "22" Or "46" Then

            '        NotaSerie = Strings.Right(i.SerieNota, 4)
            '        NotaNumero = Strings.Right(i.NumeroNota, 20)

            '    ElseIf i.TipoDocNota = "11" Then

            '        NotaSerie = Strings.Right(i.SerieNota, 20)
            '        NotaNumero = Strings.Right(i.NumeroNota, 15)

            '    ElseIf i.TipoDocNota = "12" Or "13" Or "14" Or "15" Or "16" Or "17" Or "18" Or "19" Or "21" _
            '        Or "24" Or "26" Or "27" Or "28" Or "29" Or "30" Or "32" Or "37" Or "42" Or "43" Or "44" _
            '        Or "45" Or "49" Or "87" Or "88" Or "91" Or "96" Or "97" Or "98" Then

            '        NotaSerie = Strings.Right(i.SerieNota, 20)
            '        NotaNumero = Strings.Right(i.NumeroNota, 20)

            '    End If

            '    ''///////////////////////////////


            'Else
            '    FechaNotaCredito = ""
            '    NotaSerie = ""
            '    NotaNumero = ""
            '    TipoDocNota = ""
            '    FechaNota = ""
            'End If


            'If i.tieneDetraccion = "S" Then

            '    FechaDetraccion = String.Format("{0:00}", i.fechaConstancia.Value.Day) & "/" & String.Format("{0:00}", i.fechaConstancia.Value.Month) & "/" & i.fechaConstancia.Value.Year.ToString
            '    nroConst = i.nroConstancia
            'Else
            '    FechaDetraccion = ""
            '    nroConst = ""
            'End If


            'If i.monedaDoc = "1" Then
            '    MonedaUso = "PEN"
            'ElseIf i.monedaDoc = "2" Then
            '    MonedaUso = "USD"
            'End If





            Linea = PeriodoCont & "00" & "|" & _
                    "0000000001" & "|" & _
                     "M000000001" & "|" & _
                     "01/01/0001" & "|" & _
                     "00" & "|" & _
                     "" & "|" & _
                      "000000001" & "|" & _
                      "" & "|" & _
                       "" & "|" & _
                      "0.00" & "|" & _
                      "00" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "0.00" & "|" & _
                      "0.00" & "|" & _
                      "PEN" & "|" & _
                      "0.000" & "|" & _
                      "9589" & "|" & _
                      "SIN OPERACIONES" & "|" & _
                      "" & "|" & _
                      "0" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "00" & "|" & _
                      "" & "|" & _
                      "00" & "|" & _
                      "" & "|" & _
                      "" & "|" & _
                      "0" & "|"

            archivo.WriteLine(Linea)

            'Next
            archivo.Close()

            MsgBox("Se Genero Correctamente el archivo txt." & vbCrLf)

        Catch ex As Exception
            MsgBox("No se pudo generar el archivo txt." & vbCrLf & ex.Message)
        End Try
    End Sub



    Public Sub EstructuraLibro(strPeriodo As String, Ruta As String, mesEnv As String, anioEnv As String)


        Dim NombreDelTXT As String
        Dim compraSA As New cuentaplanContableEmpresaSA
        Dim tienemodificacion As String = "NO"
        Dim listaObj As New List(Of cuentaplanContableEmpresa)
        Dim archivo As StreamWriter
        Dim Linea As String = Nothing

        'Dim periodo As String
        'periodo = años & meses & "00"

        Dim FechaNotaCredito As String = ""
        Dim FechaDetraccion As String = ""
        Dim nroConst As String = ""
        Dim MonedaUso As String = ""

        Dim NotaSerie As String = ""
        Dim NotaNumero As String = ""
        Dim TipoDocNota As String = ""
        Dim FechaNota As String = ""
        Dim FechaVct As String = ""
        Dim Serie As String = ""
        Dim Numero As String = ""
        Dim TipoDocNuevo As String = ""
        Dim TipoDocNotaNuevo As String = ""

        Dim validador As String = ""

        Try

            listaObj = compraSA.LoadEstructuraLibroDiario(Gempresas.IdEmpresaRuc, strPeriodo)
            If listaObj.Count > 0 Then
                NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "0005030000" & "1" & "1" & "1" & "1" & ".TXT"
            Else
                NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "0005030000" & "1" & "1" & "1" & "1" & ".TXT"
            End If

            'archivo = New StreamWriter("c:/Sunat/LE2039265702020170800080100001111.TXT")
            'archivo = New StreamWriter(Ruta & "\" & NombreDelTXT)

            If Strings.Right(Ruta, 1) = "\" Then
                archivo = New StreamWriter(Ruta & NombreDelTXT)
            Else
                archivo = New StreamWriter(Ruta & "\" & NombreDelTXT)
            End If

            Dim count As Integer = 0

            For Each i In listaObj





                validador = Strings.Left(i.cuenta, 3)


                If validador = "331" Or validador = "332" Or validador = "333" Or validador = "334" Or validador = "335" Or
                     validador = "336" Or validador = "337" Or validador = "338" Or validador = "339" Or validador = "341" Or
                     validador = "342" Or validador = "343" Or validador = "344" Or validador = "345" Or validador = "346" Or
                     validador = "347" Or validador = "348" Or validador = "349" Or validador = "312" Or validador = "311" Or
                     validador = "313" Or validador = "314" Or validador = "315" Or validador = "316" Or validador = "317" Or
                     validador = "318" Or validador = "319" Or validador = "564" Then

                    If i.cuenta.Trim.Length = 3 Then


                        'count = count + 1

                        'If count = 1037 Then

                        '    Dim er = "1"

                        'End If

                        If i.cuenta = "564" Then

                        Else
                            Linea = anioEnv & mesEnv & "01" & "|" &
                            i.cuenta & "|" &
                              i.descripcion & "|" &
                              "01" & "|" &
                              "" & "|" &
                              "" & "|" &
                              "" & "|" &
                             "1" & "|"

                            archivo.WriteLine(Linea)
                        End If
                    End If
                    Else


                    If i.cuenta.Trim.Length > 2 Then

                        count = count + 1

                        If count = 1037 Then

                            Dim er = "1"

                        End If

                        Linea = anioEnv & mesEnv & "01" & "|" &
                            i.cuenta & "|" &
                              i.descripcion & "|" &
                              "01" & "|" &
                              "" & "|" &
                              "" & "|" &
                              "" & "|" &
                             "1" & "|"

                        archivo.WriteLine(Linea)

                    End If
                End If
            Next
            archivo.Close()
            MsgBox("Se Genero Correctamente el archivo txt." & vbCrLf)

        Catch ex As Exception
            MsgBox("No se pudo generar el archivo txt." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub LibroDiarioTXT(strPeriodo As String, Ruta As String, anio As String, mes As String)


        Dim NombreDelTXT As String
        Dim movimientoSA As New MovimientoSA
        Dim tienemodificacion As String = "NO"
        Dim listaObj As New List(Of movimiento)
        Dim archivo As StreamWriter
        Dim Linea As String = Nothing

        'Dim periodo As String
        'periodo = años & meses & "00"




        Dim MonedaUso As String = ""

        Dim Serie As String = ""
        Dim Numero As String = ""
        Dim TipoDocNuevo As String = ""
        Dim TipoDocNotaNuevo As String = ""

        Dim DocumentoIdentificacion As String = ""
        Dim NumeroDocIdentificacion As String = ""

        Dim MontoDebe As Decimal = CDec(0.00)
        Dim MontoHaber As Decimal = CDec(0.00)


        Dim x = ""
        Dim seriedoc = ""
        Dim numerodoc = ""

        Dim NuevaGlosa As String = ""

        Try

            listaObj = movimientoSA.TxtPleLibroDiarioV2(Gempresas.IdEmpresaRuc, anio, mes)
            If listaObj.Count > 0 Then
                NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "0005010000" & "1" & "1" & "1" & "1" & ".TXT"
            Else
                NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "0005010000" & "1" & "1" & "1" & "1" & ".TXT"
            End If

            'archivo = New StreamWriter("c:/Sunat/LE2039265702020170800080100001111.TXT")
            'archivo = New StreamWriter(Ruta & "\" & NombreDelTXT)

            If Strings.Right(Ruta, 1) = "\" Then
                archivo = New StreamWriter(Ruta & NombreDelTXT)
            Else
                archivo = New StreamWriter(Ruta & "\" & NombreDelTXT)
            End If

            Dim conteo As Integer = 0

            For Each i In listaObj



                MonedaUso = ""
                Serie = ""
                Numero = ""
                seriedoc = ""
                numerodoc = ""



                'Dim PeriodoCont As String = Mid(i.periodo, 4, 4) & Mid(i.periodo, 1, 2)
                Dim PeriodoCont As String = Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2)

                Dim PeriodoInfo = i.fechaProceso.Value.Year.ToString & String.Format("{0:00}", i.fechaProceso.Value.Month)

                Dim FechaEmision = String.Format("{0:00}", i.fechaProceso.Value.Day) & "/" & String.Format("{0:00}", i.fechaProceso.Value.Month) & "/" & i.fechaProceso.Value.Year.ToString



                If i.tipoDoc = "12.1" Then
                    TipoDocNuevo = "12"
                ElseIf i.tipoDoc = "9901" Or i.tipoDoc = "9902" Or i.tipoDoc = "9903" Or i.tipoDoc = "9904" Or i.tipoDoc = "9905" _
                       Or i.tipoDoc = "9906" Or i.tipoDoc = "9907" Or i.tipoDoc = "9908" Or i.tipoDoc = "001" Then

                    TipoDocNuevo = "00"
                Else
                    TipoDocNuevo = i.tipoDoc
                End If


                If TipoDocNuevo = "00" Then

                    seriedoc = "0000"
                    numerodoc = i.nroDoc

                    Serie = seriedoc
                    Numero = numerodoc

                Else



                    x = InStr(i.nroDoc, "-")
                    seriedoc = Mid(i.nroDoc, 1, x - 1)
                    numerodoc = Mid(i.nroDoc, x + 1)

                    seriedoc = seriedoc.Replace("A", "")
                End If

                If i.tipoDoc = "05" Or i.tipoDoc = "55" Then

                    Serie = Strings.Right(seriedoc, 1)
                    Numero = Strings.Right(numerodoc, 11)


                    Serie = Serie.PadLeft(1, "0" & Serie)
                    Numero = Numero.PadLeft(11, "0" & Numero)

                ElseIf i.tipoDoc = "50" Or i.tipoDoc = "51" Or i.tipoDoc = "52" Or i.tipoDoc = "53" Or i.tipoDoc = "54" Then

                    Serie = Strings.Right(seriedoc, 3)
                    Numero = Strings.Right(numerodoc, 6)

                    Serie = Serie.PadLeft(3, "0" & Serie)
                    Numero = Numero.PadLeft(6, "0" & Numero)

                ElseIf i.tipoDoc = "54" Then

                    Serie = Strings.Right(seriedoc, 3)
                    Numero = Strings.Right(numerodoc, 20)

                    Serie = Serie.PadLeft(3, "0" & Serie)
                    Numero = Numero.PadLeft(20, "0" & Numero)


                ElseIf i.tipoDoc = "02" Or i.tipoDoc = "23" Or i.tipoDoc = "25" Or i.tipoDoc = "34" Or i.tipoDoc = "35" Or i.tipoDoc = "48" Or i.tipoDoc = "89" Then

                    Serie = Strings.Right(seriedoc, 4)
                    Numero = Strings.Right(numerodoc, 7)

                    Serie = Serie.PadLeft(4, "0" & Serie)
                    Numero = Numero.PadLeft(7, "0" & Numero)

                ElseIf i.tipoDoc = "36" Or i.tipoDoc = "01" Or i.tipoDoc = "03" Or i.tipoDoc = "04" Or i.tipoDoc = "06" Or i.tipoDoc = "07" Or i.tipoDoc = "08" Then

                    Serie = Strings.Right(seriedoc, 4)
                    Numero = Strings.Right(numerodoc, 8)

                    Serie = Serie.PadLeft(4, "0" & Serie)
                    Numero = Numero.PadLeft(8, "0" & Numero)

                ElseIf i.tipoDoc = "56" Then

                    Serie = Strings.Right(seriedoc, 4)
                    Numero = Strings.Right(numerodoc, 11)

                    Serie = Serie.PadLeft(4, "0" & Serie)
                    Numero = Numero.PadLeft(11, "0" & Numero)

                ElseIf i.tipoDoc = "10" Or i.tipoDoc = "22" Or i.tipoDoc = "46" Then

                    Serie = Strings.Right(seriedoc, 4)
                    Numero = Strings.Right(numerodoc, 20)

                    Serie = Serie.PadLeft(4, "0" & Serie)
                    Numero = Numero.PadLeft(20, "0" & Numero)

                ElseIf i.tipoDoc = "11" Then

                    Serie = Strings.Right(seriedoc, 20)
                    Numero = Strings.Right(numerodoc, 15)

                    Serie = Serie.PadLeft(20, "0" & Serie)
                    Numero = Numero.PadLeft(15, "0" & Numero)

                ElseIf i.tipoDoc = "12" Or i.tipoDoc = "12.1" Or i.tipoDoc = "13" Or i.tipoDoc = "14" Or i.tipoDoc = "15" Or i.tipoDoc = "16" Or i.tipoDoc = "17" Or i.tipoDoc = "18" Or i.tipoDoc = "19" Or i.tipoDoc = "21" _
                    Or i.tipoDoc = "24" Or i.tipoDoc = "26" Or i.tipoDoc = "27" Or i.tipoDoc = "28" Or i.tipoDoc = "29" Or i.tipoDoc = "30" Or i.tipoDoc = "32" Or i.tipoDoc = "37" Or i.tipoDoc = "42" Or i.tipoDoc = "43" Or i.tipoDoc = "44" _
                    Or i.tipoDoc = "45" Or i.tipoDoc = "49" Or i.tipoDoc = "87" Or i.tipoDoc = "88" Or i.tipoDoc = "91" Or i.tipoDoc = "96" Or i.tipoDoc = "97" Or i.tipoDoc = "98" Then

                    Serie = Strings.Right(seriedoc, 20)
                    Numero = Strings.Right(numerodoc, 20)

                    Serie = Serie.PadLeft(20, "0" & Serie)
                    Numero = Numero.PadLeft(20, "0" & Numero)

                    'ElseIf i.tipoDoc = "9901" Or i.tipoDoc = "9902" Or i.tipoDoc = "9903" Or i.tipoDoc = "9904" Or i.tipoDoc = "9905" _
                    '       Or i.tipoDoc = "9906" Or i.tipoDoc = "9907" Or i.tipoDoc = "9908" Then
                ElseIf i.tipoDoc = "00" Then


                    Serie = seriedoc
                    Numero = numerodoc

                ElseIf i.tipoDoc = "99" Then  ' solo para setiembre ver si los demas meses ya tiene
                    Serie = "0000"
                    Numero = "000001"
                    TipoDocNuevo = "00"
                End If


                If i.moneda = "1" Then
                    MonedaUso = "PEN"
                ElseIf i.moneda = "2" Then
                    MonedaUso = "USD"
                End If




                If i.idEntidad = 0 Then
                    DocumentoIdentificacion = "0"
                    NumeroDocIdentificacion = "0"
                Else
                    DocumentoIdentificacion = i.docEntidad
                    NumeroDocIdentificacion = i.nrodocEntidad
                End If

                If i.tipo = "D" Then
                    MontoDebe = i.monto
                    MontoHaber = CDec(0.00)
                ElseIf i.tipo = "H" Then
                    MontoDebe = CDec(0.00)
                    MontoHaber = i.monto
                End If


                Dim valorCamp21 As Integer


                'If PeriodoCont = PeriodoInfo Then


                valorCamp21 = 1

                'Else

                '    valorCamp21 = 8

                'End If

                'conteo = conteo + 1
                'If conteo = 13139 Then

                '    Dim err = "si"
                '    Dim IDDOC = i.iddocumento
                'End If






                If i.glosa = "" Then
                    If TipoDocNuevo = "87" Then
                        NuevaGlosa = "POR NOTA DE CREDITO"
                    End If
                Else
                    NuevaGlosa = i.glosa
                End If




                Linea = PeriodoCont & "00" & "|" &
                        i.idAsiento & "|" &
                         "M" & i.idAsiento & "|" &
                         i.cuenta & "|" &
                         "" & "|" &
                         "" & "|" &
                         MonedaUso & "|" &
                         DocumentoIdentificacion & "|" &
                         NumeroDocIdentificacion & "|" &
                         TipoDocNuevo & "|" &
                         Serie & "|" &
                           Numero & "|" &
                         FechaEmision & "|" &
                         "" & "|" &
                         FechaEmision & "|" &
                         NuevaGlosa & "|" &
                         "" & "|" &
                         String.Format("{0:0.00}", MontoDebe) & "|" &
                         String.Format("{0:0.00}", MontoHaber) & "|" &
                          "" & "|" &
                         valorCamp21 & "|"

                archivo.WriteLine(Linea)

            Next
            archivo.Close()
            MsgBox("Se Genero Correctamente el archivo txt." & vbCrLf)

        Catch ex As Exception
            MsgBox("No se pudo generar el archivo txt." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub generadorTXT(strPeriodo As String, Ruta As String)


        Dim NombreDelTXT As String
        Dim compraSA As New DocumentoCompraSA
        Dim tienemodificacion As String = "NO"
        Dim listaObj As New List(Of documentocompra)
        Dim archivo As StreamWriter
        Dim Linea As String = Nothing

        'Dim periodo As String
        'periodo = años & meses & "00"

        Dim FechaNotaCredito As String = ""
        Dim FechaDetraccion As String = ""
        Dim nroConst As String = ""
        Dim MonedaUso As String = ""

        Dim NotaSerie As String = ""
        Dim NotaNumero As String = ""
        Dim TipoDocNota As String = ""
        Dim FechaNota As String = ""
        Dim FechaVct As String = ""
        Dim Serie As String = ""
        Dim Numero As String = ""
        Dim TipoDocNuevo As String = ""
        Dim TipoDocNotaNuevo As String = ""



        Try

            listaObj = compraSA.GenerarTXTcompras(GEstableciento.IdEstablecimiento, strPeriodo)
            If listaObj.Count > 0 Then
                NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "0008010000" & "1" & "1" & "1" & "1" & ".TXT"
            Else
                NombreDelTXT = "LE" & Gempresas.IdEmpresaRuc & Mid(strPeriodo, 4, 4) & Mid(strPeriodo, 1, 2) & "0008010000" & "1" & "1" & "1" & "1" & ".TXT"
            End If

            'archivo = New StreamWriter("c:/Sunat/LE2039265702020170800080100001111.TXT")
            'archivo = New StreamWriter(Ruta & "\" & NombreDelTXT)

            If Strings.Right(Ruta, 1) = "\" Then
                archivo = New StreamWriter(Ruta & NombreDelTXT)
            Else
                archivo = New StreamWriter(Ruta & "\" & NombreDelTXT)
            End If

            For Each i In listaObj
                FechaNotaCredito = ""
                FechaDetraccion = ""
                nroConst = ""
                MonedaUso = ""
                NotaSerie = ""
                NotaNumero = ""
                TipoDocNota = ""
                FechaNota = ""
                FechaVct = ""
                Serie = ""
                Numero = ""


                Dim PeriodoCont As String = Mid(i.fechaContable, 4, 4) & Mid(i.fechaContable, 1, 2)

                Dim PeriodoInfo = i.fechaDoc.Value.Year.ToString & String.Format("{0:00}", i.fechaDoc.Value.Month)

                Dim FechaEmision = String.Format("{0:00}", i.fechaDoc.Value.Day) & "/" & String.Format("{0:00}", i.fechaDoc.Value.Month) & "/" & i.fechaDoc.Value.Year.ToString
                If i.tipoDoc = "14" Then
                    FechaVct = String.Format("{0:00}", i.fechaVcto.Value.Day) & "/" & String.Format("{0:00}", i.fechaVcto.Value.Month) & "/" & i.fechaVcto.Value.Year.ToString

                    'Serie = i.serie
                    'Numero = i.numeroDoc

                ElseIf i.tipoDoc = "12" Then

                    FechaVct = ""
                    'Serie = i.serie
                    'Numero = i.numeroDoc

                    'Else

                    '    FechaVct = ""
                    '    Serie = Strings.Right(i.serie, 4)
                    '    Numero = Strings.Right(i.numeroDoc, 8)

                End If


                If i.tipoDoc = "05" Or i.tipoDoc = "55" Then

                    Serie = Strings.Right(i.serie, 1)
                    Numero = Strings.Right(i.numeroDoc, 11)


                    Serie = Serie.PadLeft(1, "0" & Serie)
                    Numero = Numero.PadLeft(11, "0" & Numero)

                ElseIf i.tipoDoc = "50" Or i.tipoDoc = "51" Or i.tipoDoc = "52" Or i.tipoDoc = "53" Or i.tipoDoc = "54" Then

                    Serie = Strings.Right(i.serie, 3)
                    Numero = Strings.Right(i.numeroDoc, 6)

                    Serie = Serie.PadLeft(3, "0" & Serie)
                    Numero = Numero.PadLeft(6, "0" & Numero)

                ElseIf i.tipoDoc = "54" Then

                    Serie = Strings.Right(i.serie, 3)
                    Numero = Strings.Right(i.numeroDoc, 20)

                    Serie = Serie.PadLeft(3, "0" & Serie)
                    Numero = Numero.PadLeft(20, "0" & Numero)


                ElseIf i.tipoDoc = "02" Or i.tipoDoc = "23" Or i.tipoDoc = "25" Or i.tipoDoc = "34" Or i.tipoDoc = "35" Or i.tipoDoc = "48" Or i.tipoDoc = "89" Then

                    Serie = Strings.Right(i.serie, 4)
                    Numero = Strings.Right(i.numeroDoc, 7)

                    Serie = Serie.PadLeft(4, "0" & Serie)
                    Numero = Numero.PadLeft(7, "0" & Numero)

                ElseIf i.tipoDoc = "36" Or i.tipoDoc = "01" Or i.tipoDoc = "03" Or i.tipoDoc = "04" Or i.tipoDoc = "06" Or i.tipoDoc = "07" Or i.tipoDoc = "08" Then

                    Serie = Strings.Right(i.serie, 4)
                    Numero = Strings.Right(i.numeroDoc, 8)

                    Serie = Serie.PadLeft(4, "0" & Serie)
                    Numero = Numero.PadLeft(8, "0" & Numero)

                ElseIf i.tipoDoc = "56" Then

                    Serie = Strings.Right(i.serie, 4)
                    Numero = Strings.Right(i.numeroDoc, 11)

                    Serie = Serie.PadLeft(4, "0" & Serie)
                    Numero = Numero.PadLeft(11, "0" & Numero)

                ElseIf i.tipoDoc = "10" Or i.tipoDoc = "22" Or i.tipoDoc = "46" Then

                    Serie = Strings.Right(i.serie, 4)
                    Numero = Strings.Right(i.numeroDoc, 20)

                    Serie = Serie.PadLeft(4, "0" & Serie)
                    Numero = Numero.PadLeft(20, "0" & Numero)

                ElseIf i.tipoDoc = "11" Then

                    Serie = Strings.Right(i.serie, 20)
                    Numero = Strings.Right(i.numeroDoc, 15)

                    Serie = Serie.PadLeft(20, "0" & Serie)
                    Numero = Numero.PadLeft(15, "0" & Numero)

                ElseIf i.tipoDoc = "12" Or i.tipoDoc = "13" Or i.tipoDoc = "14" Or i.tipoDoc = "15" Or i.tipoDoc = "16" Or i.tipoDoc = "17" Or i.tipoDoc = "18" Or i.tipoDoc = "19" Or i.tipoDoc = "21" _
                    Or i.tipoDoc = "24" Or i.tipoDoc = "26" Or i.tipoDoc = "27" Or i.tipoDoc = "28" Or i.tipoDoc = "29" Or i.tipoDoc = "30" Or i.tipoDoc = "32" Or i.tipoDoc = "37" Or i.tipoDoc = "42" Or i.tipoDoc = "43" Or i.tipoDoc = "44" _
                    Or i.tipoDoc = "45" Or i.tipoDoc = "49" Or i.tipoDoc = "87" Or i.tipoDoc = "88" Or i.tipoDoc = "91" Or i.tipoDoc = "96" Or i.tipoDoc = "97" Or i.tipoDoc = "98" Then

                    Serie = Strings.Right(i.serie, 20)
                    Numero = Strings.Right(i.numeroDoc, 20)

                    Serie = Serie.PadLeft(20, "0" & Serie)
                    Numero = Numero.PadLeft(20, "0" & Numero)

                End If




                Dim valorCamp41 As Integer

                If tienemodificacion = "SI" Then   'cuando tiene alguna modificacion y ha sido inscrito en periodos anteriores
                    valorCamp41 = 9
                Else
                    If PeriodoCont = PeriodoInfo Then

                        If i.igv01 > 0 Then
                            valorCamp41 = 1
                        Else
                            valorCamp41 = 0
                        End If
                    Else
                        If i.igv01 > 0 Then
                            valorCamp41 = 6
                        Else
                            valorCamp41 = 7
                        End If

                    End If
                End If

                If i.tipoDoc = "07" Or i.tipoDoc = "08" Or i.tipoDoc = "87" Or i.tipoDoc = "88" Or i.tipoDoc = "97" Or i.tipoDoc = "98" Then
                    FechaNotaCredito = FechaEmision


                    'NotaSerie = i.SerieNota
                    'NotaNumero = i.NumeroNota

                    If i.TipoDocNota = "12.1" Then
                        TipoDocNota = "12"
                    Else
                        TipoDocNota = i.TipoDocNota
                    End If


                    FechaNota = String.Format("{0:00}", i.FechaNota.Day) & "/" & String.Format("{0:00}", i.FechaNota.Month) & "/" & i.FechaNota.Year.ToString



                    'documento padre  de la nota credito o debito  

                    If i.TipoDocNota = "05" Or i.TipoDocNota = "55" Then

                        NotaSerie = Strings.Right(i.SerieNota, 1)
                        NotaNumero = Strings.Right(i.NumeroNota, 11)

                        NotaSerie = NotaSerie.PadLeft(1, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(11, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "50" Or i.TipoDocNota = "51" Or i.TipoDocNota = "52" Or i.TipoDocNota = "53" Or i.TipoDocNota = "54" Then

                        NotaSerie = Strings.Right(i.SerieNota, 3)
                        NotaNumero = Strings.Right(i.NumeroNota, 6)

                        NotaSerie = NotaSerie.PadLeft(3, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(6, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "54" Then

                        NotaSerie = Strings.Right(i.SerieNota, 3)
                        NotaNumero = Strings.Right(i.NumeroNota, 20)

                        NotaSerie = NotaSerie.PadLeft(3, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(20, "0" & NotaNumero)


                    ElseIf i.TipoDocNota = "02" Or i.TipoDocNota = "23" Or i.TipoDocNota = "25" Or i.TipoDocNota = "34" Or i.TipoDocNota = "35" Or i.TipoDocNota = "48" Or i.TipoDocNota = "89" Then

                        NotaSerie = Strings.Right(i.SerieNota, 4)
                        NotaNumero = Strings.Right(i.NumeroNota, 7)

                        NotaSerie = NotaSerie.PadLeft(4, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(7, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "36" Or i.TipoDocNota = "01" Or i.TipoDocNota = "03" Or i.TipoDocNota = "04" Or i.TipoDocNota = "06" Or i.TipoDocNota = "07" Or i.TipoDocNota = "08" Then

                        NotaSerie = Strings.Right(i.SerieNota, 4)
                        NotaNumero = Strings.Right(i.NumeroNota, 8)

                        NotaSerie = NotaSerie.PadLeft(4, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(8, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "56" Then

                        NotaSerie = Strings.Right(i.SerieNota, 4)
                        NotaNumero = Strings.Right(i.NumeroNota, 11)

                        NotaSerie = NotaSerie.PadLeft(4, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(11, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "10" Or i.TipoDocNota = "22" Or i.TipoDocNota = "46" Then

                        NotaSerie = Strings.Right(i.SerieNota, 4)
                        NotaNumero = Strings.Right(i.NumeroNota, 20)

                        NotaSerie = NotaSerie.PadLeft(4, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(20, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "11" Then

                        NotaSerie = Strings.Right(i.SerieNota, 20)
                        NotaNumero = Strings.Right(i.NumeroNota, 15)

                        NotaSerie = NotaSerie.PadLeft(20, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(15, "0" & NotaNumero)

                    ElseIf i.TipoDocNota = "12" Or i.TipoDocNota = "13" Or i.TipoDocNota = "14" Or i.TipoDocNota = "15" Or i.TipoDocNota = "16" Or i.TipoDocNota = "17" Or i.TipoDocNota = "18" Or i.TipoDocNota = "19" Or i.TipoDocNota = "21" _
                        Or i.TipoDocNota = "24" Or i.TipoDocNota = "26" Or i.TipoDocNota = "27" Or i.TipoDocNota = "28" Or i.TipoDocNota = "29" Or i.TipoDocNota = "30" Or i.TipoDocNota = "32" Or i.TipoDocNota = "37" Or i.TipoDocNota = "42" Or i.TipoDocNota = "43" Or i.TipoDocNota = "44" _
                        Or i.TipoDocNota = "45" Or i.TipoDocNota = "49" Or i.TipoDocNota = "87" Or i.TipoDocNota = "88" Or i.TipoDocNota = "91" Or i.TipoDocNota = "96" Or i.TipoDocNota = "97" Or i.TipoDocNota = "98" Then

                        NotaSerie = Strings.Right(i.SerieNota, 20)
                        NotaNumero = Strings.Right(i.NumeroNota, 20)

                        NotaSerie = NotaSerie.PadLeft(20, "0" & NotaSerie)
                        NotaNumero = NotaNumero.PadLeft(20, "0" & NotaNumero)

                    End If

                    ''///////////////////////////////


                Else
                    FechaNotaCredito = ""
                    NotaSerie = ""
                    NotaNumero = ""
                    TipoDocNota = ""
                    FechaNota = ""
                End If


                If i.tieneDetraccion = "S" Then

                    FechaDetraccion = String.Format("{0:00}", i.fechaConstancia.Value.Day) & "/" & String.Format("{0:00}", i.fechaConstancia.Value.Month) & "/" & i.fechaConstancia.Value.Year.ToString
                    nroConst = i.nroConstancia
                Else
                    FechaDetraccion = ""
                    nroConst = ""
                End If


                If i.monedaDoc = "1" Then
                    MonedaUso = "PEN"
                ElseIf i.monedaDoc = "2" Then
                    MonedaUso = "USD"
                End If

                If i.tipoDoc = "12.1" Then
                    TipoDocNuevo = "12"
                Else
                    TipoDocNuevo = i.tipoDoc
                End If




                Linea = PeriodoCont & "00" & "|" & _
                        i.idDocumento & "|" & _
                         "M" & i.idDocumento & "|" & _
                         FechaEmision & "|" & _
                         FechaVct & "|" & _
                         i.tipoDoc & "|" & _
                           Serie & "|" & _
                          "" & "|" & _
                           Numero & "|" & _
                          "" & "|" & _
                          i.tipoDocEntidad & "|" & _
                          i.NroDocEntidad & "|" & _
                          (i.NombreEntidad).Replace(",", "") & "|" & _
                          String.Format("{0:0.00}", i.bi01) & "|" & _
                          String.Format("{0:0.00}", i.igv01) & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                         String.Format("{0:0.00}", i.bi02) & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          String.Format("{0:0.00}", i.importeTotal) & "|" & _
                          MonedaUso & "|" & _
                         String.Format("{0:0.000}", i.tcDolLoc) & "|" & _
                          FechaNotaCredito & "|" & _
                          TipoDocNota & "|" & _
                          NotaSerie & "|" & _
                          "" & "|" & _
                          NotaNumero & "|" & _
                          FechaDetraccion & "|" & _
                          nroConst & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                          "" & "|" & _
                         valorCamp41 & "|" & _
                         "" & "|"

                archivo.WriteLine(Linea)

            Next
            archivo.Close()
            MsgBox("Se Genero Correctamente el archivo txt." & vbCrLf)

        Catch ex As Exception
            MsgBox("No se pudo generar el archivo txt." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Meses()
        Dim empresaAnioSA As New empresaPeriodoSA
        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

#End Region


    Private Sub frmFormatosPlevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor



        Dim Direccion As String


        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Direccion = FolderBrowserDialog1.SelectedPath


            Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
            periodo = periodo & "/" & CInt(cboAnio.Text)
            generadorTXT(periodo, Direccion)

        End If


        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Cursor = Cursors.WaitCursor



        Dim Direccion As String


        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Direccion = FolderBrowserDialog1.SelectedPath


            Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
            periodo = periodo & "/" & CInt(cboAnio.Text)
            generadorTXTNoDomiciliado(periodo, Direccion)


        End If


        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        Dim Direccion As String


        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Direccion = FolderBrowserDialog1.SelectedPath


            Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
            periodo = periodo & "/" & CInt(cboAnio.Text)
            generadorVentaTXT(periodo, Direccion)


        End If




        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Cursor = Cursors.WaitCursor



        Dim Direccion As String


        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Direccion = FolderBrowserDialog1.SelectedPath

            Dim EnvPeriodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
            Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
            periodo = periodo & "/" & CInt(cboAnio.Text)
            EstructuraLibro(periodo, Direccion, EnvPeriodo, CInt(cboAnio.Text))

        End If


        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor



        Dim Direccion As String


        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Direccion = FolderBrowserDialog1.SelectedPath


            Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
            periodo = periodo & "/" & CInt(cboAnio.Text)
            LibroDiarioTXT(periodo, Direccion, cboAnio.Text, cboMesCompra.SelectedValue)

        End If


        Cursor = Cursors.Default
    End Sub
End Class