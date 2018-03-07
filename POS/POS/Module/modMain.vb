Module modMain

    Public oConFig As New clsMain() '//Local class
    Public oService As New clsService   '//Database service
    Public oLang As New clsLangMsg  '//Language
    Public clsSetting As New mySetting(mySetting.Config.ApplicationFile) 'CSettings(False)
    ' Public REPORT_PATH As String = My.Settings.ReportPath.ToString.Trim
    Public User As String
    Public Level As String


    Public Sub MasterGridFormat(ByVal grdMain As Object) 'DataGridView
        Dim xFont As New Font(grdMain.font.name.ToString, 12, FontStyle.Regular)
        With grdMain
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 30
            .AllowUserToDeleteRows = False
            ' Initialize basic DataGridView properties.
            '.Dock = DockStyle.Fill
            .BackgroundColor = Color.LightGray
            .BorderStyle = BorderStyle.Fixed3D
            .AllowUserToResizeRows = False
            .font = xFont
            .GridColor = Color.White
            .BackgroundColor = Color.White
            .RowHeadersWidth = 15
            .RowsDefaultCellStyle.SelectionBackColor = Color.SteelBlue ' Color.LightSlateGray
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.SelectionForeColor = Color.White
            '.BorderStyle = BorderStyle.None
            .MultiSelect = False
            '.RowsDefaultCellStyle.BackColor = Color.LightGray
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue ' Color.DarkGray
        End With
    End Sub

    'Public Sub LoadComboBox_DataTable(ByVal comboTest As MTGCComboBox, ByVal dtLoading As DataTable, ByVal strColWidth As String)

    '    Dim nColumn As Integer = dtLoading.Columns.Count
    '    Dim strDataString As String()
    '    Dim i As Integer = 0

    '    ReDim strDataString(nColumn - 1)

    '    For i = 0 To dtLoading.Columns.Count - 1
    '        strDataString(i) = dtLoading.Columns.Item(i).ColumnName()
    '    Next
    '    Try

    '        comboTest.SelectedIndex = -1
    '        comboTest.Items.Clear()
    '        comboTest.ColumnNum = nColumn
    '        comboTest.ColumnWidth = strColWidth
    '        comboTest.LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
    '        comboTest.SourceDataString = strDataString
    '        comboTest.SourceDataTable = dtLoading
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try

    'End Sub

    'Public Sub setComboxStyle(ByVal cboTest As MTGCComboBox)
    '    cboTest.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
    '    cboTest.DropDownArrowBackColor = Color.DarkGray
    'End Sub

End Module

