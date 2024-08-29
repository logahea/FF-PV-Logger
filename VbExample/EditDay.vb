' Copyright (c) 2005 National Instruments Corp. All rights reserved
' EditDay.vb
' implementation of writing paramter whose type is FF_TIMEOFDAY,FF_TIME_DIFF

Imports NationalInstruments.FieldBus
Imports NationalInstruments.FieldBus.ExceptionHandler
Imports NationalInstruments.FieldBus.ParameterHandler
Imports NationalInstruments.FieldBus.ElementHandler


Public Class EditDayForm
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
    Friend WithEvents dayPanel As System.Windows.Forms.Panel
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents msecOfDayText As System.Windows.Forms.TextBox
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents dayText As System.Windows.Forms.TextBox
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EditDayForm))
        Me.dayPanel = New System.Windows.Forms.Panel
        Me.label10 = New System.Windows.Forms.Label
        Me.msecOfDayText = New System.Windows.Forms.TextBox
        Me.label9 = New System.Windows.Forms.Label
        Me.dayText = New System.Windows.Forms.TextBox
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
        Me.dayPanel.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dayPanel
        '
        Me.dayPanel.Controls.Add(Me.label10)
        Me.dayPanel.Controls.Add(Me.msecOfDayText)
        Me.dayPanel.Controls.Add(Me.label9)
        Me.dayPanel.Controls.Add(Me.dayText)
        Me.dayPanel.Location = New System.Drawing.Point(0, 72)
        Me.dayPanel.Name = "dayPanel"
        Me.dayPanel.Size = New System.Drawing.Size(296, 72)
        Me.dayPanel.TabIndex = 29
        '
        'label10
        '
        Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(24, 40)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(48, 16)
        Me.label10.TabIndex = 17
        Me.label10.Text = "msec"
        '
        'msecOfDayText
        '
        Me.msecOfDayText.Location = New System.Drawing.Point(96, 40)
        Me.msecOfDayText.Name = "msecOfDayText"
        Me.msecOfDayText.Size = New System.Drawing.Size(144, 20)
        Me.msecOfDayText.TabIndex = 16
        Me.msecOfDayText.Text = ""
        '
        'label9
        '
        Me.label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.Location = New System.Drawing.Point(24, 8)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(48, 16)
        Me.label9.TabIndex = 15
        Me.label9.Text = "day"
        '
        'dayText
        '
        Me.dayText.Location = New System.Drawing.Point(96, 8)
        Me.dayText.Name = "dayText"
        Me.dayText.Size = New System.Drawing.Size(144, 20)
        Me.dayText.TabIndex = 14
        Me.dayText.Text = ""
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
        Me.panel1.Size = New System.Drawing.Size(296, 64)
        Me.panel1.TabIndex = 28
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
        Me.panel2.Location = New System.Drawing.Point(0, 150)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(296, 112)
        Me.panel2.TabIndex = 27
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
        'EditDayForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 262)
        Me.Controls.Add(Me.dayPanel)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "EditDayForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EditDay"
        Me.dayPanel.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
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

    Private Sub EditDayForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        desc.Text = CurParameter.Name + "." + CurElement.Name
        objTypeBox.Text = CurElement.Type.ToString()
        Dim Tod As TimeOfDay = CurElement.Value
        dayText.Text = Tod.Day.ToString()
        msecOfDayText.Text = Tod.Millisecond.ToString()
    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Close()
    End Sub

    Private Sub WriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WriteButton.Click
        message.Text = " Writing Object ..."
        message.Refresh()
        Try
            Dim Tod As TimeOfDay = CurElement.Value
            Tod.Day = Integer.Parse(dayText.Text)
            Tod.Millisecond = Long.Parse(msecOfDayText.Text)
            CurParameter.Write()
            message.Text += " successful"
        Catch exp As Exception
            message.Text = exp.Message
        End Try

    End Sub
End Class
