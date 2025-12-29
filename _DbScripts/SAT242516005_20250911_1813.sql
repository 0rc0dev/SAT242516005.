USE SAT242516005;
GO

IF OBJECT_ID('VardiyaEkle', 'P') IS NOT NULL
    DROP PROCEDURE VardiyaEkle;
GO

IF OBJECT_ID('VardiyaView', 'V') IS NOT NULL
    DROP VIEW VardiyaView;
GO

IF OBJECT_ID('Vardiya', 'U') IS NOT NULL
    DROP TABLE Vardiya;
GO

IF OBJECT_ID('Hasta', 'U') IS NOT NULL
    DROP TABLE Hasta;
GO

IF OBJECT_ID('Doktor', 'U') IS NOT NULL
    DROP TABLE Doktor;
GO

CREATE TABLE Doktor (
    DoktorId INT PRIMARY KEY IDENTITY(1,1),
    Ad NVARCHAR(50) NOT NULL,
    Soyad NVARCHAR(50) NOT NULL,
    Brans NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Hasta (
    HastaId INT PRIMARY KEY IDENTITY(1,1),
    Ad NVARCHAR(50) NOT NULL,
    Soyad NVARCHAR(50) NOT NULL,
    DogumTarihi DATE NOT NULL
);
GO

CREATE TABLE Vardiya (
    VardiyaId INT PRIMARY KEY IDENTITY(1,1),
    DoktorId INT NOT NULL,
    Tarih DATE NOT NULL,
    BaslangicSaati TIME NOT NULL,
    BitisSaati TIME NOT NULL,
    FOREIGN KEY (DoktorId) REFERENCES Doktor(DoktorId)
);
GO

CREATE VIEW VardiyaView AS
SELECT v.VardiyaId, d.Ad + ' ' + d.Soyad AS DoktorAdSoyad,
       v.Tarih, v.BaslangicSaati, v.BitisSaati
FROM Vardiya v
JOIN Doktor d ON v.DoktorId = d.DoktorId;
GO

CREATE PROCEDURE VardiyaEkle
    @DoktorId INT,
    @Tarih DATE,
    @BaslangicSaati TIME,
    @BitisSaati TIME
AS
BEGIN
    INSERT INTO Vardiya (DoktorId, Tarih, BaslangicSaati, BitisSaati)
    VALUES (@DoktorId, @Tarih, @BaslangicSaati, @BitisSaati);
END;
GO
