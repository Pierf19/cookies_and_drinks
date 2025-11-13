Imports System.Data
Imports System.IO

Public Class FormDrinks
    Private drinksTable As DataTable
    Private currentFilter As String = "All"
    
    Private Sub FormDrinks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set window properties
        Me.Text = "PerfectPair - Choose Your Drink"
        Me.Size = New Size(900, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(252, 248, 227)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        
        CreateUI()
        LoadDrinksData()
    End Sub
    
    Private Sub CreateUI()
        ' Create title label
        Dim lblTitle As New Label()
        lblTitle.Text = "Hello " & GlobalVariables.UserName & "! Choose Your Perfect Drink"
        lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(101, 67, 33)
        lblTitle.Size = New Size(800, 40)
        lblTitle.Location = New Point(50, 20)
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(lblTitle)
        
        ' Create filter panel
        Dim filterPanel As New Panel()
        filterPanel.Size = New Size(800, 60)
        filterPanel.Location = New Point(50, 70)
        filterPanel.BackColor = Color.Transparent
        Me.Controls.Add(filterPanel)
        
        ' Create filter buttons (chips)
        Dim filterCategories() As String = {"All", "Sweet", "Bitter", "Neutral", "Sour"}
        Dim buttonWidth As Integer = 120
        Dim startX As Integer = 50
        
        For i As Integer = 0 To filterCategories.Length - 1
            Dim btnFilter As New Button()
            btnFilter.Text = filterCategories(i)
            btnFilter.Name = "btnFilter" & filterCategories(i)
            btnFilter.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            btnFilter.Size = New Size(buttonWidth, 35)
            btnFilter.Location = New Point(startX + (i * (buttonWidth + 10)), 15)
            btnFilter.BackColor = If(filterCategories(i) = "All", Color.FromArgb(101, 67, 33), Color.White)
            btnFilter.ForeColor = If(filterCategories(i) = "All", Color.White, Color.FromArgb(101, 67, 33))
            btnFilter.FlatStyle = FlatStyle.Flat
            btnFilter.FlatAppearance.BorderColor = Color.FromArgb(101, 67, 33)
            btnFilter.FlatAppearance.BorderSize = 2
            btnFilter.Cursor = Cursors.Hand
            AddHandler btnFilter.Click, AddressOf FilterButton_Click
            filterPanel.Controls.Add(btnFilter)
        Next
        
        ' Create drinks panel (scrollable)
        Dim drinksPanel As New Panel()
        drinksPanel.Name = "drinksPanel"
        drinksPanel.Size = New Size(800, 480)
        drinksPanel.Location = New Point(50, 150)
        drinksPanel.BackColor = Color.Transparent
        drinksPanel.AutoScroll = True
        Me.Controls.Add(drinksPanel)
        
        ' Create back button
        Dim btnBack As New Button()
        btnBack.Text = "Back"
        btnBack.Font = New Font("Segoe UI", 10)
        btnBack.Size = New Size(80, 30)
        btnBack.Location = New Point(20, 640)
        btnBack.BackColor = Color.Gray
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.Cursor = Cursors.Hand
        AddHandler btnBack.Click, AddressOf BtnBack_Click
        Me.Controls.Add(btnBack)
    End Sub
    
    Private Sub LoadDrinksData()
        Try
            ' Load drinks data using DatabaseManager
            drinksTable = DatabaseManager.LoadDrinksData()
            
            If drinksTable IsNot Nothing AndAlso drinksTable.Rows.Count > 0 Then
                DisplayDrinks()
            Else
                LoadFallbackData()
                DisplayDrinks()
            End If
            
        Catch ex As Exception
            MessageBox.Show("Error loading drinks data: " & ex.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LoadFallbackData()
            DisplayDrinks()
        End Try
    End Sub
    
    Private Sub LoadFallbackData()
        ' Fallback sample data if database is not available - use same structure as DatabaseManager
        drinksTable = New DataTable()
        drinksTable.Columns.Add("id", GetType(Integer))
        drinksTable.Columns.Add("name", GetType(String))
        drinksTable.Columns.Add("type", GetType(String))
        drinksTable.Columns.Add("description", GetType(String))
        drinksTable.Columns.Add("image_path", GetType(String))
        
        drinksTable.Rows.Add(1, "Cappuccino", "Sweet", "Creamy coffee with steamed milk", "cappuccino.jpg")
        drinksTable.Rows.Add(2, "Hot Chocolate", "Sweet", "Rich chocolate drink", "hot_chocolate.jpg")
        drinksTable.Rows.Add(3, "Vanilla Latte", "Sweet", "Sweet coffee with vanilla", "vanilla_latte.jpg")
        drinksTable.Rows.Add(4, "Iced Americano", "Bitter", "Strong black coffee on ice", "iced_americano.jpg")
        drinksTable.Rows.Add(5, "Caramel Macchiato", "Sweet", "Sweet coffee with caramel", "caramel_macchiato.jpg")
        drinksTable.Rows.Add(6, "Matcha Latte", "Neutral", "Green tea with milk", "matcha_latte.jpg")
        drinksTable.Rows.Add(7, "Lemon Tea", "Sour", "Refreshing citrus tea", "lemon_tea.jpg")
        drinksTable.Rows.Add(8, "Black Tea", "Neutral", "Classic black tea", "black_tea.jpg")
    End Sub
    
    Private Sub DisplayDrinks()
        Dim drinksPanel As Panel = CType(Me.Controls("drinksPanel"), Panel)
        drinksPanel.Controls.Clear()
        
        Dim filteredRows() As DataRow
        If currentFilter = "All" Then
            filteredRows = drinksTable.Select()
        Else
            filteredRows = drinksTable.Select("type = '" & currentFilter & "'")
        End If
        
        Dim cardWidth As Integer = 180
        Dim cardHeight As Integer = 220
        Dim margin As Integer = 20
        Dim cardsPerRow As Integer = 4
        
        For i As Integer = 0 To filteredRows.Length - 1
            Dim row As DataRow = filteredRows(i)
            
            ' Calculate position
            Dim col As Integer = i Mod cardsPerRow
            Dim rowIndex As Integer = i \ cardsPerRow
            Dim x As Integer = col * (cardWidth + margin) + margin
            Dim y As Integer = rowIndex * (cardHeight + margin) + margin
            
            ' Create drink card
            Dim drinkCard As New Panel()
            drinkCard.Size = New Size(cardWidth, cardHeight)
            drinkCard.Location = New Point(x, y)
            drinkCard.BackColor = Color.White
            drinkCard.BorderStyle = BorderStyle.FixedSingle
            drinkCard.Cursor = Cursors.Hand
            drinkCard.Tag = row("ID")
            
            ' Add hover effect
            AddHandler drinkCard.MouseEnter, Sub() drinkCard.BackColor = Color.FromArgb(245, 245, 245)
            AddHandler drinkCard.MouseLeave, Sub() drinkCard.BackColor = Color.White
            AddHandler drinkCard.Click, AddressOf DrinkCard_Click
            
            ' Drink image
            Dim picImage As New PictureBox()
            picImage.Size = New Size(cardWidth - 20, 100)
            picImage.Location = New Point(10, 10)
            picImage.SizeMode = PictureBoxSizeMode.Zoom
            picImage.BackColor = Color.Transparent
            
            ' *** CARA MENAMBAHKAN GAMBAR ***
            ' 1. Letakkan file gambar (.jpg, .png) di folder 'perfect_pair' 
            ' 2. Pastikan nama file sesuai dengan yang ada di DatabaseManager.vb
            ' 3. Contoh: cappuccino.jpg, latte.jpg, espresso.jpg
            
            ' Load image from perfect_pair folder
            Dim imagePathRaw As String = row("image_path").ToString()
            Dim imagePath As String = Path.Combine(Application.StartupPath, "perfect_pair", imagePathRaw)
            
            ' Try to load the actual image file
            If File.Exists(imagePath) Then
                Try
                    ' Load image successfully
                    picImage.Image = Image.FromFile(imagePath)
                    AddHandler picImage.Click, AddressOf DrinkCard_Click
                    drinkCard.Controls.Add(picImage)
                Catch ex As Exception
                    ' File exists but corrupted, use emoji fallback
                    GoTo UseEmojiIcon
                End Try
            Else
                ' File doesn't exist, use emoji fallback
                GoTo UseEmojiIcon
            End If
            
            ' Skip emoji fallback if image loaded successfully
            GoTo SkipEmojiIcon
            
UseEmojiIcon:
            ' Use emoji icon as fallback when image file not found
            Dim lblIcon As New Label()
            lblIcon.Text = "🥤"
            lblIcon.Font = New Font("Segoe UI", 48)
            lblIcon.Size = picImage.Size
            lblIcon.Location = picImage.Location
            lblIcon.TextAlign = ContentAlignment.MiddleCenter
            lblIcon.BackColor = Color.Transparent
            AddHandler lblIcon.Click, AddressOf DrinkCard_Click
            drinkCard.Controls.Add(lblIcon)
            
SkipEmojiIcon:
            
            ' Drink name
            Dim lblName As New Label()
            lblName.Text = row("name").ToString()
            lblName.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            lblName.ForeColor = Color.FromArgb(101, 67, 33)
            lblName.Size = New Size(cardWidth - 20, 30)
            lblName.Location = New Point(10, 120)
            lblName.TextAlign = ContentAlignment.MiddleCenter
            lblName.BackColor = Color.Transparent
            AddHandler lblName.Click, AddressOf DrinkCard_Click
            drinkCard.Controls.Add(lblName)
            
            ' Category chip
            Dim lblCategory As New Label()
            lblCategory.Text = row("type").ToString()
            lblCategory.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            lblCategory.ForeColor = Color.White
            lblCategory.BackColor = GetCategoryColor(row("type").ToString())
            lblCategory.Size = New Size(80, 25)
            lblCategory.Location = New Point((cardWidth - 80) \ 2 + 10, 160)
            lblCategory.TextAlign = ContentAlignment.MiddleCenter
            AddHandler lblCategory.Click, AddressOf DrinkCard_Click
            drinkCard.Controls.Add(lblCategory)
            
            drinksPanel.Controls.Add(drinkCard)
        Next
    End Sub
    
    Private Function GetCategoryColor(category As String) As Color
        Select Case category.ToLower()
            Case "sweet"
                Return Color.FromArgb(255, 99, 132)
            Case "bitter"
                Return Color.FromArgb(75, 192, 192)
            Case "neutral"
                Return Color.FromArgb(153, 102, 255)
            Case "sour"
                Return Color.FromArgb(255, 206, 86)
            Case Else
                Return Color.Gray
        End Select
    End Function
    
    Private Sub FilterButton_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(sender, Button)
        currentFilter = clickedButton.Text
        
        ' Update button appearances
        For Each ctrl As Control In clickedButton.Parent.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                If btn.Text = currentFilter Then
                    btn.BackColor = Color.FromArgb(101, 67, 33)
                    btn.ForeColor = Color.White
                Else
                    btn.BackColor = Color.White
                    btn.ForeColor = Color.FromArgb(101, 67, 33)
                End If
            End If
        Next
        
        DisplayDrinks()
    End Sub
    
    Private Sub DrinkCard_Click(sender As Object, e As EventArgs)
        Dim clickedControl As Control = CType(sender, Control)
        Dim drinkCard As Panel
        
        ' Find the parent panel (drink card)
        If TypeOf clickedControl Is Panel Then
            drinkCard = CType(clickedControl, Panel)
        Else
            drinkCard = CType(clickedControl.Parent, Panel)
        End If
        
        Dim drinkId As Integer = CType(drinkCard.Tag, Integer)
        
        ' Find the selected drink in the data
        Dim selectedRow As DataRow = drinksTable.Select("id = " & drinkId)(0)
        
        ' Store selected drink information
        GlobalVariables.SelectedDrinkId = drinkId
        GlobalVariables.SelectedDrinkName = selectedRow("name").ToString()
        GlobalVariables.SelectedDrinkCategory = selectedRow("type").ToString()
        
        ' Open cookies recommendation form
        Dim cookiesForm As New FormCookies()
        cookiesForm.Show()
        Me.Hide()
    End Sub
    
    Private Sub BtnBack_Click(sender As Object, e As EventArgs)
        Dim inputForm As New FormInput()
        inputForm.Show()
        Me.Close()
    End Sub
End Class