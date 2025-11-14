-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Nov 14, 2025 at 01:39 PM
-- Server version: 8.0.30
-- PHP Version: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cookies_and_coffee`
--

-- --------------------------------------------------------

--
-- Table structure for table `cookies`
--

CREATE TABLE `cookies` (
  `id` int NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `type` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `image_path` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `cookies`
--

INSERT INTO `cookies` (`id`, `name`, `type`, `description`, `image_path`, `created_at`, `updated_at`) VALUES
(1, 'Chocolate Chip', 'Sweet', 'Classic sweet cookie with chocolate chips', 'choco chip cookies.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(2, 'Oatmeal Cookie', 'Neutral', 'Healthy oats with subtle sweetness', 'Oatmeal Raisin.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(3, 'Sugar Cookie', 'Sweet', 'Simple sweet vanilla cookie', 'Sugar Cookie.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(4, 'Peanut Butter', 'Sweet', 'Rich peanut butter cookie', 'Peanut Butter Cookie.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(5, 'White Chocolate', 'Sweet', 'Sweet white chocolate cookie', 'White Choco Macadamia.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(6, 'Lemon Cookie', 'Sour', 'Tangy lemon flavored cookie', 'Lemon Crinkle Cookie.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(7, 'Almond Biscotti', 'Neutral', 'Crispy Italian almond cookie', 'Almond Biscotti.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(8, 'Snickerdoodle', 'Sweet', 'Cinnamon sugar cookie', 'Snickerdoodle.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44');

-- --------------------------------------------------------

--
-- Table structure for table `drinks`
--

CREATE TABLE `drinks` (
  `id` int NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `type` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `image_path` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `drinks`
--

INSERT INTO `drinks` (`id`, `name`, `type`, `description`, `image_path`, `created_at`, `updated_at`) VALUES
(1, 'Cappuccino', 'Sweet', 'Creamy coffee with steamed milk', 'perfect_pair\\cappucino.png', '2025-11-13 15:09:44', '2025-11-13 15:14:15'),
(2, 'Hot Chocolate', 'Sweet', 'Rich chocolate drink', 'hot chocolate.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(3, 'Vanilla Latte', 'Sweet', 'Sweet coffee with vanilla', 'vanila latte.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(4, 'Iced Americano', 'Bitter', 'Strong black coffee on ice', 'iced americano.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(5, 'Caramel Macchiato', 'Sweet', 'Sweet coffee with caramel', 'caramel macchiato.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(6, 'Matcha Latte', 'Neutral', 'Green tea with milk', 'matcha latte.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(7, 'Lemon Tea', 'Sour', 'Refreshing citrus tea', 'teh lemon hangat.png', '2025-11-13 15:09:44', '2025-11-13 15:09:44');

-- --------------------------------------------------------

--
-- Table structure for table `drink_cookie_pairing`
--

CREATE TABLE `drink_cookie_pairing` (
  `id` int NOT NULL,
  `drink_id` int NOT NULL,
  `cookie_id` int NOT NULL,
  `match_score` int NOT NULL,
  `pairing_reason` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ;

--
-- Dumping data for table `drink_cookie_pairing`
--

INSERT INTO `drink_cookie_pairing` (`id`, `drink_id`, `cookie_id`, `match_score`, `pairing_reason`, `created_at`, `updated_at`) VALUES
(1, 1, 1, 95, 'Rich chocolate complements coffee perfectly', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(2, 1, 3, 90, 'Classic sweet combination with coffee', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(3, 1, 8, 85, 'Buttery chocolate balance', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(4, 1, 7, 75, 'Traditional Italian coffee pairing', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(5, 2, 1, 100, 'Double chocolate indulgence', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(6, 2, 5, 85, 'White chocolate contrast', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(7, 2, 4, 80, 'Creamy peanut butter richness', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(8, 3, 3, 95, 'Vanilla harmony', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(9, 3, 5, 90, 'White chocolate elegance', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(10, 3, 8, 85, 'Sophisticated sweet combination', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(11, 3, 2, 70, 'Balanced sweet and neutral', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(12, 4, 1, 90, 'Sweet balances bitter perfectly', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(13, 4, 4, 85, 'Rich peanut butter cuts bitterness', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(14, 4, 7, 95, 'Traditional Italian coffee biscuit', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(15, 4, 2, 75, 'Neutral oats complement strong coffee', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(16, 5, 8, 100, 'Caramel and chocolate perfection', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(17, 5, 1, 90, 'Double sweetness delight', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(18, 5, 4, 85, 'Caramel-peanut butter fusion', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(19, 6, 5, 95, 'White chocolate balances earthy matcha', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(20, 6, 2, 90, 'Oats complement matcha earthiness', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(21, 6, 3, 80, 'Simple sweetness with green tea', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(22, 6, 7, 75, 'Almond nuttiness pairs well', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(23, 7, 6, 100, 'Perfect citrus harmony', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(24, 7, 3, 85, 'Sweet balances tartness', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(25, 7, 2, 80, 'Neutral oats with citrus', '2025-11-13 15:09:44', '2025-11-13 15:09:44'),
(26, 7, 7, 70, 'Almond complements lemon', '2025-11-13 15:09:44', '2025-11-13 15:09:44');

-- --------------------------------------------------------

--
-- Stand-in structure for view `v_pairing_details`
-- (See below for the actual view)
--
CREATE TABLE `v_pairing_details` (
`cookie_id` int
,`cookie_name` varchar(100)
,`cookie_type` varchar(50)
,`drink_id` int
,`drink_name` varchar(100)
,`drink_type` varchar(50)
,`id` int
,`match_category` varchar(9)
,`match_score` int
,`pairing_reason` text
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `v_pairing_stats`
-- (See below for the actual view)
--
CREATE TABLE `v_pairing_stats` (
`avg_score` decimal(14,4)
,`best_score` int
,`drink_name` varchar(100)
,`lowest_score` int
,`total_pairings` bigint
);

-- --------------------------------------------------------

--
-- Structure for view `v_pairing_details`
--
DROP TABLE IF EXISTS `v_pairing_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_pairing_details`  AS SELECT `p`.`id` AS `id`, `p`.`drink_id` AS `drink_id`, `d`.`name` AS `drink_name`, `d`.`type` AS `drink_type`, `p`.`cookie_id` AS `cookie_id`, `c`.`name` AS `cookie_name`, `c`.`type` AS `cookie_type`, `p`.`match_score` AS `match_score`, `p`.`pairing_reason` AS `pairing_reason`, (case when (`p`.`match_score` >= 90) then 'Perfect' when (`p`.`match_score` >= 75) then 'Very Good' when (`p`.`match_score` >= 60) then 'Good' when (`p`.`match_score` >= 50) then 'Fair' else 'Poor' end) AS `match_category` FROM ((`drink_cookie_pairing` `p` join `drinks` `d` on((`p`.`drink_id` = `d`.`id`))) join `cookies` `c` on((`p`.`cookie_id` = `c`.`id`))) ORDER BY `p`.`drink_id` ASC, `p`.`match_score` DESC ;

-- --------------------------------------------------------

--
-- Structure for view `v_pairing_stats`
--
DROP TABLE IF EXISTS `v_pairing_stats`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_pairing_stats`  AS SELECT `d`.`name` AS `drink_name`, count(`p`.`id`) AS `total_pairings`, max(`p`.`match_score`) AS `best_score`, avg(`p`.`match_score`) AS `avg_score`, min(`p`.`match_score`) AS `lowest_score` FROM (`drinks` `d` left join `drink_cookie_pairing` `p` on((`d`.`id` = `p`.`drink_id`))) GROUP BY `d`.`id`, `d`.`name` ORDER BY `avg_score` DESC ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cookies`
--
ALTER TABLE `cookies`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_type` (`type`),
  ADD KEY `idx_cookies_type` (`type`);

--
-- Indexes for table `drinks`
--
ALTER TABLE `drinks`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_type` (`type`),
  ADD KEY `idx_drinks_type` (`type`);

--
-- Indexes for table `drink_cookie_pairing`
--
ALTER TABLE `drink_cookie_pairing`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_drink_id` (`drink_id`),
  ADD KEY `idx_cookie_id` (`cookie_id`),
  ADD KEY `idx_match_score` (`match_score`),
  ADD KEY `idx_pairing_composite` (`drink_id`,`match_score` DESC);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cookies`
--
ALTER TABLE `cookies`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `drinks`
--
ALTER TABLE `drinks`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `drink_cookie_pairing`
--
ALTER TABLE `drink_cookie_pairing`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `drink_cookie_pairing`
--
ALTER TABLE `drink_cookie_pairing`
  ADD CONSTRAINT `fk_pairing_cookie` FOREIGN KEY (`cookie_id`) REFERENCES `cookies` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_pairing_drink` FOREIGN KEY (`drink_id`) REFERENCES `drinks` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
