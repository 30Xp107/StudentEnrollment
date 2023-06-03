-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 25, 2023 at 07:12 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `uaenrollment`
--

-- --------------------------------------------------------

--
-- Table structure for table `addfees`
--

CREATE TABLE `addfees` (
  `Id` int(11) NOT NULL,
  `Fees` varchar(99) NOT NULL,
  `Amount` int(11) NOT NULL,
  `Payment` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `addfees`
--

INSERT INTO `addfees` (`Id`, `Fees`, `Amount`, `Payment`) VALUES
(4, 'Tuition Fee', 1000, ''),
(5, 'Registration Fee', 100, ''),
(6, 'Laboratory Fee', 150, ''),
(7, 'Library Fee', 200, ''),
(8, 'Medical/Dental Fee', 100, '');

-- --------------------------------------------------------

--
-- Table structure for table `addsubjects`
--

CREATE TABLE `addsubjects` (
  `Id` int(11) NOT NULL,
  `Subjects` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `addsubjects`
--

INSERT INTO `addsubjects` (`Id`, `Subjects`) VALUES
(1, 'Filipino'),
(3, 'English'),
(4, 'Mathematics'),
(5, 'Science'),
(6, 'Araling Panlipunan (AP)'),
(7, 'Edukasyon sa Pagpapakatao (Esp)'),
(8, 'Technology and Livelihood Education (TLE)'),
(9, 'Mapeh'),
(10, 'Music'),
(11, 'Arts'),
(12, 'Physical Education'),
(13, 'Health');

-- --------------------------------------------------------

--
-- Table structure for table `addviolation`
--

CREATE TABLE `addviolation` (
  `Id` int(11) NOT NULL,
  `Violation` varchar(999) NOT NULL,
  `Description` varchar(999) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `adminaccount`
--

CREATE TABLE `adminaccount` (
  `ID` int(11) NOT NULL,
  `AccountID` varchar(99) NOT NULL,
  `AccountName` varchar(99) NOT NULL,
  `Username` varchar(99) NOT NULL,
  `Password` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `adminaccount`
--

INSERT INTO `adminaccount` (`ID`, `AccountID`, `AccountName`, `Username`, `Password`) VALUES
(2, '2023-05AB-25T', 'John Doe', 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `enrollment`
--

CREATE TABLE `enrollment` (
  `Id` int(11) NOT NULL,
  `RFNo` int(11) NOT NULL,
  `SchoolYear` varchar(999) NOT NULL,
  `CurrYear` int(11) NOT NULL,
  `StudentID` varchar(99) NOT NULL,
  `StudentName` varchar(999) NOT NULL,
  `StudentAge` int(11) NOT NULL,
  `StudentDB` date NOT NULL,
  `PlaceofBirth` varchar(999) NOT NULL,
  `Citizenship` varchar(999) NOT NULL,
  `StudentAddress` varchar(999) NOT NULL,
  `StudentReligion` varchar(999) NOT NULL,
  `FName` varchar(999) NOT NULL,
  `FOccu` varchar(999) NOT NULL,
  `MName` varchar(999) NOT NULL,
  `MOccu` varchar(999) NOT NULL,
  `NameGuardian` varchar(999) NOT NULL,
  `RelationStudent` varchar(999) NOT NULL,
  `Address` varchar(999) NOT NULL,
  `SchoolLast` varchar(999) NOT NULL,
  `SchoolAdd` varchar(999) NOT NULL,
  `EnrolledDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `Id` int(11) NOT NULL,
  `Username` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `studentaccount`
--

CREATE TABLE `studentaccount` (
  `ID` int(11) NOT NULL,
  `StudentID` varchar(99) NOT NULL,
  `StudentName` varchar(99) NOT NULL,
  `Address` varchar(99) NOT NULL,
  `DateEnrolled` date NOT NULL,
  `Username` varchar(99) NOT NULL,
  `Password` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `studentaccount`
--

INSERT INTO `studentaccount` (`ID`, `StudentID`, `StudentName`, `Address`, `DateEnrolled`, `Username`, `Password`) VALUES
(1, '1295-73pr-3', 'John Weak', 'Philippines', '2023-05-24', 'sample', 'sample');

-- --------------------------------------------------------

--
-- Table structure for table `studentenrollment`
--

CREATE TABLE `studentenrollment` (
  `ID` int(11) NOT NULL,
  `Status` varchar(99) NOT NULL,
  `RFNumber` varchar(99) NOT NULL,
  `DateEnrolled` date NOT NULL,
  `SchoolYear` varchar(99) NOT NULL,
  `CurriculumYear` varchar(99) NOT NULL,
  `StudentID` varchar(99) NOT NULL,
  `StudentName` varchar(99) NOT NULL,
  `Gender` varchar(99) NOT NULL,
  `Age` int(11) NOT NULL,
  `DateofBirth` date NOT NULL,
  `PlaceofBirth` varchar(99) NOT NULL,
  `Citizenship` varchar(99) NOT NULL,
  `StudentAddress` varchar(99) NOT NULL,
  `Religion` varchar(99) NOT NULL,
  `FathersName` varchar(99) NOT NULL,
  `FathersOccupation` varchar(99) NOT NULL,
  `MothersName` varchar(99) NOT NULL,
  `MothersOccupation` varchar(99) NOT NULL,
  `GuardianName` varchar(99) NOT NULL,
  `Address` varchar(99) NOT NULL,
  `StudentRelation` varchar(99) NOT NULL,
  `ContactNumber` varchar(99) NOT NULL,
  `SchoolLastAttended` varchar(99) NOT NULL,
  `SchoolLastAttendedAddress` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `studentenrollment`
--

INSERT INTO `studentenrollment` (`ID`, `Status`, `RFNumber`, `DateEnrolled`, `SchoolYear`, `CurriculumYear`, `StudentID`, `StudentName`, `Gender`, `Age`, `DateofBirth`, `PlaceofBirth`, `Citizenship`, `StudentAddress`, `Religion`, `FathersName`, `FathersOccupation`, `MothersName`, `MothersOccupation`, `GuardianName`, `Address`, `StudentRelation`, `ContactNumber`, `SchoolLastAttended`, `SchoolLastAttendedAddress`) VALUES
(2, 'Old Student', '23532423adasd', '2023-05-01', '2432', 'rfasd', '85-RG-332-F454', 'sample', 'Female', 3, '2020-01-28', 'sgdfa', 'asdfas', 'San Jose, Antique', 'sdas', 'asd', 'asd', 'asd', 'assd', 'asd', 'asd', 'ssd', '+636543456787', 'asd', 'asd'),
(3, 'New Student', 'Sample', '2023-05-24', '12312', '324123', '54-rt23-456b', 'Sample', 'Male', 23, '2000-02-02', 'Sample', 'Sample', 'Sample', 'Sample', 'Sample', 'Sample', 'Sample', 'Sample', 'Sample', 'Sample', 'Sample', '+639966845321', 'Sample', 'Sample'),
(4, 'New Student', '2023-01-qw', '2023-05-24', '2023', '2023', '1295-73pr-3', 'John Weak', 'Male', 24, '1999-06-08', 'Philippines', 'Filipino', 'Philippines', 'Catholic', 'Kenny Rogers', 'Signer', 'Selena Gomez', 'Singer', 'Selena Gomez', 'USA', 'Son', '+639381217781', 'Harvard', 'UK');

-- --------------------------------------------------------

--
-- Table structure for table `studentfees`
--

CREATE TABLE `studentfees` (
  `Id` int(11) NOT NULL,
  `StudentID` varchar(99) NOT NULL,
  `StudentName` varchar(99) NOT NULL,
  `RFNumber` varchar(99) NOT NULL,
  `DateEnrolled` date NOT NULL,
  `Fees` varchar(99) NOT NULL,
  `Amount` varchar(99) NOT NULL,
  `Payment` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `studentfees`
--

INSERT INTO `studentfees` (`Id`, `StudentID`, `StudentName`, `RFNumber`, `DateEnrolled`, `Fees`, `Amount`, `Payment`) VALUES
(3, '1295-73pr-3', 'John Weak', '2023-01-qw', '2023-05-24', 'Registration Fee', '100', ''),
(4, '1295-73pr-3', 'John Weak', '2023-01-qw', '2023-05-24', 'Laboratory Fee', '150', ''),
(5, '1295-73pr-3', 'John Weak', '2023-01-qw', '2023-05-24', 'Library Fee', '200', ''),
(6, '1295-73pr-3', 'John Weak', '2023-01-qw', '2023-05-24', 'Tuition Fee', '1000', ''),
(7, '1295-73pr-3', 'John Weak', '2023-01-qw', '2023-05-24', 'Medical/Dental Fee', '100', ''),
(8, '54-rt23-456b', 'Sample', 'Sample', '2023-05-24', 'Registration Fee', '100', ''),
(9, '54-rt23-456b', 'Sample', 'Sample', '2023-05-24', 'Laboratory Fee', '150', '');

-- --------------------------------------------------------

--
-- Table structure for table `studentgrade`
--

CREATE TABLE `studentgrade` (
  `Id` int(11) NOT NULL,
  `StudentID` varchar(99) NOT NULL,
  `StudentName` varchar(99) NOT NULL,
  `ClassifiedGrade` varchar(99) NOT NULL,
  `Subject` varchar(99) NOT NULL,
  `SchoolYear` varchar(99) NOT NULL,
  `Adviser/Teacher` varchar(99) NOT NULL,
  `FinalGrade` varchar(99) NOT NULL,
  `Remarks` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `studentgrade`
--

INSERT INTO `studentgrade` (`Id`, `StudentID`, `StudentName`, `ClassifiedGrade`, `Subject`, `SchoolYear`, `Adviser/Teacher`, `FinalGrade`, `Remarks`) VALUES
(1, '1295-73pr-3', 'John Weak', 'VI', 'Science', '2022-2023', 'elesa', '80', 'Passed');

-- --------------------------------------------------------

--
-- Table structure for table `studentviolation`
--

CREATE TABLE `studentviolation` (
  `Id` int(11) NOT NULL,
  `StudentID` varchar(99) NOT NULL,
  `StudentName` varchar(999) NOT NULL,
  `Address` varchar(999) NOT NULL,
  `Violation` varchar(999) NOT NULL,
  `Description` varchar(999) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `student_account`
--

CREATE TABLE `student_account` (
  `Id` int(11) NOT NULL,
  `UserName` varchar(99) NOT NULL,
  `Password` varchar(99) NOT NULL,
  `StudentID` int(11) NOT NULL,
  `StudentName` varchar(999) NOT NULL,
  `Address` varchar(999) NOT NULL,
  `DateEnrolled` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `student_fees`
--

CREATE TABLE `student_fees` (
  `Id` int(11) NOT NULL,
  `StudentName` varchar(999) NOT NULL,
  `RFNumber` int(11) NOT NULL,
  `DateEnrolled` date NOT NULL,
  `Fees` varchar(999) NOT NULL,
  `Amount` decimal(10,0) NOT NULL,
  `Payment` varchar(999) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `violation`
--

CREATE TABLE `violation` (
  `Id` int(11) NOT NULL,
  `StudentId` int(11) NOT NULL,
  `StudentName` varchar(999) NOT NULL,
  `Address` varchar(999) NOT NULL,
  `Violation` varchar(999) NOT NULL,
  `Description` varchar(999) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `addfees`
--
ALTER TABLE `addfees`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `addsubjects`
--
ALTER TABLE `addsubjects`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `addviolation`
--
ALTER TABLE `addviolation`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `adminaccount`
--
ALTER TABLE `adminaccount`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `enrollment`
--
ALTER TABLE `enrollment`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `studentaccount`
--
ALTER TABLE `studentaccount`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `studentenrollment`
--
ALTER TABLE `studentenrollment`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `studentfees`
--
ALTER TABLE `studentfees`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `studentgrade`
--
ALTER TABLE `studentgrade`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `studentviolation`
--
ALTER TABLE `studentviolation`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `student_account`
--
ALTER TABLE `student_account`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `student_fees`
--
ALTER TABLE `student_fees`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `violation`
--
ALTER TABLE `violation`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `addfees`
--
ALTER TABLE `addfees`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `addsubjects`
--
ALTER TABLE `addsubjects`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `addviolation`
--
ALTER TABLE `addviolation`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `adminaccount`
--
ALTER TABLE `adminaccount`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `enrollment`
--
ALTER TABLE `enrollment`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=130;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `studentaccount`
--
ALTER TABLE `studentaccount`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `studentenrollment`
--
ALTER TABLE `studentenrollment`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `studentfees`
--
ALTER TABLE `studentfees`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `studentgrade`
--
ALTER TABLE `studentgrade`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `studentviolation`
--
ALTER TABLE `studentviolation`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `student_account`
--
ALTER TABLE `student_account`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `student_fees`
--
ALTER TABLE `student_fees`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `violation`
--
ALTER TABLE `violation`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
