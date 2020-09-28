Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class UCBusqueUnidadNegocio
#Region "ATTRIBUTES"
    Public Event OKEvent()
    'Public Property FormFGActividad As FormFGActividad
    Public Property UCOrganica_Especifica As UCOrganica_Especifica
    Public Property UCUnidOrganica_Jerarq As UCUnidOrganica_Jerarq
    'Public Property FormInicioTupa As FormInicioTupa

    'Public Property UCOtrosTramites As UCOtrosTramites

    Dim FORMUL As String
#End Region
#Region "CONSTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgUnidaNegocio, True, False)
    End Sub

    'Public Sub New(VARIAFGActividad As FormFGActividad)

    '    ' Esta llamada es exigida por el diseñador.
    '    InitializeComponent()
    '    FormFGActividad = VARIAFGActividad
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    FORMUL = "UNOACTIV"
    '    btnOK.Visible = True
    'End Sub

    Public Sub New(VARUCOrganica_Especifica As UCOrganica_Especifica)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        UCOrganica_Especifica = VARUCOrganica_Especifica
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FORMUL = "UNORGAESP"
        btnOK.Visible = True
    End Sub

    Public Sub New(VARUCUnidOrganica_Jerarq As UCUnidOrganica_Jerarq)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        UCUnidOrganica_Jerarq = VARUCUnidOrganica_Jerarq
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FORMUL = "UNORG_JERARQ"
        btnOK.Visible = True
    End Sub


    'Public Sub New(varFormInicioTupa As FormInicioTupa)

    '    ' Esta llamada es exigida por el diseñador.
    '    InitializeComponent()
    '    FormInicioTupa = varFormInicioTupa
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    FORMUL = "FormInicioTupa"
    '    btnOK.Visible = True
    'End Sub


    'Public Sub New(varUCOtrosTramites As UCOtrosTramites)

    '    ' Esta llamada es exigida por el diseñador.
    '    InitializeComponent()
    '    UCOtrosTramites = varUCOtrosTramites
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    FORMUL = "UCOtrosTramites"
    '    btnOK.Visible = True
    'End Sub
#End Region


#Region "METHOD"

#End Region

    Private Sub dgRegisActividad_TableControlCurrentCellKeyDown(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlKeyEventArgs) Handles dgUnidaNegocio.TableControlCurrentCellKeyDown
        Try
            If e.Inner.KeyCode = Keys.Enter Then
                Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
                Dim cc As GridCurrentCell = dgUnidaNegocio.TableControl.CurrentCell
                cc.ConfirmChanges()
                'If cc.Renderer IsNot Nothing Then

                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)
                    If FORMUL = "UNOACTIV" Then
                        Dim recor = dgUnidaNegocio.Table.CurrentRecord
                        Dim IdOrganigramaBE = dgUnidaNegocio.Table.CurrentRecord.GetValue("idOrganigrama")
                        Dim Descripcion = dgUnidaNegocio.Table.CurrentRecord.GetValue("descripcion")

                        'FormFGActividad.txtBusqUniOrganica.Text = Descripcion
                        'FormFGActividad.txtIdUORG.Text = IdOrganigramaBE


                    ElseIf FORMUL = "UNORGAESP" Then
                        Dim recor = dgUnidaNegocio.Table.CurrentRecord
                        Dim IdOrganigramaBE = dgUnidaNegocio.Table.CurrentRecord.GetValue("idOrganigrama")
                        Dim Descripcion = dgUnidaNegocio.Table.CurrentRecord.GetValue("descripcion")


                        UCOrganica_Especifica.txtBusqUniOrgaEspeci.Text = Descripcion
                        UCOrganica_Especifica.txtIdUO.Text = IdOrganigramaBE

                        If UCOrganica_Especifica.txtBusqUniOrgaEspeci.Text.Trim.Length > 0 Then
                            Dim t = UCOrganica_Especifica.txtIdUO.Text

                            UCOrganica_Especifica.PictureBox2.Visible = True
                            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() UCOrganica_Especifica.MOSTRARUNOESP(t)))
                            UCOrganica_Especifica.PictureBox2.Visible = False
                            UCOrganica_Especifica.DGUniOrEspecifica.Table.Records.DeleteAll()
                            thread.Start()
                        End If

                    ElseIf FORMUL = "UNORG_JERARQ" Then
                        Dim recor = dgUnidaNegocio.Table.CurrentRecord
                        Dim IdOrganigramaBE = dgUnidaNegocio.Table.CurrentRecord.GetValue("idOrganigrama")
                        Dim Descripcion = dgUnidaNegocio.Table.CurrentRecord.GetValue("descripcion")


                        UCUnidOrganica_Jerarq.txtBusqUniOrgaJerar.Text = Descripcion
                        UCUnidOrganica_Jerarq.txtIdUOJe.Text = IdOrganigramaBE

                        If UCUnidOrganica_Jerarq.txtBusqUniOrgaJerar.Text.Trim.Length > 0 Then
                            Dim t = UCUnidOrganica_Jerarq.txtIdUOJe.Text

                            UCUnidOrganica_Jerarq.PictureBox2.Visible = True
                            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() UCUnidOrganica_Jerarq.GetListUnidadOrganica(t)))
                            UCUnidOrganica_Jerarq.PictureBox2.Visible = False
                            UCUnidOrganica_Jerarq.DGUnidJerarquia.Table.Records.DeleteAll()
                            thread.Start()
                        End If


                        'ElseIf FORMUL = "FormInicioTupa" Then
                        '    Dim recor = dgUnidaNegocio.Table.CurrentRecord
                        '    Dim IdOrganigramaBE = dgUnidaNegocio.Table.CurrentRecord.GetValue("idOrganigrama")
                        '    Dim Descripcion = dgUnidaNegocio.Table.CurrentRecord.GetValue("descripcion")
                        '    Dim IdPadre = dgUnidaNegocio.Table.CurrentRecord.GetValue("idPadre")

                        '    FormInicioTupa.txtUnidadO.Text = Descripcion
                        '    FormInicioTupa.txtIdUniOrg.Text = IdOrganigramaBE
                        '    FormInicioTupa.txtIdPadre.Text = IdPadre

                        '    If FormInicioTupa.txtUnidadO.Text.Trim.Length > 0 Then
                        '        FormInicioTupa.BuscarPaquete(IdOrganigramaBE)
                        '        FormInicioTupa.BuscarACTIVIDAD(IdOrganigramaBE)
                        '    End If

                        'ElseIf FORMUL = "UCOtrosTramites" Then
                        '    Dim recor = dgUnidaNegocio.Table.CurrentRecord
                        '    Dim IdOrganigramaBE = dgUnidaNegocio.Table.CurrentRecord.GetValue("idOrganigrama")
                        '    Dim Descripcion = dgUnidaNegocio.Table.CurrentRecord.GetValue("descripcion")
                        '    Dim IdPadre = dgUnidaNegocio.Table.CurrentRecord.GetValue("idPadre")

                        '    UCOtrosTramites.txtBusUniOrgOT.Text = Descripcion
                        '    UCOtrosTramites.txtIdPadreOT.Text = IdOrganigramaBE
                        '    UCOtrosTramites.lblIdPadreOT.Text = IdPadre

                        'If UCOtrosTramites.txtIdPadreOT.Text.Trim.Length > 0 Then
                        '    UCOtrosTramites.BuscarPaquete(IdOrganigramaBE)
                        '    UCOtrosTramites.BuscarACTIVIDAD(IdOrganigramaBE)
                        'End If
                    End If

                End If


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar!")
        End Try
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        RaiseEvent OKEvent()
    End Sub
End Class
