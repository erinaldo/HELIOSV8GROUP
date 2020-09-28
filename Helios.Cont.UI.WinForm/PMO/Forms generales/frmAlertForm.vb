Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid

Public Class frmAlertForm
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property TotalesAlmacenSA As New TotalesAlmacenSA
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvKardexVal, True, False)
        threadInventarioXvencer()
        dgvKardexVal.DefaultGridBorderStyle = GridBorderStyle.Dotted
        dgvKardexVal.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro

    End Sub

    Private Sub threadInventarioXvencer()
        pbAnticiRecibidos.Visible = True
        pbAnticiRecibidos.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.WaitingGradient
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventarioValorizadoXvencer(DateTime.Now.Year, DateTime.Now.Month)))
        thread.Start()
    End Sub

    Private Sub GetInventarioValorizadoXvencer(anio As Integer, mes As Integer)
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
        dt.Columns.Add("status")
        dt.Columns.Add("fechaLote")
        dt.Columns.Add("NroLote")
        dt.Columns.Add("situacion")

        For Each i As totalesAlmacen In TotalesAlmacenSA.GetProductosXvencerMesFull(Gempresas.IdEmpresaRuc, anio, mes).OrderBy(Function(o) o.descripcion).ToList
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dr(13) = i.status
            If i.fechaLote.HasValue Then
                dr(14) = i.fechaLote.Value.ToString("dd-MM-yyyy")
            End If

            dr(15) = i.NroLote
            If i.fechaLote.HasValue Then
                If i.fechaLote > Date.Now Then
                    dr(16) = "Activo"
                ElseIf i.fechaLote.Value.Date = Date.Now.Date Then
                    dr(16) = "Vence Hoy"
                Else
                    dr(16) = "Vencido"
                End If
            Else
                dr(16) = "Activo"
            End If
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)

        ''dgvKardexVal.DataSource = dt
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        '''''ComboStatus()
    End Sub

    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgvKardexVal.DataSource = table
            dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvKardexVal.TableDescriptor.GroupedColumns.Clear()
            dgvKardexVal.TableDescriptor.GroupedColumns.Add("situacion")
            pbAnticiRecibidos.Visible = False

            'object for data bar rule
            'Dim conditionDataBarRule1 As New ConditionalFormatDataBarRule()

            ''Assigning column for data bar
            'conditionDataBarRule1.ColumnName = "Profit"

            ''Adding the rule to rules collection
            'conditionalDescriptor.Rules.Add(conditionDataBarRule1)

            ''Adding descriptor.
            'Me.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(conditionalDescriptor)

        End If
    End Sub


End Class