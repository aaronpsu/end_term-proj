-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 04, 2025 at 06:10 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `police_blotter_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `blotter`
--

CREATE TABLE `blotter` (
  `blotterId` int(100) NOT NULL,
  `BlotDesc` varchar(200) NOT NULL,
  `BlotCrimeDate` date NOT NULL,
  `BlotStatus` varchar(100) NOT NULL,
  `BlotCreateDate` date NOT NULL,
  `BlotByUser` varchar(200) NOT NULL,
  `id` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cases`
--

CREATE TABLE `cases` (
  `CaseNo` int(100) NOT NULL,
  `Title` varchar(200) NOT NULL,
  `Description` text NOT NULL,
  `DateReported` date NOT NULL,
  `DateUpdated` date NOT NULL,
  `CreatedByUser` varchar(100) NOT NULL,
  `id` int(100) NOT NULL,
  `judgeId` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `case_details`
--

CREATE TABLE `case_details` (
  `TransNo` int(100) NOT NULL,
  `Status` varchar(200) NOT NULL,
  `Remarks` varchar(200) NOT NULL,
  `CrimeId` int(100) NOT NULL,
  `ViolationId` int(100) NOT NULL,
  `CaseNo` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `crimetype`
--

CREATE TABLE `crimetype` (
  `crimeId` int(100) NOT NULL,
  `crimeName` varchar(200) NOT NULL,
  `crimDesc` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `judge`
--

CREATE TABLE `judge` (
  `JudgeID` int(100) NOT NULL,
  `JudgeName` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(100) NOT NULL,
  `name` varchar(200) NOT NULL,
  `email` varchar(200) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` enum('administrator','officer') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `username`, `password`, `role`) VALUES
(1, 'aaron222aasad', 'email@gmail.com2222', 'romero222asdasdasd', 'RhIi9d1pCiBlHD0ZhIAVywNp2z+Ok3Vx/7d13nB1CEc=', 'administrator'),
(2, 'lol', 'aaron@gmail.com', 'aaron', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', 'officer'),
(3, 'aa', 'aa@gmail.com', 'a', 'lhtt0+3jy47LqsvWjeBAzXjrLtWIkTDM60xJJo6k1QY=', 'administrator');

-- --------------------------------------------------------

--
-- Table structure for table `violationtype`
--

CREATE TABLE `violationtype` (
  `ViolationId` int(100) NOT NULL,
  `ViolationTitle` varchar(200) NOT NULL,
  `ViolationDesc` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `blotter`
--
ALTER TABLE `blotter`
  ADD PRIMARY KEY (`blotterId`),
  ADD KEY `fk_userid` (`id`);

--
-- Indexes for table `cases`
--
ALTER TABLE `cases`
  ADD PRIMARY KEY (`CaseNo`),
  ADD KEY `fk_userids` (`id`),
  ADD KEY `fk_judgeid` (`judgeId`);

--
-- Indexes for table `case_details`
--
ALTER TABLE `case_details`
  ADD PRIMARY KEY (`TransNo`),
  ADD KEY `fk_crimeId` (`CrimeId`),
  ADD KEY `fk_violationId` (`ViolationId`),
  ADD KEY `fk_caseno` (`CaseNo`);

--
-- Indexes for table `crimetype`
--
ALTER TABLE `crimetype`
  ADD PRIMARY KEY (`crimeId`);

--
-- Indexes for table `judge`
--
ALTER TABLE `judge`
  ADD PRIMARY KEY (`JudgeID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `violationtype`
--
ALTER TABLE `violationtype`
  ADD PRIMARY KEY (`ViolationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `blotter`
--
ALTER TABLE `blotter`
  MODIFY `blotterId` int(100) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cases`
--
ALTER TABLE `cases`
  MODIFY `CaseNo` int(100) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `case_details`
--
ALTER TABLE `case_details`
  MODIFY `TransNo` int(100) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `crimetype`
--
ALTER TABLE `crimetype`
  MODIFY `crimeId` int(100) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `judge`
--
ALTER TABLE `judge`
  MODIFY `JudgeID` int(100) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `violationtype`
--
ALTER TABLE `violationtype`
  MODIFY `ViolationId` int(100) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `blotter`
--
ALTER TABLE `blotter`
  ADD CONSTRAINT `fk_userid` FOREIGN KEY (`id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `cases`
--
ALTER TABLE `cases`
  ADD CONSTRAINT `fk_judgeid` FOREIGN KEY (`judgeId`) REFERENCES `judge` (`JudgeID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_userids` FOREIGN KEY (`id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `case_details`
--
ALTER TABLE `case_details`
  ADD CONSTRAINT `fk_caseno` FOREIGN KEY (`CaseNo`) REFERENCES `cases` (`CaseNo`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_crimeId` FOREIGN KEY (`CrimeId`) REFERENCES `crimetype` (`crimeId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_violationId` FOREIGN KEY (`ViolationId`) REFERENCES `violationtype` (`ViolationId`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
