Imports Microsoft.VisualBasic
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class clsZPL

    Public Class RawPrinterHelper
        ' Structure and API declarions: 
        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
        Public Class DOCINFOA
            <MarshalAs(UnmanagedType.LPStr)> _
            Public pDocName As String
            <MarshalAs(UnmanagedType.LPStr)> _
            Public pOutputFile As String
            <MarshalAs(UnmanagedType.LPStr)> _
            Public pDataType As String
        End Class
        <DllImport("winspool.Drv", EntryPoint:="OpenPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function OpenPrinter(<MarshalAs(UnmanagedType.LPStr)> ByVal szPrinter As String, ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
        End Function

        <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
        End Function

        <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal di As DOCINFOA) As Boolean
        End Function

        <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
        End Function

        <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
        End Function

        <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
        End Function

        <DllImport("winspool.Drv", EntryPoint:="WritePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
        End Function

        ' SendBytesToPrinter() 
        ' When the function is given a printer name and an unmanaged array 
        ' of bytes, the function sends those bytes to the print queue. 
        ' Returns true on success, false on failure. 
        Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
            Dim dwError As Int32 = 0, dwWritten As Int32 = 0
            Dim hPrinter As New IntPtr(0)
            Dim di As New DOCINFOA()
            Dim bSuccess As Boolean = False
            ' Assume failure unless you specifically succeed. 
            di.pDocName = "UU Document"
            di.pDataType = "RAW"

            ' Open the printer. 
            If OpenPrinter(szPrinterName, hPrinter, 0) Then
                ' Start a document. 
                If StartDocPrinter(hPrinter, 1, di) Then
                    ' Start a page. 
                    If StartPagePrinter(hPrinter) Then
                        ' Write your bytes. 
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                        EndPagePrinter(hPrinter)
                    End If
                    EndDocPrinter(hPrinter)
                End If
                ClosePrinter(hPrinter)
            End If
            ' If you did not succeed, GetLastError may give more information 
            ' about why not. 
            If bSuccess = False Then
                dwError = Marshal.GetLastWin32Error()
            End If
            Return bSuccess
        End Function



        Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String) As Boolean
            Dim pBytes As IntPtr
            Dim dwCount As Int32
            ' How many characters are in the string? 
            dwCount = szString.Length
            ' Assume that the printer is expecting ANSI text, and then convert 
            ' the string to ANSI text. 
            pBytes = Marshal.StringToCoTaskMemAnsi(szString)
            ' Send the converted ANSI string to the printer. 
            SendBytesToPrinter(szPrinterName, pBytes, dwCount)
            Marshal.FreeCoTaskMem(pBytes)
            Return True
        End Function
    End Class


    Public Function formatOut(ByVal barcode1 As String, ByVal barcode2 As String, _
    ByVal assetName1 As String, ByVal assetName2 As String, ByVal accOld1 As String, ByVal accOld2 As String, _
 ByVal loc1_1 As String, ByVal loc1_2 As String, _
    ByVal loc2_1 As String, ByVal loc2_2 As String, ByVal loc3_1 As String, ByVal loc3_2 As String) As String

        Dim str As String

        str = "~SD30" & vbCrLf
        str += "^XA^LH0,0" & vbCrLf
        str += "^ci24^cw1,e:angsana.fnt^fs" & vbCrLf

        'str += "^ci24^cw1,e:ms sans serif.fnt^fs" & vbCrLf
        str += "^PW1200" & vbCrLf

        str += "^FO10,30" & vbCrLf
        str += "^BXN,4,50" & vbCrLf
        str += "^FD" & barcode1 & "^FS" & vbCrLf

        str += "^FO620,30" & vbCrLf
        str += "^BXN,4,50" & vbCrLf
        str += "^FD" & barcode2 & "^FS" & vbCrLf

        '######### LOGO

        str += "^FO430,30^XGE:UB.GRF,1,1^FS" & vbCrLf
        str += "^FO1030,30^XGE:UB.GRF,1,1^FS" & vbCrLf

        ' ###### รหัสบาร์โค้ด

        str += "^FO120,30" & vbCrLf
        str += "^A1N,40,40" & vbCrLf
        str += "^FD" & barcode1 & "^FS" & vbCrLf

        str += "^FO740,30" & vbCrLf
        str += "^A1N,40,40" & vbCrLf
        str += "^FD" & barcode2 & "^FS" & vbCrLf

        '####### รหัสบัญชีเก่า

        str += "^FO120,80" & vbCrLf
        str += "^A1N,40,40" & vbCrLf
        str += "^FDรหัส: " & accOld1 & "^FS" & vbCrLf

        str += "^FO740,80" & vbCrLf
        str += "^A1N,40,40" & vbCrLf
        str += "^FDรหัส: " & accOld2 & "^FS" & vbCrLf

        ' ####### ชื่อสินทรัพย์

        str += "^FO10,120" & vbCrLf
        str += "^A1N,30,30" & vbCrLf
        str += "^FD" & assetName1 & "^FS" & vbCrLf

        str += "^FO620,120" & vbCrLf
        str += "^A1N,30,30" & vbCrLf
        str += "^FD" & assetName2 & "^FS" & vbCrLf

        ' ##########  Loc1


        str += "^FO10,150" & vbCrLf
        str += "^A1N,30,30" & vbCrLf
        str += "^FDLOC1 :" & loc1_1 & "^FS" & vbCrLf

        str += "^FO620,150" & vbCrLf
        str += "^A1N,30,30" & vbCrLf
        str += "^FDLOC1 :" & loc1_2 & "^FS" & vbCrLf

        ' ##########  Loc2


        str += "^FO10,180" & vbCrLf
        str += "^A1N,30,30" & vbCrLf
        str += "^FDLOC2 : " & loc2_1 & "^FS" & vbCrLf

        str += "^FO620,180" & vbCrLf
        str += "^A1N,30,30" & vbCrLf
        str += "^FDLOC2 : " & loc2_2 & "^FS" & vbCrLf



        ' ##########  Loc3


        str += "^FO10,210" & vbCrLf
        str += "^A1N,30,30" & vbCrLf
        str += "^FDLOC3 : " & loc3_1 & "^FS" & vbCrLf

        str += "^FO620,210" & vbCrLf
        str += "^A1N,30,30" & vbCrLf
        str += "^FDLOC3 : " & loc3_2 & "^FS" & vbCrLf




        str += "^ci0" & vbCrLf
        str += "^XZ"
        Return str
    End Function



    Public Function formatOut2(ByVal barcode As String, _
    ByVal assetName As String, _
 ByVal loc1 As String) As String

        Dim str As String



        str = "^XA^LH0,0^PW712" & vbCrLf


        str += "^FO80,50" & vbCrLf
        str += "^A1N,15,15" & vbCrLf
        str += "^FD SOMBUT ENGINEERING CO.,LTD.^FS" & vbCrLf

        str += "^FO180,80" & vbCrLf
        str += "^A1N,15,15" & vbCrLf
        str += "^FD TEL 02-536-5005^FS" & vbCrLf


        str += "^FO80,130" & vbCrLf
        str += "^B3N,N,100,Y,N" & vbCrLf
        str += "^FD" & barcode & "^FS" & vbCrLf


        str += "^FO80,280" & vbCrLf
        str += "^A1N,15,15" & vbCrLf
        str += "^FD NAME: " & assetName & "^FS" & vbCrLf


        str += "^FO80,340" & vbCrLf
        str += "^A1N,15,15" & vbCrLf
        str += "^FD LOC: " & loc1 & "^FS"

        str += "^XZ"

        Return str


    End Function
    Public Sub printOut(ByVal barcode1 As String, ByVal barcode2 As String, _
    ByVal assetName1 As String, ByVal assetName2 As String, _
    ByVal accOld1 As String, ByVal accOld2 As String, _
    ByVal loc1_1 As String, ByVal loc1_2 As String, _
    ByVal loc2_1 As String, ByVal loc2_2 As String, ByVal loc3_1 As String, ByVal loc3_2 As String)

        Try
            Dim str As String
            str = formatOut(barcode1, barcode2, assetName1, assetName2, accOld1, accOld2, loc1_1, loc1_2, loc2_1, loc2_2, loc3_1, loc3_2)
            Dim dialog As New Windows.Forms.PrintDialog()
            dialog.PrinterSettings = New Printing.PrinterSettings()
            '    If dialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            RawPrinterHelper.SendStringToPrinter(dialog.PrinterSettings.PrinterName, str)
            '   End If
        Catch ex As Exception

        End Try

    End Sub




    Public Sub printOut2(ByVal barcode1 As String, ByVal assetName1 As String, ByVal loc1 As String)

        Try
            Dim str As String
            str = formatOut2(barcode1, assetName1, loc1)
            Dim dialog As New Windows.Forms.PrintDialog()
            dialog.PrinterSettings = New Printing.PrinterSettings()
            '    If dialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            RawPrinterHelper.SendStringToPrinter(dialog.PrinterSettings.PrinterName, str)
            '  End If
        Catch ex As Exception

        End Try

    End Sub

End Class

