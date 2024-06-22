-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- 主机： 127.0.0.1:3306
-- 生成日期： 2024-06-22 14:35:41
-- 服务器版本： 8.2.0
-- PHP 版本： 8.2.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 数据库： `book`
--

-- --------------------------------------------------------

--
-- 表的结构 `books`
--

DROP TABLE IF EXISTS `books`;
CREATE TABLE IF NOT EXISTS `books` (
  `BookID` int NOT NULL AUTO_INCREMENT COMMENT '书的记录',
  `Title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '书名',
  `Author` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '作者',
  `ISBN` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT 'ISBN',
  `Publisher` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '出版社',
  `Year` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '出版年份',
  `CategoryID` int DEFAULT NULL COMMENT '分类',
  `Stock` int NOT NULL DEFAULT '0' COMMENT '库存',
  `Available` int NOT NULL DEFAULT '0' COMMENT '可借数量',
  PRIMARY KEY (`BookID`),
  UNIQUE KEY `ISBN` (`ISBN`),
  KEY `CategoryID` (`CategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- 转存表中的数据 `books`
--

INSERT INTO `books` (`BookID`, `Title`, `Author`, `ISBN`, `Publisher`, `Year`, `CategoryID`, `Stock`, `Available`) VALUES
(1, '百年孤独', '加西亚·马尔克斯', '9787544291170', '南海', '2021', 3, 20, 18),
(2, '房思琪的初恋乐园', '林奕含', '9787559614636', '北京联合出版公司', '2018', 3, 20, 20),
(3, '南京大屠杀：第二次世界大战中被遗忘的浩劫', '(美)张纯如(Iris Chang)著', '9787508653389', '中信出版社', '2021', 2, 20, 18),
(4, '活着 新经典文库 余华作品 To live', '余华', '9787530221532', '北京十月文艺出版社', '2021', 3, 30, 30),
(5, '亚特兰蒂斯：基因战争（全三册不单发）', '里德尔', '9787541140419', '四川文艺出版社', '2020', 3, 30, 30),
(6, '人性的弱点全集 How to win friends and influence people 完整全译本', '卡耐基 亦言', '9787505738966', '中国友谊出版公司', '2017', 1, 20, 20),
(7, '三体 123十周年纪念版刘慈欣雨果奖黑暗森林死神永生小说', '认知教学资源编辑室', '9787499629448', '环宇科学出版社', '2024', 2, 20, 18),
(8, '读客外国小说文库--教父Ⅲ.最后的教父', '(美)马里奥·普佐/17.5', '9787539967417', '江苏文艺出版社', '2018', 3, 20, 20),
(9, 'C++从入门到精通', '明日科技', '9787302589464', '清华大学出版社', '2021', 4, 20, 17),
(10, 'Python编程：从入门到实践：a hands-on, project-based introduction to programming', '马瑟斯', '9787115428028', '人民邮电出版社', '2016', 4, 20, 20),
(11, 'C++ Primer Plus (第6版 `中文版)', '(美)史蒂芬·普拉达(Stephen Prata)著,张海龙，袁国忠译', '9787115521644', '人民邮电', '2020', 5, 20, 20),
(12, '编程之美:微软技术面试心得', '编程之美小组', '9787121337826', '电子工业出版社', '2018', 6, 20, 20),
(13, 'JSON必知必会', '巴塞特 魏嘉汛', '9787115422071', '人民邮电出版社', '2016', 4, 20, 20),
(14, 'Head First设计模式（第二版）', '弗里曼 罗布森 UMLChina', '9787519859565', '中国电力出版社', '2022', 7, 20, 20),
(15, 'Web安全攻防从入门到精通', '红日安全', '9787301333099', '北京大学出版社', '2022', 4, 20, 20),
(16, '文学理论教程', '童庆炳', '9787040425079', '高等教育出版社', '2015', 8, 20, 20),
(17, '中国现代文学三十年（修订本）（本科教材）', '钱理群//温儒敏//吴福辉', '9787301036709', '北京大学', '2019', 9, 20, 20),
(18, '古代汉语', '王力', '9787101132434', '中华书局', '2018', 10, 20, 20),
(19, '文学原理', '金永兵', '9787040596533', '高等教育出版社', '暂无', 8, 20, 20),
(20, '面向智能时代', '关成华 黄荣怀', '9787519126346', '教育科学出版社', '2021', 11, 20, 20);

--
-- 触发器 `books`
--
DROP TRIGGER IF EXISTS `UpdateAvailableQuantity`;
DELIMITER $$
CREATE TRIGGER `UpdateAvailableQuantity` BEFORE UPDATE ON `books` FOR EACH ROW BEGIN
    
    IF NEW.Stock > OLD.Stock THEN
        SET NEW.Available = OLD.Available + (NEW.Stock - OLD.Stock);
    ELSEIF NEW.Stock < OLD.Stock THEN
        
        SET NEW.Available = GREATEST(0, OLD.Available + (NEW.Stock - OLD.Stock));
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- 表的结构 `borrowrecords`
--

DROP TABLE IF EXISTS `borrowrecords`;
CREATE TABLE IF NOT EXISTS `borrowrecords` (
  `RecordID` int NOT NULL AUTO_INCREMENT COMMENT '借书记录id',
  `UserID` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '借书用户',
  `ISBN` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '书的ISBN',
  `BorrowQuantity` int NOT NULL COMMENT '借书数量，借阅时借出的图书数量',
  `ReturnQuantity` int NOT NULL DEFAULT '0' COMMENT '还书数量',
  `BorrowDate` datetime NOT NULL COMMENT '借书日期',
  `ReturnDate` datetime DEFAULT NULL COMMENT '还书日期',
  `DueDate` datetime NOT NULL COMMENT '图书到期时间',
  PRIMARY KEY (`RecordID`),
  KEY `UserID` (`UserID`),
  KEY `ISBN` (`ISBN`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- 转存表中的数据 `borrowrecords`
--

INSERT INTO `borrowrecords` (`RecordID`, `UserID`, `ISBN`, `BorrowQuantity`, `ReturnQuantity`, `BorrowDate`, `ReturnDate`, `DueDate`) VALUES
(10, '1001', '9787544291170', 2, 0, '2024-06-22 20:43:11', NULL, '2024-06-27 20:43:11'),
(11, '1001', '9787499629448', 2, 0, '2024-06-22 20:43:19', NULL, '2024-06-27 20:43:19'),
(12, '123456', '9787508653389', 2, 0, '2024-06-22 20:49:49', NULL, '2024-06-27 20:49:49'),
(13, '123456', '9787302589464', 3, 0, '2024-06-22 20:49:55', NULL, '2024-06-27 20:49:55');

--
-- 触发器 `borrowrecords`
--
DROP TRIGGER IF EXISTS `AfterBorrowRecordUpdate`;
DELIMITER $$
CREATE TRIGGER `AfterBorrowRecordUpdate` AFTER UPDATE ON `borrowrecords` FOR EACH ROW BEGIN
    DECLARE 返回数量 INT;
    SET 返回数量 = NEW.ReturnQuantity - OLD.ReturnQuantity;
    IF NEW.ReturnQuantity > OLD.ReturnQuantity THEN
        UPDATE Books
        SET Available = Available + 返回数量
        WHERE ISBN = NEW.ISBN;
    END IF;
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `AfterBorrowRecordsInsert`;
DELIMITER $$
CREATE TRIGGER `AfterBorrowRecordsInsert` AFTER INSERT ON `borrowrecords` FOR EACH ROW BEGIN
    UPDATE Books
    SET Available = Available - NEW.BorrowQuantity
    WHERE ISBN = NEW.ISBN;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- 表的结构 `categories`
--

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `CategoryID` int NOT NULL AUTO_INCREMENT COMMENT '分类id',
  `CategoryName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '分类名称',
  PRIMARY KEY (`CategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- 转存表中的数据 `categories`
--

INSERT INTO `categories` (`CategoryID`, `CategoryName`) VALUES
(1, '社会科学总论'),
(2, '暂无'),
(3, '文学'),
(4, '工业技术'),
(5, '程序语言、算法语言'),
(6, '程序设计'),
(7, '软件工程'),
(8, '文学理论'),
(9, '文学史、文学思想史'),
(10, '古代汉语'),
(11, '教育科学研究');

-- --------------------------------------------------------

--
-- 表的结构 `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `UserID` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '账号',
  `Username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `Password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '密码',
  `Role` enum('admin','user') CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户区分',
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- 转存表中的数据 `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Password`, `Role`) VALUES
('1001', '张世杰', '123456', 'admin'),
('1111', '张镇长', '123456', 'admin'),
('123456', '张三', '123456', 'user'),
('1456', '那么', '123456', 'user'),
('14564', '那么', '123456', 'admin'),
('1457', '那么', '123456', 'user'),
('147', '离我拟定', '123456', 'user');

--
-- 限制导出的表
--

--
-- 限制表 `books`
--
ALTER TABLE `books`
  ADD CONSTRAINT `books_ibfk_1` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`CategoryID`) ON DELETE CASCADE;

--
-- 限制表 `borrowrecords`
--
ALTER TABLE `borrowrecords`
  ADD CONSTRAINT `borrowrecords_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`) ON DELETE CASCADE,
  ADD CONSTRAINT `borrowrecords_ibfk_2` FOREIGN KEY (`ISBN`) REFERENCES `books` (`ISBN`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
