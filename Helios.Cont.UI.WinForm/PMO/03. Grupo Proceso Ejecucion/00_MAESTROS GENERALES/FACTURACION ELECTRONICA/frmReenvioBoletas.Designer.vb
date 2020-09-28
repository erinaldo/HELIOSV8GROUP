<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReenvioBoletas
    Inherits frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnValidar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.dtpFechaDocs = New System.Windows.Forms.DateTimePicker()
        Me.txtNumeracion = New System.Windows.Forms.TextBox()
        Me.btnReenvio = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnValidar)
        Me.Panel1.Controls.Add(Me.dtpFechaDocs)
        Me.Panel1.Controls.Add(Me.txtNumeracion)
        Me.Panel1.Controls.Add(Me.btnReenvio)
        Me.Panel1.Controls.Add(Me.ButtonAdv3)
        Me.Panel1.Controls.Add(Me.txtTicket)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(896, 122)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Fecha Documentos:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Nª Ticket"
        '
        'btnValidar
        '
        Me.btnValidar.BackColor = System.Drawing.Color.DarkSalmon
        Me.btnValidar.BeforeTouchSize = New System.Drawing.Size(93, 34)
        Me.btnValidar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnValidar.IsBackStageButton = False
        Me.btnValidar.Location = New System.Drawing.Point(212, 35)
        Me.btnValidar.Name = "btnValidar"
        Me.btnValidar.Size = New System.Drawing.Size(93, 34)
        Me.btnValidar.TabIndex = 18
        Me.btnValidar.Text = "Validacion"
        Me.btnValidar.Visible = False
        '
        'dtpFechaDocs
        '
        Me.dtpFechaDocs.Enabled = False
        Me.dtpFechaDocs.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDocs.Location = New System.Drawing.Point(15, 87)
        Me.dtpFechaDocs.Name = "dtpFechaDocs"
        Me.dtpFechaDocs.Size = New System.Drawing.Size(156, 22)
        Me.dtpFechaDocs.TabIndex = 17
        '
        'txtNumeracion
        '
        Me.txtNumeracion.Location = New System.Drawing.Point(245, 8)
        Me.txtNumeracion.Name = "txtNumeracion"
        Me.txtNumeracion.ReadOnly = True
        Me.txtNumeracion.Size = New System.Drawing.Size(65, 22)
        Me.txtNumeracion.TabIndex = 16
        Me.txtNumeracion.Visible = False
        '
        'btnReenvio
        '
        Me.btnReenvio.BackColor = System.Drawing.Color.DarkSalmon
        Me.btnReenvio.BeforeTouchSize = New System.Drawing.Size(93, 34)
        Me.btnReenvio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReenvio.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnReenvio.IsBackStageButton = False
        Me.btnReenvio.Location = New System.Drawing.Point(216, 35)
        Me.btnReenvio.Name = "btnReenvio"
        Me.btnReenvio.Size = New System.Drawing.Size(93, 34)
        Me.btnReenvio.TabIndex = 15
        Me.btnReenvio.Text = "Envio a Sunat"
        Me.btnReenvio.Visible = False
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.BackColor = System.Drawing.Color.Teal
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(102, 45)
        Me.ButtonAdv3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(381, 3)
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(102, 45)
        Me.ButtonAdv3.TabIndex = 14
        Me.ButtonAdv3.Text = "Buscar por ticket"
        Me.ButtonAdv3.Visible = False
        '
        'txtTicket
        '
        Me.txtTicket.Location = New System.Drawing.Point(15, 37)
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.ReadOnly = True
        Me.txtTicket.Size = New System.Drawing.Size(173, 22)
        Me.txtTicket.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GridGroupingControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 122)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(896, 119)
        Me.Panel2.TabIndex = 1
        '
        'GridGroupingControl1
        '
        Me.GridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
        Me.GridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridGroupingControl1.FreezeCaption = False
        Me.GridGroupingControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridGroupingControl1.Name = "GridGroupingControl1"
        Me.GridGroupingControl1.Size = New System.Drawing.Size(896, 119)
        Me.GridGroupingControl1.TabIndex = 1
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Documento"
        GridColumnDescriptor2.MappingName = "nroDoc"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 120
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Tipo Doc."
        GridColumnDescriptor3.MappingName = "tipoDoc"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 70
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Tipo Doc Clie."
        GridColumnDescriptor4.MappingName = "tipoDocCliente"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 70
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "nro. Doc"
        GridColumnDescriptor5.MappingName = "docCliente"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 100
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Estado"
        GridColumnDescriptor6.MappingName = "estado"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 50
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Moneda"
        GridColumnDescriptor7.MappingName = "moneda"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 70
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Igv"
        GridColumnDescriptor8.MappingName = "igv"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 70
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Gravado"
        GridColumnDescriptor9.MappingName = "gravado"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 70
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Importe"
        GridColumnDescriptor10.MappingName = "importe"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 70
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "Doc.Ref."
        GridColumnDescriptor11.MappingName = "docRel"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 100
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "tipoDoc.Ref."
        GridColumnDescriptor12.MappingName = "nroRel"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 70
        Me.GridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12})
        Me.GridGroupingControl1.TableOptions.AllowDragColumns = False
        Me.GridGroupingControl1.TableOptions.AllowDropDownCell = False
        Me.GridGroupingControl1.TableOptions.AllowMultiColumnSort = False
        Me.GridGroupingControl1.TableOptions.AllowSortColumns = False
        Me.GridGroupingControl1.Text = "GridGroupingControl1"
        Me.GridGroupingControl1.VersionInfo = "12.4400.0.24"
        '
        'frmReenvioBoletas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.Teal
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(896, 241)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReenvioBoletas"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtTicket As TextBox
    Friend WithEvents btnReenvio As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtNumeracion As TextBox
    Friend WithEvents dtpFechaDocs As DateTimePicker
    Friend WithEvents btnValidar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
