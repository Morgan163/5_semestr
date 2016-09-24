CREATE TABLE Abiturients
(
	Name                 VARCHAR2(20) NOT NULL ,
	Surname              VARCHAR2(30) NOT NULL ,
	Midle_name           VARCHAR2(20) NOT NULL ,
	Sex                  VARCHAR2(6) NOT NULL ,
	Birthday             DATE NOT NULL ,
	ID                   NUMBER NOT NULL 
);

CREATE UNIQUE INDEX XPKAbiturients ON Abiturients
(ID   ASC);

ALTER TABLE Abiturients
	ADD CONSTRAINT  XPKAbiturients PRIMARY KEY (ID);

CREATE TABLE Specialties
(
	Speciality_ID        NUMBER NOT NULL ,
	ID                   NUMBER NOT NULL 
);

CREATE UNIQUE INDEX XPKSpecialties ON Specialties
(Speciality_ID   ASC);

ALTER TABLE Specialties
	ADD CONSTRAINT  XPKSpecialties PRIMARY KEY (Speciality_ID);

CREATE TABLE Objects
(
	Object_name          VARCHAR2(50) NOT NULL ,
	Speciality_ID        NUMBER NOT NULL 
);

CREATE UNIQUE INDEX XPKObjects ON Objects
(Object_name   ASC);

ALTER TABLE Objects
	ADD CONSTRAINT  XPKObjects PRIMARY KEY (Object_name);

ALTER TABLE Specialties
	ADD (CONSTRAINT R_1 FOREIGN KEY (ID) REFERENCES Abiturients (ID) ON DELETE SET NULL);

ALTER TABLE Objects
	ADD (CONSTRAINT R_2 FOREIGN KEY (Speciality_ID) REFERENCES Specialties (Speciality_ID) ON DELETE SET NULL);
