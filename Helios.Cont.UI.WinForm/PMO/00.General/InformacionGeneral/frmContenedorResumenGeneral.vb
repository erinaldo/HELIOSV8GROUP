Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class frmContenedorResumenGeneral

#Region "Fields"
    Private tabListaVentaXDoc As tabListaVentaXDoc
    Private tabLIstaVentaXItemvb As tabLIstaVentaXItemvb
    Private tabListaCuentasXCobrarDoc As tabListaCuentasXCobrarDoc
    Private tabLIstaCuentaXCobrarItem As tabLIstaCuentaXCobrarItem
    Private tabListaOtrosIngresos As tabListaOtrosIngresos
    Private tabListaOtrasSalidas As tabListaOtrasSalidas
    Private tabListaOtrosXDoc As tabListaOtrosXDoc
    Private tabLIstaOtrosXItem As tabLIstaOtrosXItem
    Private tabListaVentaElectronicasXDoc As tabListaVentaElectronicasXDoc
    Private tabLIstaVentaElectronicasXItemvb As tabLIstaVentaElectronicasXItemvb
    Public Property listaUsuario As List(Of Integer)
    Public Property tipoConsulta As String
    Public Property FechaLaboral As Date
    Public Property idEntidad As Integer
    Public listIDCajas As List(Of Integer)

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region

#Region "Methdos"


    Sub llamarVentasXDocumentoVentas(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabListaVentaXDoc = New tabListaVentaXDoc(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabListaVentaXDoc.BringToFront()
        PanelBody.Controls.Add(tabListaVentaXDoc)
    End Sub

    Sub llamarVentasXDocumento(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabListaVentaXDoc = New tabListaVentaXDoc(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabListaVentaXDoc.BringToFront()
        PanelBody.Controls.Add(tabListaVentaXDoc)
    End Sub

    Sub llamarVentasElectronicasXDocumento(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabListaVentaElectronicasXDoc = New tabListaVentaElectronicasXDoc(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabListaVentaElectronicasXDoc.BringToFront()
        PanelBody.Controls.Add(tabListaVentaElectronicasXDoc)
    End Sub

    Sub llamarVentasElectronicasXItem(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabLIstaVentaElectronicasXItemvb = New tabLIstaVentaElectronicasXItemvb(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabLIstaVentaElectronicasXItemvb.BringToFront()
        PanelBody.Controls.Add(tabLIstaVentaElectronicasXItemvb)
    End Sub

    Sub llamarVentasXItem(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabLIstaVentaXItemvb = New tabLIstaVentaXItemvb(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabLIstaVentaXItemvb.BringToFront()
        PanelBody.Controls.Add(tabLIstaVentaXItemvb)
    End Sub

    Sub llamarCuentasXDocumento(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabListaCuentasXCobrarDoc = New tabListaCuentasXCobrarDoc(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabListaCuentasXCobrarDoc.BringToFront()
        PanelBody.Controls.Add(tabListaCuentasXCobrarDoc)
    End Sub

    Sub llamarCuentasXItem(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabLIstaCuentaXCobrarItem = New tabLIstaCuentaXCobrarItem(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabLIstaCuentaXCobrarItem.BringToFront()
        PanelBody.Controls.Add(tabLIstaCuentaXCobrarItem)
    End Sub

    Sub llamarOtrasEntradasXDoc(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabListaOtrosIngresos = New tabListaOtrosIngresos(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabListaOtrosIngresos.BringToFront()
        PanelBody.Controls.Add(tabListaOtrosIngresos)
    End Sub

    Sub llamarOtrasSalidasXDoc(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabListaOtrasSalidas = New tabListaOtrasSalidas(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabListaOtrasSalidas.BringToFront()
        PanelBody.Controls.Add(tabListaOtrasSalidas)
    End Sub

    Sub llamarOtrosXDoc(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabListaOtrosXDoc = New tabListaOtrosXDoc(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabListaOtrosXDoc.BringToFront()
        PanelBody.Controls.Add(tabListaOtrosXDoc)
    End Sub

    Sub llamarotrosXItem(listaUsuario As List(Of Integer))
        PanelBody.Controls.Clear()
        tabLIstaOtrosXItem = New tabLIstaOtrosXItem(listaUsuario, listIDCajas, FechaLaboral) With {
            .Dock = DockStyle.Fill
        }
        tabLIstaOtrosXItem.BringToFront()
        PanelBody.Controls.Add(tabLIstaOtrosXItem)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Select Case tipoConsulta
            Case "CUENTAS"
                llamarCuentasXDocumento(listaUsuario)
            Case "VENTAS"
                llamarVentasXDocumento(listaUsuario)
            Case "ELECTRONICAS"
                llamarVentasElectronicasXDocumento(listaUsuario)
            Case "OEC"
                llamarOtrasEntradasXDoc(listaUsuario)
            Case "OSC"
                llamarOtrasSalidasXDoc(listaUsuario)
            Case "OTROS"
                llamarOtrosXDoc(listaUsuario)
        End Select
    End Sub

    Private Sub ToolStripDropDownButton3_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton3.Click
        Select Case tipoConsulta
            Case "CUENTAS"
                llamarCuentasXItem(listaUsuario)
            Case "VENTAS"
                llamarVentasXItem(listaUsuario)
            Case "OTROS"
                llamarotrosXItem(listaUsuario)
            Case "ELECTRONICAS"
                llamarVentasElectronicasXItem(listaUsuario)
        End Select
    End Sub

#End Region

#Region "Events"

    'Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
    '    periodo = periodo & "/" & cboAnio.Text
    '    PanelBody.Controls.Clear()
    '    TabRegistroVenta = New TabCM_RegistroVentas(periodo, cboAnio.Text, String.Format("{0:00}", cboMesPedido.SelectedValue)) With {
    '        .Dock = DockStyle.Fill
    '    }
    '    TabRegistroVenta.BringToFront()
    '    PanelBody.Controls.Add(TabRegistroVenta)


#End Region

End Class