create database QLTV
USE [QLTV]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/24/2024 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDanhMuc]    Script Date: 11/24/2024 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDanhMuc](
	[sMaDanhMuc] [varchar](10) NOT NULL,
	[sTenDanhMuc] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[sMaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDanhSachMuon]    Script Date: 11/24/2024 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDanhSachMuon](
	[sMaDanhSach] [varchar](10) NULL,
	[sMaSach] [varchar](10) NOT NULL,
	[sMaTheMuon] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sMaSach] ASC,
	[sMaTheMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNguoiDung]    Script Date: 11/24/2024 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNguoiDung](
	[sMaNguoiDung] [nvarchar](100) NOT NULL,
	[sTenNguoiDung] [nvarchar](50) NULL,
	[sCCCD] [varchar](50) NULL,
	[sDiaChi] [nvarchar](100) NULL,
	[dNgaySinh] [date] NULL,
	[sMaTheMuon] [varchar](10) NULL,
 CONSTRAINT [PK_nguoidung] PRIMARY KEY CLUSTERED 
(
	[sMaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQuyen]    Script Date: 11/24/2024 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuyen](
	[sID] [varchar](10) NOT NULL,
	[sTenQuyen] [varchar](50) NULL,
	[iMaQuyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSach]    Script Date: 11/24/2024 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSach](
	[sMaSach] [varchar](10) NOT NULL,
	[sTenSach] [nvarchar](50) NULL,
	[sNhaXuatBan] [nvarchar](50) NULL,
	[sMoTa] [nvarchar](50) NULL,
	[iSoLuong] [int] NULL,
	[sTrangThai] [nvarchar](50) NULL,
	[fGiaTien] [float] NULL,
	[sMaDanhMuc] [varchar](10) NULL,
	[sTenTacGia] [nvarchar](50) NULL,
	[sDuongDan] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[sMaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTaiKhoan]    Script Date: 11/24/2024 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaiKhoan](
	[sTaiKhoan] [varchar](50) NOT NULL,
	[sMatKhau] [varchar](50) NULL,
	[sMaQuyen] [varchar](10) NULL,
	[sMaNguoiDung] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__tblTaiKh__868A5E9D88AE4BA6] PRIMARY KEY CLUSTERED 
(
	[sTaiKhoan] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTheMuon]    Script Date: 11/24/2024 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTheMuon](
	[sMaTheMuon] [varchar](10) NOT NULL,
	[dNgayMuon] [date] NULL,
	[dNgayTra] [date] NULL,
	[dNgayTraDuKien] [date] NULL,
	[dNgayTraThucTe] [date] NULL,
	[sTrangThai] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[sMaTheMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblDanhSachMuon]  WITH CHECK ADD  CONSTRAINT [FK__tblDanhSa__sMaDa__5629CD9C] FOREIGN KEY([sMaSach])
REFERENCES [dbo].[tblSach] ([sMaSach])
GO
ALTER TABLE [dbo].[tblDanhSachMuon] CHECK CONSTRAINT [FK__tblDanhSa__sMaDa__5629CD9C]
GO
ALTER TABLE [dbo].[tblDanhSachMuon]  WITH CHECK ADD FOREIGN KEY([sMaTheMuon])
REFERENCES [dbo].[tblTheMuon] ([sMaTheMuon])
GO
ALTER TABLE [dbo].[tblNguoiDung]  WITH CHECK ADD FOREIGN KEY([sMaTheMuon])
REFERENCES [dbo].[tblTheMuon] ([sMaTheMuon])
GO
ALTER TABLE [dbo].[tblSach]  WITH CHECK ADD FOREIGN KEY([sMaDanhMuc])
REFERENCES [dbo].[tblDanhMuc] ([sMaDanhMuc])
GO
ALTER TABLE [dbo].[tblTaiKhoan]  WITH CHECK ADD FOREIGN KEY([sMaQuyen])
REFERENCES [dbo].[tblQuyen] ([sID])
GO
ALTER TABLE [dbo].[tblTaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_taikhoan_nguoidung] FOREIGN KEY([sMaNguoiDung])
REFERENCES [dbo].[tblNguoiDung] ([sMaNguoiDung])
GO
ALTER TABLE [dbo].[tblTaiKhoan] CHECK CONSTRAINT [FK_taikhoan_nguoidung]
GO
INSERT INTO tblDanhMuc(sMaDanhMuc,sTenDanhMuc)
VALUES


(1,N'Ngôn tình'),
(2,N'Trinh thám'),
(3,N'Cổ tích');


INSERT INTO tblSach (sMaSach, sTenSach, sNhaXuatBan, sMoTa, iSoLuong, sTrangThai, fGiaTien, sMaDanhMuc, sTenTacGia, sDuongDan)
VALUES
(N'S001', N'Sách Giáo Khoa', N'NXB Giáo Dục', N'Sách cho học sinh lớp 1', 50, N'Còn hàng', 10000, 1, N'Nguyễn Văn A', N'duongdan1.jpg'),
(N'S002', N'Tiểu Thuyết', N'NXB Văn Học', N'Sách tiểu thuyết lãng mạn', 30, N'Còn hàng', 20000, 2, N'Nguyễn Văn B', N'duongdan2.jpg'),
(N'S003', N'Truyện Tranh', N'NXB Kim Đồng', N'Truyện tranh dành cho trẻ em', 25, N'Hết hàng', 15000, 3, N'Nguyễn Văn C', N'duongdan3.jpg'),
(N'S004', N'Sách Khoa Học', N'NXB Khoa Học', N'Sách kiến thức khoa học', 40, N'Còn hàng', 30000, 1, N'Nguyễn Văn D', N'duongdan4.jpg'),
(N'S005', N'Sách Tâm Lý', N'NXB Tâm Lý Học', N'Sách tâm lý phát triển cá nhân', 35, N'Còn hàng', 25000, 2, N'Nguyễn Văn E', N'duongdan5.jpg'),
(N'S006', N'Sách Nấu Ăn', N'NXB Văn Hoá', N'Sách nấu ăn cho gia đình', 20, N'Còn hàng', 18000, 3, N'Nguyễn Văn F', N'duongdan6.jpg'),
(N'S007', N'Sách Thiếu Nhi', N'NXB Thiếu Nhi', N'Sách dành cho thiếu nhi', 45, N'Còn hàng', 22000, 1, N'Nguyễn Văn G', N'duongdan7.jpg'),
(N'S008', N'Sách Kinh Tế', N'NXB Kinh Tế', N'Sách kiến thức kinh tế', 50, N'Hết hàng', 28000, 2, N'Nguyễn Văn H', N'duongdan8.jpg'),
(N'S009', N'Truyện Cổ Tích', N'NXB Kim Đồng', N'Truyện cổ tích Việt Nam', 60, N'Còn hàng', 12000, 3, N'Nguyễn Văn I', N'duongdan9.jpg'),
(N'S010', N'Sách Y Học', N'NXB Y Học', N'Sách kiến thức y học', 15, N'Còn hàng', 45000, 1, N'Nguyễn Văn J', N'duongdan10.jpg'),
(N'S011', N'Sách Lịch Sử', N'NXB Lịch Sử', N'Sách kiến thức lịch sử', 38, N'Hết hàng', 24000, 2, N'Nguyễn Văn K', N'duongdan11.jpg'),
(N'S012', N'Sách Địa Lý', N'NXB Giáo Dục', N'Sách kiến thức địa lý', 27, N'Còn hàng', 26000, 3, N'Nguyễn Văn L', N'duongdan12.jpg'),
(N'S013', N'Sách Triết Học', N'NXB Triết Học', N'Sách triết học phổ thông', 22, N'Còn hàng', 32000, 1, N'Nguyễn Văn M', N'duongdan13.jpg'),
(N'S014', N'Sách Sinh Học', N'NXB Giáo Dục', N'Sách kiến thức sinh học', 33, N'Còn hàng', 21000, 2, N'Nguyễn Văn N', N'duongdan14.jpg'),
(N'S015', N'Sách Công Nghệ', N'NXB Công Nghệ', N'Sách kiến thức công nghệ', 29, N'Còn hàng', 50000, 3, N'Nguyễn Văn O', N'duongdan15.jpg'),
(N'S016', N'Sách Tài Chính', N'NXB Kinh Tế', N'Sách kiến thức tài chính', 55, N'Còn hàng', 35000, 1, N'Nguyễn Văn P', N'duongdan16.jpg'),
(N'S017', N'Truyện Ngụ Ngôn', N'NXB Kim Đồng', N'Truyện ngụ ngôn bổ ích', 40, N'Hết hàng', 13000, 2, N'Nguyễn Văn Q', N'duongdan17.jpg'),
(N'S018', N'Sách Tư Duy', N'NXB Tâm Lý Học', N'Sách phát triển tư duy', 37, N'Còn hàng', 29000, 3, N'Nguyễn Văn R', N'duongdan18.jpg'),
(N'S019', N'Sách Văn Học', N'NXB Văn Học', N'Sách văn học nổi tiếng', 48, N'Còn hàng', 34000, 1, N'Nguyễn Văn S', N'duongdan19.jpg'),
(N'S020', N'Sách Luật', N'NXB Pháp Luật', N'Sách kiến thức pháp luật', 30, N'Hết hàng', 42000, 2, N'Nguyễn Văn T', N'duongdan20.jpg'),
(N'S021', N'Sách Kỹ Năng', N'NXB Kỹ Năng Sống', N'Sách kỹ năng sống cho trẻ', 45, N'Còn hàng', 27000, 3, N'Nguyễn Văn U', N'duongdan21.jpg'),
(N'S022', N'Sách Thể Thao', N'NXB Thể Thao', N'Sách về các môn thể thao', 20, N'Còn hàng', 15000, 1, N'Nguyễn Văn V', N'duongdan22.jpg'),
(N'S023', N'Sách Môi Trường', N'NXB Môi Trường', N'Sách bảo vệ môi trường', 25, N'Hết hàng', 19000, 2, N'Nguyễn Văn W', N'duongdan23.jpg'),
(N'S024', N'Sách Chính Trị', N'NXB Chính Trị', N'Sách kiến thức chính trị', 40, N'Còn hàng', 37000, 3, N'Nguyễn Văn X', N'duongdan24.jpg'),
(N'S025', N'Sách Nghệ Thuật', N'NXB Nghệ Thuật', N'Sách về nghệ thuật', 55, N'Còn hàng', 33000, 1, N'Nguyễn Văn Y', N'duongdan25.jpg'),
(N'S026', N'Truyện Ma', N'NXB Kim Đồng', N'Truyện ma kinh dị', 20, N'Còn hàng', 11000, 2, N'Nguyễn Văn Z', N'duongdan26.jpg'),
(N'S027', N'Sách Tình Cảm', N'NXB Văn Học', N'Truyện tình cảm tuổi học trò', 60, N'Còn hàng', 17000, 3, N'Nguyễn Văn AA', N'duongdan27.jpg'),
(N'S028', N'Sách Kỹ Thuật', N'NXB Công Nghệ', N'Sách về kỹ thuật cơ khí', 18, N'Hết hàng', 46000, 1, N'Nguyễn Văn BB', N'duongdan28.jpg'),
(N'S029', N'Sách Phát Triển Cá Nhân', N'NXB Tâm Lý Học', N'Sách phát triển bản thân', 35, N'Còn hàng', 25000, 2, N'Nguyễn Văn CC', N'duongdan29.jpg'),
(N'S030', N'Sách Thời Trang', N'NXB Thời Trang', N'Sách về thời trang hiện đại', 50, N'Còn hàng', 39000, 3, N'Nguyễn Văn DD', N'duongdan30.jpg');




select * from tblSach
select * from tblDanhMuc where sMaDanhMuc = 3
select * from tblNguoiDung



select * from tblDanhMuc

update tblDanhMuc
set VerifyKey= 1