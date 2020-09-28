Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFiltroPeriodoCliente
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFiltroPeriodoCliente))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.TExtAnio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboComprobantes = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.TextNumIdentrazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.RBFullName = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TExtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(174, 24)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(16, 24)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(174, 24)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, -5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Seleccionar Periodo:"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(102, 31)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(181, 148)
        Me.RoundButton21.MetroColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(102, 31)
        Me.RoundButton21.TabIndex = 5
        Me.RoundButton21.Text = "Aceptar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'TExtAnio
        '
        Me.TExtAnio.BackGroundColor = System.Drawing.Color.White
        Me.TExtAnio.BeforeTouchSize = New System.Drawing.Size(322, 22)
        Me.TExtAnio.BorderColor = System.Drawing.Color.Silver
        Me.TExtAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TExtAnio.CurrencyDecimalDigits = 0
        Me.TExtAnio.CurrencyGroupSeparator = ""
        Me.TExtAnio.CurrencySymbol = ""
        Me.TExtAnio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TExtAnio.DecimalValue = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.TExtAnio.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TExtAnio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.TExtAnio.Location = New System.Drawing.Point(196, 22)
        Me.TExtAnio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TExtAnio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TExtAnio.Name = "TExtAnio"
        Me.TExtAnio.NullString = ""
        Me.TExtAnio.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.TExtAnio.ReadOnlyBackColor = System.Drawing.Color.White
        Me.TExtAnio.Size = New System.Drawing.Size(63, 27)
        Me.TExtAnio.TabIndex = 592
        Me.TExtAnio.Text = "2019"
        Me.TExtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(279, -5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 19)
        Me.Label2.TabIndex = 593
        Me.Label2.Text = "Tipo de Comprobantes"
        '
        'cboComprobantes
        '
        Me.cboComprobantes.BackColor = System.Drawing.Color.White
        Me.cboComprobantes.BeforeTouchSize = New System.Drawing.Size(175, 24)
        Me.cboComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComprobantes.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboComprobantes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboComprobantes.Items.AddRange(New Object() {"VENTAS ELECTRONICAS", "VENTAS FISICAS", "TODAS LAS VENTAS", "NOTAS DE VENTA"})
        Me.cboComprobantes.Location = New System.Drawing.Point(281, 24)
        Me.cboComprobantes.Name = "cboComprobantes"
        Me.cboComprobantes.Size = New System.Drawing.Size(175, 24)
        Me.cboComprobantes.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboComprobantes.TabIndex = 594
        Me.cboComprobantes.Text = "VENTAS ELECTRONICAS"
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 10
        Me.BunifuElipse1.TargetControl = Me
        '
        'TextNumIdentrazon
        '
        Me.TextNumIdentrazon.BackColor = System.Drawing.SystemColors.Info
        Me.TextNumIdentrazon.BeforeTouchSize = New System.Drawing.Size(322, 22)
        Me.TextNumIdentrazon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdentrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdentrazon.CornerRadius = 3
        Me.TextNumIdentrazon.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNumIdentrazon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdentrazon.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNumIdentrazon.Location = New System.Drawing.Point(16, 111)
        Me.TextNumIdentrazon.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.TextNumIdentrazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumIdentrazon.Name = "TextNumIdentrazon"
        Me.TextNumIdentrazon.Size = New System.Drawing.Size(112, 23)
        Me.TextNumIdentrazon.TabIndex = 650
        '
        'TextProveedor
        '
        Me.TextProveedor.BackColor = System.Drawing.Color.White
        Me.TextProveedor.BeforeTouchSize = New System.Drawing.Size(322, 22)
        Me.TextProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProveedor.CornerRadius = 3
        Me.TextProveedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextProveedor.Enabled = False
        Me.TextProveedor.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextProveedor.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextProveedor.Location = New System.Drawing.Point(134, 111)
        Me.TextProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.TextProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.Size = New System.Drawing.Size(322, 22)
        Me.TextProveedor.TabIndex = 651
        '
        'RBFullName
        '
        Me.RBFullName.AutoSize = True
        Me.RBFullName.ForeColor = System.Drawing.Color.Black
        Me.RBFullName.Location = New System.Drawing.Point(134, 88)
        Me.RBFullName.Name = "RBFullName"
        Me.RBFullName.Size = New System.Drawing.Size(88, 17)
        Me.RBFullName.TabIndex = 697
        Me.RBFullName.Text = "Razon Social"
        Me.RBFullName.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(20, 88)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(66, 17)
        Me.RadioButton1.TabIndex = 696
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Ruc/Dni"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 19)
        Me.Label3.TabIndex = 698
        Me.Label3.Text = "Seleccione Cliente"
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(134, 111)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 699
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(491, 63)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 178)
        Me.pcLikeCategoria.TabIndex = 700
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC, Me.colTipoDoc})
        Me.LsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProveedor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.LsvProveedor.FullRowSelect = True
        Me.LsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvProveedor.HideSelection = False
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.LsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.LsvProveedor.MultiSelect = False
        Me.LsvProveedor.Name = "LsvProveedor"
        Me.LsvProveedor.Size = New System.Drawing.Size(282, 178)
        Me.LsvProveedor.TabIndex = 1
        Me.LsvProveedor.UseCompatibleStateImageBehavior = False
        Me.LsvProveedor.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 219
        '
        'colRUC
        '
        Me.colRUC.Text = "RUC"
        '
        'FormFiltroPeriodoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BorderThickness = 4
        Me.CaptionButtonColor = System.Drawing.Color.Black
        Me.CaptionButtonHoverColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(468, 191)
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.PictureLoad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RBFullName)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.TextNumIdentrazon)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.cboComprobantes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TExtAnio)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMesCompra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MetroColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.MinimizeBox = False
        Me.Name = "FormFiltroPeriodoCliente"
        Me.ShowIcon = False
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TExtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboMesCompra As Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents TExtAnio As Tools.CurrencyTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboComprobantes As Tools.ComboBoxAdv
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents TextNumIdentrazon As Tools.TextBoxExt
    Friend WithEvents TextProveedor As Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents RBFullName As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents PictureLoad As PictureBox
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
End Class
