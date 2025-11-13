Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set window properties
        Me.Text = "PerfectPair"
        Me.Size = New Size(600, 450)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(252, 248, 227) ' Cream background
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        
        ' Create main title label
        Dim lblTitle As New Label()
        lblTitle.Text = "PerfectPair"
        lblTitle.Font = New Font("Segoe UI", 36, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(101, 67, 33) ' Coffee brown
        lblTitle.Size = New Size(400, 60)
        lblTitle.Location = New Point(100, 80)
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(lblTitle)
        
        ' Create tagline label
        Dim lblTagline As New Label()
        lblTagline.Text = "for your cookies & drink"
        lblTagline.Font = New Font("Segoe UI", 14, FontStyle.Italic)
        lblTagline.ForeColor = Color.FromArgb(139, 115, 85) ' Light brown
        lblTagline.Size = New Size(400, 30)
        lblTagline.Location = New Point(100, 150)
        lblTagline.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(lblTagline)
        
        ' Create decorative elements (coffee cup icon placeholder)
        Dim lblIcon As New Label()
        lblIcon.Text = "☕"
        lblIcon.Font = New Font("Segoe UI", 48)
        lblIcon.ForeColor = Color.FromArgb(101, 67, 33)
        lblIcon.Size = New Size(80, 80)
        lblIcon.Location = New Point(260, 180)
        lblIcon.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(lblIcon)
        
        ' Create Start button
        Dim btnStart As New Button()
        btnStart.Text = "START"
        btnStart.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        btnStart.Size = New Size(200, 60)
        btnStart.Location = New Point(200, 280)
        btnStart.BackColor = Color.FromArgb(101, 67, 33) ' Coffee brown
        btnStart.ForeColor = Color.White
        btnStart.FlatStyle = FlatStyle.Flat
        btnStart.FlatAppearance.BorderSize = 0
        btnStart.Cursor = Cursors.Hand
        AddHandler btnStart.Click, AddressOf BtnStart_Click
        Me.Controls.Add(btnStart)
    End Sub
    
    Private Sub BtnStart_Click(sender As Object, e As EventArgs)
        ' Open the input form
        Dim inputForm As New FormInput()
        inputForm.Show()
        Me.Hide()
    End Sub
End Class
