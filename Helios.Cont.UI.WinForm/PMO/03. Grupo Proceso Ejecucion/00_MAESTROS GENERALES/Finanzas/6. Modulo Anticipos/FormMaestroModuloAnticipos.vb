Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormMaestroModuloAnticipos

#Region "Variables"
    Public Property AnticipoSA As New documentoAnticipoSA
    Public Property TabFN_AnticiposEscaneados As TabFN_AnticiposEscaneados
    Public Property TabFN_AnticiposPeriodo As TabFN_AnticiposPeriodo
    Public Property TabFN_AnticiposPendiente As TabFN_AnticiposPendiente
    Public Property TabFN_Reclamaciones As TabFN_Reclamaciones
    Public Property TabFN_AnticipoReclamacionStatus As TabFN_AnticipoReclamacionStatus
    Public Property TabFN_DevolucionNotaCreditoAnt As TabFN_DevolucionNotaCreditoAnt
    Public Property TabFN_DevolucionNotaSeguimiento As TabFN_DevolucionNotaSeguimiento
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetStatus()
        GetStatusNotasCreditoREM()
    End Sub
#End Region

#Region "Methods"
    Public Sub GetStatus()
        Dim compraSA As New documentoAnticipoSA
        Dim statusList = AnticipoSA.GetStatusAprobacionAnticipos(
            New Business.Entity.documentoAnticipo With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .tipoAnticipo = Anticipo.Tipo.Recibido
            })

        Dim conteoPendientes = statusList.Where(Function(o) o.estado = Anticipo.Estado.Emitido).Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteoDevolucion = statusList.Where(Function(o) o.estado = Anticipo.Estado.DevolucionDeDinero).Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteoRechazados = statusList.Where(Function(o) o.estado = Anticipo.Estado.Rechazado).Select(Function(o) o.conteoCuotas).FirstOrDefault


        ToolPendientes.Text = conteoPendientes
        'ToolDevolucion.Text = conteoDevolucion
        ToolRechazados.Text = conteoRechazados


        Dim statusSolictudDevololucion = AnticipoSA.GetANTReclamacionesStatusCount(New Business.Entity.documentoventaAbarrotes With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .tipoVenta = TIPO_VENTA.VENTA_NOTA_CREDITO_ANTICIPO,
            .estadoCobro = Anticipo.EstadoCobroNotaCredito.SolicitudDevolucion
            })

        ToolRecientes.Text = statusSolictudDevololucion
    End Sub

    Public Sub GetStatusNotasCreditoREM()
        Dim compraSA As New documentoAnticipoSA
        Dim statusList = AnticipoSA.GetStatusNotaCreditoCount(
            New Business.Entity.documentoventaAbarrotes With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .tipoVenta = TIPO_VENTA.VENTA_NOTA_CREDITO_ANTICIPO,
            .fechaDoc = Date.Now
            })

        Dim conteoPendientes = statusList.Where(Function(o) o.estado = Anticipo.EstadoCobroNotaCredito.Pendiente).Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteoParcial = statusList.Where(Function(o) o.estado = Anticipo.EstadoCobroNotaCredito.Parcial).Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteoCompletos = statusList.Where(Function(o) o.estado = Anticipo.EstadoCobroNotaCredito.Completado).Select(Function(o) o.conteoCuotas).FirstOrDefault


        ToolSinEjecucion.Text = conteoPendientes
        ToolParcial.Text = conteoParcial
        ToolCompletado.Text = conteoCompletos
    End Sub
#End Region

#Region "Events"
    Private Sub Tool30_Click(sender As Object, e As EventArgs) Handles Tool30.Click
        Try
            PanelBody.Controls.Clear()
            TabFN_AnticiposEscaneados = New TabFN_AnticiposEscaneados(Me, "30") With {
                            .Dock = DockStyle.Fill
            }
            TabFN_AnticiposEscaneados.BringToFront()
            PanelBody.Controls.Add(TabFN_AnticiposEscaneados)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Tool60_Click(sender As Object, e As EventArgs) Handles Tool60.Click
        PanelBody.Controls.Clear()
        TabFN_AnticiposEscaneados = New TabFN_AnticiposEscaneados(Me, "60") With {
            .Dock = DockStyle.Fill
        }
        TabFN_AnticiposEscaneados.BringToFront()
        PanelBody.Controls.Add(TabFN_AnticiposEscaneados)
    End Sub

    Private Sub Tool61_Click(sender As Object, e As EventArgs) Handles Tool61.Click
        PanelBody.Controls.Clear()
        TabFN_AnticiposEscaneados = New TabFN_AnticiposEscaneados(Me, "61") With {
            .Dock = DockStyle.Fill
        }
        TabFN_AnticiposEscaneados.BringToFront()
        PanelBody.Controls.Add(TabFN_AnticiposEscaneados)
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        Try
            PanelBody.Controls.Clear()
            TabFN_AnticiposPeriodo = New TabFN_AnticiposPeriodo() With {
                            .Dock = DockStyle.Fill
            }
            TabFN_AnticiposPeriodo.BringToFront()
            PanelBody.Controls.Add(TabFN_AnticiposPeriodo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolPendientes_Click(sender As Object, e As EventArgs) Handles ToolPendientes.Click
        PanelBody.Controls.Clear()
        TabFN_AnticiposPendiente = New TabFN_AnticiposPendiente(Me, Estado.Emitido) With {
                  .Dock = DockStyle.Fill
              }
        TabFN_AnticiposPendiente.BringToFront()
        PanelBody.Controls.Add(TabFN_AnticiposPendiente)
    End Sub

    Private Sub ToolDevolucion_Click(sender As Object, e As EventArgs)
        PanelBody.Controls.Clear()
        TabFN_AnticiposPendiente = New TabFN_AnticiposPendiente(Me, Estado.DevolucionDeDinero) With {
                  .Dock = DockStyle.Fill
              }
        TabFN_AnticiposPendiente.BringToFront()
        PanelBody.Controls.Add(TabFN_AnticiposPendiente)
    End Sub

    Private Sub ToolRechazados_Click(sender As Object, e As EventArgs) Handles ToolRechazados.Click
        PanelBody.Controls.Clear()
        TabFN_AnticiposPendiente = New TabFN_AnticiposPendiente(Me, Estado.Rechazado) With {
                  .Dock = DockStyle.Fill
              }
        TabFN_AnticiposPendiente.BringToFront()
        PanelBody.Controls.Add(TabFN_AnticiposPendiente)
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        'PanelBody.Controls.Clear()
        'TabFN_Reclamaciones = New TabFN_Reclamaciones() With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_Reclamaciones.BringToFront()
        'PanelBody.Controls.Add(TabFN_Reclamaciones)

        PanelBody.Controls.Clear()
        'TabFN_Reclamaciones = New TabFN_Reclamaciones(Anticipo.Estado.NotaCredito, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_Reclamaciones.BringToFront()
        PanelBody.Controls.Add(TabFN_Reclamaciones)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        PanelBody.Controls.Clear()
        'TabFN_AnticipoReclamacionStatus = New TabFN_AnticipoReclamacionStatus(Anticipo.EstadoCobroNotaCredito.Pendiente, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_AnticipoReclamacionStatus.BringToFront()
        PanelBody.Controls.Add(TabFN_AnticipoReclamacionStatus)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        PanelBody.Controls.Clear()
        'TabFN_AnticipoReclamacionStatus = New TabFN_AnticipoReclamacionStatus(Anticipo.EstadoCobroNotaCredito.Parcial, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_AnticipoReclamacionStatus.BringToFront()
        PanelBody.Controls.Add(TabFN_AnticipoReclamacionStatus)
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        PanelBody.Controls.Clear()
        'TabFN_AnticipoReclamacionStatus = New TabFN_AnticipoReclamacionStatus(Anticipo.EstadoCobroNotaCredito.Completado, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_AnticipoReclamacionStatus.BringToFront()
        PanelBody.Controls.Add(TabFN_AnticipoReclamacionStatus)
    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        PanelBody.Controls.Clear()
        'TabFN_Reclamaciones = New TabFN_Reclamaciones(Anticipo.Estado.Compensado, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_Reclamaciones.BringToFront()
        PanelBody.Controls.Add(TabFN_Reclamaciones)
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        PanelBody.Controls.Clear()
        'TabFN_Reclamaciones = New TabFN_Reclamaciones(Anticipo.Estado.NotaCreditoParcial, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_Reclamaciones.BringToFront()
        PanelBody.Controls.Add(TabFN_Reclamaciones)
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton21.Click

    End Sub

    Private Sub ToolRecientes_Click(sender As Object, e As EventArgs) Handles ToolRecientes.Click
        PanelBody.Controls.Clear()
        'TabFN_DevolucionNotaCreditoAnt = New TabFN_DevolucionNotaCreditoAnt(Anticipo.EstadoCobroNotaCredito.SolicitudDevolucion, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_DevolucionNotaCreditoAnt.BringToFront()
        PanelBody.Controls.Add(TabFN_DevolucionNotaCreditoAnt)
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        PanelBody.Controls.Clear()
        'TabFN_DevolucionNotaSeguimiento = New TabFN_DevolucionNotaSeguimiento(Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_DevolucionNotaSeguimiento.BringToFront()
        'PanelBody.Controls.Add(TabFN_DevolucionNotaSeguimiento)
    End Sub

    Private Sub ToolStripButton18_Click(sender As Object, e As EventArgs) Handles ToolStripButton18.Click
        PanelBody.Controls.Clear()
        'TabFN_DevolucionNotaSeguimiento = New TabFN_DevolucionNotaSeguimiento(Anticipo.EstadoCobroNotaCredito.DevolucionTramiteParcial, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_DevolucionNotaSeguimiento.BringToFront()
        'PanelBody.Controls.Add(TabFN_DevolucionNotaSeguimiento)
    End Sub

    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs) Handles ToolStripButton19.Click
        PanelBody.Controls.Clear()
        'TabFN_DevolucionNotaSeguimiento = New TabFN_DevolucionNotaSeguimiento(Anticipo.EstadoCobroNotaCredito.DevolucionTramiteCompleto, Me) With {
        '         .Dock = DockStyle.Fill
        '     }
        'TabFN_DevolucionNotaSeguimiento.BringToFront()
        'PanelBody.Controls.Add(TabFN_DevolucionNotaSeguimiento)
    End Sub

    Private Sub ToolSinEjecucion_Click(sender As Object, e As EventArgs) Handles ToolSinEjecucion.Click
        ToolStripButton4.PerformClick()
    End Sub

    Private Sub ToolParcial_Click(sender As Object, e As EventArgs) Handles ToolParcial.Click
        ToolStripButton5.PerformClick()
    End Sub

    Private Sub ToolCompletado_Click(sender As Object, e As EventArgs) Handles ToolCompletado.Click
        ToolStripButton9.PerformClick()
    End Sub
#End Region

End Class