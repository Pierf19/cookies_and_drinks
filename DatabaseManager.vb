Imports System.Data
Imports MySql.Data.MySqlClient  

Public Class DatabaseManager
    
    ' Connection string untuk MySQL (localhost, no password)
    Private Shared ReadOnly connectionString As String = "Server=localhost;Database=cookies_and_coffee;Uid=root;Pwd=;CharSet=utf8mb4;"
    
    ' Test koneksi database
    Public Shared Function TestConnection() As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("MySQL connection failed: " & ex.Message & vbCrLf & vbCrLf & 
                          "Please make sure:" & vbCrLf & 
                          "1. MySQL server is running" & vbCrLf & 
                          "2. Database 'cookies_and_coffee' exists" & vbCrLf & 
                          "3. Import the database_structure.sql file", 
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    
    ' Load data minuman dari MySQL
    Public Shared Function LoadDrinksData() As DataTable
        ' TODO: Implement when MySQL.Data connector is available
        Dim table As New DataTable()
        table.Columns.Add("id", GetType(Integer))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("type", GetType(String))
        table.Columns.Add("description", GetType(String))
        table.Columns.Add("image_path", GetType(String))
        Return table
        
        ' TODO: Uncomment when MySQL.Data is installed:
        'Try
        '    Using connection As New MySqlConnection(connectionString)
        '        connection.Open()
        '        
        '        Dim query As String = "SELECT id, name, type, description, image_path FROM drinks ORDER BY name"
        '        Using command As New MySqlCommand(query, connection)
        '            Using adapter As New MySqlDataAdapter(command)
        '                adapter.Fill(table)
        '            End Using
        '        End Using
        '    End Using
        '    
        'Catch ex As Exception
        '    MessageBox.Show("Error loading drinks data: " & ex.Message, "Database Error", 
        '                  MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        '
        'Return table
    End Function
    
    ' Load data cookies dari MySQL
    Public Shared Function LoadCookiesData() As DataTable
        ' TODO: Implement when MySQL.Data connector is available
        Dim table As New DataTable()
        table.Columns.Add("id", GetType(Integer))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("type", GetType(String))
        table.Columns.Add("description", GetType(String))
        table.Columns.Add("image_path", GetType(String))
        Return table
    End Function
    
    ' Load data pairing dari MySQL
    Public Shared Function LoadDrinkCookiePairingData() As DataTable
        ' TODO: Implement when MySQL.Data connector is available
        Dim table As New DataTable()
        table.Columns.Add("id", GetType(Integer))
        table.Columns.Add("drink_id", GetType(Integer))
        table.Columns.Add("cookie_id", GetType(Integer))
        table.Columns.Add("match_score", GetType(Integer))
        table.Columns.Add("pairing_reason", GetType(String))
        Return table
    End Function
    
    ' Method untuk mendapatkan rekomendasi cookie berdasarkan ID minuman menggunakan MySQL
    Public Shared Function GetCookieRecommendationsByDrinkId(drinkId As Integer) As DataTable
        ' TODO: Implement when MySQL.Data connector is available
        Dim table As New DataTable()
        table.Columns.Add("id", GetType(Integer))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("type", GetType(String))
        table.Columns.Add("description", GetType(String))
        table.Columns.Add("image_path", GetType(String))
        table.Columns.Add("match_score", GetType(Integer))
        table.Columns.Add("pairing_reason", GetType(String))
        Return table
    End Function
    
    ' Method untuk menambah minuman baru (untuk future admin features)
    'Public Shared Function AddDrink(name As String, type As String, description As String, imagePath As String) As Boolean
    '    Try
    '        Using connection As New MySqlConnection(connectionString)
    '            connection.Open()
    '            
    '            Dim query As String = "INSERT INTO drinks (name, type, description, image_path) VALUES (@name, @type, @description, @imagePath)"
    '            Using command As New MySqlCommand(query, connection)
    '                command.Parameters.AddWithValue("@name", name)
    '                command.Parameters.AddWithValue("@type", type)
    '                command.Parameters.AddWithValue("@description", description)
    '                command.Parameters.AddWithValue("@imagePath", imagePath)
    '                
    '                command.ExecuteNonQuery()
    '                Return True
    '            End Using
    '        End Using
    '        
    '    Catch ex As Exception
    '        MessageBox.Show("Error adding drink: " & ex.Message, "Database Error", 
    '                      MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return False
    '    End Try
    'End Function
    
    ' Method untuk menambah cookie baru (untuk future admin features)
    'Public Shared Function AddCookie(name As String, type As String, description As String, imagePath As String) As Boolean
    '    Try
    '        Using connection As New MySqlConnection(connectionString)
    '            connection.Open()
    '            
    '            Dim query As String = "INSERT INTO cookies (name, type, description, image_path) VALUES (@name, @type, @description, @imagePath)"
    '            Using command As New MySqlCommand(query, connection)
    '                command.Parameters.AddWithValue("@name", name)
    '                command.Parameters.AddWithValue("@type", type)
    '                command.Parameters.AddWithValue("@description", description)
    '                command.Parameters.AddWithValue("@imagePath", imagePath)
    '                
    '                command.ExecuteNonQuery()
    '                Return True
    '            End Using
    '        End Using
    '        
    '    Catch ex As Exception
    '        MessageBox.Show("Error adding cookie: " & ex.Message, "Database Error", 
    '                      MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return False
    '    End Try
    'End Function
    
    ' Method untuk menambah pairing baru (untuk future admin features)
    'Public Shared Function AddPairing(drinkId As Integer, cookieId As Integer, matchScore As Integer, reason As String) As Boolean
    '    Try
    '        Using connection As New MySqlConnection(connectionString)
    '            connection.Open()
    '            
    '            Dim query As String = "INSERT INTO drink_cookie_pairing (drink_id, cookie_id, match_score, pairing_reason) VALUES (@drinkId, @cookieId, @matchScore, @reason)"
    '            Using command As New MySqlCommand(query, connection)
    '                command.Parameters.AddWithValue("@drinkId", drinkId)
    '                command.Parameters.AddWithValue("@cookieId", cookieId)
    '                command.Parameters.AddWithValue("@matchScore", matchScore)
    '                command.Parameters.AddWithValue("@reason", reason)
    '                
    '                command.ExecuteNonQuery()
    '                Return True
    '            End Using
    '        End Using
    '        
    '    Catch ex As Exception
    '        MessageBox.Show("Error adding pairing: " & ex.Message, "Database Error", 
    '                      MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return False
    '    End Try
    'End Function
    
    ' Method untuk mendapatkan statistik pairing
    'Public Shared Function GetPairingStats() As DataTable
    '    Dim table As New DataTable()
    '    
    '    Try
    '        Using connection As New MySqlConnection(connectionString)
    '            connection.Open()
    '            
    '            Dim query As String = "SELECT * FROM v_pairing_stats"
    '            Using command As New MySqlCommand(query, connection)
    '                Using adapter As New MySqlDataAdapter(command)
    '                    adapter.Fill(table)
    '                End Using
    '            End Using
    '        End Using
    '        
    '    Catch ex As Exception
    '        MessageBox.Show("Error loading pairing statistics: " & ex.Message, "Database Error", 
    '                      MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    '    
    '    Return table
    'End Function
    
End Class