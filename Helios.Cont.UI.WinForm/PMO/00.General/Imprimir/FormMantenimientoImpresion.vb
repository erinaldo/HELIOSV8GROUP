Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FormMantenimientoImpresion

    Private TabMG_Servicios As TabMG_Servicios


    Private Sub btListaServicio_Click(sender As Object, e As EventArgs)
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.LISTA_PRODUCTO_Formulario___, AutorizacionRolList) Then
            PanelBody.Controls.Clear()
            TabMG_Servicios = New TabMG_Servicios With {
                .Dock = DockStyle.Fill
            }
            TabMG_Servicios.BringToFront()
            PanelBody.Controls.Add(TabMG_Servicios)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class