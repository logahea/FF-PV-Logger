Imports NationalInstruments.FieldBus
Imports NationalInstruments.FieldBus.ExceptionHandler
Imports NationalInstruments.FieldBus.ParameterHandler
Imports NationalInstruments.FieldBus.ElementHandler


Public Class ReadWriteForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "



    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents panel4 As System.Windows.Forms.Panel
    Friend WithEvents paramType As System.Windows.Forms.TextBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents dataList As System.Windows.Forms.ListView
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents paramList As System.Windows.Forms.ListBox
    Friend WithEvents desc As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents readData As System.Windows.Forms.Button
    Friend WithEvents editData As System.Windows.Forms.Button
    Friend WithEvents panel3 As System.Windows.Forms.Panel
    Friend WithEvents message As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReadWriteForm))
        Me.panel4 = New System.Windows.Forms.Panel
        Me.paramType = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.panel2 = New System.Windows.Forms.Panel
        Me.dataList = New System.Windows.Forms.ListView
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.label3 = New System.Windows.Forms.Label
        Me.panel1 = New System.Windows.Forms.Panel
        Me.paramList = New System.Windows.Forms.ListBox
        Me.desc = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.readData = New System.Windows.Forms.Button
        Me.editData = New System.Windows.Forms.Button
        Me.panel3 = New System.Windows.Forms.Panel
        Me.message = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.panel4.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel4
        '
        Me.panel4.Controls.Add(Me.paramType)
        Me.panel4.Controls.Add(Me.label5)
        Me.panel4.Location = New System.Drawing.Point(24, 160)
        Me.panel4.Name = "panel4"
        Me.panel4.Size = New System.Drawing.Size(368, 40)
        Me.panel4.TabIndex = 8
        '
        'paramType
        '
        Me.paramType.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.paramType.Location = New System.Drawing.Point(0, 20)
        Me.paramType.Name = "paramType"
        Me.paramType.ReadOnly = True
        Me.paramType.Size = New System.Drawing.Size(368, 20)
        Me.paramType.TabIndex = 1
        Me.paramType.Text = ""
        '
        'label5
        '
        Me.label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.label5.Location = New System.Drawing.Point(0, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(368, 24)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Parameter Type"
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.dataList)
        Me.panel2.Controls.Add(Me.label3)
        Me.panel2.Location = New System.Drawing.Point(24, 216)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(368, 136)
        Me.panel2.TabIndex = 7
        '
        'dataList
        '
        Me.dataList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3})
        Me.dataList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dataList.FullRowSelect = True
        Me.dataList.GridLines = True
        Me.dataList.LabelWrap = False
        Me.dataList.Location = New System.Drawing.Point(0, 16)
        Me.dataList.MultiSelect = False
        Me.dataList.Name = "dataList"
        Me.dataList.Size = New System.Drawing.Size(368, 120)
        Me.dataList.TabIndex = 1
        Me.dataList.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "ParamName"
        Me.columnHeader1.Width = 79
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Data Type"
        Me.columnHeader2.Width = 100
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Data"
        Me.columnHeader3.Width = 200
        '
        'label3
        '
        Me.label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.label3.Location = New System.Drawing.Point(0, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(368, 16)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Data"
        '
        'panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.paramList)
        Me.panel1.Controls.Add(Me.desc)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Location = New System.Drawing.Point(24, 16)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(368, 144)
        Me.panel1.TabIndex = 6
        '
        'paramList
        '
        Me.paramList.Location = New System.Drawing.Point(24, 56)
        Me.paramList.Name = "paramList"
        Me.paramList.Size = New System.Drawing.Size(312, 69)
        Me.paramList.TabIndex = 4
        '
        'desc
        '
        Me.desc.Location = New System.Drawing.Point(104, 24)
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Size = New System.Drawing.Size(232, 20)
        Me.desc.TabIndex = 3
        Me.desc.Text = ""
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(24, 24)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(56, 16)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Descriptor"
        '
        'label1
        '
        Me.label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.label1.Location = New System.Drawing.Point(0, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(366, 16)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Input Parameter"
        '
        'readData
        '
        Me.readData.Location = New System.Drawing.Point(216, 424)
        Me.readData.Name = "readData"
        Me.readData.Size = New System.Drawing.Size(136, 24)
        Me.readData.TabIndex = 11
        Me.readData.Text = "Read Data"
        '
        'editData
        '
        Me.editData.Location = New System.Drawing.Point(48, 424)
        Me.editData.Name = "editData"
        Me.editData.Size = New System.Drawing.Size(144, 24)
        Me.editData.TabIndex = 10
        Me.editData.Text = "Edit Data"
        '
        'panel3
        '
        Me.panel3.Controls.Add(Me.message)
        Me.panel3.Controls.Add(Me.label4)
        Me.panel3.Location = New System.Drawing.Point(24, 360)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(368, 40)
        Me.panel3.TabIndex = 9
        '
        'message
        '
        Me.message.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.message.Location = New System.Drawing.Point(0, 20)
        Me.message.Name = "message"
        Me.message.ReadOnly = True
        Me.message.Size = New System.Drawing.Size(368, 20)
        Me.message.TabIndex = 1
        Me.message.Text = ""
        '
        'label4
        '
        Me.label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.label4.Location = New System.Drawing.Point(0, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(368, 24)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Returned Message"
        '
        'ReadWriteForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 470)
        Me.Controls.Add(Me.readData)
        Me.Controls.Add(Me.editData)
        Me.Controls.Add(Me.panel3)
        Me.Controls.Add(Me.panel4)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ReadWriteForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ReadWrite"
        Me.panel4.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private CurBlock As Block
    Private CurParam As Parameter


    Public Sub New(ByVal CurBlock As Block)
        InitializeComponent()
        Me.CurBlock = CurBlock
    End Sub

    Private Sub ReadWrite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' when initializing the form editData and readData buttons should be disabled because
        ' these button can't work properly without selected parameter
        desc.Text = CurBlock.Tag

        paramList.Items.Clear()
        Dim MyParameter As Parameter
        For Each MyParameter In CurBlock.Parameters
            paramList.Items.Add(MyParameter.Name)
        Next
    End Sub


    Private Sub readData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles readData.Click, paramList.DoubleClick
        If paramList.SelectedItem = Nothing Then
            Return
        End If

        message.Text = " Reading Data ... "

        dataList.Items.Clear()

        Dim ParamName As String = paramList.SelectedItem

        Try
            CurParam = CurBlock.ReadParameterByName(ParamName)
            paramType.Text = CurParam.Type.ToString()
            Dim Elem As Element
            Dim DataItem As ListViewItem
            Select Case CurParam.Type
                Case ParameterType.ODT_SIMPLEVAR
                    Dim Svp As SimpleVarParameter
                    Svp = CurParam
                    DataItem = New ListViewItem
                    DataItem.Text = Svp.Element.Name
                    DataItem.SubItems.Add(Svp.Element.Type.ToString())
                    DataItem.SubItems.Add(Svp.Element.ValueString())
                    dataList.Items.Add(DataItem)
                    Exit Select
                Case ParameterType.ODT_ARRAY
                    Dim Ap As ArrayParameter
                    Ap = CurParam
                    For Each Elem In Ap.Elements
                        DataItem = New ListViewItem
                        DataItem.Text = Elem.Name
                        DataItem.SubItems.Add(Elem.Type.ToString())
                        DataItem.SubItems.Add(Elem.ValueString())
                        dataList.Items.Add(DataItem)
                    Next
                    Exit Select
                Case ParameterType.ODT_RECORD
                    Dim Rp As RecordParameter
                    Rp = CurParam
                    For Each Elem In Rp.Elements
                        DataItem = New ListViewItem
                        DataItem.Text = Elem.Name
                        DataItem.SubItems.Add(Elem.Type.ToString())
                        DataItem.SubItems.Add(Elem.ValueString())
                        dataList.Items.Add(DataItem)
                    Next
                    Exit Select
            End Select
            message.Text += " successful"
        Catch ex As Exception
            message.Text = ex.Message
        End Try


    End Sub



    Private Sub editData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editData.Click, dataList.DoubleClick
        If dataList.SelectedIndices.Count = 0 Then
            Return
        End If
        Dim Index As Integer = dataList.SelectedIndices(0)
        Dim Elem As Element
        Select Case CurParam.Type
            Case ParameterType.ODT_SIMPLEVAR
                Dim Svp As SimpleVarParameter
                Svp = CurParam
                Elem = Svp.Element
                Exit Select
            Case ParameterType.ODT_ARRAY
                Dim Ap As ArrayParameter
                Ap = CurParam
                Elem = Ap.Elements(Index)
                Exit Select
            Case ParameterType.ODT_RECORD
                Dim Rp As RecordParameter
                Rp = CurParam
                Elem = Rp.Elements(Index)
                Exit Select
        End Select
        Select Case Elem.Type
            Case ElementType.FF_BOOLEAN
                Dim EditBool As EditBoolForm
                EditBool = New EditBoolForm(CurParam, Elem)
                EditBool.ShowDialog()
                Exit Select
            Case ElementType.FF_INTEGER8, ElementType.FF_INTEGER16, ElementType.FF_INTEGER32, ElementType.FF_UNSIGNED8, ElementType.FF_UNSIGNED16, ElementType.FF_UNSIGNED32
                Dim EditInteger As EditIntegerForm
                EditInteger = New EditIntegerForm(CurParam, Elem)
                EditInteger.ShowDialog()
                Exit Select
            Case ElementType.FF_FLOAT
                Dim EditFloat As EditFloatForm
                EditFloat = New EditFloatForm(CurParam, Elem)
                EditFloat.ShowDialog()
                Exit Select
            Case ElementType.FF_VISIBLE_STRING
                Dim EditVisiString As EditVisiStringForm
                EditVisiString = New EditVisiStringForm(CurParam, Elem)
                EditVisiString.ShowDialog()
                Exit Select
            Case ElementType.FF_OCTET_STRING
                Dim EditOctetString As EditOctetStringForm
                EditOctetString = New EditOctetStringForm(CurParam, Elem)
                EditOctetString.ShowDialog()
                Exit Select
            Case ElementType.FF_DATE
                Dim EditDate As EditDateForm
                EditDate = New EditDateForm(CurParam, Elem)
                EditDate.ShowDialog()
                Exit Select
            Case ElementType.FF_TIMEOFDAY, ElementType.FF_TIME_DIFF
                Dim EditDay As EditDayForm
                EditDay = New EditDayForm(CurParam, Elem)
                EditDay.ShowDialog()
                Exit Select
            Case ElementType.FF_BIT_STRING
                Dim EditBitString As EditBitStringForm
                EditBitString = New EditBitStringForm(CurParam, Elem)
                EditBitString.ShowDialog()
                Exit Select
            Case ElementType.FF_TIME_VALUE
                Dim EditTime As EditTimeForm
                EditTime = New EditTimeForm(CurParam, Elem)
                EditTime.ShowDialog()
                Exit Select
            Case Else
                message.Text = " Unknown parameter type!"
                Exit Select
        End Select

        ' refresh subparameter's data
        readData_Click(sender, e)
    End Sub
End Class
