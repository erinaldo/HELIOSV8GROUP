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
Public Class frmCronogramaMensual
    Inherits frmMaster

#Region "Metodos"


    Public Sub UbicarPagosProgramadosMensual()

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim enero As Decimal = CDec(0.0)
        Dim febrero As Decimal = CDec(0.0)
        Dim marzo As Decimal = CDec(0.0)
        Dim abril As Decimal = CDec(0.0)
        Dim mayo As Decimal = CDec(0.0)
        Dim junio As Decimal = CDec(0.0)
        Dim julio As Decimal = CDec(0.0)
        Dim agosto As Decimal = CDec(0.0)
        Dim setiembre As Decimal = CDec(0.0)
        Dim octubre As Decimal = CDec(0.0)
        Dim noviembre As Decimal = CDec(0.0)
        Dim diciembre As Decimal = CDec(0.0)


        dt.Columns.Add("enero", GetType(Decimal))
        dt.Columns.Add("febrero", GetType(Decimal))
        dt.Columns.Add("marzo", GetType(Decimal))
        dt.Columns.Add("abril", GetType(Decimal))
        dt.Columns.Add("mayo", GetType(Decimal))
        dt.Columns.Add("junio", GetType(Decimal))
        dt.Columns.Add("julio", GetType(Decimal))
        dt.Columns.Add("agosto", GetType(Decimal))
        dt.Columns.Add("setiembre", GetType(Decimal))
        dt.Columns.Add("octubre", GetType(Decimal))
        dt.Columns.Add("noviembre", GetType(Decimal))
        dt.Columns.Add("diciembre", GetType(Decimal))


        documentoLibro = documentoVentaSA.GetListarPagosPorMes("P")

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro


                Select Case i.fechaContable
                    Case "01/" & AnioGeneral
                        enero = i.montoAutorizadoMN
                    Case "02/" & AnioGeneral
                        febrero = i.montoAutorizadoMN
                    Case "03/" & AnioGeneral
                        marzo = i.montoAutorizadoMN
                    Case "04/" & AnioGeneral
                        abril = i.montoAutorizadoMN
                    Case "05/" & AnioGeneral
                        mayo = i.montoAutorizadoMN
                    Case "06/" & AnioGeneral
                        junio = i.montoAutorizadoMN
                    Case "07/" & AnioGeneral
                        julio = i.montoAutorizadoMN
                    Case "08/" & AnioGeneral
                        agosto = i.montoAutorizadoMN
                    Case "09/" & AnioGeneral
                        setiembre = i.montoAutorizadoMN
                    Case "10/" & AnioGeneral
                        octubre = i.montoAutorizadoMN
                    Case "11/" & AnioGeneral
                        noviembre = i.montoAutorizadoMN
                    Case "12/" & AnioGeneral
                        diciembre = i.montoAutorizadoMN
                End Select
            Next

            Dim dr As DataRow = dt.NewRow()
            dr(0) = enero
            dr(1) = febrero
            dr(2) = marzo
            dr(3) = abril
            dr(4) = mayo
            dr(5) = junio
            dr(6) = julio
            dr(7) = agosto
            dr(8) = setiembre
            dr(9) = octubre
            dr(10) = noviembre
            dr(11) = diciembre
            dt.Rows.Add(dr)
            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            dgvObligaciones.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvObligaciones.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If

    End Sub


#End Region

    Private Sub frmCronogramaMensual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UbicarPagosProgramadosMensual()
    End Sub
End Class