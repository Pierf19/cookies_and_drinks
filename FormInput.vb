Public Class FormInput
    Inherits System.Windows.Forms.Form

    Private Sub FormInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set window properties
        Me.Text = "PerfectPair - User Information"
        Me.Size = New Size(500, 400)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(252, 248, 227) ' Cream background
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        
        ' Create title label
        Dim lblTitle As New Label()
        lblTitle.Text = "Welcome to PerfectPair!"
        lblTitle.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(101, 67, 33)
        lblTitle.Size = New Size(400, 40)
        lblTitle.Location = New Point(50, 30)
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(lblTitle)
        
        ' Create name label and textbox
        Dim lblName As New Label()
        lblName.Text = "Your Name:"
        lblName.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblName.ForeColor = Color.FromArgb(101, 67, 33)
        lblName.Size = New Size(100, 25)
        lblName.Location = New Point(50, 100)
        Me.Controls.Add(lblName)
        
        Dim txtName As New TextBox()
        txtName.Name = "txtName"
        txtName.Font = New Font("Segoe UI", 11)
        txtName.Size = New Size(300, 30)
        txtName.Location = New Point(50, 130)
        txtName.BackColor = Color.White
        txtName.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(txtName)
        
        ' Create code label and textbox
        Dim lblCode As New Label()
        lblCode.Text = "Access Code:"
        lblCode.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblCode.ForeColor = Color.FromArgb(101, 67, 33)
        lblCode.Size = New Size(100, 25)
        lblCode.Location = New Point(50, 180)
        Me.Controls.Add(lblCode)
        
        Dim txtCode As New TextBox()
        txtCode.Name = "txtCode"
        txtCode.Font = New Font("Segoe UI", 11)
        txtCode.Size = New Size(300, 30)
        txtCode.Location = New Point(50, 210)
        txtCode.BackColor = Color.White
        txtCode.BorderStyle = BorderStyle.FixedSingle
        txtCode.UseSystemPasswordChar = True
        Me.Controls.Add(txtCode)
        
        ' Create Begin button
        Dim btnBegin As New Button()
        btnBegin.Text = "BEGIN"
        btnBegin.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        btnBegin.Size = New Size(150, 50)
        btnBegin.Location = New Point(175, 280)
        btnBegin.BackColor = Color.FromArgb(101, 67, 33)
        btnBegin.ForeColor = Color.White
        btnBegin.FlatStyle = FlatStyle.Flat
        btnBegin.FlatAppearance.BorderSize = 0
        btnBegin.Cursor = Cursors.Hand
        AddHandler btnBegin.Click, AddressOf BtnBegin_Click
        Me.Controls.Add(btnBegin)
        
        ' Create back button
        Dim btnBack As New Button()
        btnBack.Text = "Back"
        btnBack.Font = New Font("Segoe UI", 10)
        btnBack.Size = New Size(80, 30)
        btnBack.Location = New Point(20, 320)
        btnBack.BackColor = Color.Gray
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.Cursor = Cursors.Hand
        AddHandler btnBack.Click, AddressOf BtnBack_Click
        Me.Controls.Add(btnBack)
    End Sub
    
    Private Sub BtnBegin_Click(sender As Object, e As EventArgs)
        Dim txtName As TextBox = CType(Me.Controls("txtName"), TextBox)
        Dim txtCode As TextBox = CType(Me.Controls("txtCode"), TextBox)
        
        ' Validate input
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return
        End If
        
        If String.IsNullOrWhiteSpace(txtCode.Text) Then
            MessageBox.Show("Please enter the access code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return
        End If
        
        ' Store user information globally (you can use a module for this)
        GlobalVariables.UserName = txtName.Text.Trim()
        GlobalVariables.AccessCode = txtCode.Text.Trim()
        
        ' Open drinks selection form
        Dim drinksForm As New FormDrinks()
        drinksForm.Show()
        Me.Hide()
    End Sub
    
    Private Sub BtnBack_Click(sender As Object, e As EventArgs)
        Dim splashForm As New Form1()
        splashForm.Show()
        Me.Close()
    End Sub
End Class