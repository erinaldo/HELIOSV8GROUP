Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Syncfusion.Windows.Forms.Grid
Imports System.Runtime.Serialization
Imports System.Drawing
Imports Syncfusion.Windows.Forms
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Syncfusion.Drawing
Public Class OutlookCell
    ''' <summary>
    ''' Implements the data / model part of a column header with sort indicator.
    ''' </summary>
    ''' <remarks>
    ''' You typically access cell models through the <see cref="GridModel.CellModels"/>
    ''' property of the <see cref="GridModel"/> class.<para/>
    ''' A <see cref="OutlookHeaderCellModel"/> can serve as model for several <see cref="OutlookHeaderCellRenderer"/>
    ''' instances if there are several <see cref="GridControlBase"/> views for a <see cref="GridModel"/>.
    ''' <para/>
    ''' See <see cref="OutlookHeaderCellRenderer"/> for more detailed information about this cell type.
    ''' </remarks>
    <Serializable> _
    Public Class OutlookHeaderCellModel
        Inherits GridOriginalTextBoxCellModel
        ''' <overload>
        ''' Initializes a new <see cref="OutlookHeaderCellModel"/> object.
        ''' </overload>
        ''' <summary>
        ''' Initializes a new <see cref="OutlookHeaderCellModel"/> object 
        ''' and stores a reference to the <see cref="GridModel"/> this cell belongs to.
        ''' </summary>
        ''' <param name="grid">The <see cref="GridModel"/> for this cell model.</param>    
        ''' <remarks>
        ''' You typically access cell models through the <see cref="GridModel.CellModels"/>
        ''' property of the <see cref="GridModel"/> class.
        ''' </remarks>
        Public Sub New(grid As GridModel)
            MyBase.New(grid)
        End Sub

        ''' <summary>
        ''' Initializes a new <see cref="OutlookHeaderCellModel"/> from a serialization stream.
        ''' </summary>
        ''' <param name="info">An object that holds all the data needed to serialize or deserialize this instance.</param>
        ''' <param name="context">Describes the source and destination of the serialized stream specified by info. </param>
        Protected Sub New(info As SerializationInfo, context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        ''' <summary>
        ''' This is called from GridStyleInfo.GetFormattedText. 
        ''' </summary>
        ''' <param name="style">The <see cref="GridStyleInfo"/> object that holds cell information.</param>
        ''' <param name="value">The value to format.</param>
        ''' <param name="textInfo">textInfo is a hint who is calling, default is GridCellBaseTextInfo.DisplayText.</param>
        ''' <returns>The formatted test for the gives value.</returns>
        Public Overrides Function GetFormattedText(style As GridStyleInfo, value As Object, textInfo As Integer) As String
            Dim styleColumn As GridStyleInfo = Grid.ColStyles(DirectCast(style.Identity, GridStyleInfoIdentity).ColIndex)
            Dim desc As String = styleColumn.Description
            If desc.Length > 0 Then
                Return desc
            End If
            Return MyBase.GetFormattedText(style, value, textInfo)
        End Function

        ''' <override/>
        ''' <summary>Creates a renderer for this cell model.</summary>
        ''' <param name="control">The grid control.</param>
        ''' <returns>Cell renderer.</returns>
        Public Overrides Function CreateRenderer(control As GridControlBase) As GridCellRendererBase
            Return New OutlookHeaderCellRenderer(control, Me)
        End Function

        ''' <summary>
        ''' Calculates the preferred size of the cell based on its contents without margins and any buttons.
        ''' </summary>
        ''' <param name="g">The <see cref="System.Drawing.Graphics"/> context of the canvas.</param>
        ''' <param name="rowIndex">The row index.</param>
        ''' <param name="colIndex">The column index.</param>
        ''' <param name="style">The <see cref="GridStyleInfo"/> object that holds cell information.</param>
        ''' <param name="queryBounds">grsphical bounds</param>
        ''' <returns>The optimal size of the cell.</returns>
        ''' <override/>
        Protected Overrides Function OnQueryPrefferedClientSize(g As Graphics, rowIndex As Integer, colIndex As Integer, style As GridStyleInfo, queryBounds As GridQueryBounds) As Size
            Dim size As Size = MyBase.OnQueryPrefferedClientSize(g, rowIndex, colIndex, style, queryBounds)
            size.Width += 12
            ' for sort triangle
            Return size
        End Function
    End Class
    ''' <summary>
    ''' Implements the CellRenderer for the OutlookHeaderCellRenderer.
    ''' </summary>
    Public Class OutlookHeaderCellRenderer
        Inherits GridOriginalTextBoxCellRenderer
        Private pushButton As GridCellButton, removeButton As GridCellButton
        Private hoverRange As GridRangeInfo = GridRangeInfo.Empty
        Private range As GridRangeInfo = Nothing
        Private mouseDown As Boolean = False
        Private inMouseDownRange As Boolean = False
        Private drawPressed As Boolean = False
        Private state As ThemedHeaderDrawing.HeaderState = ThemedHeaderDrawing.HeaderState.Normal
        Private mouseDownRange As GridRangeInfo = GridRangeInfo.Empty
        Shared ReadOnly defaultInterior1 As New BrushInfo(GradientStyle.Vertical, Color.FromArgb(203, 199, 184), Color.FromArgb(238, 234, 216))

        Private gridBase As GridControlBase
        Private r1 As Rectangle, r2 As Rectangle
        Private sortIconSize As Integer = 12
        Private pen As New Pen(Color.Red)

        ''' <summary>
        ''' Initializes a new <see cref="OutlookHeaderCellRenderer"/> object.
        ''' </summary>
        ''' <param name="grid">Instance of gridcontrolbase.</param>
        ''' <param name="cellModel">The cellmodel of this renderer.</param>
        Public Sub New(grid As GridControlBase, cellModel As GridCellModelBase)
            MyBase.New(grid, cellModel)
            Me.gridBase = grid
            AddButton(InlineAssignHelper(pushButton, New GridCellButton(Me)))
        End Sub

        Private m_firstString As New Dictionary(Of Integer, String)()
        Public Property FirstString() As Dictionary(Of Integer, String)
            Get
                Return m_firstString
            End Get
            Set(value As Dictionary(Of Integer, String))
                m_firstString = value
            End Set
        End Property
        Public unreadMessage As New List(Of Integer)()
        ''' <summary>
        ''' overriden to draw the border style of the cell.
        ''' </summary>
        ''' <param name="g">graphics associated with the control</param>
        ''' <param name="clRect">clientrectangle of the cell</param>
        ''' <param name="rowIndex">rowindex of the cell</param>
        ''' <param name="colIndex">colindex of the cell</param>
        ''' <param name="style">style information of this cell</param>
        Protected Overrides Sub OnDraw(g As Graphics, clRect As Rectangle, rowIndex As Integer, colIndex As Integer, style As GridStyleInfo)
            MyBase.OnDraw(g, clRect, rowIndex, colIndex, style)
        End Sub
        Protected Overrides Sub OnClick(rowIndex As Integer, colIndex As Integer, e As MouseEventArgs)
            Dim rect As Rectangle = Me.Grid.RangeInfoToRectangle(GridRangeInfo.Cell(rowIndex, colIndex))
            rect.Width = 50
            If unreadMessage IsNot Nothing Then
                If unreadMessage.Contains(rowIndex) Then
                    unreadMessage.Remove(rowIndex)
                End If
            End If
            If rect.Contains(e.Location) Then
                If unreadMessage.Contains(rowIndex) Then
                    unreadMessage.Remove(rowIndex)
                Else
                    unreadMessage.Add(rowIndex)
                End If
            End If
            clickedRow = rowIndex
            clickedCol = colIndex
            MyBase.OnClick(rowIndex, colIndex, e)
            Me.Grid.RefreshRange(GridRangeInfo.Cells(rowIndex, colIndex, rowIndex, colIndex))
        End Sub
        Private clickedRow As Integer, clickedCol As Integer = 0
        Protected Overrides Sub OnMouseMove(rowIndex As Integer, colIndex As Integer, e As MouseEventArgs)
            Dim range As Rectangle = Me.Grid.RangeInfoToRectangle(GridRangeInfo.Cell(rowIndex, colIndex))
            range.Width = 50


            If range.Contains(e.Location) Then
            End If
            moveRowIndex = rowIndex
            moveColIndex = colIndex
            MyBase.OnMouseMove(rowIndex, colIndex, e)
        End Sub


        Private resources As New System.ComponentModel.ComponentResourceManager(GetType(frmNotify))
        Private moveRowIndex As Integer = 0, moveColIndex As Integer = 0

        Protected Overrides Sub OnMouseHoverEnter(rowIndex As Integer, colIndex As Integer)
            moveRowIndex = rowIndex
            moveColIndex = colIndex
            MyBase.OnMouseHoverEnter(rowIndex, colIndex)
        End Sub
        Protected Overrides Sub OnMouseHoverLeave(rowIndex As Integer, colIndex As Integer, e As EventArgs)
            Dim clRect As Rectangle = Me.Grid.RangeInfoToRectangle(GridRangeInfo.Cell(rowIndex, colIndex))
            Dim closeImage As New Rectangle(clRect.X + clRect.Width - 25, clRect.Y + 22, 21, 21)
            Dim flagImage As New Rectangle(clRect.X + clRect.Width - 50, clRect.Y + 2, 21, 21)

            Using g As Graphics = Me.Grid.CreateGridGraphics()
                If moveRowIndex = rowIndex AndAlso moveColIndex = colIndex Then
                    g.FillRectangle(Brushes.White, closeImage)
                    g.FillRectangle(Brushes.White, flagImage)
                End If
                g.Dispose()
            End Using
            Me.Grid.RefreshRange(GridRangeInfo.Cells(rowIndex, colIndex, rowIndex, colIndex))
            MyBase.OnMouseHoverLeave(rowIndex, colIndex, e)
        End Sub
        Protected Overrides Sub OnMouseHover(rowIndex As Integer, colIndex As Integer, e As MouseEventArgs)
            moveRowIndex = rowIndex
            moveColIndex = colIndex
            Dim result As Integer = 0
            Dim style As GridStyleInfo = Me.Grid.Model(rowIndex, colIndex)
            If Integer.TryParse(style.ValueMember, result) Then
                If Not unreadMessage.Contains(rowIndex) Then
                    unreadMessage.Add(rowIndex)
                End If
            End If
            Dim secondBrush As New SolidBrush(ColorTranslator.FromHtml("#006FC4"))
            Dim clRect As Rectangle = Me.Grid.RangeInfoToRectangle(GridRangeInfo.Cell(rowIndex, colIndex))
            Dim closeImage As New Rectangle(clRect.X + clRect.Width - 25, clRect.Y + 20, 20, 20)
            Dim flagImage As New Rectangle(clRect.X + clRect.Width - 50, clRect.Y + 2, 20, 20)
            Dim rect As New Rectangle(clRect.X, clRect.Y, 50, clRect.Height)
            Dim clr As Color = Color.FromArgb(230, 242, 250)
            ' ;
            Using g As Graphics = Me.Grid.CreateGraphics()
                If moveRowIndex = rowIndex AndAlso moveColIndex = colIndex Then
                    If Me.Grid.Model.ColWidths(colIndex) <= 400 Then
                        If hoveredFlag Then
                            If clickedRow = rowIndex Then
                                clr = ColorTranslator.FromHtml("#CDE6F7")
                            End If
                            g.FillRectangle(New SolidBrush(clr), flagImage)
                            hoveredFlag = False
                        End If
                        If hoveredClose Then
                            If clickedRow = rowIndex Then
                                clr = ColorTranslator.FromHtml("#CDE6F7")
                            End If
                            g.FillRectangle(New SolidBrush(clr), closeImage)
                            hoveredClose = False
                        End If
                    End If
                    If closeImage.Contains(e.Location) Then
                        If clickedRow = rowIndex Then
                            clr = ColorTranslator.FromHtml("#CDE6F7")
                        End If
                        g.FillRectangle(New SolidBrush(clr), closeImage)
                        '  g.DrawImage(Global.OutlookDemo_2010.Properties.Resources.Run_rules_now, closeImage)
                        hoveredClose = True
                    Else
                        '   g.DrawImage(Global.OutlookDemo_2010.Properties.Resources.delete, closeImage)
                    End If
                    'Change icon here.
                    If flagImage.Contains(e.Location) Then
                        If clickedRow = rowIndex Then
                            clr = ColorTranslator.FromHtml("#CDE6F7")
                        End If
                        g.FillRectangle(New SolidBrush(clr), flagImage)
                        '   g.DrawImage(Global.OutlookDemo_2010.Properties.Resources.Run_rules_now1, flagImage)
                        hoveredFlag = True
                    Else
                        '  g.DrawImage(Global.OutlookDemo_2010.Properties.Resources.flag, flagImage)
                        'change icon here.
                    End If
                End If
                g.Dispose()
            End Using
            MyBase.OnMouseHover(rowIndex, colIndex, e)
        End Sub
        Private hoveredFlag As Boolean, hoveredClose As Boolean = False
        ''' <summary>
        ''' overriden to invalidate the mousedown cellrange
        ''' </summary>
        ''' <param name="rowIndex">rowIndex of this cell in grid</param>
        ''' <param name="colIndex">colIndex of this cell in grid</param>
        ''' <param name="e">mouse event data</param>
        Protected Overrides Sub OnMouseDown(rowIndex As Integer, colIndex As Integer, e As MouseEventArgs)
            Dim range As GridRangeInfo = GridRangeInfo.Cell(rowIndex, colIndex)
            If Not range.IsEmpty Then
                Grid.Model.GetSpannedRangeInfo(range.Top, range.Left, Me.mouseDownRange)
                Dim style As GridStyleInfo = Me.Grid.Model(range.Top, range.Left)
                If Not style.Clickable Then 'OrElse Me.Grid.CellRenderers(style.CellType) <> Me Then
                    Me.mouseDownRange = GridRangeInfo.Empty
                End If
            End If

            Me.mouseDown = Not mouseDownRange.IsEmpty
            Me.hoverRange = GridRangeInfo.Empty
            If Me.mouseDown Then
                Me.inMouseDownRange = True
                Me.Grid.InvalidateRange(Me.mouseDownRange)
            End If
            MyBase.OnMouseDown(rowIndex, colIndex, e)
        End Sub

        ''' <summary>
        ''' overriden to invalidate the clicked header cellrange.
        ''' </summary>
        ''' <param name="rowIndex">rowIndex of this cell in grid</param>
        ''' <param name="colIndex">colIndex of this cell in grid</param>
        ''' <param name="e">Mouse event data</param>
        Protected Overrides Sub OnMouseUp(rowIndex As Integer, colIndex As Integer, e As MouseEventArgs)
            If Me.mouseDown Then
                Me.mouseDown = False
                Me.Grid.InvalidateRange(Me.mouseDownRange)
                Me.mouseDownRange = GridRangeInfo.Empty
            End If
            MyBase.OnMouseUp(rowIndex, colIndex, e)
        End Sub

        ''' <summary>
        ''' overriden to draw the button for this cell.
        ''' </summary>
        ''' <param name="button">instance of the gridcellbutton to be drawn</param>
        ''' <param name="g">graphics associated with this control</param>
        ''' <param name="rowIndex">rowIndex of this cell in grid</param>
        ''' <param name="colIndex">colIndex of this cell in grid</param>
        ''' <param name="bActive">boolean value</param>
        ''' <param name="style">style information of this cell</param>
        Protected Overrides Sub OnDrawCellButton(button As GridCellButton, g As Graphics, rowIndex As Integer, colIndex As Integer, bActive As Boolean, style As GridStyleInfo)
            Dim ptOffset As New Point(1, 1)
            Dim bm As Bitmap = Nothing
            Dim propertyObject As GridProperties = Grid.Model.Properties

            Dim faceRect As Rectangle = button.Bounds
            faceRect.Inflate(-2, -1)
        End Sub




        ''' <summary>
        ''' overriden to preapre the layout appearance of the cell.
        ''' </summary>
        ''' <param name="rowIndex">rowIndex of this cell in grid</param>
        ''' <param name="colIndex">colIndex of this cell in grid</param>
        ''' <param name="style">style information of the cell</param>
        ''' <param name="innerBounds">inner text rectangle area</param>
        ''' <param name="buttonsBounds">button bounds for the associated button in control</param>
        ''' <returns></returns>
        Protected Overrides Function OnLayout(rowIndex As Integer, colIndex As Integer, style As GridStyleInfo, innerBounds As Rectangle, buttonsBounds As Rectangle()) As Rectangle
            Dim buttonArea As Rectangle
            Dim buttonWidth As Integer = 18

            Dim isTextRightToLeft As Boolean = (style.RightToLeft = RightToLeft.Inherit AndAlso Grid.IsRightToLeft()) OrElse style.RightToLeft = RightToLeft.Yes
            'Button area customization...........
            If Not isTextRightToLeft Then
                buttonArea = Rectangle.FromLTRB(innerBounds.Location.X + sortIconSize, innerBounds.Location.Y, innerBounds.Right + buttonWidth + sortIconSize, innerBounds.Bottom)
            Else
                buttonArea = Rectangle.FromLTRB(innerBounds.Location.X, innerBounds.Location.Y, innerBounds.Left + buttonWidth, innerBounds.Bottom)
            End If
            buttonsBounds(0) = GridUtil.CenterInRect(buttonArea, New Size(buttonWidth, 20))
            r1 = buttonArea

            Return innerBounds
        End Function

        ''' <summary>
        ''' overriden to raise the pushbutton click.
        ''' </summary>
        ''' <param name="rowIndex">rowIndex of this cell in grid</param>
        ''' <param name="colIndex">colIndex of this cell in grid</param>
        ''' <param name="button">clicked button</param>
        Protected Overrides Sub OnButtonClicked(rowIndex As Integer, colIndex As Integer, button As Integer)
            MyBase.OnButtonClicked(rowIndex, colIndex, button)
            OnPushButtonClick(rowIndex, colIndex)
        End Sub

        ''' <summary>
        ''' Raises <see cref="GridControlBase.PushButtonClick"/> event when the user presses the PushButton.
        ''' </summary>
        ''' <param name="rowIndex">Specifies the row id.</param>
        ''' <param name="colIndex">Specifies the column id.</param>
        Protected Overridable Sub OnPushButtonClick(rowIndex As Integer, colIndex As Integer)
            Grid.RaisePushButtonClick(rowIndex, colIndex)
        End Sub
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class
