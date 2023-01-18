-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : mar. 17 jan. 2023 à 11:25
-- Version du serveur :  10.4.18-MariaDB
-- Version de PHP : 7.4.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `smartparking`
--

-- --------------------------------------------------------

--
-- Structure de la table `parking`
--

CREATE TABLE `parking` (
  `id` int(11) NOT NULL,
  `name` varchar(25) NOT NULL,
  `adresse` varchar(25) NOT NULL,
  `contact` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `place`
--

CREATE TABLE `place` (
  `id` int(11) NOT NULL,
  `code` varchar(25) NOT NULL,
  `status` int(11) NOT NULL,
  `type` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `place`
--

INSERT INTO `place` (`id`, `code`, `status`, `type`) VALUES
(1, 'A-2', 1, 'Auto'),
(2, 'A-3', 1, 'Auto'),
(3, 'B-2', 1, 'Camion');

-- --------------------------------------------------------

--
-- Structure de la table `reservation`
--

CREATE TABLE `reservation` (
  `id` int(11) NOT NULL,
  `placeId` int(11) NOT NULL,
  `matricule` varchar(25) NOT NULL,
  `ownername` varchar(25) NOT NULL,
  `model` varchar(25) NOT NULL,
  `type` varchar(11) NOT NULL,
  `prix` double NOT NULL,
  `dateEnreg` date NOT NULL,
  `owenerCin` varchar(25) NOT NULL,
  `status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `reservation`
--

INSERT INTO `reservation` (`id`, `placeId`, `matricule`, `ownername`, `model`, `type`, `prix`, `dateEnreg`, `owenerCin`, `status`) VALUES
(1, 1, 'azerty', 'io', 'rtyui', 'Auto', 2, '2023-01-13', 'iop', 'en coure'),
(2, 1, 'zertyu', 'zeretr', 'tytuyu', 'Auto', 2, '2023-01-13', 'erty', 'terminer'),
(3, 1, 'ertyu', 'hgfjg', 'dhgfjhg', 'Auto', 2, '2023-01-13', 'ertyuyi', 'terminer'),
(4, 2, 'rh', 'sfdg', 'fdgf', 'Auto', 2, '2023-01-13', 'dsfdgf', 'en coure'),
(5, 1, 'zezre', 'zeret', 'rert', 'Auto', 3, '2023-01-15', 'ezret', 'en coure'),
(6, 1, 'azer', 'ezret', 'retr', 'Auto', 3, '2023-01-15', 'ezretret', 'en coure'),
(7, 1, 'erty', 'zert', 'zerty', 'Auto', 3, '2023-01-15', 'zert', 'en coure'),
(8, 2, 'azer', 'zer', 'aze', 'Auto', 3, '2023-01-16', 'ze', 'en coure'),
(9, 2, 'ert', 'dfs', 'dfsf', 'Auto', 3, '2023-01-17', 'ersrd', 'en coure'),
(10, 2, 'azer', 'ty', 'tyryt', 'Auto', 3, '2023-01-17', 'ret', 'en coure'),
(11, 2, 'gfd', 'fdgf', 'gh', 'Auto', 3, '2023-01-17', 'dfg', 'en coure');

-- --------------------------------------------------------

--
-- Structure de la table `ticket`
--

CREATE TABLE `ticket` (
  `id` int(11) NOT NULL,
  `idRes` int(11) NOT NULL,
  `idUser` int(11) NOT NULL,
  `dateEmp` date NOT NULL,
  `total` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `ticket`
--

INSERT INTO `ticket` (`id`, `idRes`, `idUser`, `dateEmp`, `total`) VALUES
(3, 2, 1, '2023-01-11', 22),
(4, 3, 1, '2023-01-25', 111);

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `role` varchar(25) NOT NULL,
  `username` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  `nom` varchar(25) DEFAULT NULL,
  `prenom` varchar(25) DEFAULT NULL,
  `CIN` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `user`
--

INSERT INTO `user` (`id`, `role`, `username`, `password`, `nom`, `prenom`, `CIN`) VALUES
(1, 'rtere', 'ghfgj', 'nbcvxc', 'vxcbvn', 'vbncbcvx', 'xccbn');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `parking`
--
ALTER TABLE `parking`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `place`
--
ALTER TABLE `place`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`id`),
  ADD KEY `placeId` (`placeId`);

--
-- Index pour la table `ticket`
--
ALTER TABLE `ticket`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idRes` (`idRes`),
  ADD KEY `idUser` (`idUser`);

--
-- Index pour la table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `parking`
--
ALTER TABLE `parking`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `place`
--
ALTER TABLE `place`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `reservation`
--
ALTER TABLE `reservation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT pour la table `ticket`
--
ALTER TABLE `ticket`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pour la table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `reservation_ibfk_1` FOREIGN KEY (`placeId`) REFERENCES `place` (`id`);

--
-- Contraintes pour la table `ticket`
--
ALTER TABLE `ticket`
  ADD CONSTRAINT `ticket_ibfk_1` FOREIGN KEY (`idRes`) REFERENCES `reservation` (`id`),
  ADD CONSTRAINT `ticket_ibfk_2` FOREIGN KEY (`idUser`) REFERENCES `user` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
