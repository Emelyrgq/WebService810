--DROP DATABASE APIMONEDA

CREATE DATABASE APIMONEDA

USE APIMONEDA

drop table HistorialCrediticio;
drop table IndiceInflacion;
drop table SaludFinanciera;
drop table TasaCambio;

CREATE TABLE TasaCambio (
    Id INT PRIMARY KEY IDENTITY,
    Moneda VARCHAR(3),
    Tasa DECIMAL(18, 2)
);

CREATE TABLE IndiceInflacion (
    Id INT PRIMARY KEY IDENTITY,
    Periodo VARCHAR(6),
    Indice DECIMAL(18, 2)
);

CREATE TABLE SaludFinanciera (
    Id INT PRIMARY KEY IDENTITY,
    Cedula NVARCHAR(11),
    Indicador NVARCHAR(50),
    Comentario NVARCHAR(MAX),
    MontoTotalAdeudado DECIMAL(18, 2)
);

CREATE TABLE HistorialCrediticio (
    Id INT PRIMARY KEY IDENTITY,
    Cedula NVARCHAR(11),
    RNCEmpresa NVARCHAR(100),
    ConceptoDeuda NVARCHAR(100),
    Fecha DATE,
    MontoAdeudado DECIMAL(18, 2)
);


USE APIMONEDA 
-- Insertar datos de indice inflacion por año
INSERT INTO IndiceInflacion (Periodo, Indice)
VALUES ('202102', 8.24),
       ('202001', 3.78),
       ('201902', 1.81),
       ('201801', 3.56),
       ('201701', 3.28),
       ('201602', 1.61),
       ('201501', 8.40),
       ('201401', 3.00),
       ('201303', 7.83);


-- Insertar tasas de cambio reales para algunas monedas
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('USD', 1.0); -- Dólar estadounidense
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('EUR', 0.85); -- Euro
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('GBP', 0.72); -- Libra esterlina
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('JPY', 110.21); -- Yen japonés
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('CAD', 1.25); -- Dólar canadiense
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('AUD', 1.30); -- Dólar australiano
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('CHF', 0.92); -- Franco suizo
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('SEK', 8.64); -- Corona sueca
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('NOK', 8.86); -- Corona noruega
INSERT INTO TasaCambio (Moneda, Tasa) VALUES ('CNY', 6.45); -- Yuan chino

USE APIMONEDA
-- Insertar datos de Salud Financiera de Clientes
INSERT INTO SaludFinanciera (Cedula, Indicador, Comentario, MontoTotalAdeudado) VALUES
('78909876543', 'S', 'Pagos atrasados', 30000.75),
('98765432104', 'N', 'Deuda pendiente', 50000.00),
('23456789015', 'S', 'Sin comentarios', 7500.25),
('56789012306', 'N', 'Tarjeta de crédito', 100000.00),
('32109876547', 'S', 'Préstamo hipotecario', 250000.00),
('65432109878', 'N', 'Pagos atrasados', 15000.50),
('89012345679', 'S', 'Sin comentarios', 6000.00),
('12345678901', 'N', 'Cliente antiguo', 35000.00),
('78909876543', 'N', 'Sin comentarios', 15000.75),
('98765432104', 'S', 'Pagos atrasados', 40000.00),
('23456789015', 'N', 'Deuda pendiente', 65000.50),
('56789012346', 'S', 'Cliente nuevo', 200000.00),
('32109876547', 'N', 'Sin comentarios', 30000.00),
('65432109878', 'S', 'Préstamo hipotecario', 12000.75),
('89012345679', 'N', 'Tarjeta de crédito', 70000.00);

USE APIMONEDA
-- Insertar datos de Historial Crediticio  de Clientes
INSERT INTO HistorialCrediticio (Cedula, RNCEmpresa, ConceptoDeuda, Fecha, MontoAdeudado) VALUES
('40214026128', '101027791', 'Tarjeta de crédito', '2022-01-15', 15000.00),
('40212345672', '101027792', 'Préstamo hipotecario', '2022-02-20', 200000.50),
('40209876543', '101027793', 'Pagos atrasados', '2022-03-25', 30000.75),
('40265432104', '101027794', 'Deuda pendiente', '2022-04-10', 50000.00),
('05356789015', '101027795', 'Sin comentarios', '2022-05-05', 75000.25),
('05389012346', '101027796', 'Cliente nuevo', '2022-06-30', 10000.00),
('05309876547', '101027797', 'Tarjeta de crédito', '2022-07-20', 2500000.00),
('05332109878', '101027798', 'Préstamo hipotecario', '2022-08-15', 15000.50),
('05312345679', '101027799', 'Pagos atrasados', '2022-09-10', 6000.00),
('05345678901', '101027710', 'Deuda pendiente', '2022-10-05', 35000.00),
('05312345672', '101027711', 'Cliente antiguo', '2022-11-30', 8000.25),
('05309876543', '101027712', 'Sin comentarios', '2022-12-25', 1500.75),
('05365432104', '101027713', 'Préstamo hipotecario', '2023-01-10', 40000.00),
('05356789015', '101027714', 'Tarjeta de crédito', '2023-02-15', 6500.50),
('05389012346', '101027715', 'Sin comentarios', '2023-03-20', 2000.00),
('05309876547', '101027716', 'Deuda pendiente', '2023-04-25', 300000.00),
('05332109878', '101027717', 'Pagos atrasados', '2023-05-30', 1200.75),
('05312345679', '101027718', 'Tarjeta de crédito', '2023-06-05', 70000.00),
('05345678901', '101027719', 'Préstamo hipotecario', '2023-07-10', 250000.00),
('05312345672', '101027720', 'Sin comentarios', '2023-08-15', 90000.25);
