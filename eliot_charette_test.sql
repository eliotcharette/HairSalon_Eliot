-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 21, 2018 at 12:12 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eliot_charette_test`
--
CREATE DATABASE IF NOT EXISTS `eliot_charette_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `eliot_charette_test`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `client` varchar(255) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `client`, `stylist_id`) VALUES
(52, 'Oprah', 2),
(53, 'Jill', 2),
(56, 'Jackie', 5),
(57, 'Jimmy', 2),
(58, 'John', 2),
(59, 'John', 2),
(60, 'Lil Wayne', 5);

-- --------------------------------------------------------

--
-- Table structure for table `clients_stylists`
--

CREATE TABLE `clients_stylists` (
  `id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients_stylists`
--

INSERT INTO `clients_stylists` (`id`, `client_id`, `stylist_id`) VALUES
(1, 56, 2),
(2, 57, 4),
(3, 52, 2);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `specialty`) VALUES
(1, 'Perm'),
(2, 'Afro'),
(3, 'Corn Rows'),
(4, 'Curls'),
(5, 'Ombre'),
(6, 'Mow the lawn');

-- --------------------------------------------------------

--
-- Table structure for table `specialties_stylists`
--

CREATE TABLE `specialties_stylists` (
  `id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties_stylists`
--

INSERT INTO `specialties_stylists` (`id`, `specialty_id`, `stylist_id`) VALUES
(1, 2, 2),
(2, 5, 1),
(3, 6, 1),
(4, 4, 1),
(5, 5, 1),
(6, 2, 5),
(7, 7, 2),
(8, 2, 2),
(9, 2, 2),
(10, 4, 2),
(11, 2, 2),
(12, 7, 2),
(13, 2, 2),
(14, 8, 2),
(15, 6, 3),
(16, 6, 4),
(17, 4, 4),
(18, 11, 4),
(19, 4, 4),
(20, 2, 4),
(21, 2, 4),
(22, 5, 4),
(23, 11, 4),
(24, 2, 2),
(25, 1, 4),
(26, 5, 3),
(27, 7, 3),
(28, 6, 3),
(29, 2, 3),
(30, 2, 3),
(31, 2, 3),
(32, 2, 3),
(33, 2, 3),
(34, 2, 3),
(35, 2, 3),
(36, 2, 3),
(37, 2, 3),
(38, 2, 3),
(39, 5, 4),
(40, 4, 8),
(41, 1, 8),
(42, 1, 8),
(43, 1, 8),
(44, 1, 8),
(45, 1, 8),
(46, 4, 5),
(47, 7, 5),
(48, 2, 5),
(49, 2, 5),
(50, 3, 2),
(51, 5, 2),
(52, 5, 15),
(53, 3, 15),
(54, 8, 4),
(55, 6, 5),
(56, 22, 6);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `stylist` varchar(255) NOT NULL,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;
--
-- AUTO_INCREMENT for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;
--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
