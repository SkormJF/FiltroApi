CREATE TABLE Owners(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(50),
    LastNames VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    Address VARCHAR(100),
    Phone VARCHAR(25)
);

CREATE TABLE Vets(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(120),
    Phone VARCHAR(25),
    Address VARCHAR(30),
    Email VARCHAR(100) UNIQUE
);

INSERT INTO Vets(Names, Phone, Address, Email)VALUES("GenVD","","False 123 Street", "GenVD@correo.com")

CREATE TABLE Pets(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(25),
    Specie ENUM("Perro", "Gato", "Pajaro"),
    Race ENUM("Angora", "Maicoon", "Pastor aleman", "Labrador", "Cacatua"),
    DateBirth DATE,
    OwnerId INTEGER,
    Photo TEXT
);


ALTER TABLE Pets ADD FOREIGN KEY (OwnerId) REFERENCES Owners(Id);

CREATE TABLE Quotes(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Date DATE,
    PetId INTEGER,
    VetId INTEGER,
    Description TEXT
);

ALTER TABLE Quotes ADD FOREIGN KEY (PetId) REFERENCES Pets(Id);
ALTER TABLE Quotes ADD FOREIGN KEY (VetId) REFERENCES Vets(Id);

