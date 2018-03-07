Option Strict On
Public Class clsMain

    Dim clsSetting As New mySetting(mySetting.Config.ApplicationFile)

    Dim nVatType As Byte = 0  '// 0= Include ,1=Exclude ,2 No vat
    Dim nVatRate As Single = 7.0 '//Vat rate
    Dim strSecurityKey As String = "SAHARUT-YOURPOS"


    Public Function User() As String
        'Return "Admin"
        Return CType(clsSetting.GetSetting("User"), String)
        'Return AWMS_USER_CODE
    End Function

    Public Function UserName() As String
        'Return "Admin"
        Return CType(clsSetting.GetSetting("UserName"), String)
        'Return AWMS_USER_CODE
    End Function

    Public Function gReportPath() As String
        Dim strReturn As String '= CType(clsSetting.GetSetting("reportpath"), String)
        strReturn = Application.StartupPath & "\"
        If strReturn.Substring(strReturn.Length - 1, 1) <> "\" Then strReturn += "\"
        Return strReturn
    End Function

    Public Function db2Date(ByVal sDate As Object) As Date
        Dim nDif As Integer = 0
        If IsDate(sDate) = False Then sDate = Today.Year & Today.ToString("-MM-dd")
        If Year(Now) <> Today.Year Then nDif = 543
        If IsDBNull(sDate) Then
            Return Nothing
        Else
            Return DateSerial(CInt(sDate.ToString.Substring(0, 4)) + nDif, CInt(sDate.ToString.Substring(5, 2)), CInt(sDate.ToString.Substring(8, 2)))
        End If
    End Function

    Public Function Date2db(ByVal sDate As Date) As String
        Dim sYear As Integer
        'Dim nDif As Integer = 0
        'If Year(Now) <> Today.Year Then nDif = 543
        If IsDate(sDate) = False Then
            Return ""
        Else
            sYear = sDate.Year
            If sYear > 2500 Then sYear = sYear - 543
            Return sYear & Format(sDate.Month, "-0#") & Format(sDate.Day, "-0#")
        End If
    End Function

    Public Function Bool2Int(ByVal bData As Boolean) As Integer
        If bData Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Function Int2Bool(ByVal iData As Integer) As Boolean
        If iData = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getAppPath() As String
        Dim s As String
        Dim _AlternatePath As String = String.Empty
        If _AlternatePath.Length = 0 Then
            s = IO.Path.GetDirectoryName( _
               Reflection.Assembly.GetExecutingAssembly.Location())
        Else
            s = IO.Path.GetDirectoryName(_AlternatePath)
        End If
        Return s
    End Function

    Public Function getKeys() As String
        Return strSecurityKey
    End Function

    Public Sub StdGridFormat(ByVal grdMain As DataGridView)
        Dim xFont As New Font(grdMain.Font.Name.ToString, 10, FontStyle.Regular)
        With grdMain
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 25
            .RowHeadersWidth = 20
            .AllowUserToResizeRows = False
            ' Initialize basic DataGridView properties.
            '.Dock = DockStyle.Fill
            .BackgroundColor = Color.White    'Color.LightGray
            .BorderStyle = BorderStyle.None
            .Font = xFont
            .GridColor = Color.Gray
            .RowsDefaultCellStyle.SelectionBackColor = Color.SteelBlue   ' Color.LightSlateGray
            .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect 'DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowsDefaultCellStyle.BackColor = Color.LightGray
            .AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray
        End With
    End Sub

    Public Sub DrawGradient(ByVal color1 As Color, ByVal color2 As Color, ByVal mode As System.Drawing.Drawing2D.LinearGradientMode, ByVal objPn As Panel)
        Dim a As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, objPn.Width, objPn.Height), color1, color2, mode)
        Dim g As Graphics = objPn.CreateGraphics
        g.FillRectangle(a, New RectangleF(0, 0, objPn.Width, objPn.Height))
        g.Dispose()
    End Sub


    Private Sub DrawGradientString(ByVal text As String, ByVal color1 As Color, ByVal color2 As Color, ByVal mode As System.Drawing.Drawing2D.LinearGradientMode)
        Dim a As New System.Drawing.Drawing2D.LinearGradientBrush(New RectangleF(0, 0, 100, 19), color1, color2, mode)
        Dim g As Graphics '= Me.CreateGraphics
        Dim f As Font
        f = New Font("arial", 20, FontStyle.Bold, GraphicsUnit.Pixel)
        g.DrawString(text, f, a, 0, 0)
        g.Dispose()
    End Sub


    Public Function Bath2Text(ByVal nParameter As String) As String
        Dim strReturn As String = ""
        Dim strStang As String = ""
        Dim i As Integer
        Dim nPOS As Integer
        Dim cNumber As New Collection
        Dim cUnit As New Collection
        Dim nBefor As String = Split(nParameter.ToString, ".")(0)

        Try
            cNumber.Add("หนึ่ง", "1")
            cNumber.Add("สอง", "2")
            cNumber.Add("สาม", "3")
            cNumber.Add("สี่", "4")
            cNumber.Add("ห้า", "5")
            cNumber.Add("หก", "6")
            cNumber.Add("เจ็ด", "7")
            cNumber.Add("แป็ด", "8")
            cNumber.Add("เก้า", "9")
            cNumber.Add("ศูนย์", "0")

            cUnit.Add("", "1")
            cUnit.Add("สิบ", "2")
            cUnit.Add("ร้อย", "3")
            cUnit.Add("พัน", "4")
            cUnit.Add("หมื่น", "5")
            cUnit.Add("แสน", "6")
            cUnit.Add("ล้าน", "7")
            cUnit.Add("สิบ", "8")
            cUnit.Add("ร้อย", "9")
            cUnit.Add("พัน", "10")
            cUnit.Add("หมื่น", "11")

            nPOS = 1
            For i = nBefor.Length - 1 To 0 Step -1
                If nBefor(i).ToString <> "0" Then
                    If nPOS = 1 And nBefor.Length > 1 And nBefor(i).ToString = "1" Then  '//หลักหน่วย
                        strReturn = "เอ็ด" 'cNumber(nBefor(i).ToString).ToString
                    ElseIf nPOS = 2 And nBefor.Length > 1 And nBefor(i).ToString = "1" Then '//หลักสิบ
                        strReturn = cUnit(nPOS.ToString).ToString & strReturn
                    ElseIf nPOS = 2 And nBefor.Length > 1 And nBefor(i).ToString = "2" Then '//หลักสิบ
                        strReturn = "ยี่" & cUnit(nPOS.ToString).ToString & strReturn
                    ElseIf nPOS = 7 And nBefor.Length > 7 And nBefor(i).ToString = "1" Then  '//หลักล้าน
                        strReturn = "เอ็ด" & cUnit(nPOS.ToString).ToString & strReturn
                    ElseIf nPOS = 8 And nBefor.Length > 7 And nBefor(i).ToString = "1" Then '//หลักสิบ
                        strReturn = cUnit(nPOS.ToString).ToString & strReturn
                    ElseIf nPOS = 8 And nBefor.Length > 7 And nBefor(i).ToString = "2" Then '//หลักสิบ
                        strReturn = "ยี่" & cUnit(nPOS.ToString).ToString & strReturn
                    Else
                        strReturn = cNumber(nBefor(i).ToString).ToString & cUnit(nPOS.ToString).ToString & strReturn
                    End If
                Else
                    If nPOS = 1 And nBefor.Length = 1 And nBefor(i).ToString = "0" Then  '//หลักหน่วย
                        strReturn = cNumber(nBefor(i).ToString).ToString
                    End If
                End If
                nPOS += 1
            Next


            strReturn = strReturn & "บาท"

            '//ทศนิยม
            If nParameter.ToString.IndexOf(".") > 0 Then
                Dim nAfter As String = Split(nParameter.ToString, ".")(1)

                nPOS = 1
                For i = nAfter.Length - 1 To 0 Step -1
                    If nAfter(i).ToString <> "0" Then
                        If nPOS = 1 And nAfter.Length > 1 And nAfter(i).ToString = "1" Then  '//หลักหน่วย
                            strStang = "เอ็ด" 'cNumber(nBefor(i).ToString).ToString
                        ElseIf nPOS = 2 And nAfter.Length > 1 And nAfter(i).ToString = "1" Then '//หลักสิบ
                            strStang = cUnit(nPOS.ToString).ToString & strStang
                        ElseIf nPOS = 2 And nAfter.Length > 1 And nAfter(i).ToString = "2" Then '//หลักสิบ
                            strStang = "ยี่" & cUnit(nPOS.ToString).ToString & strStang
                        Else
                            strStang = cNumber(nAfter(i).ToString).ToString & cUnit(nPOS.ToString).ToString & strStang
                        End If
                        'Else
                        '    If nPOS = 1 And nBefor.Length = 1 And nBefor(i).ToString = "0" Then  '//หลักหน่วย
                        '        strStang = cNumber(nBefor(i).ToString).ToString
                        '    End If
                    End If
                    nPOS += 1
                Next
                If strStang.Trim <> "" Then strStang = strStang & "สตางค์"
            End If

            strReturn = strReturn & strStang

            '            MessageBox.Show(strReturn)

        Catch ex As Exception

        End Try
        Return strReturn
    End Function

    '//88888888888888888888888888888888888 Start for this project only 88888888888888888888888888888888888888
    Public Function VatRate() As Single
        Return nVatRate
    End Function

    Public Function VateType() As Byte
        Return nVatType
    End Function

    Public Function getSecurityKey() As String
        Return strSecurityKey
    End Function

    Public Function getMemTypName(ByVal sTypeId As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "Select TypeId,TypeName from tb_mas_cust_type where TypeId='" & sTypeId & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("TypeName").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getBranchName(ByVal sBranchId As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "Select BranchId,BranchName from tb_mas_branch where BranchId='" & sBranchId & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("BranchName").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getAccType(ByVal sAcctypeId As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "Select Dep_TypeId,Dep_TypeName from TB_MAS_DEP_TYPE where Dep_TypeId='" & sAcctypeId & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("Dep_TypeName").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getFunName(ByVal strFunCode As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "SELECT makecap_typeId,makecap_typeName from tb_mas_makecap_type where makecap_typeId='" & strFunCode & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("makecap_typeName").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getFunMemName(ByVal strMemId As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "Select AccNo,  Name FROM  v004_MAKECAP_MEMBER where AccNo='" & strMemId & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("Name").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getUserName(ByVal strUserId As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "Select UserId,  UserName FROM  tb_mas_user where UserId='" & strUserId & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("UserName").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getMemberName(ByVal strMemId As String) As String
        Dim strReturn As String = ""
        Try
            If strMemId = "" Then strMemId = "XXX"
            Dim oDataset As New DataSet
            Dim strSql As String = "Select MemberId,  Name FROM  tb_mas_contact where contactid='" & strMemId & "' or MemberId='" & strMemId & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("Name").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getmembergrade(ByVal strMemId As String) As String
        Dim strReturn As String = ""
        Try
            If strMemId = "" Then strMemId = "XXX"
            Dim oDataset As New DataSet
            Dim strSql As String = "SELECT CustGrade FROM  TB_MAS_LOAN_MEM_GRADE WHERE  (CustId = N'" & strMemId & "')"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("CustGrade").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getMemberGroupByCust(ByVal strMemId As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "Select MemType FROM  tb_mas_contact where MemberId='" & strMemId & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("MemType").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function checkExistContact(ByVal strContactid As String) As Boolean
        Dim strReturn As Boolean = False
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "Select ContactId FROM  tb_mas_contact where contactid='" & strContactid & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    'strReturn = oDataset.Tables(0).Rows(0).Item("UserName").ToString
                    strReturn = True
                Else
                    strReturn = False
                End If
            End If
        Catch ex As Exception
            strReturn = True
        End Try

        Return strReturn
    End Function

    Public Function BranchId() As String
        Return CType(clsSetting.GetSetting("BranchId"), String)
    End Function

    Public Function BranchName() As String
        Return CType(clsSetting.GetSetting("BranchName"), String)
    End Function

    Public Sub ShellandWait(ByVal processPath As String)
        'Dim objProcess As System.Diagnostics.Process

        Try
            'objProcess = New System.Diagnostics.Process
            'objProcess.StartInfo.FileName = processPath
            'objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
            'objProcess.Start()
            'objProcess.WaitForExit()
            'objProcess.Close()

            Shell("calc.exe")

        Catch ex As Exception

            MsgBox("Can not open File " & processPath, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Function TerminateProcess(ByVal strProcess As String) As Boolean

        Dim p As Process
        Try
            For Each p In Process.GetProcesses
                'MsgBox(p.ProcessName)
                If p.ProcessName.ToUpper = strProcess.ToUpper Then
                    p.Kill()
                    Exit For
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function getBeginDate(ByVal dCurDate As Date) As String
        Dim sReturn As String = ""
        Try
            If dCurDate.Month < 4 Then '//เมษา
                sReturn = dCurDate.Year - 1 & "-04-01"       '// 1 เมษาปีที่แล้ว
            Else
                sReturn = dCurDate.Year & "-04-01"       '// 1 เมษาปีนี้
            End If
        Catch ex As Exception

        End Try

        Return sReturn

    End Function

    Public Function getAddName1(ByVal strAdd1 As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "SELECT Add1,AddName1 from TB_MAS_LOAN_LAND_ADD where Add1='" & strAdd1 & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("AddName1").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getLandType(ByVal strLandType As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "SELECT  LandType, LandtypeName FROM    TB_MAS_LOAN_LAND_TYPE where LandType='" & strLandType & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("LandtypeName").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getLandGroup(ByVal strLandGroup As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "SELECT  LandGroup, LandGroupName FROM    TB_MAS_LOAN_LAND_GROUP where LandGroup='" & strLandGroup & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("LandGroupName").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

    Public Function getLoanProjectName(ByVal sProject As String) As String
        Dim strReturn As String = ""
        Try
            Dim oDataset As New DataSet
            Dim strSql As String = "select PrjNo,PrjName from tb_mas_loan_project where PrjNo='" & sProject & "'"
            oDataset = oService.getDataSet(strSql)
            If oDataset.Tables.Count > 0 Then
                If oDataset.Tables(0).Rows.Count > 0 Then
                    strReturn = oDataset.Tables(0).Rows(0).Item("PrjName").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strReturn
    End Function

End Class

