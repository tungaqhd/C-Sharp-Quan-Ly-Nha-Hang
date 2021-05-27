use master
create database QLNhaHang
use QLNhaHang

create table NhanVien (
	ma_nv int not null identity primary key,
	ten_nv nvarchar(60),
	username varchar(30),
	password varchar(75),
	ngay_sinh date,
	chuc_vu varchar(10)
)

create table SanPham (
	ma_sp int not null identity primary key,
	ten_sp nvarchar(60),
	mo_ta nvarchar(200),
	so_luong int,
	don_gia int,
	loai nvarchar(20),
	anh image default null
)

create table Ban (
	ma_ban int not null identity primary key,
	ten_ban nvarchar(20),
	trang_thai int default 0
)

create table KhuyenMai (
	ma_km char(10) primary key,
	ten_km nvarchar(30),
	yeu_cau int,
	tien_giam int
)

create table Menu (
	ma_menu int not null identity primary key,
	ten_menu nvarchar(30),
)

create table ChiTietMenu (
	ma_ct_mn int not null identity primary key,
	ma_menu int,
	ma_sp int,
	constraint fk_ctmn_mn foreign key(ma_menu) references Menu(ma_menu) on update cascade on delete cascade,
	constraint fk_ctmn_sp foreign key(ma_sp) references SanPham(ma_sp) on update cascade on delete cascade,
)

create table HoaDon (
	ma_hd int not null identity primary key,
	ma_nv int,
	ma_ban int,
	ngay date,
	trang_thai_hd int,
	ma_km char(10),
	constraint fk_nv foreign key(ma_nv) references NhanVien(ma_nv) on update cascade on delete cascade,
	constraint fk_ban foreign key(ma_ban) references Ban(ma_ban) on update cascade on delete cascade,
	constraint fk_km foreign key(ma_km) references KhuyenMai(ma_km) on update cascade on delete cascade
)

create table ChiTietHoaDon (
	ma_cthd int not null identity primary key,
	ma_hd int,
	ma_sp int,
	so_luong int,
	constraint fk_hd foreign key(ma_hd) references HoaDon(ma_hd) on update cascade on delete cascade,
	constraint fk_sp foreign key(ma_sp) references SanPham(ma_sp) on update cascade on delete cascade
)

insert into SanPham values
(N'Chân giò xông khói', N'Chân giò xông khói hương vị truyền thống', 40, 25000, N'Đồ ăn', NULL)
insert into SanPham values
(N'Chả lụa', N'Chả lụa chất lượng cao', 20, 250000, N'Đồ ăn', NULL)
insert into SanPham values
(N'Rượu ngô', N'Rượu ngô', 40, 25000, N'Đồ uống', NULL)
insert into Ban values
(N'Bàn 1', 1),
(N'Bàn 2', 1),
(N'Bàn 3', 1),
(N'Bàn 4', 1),
(N'Bàn 5', 1),
(N'Bàn 6', 1),
(N'Bàn 7', 1),
(N'Bàn 8', 1),
(N'Bàn 9', 1),
(N'Bàn 10', 1)

insert into NhanVien values
(N'Quản trị viên 1', 'admin', '123', '1/1/2000', 'quanly'),
(N'Nhân viên 1', 'user', '123', '1/1/2000', 'nhanvien')

select * from KhuyenMai
select * from HoaDon

select * from Ban
select * from HoaDon