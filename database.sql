﻿use master
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

create table KhachHang (
	ma_kh int not null identity primary key,
	ten_kh nvarchar(60),
	sdt char(12)
)

create table SanPham (
	ma_sp int not null identity primary key,
	ten_sp nvarchar(60),
	mo_ta nvarchar(200),
	so_luong int,
	don_gia int,
	loai nvarchar(20)
)

create table DanhSach (
	ma_ds int not null identity primary key,
	ten_ds nvarchar(60)
)

create table Ban (
	ma_ban int not null identity primary key,
	ten_ban nvarchar(20),
	trang_thai int default 0
)

create table HoaDon (
	ma_hd int not null identity primary key,
	ma_nv int,
	ma_ban int,
	ngay date,
	trang_thai_hd int,
	ma_km char(10),
	constraint pk_nv foreign key(ma_nv) references NhanVien(ma_nv),
	constraint pk_ban foreign key(ma_ban) references Ban(ma_ban)
)

--alter table HoaDon drop column ma_kh
--alter table HoaDon drop constraint pk_kh

create table ChiTietHoaDon (
	ma_cthd int not null identity primary key,
	ma_hd int,
	ma_sp int,
	so_luong int,
	constraint fk_hd foreign key(ma_hd) references HoaDon(ma_hd),
	constraint fk_sp foreign key(ma_sp) references SanPham(ma_sp)
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
	constraint ctmn_mn foreign key(ma_menu) references Menu(ma_menu),
	constraint ctmn_sp foreign key(ma_sp) references SanPham(ma_sp),
)

insert into SanPham values
(N'Chân giò xông khói', N'Chân giò xông khói hương vị truyền thống', 40, 25000, 1)
insert into SanPham values
(N'Chả lụa', N'Chả lụa chất lượng cao', 20, 250000, N'Đồ ăn')
insert into SanPham values
(N'Rượu ngô', N'Rượu ngô', 40, 25000, N'Đồ uống')
insert into Ban values
(N'Bàn 1'),
(N'Bàn 2'),
(N'Bàn 3'),
(N'Bàn 4'),
(N'Bàn 5'),
(N'Bàn 6'),
(N'Bàn 7'),
(N'Bàn 8'),
(N'Bàn 9'),
(N'Bàn 10')


alter table SanPham alter column loai nvarchar(20)
alter table Ban add trang_thai int default 0
select * from SanPham
select * from ChiTietMenu
delete from Menu
delete from ChiTietMenu
select * from Ban
select * from HoaDon
update Ban set trang_thai = 0