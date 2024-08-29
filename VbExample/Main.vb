
' Copyright (c) 2005 National Instruments Corp. All rights reserved
' Main.vb
' implementation of handling the initial steps before read or write parameters

' This example aims to demonstrate how to use CM APIs with VB.NET under .NET framework.
' NationalInstruments.fbus must be referenced which contains CM APIs.
' This assembly is composed by eleven files.
' Main.vb handles the initial steps before read or write parameters.
' ReadWrite.vb lists all the parameters of a definite block, shows the definite parameter's value and selects the definite parameter to write.
' Nine files whose names begin with Edit handle the function of writing paramter depending on the paramter's type.  


Imports NationalInstruments.FieldBus
Imports NationalInstruments.FieldBus.ExceptionHandler


Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

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
    Private WithEvents Block As System.Windows.Forms.Button
    Private WithEvents Device As System.Windows.Forms.Button
    Private WithEvents Link As System.Windows.Forms.Button
    Private WithEvents panel3 As System.Windows.Forms.Panel
    Private WithEvents blockList As System.Windows.Forms.ListBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents devList As System.Windows.Forms.ListBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents message As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Session As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Private WithEvents linkList As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Block = New System.Windows.Forms.Button()
        Me.Device = New System.Windows.Forms.Button()
        Me.Link = New System.Windows.Forms.Button()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.blockList = New System.Windows.Forms.ListBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.devList = New System.Windows.Forms.ListBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.linkList = New System.Windows.Forms.ListBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.message = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Session = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.panel3.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Block
        '
        Me.Block.Location = New System.Drawing.Point(16, 296)
        Me.Block.Name = "Block"
        Me.Block.Size = New System.Drawing.Size(88, 23)
        Me.Block.TabIndex = 13
        Me.Block.Text = "Open Block"
        '
        'Device
        '
        Me.Device.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Device.Location = New System.Drawing.Point(16, 184)
        Me.Device.Name = "Device"
        Me.Device.Size = New System.Drawing.Size(88, 23)
        Me.Device.TabIndex = 12
        Me.Device.Text = "Open Device"
        '
        'Link
        '
        Me.Link.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link.Location = New System.Drawing.Point(16, 64)
        Me.Link.Name = "Link"
        Me.Link.Size = New System.Drawing.Size(88, 23)
        Me.Link.TabIndex = 11
        Me.Link.Text = "Open Link"
        '
        'panel3
        '
        Me.panel3.AccessibleDescription = ""
        Me.panel3.AccessibleName = ""
        Me.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel3.Controls.Add(Me.blockList)
        Me.panel3.Controls.Add(Me.label4)
        Me.panel3.ForeColor = System.Drawing.Color.Black
        Me.panel3.Location = New System.Drawing.Point(136, 256)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(272, 88)
        Me.panel3.TabIndex = 10
        Me.panel3.Tag = ""
        '
        'blockList
        '
        Me.blockList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.blockList.Location = New System.Drawing.Point(0, 43)
        Me.blockList.Name = "blockList"
        Me.blockList.Size = New System.Drawing.Size(270, 43)
        Me.blockList.TabIndex = 1
        '
        'label4
        '
        Me.label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.label4.Location = New System.Drawing.Point(0, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(270, 16)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Block"
        '
        'panel2
        '
        Me.panel2.AccessibleDescription = ""
        Me.panel2.AccessibleName = ""
        Me.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel2.Controls.Add(Me.devList)
        Me.panel2.Controls.Add(Me.label5)
        Me.panel2.ForeColor = System.Drawing.Color.Black
        Me.panel2.Location = New System.Drawing.Point(136, 144)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(272, 88)
        Me.panel2.TabIndex = 9
        Me.panel2.Tag = ""
        '
        'devList
        '
        Me.devList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.devList.Location = New System.Drawing.Point(0, 43)
        Me.devList.Name = "devList"
        Me.devList.Size = New System.Drawing.Size(270, 43)
        Me.devList.TabIndex = 1
        '
        'label5
        '
        Me.label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.label5.Location = New System.Drawing.Point(0, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(270, 16)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Device"
        '
        'panel1
        '
        Me.panel1.AccessibleDescription = ""
        Me.panel1.AccessibleName = ""
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.linkList)
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.ForeColor = System.Drawing.Color.Black
        Me.panel1.Location = New System.Drawing.Point(136, 32)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(272, 88)
        Me.panel1.TabIndex = 8
        Me.panel1.Tag = ""
        '
        'linkList
        '
        Me.linkList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.linkList.Location = New System.Drawing.Point(0, 43)
        Me.linkList.Name = "linkList"
        Me.linkList.Size = New System.Drawing.Size(270, 43)
        Me.linkList.TabIndex = 1
        '
        'label3
        '
        Me.label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.label3.Location = New System.Drawing.Point(0, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(270, 16)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Link"
        '
        'label2
        '
        Me.label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label2.Location = New System.Drawing.Point(136, 360)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(104, 16)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Returned Message"
        '
        'message
        '
        Me.message.Location = New System.Drawing.Point(136, 376)
        Me.message.Name = "message"
        Me.message.ReadOnly = True
        Me.message.Size = New System.Drawing.Size(272, 20)
        Me.message.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Open Block"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(16, 184)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 23)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Open Device"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(16, 64)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 23)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Open Link"
        '
        'Panel4
        '
        Me.Panel4.AccessibleDescription = ""
        Me.Panel4.AccessibleName = ""
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.ListBox1)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.ForeColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(136, 256)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(272, 88)
        Me.Panel4.TabIndex = 10
        Me.Panel4.Tag = ""
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListBox1.Location = New System.Drawing.Point(0, 43)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(270, 43)
        Me.ListBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(270, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Block"
        '
        'Panel5
        '
        Me.Panel5.AccessibleDescription = ""
        Me.Panel5.AccessibleName = ""
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.ListBox2)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.ForeColor = System.Drawing.Color.Black
        Me.Panel5.Location = New System.Drawing.Point(136, 144)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(272, 88)
        Me.Panel5.TabIndex = 9
        Me.Panel5.Tag = ""
        '
        'ListBox2
        '
        Me.ListBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListBox2.Location = New System.Drawing.Point(0, 43)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(270, 43)
        Me.ListBox2.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(270, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Device"
        '
        'Panel6
        '
        Me.Panel6.AccessibleDescription = ""
        Me.Panel6.AccessibleName = ""
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.ListBox3)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.ForeColor = System.Drawing.Color.Black
        Me.Panel6.Location = New System.Drawing.Point(136, 32)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(272, 88)
        Me.Panel6.TabIndex = 8
        Me.Panel6.Tag = ""
        '
        'ListBox3
        '
        Me.ListBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListBox3.Location = New System.Drawing.Point(0, 43)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(270, 43)
        Me.ListBox3.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(270, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Link"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(136, 360)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Error Message"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(136, 376)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(272, 20)
        Me.TextBox1.TabIndex = 6
        '
        'Session
        '
        Me.Session.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Session.Location = New System.Drawing.Point(16, 16)
        Me.Session.Name = "Session"
        Me.Session.Size = New System.Drawing.Size(88, 23)
        Me.Session.TabIndex = 14
        Me.Session.Text = "Open Session"
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(16, 368)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(88, 23)
        Me.ExitButton.TabIndex = 15
        Me.ExitButton.Text = "Exit"
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(630, 487)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.Session)
        Me.Controls.Add(Me.Block)
        Me.Controls.Add(Me.Device)
        Me.Controls.Add(Me.Link)
        Me.Controls.Add(Me.panel3)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.message)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NI_FBUS API .Net Support Demo (VB.Net)"
        Me.panel3.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private MainSession As Session = new Session
    Private CurLink As Link
    Private CurDevice As Device
    Private CurVFD As VFD
    Private CurBlock As Block


    Private Sub Session_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Session.Click

        message.Text = "Open session ..."

        Device.Enabled = False
        Block.Enabled = False
        Link.Enabled = False
        linkList.Items.Clear()
        devList.Items.Clear()
        blockList.Items.Clear()

        Try
            MainSession.Close()
            MainSession.Open()
            Dim MyLink As Link
            For Each MyLink In MainSession.Links
                linkList.Items.Add(MyLink.Tag)
            Next
            message.Text += " successful"
        Catch ex As FBException
            message.Text = ex.Message
        End Try
        Link.Enabled = True



    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click, MyBase.Closed
        MainSession.Close()
        Application.Exit()
    End Sub

    Private Sub Link_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Link.Click

        Dim LinkTag As String
        If linkList.SelectedItem = Nothing Then
            Return
        End If
        LinkTag = linkList.SelectedItem
        message.Text = "Open Link " + LinkTag + " ..."

        Block.Enabled = False
        Device.Enabled = False
        blockList.Items.Clear()
        devList.Items.Clear()

        Try
            If Not (CurLink Is Nothing) Then
                CurLink.Close()
            End If
            CurLink = MainSession.GetLinkByTag(LinkTag)
            CurLink.Open()
            Dim MyDevice As Device
            For Each MyDevice In CurLink.Devices
                devList.Items.Add(MyDevice.Tag)
            Next
            message.Text += " successful"
        Catch ex As Exception
            message.Text = ex.Message
        End Try
        Device.Enabled = True

    End Sub


    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Link.Enabled = False
        Device.Enabled = False
        Block.Enabled = False

    End Sub



    Private Sub Device_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Device.Click

        Dim DeviceTag As String
        If devList.SelectedItem = Nothing Then
            Return
        End If
        DeviceTag = devList.SelectedItem

        message.Text = "Open Physical Device " + DeviceTag + " ..."
        Block.Enabled = False
        blockList.Items.Clear()

        Try
            If Not (CurDevice Is Nothing) Then
                CurDevice.Close()
            End If
            CurDevice = CurLink.GetDeviceByTag(DeviceTag)
            CurDevice.Open()
            CurVFD = CurDevice.GetVfdByOrdinalNumber(0)
            CurVFD.Open()
            Dim MyBlock As Block
            For Each MyBlock In CurVFD.Blocks
                blockList.Items.Add(MyBlock.Tag)
            Next
            message.Text += " successful"
        Catch ex As Exception
            message.Text = ex.Message
        End Try
        Block.Enabled = True

    End Sub

    Private Sub Block_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Block.Click
        Dim BlockTag As String
        If blockList.SelectedItem = Nothing Then
            Return
        End If
        BlockTag = blockList.SelectedItem

        message.Text = "Open Block" + BlockTag + " ..."
        Try
            If Not (CurBlock Is Nothing) Then
                CurBlock.Close()
            End If
            CurBlock = CurVFD.GetBlockByTag(BlockTag)
            CurBlock.Open()
            message.Text += " successful"
            Dim ParamForm As ReadWriteForm
            ParamForm = New ReadWriteForm(CurBlock)
            ParamForm.ShowDialog()
        Catch ex As Exception
            message.Text = ex.Message
        End Try
    End Sub
End Class
