CREATE DATABASE RealEstateDB;
GO

USE RealEstateDB;
GO

-- Tabla Users
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),        
    Username NVARCHAR(100) NOT NULL,            
    PasswordHash NVARCHAR(255) NOT NULL         
);
GO

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único del usuario', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Users, 
    @level2type = N'COLUMN', @level2name = UserId;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Nombre de usuario para login', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Users, 
    @level2type = N'COLUMN', @level2name = Username;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Hash de la contraseña del usuario', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Users, 
    @level2type = N'COLUMN', @level2name = PasswordHash;
GO

-- Tabla Owners
CREATE TABLE Owners (
    OwnerId INT PRIMARY KEY IDENTITY(1,1),  
    Name NVARCHAR(100) NOT NULL,             
    Address NVARCHAR(255) NOT NULL,          
    Photo NVARCHAR(255),                     
    Birthday DATE NOT NULL                   
);
GO

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único del dueño', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Owners, 
    @level2type = N'COLUMN', @level2name = OwnerId;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Nombre completo del dueño', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Owners, 
    @level2type = N'COLUMN', @level2name = Name;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Dirección física del dueño', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Owners, 
    @level2type = N'COLUMN', @level2name = Address;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Ruta o nombre del archivo de la foto del dueño', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Owners, 
    @level2type = N'COLUMN', @level2name = Photo;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Fecha de nacimiento del dueño', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Owners, 
    @level2type = N'COLUMN', @level2name = Birthday;
GO

-- Tabla Properties
CREATE TABLE Properties (
    PropertyId INT PRIMARY KEY IDENTITY(1,1), 
    Name NVARCHAR(255) NOT NULL,               
    Address NVARCHAR(255) NOT NULL,            
    Price DECIMAL(18,2) NOT NULL,              
    CodeInternal NVARCHAR(50) NOT NULL,        
    Year INT NOT NULL,                         
    OwnerId INT,                                
    CONSTRAINT FK_Property_Owner FOREIGN KEY (OwnerId) REFERENCES Owners(OwnerId)
);
GO

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Properties, 
    @level2type = N'COLUMN', @level2name = PropertyId;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Nombre de la propiedad (ej. Casa en venta)', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Properties, 
    @level2type = N'COLUMN', @level2name = Name;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Dirección física de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Properties, 
    @level2type = N'COLUMN', @level2name = Address;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Precio de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Properties, 
    @level2type = N'COLUMN', @level2name = Price;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Código interno de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Properties, 
    @level2type = N'COLUMN', @level2name = CodeInternal;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Año de construcción de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Properties, 
    @level2type = N'COLUMN', @level2name = Year;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Id del dueño de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = Properties, 
    @level2type = N'COLUMN', @level2name = OwnerId;
GO

CREATE INDEX IDX_Property_Name ON Properties (Name);
CREATE INDEX IDX_Property_Year ON Properties (Year);
GO

-- Tabla PropertyImages
CREATE TABLE PropertyImages (
    PropertyImageId INT PRIMARY KEY IDENTITY(1,1),   
    PropertyId INT,                                 
    Url NVARCHAR(255) NOT NULL,                     
    Enabled BIT NOT NULL,                           
    CONSTRAINT FK_PropertyImage_Property FOREIGN KEY (PropertyId) REFERENCES Properties(PropertyId)
);
GO

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único de la imagen de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = PropertyImages, 
    @level2type = N'COLUMN', @level2name = PropertyImageId;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Id de la propiedad a la que pertenece la imagen', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = PropertyImages, 
    @level2type = N'COLUMN', @level2name = PropertyId;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Archivo de imagen de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = PropertyImages, 
    @level2type = N'COLUMN', @level2name = Url;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Indicador de si la imagen está habilitada o no', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = PropertyImages, 
    @level2type = N'COLUMN', @level2name = Enabled;
GO

-- Tabla PropertyTraces
CREATE TABLE PropertyTraces (
    PropertyTraceId INT PRIMARY KEY IDENTITY(1,1),    
    DateSale DATE,                                   
    Name NVARCHAR(255) NOT NULL,                      
    Value DECIMAL(18,2),     
    Tax DECIMAL(18,2) NOT NULL,    
    PropertyId INT,                                  
    CONSTRAINT FK_PropertyTrace_Property FOREIGN KEY (PropertyId) REFERENCES Properties(PropertyId)
);
GO

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único del registro de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = PropertyTraces, 
    @level2type = N'COLUMN', @level2name = PropertyTraceId;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Fecha de la venta de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = PropertyTraces, 
    @level2type = N'COLUMN', @level2name = DateSale;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Nombre del comprador o entidad asociada con la venta', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = PropertyTraces, 
    @level2type = N'COLUMN', @level2name = Name;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Valor de la venta de la propiedad', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE', @level1name = PropertyTraces, 
    @level2type = N'COLUMN', @level2name = Value;
GO
