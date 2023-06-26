CREATE DATABASE `tecnologia_hospitalar`;
use tecnologia_hospitalar;

CREATE TABLE `autenticacao` (
   `Id` int NOT NULL AUTO_INCREMENT,
   `Usuario` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
   `Senha` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
   `DataAlteracao` datetime DEFAULT NULL,
   `Status` int DEFAULT NULL,
   PRIMARY KEY (`Id`)
 ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `responsavel` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ResponsavelLegal` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ResponsavelTecnico` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Cargo` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `ConselhoClasse` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `UF` varchar(4) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `NumeroInscricao` varchar(32) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `DataCriacao` datetime NOT NULL,
  `DataAlteracao` datetime DEFAULT NULL,
  `Status` int DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `fornecedor` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RazaoSocial` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `NomeFantasia` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Endereco` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Cidade` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `UF` varchar(4) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `CEP` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Telefone` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Email` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `AutorizacaoANVISA` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `CNPJ` varchar(32) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Site` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `IdResponsavel` int DEFAULT NULL,
  `IdAutenticacao` int Not NULL,
  `DataCriacao` datetime NOT NULL,
  `DataAlteracao` datetime DEFAULT NULL,
  `Status` int DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `fk_Fornecedor_IdAutenticacao` (`IdAutenticacao`),
  KEY `fk_Fornecedor_IdResponsavel` (`IdResponsavel`),
  CONSTRAINT `fk_Fornecedor_IdAutenticacao` FOREIGN KEY (`IdAutenticacao`) REFERENCES `autenticacao` (`Id`),
  CONSTRAINT `fk_Fornecedor_IdResponsavel` FOREIGN KEY (`IdResponsavel`) REFERENCES `responsavel` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `produto` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CodigoNomeTecnico` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `RegraClassificacao` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ClasseRisco` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `NomeComercial` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `NomeComercialInternacional` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `ModelosComerciais` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Acessorios` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `ApresentacaoComercial` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `ImagemProdutoCaminho` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `NomeTecnico` varchar(126) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `TipoPeticao` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ManualUsuario` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `IdFornecedor` int DEFAULT NULL,
  `IdResponsavel` int DEFAULT NULL,
  `DataCriacao` datetime NOT NULL,
  `DataAlteracao` datetime DEFAULT NULL,
  `Status` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Produto_IdFornecedor` (`IdFornecedor`),
  KEY `fk_Produto_IdResponsavel` (`IdResponsavel`),
  CONSTRAINT `fk_Produto_IdFornecedor` FOREIGN KEY (`IdFornecedor`) REFERENCES `fornecedor` (`Id`),
  CONSTRAINT `fk_Produto_IdResponsavel` FOREIGN KEY (`IdResponsavel`) REFERENCES `responsavel` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `conformidade` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AutorizacaoFuncionamento` int DEFAULT NULL,
  `LicencaFuncionamento` int DEFAULT NULL,
  `BoasPraticas` int DEFAULT NULL,
  `IdentificacaoSanitaria` int DEFAULT NULL,
  `ClassificacaoEquipamento` int DEFAULT NULL,
  `CertificadoInmetro` int DEFAULT NULL,
  `InformacoesEconomica` int DEFAULT NULL,
  `TipoPeticao` int DEFAULT NULL,
  `EnvioPeticao` int DEFAULT NULL,
  `NumeroPeticao` int DEFAULT NULL,
  `ResutadoAnalise` int DEFAULT NULL,
  `IdProduto` int NOT NULL,
  `DataCriacao` datetime DEFAULT NULL,
  `DataAlteracao` datetime DEFAULT NULL,
  `Status` int DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `fk_IdProduto` (`IdProduto`),
  CONSTRAINT `fk_IdProduto` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `processo` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdProduto` int DEFAULT NULL,
  `NumeroProcesso` varchar(32) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `NumeroNotificacao` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `CodigoPeticao` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Descricao` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `DataCriacao` datetime NOT NULL,
  `DataAlteracao` datetime DEFAULT NULL,
  `Status` int DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `fk_Processo_IdProduto` (`IdProduto`),
  CONSTRAINT `fk_Processo_IdProduto` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `venda` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdProduto` int DEFAULT NULL,
  `NomeRepresentante` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `NomeEmpresa` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `CPF` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `CNPJ` varchar(32) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Telefone` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Endereco` varchar(124) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `DataVenda` datetime NOT NULL,
  `DataCriacao` datetime NOT NULL,
  `DataAlteracao` datetime DEFAULT NULL,
  `Status` int DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `fk_Venda_IdProduto` (`IdProduto`),
  CONSTRAINT `fk_Venda_IdProduto` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
