Public Class FormCierreXUsuario

#Region "Attributes"
    Public UCResumenVentas As UCResumenVentas

#End Region

#Region "Constructor"


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Dim codigo = LogeoUsuarioCaja()

        UCResumenVentas = New UCResumenVentas(codigo, Me) 'With {.Dock = DockStyle.Fill, .Visible = True}

        UCResumenVentas.Dock = DockStyle.Fill

        PanelBody.Controls.Add(UCResumenVentas)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Metodos"

    Public Sub CerrarFormulario()

        Close()
        Me.Dispose()
    End Sub


    Function LogeoUsuarioCaja()
        Dim usuarioSel = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).FirstOrDefault
        If usuarioSel IsNot Nothing Then

            Return usuarioSel.codigo

        Else
            Return 0
        End If

    End Function


#End Region


End Class