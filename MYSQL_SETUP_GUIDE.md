# 🗄️ MySQL Database Setup Guide

## 📋 Prerequisites

### 1. Install MySQL Server
- Download MySQL Community Server dari [https://dev.mysql.com/downloads/mysql/](https://dev.mysql.com/downloads/mysql/)
- Install dengan konfigurasi default
- **PENTING**: Set password untuk root user sebagai **KOSONG** (blank/empty)
- Atau jika sudah ada MySQL, kosongkan password root dengan command:
```sql
ALTER USER 'root'@'localhost' IDENTIFIED BY '';
```

### 2. Install MySQL Connector/NET
Aplikasi sudah dikonfigurasi untuk menggunakan MySQL.Data versi 8.0.33.
Package akan ter-download otomatis saat build pertama kali.

## 🚀 Database Setup

### Step 1: Start MySQL Service
Pastikan MySQL server berjalan:
```bash
# Windows (Command Prompt as Administrator)
net start mysql80

# Atau melalui Services.msc, start service "MySQL80"
```

### Step 2: Import Database Structure
1. Buka MySQL Command Line Client atau MySQL Workbench
2. Login sebagai root (password kosong):
```bash
mysql -u root -p
# Tekan Enter saat diminta password (karena kosong)
```

3. Import file database_structure.sql:
```sql
# Melalui command line:
source C:\Users\legio\source\repos\cookies_and_coffe\cookies_and_coffe\database_structure.sql

# Atau copy-paste isi file database_structure.sql ke MySQL client
```

### Step 3: Verify Database
Setelah import berhasil, verifikasi dengan query:
```sql
USE cookies_and_coffee;

-- Check tables
SHOW TABLES;

-- Check data
SELECT COUNT(*) FROM drinks;     -- Should return 8
SELECT COUNT(*) FROM cookies;    -- Should return 8  
SELECT COUNT(*) FROM drink_cookie_pairing; -- Should return 31

-- Test pairing view
SELECT * FROM v_pairing_details LIMIT 5;
```

## 🏗️ Database Structure

### Tables Created:

#### 1. `drinks` (8 records)
| Column | Type | Description |
|--------|------|-------------|
| id | INT | Primary key |
| name | VARCHAR(100) | Drink name |
| type | VARCHAR(50) | Sweet/Bitter/Sour/Neutral |
| description | TEXT | Description |
| image_path | VARCHAR(255) | Path to image file |
| created_at | TIMESTAMP | Auto-created |
| updated_at | TIMESTAMP | Auto-updated |

#### 2. `cookies` (8 records)  
| Column | Type | Description |
|--------|------|-------------|
| id | INT | Primary key |
| name | VARCHAR(100) | Cookie name |
| type | VARCHAR(50) | Sweet/Neutral/Sour |
| description | TEXT | Description |
| image_path | VARCHAR(255) | Path to image file |
| created_at | TIMESTAMP | Auto-created |
| updated_at | TIMESTAMP | Auto-updated |

#### 3. `drink_cookie_pairing` (31 records)
| Column | Type | Description |
|--------|------|-------------|
| id | INT | Primary key |
| drink_id | INT | Foreign key to drinks |
| cookie_id | INT | Foreign key to cookies |
| match_score | INT | Score 1-100 |
| pairing_reason | TEXT | Why they pair well |
| created_at | TIMESTAMP | Auto-created |
| updated_at | TIMESTAMP | Auto-updated |

### Views Created:

#### 1. `v_pairing_details`
Complete pairing information with drink/cookie names and match categories.

#### 2. `v_pairing_stats`  
Statistics per drink: total pairings, best/average/lowest scores.

## 🔧 Application Configuration

### Connection String
```
Server=localhost;Database=cookies_and_coffee;Uid=root;Pwd=;CharSet=utf8mb4;
```

### Hybrid System
Aplikasi menggunakan **Hybrid Database System**:

1. **Primary**: MySQL Database
   - Fastest performance
   - Full CRUD capabilities
   - Real-time data updates
   - Advanced querying with JOINs

2. **Fallback**: Hardcoded Data (existing system)
   - Automatic fallback jika MySQL tidak tersedia
   - No setup required
   - Always works offline

### How It Works:
```vb
' Application flow:
1. Check if MySQL is available
2. If YES: Use DatabaseManager (MySQL)
3. If NO: Use DatabaseManagerSimple (hardcoded data)
4. User experience remains identical
```

## ✅ Testing & Verification

### Test Connection
Aplikasi akan otomatis test koneksi MySQL saat pertama kali dijalankan.

### Success Indicators:
- ✅ Application starts without errors
- ✅ Images display properly
- ✅ Sophisticated pairing system works
- ✅ All 31 pairing combinations available
- ✅ Real-time data from MySQL

### Failure Indicators (Auto-fallback to hardcoded):
- ⚠️ "Database connection failed" message  
- ⚠️ Application still works (using hardcoded data)
- ⚠️ No MySQL benefits but all features functional

## 🔄 Data Management

### Sample Queries:

**Get all drinks:**
```sql
SELECT * FROM drinks ORDER BY name;
```

**Get recommendations for specific drink:**
```sql
SELECT c.*, p.match_score, p.pairing_reason 
FROM cookies c
JOIN drink_cookie_pairing p ON c.id = p.cookie_id
WHERE p.drink_id = 1  -- Cappuccino
ORDER BY p.match_score DESC;
```

**Best pairings (Perfect score):**
```sql
SELECT * FROM v_pairing_details 
WHERE match_score >= 90 
ORDER BY match_score DESC;
```

**Pairing statistics:**
```sql
SELECT * FROM v_pairing_stats;
```

### Future Admin Features:
- Add new drinks: `DatabaseManager.AddDrink()`
- Add new cookies: `DatabaseManager.AddCookie()`  
- Add new pairings: `DatabaseManager.AddPairing()`

## 🚨 Troubleshooting

### Common Issues:

**1. MySQL Connection Failed**
- Verify MySQL service is running
- Check root password is empty
- Ensure database `cookies_and_coffee` exists

**2. Permission Denied**
```sql
-- Grant all privileges to root
GRANT ALL PRIVILEGES ON *.* TO 'root'@'localhost';
FLUSH PRIVILEGES;
```

**3. Character Set Issues**
- Database uses UTF8MB4 for full Unicode support
- Handles emoji and special characters

**4. Import Errors**
- Use MySQL 8.0 or higher
- Ensure sufficient disk space
- Check MySQL error log

### Fallback Mode:
If MySQL setup fails, aplikasi tetap berfungsi dengan hardcoded data.
Semua fitur tersedia, hanya tidak ada database persistence.

---

## 📊 Final Result

✅ **Hybrid Database System**: MySQL primary + hardcoded fallback  
✅ **31 Sophisticated Pairings**: Fully preserved in database  
✅ **Performance**: Fast MySQL queries with JOINs  
✅ **Reliability**: Always works even without MySQL  
✅ **Scalability**: Easy to add new data via database  
✅ **User Experience**: Identical regardless of backend used  

**Ready for Production**: Import SQL file, run application, enjoy! 🎉