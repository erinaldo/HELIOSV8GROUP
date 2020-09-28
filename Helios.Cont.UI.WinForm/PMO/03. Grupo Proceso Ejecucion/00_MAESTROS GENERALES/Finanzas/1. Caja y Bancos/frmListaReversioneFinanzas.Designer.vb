<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaReversioneFinanzas
    Inherits frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListaReversioneFinanzas))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.idReversion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.reversion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.saldoMN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.saldoME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idReversion, Me.fecha, Me.reversion, Me.saldoMN, Me.saldoME})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 40)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(700, 252)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'idReversion
        '
        Me.idReversion.Text = "ID"
        Me.idReversion.Width = 0
        '
        'reversion
        '
        Me.reversion.DisplayIndex = 1
        Me.reversion.Text = "Descripción"
        Me.reversion.Width = 350
        '
        'fecha
        '
        Me.fecha.DisplayIndex = 2
        Me.fecha.Text = "Fecha"
        Me.fecha.Width = 100
        '
        'saldoMN
        '
        Me.saldoMN.Text = "Monto MN"
        Me.saldoMN.Width = 100
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(55, 23)
        Me.ButtonAdv6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(645, 12)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(55, 23)
        Me.ButtonAdv6.TabIndex = 555
        Me.ButtonAdv6.Text = "Ver"
        Me.ButtonAdv6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BackColor = System.Drawing.Color.White
        Me.GradientPanel11.BorderColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel11.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel11.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel11.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(700, 10)
        Me.GradientPanel11.TabIndex = 556
        '
        'saldoME
        '
        Me.saldoME.Text = "Monto ME"
        Me.saldoME.Width = 100
        '
        'frmListaReversioneFinanzas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.fecha_del_calendario_icono_6664_64
        CaptionImage1.Location = New System.Drawing.Point(15, 13)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Lista de Reversiones"
        CaptionLabel2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.SystemColors.Highlight
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Saldos disponibles"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(700, 292)
        Me.Controls.Add(Me.GradientPanel11)
        Me.Controls.Add(Me.ButtonAdv6)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListaReversioneFinanzas"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents idReversion As ColumnHeader
    Friend WithEvents reversion As ColumnHeader
    Friend WithEvents fecha As ColumnHeader
    Friend WithEvents saldoMN As ColumnHeader
    Friend WithEvents GradientPanel11 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents saldoME As System.Windows.Forms.ColumnHeader
End Class
