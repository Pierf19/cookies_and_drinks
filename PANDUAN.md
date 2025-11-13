# PerfectPair - Cookie & Drink Pairing Application

## Cara Menambahkan Data Baru

### 1. Menambahkan Minuman (Drinks)

**Lokasi**: Edit file `DatabaseManagerSimple.vb`, cari method `LoadDrinksData()`

**Format**:
```vb
New With {.id = [nomor], .name = "[nama minuman]", .category = "[kategori]", .image_path = "perfect_pair\[nama_file].jpg"}
```

**Kategori yang tersedia**:
- `Sweet` - Minuman manis (Cappuccino, Latte, Mocha)
- `Bitter` - Minuman pahit (Espresso, Americano)
- `Neutral` - Minuman netral (Green Tea, Black Tea)
- `Sour` - Minuman asam (Lemon Tea)

**Contoh menambah minuman baru**:
```vb
New With {.id = 9, .name = "Caramel Macchiato", .category = "Sweet", .image_path = "perfect_pair\caramel_macchiato.jpg"}
```

### 2. Menambahkan Cookies

**Lokasi**: Edit file `DatabaseManagerSimple.vb`, cari method `LoadCookiesData()`

**Format**:
```vb
New With {.id = [nomor], .name = "[nama cookie]", .type = "[tipe]", .description = "[deskripsi]", .image_path = "perfect_pair\[nama_file].jpg"}
```

**Tipe yang tersedia**:
- `Sweet` - Cookie manis
- `Bitter-Sweet` - Cookie pahit-manis
- `Spicy` - Cookie pedas
- `Citrus` - Cookie jeruk/asam
- `Neutral` - Cookie netral

**Contoh menambah cookie baru**:
```vb
New With {.id = 9, .name = "White Chocolate Cookies", .type = "Sweet", .description = "Creamy white chocolate flavor", .image_path = "perfect_pair\white_chocolate.jpg"}
```

### 3. Menambahkan Gambar

1. **Buat folder `perfect_pair`** di folder aplikasi (sudah dibuat otomatis)
2. **Copy file gambar** (.jpg, .png, .gif) ke folder `perfect_pair`
3. **Pastikan nama file** sesuai dengan yang tertulis di `image_path`

**Contoh struktur folder**:
```
cookies_and_coffe/
├── bin/Debug/
│   ├── cookies_and_coffe.exe
│   └── perfect_pair/
│       ├── cappuccino.jpg
│       ├── latte.jpg
│       ├── chocolate_chip.jpg
│       └── oatmeal.jpg
```

**Tips untuk gambar**:
- Gunakan format JPG atau PNG
- Ukuran optimal: 200x200 pixel
- Nama file tanpa spasi (gunakan underscore: `chocolate_chip.jpg`)

## Struktur Aplikasi

### Flow Aplikasi:
1. **Form1** (Splash Screen) → START button
2. **FormInput** → User input nama dan kode akses
3. **FormDrinks** → Pilih minuman berdasarkan kategori
4. **FormCookies** → Rekomendasi cookie yang cocok

### File Penting:
- `DatabaseManagerSimple.vb` - Data minuman dan cookie
- `FormDrinks.vb` - Tampilan pilihan minuman
- `FormCookies.vb` - Tampilan rekomendasi cookie
- `perfect_pair/` - Folder gambar

## Troubleshooting

### Gambar tidak muncul?
1. Periksa folder `perfect_pair` ada di folder aplikasi
2. Pastikan nama file gambar sesuai dengan `image_path` di code
3. Periksa format file (harus jpg, png, gif)

### Data tidak muncul?
1. Periksa format data di `DatabaseManagerSimple.vb`
2. Pastikan tidak ada error syntax (tanda koma, kurung, dll)
3. Rebuild aplikasi setelah edit data

### Build error?
1. Clean solution: hapus folder `obj` dan `bin`
2. Rebuild project
3. Periksa syntax error di file yang diedit

## Kustomisasi Lanjutan

### Mengubah warna tema:
- Edit nilai Color.FromArgb() di setiap form
- Warna utama: `Color.FromArgb(101, 67, 33)` (coklat kopi)
- Background: `Color.FromArgb(252, 248, 227)` (krem)

### Mengubah font:
- Edit `New Font("Segoe UI", [ukuran], FontStyle.[style])`
- Style: Bold, Italic, Regular

### Menambah kategori filter:
- Edit array `filterCategories` di `FormDrinks.vb`
- Tambahkan kategori baru di data minuman

---

**Catatan**: Aplikasi ini menggunakan data hardcoded di `DatabaseManagerSimple.vb` untuk kemudahan maintenance tanpa database external.