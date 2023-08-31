
CREATE DATABASE LubeePT;


USE LubeePT;

-- Crea una tabla llamada Ejemplos
CREATE TABLE Contract (
    id INT AUTO_INCREMENT PRIMARY KEY,
    CourseCode VARCHAR(50),
    FechaAlta DATE,
    Estado INT,
    CantidadEgresados INT,
    FechaEntrega DATE,
    MedioEntrega INT,
    Vendedor INT,
    ColegioNivel VARCHAR(50),
    ColegioNombre VARCHAR(50),
    ColegioCurso VARCHAR(10),
    ColegioLocalidad VARCHAR(50),
    Comision INT,
    Total DECIMAL(10, 2)
    
);

CREATE TABLE Articles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Precio DECIMAL(10, 2)
);

CREATE TABLE Details (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ContractId INT,
    ArticleId INT,
    CreateDate DATE,
    UpdateDate BOOL,
    Enabled INT,
    Deleted INT,
    CreatedBy VARCHAR(50),
    FOREIGN KEY (ContractId) REFERENCES Contract(id),
    FOREIGN KEY (ArticleId) REFERENCES Articles(id)
);


-- Inserta datos en la tabla Articles
INSERT INTO Articles (Nombre, Precio)
VALUES
    ('Artículo 1', 103.99),
    ('Artículo 2', 253.50),
    ('Artículo 3', 522.75),
    ('Pantalones', 2502.00),
    ('Gorros', 1200.00),
    ('Zapatillas', 4000.00),
    ('Medias', 5000.00),
    ('Remera', 3000.00);

-- Inserta datos en la tabla Contract
INSERT INTO Contract (CourseCode, FechaAlta, Estado, CantidadEgresados, FechaEntrega, MedioEntrega, Vendedor, ColegioNivel, ColegioNombre, ColegioCurso, ColegioLocalidad, Comision, Total)
VALUES
    ('COD123', '2023-08-15', 1, 50, '2023-09-01', 2, 101, 'Secundario', 'Colegio A', '4B', 'Catamarca', 10, 500.00),
    ('COD456', '2023-07-20', 2, 30, '2023-08-25', 1, 102, 'Primario', 'Colegio B', '4C', 'Catamarca', 5, 350.00),
    ('COD789', '2023-08-01', 1, 45, '2023-09-10', 3, 103, 'Secundario', 'Colegio C', '4A', 'Catamarca', 12, 650.00);
    
    -- Inserta datos en la tabla Details
INSERT INTO Details (ContractId, ArticleId, CreateDate, UpdateDate, Enabled, Deleted, CreatedBy)
VALUES
    (1, 1, '2023-08-15', TRUE, 1, 0, 'Usuario1'),
    (1, 2, '2023-08-16', FALSE, 1, 0, 'Usuario2'),
    (2, 3, '2023-07-22', TRUE, 1, 0, 'Usuario1'),
    (3, 1, '2023-08-02', TRUE, 1, 0, 'Usuario3'),
    (3, 2, '2023-08-03', TRUE, 1, 0, 'Usuario1');

