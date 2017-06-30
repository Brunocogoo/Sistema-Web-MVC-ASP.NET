-- phpMyAdmin SQL Dump
-- version 4.5.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 30-Jun-2017 às 03:38
-- Versão do servidor: 5.7.11
-- PHP Version: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `web`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `filmes`
--

CREATE TABLE `filmes` (
  `cod` varchar(255) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `genero` varchar(255) NOT NULL,
  `duracao` varchar(255) NOT NULL,
  `diretor` varchar(255) NOT NULL,
  `imagemref` varchar(255) DEFAULT '0',
  `nota` varchar(255) NOT NULL,
  `videoref` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `filmes`
--

INSERT INTO `filmes` (`cod`, `nome`, `genero`, `duracao`, `diretor`, `imagemref`, `nota`, `videoref`) VALUES
('tt0837562', 'Hotel Transylvania', 'Animation, Comedy, Family', '91 min', 'Genndy Tartakovsky', 'hoteltransylvania_6254.jpg', '7.1', 'Hotel.Transylvânia.2012.720p.BluRay.x264-VTM_SL.mp4'),
('as', 'sa', '0', '0', '0', '16933824_1424715427540268_749561811_n.png', '0', 'teste2.mp4');

-- --------------------------------------------------------

--
-- Estrutura da tabela `meufilme`
--

CREATE TABLE `meufilme` (
  `pessoaid` int(11) NOT NULL,
  `filmeid` varchar(255) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `meufilme`
--

INSERT INTO `meufilme` (`pessoaid`, `filmeid`, `status`) VALUES
(5, 'tt3874544', 1),
(9, 'tt3874544', 1),
(9, 'tt0097757', 0),
(9, 'ss', 0);

-- --------------------------------------------------------

--
-- Estrutura da tabela `pessoa`
--

CREATE TABLE `pessoa` (
  `email` varchar(255) NOT NULL,
  `senha` varchar(255) NOT NULL,
  `nivel` int(11) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `pessoa`
--

INSERT INTO `pessoa` (`email`, `senha`, `nivel`, `id`) VALUES
('adm@local', '123', 1, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pessoa`
--
ALTER TABLE `pessoa`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pessoa`
--
ALTER TABLE `pessoa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
