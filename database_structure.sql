-- ================================================
-- DATABASE: cookies_and_coffee
-- DESCRIPTION: Database untuk aplikasi PerfectPair
-- DATE: 13 November 2025
-- ================================================

-- Buat database
CREATE DATABASE IF NOT EXISTS `cookies_and_coffee` 
CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE `cookies_and_coffee`;

-- ================================================
-- TABLE: drinks
-- DESCRIPTION: Master data minuman
-- ================================================
DROP TABLE IF EXISTS `drinks`;
CREATE TABLE `drinks` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `type` varchar(50) NOT NULL,
  `description` text NOT NULL,
  `image_path` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_type` (`type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Insert data drinks
INSERT INTO `drinks` (`id`, `name`, `type`, `description`, `image_path`) VALUES
(1, 'Cappuccino', 'Sweet', 'Creamy coffee with steamed milk', 'cappucino.png'),
(2, 'Hot Chocolate', 'Sweet', 'Rich chocolate drink', 'hot chocolate.png'),
(3, 'Vanilla Latte', 'Sweet', 'Sweet coffee with vanilla', 'vanila latte.png'),
(4, 'Iced Americano', 'Bitter', 'Strong black coffee on ice', 'iced americano.png'),
(5, 'Caramel Macchiato', 'Sweet', 'Sweet coffee with caramel', 'caramel macchiato.png'),
(6, 'Matcha Latte', 'Neutral', 'Green tea with milk', 'matcha latte.png'),
(7, 'Lemon Tea', 'Sour', 'Refreshing citrus tea', 'teh lemon hangat.png'),
(8, 'Black Tea', 'Neutral', 'Classic black tea', 'iced black tea.png');

-- ================================================
-- TABLE: cookies
-- DESCRIPTION: Master data cookies
-- ================================================
DROP TABLE IF EXISTS `cookies`;
CREATE TABLE `cookies` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `type` varchar(50) NOT NULL,
  `description` text NOT NULL,
  `image_path` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_type` (`type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Insert data cookies
INSERT INTO `cookies` (`id`, `name`, `type`, `description`, `image_path`) VALUES
(1, 'Chocolate Chip', 'Sweet', 'Classic sweet cookie with chocolate chips', 'choco chip cookies.png'),
(2, 'Oatmeal Cookie', 'Neutral', 'Healthy oats with subtle sweetness', 'Oatmeal Raisin.png'),
(3, 'Sugar Cookie', 'Sweet', 'Simple sweet vanilla cookie', 'Sugar Cookie.png'),
(4, 'Peanut Butter', 'Sweet', 'Rich peanut butter cookie', 'Peanut Butter Cookie.png'),
(5, 'White Chocolate', 'Sweet', 'Sweet white chocolate cookie', 'White Choco Macadamia.png'),
(6, 'Lemon Cookie', 'Sour', 'Tangy lemon flavored cookie', 'Lemon Crinkle Cookie.png'),
(7, 'Almond Biscotti', 'Neutral', 'Crispy Italian almond cookie', 'Almond Biscotti.png'),
(8, 'Snickerdoodle', 'Sweet', 'Cinnamon sugar cookie', 'Snickerdoodle.png');

-- ================================================
-- TABLE: drink_cookie_pairing
-- DESCRIPTION: Tabel pairing minuman dengan cookies
-- ================================================
DROP TABLE IF EXISTS `drink_cookie_pairing`;
CREATE TABLE `drink_cookie_pairing` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `drink_id` int(11) NOT NULL,
  `cookie_id` int(11) NOT NULL,
  `match_score` int(11) NOT NULL CHECK (`match_score` >= 1 AND `match_score` <= 100),
  `pairing_reason` text NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_drink_id` (`drink_id`),
  KEY `idx_cookie_id` (`cookie_id`),
  KEY `idx_match_score` (`match_score`),
  CONSTRAINT `fk_pairing_drink` FOREIGN KEY (`drink_id`) REFERENCES `drinks` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_pairing_cookie` FOREIGN KEY (`cookie_id`) REFERENCES `cookies` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Insert data pairing (31 kombinasi sophisticated)
INSERT INTO `drink_cookie_pairing` (`id`, `drink_id`, `cookie_id`, `match_score`, `pairing_reason`) VALUES
-- Cappuccino (ID=1) - 4 pairings
(1, 1, 1, 95, 'Rich chocolate complements coffee perfectly'),
(2, 1, 3, 90, 'Classic sweet combination with coffee'),
(3, 1, 8, 85, 'Buttery chocolate balance'),
(4, 1, 7, 75, 'Traditional Italian coffee pairing'),

-- Hot Chocolate (ID=2) - 3 pairings
(5, 2, 1, 100, 'Double chocolate indulgence'),
(6, 2, 5, 85, 'White chocolate contrast'),
(7, 2, 4, 80, 'Creamy peanut butter richness'),

-- Vanilla Latte (ID=3) - 4 pairings
(8, 3, 3, 95, 'Vanilla harmony'),
(9, 3, 5, 90, 'White chocolate elegance'),
(10, 3, 8, 85, 'Sophisticated sweet combination'),
(11, 3, 2, 70, 'Balanced sweet and neutral'),

-- Iced Americano (ID=4) - 4 pairings
(12, 4, 1, 90, 'Sweet balances bitter perfectly'),
(13, 4, 4, 85, 'Rich peanut butter cuts bitterness'),
(14, 4, 7, 95, 'Traditional Italian coffee biscuit'),
(15, 4, 2, 75, 'Neutral oats complement strong coffee'),

-- Caramel Macchiato (ID=5) - 3 pairings
(16, 5, 8, 100, 'Caramel and chocolate perfection'),
(17, 5, 1, 90, 'Double sweetness delight'),
(18, 5, 4, 85, 'Caramel-peanut butter fusion'),

-- Matcha Latte (ID=6) - 4 pairings
(19, 6, 5, 95, 'White chocolate balances earthy matcha'),
(20, 6, 2, 90, 'Oats complement matcha earthiness'),
(21, 6, 3, 80, 'Simple sweetness with green tea'),
(22, 6, 7, 75, 'Almond nuttiness pairs well'),

-- Lemon Tea (ID=7) - 4 pairings
(23, 7, 6, 100, 'Perfect citrus harmony'),
(24, 7, 3, 85, 'Sweet balances tartness'),
(25, 7, 2, 80, 'Neutral oats with citrus'),
(26, 7, 7, 70, 'Almond complements lemon'),

-- Black Tea (ID=8) - 5 pairings
(27, 8, 2, 95, 'Classic tea biscuit pairing'),
(28, 8, 7, 90, 'Traditional biscotti with tea'),
(29, 8, 3, 85, 'Simple sweetness with tea'),
(30, 8, 6, 75, 'Lemon brightens black tea'),
(31, 8, 1, 70, 'Chocolate treats with afternoon tea');

-- ================================================
-- VIEWS untuk kemudahan query
-- ================================================

-- View untuk pairing lengkap dengan nama minuman dan cookies
CREATE OR REPLACE VIEW `v_pairing_details` AS
SELECT 
    p.id,
    p.drink_id,
    d.name AS drink_name,
    d.type AS drink_type,
    p.cookie_id,
    c.name AS cookie_name,
    c.type AS cookie_type,
    p.match_score,
    p.pairing_reason,
    CASE 
        WHEN p.match_score >= 90 THEN 'Perfect'
        WHEN p.match_score >= 75 THEN 'Very Good'
        WHEN p.match_score >= 60 THEN 'Good'
        WHEN p.match_score >= 50 THEN 'Fair'
        ELSE 'Poor'
    END AS match_category
FROM drink_cookie_pairing p
JOIN drinks d ON p.drink_id = d.id
JOIN cookies c ON p.cookie_id = c.id
ORDER BY p.drink_id, p.match_score DESC;

-- View untuk statistik pairing
CREATE OR REPLACE VIEW `v_pairing_stats` AS
SELECT 
    d.name AS drink_name,
    COUNT(p.id) AS total_pairings,
    MAX(p.match_score) AS best_score,
    AVG(p.match_score) AS avg_score,
    MIN(p.match_score) AS lowest_score
FROM drinks d
LEFT JOIN drink_cookie_pairing p ON d.id = p.drink_id
GROUP BY d.id, d.name
ORDER BY avg_score DESC;

-- ================================================
-- INDEXES untuk performance
-- ================================================
CREATE INDEX idx_pairing_composite ON drink_cookie_pairing(drink_id, match_score DESC);
CREATE INDEX idx_drinks_type ON drinks(type);
CREATE INDEX idx_cookies_type ON cookies(type);

-- ================================================
-- SAMPLE QUERIES untuk testing
-- ================================================

-- Query 1: Ambil semua minuman
-- SELECT * FROM drinks ORDER BY name;

-- Query 2: Ambil rekomendasi cookies untuk minuman tertentu
-- SELECT c.*, p.match_score, p.pairing_reason 
-- FROM cookies c
-- JOIN drink_cookie_pairing p ON c.id = p.cookie_id
-- WHERE p.drink_id = 1
-- ORDER BY p.match_score DESC;

-- Query 3: Lihat pairing terbaik (score >= 90)
-- SELECT * FROM v_pairing_details WHERE match_score >= 90 ORDER BY match_score DESC;

-- Query 4: Statistik pairing per minuman
-- SELECT * FROM v_pairing_stats;

-- ================================================
-- DATABASE INFO
-- ================================================
SELECT 
    'Database created successfully!' AS status,
    (SELECT COUNT(*) FROM drinks) AS total_drinks,
    (SELECT COUNT(*) FROM cookies) AS total_cookies,
    (SELECT COUNT(*) FROM drink_cookie_pairing) AS total_pairings,
    NOW() AS created_at;