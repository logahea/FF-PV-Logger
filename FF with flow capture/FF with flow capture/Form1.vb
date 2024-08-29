
Imports NationalInstruments.FieldBus
Imports NationalInstruments.FieldBus.ExceptionHandler
Imports System.Threading
Imports eFB_Wrapper
Imports eFB_Flash
Imports EFieldbus
Imports EFieldbusCommon
Imports ENiCFunc
Imports EFieldbusNi





Public Class Form1
    'Dim MainSession As Session = New Session
    Dim CurLink As Link
    Dim LinkTag As String = "interface0-0"
    Dim MyDevice As Device
    Dim DeviceTag As String = ""
    Dim CurDevice As Device
    Dim checkitagain As Label
    Dim CurVFD As Vfd
    Dim BlockTag As String = ""
    Dim MyBlock As Block
    Dim blockList As New List(Of String)
    Dim i As Integer = 0
    Dim blockName As String = ""
    Dim gotthetransducer As Label
    Dim CurBlock As Block
    Dim CurParam As Parameter
    Dim Elem As Element
    Dim Rp As RecordParameter
    Dim dataItem1 As String = ""
    Dim dataItem2 As String = ""
    Dim dataItem3 As String = ""
    Dim j As Integer
    Dim currentlyusedblock As Block
    Dim k As Integer = 0
    Dim stoppv As Boolean = False
    Dim endofpv As Label
    'Dim CurElement As Element
    Dim CurParameter As Parameter
    Dim readvalue As String = ""
    Dim nameofblock As String = ""
    Dim valuethatwasread As String = ""
    Dim writevalue As String = ""
    Dim nameofparameter As String = ""
    Dim buttonpressedwas As Integer = 0
    Dim out As IO.StreamWriter
    'Dim timestamp As String = DateTime.Now.ToString("HH" & "mm" & "ss")


    'Dim filename As String = "C:\testdata\" & timestamp & ".csv"
    Dim average As Decimal = 0
    Dim dataitem3asdecimal As Decimal = 0
    Dim totalvalue As Decimal = 0
    Dim POLL_TIME As Integer = 1








    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MainSession As Session = New Session

        MainSession.Open()
        CurLink = MainSession.GetLinkByTag(LinkTag)
        CurLink.Open()
        For Each MyDevice In CurLink.Devices
            ListBox1.Items.Add(MyDevice.Tag)
        Next
        ListBox1.Items.RemoveAt(0)
        Label1.Visible = True

    End Sub

    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Do

        Button4.Focus()

        My.Application.DoEvents()

        If stoppv = True Then
            stoppv = False
            GoTo endofpv

        End If
        DeviceTag = ListBox1.SelectedItem
        blockList.Clear()

        TextBox2.Text = DeviceTag
        TextBox2.Refresh()




        Try
            CurDevice = CurLink.GetDeviceByTag(DeviceTag)

        Catch
            MsgBox("            You MORON!!" & vbCrLf & "             You must select a transmitter from the list!")
            GoTo theveryend

        End Try

        CurDevice.Open()
        CurVFD = CurDevice.GetVfdByOrdinalNumber(0)
        CurVFD.Open()
        i = 0

        For Each MyBlock In CurVFD.Blocks
            blockList.Add(MyBlock.Tag)
            blockList.IndexOf("T", i)
            blockName = blockList(i)
            If blockName.Contains("T") Then
                GoTo gotthetransducer
            End If
            i = i + 1




        Next

gotthetransducer:
        TextBox3.Text = blockName
        TextBox3.Refresh()
        'from here down code is for reading PV
        CurBlock = CurVFD.GetBlockByTag(blockName)
        CurBlock.Open()


        CurParam = CurBlock.ReadParameterByName("PRIMARY_VALUE")
        RadioButton1.Checked = True

        If blockName.Length > 7 Then
            PictureBox2.Visible = True 'shows 8732
        Else
            PictureBox1.Visible = True 'shows 8800
        End If
        Button6.Enabled = True
        Button4.Enabled = True
        Rp = CurParam

        For Each Elem In Rp.Elements

            dataItem1 = Elem.Name
            dataItem2 = (Elem.Type.ToString())
            dataItem3 = (Elem.ValueString())


        Next

endofall:
        '  TextBox1.Text = dataItem3
        '  TextBox1.Refresh()
        '  TextBox4.Text = k
        'TextBox4.Refresh()


        k = k + 1

        currentlyusedblock = CurVFD.GetBlockByTag(blockName)
        ' MyBlock.Close()
        'MyBlock.Dispose()
        'CurVFD.Close()
        'CurVFD.Dispose()
        'CurBlock.Close()
        'CurBlock.Dispose()


endofpv:
        currentlyusedblock = CurVFD.GetBlockByTag(blockName)
        ' MyBlock.Close()
        ' MyBlock.Dispose()
        ' CurVFD.Close()
        'CurVFD.Dispose()
        'CurBlock.Close()
        ' CurBlock.Dispose()
theveryend:
    End Sub


    Public Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        stoppv = True

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HHmmss")  'DateTime.Now.ToString("HH" & "mm" & "ss")
        Dim filename As String = "C:\testdata\" & timestamp & ".csv"
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox10.Text = ""
        k = 1
        totalvalue = 0
        average = 0
        TextBox11.Text = filename
        out = My.Computer.FileSystem.OpenTextFileWriter(filename, True)
        out.WriteLine("Fieldbus PV, Time")
        GoTo tryhere
        ' Do

        'Button4.Focus()

        'My.Application.DoEvents()




        DeviceTag = ListBox1.SelectedItem


        Try
            CurDevice = CurLink.GetDeviceByTag(DeviceTag)

        Catch
            MsgBox("            You MORON!!" & vbCrLf & "             You must select a transmitter from the list!")
            GoTo theveryend

        End Try

        CurDevice.Open()
        CurVFD = CurDevice.GetVfdByOrdinalNumber(0)
        CurVFD.Open()
        i = 0

        For Each MyBlock In CurVFD.Blocks
            blockList.Add(MyBlock.Tag)
            blockList.IndexOf("TRANS", i)
            blockName = blockList(i)
            If blockName.Contains("TRANS") Then
                GoTo gotthetransducer
            End If
            i = i + 1




        Next

gotthetransducer:
        TextBox3.Text = blockName
        TextBox3.Refresh()
        'from here down code is for reading PV


tryhere:
        'CurBlock = CurVFD.GetBlockByTag(blockName)
        'CurBlock.Open()





        Do
            CurParam = CurBlock.ReadParameterByName("PRIMARY_VALUE")

            Button4.Focus()

            My.Application.DoEvents()
            Rp = CurParam

            For Each Elem In Rp.Elements

                dataItem1 = Elem.Name
                dataItem2 = (Elem.Type.ToString())
                dataItem3 = (Elem.ValueString())


            Next

endofall:
            TextBox1.Text = dataItem3
            TextBox1.Refresh()
            TextBox4.Text = k
            TextBox4.Refresh()



            totalvalue = totalvalue + dataItem3

            average = (totalvalue / k)
            average = Math.Round(average, 7, MidpointRounding.AwayFromZero)


            TextBox10.Text = average
            k = k + 1
            If stoppv = True Then
                stoppv = False
                GoTo endofpv
            End If

            out.WriteLine(Elem.ValueString(), DateTime.Now.ToString("yyyy-MM-dd HHmmss")) 'TextBox1.Text
            Thread.Sleep(POLL_TIME)
        Loop



        currentlyusedblock = CurVFD.GetBlockByTag(blockName)

endofpv:
        currentlyusedblock = CurVFD.GetBlockByTag(blockName)

theveryend:
        out.Close()

    End Sub

   

   

  


    

   

    Private Sub Form1_close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        'stoppv = True
        'Button4.PerformClick()
        System.Threading.Thread.Sleep(3000)

        ' Handles no button pressed closing 

        If stoppv = False And k > 1 Then
            out.Close()
        End If

        Process.Start("killnifb.bat")
        ' Process.Start("C:\Program Files\National Instruments\NI-FBUS\killnifb.exe")

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        RadioButton1.Checked = False
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        Button6.Enabled = False
        Button4.Enabled = False


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim proc As Process
        proc = Process.Start("C:\Program Files (x86)\National Instruments\NI-FBUS\Binaries\nifb.exe")
        proc.WaitForInputIdle()

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged



        POLL_TIME = 1000 * (NumericUpDown1.Value) 'value * 1000 for ms


    End Sub

End Class
