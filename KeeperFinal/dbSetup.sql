CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture',
  coverImg varchar(255) COMMENT 'User CoverImg'
) default charset utf8 COMMENT '';

CREATE TABLE keeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR (255) NOT NULL,
  description VARCHAR (500) NOT NULL,
  img VARCHAR (500) NOt NULL,
  views INT NOT NULL DEFAULT 0,
  kept INT NOT NULL DEFAULT 0,
  creatorId VARCHAR(255) NOT NUll,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

CREATE TABLE vaults(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR (255) NOT NULL,
  description VARCHAR (500) NOT NULL,
  img VARCHAR (500) NOt NULL,
  isPrivate BOOLEAN DEFAULT false,
  creatorId VARCHAR(255) NOT NUll,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
  )default charset utf8 COMMENT '';

CREATE TABLE vaultKeeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  accountId VARCHAR(255) NOT NULL,
  keepId INT NOT NULL,
  vaultId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

INSERT INTO keeps(name, description, img, views, creatorId)
VALUES('Naruto anime', 'This may be an obsession with Naruto anime', 'https://images.unsplash.com/photo-1630710478039-9c680b99f800?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2670&q=80', '0', '64e8e541ad74581073a28ba9' )

INSERT INTO vaultKeeps(vaultId, creatorId, accountId)
VALUES('1','64e8e541ad74581073a28ba9','64e8e541ad74581073a28ba9')

DROP TABLE accounts

DROP TABLE keeps

DROP TABLE vaults

DROP TABLE vaultKeeps

