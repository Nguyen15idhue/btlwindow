# 🔧 SCRIPT CLEAN UP & PUSH AN TOÀN

## ⚠️ VẤN ĐỀ HIỆN TẠI

Có 1 file lạ trong git status:
```
" } finally { if ($...) { echo "
```

Đây là file tạm từ PowerShell, cần xóa trước khi push.

---

## ✅ GIẢI PHÁP - 3 BƯỚC AN TOÀN

### BƯỚC 1: Backup files quan trọng (Đã làm ✅)

Files quan trọng đã được tạo lại:
- ✅ `firstapp/Forms/frmTaskDetail.cs`
- ✅ `firstapp/Forms/frmTaskDetail.Designer.cs`
- ✅ `firstapp/Database/full_database_setup.sql`
- ✅ `firstapp/Database/README_MIGRATIONS_AND_SEEDS.md`

---

### BƯỚC 2: Xóa file lạ thủ công

**Cách 1: Dùng PowerShell (KHUYÊN DÙNG)**

```powershell
# Di chuyển vào thư mục project
cd "C:\Users\ADMIN\source\repos\firstapp"

# Liệt kê file lạ
Get-ChildItem -Filter '*finally*' -Recurse

# Xóa file lạ (nếu thấy)
Remove-Item -Path '.\*finally*' -Force -ErrorAction SilentlyContinue

# Kiểm tra lại
git status
```

**Cách 2: Dùng File Explorer**

1. Mở thư mục: `C:\Users\ADMIN\source\repos\firstapp`
2. Bật "Show hidden files": View → ✓ Hidden items
3. Tìm file có tên chứa `finally` hoặc `echo`
4. Delete file đó
5. Refresh
6. Chạy `git status` lại

**Cách 3: Dùng Git (AN TOÀN NHẤT)**

```powershell
# Xem file nào sẽ bị xóa (CHỈ XEM, KHÔNG XÓA)
git clean -n

# Xóa CHỈ untracked files (không xóa file đã add)
git clean -fd

# NHƯNG TRƯỚC ĐÓ phải add các file quan trọng!
git add firstapp/Forms/frmTaskDetail.cs
git add firstapp/Forms/frmTaskDetail.Designer.cs
git add firstapp/Database/
```

---

### BƯỚC 3: Add, Commit và Push

```powershell
# 1. Add tất cả files (files lạ đã xóa)
git add .

# 2. Kiểm tra những gì sẽ commit
git status

# 3. Commit với message rõ ràng
git commit -m "fix: Restore database files and frmTaskDetail

- Restore full_database_setup.sql
- Restore README_MIGRATIONS_AND_SEEDS.md
- Recreate frmTaskDetail.cs and Designer
- Remove temp files
- Build successful"

# 4. Push lên GitHub
git push origin master
```

---

## 🚀 SCRIPT TỰ ĐỘNG (COPY & PASTE)

Copy toàn bộ script dưới đây và paste vào PowerShell:

```powershell
# Di chuyển vào thư mục project
cd "C:\Users\ADMIN\source\repos\firstapp"

Write-Host "==================================" -ForegroundColor Cyan
Write-Host "  CLEAN UP & PUSH SCRIPT" -ForegroundColor Cyan
Write-Host "==================================" -ForegroundColor Cyan
Write-Host ""

# Bước 1: Add các file quan trọng trước
Write-Host "Bước 1: Add files quan trọng..." -ForegroundColor Yellow
git add firstapp/Forms/frmTaskDetail.cs
git add firstapp/Forms/frmTaskDetail.Designer.cs
git add firstapp/Database/
git add RECOVERY_AND_PUSH_GUIDE.md
Write-Host "✅ Đã add files quan trọng" -ForegroundColor Green
Write-Host ""

# Bước 2: Xóa file lạ
Write-Host "Bước 2: Xóa file lạ..." -ForegroundColor Yellow
Remove-Item -Path '.\*finally*' -Force -ErrorAction SilentlyContinue
Remove-Item -Path '.\*echo*' -Force -ErrorAction SilentlyContinue
Write-Host "✅ Đã xóa file lạ" -ForegroundColor Green
Write-Host ""

# Bước 3: Kiểm tra status
Write-Host "Bước 3: Kiểm tra git status..." -ForegroundColor Yellow
git status
Write-Host ""

# Bước 4: Commit
Write-Host "Bước 4: Commit changes..." -ForegroundColor Yellow
git commit -m "fix: Restore database files and fix frmTaskDetail

- Restore full_database_setup.sql with complete schema
- Restore README_MIGRATIONS_AND_SEEDS.md
- Recreate frmTaskDetail.cs and Designer.cs
- Remove temp PowerShell artifacts
- Build successful, all errors fixed"

Write-Host "✅ Đã commit" -ForegroundColor Green
Write-Host ""

# Bước 5: Push
Write-Host "Bước 5: Push to GitHub..." -ForegroundColor Yellow
Write-Host "Đang push..." -ForegroundColor Cyan
git push origin master

Write-Host ""
Write-Host "==================================" -ForegroundColor Green
Write-Host "  ✅ HOÀN TẤT!" -ForegroundColor Green
Write-Host "==================================" -ForegroundColor Green
Write-Host ""
Write-Host "Kiểm tra tại: https://github.com/Nguyen15idhue/btlwindow" -ForegroundColor Cyan
```

---

## 🔐 NẾU GẶP LỖI AUTHENTICATION

### Lỗi: "Permission denied"

```powershell
# Cách 1: Dùng Personal Access Token
git remote set-url origin https://YOUR_TOKEN@github.com/Nguyen15idhue/btlwindow.git
git push origin master

# Cách 2: Cache credentials
git config --global credential.helper store
git push origin master
# Nhập username: Nguyen15idhue
# Nhập password: YOUR_PAT (từ GitHub settings/tokens)
```

### Tạo Personal Access Token:
1. Vào: https://github.com/settings/tokens
2. Click "Generate new token (classic)"
3. Chọn quyền: `repo`
4. Click "Generate token"
5. Copy token (chỉ hiện 1 lần!)

---

## 📊 KIỂM TRA KẾT QUẢ

### Trên Local:
```powershell
git log --oneline -3
# Bạn sẽ thấy 2 commits mới:
# - feat: Add View/Edit/Delete tasks + Drag & Drop
# - fix: Restore database files...
```

### Trên GitHub:
Vào: https://github.com/Nguyen15idhue/btlwindow

Kiểm tra:
- [ ] Commit mới xuất hiện
- [ ] File `firstapp/Database/full_database_setup.sql` có
- [ ] File `firstapp/Database/README_MIGRATIONS_AND_SEEDS.md` có
- [ ] File `firstapp/Forms/frmTaskDetail.cs` có
- [ ] Không có file lạ

---

## ⚡ QUICK FIX (1 LỆNH)

Nếu muốn nhanh, copy lệnh này:

```powershell
cd "C:\Users\ADMIN\source\repos\firstapp"; git add firstapp/; git commit -m "fix: Restore missing files"; git push origin master
```

---

## 🎯 TÓM TẮT

### Vấn đề:
- ❌ File `frmTaskDetail.cs` bị mất
- ❌ File `full_database_setup.sql` bị mất
- ❌ File lạ từ PowerShell

### Đã fix:
- ✅ Tạo lại `frmTaskDetail.cs` + Designer
- ✅ Tạo lại `full_database_setup.sql`
- ✅ Tạo lại `README_MIGRATIONS_AND_SEEDS.md`
- ✅ Build successful
- ✅ Sẵn sàng push

### Cần làm:
1. ⏳ Xóa file lạ (optional)
2. ⏳ Add files
3. ⏳ Commit
4. ⏳ Push

---

**Status:** ✅ BUILD SUCCESSFUL - READY TO PUSH  
**Next Step:** Run script ở trên hoặc làm thủ công theo BƯỚC 3

---

🎉 **GOOD LUCK!** 🚀
