CREATE TABLE Abiturients
(
	Name                 VARCHAR2(20) NOT NULL ,
	Surname              VARCHAR2(30) NOT NULL ,
	Midle_name           VARCHAR2(20) NOT NULL ,
	Sex                  VARCHAR2(6) NOT NULL ,
	Birthday             DATE NOT NULL ,
	Abiturient_ID        NUMBER NOT NULL 
);

CREATE UNIQUE INDEX XPKAbiturients ON Abiturients
(Abiturient_ID   ASC);

ALTER TABLE Abiturients
	ADD CONSTRAINT  XPKAbiturients PRIMARY KEY (Abiturient_ID);

CREATE TABLE Exam
(
	Exam_ID              NUMBER NOT NULL ,
	Presence             VARCHAR2(3) NOT NULL 
);

CREATE UNIQUE INDEX XPKЭкзамен ON Exam
(Exam_ID   ASC);

ALTER TABLE Exam
	ADD CONSTRAINT  XPKЭкзамен PRIMARY KEY (Exam_ID);

CREATE TABLE Objects
(
	Object_name          VARCHAR2(50) NULL ,
	Object_ID            NUMBER NOT NULL 
);

CREATE UNIQUE INDEX XPKObjects ON Objects
(Object_ID   ASC);

ALTER TABLE Objects
	ADD CONSTRAINT  XPKObjects PRIMARY KEY (Object_ID);

CREATE TABLE Object_raiting
(
	Mark                 NUMBER NOT NULL ,
	Exam_ID              NUMBER NULL ,
	Object_ID            NUMBER NULL ,
	Object_raiting_ID    NUMBER NOT NULL 
);

CREATE UNIQUE INDEX XPKObject_raiting ON Object_raiting
(Object_raiting_ID   ASC);

ALTER TABLE Object_raiting
	ADD CONSTRAINT  XPKObject_raiting PRIMARY KEY (Object_raiting_ID);

CREATE TABLE Specialties
(
	Speciality_ID        NUMBER NOT NULL ,
	NAME                 VARCHAR2(100) NOT NULL 
);

CREATE UNIQUE INDEX XPKSpecialties ON Specialties
(Speciality_ID   ASC);

ALTER TABLE Specialties
	ADD CONSTRAINT  XPKSpecialties PRIMARY KEY (Speciality_ID);

CREATE TABLE Statement
(
	Statement_ID         NUMBER NOT NULL ,
	Speciality_ID        NUMBER NULL ,
	Exam_ID              NUMBER NULL ,
	Abiturient_ID        NUMBER NULL 
);

CREATE UNIQUE INDEX XPKStatement ON Statement
(Statement_ID   ASC);

ALTER TABLE Statement
	ADD CONSTRAINT  XPKStatement PRIMARY KEY (Statement_ID);

CREATE TABLE Speciality_object
(
	Speciality_ID        NUMBER NOT NULL ,
	Object_ID            NUMBER NOT NULL 
);

CREATE UNIQUE INDEX XPKSpeciality_object ON Speciality_object
(Speciality_ID   ASC,Object_ID   ASC);

ALTER TABLE Speciality_object
	ADD CONSTRAINT  XPKSpeciality_object PRIMARY KEY (Speciality_ID,Object_ID);

ALTER TABLE Object_raiting
	ADD (CONSTRAINT R_26 FOREIGN KEY (Exam_ID) REFERENCES Exam (Exam_ID) ON DELETE SET NULL);

ALTER TABLE Object_raiting
	ADD (CONSTRAINT R_27 FOREIGN KEY (Object_ID) REFERENCES Objects (Object_ID) ON DELETE SET NULL);

ALTER TABLE Statement
	ADD (CONSTRAINT R_25 FOREIGN KEY (Exam_ID) REFERENCES Exam (Exam_ID) ON DELETE SET NULL);

ALTER TABLE Statement
	ADD (CONSTRAINT R_35 FOREIGN KEY (Abiturient_ID) REFERENCES Abiturients (Abiturient_ID) ON DELETE SET NULL);

ALTER TABLE Statement
	ADD (CONSTRAINT R_13 FOREIGN KEY (Speciality_ID) REFERENCES Specialties (Speciality_ID) ON DELETE SET NULL);

ALTER TABLE Speciality_object
	ADD (CONSTRAINT R_33 FOREIGN KEY (Speciality_ID) REFERENCES Specialties (Speciality_ID));

ALTER TABLE Speciality_object
	ADD (CONSTRAINT R_34 FOREIGN KEY (Object_ID) REFERENCES Objects (Object_ID));
