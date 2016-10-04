
CREATE TABLE Objects
(
	Object_name          VARCHAR2(50) NOT NULL 
);

CREATE UNIQUE INDEX XPKObjects ON Objects
(Object_name   ASC);

ALTER TABLE Objects
	ADD CONSTRAINT  XPKObjects PRIMARY KEY (Object_name);

CREATE TABLE Raiting
(
	SCORE_ID             NUMBER NOT NULL ,
	IS_MISSING_EXAM      VARCHAR2(3) NULL 
);

CREATE UNIQUE INDEX XPKRaiting ON Raiting
(SCORE_ID   ASC);

ALTER TABLE Raiting
	ADD CONSTRAINT  XPKRaiting PRIMARY KEY (SCORE_ID);

CREATE TABLE Object_reitings
(
	SCORE_ID             NUMBER NOT NULL ,
	Object_name          VARCHAR2(50) NOT NULL ,
	MARK                 NUMBER NOT NULL 
);

CREATE UNIQUE INDEX XPKObject_reitings ON Object_reitings
(Object_name   ASC,SCORE_ID   ASC);

ALTER TABLE Object_reitings
	ADD CONSTRAINT  XPKObject_reitings PRIMARY KEY (Object_name,SCORE_ID);

CREATE TABLE Specialties
(
	Speciality_ID        NUMBER NOT NULL ,
	NAME                 VARCHAR2(100) NOT NULL 
);

CREATE UNIQUE INDEX XPKSpecialties ON Specialties
(Speciality_ID   ASC);

ALTER TABLE Specialties
	ADD CONSTRAINT  XPKSpecialties PRIMARY KEY (Speciality_ID);

CREATE TABLE Abiturients
(
	Name                 VARCHAR2(20) NOT NULL ,
	Surname              VARCHAR2(30) NOT NULL ,
	Midle_name           VARCHAR2(20) NOT NULL ,
	Sex                  VARCHAR2(6) NOT NULL ,
	Birthday             DATE NOT NULL ,
	ID                   NUMBER NOT NULL ,
	Speciality_ID        NUMBER NULL ,
	SCORE_ID             NUMBER NULL 
);

CREATE UNIQUE INDEX XPKAbiturients ON Abiturients
(ID   ASC);

ALTER TABLE Abiturients
	ADD CONSTRAINT  XPKAbiturients PRIMARY KEY (ID);

ALTER TABLE Object_reitings
	ADD (CONSTRAINT R_10 FOREIGN KEY (SCORE_ID) REFERENCES Raiting (SCORE_ID));

ALTER TABLE Object_reitings
	ADD (CONSTRAINT R_11 FOREIGN KEY (Object_name) REFERENCES Objects (Object_name));

ALTER TABLE Abiturients
	ADD (CONSTRAINT R_3 FOREIGN KEY (Speciality_ID) REFERENCES Specialties (Speciality_ID) ON DELETE SET NULL);

ALTER TABLE Abiturients
	ADD (CONSTRAINT R_5 FOREIGN KEY (SCORE_ID) REFERENCES Raiting (SCORE_ID) ON DELETE SET NULL);
