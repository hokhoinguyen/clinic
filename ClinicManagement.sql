Use Clinic
Go

Create Table NguoiDung
(
	MaND int Identity(1, 1) Primary Key not null,
	Ho nvarchar(256),
	Ten nvarchar(50),
	TenDangNhap nvarchar(100),
	MatKhau nvarchar(256),
	Email nvarchar(256),
	Avatar nvarchar(256),
	MaQuyen int,
	Foreign Key (MaQuyen) References dbo.Quyen (MaQuyen)
)

Create Table Quyen
(
	MaQuyen int Identity(1, 1) Primary Key not null,
	TenQuyen nvarchar(50),
	MoTaQuyen nvarchar(256)
)

Create Table BacSi
(
	MaBacSi int Identity(1, 1) Primary Key not null,
	Ho nvarchar(256),
	Ten nvarchar(50) ,
	NgaySinh date ,
	ChucVu nvarchar(50) ,
	GioiTinh nvarchar(20) ,
	DiaChi nvarchar(256),
	SoDienThoai nvarchar(20) ,
	BangCap nvarchar(50) ,
	ChuyenMon nvarchar(50) ,
	MaND int ,
	Foreign Key (MaND) References dbo.NguoiDung (MaND)
)

Create Table YTa
(
	MaYTa int Identity(1, 1) Primary Key not null,
	Ho nvarchar(256) ,
	Ten nvarchar(50) ,
	NgaySinh date ,
	GioiTinh nvarchar(20) ,
	DiaChi nvarchar(256),
	SoDienThoai nvarchar(20) ,
	BangCap nvarchar(50) ,
	ChuyenMon nvarchar(50) ,
	MaND int ,
	Foreign Key (MaND) References dbo.NguoiDung (MaND)
)

Create Table BenhNhan
(
	MaBenhNhan int Identity(1, 1) Primary Key not null,
	Ho nvarchar(256) ,
	Ten nvarchar(50) ,
	NgaySinh date ,
	SoCCCD nvarchar(50) ,
	GioiTinh nvarchar(20) ,
	DiaChi nvarchar(256),
	SoDienThoai nvarchar(20) ,
	MaND int ,
	Foreign Key (MaND) References dbo.NguoiDung (MaND)
)

Create Table LichHen
(
	MaLichHen int Identity(1, 1) Primary Key not null,
	MaBenhNhan int ,
	Foreign Key (MaBenhNhan) References dbo.BenhNhan (MaBenhNhan),
	MaBacSi int ,
	Foreign Key (MaBacSi) References dbo.BacSi (MaBacSi),
	NgayGioHen datetime,
	TrangThai nvarchar(50) 
)

Create Table Thuoc
(
	MaThuoc int Identity(1, 1) Primary Key not null,
	TenThuoc nvarchar(50),
	MoTa nvarchar(100),
	HangSanXuat nvarchar(100),
	GiaNiemYet money,
	MaLoaiThuoc int ,
	Foreign Key (MaLoaiThuoc) References dbo.LoaiThuoc (MaLoaiThuoc)
)

Create Table LoaiThuoc
(
	MaLoaiThuoc int Identity(1, 1) Primary Key not null,
	TenLoaiThuoc nvarchar(50),
	MoTa nvarchar(100)
)

Create Table DonThuoc
(
	MaDonThuoc int Identity(1, 1) Primary Key not null,
	MaLichHen int ,
	Foreign Key (MaLichHen) References dbo.LichHen (MaLichHen),
	NgayKeDon date ,
	TrieuChung nvarchar(256),
	KetLuan nvarchar(256)
	MaThuoc int ,
	Foreign Key (MaThuoc) References dbo.Thuoc (MaThuoc),
)

Create Table KhamBenh
(
	MaKhamBenh int Identity(1, 1) Primary Key not null,
	MaBenhNhan int ,
	Foreign Key (MaBenhNhan) References dbo.BenhNhan (MaBenhNhan),
	MaBacSi int ,
	Foreign Key (MaBacSi) References dbo.BacSi (MaBacSi),
	MaLichHen int ,
	Foreign Key (MaLichHen) References dbo.LichHen (MaLichHen),
	NgayGioKham datetime,
	TienSuBenh nvarchar(256),
	QuaTrinhDieuTri nvarchar(256),
	CacXetNghiem nvarchar(256),
	KetLuan nvarchar(256),
	HenTaiKham date
)

Create Table DonThuocKhamBenh
(
	MaDonThuoc int not null,
	Foreign Key (MaDonThuoc) References dbo.DonThuoc (MaDonThuoc)
	MaKhamBenh int not null,
	Foreign Key (MaKhamBenh) References dbo.KhamBenh (MaKhamBenh),
	NgayGioKham datetime,
	TienSuBenh nvarchar(256),
	QuaTrinhDieuTri nvarchar(256),
	CacXetNghiem nvarchar(256),
	KetLuan nvarchar(256),
	HenTaiKham date
)
ALTER TABLE dbo.DonThuocKhamBenh ADD PRIMARY KEY(MaDonThuoc, MaKhamBenh)

Insert Into Quyen Values(N'Admin', N'QL bác sĩ, y tá, sắp lịch trực, quản lý thuốc, thống kê báo cáo')
Insert Into Quyen Values(N'Doctor', N'Ra toa thuốc, tìm kiếm thuốc, chỉ định triệu chứng, kết luận và danh mục thuốc uống. Xem lịch sử khám bệnh')
Insert Into Quyen Values(N'Nurse', N'Xác nhận lịch đăng ký khám của bệnh nhân')
Insert Into Quyen Values(N'Patient', N'Đăng ký tài khoản, đăng ký hoặc hủy lịch khám')

Insert Into NguoiDung Values(N'Trần Thị Bình', N'Minh', N'binhminh', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'biminh123@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1693581087/avatar/girl-cartoon-characters-1_igbcxo.jpg', 4)
Insert Into NguoiDung Values(N'Lê Văn', N'Hòa', 'vhoa123', '2dc0269fa54d269a87536810ec453cb095b4b92f45e63826a21dff1c2e76f169', 'vanhoa10@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1693581098/avatar/Cartoon-Images-For-Boys2-1_anyb6l.jpg', 4)
Insert Into NguoiDung Values(N'Nguyễn Thị Anh', N'Thư', 'anhthu', 'd7da6caa27948d250f1ea385bf587f9d348c7334b23fa1766016b503572a73a8', 'anhthu@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1693581394/avatar/vanessa_t6tl6t.webp', 4)
Insert Into NguoiDung Values(N'Phạm Văn', N'Quang', 'vanquang456', '472bbe83616e93d3c09a79103ae47d8f71e3d35a966d6e8b22f743218d04171d', 'vquang456@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1693581097/avatar/Cartoon-Images-For-Boys7-1_legz80.jpg', 4)
Insert Into NguoiDung Values(N'Hoàng Thị', N'Thảo', 'thao123', 'b39667cf64cd5bc6cd7adbfc711cd8446036f9144c1cceb604897b0e824a027d', 'thaohoang@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1693581640/avatar/candace_a5itwd.jpg', 3)
Insert Into NguoiDung Values(N'Đặng Văn', N'Nam', 'vannam', '96931d66ec7b275ebae30dbc25e80275fabb94c82d92504f9d10a8a6ce038146', 'vannam12@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1693581097/avatar/Cartoon-Images-For-Boys28-1_qjbkjb.jpg', 3)
Insert Into NguoiDung Values(N'Nguyễn Thanh', N'Hương', 'thhuong', '2cf24dba5fb0a30e26e83b2ac5b9e29e1b161e5c1fa7425e73043362938b9824', 'thhuong@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1695277742/avatar/female1_mtronb.jpg', 2)
Insert Into NguoiDung Values(N'Trần Văn', N'Minh', 'vanminh', '66f1218bbd7a840aad6f611d090731acffce60f70ef426f01dffad30bce18528', 'vanminh@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1695277580/avatar/male2_qrqjao.jpg', 2)
Insert Into NguoiDung Values(N'Lê Thị Mai', N'Anh', 'maianh', '25d03bc524a4e50486d8f46e97f1cdc812d7e5b5aee7e736b42283c1ea4102b0', 'ltmanh@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1695277743/avatar/female3_hdwhhk.jpg', 2)
Insert Into NguoiDung Values(N'Phạm Quốc', N'Bảo', 'quocbao', 'd0903d035484f13b9ac92ab3b486364d8676790d792c410c48ea4d6db467ed61', 'baopham@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1695277743/avatar/male4_dcoiai.webp', 2)
Insert Into NguoiDung Values(N'Hoàng Đức', N'Thịnh', 'hoangthinh', 'dba910777e9572b0821f0db47466f94225aa7face126eaae882416e82eb2e722', 'thinhhoang123@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1695277744/avatar/male3_eji408.jpg', 1)
Insert Into NguoiDung Values(N'Ngô Thị Lan', N'Anh', 'anhngo', '99d1d363a47c8f8b6f0690d57b06d06ec1d972e9e3ccb896c43541b230fea483', 'anhngo@gmail.com', 'https://res.cloudinary.com/dlxhvabif/image/upload/v1695277744/avatar/female4_pit154.webp', 1)

Insert Into BacSi Values(N'Nguyễn Thanh', N'Hương', '1990-03-15', N'Bác sĩ chuyên khoa', N'Nữ', N'123 Đường Lê Lợi, Quận 1, TP.HCM', '0156478441', N'Tiến sĩ da liễu', N'Da liễu', 7)
Insert Into BacSi Values(N'Trần Văn', N'Minh', '1985-08-27', N'Bác sĩ chuyên khoa', N'Nam', N'456 Đường Nguyễn Đình Chính, Quận Phú Nhuận, TP.HCM', '0984815474', N'Tiến sĩ tim mạch', N'Tim mạch', 8)
Insert Into BacSi Values(N'Lê Thị Mai', N'Anh', '1990-12-04', N'Bác sĩ tổng quát', N'Nữ', N'789 Đường Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP.HCM', '0224844870', N'Thạc sĩ y học', N'Tổng quát', 9)
Insert Into BacSi Values(N'Phạm Quốc', N'Bảo', '1988-05-19', N'Bác sĩ chuyên khoa', N'Nam', N'234 Đường Trần Hưng Đạo, Quận 5, TP.HCM', '0811578622', N'Tiến sĩ răng hàm mặt', N'Răng, hàm, mặt', 10)

Insert Into YTa Values(N'Hoàng Thị', N'Thảo', '1992-04-12', N'Nữ', N'321 Đường Nguyễn Công Trứ, Quận Bình Thạnh, TP.HCM', '0156840189', N'Cao đẳng y tế', N'Y tế ngoại trú', 5)
Insert Into YTa Values(N'Đặng Văn', N'Nam', '1993-09-28', N'Nam', N'567 Đường Hoàng Sa, Quận 1, TP.HCM', '0984157324', N'Cao đẳng y tế', N'Y tế cộng đồng', 6)

Insert Into BenhNhan Values(N'Trần Thị Bình', N'Minh', '1995-08-12', '0154157655823', N'Nữ', N'234 Hoàng Hoa Thám, Phường Tân Bình, Quận Tân Bình, TP.HCM', '0791551843', 1)
Insert Into BenhNhan Values(N'Lê Văn', N'Hòa', '1987-04-25', '095648778102', N'Nam', N'101 Đinh Công Tráng, Phường Tân Định, Quận 1, TP.HCM', '0546879526', 2)
Insert Into BenhNhan Values(N'Nguyễn Thị Anh', N'Thư', '2000-11-03', '098451895657', N'Nữ', N'789 Lê Văn Việt, Phường Hiệp Phú, Quận 9, TP.HCM', '0849156237', 3)
Insert Into BenhNhan Values(N'Phạm Văn', N'Quang', '1978-02-19', '081536514959', N'Nam', N'123 Nguyễn Đình Chính, Phường Tân Phú, Quận 7, TP.HCM', '0916584327', 4)

Insert Into LoaiThuoc Values(N'Thuốc chống viêm', N'Thuốc chống viêm là nhóm thuốc được sử dụng để giảm viêm nhiễm trong cơ thể')
Insert Into LoaiThuoc Values(N'Thuốc kháng sinh', N'Thuốc kháng sinh là nhóm thuốc được sử dụng để chữa trị các bệnh nhiễm trùng do vi khuẩn')
Insert Into LoaiThuoc Values(N'Thuốc chống dị ứng', N'Thuốc chống dị ứng được sử dụng để giảm triệu chứng dị ứng')
Insert Into LoaiThuoc Values(N'Thuốc chống đau', N'Thuốc chống đau là nhóm thuốc được sử dụng để giảm đau')
Insert Into LoaiThuoc Values(N'Thuốc chống tăng nhịp tim', N'Là một nhóm thuốc được sử dụng để điều trị các vấn đề tim mạch')
Insert Into LoaiThuoc Values(N'Thuốc trị mụn', N'Được sử dụng để điều trị mụn trứng cá và các vấn đề da liễu khác')

Insert Into Thuoc Values(N'Ibuprofen', N'Ibuprofen được sử dụng để giảm đau và sưng viêm', N'Motrin', 200000, 1)
Insert Into Thuoc Values(N'Naproxen', N'Naproxen được dùng để điều trị đau cơ xương, đau viêm khớp, và các tình trạng đau viêm khác', N'Naprosyn', 250000, 1)
Insert Into Thuoc Values(N'Amoxicillin', N'Amoxicillin được sử dụng để điều trị các nhiễm trùng nặng nhẹ', N'Amoxil', 260000, 2)
Insert Into Thuoc Values(N'Ciprofloxacin', N'Ciprofloxacin được sử dụng để điều trị nhiễm trùng do vi khuẩn', N'Ciloxan', 300000, 2)
Insert Into Thuoc Values(N'Loratadine', N'Loratadine được sử dụng để giảm triệu chứng dị ứng như ngứa, chảy nước mắt, và sưng đỏ', N'Claritin', 300000, 3)
Insert Into Thuoc Values(N'Diphenhydramine', N'Diphenhydramine được sử dụng để giảm triệu chứng dị ứng như ngứa, sưng đỏ, và nốt phát ban', N'Benadryl', 320000, 3)
Insert Into Thuoc Values(N'Paracetamol', N'Paracetamol được sử dụng để giảm đau từ đau đầu, đau cơ xương, đau rát cổ họng,...', N'Panadol', 200000, 4)
Insert Into Thuoc Values(N'Tramadol', N'Tramadol được sử dụng để điều trị đau từ trung bình đến nặng', N'ConZip', 250000, 4)
Insert Into Thuoc Values(N'Metoprolol', N'Metoprolol được sử dụng để điều trị các tình trạng như tăng huyết áp, bệnh tim vành,...', N'Lopressor', 260000, 5)
Insert Into Thuoc Values(N'Propranolol', N'Propranolol điều trị nhiều vấn đề tim mạch như rối loạn nhịp tim, tăng huyết áp,...', N'InnoPran XL', 260000, 5)
Insert Into Thuoc Values(N'Benzoyl Peroxide', N'Benzoyl Peroxide giết khuẩn, loại bỏ dầu thừa và tế bào da chết,...', N'Clearasil', 200000, 6)
Insert Into Thuoc Values(N'Salicylic Acid', N'Salicylic Acid được sử dụng để trị mụn và làm sạch lỗ chân lông', N'Neutrogena', 220000, 6)

Insert Into LichHen Values(1, 1, '2023-11-01 07:00:00', N'Chưa xác nhận')
Insert Into LichHen Values(2, 1, '2023-11-01 08:00:00', N'Chưa xác nhận')
Insert Into LichHen Values(3, 2, '2023-11-02 08:00:00', N'Chưa xác nhận')
Insert Into LichHen Values(4, 2, '2023-11-02 09:00:00', N'Chưa xác nhận')
Insert Into LichHen Values(5, 3, '2023-11-03 09:00:00', N'Chưa xác nhận')
Insert Into LichHen Values(6, 3, '2023-11-03 10:00:00', N'Chưa xác nhận')
Insert Into LichHen Values(7, 4, '2023-11-04 08:00:00', N'Chưa xác nhận')
Insert Into LichHen Values(8, 4, '2023-11-04 09:00:00', N'Chưa xác nhận')