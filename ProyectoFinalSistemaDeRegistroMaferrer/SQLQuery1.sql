CREATE TABLE Incidentes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    Tipo VARCHAR(100) NOT NULL,
    Lugar VARCHAR(150) NOT NULL,
    Descripcion VARCHAR(500),
    Estado VARCHAR(50) NOT NULL
);