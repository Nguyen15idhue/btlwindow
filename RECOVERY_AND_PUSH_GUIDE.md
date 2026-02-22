# ✅ HƯỚNG DẪN KHÔI PHỤC VÀ GIT PUSH

## 🎉 ĐÃ KHÔI PHỤC THÀNH CÔNG!

### 2 File đã được tạo lại:
1. ✅ `firstapp/Database/full_database_setup.sql`
2. ✅ `firstapp/Database/README_MIGRATIONS_AND_SEEDS.md`

---

## 📝 CÁC BƯỚC TIẾP THEO

### Bước 1: Kiểm tra status
```powershell
cd "C:\Users\ADMIN\source\repos\firstapp"
git status
```

**Kết quả:** Bạn sẽ thấy 2 file mới trong "Changes to be committed"

---

### Bước 2: Commit các file đã khôi phục
```powershell
git commit -m "docs: Restore database setup files

- Restore full_database_setup.sql with complete schema
- Restore README_MIGRATIONS_AND_SEEDS.md with documentation
- Add tables: nguoi_dung, cong_viec, tags, nhom_cong_viec
- Add view: v_cong_viec_full
- Add stored procedures"
```

---

### Bước 3: Push lên GitHub
```powershell
git push origin master
```

**Lưu ý:** Nếu GitHub yêu cầu authentication, bạn cần:
- Personal Access Token (PAT)
- Hoặc SSH key

---

## 🔐 NẾU GẶP LỖI AUTHENTICATION

### Cách 1: Dùng Personal Access Token (PAT)

1. **Tạo PAT trên GitHub:**
   - Vào: https://github.com/settings/tokens
   - Click "Generate new token (classic)"
   - Chọn quyền: `repo` (Full control of private repositories)
   - Click "Generate token"
   - **Copy token ngay** (chỉ hiện 1 lần!)

2. **Push với PAT:**
```powershell
git push https://YOUR_TOKEN@github.com/Nguyen15idhue/btlwindow.git master
```

Hoặc cache credential:
```powershell
git config --global credential.helper store
git push origin master
# Nhập username: Nguyen15idhue
# Nhập password: YOUR_PAT_TOKEN
```

---

### Cách 2: Dùng GitHub Desktop (DỄ NHẤT)

1. Tải GitHub Desktop: https://desktop.github.com/
2. Đăng nhập GitHub
3. Add repository: `C:\Users\ADMIN\source\repos\firstapp`
4. Commit changes
5. Click "Push origin" (1 click!)

---

## 🚨 XỬ LÝ FILE LẠ (Nếu có)

Nếu bạn thấy file lạ như `" } finally { if ($...`:

```powershell
# Xóa file lạ
git clean -fd

# Kiểm tra lại
git status
```

---

## 📊 KIỂM TRA SAU KHI PUSH

Vào GitHub repo của bạn:
```
https://github.com/Nguyen15idhue/btlwindow
```

Kiểm tra:
- [ ] Folder `firstapp/Database/` có file `full_database_setup.sql`
- [ ] Folder `firstapp/Database/` có file `README_MIGRATIONS_AND_SEEDS.md`
- [ ] Commit message hiển thị đúng
- [ ] Files có nội dung đầy đủ

---

## 🎯 LỜI KHUYÊN TRÁNH MẤT FILE

### 1. Commit thường xuyên
```powershell
# Mỗi khi tạo file mới quan trọng:
git add .
git commit -m "Add new feature"
git push
```

### 2. KHÔNG dùng `git clean -fd` khi có untracked files
- `git clean` sẽ **XÓA VĨNH VIỄN** các file chưa được add
- Chỉ dùng khi chắc chắn muốn xóa

### 3. Backup quan trọng
- Copy folder Database ra ngoài
- Hoặc dùng GitHub như backup chính

### 4. Kiểm tra trước khi clean
```powershell
# Xem file nào sẽ bị xóa (KHÔNG xóa)
git clean -n

# Chỉ xóa khi chắc chắn
git clean -fd
```

---

## 🔄 QUY TRÌNH GIT CHUẨN

```powershell
# 1. Kiểm tra status
git status

# 2. Add các file cần commit
git add .

# 3. Commit với message rõ ràng
git commit -m "feat: Add new feature XYZ"

# 4. Pull trước khi push (nếu làm team)
git pull origin master

# 5. Push lên remote
git push origin master

# 6. Verify trên GitHub
# Check web: https://github.com/Nguyen15idhue/btlwindow
```

---

## ✅ CHECKLIST HOÀN THÀNH

- [x] File `full_database_setup.sql` đã được tạo
- [x] File `README_MIGRATIONS_AND_SEEDS.md` đã được tạo
- [x] Files đã được add vào staging
- [ ] **TODO: Commit changes**
- [ ] **TODO: Push to GitHub**
- [ ] **TODO: Verify trên GitHub**

---

## 📞 NẾU CẦN TRỢ GIÚP

Nếu gặp lỗi khi push, hãy:

1. Chụp screenshot lỗi
2. Copy toàn bộ message lỗi
3. Kiểm tra kết nối internet
4. Thử push lại với GitHub Desktop

---

**Ngày tạo:** $(Get-Date -Format "dd/MM/yyyy HH:mm")  
**Status:** ✅ Files Restored - Ready to Commit & Push

---

🎉 **HAPPY CODING!** 🚀
