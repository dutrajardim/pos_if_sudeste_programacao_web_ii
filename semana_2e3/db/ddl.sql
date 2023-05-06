-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- db_IF.dbo.AspNetRoles definition

-- Drop table

-- DROP TABLE db_IF.dbo.AspNetRoles;

CREATE TABLE db_IF.dbo.AspNetRoles (
	Id nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Name nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NormalizedName nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ConcurrencyStamp nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_AspNetRoles PRIMARY KEY (Id)
);
 CREATE  UNIQUE NONCLUSTERED INDEX RoleNameIndex ON dbo.AspNetRoles (  NormalizedName ASC  )  
	 WHERE  ([NormalizedName] IS NOT NULL)
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.AspNetUsers definition

-- Drop table

-- DROP TABLE db_IF.dbo.AspNetUsers;

CREATE TABLE db_IF.dbo.AspNetUsers (
	Id nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	UserName nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NormalizedUserName nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Email nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NormalizedEmail nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	EmailConfirmed bit NOT NULL,
	PasswordHash nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	SecurityStamp nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ConcurrencyStamp nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	PhoneNumber nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	PhoneNumberConfirmed bit NOT NULL,
	TwoFactorEnabled bit NOT NULL,
	LockoutEnd datetimeoffset NULL,
	LockoutEnabled bit NOT NULL,
	AccessFailedCount int NOT NULL,
	CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id)
);
 CREATE NONCLUSTERED INDEX EmailIndex ON dbo.AspNetUsers (  NormalizedEmail ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE  UNIQUE NONCLUSTERED INDEX UserNameIndex ON dbo.AspNetUsers (  NormalizedUserName ASC  )  
	 WHERE  ([NormalizedUserName] IS NOT NULL)
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE db_IF.dbo.[__EFMigrationsHistory];

CREATE TABLE db_IF.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);


-- db_IF.dbo.tbAlimento definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbAlimento;

CREATE TABLE db_IF.dbo.tbAlimento (
	IdAlimento int IDENTITY(1,1) NOT NULL,
	IdTipoQuantidade int NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Carboidrato float NOT NULL,
	VitaminaA float NOT NULL,
	VitaminaB float NOT NULL,
	CONSTRAINT PK__tbAlimen__24065705F9637D45 PRIMARY KEY (IdAlimento)
);


-- db_IF.dbo.tbCategoriaMedicamento definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbCategoriaMedicamento;

CREATE TABLE db_IF.dbo.tbCategoriaMedicamento (
	IdCategoriaMedicamento int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	InformacaoComplementar varchar(5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbCatego__14A80672E346B6AA PRIMARY KEY (IdCategoriaMedicamento)
);


-- db_IF.dbo.tbEscalaBristol definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbEscalaBristol;

CREATE TABLE db_IF.dbo.tbEscalaBristol (
	IdEscalaBristol int IDENTITY(1,1) NOT NULL,
	Nome varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Sangue bit NULL,
	CONSTRAINT PK__tbEscala__A6FB417F76A6B4B3 PRIMARY KEY (IdEscalaBristol)
);


-- db_IF.dbo.tbExame definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbExame;

CREATE TABLE db_IF.dbo.tbExame (
	IdExame int IDENTITY(1,1) NOT NULL,
	Grupo int NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Descricao varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbExame__0C2F360F2216CC85 PRIMARY KEY (IdExame)
);


-- db_IF.dbo.tbGrupoPatologico definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbGrupoPatologico;

CREATE TABLE db_IF.dbo.tbGrupoPatologico (
	IdGrupoPatologico int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK__tbGrupoP__A7D4244DF0B4C5B5 PRIMARY KEY (IdGrupoPatologico)
);


-- db_IF.dbo.tbGruposReceitasDespesas definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbGruposReceitasDespesas;

CREATE TABLE db_IF.dbo.tbGruposReceitasDespesas (
	IdReceitaDespesa int IDENTITY(1,1) NOT NULL,
	Tipo int NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK__tbGrupos__6D0EB540F61EA832 PRIMARY KEY (IdReceitaDespesa)
);


-- db_IF.dbo.tbPais definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbPais;

CREATE TABLE db_IF.dbo.tbPais (
	IdPais int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Sigla varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbPais__FC850A7B43473BCC PRIMARY KEY (IdPais)
);


-- db_IF.dbo.tbPatologia definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbPatologia;

CREATE TABLE db_IF.dbo.tbPatologia (
	IdPatologia int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	InformacaoComplementar varchar(5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbPatolo__6D573A326AEEE3E4 PRIMARY KEY (IdPatologia)
);


-- db_IF.dbo.tbPlano definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbPlano;

CREATE TABLE db_IF.dbo.tbPlano (
	IdPlano int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Validade int NOT NULL,
	Valor decimal(10,2) NOT NULL,
	CONSTRAINT PK__tbPlano__4C970C54B227DBD4 PRIMARY KEY (IdPlano)
);


-- db_IF.dbo.tbSubstancia definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbSubstancia;

CREATE TABLE db_IF.dbo.tbSubstancia (
	IdSubstancia int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	InformacaoComplementar varchar(5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbSubsta__13276D32164DD309 PRIMARY KEY (IdSubstancia)
);


-- db_IF.dbo.tbSuplemento definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbSuplemento;

CREATE TABLE db_IF.dbo.tbSuplemento (
	IdSuplemento int IDENTITY(1,1) NOT NULL,
	IdTipoQuantidade int NOT NULL,
	Tipo int NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	DoseMinima float NOT NULL,
	DoseMaxima float NOT NULL,
	Carboidrato float NOT NULL,
	VitaminaA float NOT NULL,
	VitaminaB float NOT NULL,
	CONSTRAINT PK__tbSuplem__EC3A6B1670079CD9 PRIMARY KEY (IdSuplemento)
);


-- db_IF.dbo.tbTipoAcesso definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbTipoAcesso;

CREATE TABLE db_IF.dbo.tbTipoAcesso (
	IdTipoAcesso int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	FlagAtivo bit NOT NULL,
	CONSTRAINT PK__tbTipoAc__FFC17AE5FD267F9A PRIMARY KEY (IdTipoAcesso)
);


-- db_IF.dbo.tbTipoProfissional definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbTipoProfissional;

CREATE TABLE db_IF.dbo.tbTipoProfissional (
	IdTipoProfissional int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbTipoPr__358F03BEB90F480F PRIMARY KEY (IdTipoProfissional)
);


-- db_IF.dbo.AspNetRoleClaims definition

-- Drop table

-- DROP TABLE db_IF.dbo.AspNetRoleClaims;

CREATE TABLE db_IF.dbo.AspNetRoleClaims (
	Id int IDENTITY(1,1) NOT NULL,
	RoleId nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ClaimType nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ClaimValue nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id),
	CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES db_IF.dbo.AspNetRoles(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_AspNetRoleClaims_RoleId ON dbo.AspNetRoleClaims (  RoleId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.AspNetUserClaims definition

-- Drop table

-- DROP TABLE db_IF.dbo.AspNetUserClaims;

CREATE TABLE db_IF.dbo.AspNetUserClaims (
	Id int IDENTITY(1,1) NOT NULL,
	UserId nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ClaimType nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ClaimValue nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_AspNetUserClaims PRIMARY KEY (Id),
	CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES db_IF.dbo.AspNetUsers(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_AspNetUserClaims_UserId ON dbo.AspNetUserClaims (  UserId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.AspNetUserLogins definition

-- Drop table

-- DROP TABLE db_IF.dbo.AspNetUserLogins;

CREATE TABLE db_IF.dbo.AspNetUserLogins (
	LoginProvider nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProviderKey nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProviderDisplayName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UserId nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_AspNetUserLogins PRIMARY KEY (LoginProvider,ProviderKey),
	CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES db_IF.dbo.AspNetUsers(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_AspNetUserLogins_UserId ON dbo.AspNetUserLogins (  UserId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.AspNetUserRoles definition

-- Drop table

-- DROP TABLE db_IF.dbo.AspNetUserRoles;

CREATE TABLE db_IF.dbo.AspNetUserRoles (
	UserId nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	RoleId nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_AspNetUserRoles PRIMARY KEY (UserId,RoleId),
	CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES db_IF.dbo.AspNetRoles(Id) ON DELETE CASCADE,
	CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES db_IF.dbo.AspNetUsers(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_AspNetUserRoles_RoleId ON dbo.AspNetUserRoles (  RoleId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.AspNetUserTokens definition

-- Drop table

-- DROP TABLE db_IF.dbo.AspNetUserTokens;

CREATE TABLE db_IF.dbo.AspNetUserTokens (
	UserId nvarchar(450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	LoginProvider nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Name nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Value nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_AspNetUserTokens PRIMARY KEY (UserId,LoginProvider,Name),
	CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES db_IF.dbo.AspNetUsers(Id) ON DELETE CASCADE
);


-- db_IF.dbo.tbContrato definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbContrato;

CREATE TABLE db_IF.dbo.tbContrato (
	IdContrato int IDENTITY(1,1) NOT NULL,
	IdPlano int NOT NULL,
	DataInicio smalldatetime NULL,
	DataFim smalldatetime NULL,
	CONSTRAINT PK__tbContra__8569F05ADE9FA311 PRIMARY KEY (IdContrato),
	CONSTRAINT FK__tbContrat__IdPla__412EB0B6 FOREIGN KEY (IdPlano) REFERENCES db_IF.dbo.tbPlano(IdPlano)
);
 CREATE NONCLUSTERED INDEX IX_tbContrato_IdPlano ON dbo.tbContrato (  IdPlano ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbEstado definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbEstado;

CREATE TABLE db_IF.dbo.tbEstado (
	IdEstado int IDENTITY(1,1) NOT NULL,
	IdPais int NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UF varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbEstado__FBB0EDC1CA882B96 PRIMARY KEY (IdEstado),
	CONSTRAINT FK__tbEstado__IdPais__398D8EEE FOREIGN KEY (IdPais) REFERENCES db_IF.dbo.tbPais(IdPais)
);
 CREATE NONCLUSTERED INDEX IX_tbEstado_IdPais ON dbo.tbEstado (  IdPais ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbGrupoPatologico_X_Patologia definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbGrupoPatologico_X_Patologia;

CREATE TABLE db_IF.dbo.tbGrupoPatologico_X_Patologia (
	IdPatologia_X_GrupoPatologico int IDENTITY(1,1) NOT NULL,
	IdGrupoPatologico int NOT NULL,
	IdPatologia int NOT NULL,
	CONSTRAINT PK__tbGrupoP__2BA30300F08B048B PRIMARY KEY (IdPatologia_X_GrupoPatologico),
	CONSTRAINT FK__tbGrupoPa__IdGru__5070F446 FOREIGN KEY (IdGrupoPatologico) REFERENCES db_IF.dbo.tbGrupoPatologico(IdGrupoPatologico),
	CONSTRAINT FK__tbGrupoPa__IdPat__5165187F FOREIGN KEY (IdPatologia) REFERENCES db_IF.dbo.tbPatologia(IdPatologia)
);
 CREATE NONCLUSTERED INDEX IX_tbGrupoPatologico_X_Patologia_IdGrupoPatologico ON dbo.tbGrupoPatologico_X_Patologia (  IdGrupoPatologico ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbGrupoPatologico_X_Patologia_IdPatologia ON dbo.tbGrupoPatologico_X_Patologia (  IdPatologia ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbLancarReceitasDespesas definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbLancarReceitasDespesas;

CREATE TABLE db_IF.dbo.tbLancarReceitasDespesas (
	IdLancamento int IDENTITY(1,1) NOT NULL,
	IdReceitaDespesa int NOT NULL,
	[Data] datetime NOT NULL,
	CONSTRAINT PK__tbLancar__2E53154926286AD6 PRIMARY KEY (IdLancamento),
	CONSTRAINT FK__tbLancarR__IdRec__1EA48E88 FOREIGN KEY (IdReceitaDespesa) REFERENCES db_IF.dbo.tbGruposReceitasDespesas(IdReceitaDespesa)
);
 CREATE NONCLUSTERED INDEX IX_tbLancarReceitasDespesas_IdReceitaDespesa ON dbo.tbLancarReceitasDespesas (  IdReceitaDespesa ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbMedicamento definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbMedicamento;

CREATE TABLE db_IF.dbo.tbMedicamento (
	IdMedicamento int IDENTITY(1,1) NOT NULL,
	IdCategoriaMedicamento int NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Bula varchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	BulaArquivo varbinary(MAX) NULL,
	CONSTRAINT PK__tbMedica__AC96376E52F14D42 PRIMARY KEY (IdMedicamento),
	CONSTRAINT FK__tbMedicam__IdCat__5812160E FOREIGN KEY (IdCategoriaMedicamento) REFERENCES db_IF.dbo.tbCategoriaMedicamento(IdCategoriaMedicamento)
);
 CREATE NONCLUSTERED INDEX IX_tbMedicamento_IdCategoriaMedicamento ON dbo.tbMedicamento (  IdCategoriaMedicamento ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbCidade definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbCidade;

CREATE TABLE db_IF.dbo.tbCidade (
	IdCidade int IDENTITY(1,1) NOT NULL,
	IdEstado int NULL,
	nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbCidade__160879A3A746DC0A PRIMARY KEY (IdCidade),
	CONSTRAINT FK__tbCidade__IdEsta__3C69FB99 FOREIGN KEY (IdEstado) REFERENCES db_IF.dbo.tbEstado(IdEstado)
);
 CREATE NONCLUSTERED INDEX IX_tbCidade_IdEstado ON dbo.tbCidade (  IdEstado ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbPaciente definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbPaciente;

CREATE TABLE db_IF.dbo.tbPaciente (
	IdPaciente int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	RG varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CPF varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	DataNascimento date NOT NULL,
	NomeResponsavel varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Sexo char(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Etnia int NOT NULL,
	Endereco varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Bairro varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	IdCidade int NULL,
	TelResidencial varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TelComercial varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TelCelular varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Profissao varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	FlgAtleta bit NULL,
	FlgGestante bit NULL,
	CONSTRAINT PK__tbPacien__C93DB49B03A2585E PRIMARY KEY (IdPaciente),
	CONSTRAINT FK__tbPacient__IdCid__68487DD7 FOREIGN KEY (IdCidade) REFERENCES db_IF.dbo.tbCidade(IdCidade)
);
 CREATE NONCLUSTERED INDEX IX_tbPaciente_IdCidade ON dbo.tbPaciente (  IdCidade ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbProfissional definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbProfissional;

CREATE TABLE db_IF.dbo.tbProfissional (
	IdProfissional int IDENTITY(1,1) NOT NULL,
	IdTipoProfissional int NULL,
	IdContrato int NOT NULL,
	IdTipoAcesso int NULL,
	IdCidade int NOT NULL,
	IdUser nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CPF varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CRM_CRN varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Especialidade varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Logradouro varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Numero varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Bairro varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CEP varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Cidade varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Estado varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	DDD1 varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	DDD2 varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Telefone1 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Telefone2 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Salario decimal(10,2) NULL,
	CONSTRAINT PK__tbProfis__B9503FBC93FEB044 PRIMARY KEY (IdProfissional),
	CONSTRAINT FK__tbProfiss__IdCid__49C3F6B7 FOREIGN KEY (IdCidade) REFERENCES db_IF.dbo.tbCidade(IdCidade),
	CONSTRAINT FK__tbProfiss__IdCon__47DBAE45 FOREIGN KEY (IdContrato) REFERENCES db_IF.dbo.tbContrato(IdContrato),
	CONSTRAINT FK__tbProfiss__IdTip__48CFD27E FOREIGN KEY (IdTipoAcesso) REFERENCES db_IF.dbo.tbTipoAcesso(IdTipoAcesso)
);
 CREATE NONCLUSTERED INDEX IX_tbProfissional_IdCidade ON dbo.tbProfissional (  IdCidade ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbProfissional_IdContrato ON dbo.tbProfissional (  IdContrato ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbProfissional_IdTipoAcesso ON dbo.tbProfissional (  IdTipoAcesso ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbReceitaAlimentarPadrao definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbReceitaAlimentarPadrao;

CREATE TABLE db_IF.dbo.tbReceitaAlimentarPadrao (
	IdReceitaAlimentarPadrao int IDENTITY(1,1) NOT NULL,
	IdProfissional int NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	InformacaoComplementar varchar(5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbReceit__6386356134E3EECA PRIMARY KEY (IdReceitaAlimentarPadrao),
	CONSTRAINT FK__tbReceita__IdPro__5EBF139D FOREIGN KEY (IdProfissional) REFERENCES db_IF.dbo.tbProfissional(IdProfissional)
);
 CREATE NONCLUSTERED INDEX IX_tbReceitaAlimentarPadrao_IdProfissional ON dbo.tbReceitaAlimentarPadrao (  IdProfissional ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbReceitaAlimentarPadrao_X_Alimento definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbReceitaAlimentarPadrao_X_Alimento;

CREATE TABLE db_IF.dbo.tbReceitaAlimentarPadrao_X_Alimento (
	IdReceitaAlimentarPadrao_X_Alimento_X_QuantidadeAlimento int IDENTITY(1,1) NOT NULL,
	IdReceitaAlimentarPadrao int NOT NULL,
	IdAlimento int NOT NULL,
	IdQuantidadeAlimento int NOT NULL,
	Periodicidade varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	QuantoTempo varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbReceit__2843B293CFC3AE95 PRIMARY KEY (IdReceitaAlimentarPadrao_X_Alimento_X_QuantidadeAlimento),
	CONSTRAINT FK__tbReceita__IdAli__656C112C FOREIGN KEY (IdAlimento) REFERENCES db_IF.dbo.tbAlimento(IdAlimento),
	CONSTRAINT FK__tbReceita__IdRec__6477ECF3 FOREIGN KEY (IdReceitaAlimentarPadrao) REFERENCES db_IF.dbo.tbReceitaAlimentarPadrao(IdReceitaAlimentarPadrao)
);
 CREATE NONCLUSTERED INDEX IX_tbReceitaAlimentarPadrao_X_Alimento_IdAlimento ON dbo.tbReceitaAlimentarPadrao_X_Alimento (  IdAlimento ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbReceitaAlimentarPadrao_X_Alimento_IdReceitaAlimentarPadrao ON dbo.tbReceitaAlimentarPadrao_X_Alimento (  IdReceitaAlimentarPadrao ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbReceitaMedicaPadrao definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbReceitaMedicaPadrao;

CREATE TABLE db_IF.dbo.tbReceitaMedicaPadrao (
	IdReceitaMedicaPadrao int IDENTITY(1,1) NOT NULL,
	IdProfissional int NOT NULL,
	Nome varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	InformacaoComplementar varchar(5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbReceit__E6DF7D7799F5B7A8 PRIMARY KEY (IdReceitaMedicaPadrao),
	CONSTRAINT FK__tbReceita__IdPro__619B8048 FOREIGN KEY (IdProfissional) REFERENCES db_IF.dbo.tbProfissional(IdProfissional)
);
 CREATE NONCLUSTERED INDEX IX_tbReceitaMedicaPadrao_IdProfissional ON dbo.tbReceitaMedicaPadrao (  IdProfissional ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbExame_X_Pacientes definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbExame_X_Pacientes;

CREATE TABLE db_IF.dbo.tbExame_X_Pacientes (
	IdExame_X_Paciente int IDENTITY(1,1) NOT NULL,
	IdExame int NOT NULL,
	IdPaciente int NOT NULL,
	[Data] date NULL,
	Resultado varchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbExame___8F261547E55E544D PRIMARY KEY (IdExame_X_Paciente),
	CONSTRAINT FK__tbExame_X__IdExa__08B54D69 FOREIGN KEY (IdExame) REFERENCES db_IF.dbo.tbExame(IdExame),
	CONSTRAINT FK__tbExame_X__IdPac__09A971A2 FOREIGN KEY (IdPaciente) REFERENCES db_IF.dbo.tbPaciente(IdPaciente)
);
 CREATE NONCLUSTERED INDEX IX_tbExame_X_Pacientes_IdExame ON dbo.tbExame_X_Pacientes (  IdExame ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbExame_X_Pacientes_IdPaciente ON dbo.tbExame_X_Pacientes (  IdPaciente ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbHistoriaPatologica definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbHistoriaPatologica;

CREATE TABLE db_IF.dbo.tbHistoriaPatologica (
	IdHistoriaPatologica int IDENTITY(1,1) NOT NULL,
	IdPaciente int NOT NULL,
	IdPatologia int NULL,
	FlgHAS bit NULL,
	FlgAVC bit NULL,
	FlgDoencasPulmonares bit NULL,
	FlgDoencasCardiacas bit NULL,
	FlgDoencaRenal bit NULL,
	FlgDoencaHepatica bit NULL,
	FlgNeoplasia bit NULL,
	FlgHipercolesterolemia bit NULL,
	FlgHipertrigliciridemia bit NULL,
	FlgHiperuricemia bit NULL,
	FlgAnemias bit NULL,
	FlgCirurgias bit NULL,
	FlgDoencasAutoImunes bit NULL,
	FlgDiabetes bit NULL,
	Obs varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbHistor__86BDE8CFC9133092 PRIMARY KEY (IdHistoriaPatologica),
	CONSTRAINT FK__tbHistori__IdPac__76969D2E FOREIGN KEY (IdPaciente) REFERENCES db_IF.dbo.tbPaciente(IdPaciente),
	CONSTRAINT FK__tbHistori__IdPat__778AC167 FOREIGN KEY (IdPatologia) REFERENCES db_IF.dbo.tbPatologia(IdPatologia)
);
 CREATE NONCLUSTERED INDEX IX_tbHistoriaPatologica_IdPaciente ON dbo.tbHistoriaPatologica (  IdPaciente ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbHistoriaPatologica_IdPatologia ON dbo.tbHistoriaPatologica (  IdPatologia ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbHistoricoAlimentarNutricional definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbHistoricoAlimentarNutricional;

CREATE TABLE db_IF.dbo.tbHistoricoAlimentarNutricional (
	IdHistAlimentarNutricional int IDENTITY(1,1) NOT NULL,
	IdPaciente int NOT NULL,
	MotivacaoTratamento int NULL,
	ModismosAlimentares int NULL,
	FlgIntoleanciaAlimentar bit NULL,
	DescIntoleranciaAlimentar varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	FaseObesidadePerdaPeso int NULL,
	FlgPerdaGanhoPeso bit NULL,
	PesoMax int NULL,
	PesoMaxIdade int NULL,
	PesoMin int NULL,
	PesoMinIdade int NULL,
	FlgDietas bit NULL,
	DescDietas varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	FlgMedicamentos bit NULL,
	DescMedicamentos varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	FlgExercicios bit NULL,
	DescExercicios varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	FlgOutros bit NULL,
	DescOutros varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Obs varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbHistor__43605910B3DA1AA4 PRIMARY KEY (IdHistAlimentarNutricional),
	CONSTRAINT FK__tbHistori__IdPac__00200768 FOREIGN KEY (IdPaciente) REFERENCES db_IF.dbo.tbPaciente(IdPaciente)
);
 CREATE NONCLUSTERED INDEX IX_tbHistoricoAlimentarNutricional_IdPaciente ON dbo.tbHistoricoAlimentarNutricional (  IdPaciente ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbHistoricoDoencaAtual definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbHistoricoDoencaAtual;

CREATE TABLE db_IF.dbo.tbHistoricoDoencaAtual (
	IdHDA int IDENTITY(1,1) NOT NULL,
	IdPaciente int NOT NULL,
	IdPatologia int NULL,
	Historico varchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Cirurgia int NULL,
	Trauma int NULL,
	Infeccao int NULL,
	Neoplasia int NULL,
	Metastase int NULL,
	Queimadura int NULL,
	ObsNeoplasia varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ObsMetastase varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ObsQueimadura varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Outros varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbHistor__0B5E79E28B52222F PRIMARY KEY (IdHDA),
	CONSTRAINT FK__tbHistori__IdPac__72C60C4A FOREIGN KEY (IdPaciente) REFERENCES db_IF.dbo.tbPaciente(IdPaciente),
	CONSTRAINT FK__tbHistori__IdPat__73BA3083 FOREIGN KEY (IdPatologia) REFERENCES db_IF.dbo.tbPatologia(IdPatologia)
);
 CREATE NONCLUSTERED INDEX IX_tbHistoricoDoencaAtual_IdPaciente ON dbo.tbHistoricoDoencaAtual (  IdPaciente ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbHistoricoDoencaAtual_IdPatologia ON dbo.tbHistoricoDoencaAtual (  IdPatologia ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbHistoricoSocialAlimentar definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbHistoricoSocialAlimentar;

CREATE TABLE db_IF.dbo.tbHistoricoSocialAlimentar (
	IdHistSocialAlimentar int IDENTITY(1,1) NOT NULL,
	IdPaciente int NOT NULL,
	Profissao varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CargaHoraria int NULL,
	NroPessoasRes int NULL,
	RendaFamiliar decimal(12,2) NULL,
	Escolaridade varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	EstadoCivil varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NomeCompraAlimento varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NomeCozinhaAlimento varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CompraFeita int NULL,
	NomeRealizaRefeicao varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	FlgTabagismo bit NULL,
	QtdTabagismoDia int NULL,
	FlgEtilismo bit NULL,
	QtdEtilismoDia int NULL,
	FlgCafe bit NULL,
	QtdCafeDia int NULL,
	FlgPaiMaeHas bit NULL,
	FlgAvosHas bit NULL,
	FlgIrmaosHas bit NULL,
	FlgPaiMaeDiabetes bit NULL,
	FlgAvosDiabetes bit NULL,
	FlgIrmaosDiabetes bit NULL,
	FlgPaiMaeCancer bit NULL,
	FlgAvosCancer bit NULL,
	FlgIrmaosCancer bit NULL,
	FlgPaiMaeObesidade bit NULL,
	FlgAvosObesidade bit NULL,
	FlgIrmaosObesidade bit NULL,
	CONSTRAINT PK__tbHistor__7735810F6011D5BE PRIMARY KEY (IdHistSocialAlimentar),
	CONSTRAINT FK__tbHistori__IdPac__7D439ABD FOREIGN KEY (IdPaciente) REFERENCES db_IF.dbo.tbPaciente(IdPaciente)
);
 CREATE NONCLUSTERED INDEX IX_tbHistoricoSocialAlimentar_IdPaciente ON dbo.tbHistoricoSocialAlimentar (  IdPaciente ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbHoraPaciente_Profissional definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbHoraPaciente_Profissional;

CREATE TABLE db_IF.dbo.tbHoraPaciente_Profissional (
	IdHoraPaciente_Profissional int IDENTITY(1,1) NOT NULL,
	IdPaciente int NOT NULL,
	IdProfissional int NOT NULL,
	DataConsulta date NULL,
	HoraInicioIndividual time(0) NOT NULL,
	HoraFimIndividual time(0) NOT NULL,
	PrimeiraConculta bit NOT NULL,
	Compareceu bit NOT NULL,
	Motivo varchar(5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Resumo varchar(5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Valor decimal(10,2) NULL,
	CONSTRAINT PK__tbHoraPa__A67184267BAD11A4 PRIMARY KEY (IdHoraPaciente_Profissional),
	CONSTRAINT FK__tbHoraPac__IdPac__6EF57B66 FOREIGN KEY (IdPaciente) REFERENCES db_IF.dbo.tbPaciente(IdPaciente),
	CONSTRAINT FK__tbHoraPac__IdPro__6FE99F9F FOREIGN KEY (IdProfissional) REFERENCES db_IF.dbo.tbProfissional(IdProfissional)
);
 CREATE NONCLUSTERED INDEX IX_tbHoraPaciente_Profissional_IdPaciente ON dbo.tbHoraPaciente_Profissional (  IdPaciente ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbHoraPaciente_Profissional_IdProfissional ON dbo.tbHoraPaciente_Profissional (  IdProfissional ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbMedico_Paciente definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbMedico_Paciente;

CREATE TABLE db_IF.dbo.tbMedico_Paciente (
	IdMedico_Paciente int IDENTITY(1,1) NOT NULL,
	IdPaciente int NOT NULL,
	IdProfissional int NOT NULL,
	InformacaoResumida varchar(5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbMedico__1F0BE44CA433BC34 PRIMARY KEY (IdMedico_Paciente),
	CONSTRAINT FK__tbMedico___IdPac__6B24EA82 FOREIGN KEY (IdPaciente) REFERENCES db_IF.dbo.tbPaciente(IdPaciente),
	CONSTRAINT FK__tbMedico___IdPro__6C190EBB FOREIGN KEY (IdProfissional) REFERENCES db_IF.dbo.tbProfissional(IdProfissional)
);
 CREATE NONCLUSTERED INDEX IX_tbMedico_Paciente_IdPaciente ON dbo.tbMedico_Paciente (  IdPaciente ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbMedico_Paciente_IdProfissional ON dbo.tbMedico_Paciente (  IdProfissional ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbPergunta definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbPergunta;

CREATE TABLE db_IF.dbo.tbPergunta (
	IdPergunta int IDENTITY(1,1) NOT NULL,
	IdProfissional int NOT NULL,
	Nome varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Ativo bit NOT NULL,
	CONSTRAINT PK__tbPergun__6DC6D9A74686F2EE PRIMARY KEY (IdPergunta),
	CONSTRAINT FK__tbPergunt__IdPro__0C85DE4D FOREIGN KEY (IdProfissional) REFERENCES db_IF.dbo.tbProfissional(IdProfissional)
);
 CREATE NONCLUSTERED INDEX IX_tbPergunta_IdProfissional ON dbo.tbPergunta (  IdProfissional ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbRastreamentoResposta definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbRastreamentoResposta;

CREATE TABLE db_IF.dbo.tbRastreamentoResposta (
	IdRastreamentoResposta int IDENTITY(1,1) NOT NULL,
	IdPergunta int NOT NULL,
	VlrRespota int NOT NULL,
	IdParteCorpo int NOT NULL,
	Obs varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK__tbRastre__ABA70EB615D1F5DE PRIMARY KEY (IdRastreamentoResposta),
	CONSTRAINT FK__tbRastrea__IdPer__0F624AF8 FOREIGN KEY (IdPergunta) REFERENCES db_IF.dbo.tbPergunta(IdPergunta)
);
 CREATE NONCLUSTERED INDEX IX_tbRastreamentoResposta_IdPergunta ON dbo.tbRastreamentoResposta (  IdPergunta ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbAntropometria definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbAntropometria;

CREATE TABLE db_IF.dbo.tbAntropometria (
	IdAntropometria int IDENTITY(1,1) NOT NULL,
	IdHoraPaciente_Profissional int NOT NULL,
	IdPaciente int NOT NULL,
	Estatura int NULL,
	AlturaJoelho int NULL,
	PesoAtual int NULL,
	PesoUsual int NULL,
	TipoProtocolo int NULL,
	Tricipal int NULL,
	Subescap int NULL,
	AuxiliarMed int NULL,
	SupraIliaca int NULL,
	Abdomen int NULL,
	Peitoral int NULL,
	Coxa int NULL,
	Biceps int NULL,
	Panturrilha int NULL,
	PercGordura int NULL,
	CircunfBraco int NULL,
	CircunfAbdomen int NULL,
	CircunfCintura int NULL,
	CircunfQuadril int NULL,
	CONSTRAINT PK__tbAntrop__53A9E5942AE268DA PRIMARY KEY (IdAntropometria),
	CONSTRAINT FK__tbAntropo__IdHor__02FC7413 FOREIGN KEY (IdHoraPaciente_Profissional) REFERENCES db_IF.dbo.tbHoraPaciente_Profissional(IdHoraPaciente_Profissional),
	CONSTRAINT FK__tbAntropo__IdPac__03F0984C FOREIGN KEY (IdPaciente) REFERENCES db_IF.dbo.tbPaciente(IdPaciente)
);
 CREATE NONCLUSTERED INDEX IX_tbAntropometria_IdHoraPaciente_Profissional ON dbo.tbAntropometria (  IdHoraPaciente_Profissional ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbAntropometria_IdPaciente ON dbo.tbAntropometria (  IdPaciente ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbEscalaBristol_Paciente_Consulta definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbEscalaBristol_Paciente_Consulta;

CREATE TABLE db_IF.dbo.tbEscalaBristol_Paciente_Consulta (
	IdEscalaBristol_Paciente_Consulta int IDENTITY(1,1) NOT NULL,
	IdEscalaBristol int NOT NULL,
	IdPaciente int NOT NULL,
	IdHora_Paciente_Profissional int NOT NULL,
	CONSTRAINT PK__tbEscala__44B7B8967885A4AD PRIMARY KEY (IdEscalaBristol_Paciente_Consulta),
	CONSTRAINT FK__tbEscalaB__IdEsc__17F790F9 FOREIGN KEY (IdEscalaBristol) REFERENCES db_IF.dbo.tbEscalaBristol(IdEscalaBristol),
	CONSTRAINT FK__tbEscalaB__IdHor__19DFD96B FOREIGN KEY (IdHora_Paciente_Profissional) REFERENCES db_IF.dbo.tbHoraPaciente_Profissional(IdHoraPaciente_Profissional),
	CONSTRAINT FK__tbEscalaB__IdPac__18EBB532 FOREIGN KEY (IdPaciente) REFERENCES db_IF.dbo.tbPaciente(IdPaciente)
);
 CREATE NONCLUSTERED INDEX IX_tbEscalaBristol_Paciente_Consulta_IdEscalaBristol ON dbo.tbEscalaBristol_Paciente_Consulta (  IdEscalaBristol ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbEscalaBristol_Paciente_Consulta_IdHora_Paciente_Profissional ON dbo.tbEscalaBristol_Paciente_Consulta (  IdHora_Paciente_Profissional ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbEscalaBristol_Paciente_Consulta_IdPaciente ON dbo.tbEscalaBristol_Paciente_Consulta (  IdPaciente ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbExameFisico definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbExameFisico;

CREATE TABLE db_IF.dbo.tbExameFisico (
	IdExameFisico int IDENTITY(1,1) NOT NULL,
	IdHoraPaciente_Profissional int NULL,
	SNC int NULL,
	AtividadeFisica int NULL,
	TipoAtividadeFisica varchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Frequencia int NULL,
	HoraPreferido int NULL,
	Tempo int NULL,
	FlgDenticaoCompleta bit NULL,
	FlgDenticaoIncompleta bit NULL,
	FlgDenticaoAusente bit NULL,
	FlgDenticaoProtese bit NULL,
	Mastigacao int NULL,
	Peristalse int NULL,
	Fumante int NULL,
	FrequenciaCardiaca int NULL,
	PA varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	FrequenciaRespiratoria int NULL,
	Temperatura int NULL,
	Glicemia int NULL,
	Diurese int NULL,
	TipoDiurese int NULL,
	Evacuacao int NULL,
	TipoEvacuacao int NULL,
	Ingestao int NULL,
	Excrecao int NULL,
	FlgXerostomia bit NULL,
	FlgSialorreia bit NULL,
	FlgUlcerasBucais bit NULL,
	FlgNauseas bit NULL,
	FlgVomitos bit NULL,
	FlgDisfagia bit NULL,
	FlgOdinofagia bit NULL,
	FlgFistula bit NULL,
	FlgOral bit NULL,
	FlgOralEnteral bit NULL,
	FlgEnteralExclusiva bit NULL,
	FlgEnteralParental bit NULL,
	FlgParentalExclusiva bit NULL,
	FlgParentalOral bit NULL,
	TipoAcesso int NULL,
	FlgGastrico bit NULL,
	FlgTranspilorica bit NULL,
	FlgDuodenal bit NULL,
	FlgJejunal bit NULL,
	FlgHiperemia bit NULL,
	FlgSaidaSecrecao bit NULL,
	FlgPresencaFeridas bit NULL,
	Obs varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__tbExameF__C8897518FB452A27 PRIMARY KEY (IdExameFisico),
	CONSTRAINT FK__tbExameFi__IdHor__7A672E12 FOREIGN KEY (IdHoraPaciente_Profissional) REFERENCES db_IF.dbo.tbHoraPaciente_Profissional(IdHoraPaciente_Profissional)
);
 CREATE NONCLUSTERED INDEX IX_tbExameFisico_IdHoraPaciente_Profissional ON dbo.tbExameFisico (  IdHoraPaciente_Profissional ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- db_IF.dbo.tbRastreamentoMetabolico definition

-- Drop table

-- DROP TABLE db_IF.dbo.tbRastreamentoMetabolico;

CREATE TABLE db_IF.dbo.tbRastreamentoMetabolico (
	IdRastreamentoMetabolico int IDENTITY(1,1) NOT NULL,
	IdRastreamentoResposta int NOT NULL,
	IdHoraPaciente_Profissional int NOT NULL,
	ObsGeral varchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Total int NULL,
	CONSTRAINT PK__tbRastre__E5AA062396329FF6 PRIMARY KEY (IdRastreamentoMetabolico),
	CONSTRAINT FK__tbRastrea__IdHor__1332DBDC FOREIGN KEY (IdHoraPaciente_Profissional) REFERENCES db_IF.dbo.tbHoraPaciente_Profissional(IdHoraPaciente_Profissional),
	CONSTRAINT FK__tbRastrea__IdRas__123EB7A3 FOREIGN KEY (IdRastreamentoResposta) REFERENCES db_IF.dbo.tbRastreamentoResposta(IdRastreamentoResposta)
);
 CREATE NONCLUSTERED INDEX IX_tbRastreamentoMetabolico_IdHoraPaciente_Profissional ON dbo.tbRastreamentoMetabolico (  IdHoraPaciente_Profissional ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_tbRastreamentoMetabolico_IdRastreamentoResposta ON dbo.tbRastreamentoMetabolico (  IdRastreamentoResposta ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
