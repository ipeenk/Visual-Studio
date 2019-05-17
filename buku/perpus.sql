-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 16 Jan 2019 pada 18.59
-- Versi server: 10.1.37-MariaDB
-- Versi PHP: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `perpus`
--
CREATE DATABASE IF NOT EXISTS `perpus` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `perpus`;

-- --------------------------------------------------------

--
-- Struktur dari tabel `buku`
--

CREATE TABLE `buku` (
  `tgl` date NOT NULL,
  `nama_buku` varchar(15) NOT NULL,
  `nama_penulis` varchar(15) NOT NULL,
  `nama_penerbit` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `buku`
--

INSERT INTO `buku` (`tgl`, `nama_buku`, `nama_penulis`, `nama_penerbit`) VALUES
('0000-00-00', 'svav', 'asv', 'savas'),
('1986-06-10', 'bjbjk', 'nklnkln', 'klnklnkl'),
('2018-10-10', 'rhweh', 'wgw', 'asvas'),
('2018-10-16', 'hehw', 'whwr', 'whwer'),
('2018-10-23', 'ipeenk', 'svnaks', 'nkanva'),
('2018-11-13', 'vasasv', 'asvasv', 'asvas'),
('2018-11-15', 'Ipeenk', 'test', 'test'),
('2018-11-27', 'vasasv', 'asvasv', 'asvas'),
('2018-11-28', 'ewgew', 'wgw', 'asvas'),
('2018-12-10', 'savasv', 'asv', 'vasv'),
('2018-12-11', 'wgg', 'gq', 'geq');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `buku`
--
ALTER TABLE `buku`
  ADD PRIMARY KEY (`tgl`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
