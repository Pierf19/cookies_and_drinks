Imports System.Data
Imports System.IO

Public Class DatabaseManagerSimple
    
    ' Flag untuk mengecek apakah MySQL tersedia
    Private Shared isMySQL As Boolean? = Nothing
    
    ' Test dan set flag MySQL
    Private Shared Sub CheckMySQLAvailability()
        If isMySQL Is Nothing Then
            Try
                ' Try to load DatabaseManager class (yang menggunakan MySQL)
                isMySQL = DatabaseManager.TestConnection()
            Catch ex As Exception
                isMySQL = False
            End Try
        End If
    End Sub
    
    Public Shared Function LoadDrinksData() As DataTable
        CheckMySQLAvailability()
        
        ' Try MySQL first
        If isMySQL = True Then
            Try
                Return DatabaseManager.LoadDrinksData()
            Catch ex As Exception
                ' MySQL failed, fallback to hardcoded data
                isMySQL = False
            End Try
        End If
        
        ' Use hardcoded data as fallback
        Return LoadDrinksDataHardcoded()
    End Function
    
    Private Shared Function LoadDrinksDataHardcoded() As DataTable
        ' Membuat struktur tabel untuk data minuman
        Dim table As New DataTable()
        table.Columns.Add("id", GetType(Integer))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("type", GetType(String))
        table.Columns.Add("description", GetType(String))
        table.Columns.Add("image_path", GetType(String))

        ' Data sampel minuman
        Dim sampleDrinks = {
            New With {.id = 1, .name = "Cappuccino", .type = "Sweet", .description = "Creamy coffee with steamed milk", .image_path = "perfect_pair\cappucino.png"},
            New With {.id = 2, .name = "Hot Chocolate", .type = "Sweet", .description = "Rich chocolate drink", .image_path = "perfect_pair\hot chocolate.png"},
            New With {.id = 3, .name = "Vanilla Latte", .type = "Sweet", .description = "Sweet coffee with vanilla", .image_path = "perfect_pair\vanila latte.png"},
            New With {.id = 4, .name = "Iced Americano", .type = "Bitter", .description = "Strong black coffee on ice", .image_path = "perfect_pair\iced americano.png"},
            New With {.id = 5, .name = "Caramel Macchiato", .type = "Sweet", .description = "Sweet coffee with caramel", .image_path = "perfect_pair\caramel macchiato.png"},
            New With {.id = 6, .name = "Matcha Latte", .type = "Neutral", .description = "Green tea with milk", .image_path = "perfect_pair\matcha latte.png"},
            New With {.id = 7, .name = "Lemon Tea", .type = "Sour", .description = "Refreshing citrus tea", .image_path = "perfect_pair\teh lemon hangat.png"},
            New With {.id = 8, .name = "Black Tea", .type = "Neutral", .description = "Classic black tea", .image_path = "perfect_pair\iced black tea.png"}
        }

        ' Memasukkan data ke tabel
        For Each drink In sampleDrinks
            Dim newRow As DataRow = table.NewRow()
            newRow("id") = drink.id
            newRow("name") = drink.name
            newRow("type") = drink.type
            newRow("description") = drink.description
            newRow("image_path") = drink.image_path
            table.Rows.Add(newRow)
        Next

        Return table
    End Function

    Public Shared Function LoadCookiesData() As DataTable
        CheckMySQLAvailability()
        
        ' Try MySQL first
        If isMySQL = True Then
            Try
                Return DatabaseManager.LoadCookiesData()
            Catch ex As Exception
                ' MySQL failed, fallback to hardcoded data
                isMySQL = False
            End Try
        End If
        
        ' Use hardcoded data as fallback
        Return LoadCookiesDataHardcoded()
    End Function
    
    Private Shared Function LoadCookiesDataHardcoded() As DataTable
        ' Membuat struktur tabel untuk data cookies
        Dim table As New DataTable()
        table.Columns.Add("id", GetType(Integer))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("type", GetType(String))
        table.Columns.Add("description", GetType(String))
        table.Columns.Add("image_path", GetType(String))

        ' Data sampel cookies
        Dim sampleCookies = {
            New With {.id = 1, .name = "Chocolate Chip", .type = "Sweet", .description = "Classic sweet cookie with chocolate chips", .image_path = "perfect_pair\choco chip cookies.png"},
            New With {.id = 2, .name = "Oatmeal Cookie", .type = "Neutral", .description = "Healthy oats with subtle sweetness", .image_path = "perfect_pair\Oatmeal Raisin.png"},
            New With {.id = 3, .name = "Sugar Cookie", .type = "Sweet", .description = "Simple sweet vanilla cookie", .image_path = "perfect_pair\Sugar Cookie.png"},
            New With {.id = 4, .name = "Peanut Butter", .type = "Sweet", .description = "Rich peanut butter cookie", .image_path = "perfect_pair\Peanut Butter Cookie.png"},
            New With {.id = 5, .name = "White Chocolate", .type = "Sweet", .description = "Sweet white chocolate cookie", .image_path = "perfect_pair\White Choco Macadamia.png"},
            New With {.id = 6, .name = "Lemon Cookie", .type = "Sour", .description = "Tangy lemon flavored cookie", .image_path = "perfect_pair\Lemon Crinkle Cookie.png"},
            New With {.id = 7, .name = "Almond Biscotti", .type = "Neutral", .description = "Crispy Italian almond cookie", .image_path = "perfect_pair\Almond Biscotti.png"},
            New With {.id = 8, .name = "Snickerdoodle", .type = "Sweet", .description = "Cinnamon sugar cookie", .image_path = "perfect_pair\Snickerdoodle.png"}
        }

        ' Memasukkan data ke tabel
        For Each cookie In sampleCookies
            Dim newRow As DataRow = table.NewRow()
            newRow("id") = cookie.id
            newRow("name") = cookie.name
            newRow("type") = cookie.type
            newRow("description") = cookie.description
            newRow("image_path") = cookie.image_path
            table.Rows.Add(newRow)
        Next

        Return table
    End Function

    Public Shared Function LoadDrinkCookiePairingData() As DataTable
        CheckMySQLAvailability()
        
        ' Try MySQL first
        If isMySQL = True Then
            Try
                Return DatabaseManager.LoadDrinkCookiePairingData()
            Catch ex As Exception
                ' MySQL failed, fallback to hardcoded data
                isMySQL = False
            End Try
        End If
        
        ' Use hardcoded data as fallback
        Return LoadDrinkCookiePairingDataHardcoded()
    End Function
    
    Private Shared Function LoadDrinkCookiePairingDataHardcoded() As DataTable
        ' Membuat struktur tabel untuk data pairing minuman-cookies
        Dim table As New DataTable()
        table.Columns.Add("id", GetType(Integer))
        table.Columns.Add("drink_id", GetType(Integer))
        table.Columns.Add("cookie_id", GetType(Integer))
        table.Columns.Add("match_score", GetType(Integer)) ' Score 1-100
        table.Columns.Add("pairing_reason", GetType(String))

        ' ========================================
        ' DATA PAIRING MINUMAN-COOKIES - EDIT DI SINI
        ' ========================================
        ' Match Score: 90-100 = Perfect, 75-89 = Very Good, 60-74 = Good, 50-59 = Fair
        
        ' Cappuccino (ID=1) - 4 pairings
        table.Rows.Add(1, 1, 1, 95, "Rich chocolate complements coffee perfectly")
        table.Rows.Add(2, 1, 3, 90, "Classic sweet combination with coffee")
        table.Rows.Add(3, 1, 8, 85, "Buttery chocolate balance")
        table.Rows.Add(4, 1, 7, 75, "Traditional Italian coffee pairing")
        
        ' Hot Chocolate (ID=2) - 3 pairings
        table.Rows.Add(5, 2, 1, 100, "Double chocolate indulgence")
        table.Rows.Add(6, 2, 5, 85, "White chocolate contrast")
        table.Rows.Add(7, 2, 4, 80, "Creamy peanut butter richness")
        
        ' Vanilla Latte (ID=3) - 4 pairings
        table.Rows.Add(8, 3, 3, 95, "Vanilla harmony")
        table.Rows.Add(9, 3, 5, 90, "White chocolate elegance")
        table.Rows.Add(10, 3, 8, 85, "Sophisticated sweet combination")
        table.Rows.Add(11, 3, 2, 70, "Balanced sweet and neutral")
        
        ' Iced Americano (ID=4) - 4 pairings
        table.Rows.Add(12, 4, 1, 90, "Sweet balances bitter perfectly")
        table.Rows.Add(13, 4, 4, 85, "Rich peanut butter cuts bitterness")
        table.Rows.Add(14, 4, 7, 95, "Traditional Italian coffee biscuit")
        table.Rows.Add(15, 4, 2, 75, "Neutral oats complement strong coffee")
        
        ' Caramel Macchiato (ID=5) - 3 pairings
        table.Rows.Add(16, 5, 8, 100, "Caramel and chocolate perfection")
        table.Rows.Add(17, 5, 1, 90, "Double sweetness delight")
        table.Rows.Add(18, 5, 4, 85, "Caramel-peanut butter fusion")
        
        ' Matcha Latte (ID=6) - 4 pairings
        table.Rows.Add(19, 6, 5, 95, "White chocolate balances earthy matcha")
        table.Rows.Add(20, 6, 2, 90, "Oats complement matcha earthiness")
        table.Rows.Add(21, 6, 3, 80, "Simple sweetness with green tea")
        table.Rows.Add(22, 6, 7, 75, "Almond nuttiness pairs well")
        
        ' Lemon Tea (ID=7) - 4 pairings
        table.Rows.Add(23, 7, 6, 100, "Perfect citrus harmony")
        table.Rows.Add(24, 7, 3, 85, "Sweet balances tartness")
        table.Rows.Add(25, 7, 2, 80, "Neutral oats with citrus")
        table.Rows.Add(26, 7, 7, 70, "Almond complements lemon")
        
        ' Black Tea (ID=8) - 5 pairings
        table.Rows.Add(27, 8, 2, 95, "Classic tea biscuit pairing")
        table.Rows.Add(28, 8, 7, 90, "Traditional biscotti with tea")
        table.Rows.Add(29, 8, 3, 85, "Simple sweetness with tea")
        table.Rows.Add(30, 8, 6, 75, "Lemon brightens black tea")
        table.Rows.Add(31, 8, 1, 70, "Chocolate treats with afternoon tea")

        Return table
    End Function

    ' Method untuk mendapatkan rekomendasi cookie berdasarkan ID minuman yang dipilih
    Public Shared Function GetCookieRecommendationsByDrinkId(drinkId As Integer) As DataTable
        CheckMySQLAvailability()
        
        ' Try MySQL first
        If isMySQL = True Then
            Try
                Return DatabaseManager.GetCookieRecommendationsByDrinkId(drinkId)
            Catch ex As Exception
                ' MySQL failed, fallback to hardcoded data
                isMySQL = False
            End Try
        End If
        
        ' Use hardcoded data as fallback
        Return GetCookieRecommendationsByDrinkIdHardcoded(drinkId)
    End Function
    
    Private Shared Function GetCookieRecommendationsByDrinkIdHardcoded(drinkId As Integer) As DataTable
        Dim cookiesData As DataTable = LoadCookiesData()
        Dim pairingData As DataTable = LoadDrinkCookiePairingData()
        
        ' Membuat tabel hasil dengan kolom tambahan untuk match score dan reason
        Dim resultTable As New DataTable()
        resultTable.Columns.Add("id", GetType(Integer))
        resultTable.Columns.Add("name", GetType(String))
        resultTable.Columns.Add("type", GetType(String))
        resultTable.Columns.Add("description", GetType(String))
        resultTable.Columns.Add("image_path", GetType(String))
        resultTable.Columns.Add("match_score", GetType(Integer))
        resultTable.Columns.Add("pairing_reason", GetType(String))
        
        ' Gabungkan data berdasarkan drink_id yang dipilih
        For Each pairingRow As DataRow In pairingData.Rows
            If CInt(pairingRow("drink_id")) = drinkId Then
                Dim cookieId As Integer = CInt(pairingRow("cookie_id"))
                
                ' Cari cookie yang sesuai
                For Each cookieRow As DataRow In cookiesData.Rows
                    If CInt(cookieRow("id")) = cookieId Then
                        Dim newRow As DataRow = resultTable.NewRow()
                        newRow("id") = cookieRow("id")
                        newRow("name") = cookieRow("name") 
                        newRow("type") = cookieRow("type")
                        newRow("description") = cookieRow("description")
                        newRow("image_path") = cookieRow("image_path")
                        newRow("match_score") = pairingRow("match_score")
                        newRow("pairing_reason") = pairingRow("pairing_reason")
                        resultTable.Rows.Add(newRow)
                        Exit For
                    End If
                Next
            End If
        Next
        
        ' Urutkan berdasarkan match_score (tertinggi dulu)
        Dim sortedTable As DataTable = resultTable.Clone()
        Dim sortedRows() As DataRow = resultTable.Select("", "match_score DESC")
        For Each row As DataRow In sortedRows
            sortedTable.ImportRow(row)
        Next
        
        Return sortedTable
    End Function

End Class