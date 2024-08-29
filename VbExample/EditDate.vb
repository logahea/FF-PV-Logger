' Copyright (c) 2005 National Instruments Corp. All rights reserved
' EditDate.vb
'implementation of writing paramter whose type is FF_DATE
Imports NationalInstruments.FieldBus
Imports NationalInstruments.FieldBus.ExceptionHandler
Imports NationalInstruments.FieldBus.ParameterHandler
Imports NationalInstruments.FieldBus.ElementHandler



Public Class EditDateForm
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
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents objTypeBox As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents desc As System.Windows.Forms.TextBox
    Friend WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents message As System.Windows.Forms.TextBox
    Friend WithEvents mesglabel As System.Windows.Forms.Label
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents WriteButton As System.Windows.Forms.Button
    Friend WithEvents datePanel As System.Windows.Forms.Panel
    Friend WithEvents summerTimeCheck As System.Windows.Forms.CheckBox
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents msecOfDateText As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents minText As System.Windows.Forms.TextBox
    Friend WithEvents hourText As System.Windows.Forms.TextBox
    Friend WithEvents dayOfMonthText As System.Windows.Forms.TextBox
    Friend WithEvents monthText As System.Windows.Forms.TextBox
    Friend WithEvents yearText As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EditDateForm))
        Me.panel1 = New System.Windows.Forms.Panel
        Me.label1 = New System.Windows.Forms.Label
        Me.objTypeBox = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.desc = New System.Windows.Forms.TextBox
        Me.panel2 = New System.Windows.Forms.Panel
        Me.message = New System.Windows.Forms.TextBox
        Me.mesglabel = New System.Windows.Forms.Label
        Me.ExitButton = New System.Windows.Forms.Button
        Me.WriteButton = New System.Windows.Forms.Button
        Me.datePanel = New System.Windows.Forms.Panel
        Me.summerTimeCheck = New System.Windows.Forms.CheckBox
        Me.label8 = New System.Windows.Forms.Label
        Me.msecOfDateText = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.minText = New System.Windows.Forms.TextBox
        Me.hourText = New System.Windows.Forms.TextBox
        Me.dayOfMonthText = New System.Windows.Forms.TextBox
        Me.monthText = New System.Windows.Forms.TextBox
        Me.yearText = New System.Windows.Forms.TextBox
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.datePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.objTypeBox)
        Me.panel1.Controls.Add(Me.label4)
        Me.panel1.Controls.Add(Me.desc)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(288, 64)
        Me.panel1.TabIndex = 25
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(8, 40)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 16)
        Me.label1.TabIndex = 20
        Me.label1.Text = "Object Type"
        '
        'objTypeBox
        '
        Me.objTypeBox.Location = New System.Drawing.Point(96, 40)
        Me.objTypeBox.Name = "objTypeBox"
        Me.objTypeBox.ReadOnly = True
        Me.objTypeBox.Size = New System.Drawing.Size(184, 20)
        Me.objTypeBox.TabIndex = 19
        Me.objTypeBox.Text = ""
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(16, 8)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(56, 16)
        Me.label4.TabIndex = 18
        Me.label4.Text = "Parameter"
        '
        'desc
        '
        Me.desc.Location = New System.Drawing.Point(96, 8)
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Size = New System.Drawing.Size(184, 20)
        Me.desc.TabIndex = 17
        Me.desc.Text = ""
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.message)
        Me.panel2.Controls.Add(Me.mesglabel)
        Me.panel2.Controls.Add(Me.ExitButton)
        Me.panel2.Controls.Add(Me.WriteButton)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel2.Location = New System.Drawing.Point(0, 262)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(288, 112)
        Me.panel2.TabIndex = 24
        '
        'message
        '
        Me.message.Location = New System.Drawing.Point(0, 32)
        Me.message.Name = "message"
        Me.message.ReadOnly = True
        Me.message.Size = New System.Drawing.Size(288, 20)
        Me.message.TabIndex = 13
        Me.message.Text = ""
        '
        'mesglabel
        '
        Me.mesglabel.Location = New System.Drawing.Point(0, 16)
        Me.mesglabel.Name = "mesglabel"
        Me.mesglabel.Size = New System.Drawing.Size(288, 16)
        Me.mesglabel.TabIndex = 12
        Me.mesglabel.Text = "Returned Message"
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(156, 72)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(72, 24)
        Me.ExitButton.TabIndex = 11
        Me.ExitButton.Text = "Close"
        '
        'WriteButton
        '
        Me.WriteButton.Location = New System.Drawing.Point(32, 72)
        Me.WriteButton.Name = "WriteButton"
        Me.WriteButton.Size = New System.Drawing.Size(72, 24)
        Me.WriteButton.TabIndex = 10
        Me.WriteButton.Text = "Write Data"
        '
        'datePanel
        '
        Me.datePanel.Controls.Add(Me.summerTimeCheck)
        Me.datePanel.Controls.Add(Me.label8)
        Me.datePanel.Controls.Add(Me.msecOfDateText)
        Me.datePanel.Controls.Add(Me.label7)
        Me.datePanel.Controls.Add(Me.label6)
        Me.datePanel.Controls.Add(Me.label2)
        Me.datePanel.Controls.Add(Me.label3)
        Me.datePanel.Controls.Add(Me.label9)
        Me.datePanel.Controls.Add(Me.minText)
        Me.datePanel.Controls.Add(Me.hourText)
        Me.datePanel.Controls.Add(Me.dayOfMonthText)
        Me.datePanel.Controls.Add(Me.monthText)
        Me.datePanel.Controls.Add(Me.yearText)
        Me.datePanel.Location = New System.Drawing.Point(0, 72)
        Me.datePanel.Name = "datePanel"
        Me.datePanel.Size = New System.Drawing.Size(292, 184)
        Me.datePanel.TabIndex = 26
        '
        'summerTimeCheck
        '
        Me.summerTimeCheck.Location = New System.Drawing.Point(24, 160)
        Me.summerTimeCheck.Name = "summerTimeCheck"
        Me.summerTimeCheck.Size = New System.Drawing.Size(144, 16)
        Me.summerTimeCheck.TabIndex = 14
        Me.summerTimeCheck.Text = "summerTime"
        '
        'label8
        '
        Me.label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.Location = New System.Drawing.Point(24, 128)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(48, 16)
        Me.label8.TabIndex = 13
        Me.label8.Text = "msec"
        '
        'msecOfDateText
        '
        Me.msecOfDateText.Location = New System.Drawing.Point(96, 128)
        Me.msecOfDateText.Name = "msecOfDateText"
        Me.msecOfDateText.Size = New System.Drawing.Size(144, 20)
        Me.msecOfDateText.TabIndex = 12
        Me.msecOfDateText.Text = ""
        '
        'label7
        '
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(24, 104)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(48, 16)
        Me.label7.TabIndex = 11
        Me.label7.Text = "min"
        '
        'label6
        '
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.Location = New System.Drawing.Point(24, 80)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(48, 16)
        Me.label6.TabIndex = 10
        Me.label6.Text = "hour"
        '
        'label2
        '
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(8, 56)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(80, 16)
        Me.label2.TabIndex = 8
        Me.label2.Text = "dayOfMonth"
        '
        'label3
        '
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(24, 32)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(48, 16)
        Me.label3.TabIndex = 7
        Me.label3.Text = "month"
        '
        'label9
        '
        Me.label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.Location = New System.Drawing.Point(24, 8)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(48, 16)
        Me.label9.TabIndex = 6
        Me.label9.Text = "year"
        '
        'minText
        '
        Me.minText.Location = New System.Drawing.Point(96, 104)
        Me.minText.Name = "minText"
        Me.minText.Size = New System.Drawing.Size(144, 20)
        Me.minText.TabIndex = 5
        Me.minText.Text = ""
        '
        'hourText
        '
        Me.hourText.Location = New System.Drawing.Point(96, 80)
        Me.hourText.Name = "hourText"
        Me.hourText.Size = New System.Drawing.Size(144, 20)
        Me.hourText.TabIndex = 4
        Me.hourText.Text = ""
        '
        'dayOfMonthText
        '
        Me.dayOfMonthText.Location = New System.Drawing.Point(96, 56)
        Me.dayOfMonthText.Name = "dayOfMonthText"
        Me.dayOfMonthText.Size = New System.Drawing.Size(144, 20)
        Me.dayOfMonthText.TabIndex = 2
        Me.dayOfMonthText.Text = ""
        '
        'monthText
        '
        Me.monthText.Location = New System.Drawing.Point(96, 32)
        Me.monthText.Name = "monthText"
        Me.monthText.Size = New System.Drawing.Size(144, 20)
        Me.monthText.TabIndex = 1
        Me.monthText.Text = ""
        '
        'yearText
        '
        Me.yearText.Location = New System.Drawing.Point(96, 8)
        Me.yearText.Name = "yearText"
        Me.yearText.Size = New System.Drawing.Size(144, 20)
        Me.yearText.TabIndex = 0
        Me.yearText.Text = ""
        '
        'EditDateForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(288, 374)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.datePanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "EditDateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EditDate"
        Me.panel1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.datePanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private CurParameter As Parameter
    Private CurElement As Element

    Public Sub New(ByVal CurParameter As Parameter, ByVal CurElement As Element)
        InitializeComponent()
        Me.CurElement = CurElement
        Me.CurParameter = CurParameter
    End Sub

    Private Sub EditDateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        desc.Text = CurParameter.Name + "." + CurElement.Name
        objTypeBox.Text = CurElement.Type.ToString()
        Dim d As FBDate = CurElement.Value
        yearText.Text = d.Year.ToString()
        monthText.Text = d.Month.ToString()
        dayOfMonthText.Text = d.DayOfMonth.ToString()
        hourText.Text = d.Hour.ToString()
        minText.Text = d.Minute.ToString()
        msecOfDateText.Text = d.Millisecond.ToString()
        summerTimeCheck.Checked = d.SummerTime
    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Close()
    End Sub

    Private Sub WriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WriteButton.Click
        message.Text = " Writing Object ..."
        message.Refresh()
        Dim d As FBDate = CurElement.Value
        Try
            d.Year = Byte.Parse(yearText.Text)
            d.Month = Byte.Parse(monthText.Text)
            d.DayOfMonth = Byte.Parse(dayOfMonthText.Text)
            d.Hour = Byte.Parse(hourText.Text)
            d.Minute = Byte.Parse(minText.Text)
            d.Millisecond = Integer.Parse(msecOfDateText.Text)
            d.SummerTime = summerTimeCheck.Checked
            CurParameter.Write()
            message.Text += " successful"
        Catch exp As Exception
            message.Text = exp.Message
        End Try

    End Sub
End Class
