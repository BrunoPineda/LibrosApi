-- Crear la tabla Books
CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    ISBN NVARCHAR(20) NOT NULL UNIQUE,
    Price DECIMAL(10, 2) NULL
);
GO
-- Insertar datos de prueba
INSERT INTO Books (Title, Author, ISBN, Price) VALUES 
('Cien años de soledad', 'Gabriel García Márquez', '978-3-16-148410-0', 25.99),
('1984', 'George Orwell', '978-0-452-28423-4', 19.99),
('Orgullo y prejuicio', 'Jane Austen', '978-0-19-283355-2', 14.99),
('Crimen y castigo', 'Fyodor Dostoevsky', '978-0-14-044913-6', 22.99),
('El gran Gatsby', 'F. Scott Fitzgerald', '978-0-7432-7356-5', 18.99);
GO

SELECT * FROM Books;
