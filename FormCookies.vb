Imports System.Data
Imports System.IO

Public Class FormCookies
    Private cookiesTable As DataTable
    
    Private Sub FormCookies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set window properties
        Me.Text = "PerfectPair - Perfect Cookies for Your Drink"
        Me.Size = New Size(900, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(252, 248, 227)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        
        CreateUI()
        LoadCookiesData()
    End Sub
    
    Private Sub CreateUI()
        ' Create title label
        Dim lblTitle As New Label()
        lblTitle.Text = "Perfect Cookies for Your " & GlobalVariables.SelectedDrinkName
        lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(101, 67, 33)
        lblTitle.Size = New Size(800, 40)
        lblTitle.Location = New Point(50, 20)
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(lblTitle)
        
        ' Create subtitle
        Dim lblSubtitle As New Label()
        lblSubtitle.Text = "Based on your " & GlobalVariables.SelectedDrinkCategory.ToLower() & " drink preference, here are our recommendations:"
        lblSubtitle.Font = New Font("Segoe UI", 12, FontStyle.Italic)
        lblSubtitle.ForeColor = Color.FromArgb(139, 115, 85)
        lblSubtitle.Size = New Size(800, 30)
        lblSubtitle.Location = New Point(50, 65)
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(lblSubtitle)
        
        ' Create cookies panel (scrollable)
        Dim cookiesPanel As New Panel()
        cookiesPanel.Name = "cookiesPanel"
        cookiesPanel.Size = New Size(800, 480)
        cookiesPanel.Location = New Point(50, 110)
        cookiesPanel.BackColor = Color.Transparent
        cookiesPanel.AutoScroll = True
        Me.Controls.Add(cookiesPanel)
        
        ' Create action buttons panel
        Dim actionPanel As New Panel()
        actionPanel.Size = New Size(800, 60)
        actionPanel.Location = New Point(50, 600)
        actionPanel.BackColor = Color.Transparent
        Me.Controls.Add(actionPanel)
        
        ' Create back button
        Dim btnBack As New Button()
        btnBack.Text = "Back to Drinks"
        btnBack.Font = New Font("Segoe UI", 10)
        btnBack.Size = New Size(120, 35)
        btnBack.Location = New Point(20, 15)
        btnBack.BackColor = Color.Gray
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.Cursor = Cursors.Hand
        AddHandler btnBack.Click, AddressOf BtnBack_Click
        actionPanel.Controls.Add(btnBack)
        
        ' Create new selection button
        Dim btnNewSelection As New Button()
        btnNewSelection.Text = "New Selection"
        btnNewSelection.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        btnNewSelection.Size = New Size(150, 40)
        btnNewSelection.Location = New Point(325, 10)
        btnNewSelection.BackColor = Color.FromArgb(101, 67, 33)
        btnNewSelection.ForeColor = Color.White
        btnNewSelection.FlatStyle = FlatStyle.Flat
        btnNewSelection.FlatAppearance.BorderSize = 0
        btnNewSelection.Cursor = Cursors.Hand
        AddHandler btnNewSelection.Click, AddressOf BtnNewSelection_Click
        actionPanel.Controls.Add(btnNewSelection)
        
        ' Create exit button
        Dim btnExit As New Button()
        btnExit.Text = "Exit"
        btnExit.Font = New Font("Segoe UI", 10)
        btnExit.Size = New Size(80, 35)
        btnExit.Location = New Point(700, 15)
        btnExit.BackColor = Color.FromArgb(192, 57, 43)
        btnExit.ForeColor = Color.White
        btnExit.FlatStyle = FlatStyle.Flat
        btnExit.FlatAppearance.BorderSize = 0
        btnExit.Cursor = Cursors.Hand
        AddHandler btnExit.Click, AddressOf BtnExit_Click
        actionPanel.Controls.Add(btnExit)
    End Sub
    
    Private Sub LoadCookiesData()
        Try
            ' Load recommended cookies based on selected drink category
            LoadRecommendedCookies()
            DisplayCookies()
            
        Catch ex As Exception
            MessageBox.Show("Error loading cookies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub LoadRecommendedCookies()
        Try
            ' Load recommended cookies based on selected drink ID using new pairing system
            Dim drinkId As Integer = GlobalVariables.SelectedDrinkId
            Dim databaseResult As DataTable
            
            If drinkId > 0 Then
                ' Use new pairing system based on drink ID
                databaseResult = DatabaseManagerSimple.GetCookieRecommendationsByDrinkId(drinkId)
            Else
                ' Fallback to showing all cookies jika tidak ada pairing
                databaseResult = DatabaseManagerSimple.LoadCookiesData()
                ' Transform to expected format with default values
                Dim fallbackTable As New DataTable()
                fallbackTable.Columns.Add("id", GetType(Integer))
                fallbackTable.Columns.Add("name", GetType(String))
                fallbackTable.Columns.Add("type", GetType(String))
                fallbackTable.Columns.Add("description", GetType(String))
                fallbackTable.Columns.Add("image_path", GetType(String))
                fallbackTable.Columns.Add("match_score", GetType(Integer))
                fallbackTable.Columns.Add("pairing_reason", GetType(String))
                
                For Each row As DataRow In databaseResult.Rows
                    Dim newRow As DataRow = fallbackTable.NewRow()
                    newRow("id") = row("id")
                    newRow("name") = row("name")
                    newRow("type") = row("type")
                    newRow("description") = row("description")
                    newRow("image_path") = row("image_path")
                    newRow("match_score") = 50  ' Default score
                    newRow("pairing_reason") = "General recommendation"
                    fallbackTable.Rows.Add(newRow)
                Next
                databaseResult = fallbackTable
            End If
            
            ' Use recommended cookies data directly
            If databaseResult IsNot Nothing AndAlso databaseResult.Rows.Count > 0 Then
                cookiesTable = databaseResult.Copy()
            Else
                LoadFallbackCookies()
            End If
            
        Catch ex As Exception
            ' If database error, use fallback data
            LoadFallbackCookies()
        End Try
    End Sub
    
    Private Sub LoadFallbackCookies()
        ' Fallback: load all cookies from DatabaseManagerSimple
        cookiesTable = DatabaseManagerSimple.LoadCookiesData()
    End Sub
    
    Private Sub DisplayCookies()
        Dim cookiesPanel As Panel = CType(Me.Controls("cookiesPanel"), Panel)
        cookiesPanel.Controls.Clear()
        
        ' Get all cookies rows
        Dim sortedRows() As DataRow = cookiesTable.Select()
        
        Dim cardWidth As Integer = 200
        Dim cardHeight As Integer = 280
        Dim margin As Integer = 20
        Dim cardsPerRow As Integer = 3
        
        For i As Integer = 0 To sortedRows.Length - 1
            Dim row As DataRow = sortedRows(i)
            
            ' Calculate position
            Dim col As Integer = i Mod cardsPerRow
            Dim rowIndex As Integer = i \ cardsPerRow
            Dim x As Integer = col * (cardWidth + margin) + margin + 50
            Dim y As Integer = rowIndex * (cardHeight + margin) + margin
            
            ' Create cookie card
            Dim cookieCard As New Panel()
            cookieCard.Size = New Size(cardWidth, cardHeight)
            cookieCard.Location = New Point(x, y)
            cookieCard.BackColor = Color.White
            cookieCard.BorderStyle = BorderStyle.FixedSingle
            cookieCard.Tag = row("ID")
            
            ' Cookie image
            Dim picImage As New PictureBox()
            picImage.Size = New Size(cardWidth - 20, 100)
            picImage.Location = New Point(10, 10)
            picImage.SizeMode = PictureBoxSizeMode.Zoom
            picImage.BackColor = Color.Transparent
            
            ' *** CARA MENAMBAHKAN GAMBAR COOKIES ***
            ' 1. Letakkan file gambar (.jpg, .png) di folder 'perfect_pair' 
            ' 2. Pastikan nama file sesuai dengan yang ada di DatabaseManagerSimple.vb
            ' 3. Contoh: chocolate_chip.jpg, oatmeal.jpg, biscotti.jpg
            
            ' Load image from perfect_pair folder
            Dim imagePathRaw As String = row("image_path").ToString()
            Dim imagePath As String = Path.Combine(Application.StartupPath, "perfect_pair", imagePathRaw)
            
            ' Try to load the actual image file
            If File.Exists(imagePath) Then
                Try
                    ' Load image successfully
                    picImage.Image = Image.FromFile(imagePath)
                    cookieCard.Controls.Add(picImage)
                Catch ex As Exception
                    ' File exists but corrupted, use emoji fallback
                    GoTo UseCookieEmojiIcon
                End Try
            Else
                ' File doesn't exist, use emoji fallback
                GoTo UseCookieEmojiIcon
            End If
            
            ' Skip emoji fallback if image loaded successfully
            GoTo SkipCookieEmojiIcon
            
UseCookieEmojiIcon:
            ' Use emoji icon as fallback when image file not found
            Dim lblIcon As New Label()
            lblIcon.Text = "🍪"
            lblIcon.Font = New Font("Segoe UI", 48)
            lblIcon.Size = picImage.Size
            lblIcon.Location = picImage.Location
            lblIcon.TextAlign = ContentAlignment.MiddleCenter
            lblIcon.BackColor = Color.Transparent
            cookieCard.Controls.Add(lblIcon)
            
SkipCookieEmojiIcon:
            

            
            ' Cookie name
            Dim lblName As New Label()
            lblName.Text = row("name").ToString()
            lblName.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            lblName.ForeColor = Color.FromArgb(101, 67, 33)
            lblName.Size = New Size(cardWidth - 20, 25)
            lblName.Location = New Point(10, 120)
            lblName.TextAlign = ContentAlignment.MiddleCenter
            lblName.BackColor = Color.Transparent
            cookieCard.Controls.Add(lblName)
            
            ' Cookie type
            Dim lblType As New Label()
            lblType.Text = row("type").ToString()
            lblType.Font = New Font("Segoe UI", 9, FontStyle.Italic)
            lblType.ForeColor = Color.FromArgb(139, 115, 85)
            lblType.Size = New Size(cardWidth - 20, 20)
            lblType.Location = New Point(10, 145)
            lblType.TextAlign = ContentAlignment.MiddleCenter
            lblType.BackColor = Color.Transparent
            cookieCard.Controls.Add(lblType)
            
            ' Description
            Dim lblDescription As New Label()
            lblDescription.Text = row("description").ToString()
            lblDescription.Font = New Font("Segoe UI", 9)
            lblDescription.ForeColor = Color.Gray
            lblDescription.Size = New Size(cardWidth - 20, 40)
            lblDescription.Location = New Point(10, 170)
            lblDescription.TextAlign = ContentAlignment.TopCenter
            lblDescription.BackColor = Color.Transparent
            cookieCard.Controls.Add(lblDescription)
            
            ' Match score and pairing reason (if available from new pairing system)
            Dim lblMatchInfo As New Label()
            If cookiesTable.Columns.Contains("match_score") AndAlso Not IsDBNull(row("match_score")) Then
                Dim matchScore As Integer = CInt(row("match_score"))
                Dim pairingReason As String = row("pairing_reason").ToString()
                
                ' Show match score with color coding
                Dim scoreColor As Color = GetMatchScoreColor(matchScore)
                lblMatchInfo.Text = "Match: " & matchScore & "%" & vbCrLf & pairingReason
                lblMatchInfo.ForeColor = scoreColor
            Else
                ' Fallback to generic recommendation
                Dim cookieType As String = row("type").ToString()
                Dim recommendationText As String = GetRecommendationText(cookieType, GlobalVariables.SelectedDrinkCategory)
                lblMatchInfo.Text = "Perfect with: " & recommendationText
                lblMatchInfo.ForeColor = Color.FromArgb(101, 67, 33)
            End If
            
            lblMatchInfo.Font = New Font("Segoe UI", 8, FontStyle.Bold)
            lblMatchInfo.Size = New Size(cardWidth - 20, 50)
            lblMatchInfo.Location = New Point(10, 210)
            lblMatchInfo.TextAlign = ContentAlignment.TopCenter
            lblMatchInfo.BackColor = Color.Transparent
            cookieCard.Controls.Add(lblMatchInfo)
            
            cookiesPanel.Controls.Add(cookieCard)
        Next
        
        ' Add recommendation message
        If sortedRows.Length > 0 Then
            Dim lblRecommendation As New Label()
            lblRecommendation.Text = "We found " & sortedRows.Length & " perfect cookie matches for your " & GlobalVariables.SelectedDrinkName & "!"
            lblRecommendation.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            lblRecommendation.ForeColor = Color.FromArgb(101, 67, 33)
            lblRecommendation.Size = New Size(700, 30)
            lblRecommendation.Location = New Point(50, sortedRows.Length \ 3 * (cardHeight + margin) + margin + 20)
            lblRecommendation.TextAlign = ContentAlignment.MiddleCenter
            lblRecommendation.BackColor = Color.FromArgb(252, 248, 227)
            cookiesPanel.Controls.Add(lblRecommendation)
        End If
    End Sub
    
    Private Function GetMatchScoreColor(score As Integer) As Color
        Select Case score
            Case 90 To 100
                Return Color.FromArgb(27, 94, 32) ' Dark Green - Perfect Match
            Case 75 To 89
                Return Color.FromArgb(56, 142, 60) ' Green - Very Good Match
            Case 60 To 74
                Return Color.FromArgb(255, 152, 0) ' Orange - Good Match
            Case 50 To 59
                Return Color.FromArgb(255, 193, 7) ' Amber - Fair Match
            Case Else
                Return Color.FromArgb(198, 40, 40) ' Red - Poor Match
        End Select
    End Function
    
    Private Function GetRecommendationText(cookieType As String, drinkCategory As String) As String
        ' Create recommendation text based on cookie type and drink category
        Select Case cookieType.ToLower()
            Case "sweet"
                Return drinkCategory & " drinks & sweet treats"
            Case "neutral"
                Return "All types of beverages"
            Case "spicy"
                Return "Strong " & drinkCategory.ToLower() & " drinks"
            Case "citrus"
                Return "Citrus & " & drinkCategory.ToLower() & " beverages"
            Case "bitter-sweet"
                Return "Bold " & drinkCategory.ToLower() & " flavors"
            Case Else
                Return GlobalVariables.SelectedDrinkName
        End Select
    End Function
    
    Private Sub BtnBack_Click(sender As Object, e As EventArgs)
        Dim drinksForm As New FormDrinks()
        drinksForm.Show()
        Me.Close()
    End Sub
    
    Private Sub BtnNewSelection_Click(sender As Object, e As EventArgs)
        ' Reset global variables
        GlobalVariables.SelectedDrinkId = 0
        GlobalVariables.SelectedDrinkName = ""
        GlobalVariables.SelectedDrinkCategory = ""
        
        ' Go back to drinks selection
        Dim drinksForm As New FormDrinks()
        drinksForm.Show()
        Me.Close()
    End Sub
    
    Private Sub BtnExit_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Are you sure you want to exit PerfectPair?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class