CREATE DATABASE IF NOT EXISTS farmacia;
USE farmacia;

CREATE TABLE IF NOT EXISTS medicamentos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    tipo VARCHAR(100) NOT NULL,
    fecha_fabricacion DATE NOT NULL,
    fecha_vencimiento DATE NOT NULL,
    imagen TEXT
);

INSERT INTO medicamentos (nombre, tipo, fecha_fabricacion, fecha_vencimiento, imagen) VALUES
('Paracetamol', 'Analgésico', '2024-01-10', '2026-01-10', 'paracetamol.jpg'),
('Ibuprofeno', 'Antiinflamatorio', '2023-12-05', '2025-12-05', 'ibuprofeno.jpg'),
('Amoxicilina', 'Antibiótico', '2024-02-15', '2026-02-15', 'amoxicilina.jpg'),
('Loratadina', 'Antihistamínico', '2023-11-20', '2025-11-20', 'loratadina.jpg'),
('Omeprazol', 'Gastroprotector', '2024-03-01', '2026-03-01', 'omeprazol.jpg');
