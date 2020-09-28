Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class frmNuevoitemTabladetalle
    Inherits frmMaster

#Region "Fields"
    Property ManipulacionData As String
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ManipulacionData = ENTITY_ACTIONS.INSERT
        Loadcombos()
    End Sub

    Public Sub New(idtabla As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ManipulacionData = ENTITY_ACTIONS.INSERT
        Loadcombos()
        cboCuentaPadre.SelectedValue = idtabla
    End Sub

    Public Sub New(id As Integer, codigo1 As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ManipulacionData = ENTITY_ACTIONS.UPDATE
        Loadcombos()
        UbicarItem(id, codigo1)
    End Sub
#End Region

#Region "Métodos"
    Private Sub MaxCodigotabla(idtabla As Integer)
        Dim tablaSA As New tablaDetalleSA
        Dim codigoMax = tablaSA.ObtenerMaxTabla(New tabladetalle With {.idtabla = idtabla})
        txtCodigo1.Text = codigoMax + 1
    End Sub

    Private Sub UbicarItem(idTabla As Integer, codigo1 As String)
        Dim tablaSA As New tablaDetalleSA

        Dim tabla = tablaSA.GetUbicarTablaID(idTabla, codigo1)
        With tabla
            cboCuentaPadre.SelectedValue = .idtabla
            txtCodigo1.Text = .codigoDetalle
            txtCodigo2.Text = .codigoDetalle2
            txtDescripcion.Text = .descripcion
        End With

    End Sub

    Sub Loadcombos()
        Dim tablasa As New TablaSA
        Dim tables() As String = {"1", "2", "6", "10", "14"}
        cboCuentaPadre.DisplayMember = "descripcion"
        cboCuentaPadre.ValueMember = "idtabla"
        cboCuentaPadre.DataSource = tablasa.GetListaTabla.Where(Function(o) tables.Contains(o.idtabla)).ToList
    End Sub

    Private Sub Editar()
        Dim tabla As New tabladetalle
        Dim tablaSA As New tablaDetalleSA

        tabla = New tabladetalle With
                {
                .Action = BaseBE.EntityAction.UPDATE,
                .idtabla = cboCuentaPadre.SelectedValue,
                 .codigoDetalle = txtCodigo1.Text.Trim,
                 .codigoDetalle2 = txtCodigo2.Text.Trim,
                 .descripcion = txtDescripcion.Text.Trim,
                 .estadodetalle = "1",
                 .usuarioModificacion = usuario.IDUsuario,
                 .fechaModificacion = DateTime.Now
                }

        tablaSA.UpdateTablaDetalle(tabla)
        Close()
    End Sub

    Private Sub Grabar()
        Dim tabla As New tabladetalle
        Dim tablaSA As New tablaDetalleSA

        tabla = New tabladetalle With
                {
                .Action = BaseBE.EntityAction.INSERT,
                .idtabla = cboCuentaPadre.SelectedValue,
                 .codigoDetalle = txtCodigo1.Text.Trim,
                 .codigoDetalle2 = txtCodigo2.Text.Trim,
                 .descripcion = txtDescripcion.Text.Trim,
                 .estadodetalle = "1",
                 .usuarioModificacion = usuario.IDUsuario,
                 .fechaModificacion = DateTime.Now
                }

        tablaSA.InsertarTablaDetalle(tabla)
        Close()
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Close()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If txtCodigo1.Text.Trim.Length = 0 Then
            MsgBox("El codigo1 es requerido!", MsgBoxStyle.Exclamation, "Validar campo")
            txtCodigo1.Select()
            Exit Sub
        End If

        If txtCodigo2.Text.Trim.Length = 0 Then
            MsgBox("El codigo2 es requerido!", MsgBoxStyle.Exclamation, "Validar campo")
            txtCodigo2.Select()
            Exit Sub
        End If

        If txtDescripcion.Text.Trim.Length = 0 Then
            MsgBox("El campo descripción es requerido!", MsgBoxStyle.Exclamation, "Validar campo")
            txtDescripcion.Select()
            Exit Sub
        End If
        If ManipulacionData = ENTITY_ACTIONS.INSERT Then
            Grabar()
        Else
            Editar()
        End If

    End Sub

    Private Sub cboCuentaPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCuentaPadre.SelectedIndexChanged
        Dim codigo As Object
        Try
            codigo = cboCuentaPadre.SelectedValue
            If IsNumeric(codigo) Then
                'MaxCodigotabla(codigo)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

End Class