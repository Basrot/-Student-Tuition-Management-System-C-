-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 29, 2025 lúc 06:14 PM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `quanlyhocphi`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `account`
--

CREATE TABLE `account` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `role` varchar(20) NOT NULL DEFAULT 'SINHVIEN'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `account`
--

INSERT INTO `account` (`id`, `username`, `email`, `password`, `role`) VALUES
(101, 'basrot', 'nam21620000@gmail.com', '96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e', 'ADMIN'),
(102, 'adminutt', 'adminutt@gmail.com', '85124f7d2f243c9fcdf0b0e04e0d3dbe1fd7e3f29af9c2ccb975e223068097d4', 'SINHVIEN'),
(103, 'viet', 'vietnguyen@gmail.com', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 'SINHVIEN'),
(104, '1', '1', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 'SINHVIEN'),
(106, '2', '1', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 'ADMIN'),
(107, '74DCHT16376', NULL, 'utt@2005', 'SINHVIEN'),
(115, '73DCCT53069', NULL, 'utt@2005', 'SINHVIEN'),
(116, '78DCCT91126', NULL, 'utt@2005', 'SINHVIEN'),
(117, '23DCCD54531', NULL, 'utt@2005', 'SINHVIEN'),
(118, '55DCCD61205', NULL, '$2a$10$pZLDM8SYFQUDaolX/3HKI.tJByKSK4BzvwiTb/jkHifMDDo1f/49C', 'SINHVIEN'),
(120, 'admin', NULL, '$2a$10$CwTycUXWue0Thq9StjUM0uJ8f5Kx8pQq8N3/OuB9A5G0h5Q9M6g2W', 'ADMIN'),
(122, 'admin1', 'hi', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 'ADMIN');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chuongtrinhhoc`
--

CREATE TABLE `chuongtrinhhoc` (
  `MaCT` int(11) NOT NULL,
  `MaNganh` varchar(10) DEFAULT NULL,
  `NamHoc` int(11) DEFAULT NULL,
  `HocKy` varchar(10) DEFAULT NULL,
  `MaMon` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `chuongtrinhhoc`
--

INSERT INTO `chuongtrinhhoc` (`MaCT`, `MaNganh`, `NamHoc`, `HocKy`, `MaMon`) VALUES
(1, 'CNTT', 1, 'HK1', 'CS101'),
(2, 'CNTT', 1, 'HK1', 'OOP201'),
(3, 'CNTT', 1, 'HK2', 'CT175'),
(4, 'CNTT', 2, 'HK1', 'LTW202');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `congno`
--

CREATE TABLE `congno` (
  `MaSV` varchar(20) NOT NULL,
  `MaHocKi` varchar(10) NOT NULL,
  `TongHocPhi` decimal(18,2) DEFAULT NULL,
  `DaThu` decimal(18,2) DEFAULT NULL,
  `ConNo` decimal(18,2) GENERATED ALWAYS AS (`TongHocPhi` - `DaThu`) STORED,
  `HanDong` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `congno`
--

INSERT INTO `congno` (`MaSV`, `MaHocKi`, `TongHocPhi`, `DaThu`, `HanDong`) VALUES
('23CKM001', 'HK1', 10000000.00, 5000000.00, '2025-01-15'),
('23CKM002', 'HK1', 10000000.00, 10000000.00, '2025-01-15'),
('23CNPM001', 'HK1', 12000000.00, 12000000.00, '2025-01-15'),
('23CNPM002', 'HK1', 12000000.00, 8000000.00, '2025-01-15'),
('23CNPM003', 'HK1', 12000000.00, 0.00, '2025-01-15'),
('23CNPM004', 'HK1', 12000000.00, 12000000.00, '2025-01-15'),
('23HTTT001', 'HK1', 11000000.00, 6000000.00, '2025-01-15'),
('23HTTT002', 'HK1', 11000000.00, 11000000.00, '2025-01-15'),
('23QTKD001', 'HK1', 9000000.00, 9000000.00, '2025-01-15'),
('23XDCT001', 'HK1', 9500000.00, 3000000.00, '2025-01-15'),
('73DCCT53069', 'HK1', 12000000.00, 5000000.00, '2025-12-30');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dangkymonhoc`
--

CREATE TABLE `dangkymonhoc` (
  `MaDK` varchar(10) NOT NULL,
  `MaSV` varchar(10) NOT NULL,
  `MaMon` varchar(10) NOT NULL,
  `SoTinChi` int(11) NOT NULL,
  `MaHocKi` varchar(10) NOT NULL,
  `TrangThai` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hocki`
--

CREATE TABLE `hocki` (
  `MaHocKi` varchar(10) NOT NULL,
  `TenHocKi` varchar(50) DEFAULT NULL,
  `NamHoc` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `hocki`
--

INSERT INTO `hocki` (`MaHocKi`, `TenHocKi`, `NamHoc`) VALUES
('HK1', 'Học kỳ 1', '2024-2025'),
('HK2', 'Học kỳ 2', '2024-2025'),
('HK3', 'Học kỳ hè', '2024-2025');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hocphi`
--

CREATE TABLE `hocphi` (
  `MaHP` varchar(20) NOT NULL,
  `MaSV` varchar(20) DEFAULT NULL,
  `HocKy` varchar(10) DEFAULT NULL,
  `TongTinChi` int(11) DEFAULT NULL,
  `TongTien` double DEFAULT NULL,
  `DaDong` double DEFAULT 0,
  `TrangThai` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `hocphi`
--

INSERT INTO `hocphi` (`MaHP`, `MaSV`, `HocKy`, `TongTinChi`, `TongTien`, `DaDong`, `TrangThai`) VALUES
('HP_73DCCT53069_HK1', '73DCCT53069', 'HK1', 15, 5250000, 1520000, 'ĐÃ ĐÓNG');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khoa`
--

CREATE TABLE `khoa` (
  `MaKhoa` varchar(10) NOT NULL,
  `TenKhoa` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `khoa`
--

INSERT INTO `khoa` (`MaKhoa`, `TenKhoa`) VALUES
('CK', 'Cơ khí'),
('CNTT', 'Công nghệ thông tin'),
('DT', 'Điện - Điện tử'),
('GT', 'Giao thông vận tải'),
('KT', 'Kinh tế'),
('XD', 'Xây dựng');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `lop`
--

CREATE TABLE `lop` (
  `MaLop` varchar(10) NOT NULL,
  `TenLop` varchar(100) NOT NULL,
  `MaKhoa` varchar(10) NOT NULL,
  `MaNganh` varchar(10) DEFAULT NULL,
  `SiSo` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `lop`
--

INSERT INTO `lop` (`MaLop`, `TenLop`, `MaKhoa`, `MaNganh`, `SiSo`) VALUES
('23CDT', '23CDT', 'CK', 'CDT', 1),
('23CKM1', '23CKM1', 'CK', NULL, NULL),
('23CKT1', '23CKT1', 'CK', NULL, NULL),
('23CNPM1', '23CNPM1', 'CNTT', NULL, NULL),
('23CNPM2', '23CNPM2', 'CNTT', NULL, NULL),
('23DTCN1', '23DTCN1', 'DT', NULL, NULL),
('23DTDD1', '23DTDD1', 'DT', NULL, NULL),
('23DTVT1', 'DTVT 1', 'DT', 'DTVT', 0),
('23GTCD1', 'GT Cầu đường 1', 'GT', 'GTCD', 0),
('23HTTT1', '23HTTT1', 'CNTT', NULL, NULL),
('23KETO1', '23KETO1', 'KT', NULL, NULL),
('23KHMT1', '23KHMT1', 'CNTT', NULL, NULL),
('23QTKD1', '23QTKD1', 'KT', NULL, NULL),
('23XDCT1', '23XDCT1', 'XD', NULL, NULL),
('73CNTT', '73CNTT', 'CNTT', 'CNTT', 1),
('74HTTT', '74HTTT', 'CNTT', 'HTTT', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `lophocphan`
--

CREATE TABLE `lophocphan` (
  `MaLHP` varchar(20) NOT NULL,
  `MaMon` varchar(10) DEFAULT NULL,
  `MaHocKi` varchar(10) DEFAULT NULL,
  `GiangVien` varchar(100) DEFAULT NULL,
  `SiSoToiDa` int(11) DEFAULT NULL,
  `TrangThai` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `monhoc`
--

CREATE TABLE `monhoc` (
  `MaMon` varchar(10) NOT NULL,
  `TenMon` varchar(100) NOT NULL,
  `SoTinChi` int(11) NOT NULL,
  `DonGia` decimal(18,2) NOT NULL,
  `SoTiet` int(11) GENERATED ALWAYS AS (`SoTinChi` * 15) STORED,
  `TrangThai` varchar(20) DEFAULT NULL,
  `MaNganh` varchar(10) DEFAULT NULL,
  `NamHoc` int(11) DEFAULT NULL,
  `HocKy` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `monhoc`
--

INSERT INTO `monhoc` (`MaMon`, `TenMon`, `SoTinChi`, `DonGia`, `TrangThai`, `MaNganh`, `NamHoc`, `HocKy`) VALUES
('CS101', 'Tin học cơ sở', 3, 350000.00, 'Mở', 'CNTT', 1, 'HK1'),
('CT175', 'Cấu trúc dữ liệu', 3, 350000.00, 'Mở', NULL, NULL, NULL),
('LTW202', 'Lập trình Web', 4, 380000.00, 'Mở', NULL, NULL, NULL),
('MH01', 'Lập trình C', 3, 350000.00, 'Mở', NULL, NULL, NULL),
('MH02', 'Cấu trúc dữ liệu', 3, 350000.00, 'Mở', NULL, NULL, NULL),
('MH03', 'Cơ sở dữ liệu', 3, 350000.00, 'Mở', NULL, NULL, NULL),
('OOP201', 'Lập trình hướng đối tượng', 3, 350000.00, 'Mở', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nganh`
--

CREATE TABLE `nganh` (
  `MaNganh` varchar(10) NOT NULL,
  `TenNganh` varchar(100) NOT NULL,
  `VietTat` varchar(10) NOT NULL,
  `MaKhoa` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `nganh`
--

INSERT INTO `nganh` (`MaNganh`, `TenNganh`, `VietTat`, `MaKhoa`) VALUES
('ATTT', 'An toàn thông tin', 'AT', 'CNTT'),
('CCT', 'Cầu đường', 'CD', 'GT'),
('CDT', 'Cơ điện tử', 'CD', 'CK'),
('CKM', 'Cơ khí máy', 'CK', 'CK'),
('CKT', 'Cơ khí chế tạo', '', 'CK'),
('CNPM', 'Công nghệ phần mềm', '', 'CNTT'),
('CNTT', 'Công nghệ thông tin', 'CT', 'CNTT'),
('DDT', 'Điện – Điện tử', 'DD', 'DT'),
('DTCN', 'Điện công nghiệp', '', 'DT'),
('DTVT', 'Điện viễn thông', '', 'DT'),
('GTCD', 'Cầu đường', '', 'GT'),
('GTDT', 'Giao thông đô thị', '', 'GT'),
('HTTT', 'Hệ thống thông tin', 'HT', 'CNTT'),
('KHMT', 'Khoa học máy tính', '', 'CNTT'),
('KTKT', 'Kế toán', 'KT', 'KT'),
('KTPM', 'Kỹ thuật phần mềm', 'PM', 'CNTT'),
('KTQT', 'Kinh tế quốc tế', '', 'KT'),
('QLXD', 'Quản lý xây dựng', 'QL', 'XD'),
('QTKD', 'Quản trị kinh doanh', 'QT', 'KT'),
('XDCT', 'Xây dựng công trình', '', 'XD');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieudangky`
--

CREATE TABLE `phieudangky` (
  `MaPhieu` varchar(20) NOT NULL,
  `MaHocPhan` varchar(20) NOT NULL,
  `TenHocPhan` varchar(100) NOT NULL,
  `NgayDangKy` date NOT NULL,
  `HocKy` varchar(20) NOT NULL,
  `SoTinChi` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieuthu`
--

CREATE TABLE `phieuthu` (
  `MaPhieuThu` varchar(10) NOT NULL,
  `MaSV` varchar(10) NOT NULL,
  `MaHocKi` varchar(10) NOT NULL,
  `NguoiLap` varchar(50) DEFAULT NULL,
  `NgayLap` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sinhvien`
--

CREATE TABLE `sinhvien` (
  `MaSV` varchar(20) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `HoTen` varchar(100) NOT NULL,
  `NgaySinh` date DEFAULT NULL,
  `GioiTinh` varchar(10) DEFAULT NULL,
  `QueQuan` varchar(100) DEFAULT NULL,
  `MaLop` varchar(10) NOT NULL,
  `MaNganh` varchar(10) DEFAULT NULL,
  `MaKhoa` varchar(10) DEFAULT NULL,
  `Khoa` varchar(5) DEFAULT NULL,
  `TrangThai` varchar(20) DEFAULT NULL,
  `NamNhapHoc` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `sinhvien`
--

INSERT INTO `sinhvien` (`MaSV`, `Username`, `HoTen`, `NgaySinh`, `GioiTinh`, `QueQuan`, `MaLop`, `MaNganh`, `MaKhoa`, `Khoa`, `TrangThai`, `NamNhapHoc`) VALUES
('23CKM001', '23CKM001', 'Nguyễn Đức Long', '2005-09-12', 'Nam', 'Thanh Hóa', '23CKM1', 'CKM', 'CK', '23', 'Đang học', 2024),
('23CKM002', '23CKM002', 'Phan Văn Hùng', '2005-10-01', 'Nam', 'Nghệ An', '23CKM1', 'CKM', 'CK', '23', 'Đang học', 2024),
('23CKT001', '23CKT001', 'Trần Quốc Khánh', '2005-04-08', 'Nam', 'Hà Nội', '23CKT1', 'CKT', 'CK', '23', 'Đang học', 2024),
('23CNPM001', '23CNPM001', 'Nguyễn Văn An', '2005-03-12', 'Nam', 'Hà Nội', '23CNPM1', 'CNPM', 'CNTT', '23', 'Đang học', 2024),
('23CNPM002', '23CNPM002', 'Trần Thị Bích', '2005-05-21', 'Nữ', 'Hải Phòng', '23CNPM1', 'CNPM', 'CNTT', '23', 'Đang học', 2024),
('23CNPM003', '23CNPM003', 'Lê Hoàng Nam', '2005-07-09', 'Nam', 'Nam Định', '23CNPM2', 'CNPM', 'CNTT', '23', 'Đang học', 2024),
('23CNPM004', '23CNPM004', 'Phạm Minh Quân', '2005-11-30', 'Nam', 'Hà Nội', '23CNPM2', 'CNPM', 'CNTT', '23', 'Đang học', 2024),
('23DCCD54531', '23DCCD54531', 'hihi', '2025-12-27', 'Nữ', 'He', '23CDT', 'CDT', 'CK', '23', 'Đang học', 2024),
('23DTCN001', '23DTCN001', 'Ngô Thị Tuyết', '2005-12-19', 'Nữ', 'Hà Tĩnh', '23DTCN1', 'DTCN', 'DT', '23', 'Đang học', 2024),
('23DTVT001', '23DTVT001', 'Võ Thành Đạt', '2005-07-27', 'Nam', 'Đà Nẵng', '23DTVT1', 'DTVT', 'DT', '23', 'Đang học', 2024),
('23GTCD001', '23GTCD001', 'Lý Minh Trí', '2005-05-05', 'Nam', 'Quảng Ninh', '23GTCD1', 'GTCD', 'GT', '23', 'Đang học', 2024),
('23HTTT001', '23HTTT001', 'Đỗ Thị Lan', '2005-02-18', 'Nữ', 'Bắc Ninh', '23HTTT1', 'HTTT', 'CNTT', '23', 'Đang học', 2024),
('23HTTT002', '23HTTT002', 'Nguyễn Quốc Huy', '2005-08-04', 'Nam', 'Hà Nội', '23HTTT1', 'HTTT', 'CNTT', '23', 'Đang học', 2024),
('23KHMT001', '23KHMT001', 'Bùi Anh Tuấn', '2005-06-22', 'Nam', 'Thái Bình', '23KHMT1', 'KHMT', 'CNTT', '23', 'Đang học', 2024),
('23KHMT002', '23KHMT002', 'Nguyễn Thị Hạnh', '2005-01-15', 'Nữ', 'Hà Nam', '23KHMT1', 'KHMT', 'CNTT', '23', 'Đang học', 2024),
('23QTKD001', '23QTKD001', 'Huỳnh Ngọc Mai', '2005-09-09', 'Nữ', 'TP.HCM', '23QTKD1', 'QTKD', 'KT', '23', 'Đang học', 2024),
('23XDCT001', '23XDCT001', 'Nguyễn Hoàng Phúc', '2005-03-03', 'Nam', 'Bình Dương', '23XDCT1', 'XDCT', 'XD', '23', 'Đang học', 2024),
('55DCCD61205', '55DCCD61205', 'test1', '2025-12-27', 'Nữ', 'Ha', '23CDT', 'CDT', 'CK', '55', 'Đang học', 2024),
('73DCCT53069', '73DCCT53069', 'Nguyễn Bá Việt', '2025-12-27', 'Nam', 'Sơn La', '73CNTT', 'CNTT', 'CNTT', '73', 'Đang học', 2024),
('74DCHT16376', '', 'Nguyễn Gia Nam', '2025-12-27', 'Nam', 'HaNoi', '74HTTT', 'HTTT', 'CNTT', '74', 'Đang học', 2024),
('78DCCT91126', '78DCCT91126', 'Lương Gia Bảo', '2025-12-27', 'Nam', 'Hà Nội', '73CNTT', 'CNTT', 'CNTT', '78', 'Đang học', 2024);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `thanhtoan`
--

CREATE TABLE `thanhtoan` (
  `MaThanhToan` varchar(10) NOT NULL,
  `MaPhieuThu` varchar(10) NOT NULL,
  `PhuongThuc` varchar(50) DEFAULT NULL,
  `SoTien` decimal(18,2) DEFAULT NULL,
  `NgayThanhToan` date DEFAULT NULL,
  `NguoiThu` varchar(50) DEFAULT NULL,
  `SoTin` int(11) DEFAULT NULL,
  `TongSoMon` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Chỉ mục cho bảng `chuongtrinhhoc`
--
ALTER TABLE `chuongtrinhhoc`
  ADD PRIMARY KEY (`MaCT`),
  ADD KEY `MaMon` (`MaMon`);

--
-- Chỉ mục cho bảng `congno`
--
ALTER TABLE `congno`
  ADD PRIMARY KEY (`MaSV`,`MaHocKi`),
  ADD KEY `MaHocKi` (`MaHocKi`);

--
-- Chỉ mục cho bảng `dangkymonhoc`
--
ALTER TABLE `dangkymonhoc`
  ADD PRIMARY KEY (`MaDK`),
  ADD KEY `MaMon` (`MaMon`),
  ADD KEY `MaHocKi` (`MaHocKi`),
  ADD KEY `dangkymonhoc_ibfk_1` (`MaSV`);

--
-- Chỉ mục cho bảng `hocki`
--
ALTER TABLE `hocki`
  ADD PRIMARY KEY (`MaHocKi`);

--
-- Chỉ mục cho bảng `hocphi`
--
ALTER TABLE `hocphi`
  ADD PRIMARY KEY (`MaHP`),
  ADD KEY `MaSV` (`MaSV`);

--
-- Chỉ mục cho bảng `khoa`
--
ALTER TABLE `khoa`
  ADD PRIMARY KEY (`MaKhoa`);

--
-- Chỉ mục cho bảng `lop`
--
ALTER TABLE `lop`
  ADD PRIMARY KEY (`MaLop`),
  ADD KEY `MaKhoa` (`MaKhoa`),
  ADD KEY `MaNganh` (`MaNganh`);

--
-- Chỉ mục cho bảng `lophocphan`
--
ALTER TABLE `lophocphan`
  ADD PRIMARY KEY (`MaLHP`),
  ADD KEY `MaMon` (`MaMon`),
  ADD KEY `MaHocKi` (`MaHocKi`);

--
-- Chỉ mục cho bảng `monhoc`
--
ALTER TABLE `monhoc`
  ADD PRIMARY KEY (`MaMon`);

--
-- Chỉ mục cho bảng `nganh`
--
ALTER TABLE `nganh`
  ADD PRIMARY KEY (`MaNganh`),
  ADD KEY `MaKhoa` (`MaKhoa`);

--
-- Chỉ mục cho bảng `phieudangky`
--
ALTER TABLE `phieudangky`
  ADD PRIMARY KEY (`MaPhieu`);

--
-- Chỉ mục cho bảng `phieuthu`
--
ALTER TABLE `phieuthu`
  ADD PRIMARY KEY (`MaPhieuThu`),
  ADD KEY `MaHocKi` (`MaHocKi`),
  ADD KEY `phieuthu_ibfk_1` (`MaSV`);

--
-- Chỉ mục cho bảng `sinhvien`
--
ALTER TABLE `sinhvien`
  ADD PRIMARY KEY (`MaSV`),
  ADD UNIQUE KEY `Username` (`Username`),
  ADD UNIQUE KEY `MaSV` (`MaSV`),
  ADD KEY `MaLop` (`MaLop`),
  ADD KEY `MaNganh` (`MaNganh`);

--
-- Chỉ mục cho bảng `thanhtoan`
--
ALTER TABLE `thanhtoan`
  ADD PRIMARY KEY (`MaThanhToan`),
  ADD KEY `MaPhieuThu` (`MaPhieuThu`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `account`
--
ALTER TABLE `account`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=123;

--
-- AUTO_INCREMENT cho bảng `chuongtrinhhoc`
--
ALTER TABLE `chuongtrinhhoc`
  MODIFY `MaCT` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `chuongtrinhhoc`
--
ALTER TABLE `chuongtrinhhoc`
  ADD CONSTRAINT `chuongtrinhhoc_ibfk_1` FOREIGN KEY (`MaMon`) REFERENCES `monhoc` (`MaMon`);

--
-- Các ràng buộc cho bảng `congno`
--
ALTER TABLE `congno`
  ADD CONSTRAINT `congno_ibfk_1` FOREIGN KEY (`MaSV`) REFERENCES `sinhvien` (`MaSV`),
  ADD CONSTRAINT `congno_ibfk_2` FOREIGN KEY (`MaHocKi`) REFERENCES `hocki` (`MaHocKi`);

--
-- Các ràng buộc cho bảng `dangkymonhoc`
--
ALTER TABLE `dangkymonhoc`
  ADD CONSTRAINT `dangkymonhoc_ibfk_1` FOREIGN KEY (`MaSV`) REFERENCES `sinhvien` (`MaSV`),
  ADD CONSTRAINT `dangkymonhoc_ibfk_2` FOREIGN KEY (`MaMon`) REFERENCES `monhoc` (`MaMon`),
  ADD CONSTRAINT `dangkymonhoc_ibfk_3` FOREIGN KEY (`MaHocKi`) REFERENCES `hocki` (`MaHocKi`);

--
-- Các ràng buộc cho bảng `hocphi`
--
ALTER TABLE `hocphi`
  ADD CONSTRAINT `hocphi_ibfk_1` FOREIGN KEY (`MaSV`) REFERENCES `sinhvien` (`MaSV`);

--
-- Các ràng buộc cho bảng `lop`
--
ALTER TABLE `lop`
  ADD CONSTRAINT `lop_ibfk_1` FOREIGN KEY (`MaKhoa`) REFERENCES `khoa` (`MaKhoa`),
  ADD CONSTRAINT `lop_ibfk_2` FOREIGN KEY (`MaNganh`) REFERENCES `nganh` (`MaNganh`);

--
-- Các ràng buộc cho bảng `lophocphan`
--
ALTER TABLE `lophocphan`
  ADD CONSTRAINT `lophocphan_ibfk_1` FOREIGN KEY (`MaMon`) REFERENCES `monhoc` (`MaMon`),
  ADD CONSTRAINT `lophocphan_ibfk_2` FOREIGN KEY (`MaHocKi`) REFERENCES `hocki` (`MaHocKi`);

--
-- Các ràng buộc cho bảng `nganh`
--
ALTER TABLE `nganh`
  ADD CONSTRAINT `nganh_ibfk_1` FOREIGN KEY (`MaKhoa`) REFERENCES `khoa` (`MaKhoa`);

--
-- Các ràng buộc cho bảng `phieuthu`
--
ALTER TABLE `phieuthu`
  ADD CONSTRAINT `phieuthu_ibfk_1` FOREIGN KEY (`MaSV`) REFERENCES `sinhvien` (`MaSV`),
  ADD CONSTRAINT `phieuthu_ibfk_2` FOREIGN KEY (`MaHocKi`) REFERENCES `hocki` (`MaHocKi`);

--
-- Các ràng buộc cho bảng `sinhvien`
--
ALTER TABLE `sinhvien`
  ADD CONSTRAINT `sinhvien_ibfk_1` FOREIGN KEY (`MaLop`) REFERENCES `lop` (`MaLop`),
  ADD CONSTRAINT `sinhvien_ibfk_2` FOREIGN KEY (`MaNganh`) REFERENCES `nganh` (`MaNganh`);

--
-- Các ràng buộc cho bảng `thanhtoan`
--
ALTER TABLE `thanhtoan`
  ADD CONSTRAINT `thanhtoan_ibfk_1` FOREIGN KEY (`MaPhieuThu`) REFERENCES `phieuthu` (`MaPhieuThu`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
