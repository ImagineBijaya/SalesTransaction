USE master;
GO

CREATE DATABASE Sales ON
(NAME = Sales_dat,
    FILENAME = 'Z:\Database\SalesTransaction\saledat.mdf',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5)
LOG ON
(NAME = Sales_log,
    FILENAME = 'Z:\DataBase\SalesTransaction\salelog.ldf',
    SIZE = 5 MB,
    MAXSIZE = 25 MB,
    FILEGROWTH = 5 MB);
GO


CREATE TABLE [Sales].[dbo].[Customer]
 (
   CustomerId INT IDENTITY(0,1) NOT NULL,
   CustomerName NVARCHAR(256) NOT NULL,
   CustomerAddress NVARCHAR(256) NOT NULL,
   PhoneNumber NVARCHAR(256) NOT NULL
   CONSTRAINT [PK_Customer_CustomerId] PRIMARY KEY CLUSTERED  (CustomerId ASC)
 )
 
 CREATE TABLE [Sales].[dbo].[Product]
 (
 ProductId INT IDENTITY(0,1) NOT NULL,
 ProductName NVARCHAR(256) NOT NULL,
 ProductUnit NVARCHAR(256) NOT NULL,
 ProductPrice FLOAT NOT NULL
 CONSTRAINT [PK_Product_ProductId] PRIMARY KEY CLUSTERED (ProductId ASC)
 )

 CREATE TABLE [Sales].[dbo].[SalesTransaction]
 (
 SalesTransactionId INT IDENTITY(0,1) NOT NULL,
 CustomerId INT NOT NULL,
 ProductId INT NOT NULL,
 Quantity FLOAT NOT NULL,
 Amount FLOAT NOT NULL,
 Invoice  BIT ,
 TransactionDate DATETIME NOT NULL,
 CONSTRAINT  [PK_SalesTransaction_SalesTransactionId] PRIMARY KEY CLUSTERED (SalesTransactionId ASC),
 CONSTRAINT  [FK_SalesTransaction_ProductId] FOREIGN KEY (ProductId) REFERENCES [dbo].[Product](ProductId),
 CONSTRAINT  [FK_SalesTransaction_CustomerId] FOREIGN KEY (CustomerId) REFERENCES [dbo].[Customer](CustomerId)
 )
 

 USE Sales
 GO
CREATE PROCEDURE [dbo].[sp_CustomerOperation] (
										  @id             INT,
                                          @name           NVARCHAR(256),
                                          @address		  NVARCHAR(256),
                                          @phone		  NVARCHAR(256),
                                          @statementType  NVARCHAR(20) = '')
AS
  BEGIN
      IF @statementType = 'Insert'
        BEGIN
            INSERT INTO Customer
                        ( CustomerName,
                         CustomerAddress,
                         PhoneNumber
                         )
            VALUES     ( @name,
                         @address,
                         @phone
                       )
        END

      IF @statementType = 'Select'
        BEGIN
		IF @id IS NOT NULL
		    BEGIN
              SELECT *
              FROM   Customer WHERE CustomerId =@id
			END
		ELSE
		    BEGIN
			SELECT * 
			FROM Customer
			END
        END

      IF @statementType = 'Update'
        BEGIN
            UPDATE Customer
            SET    CustomerName = @name,
                   CustomerAddress = @address,
                   PhoneNumber = @phone
            WHERE  CustomerId = @id
        END
      ELSE IF @statementType = 'Delete'
        BEGIN
            DELETE FROM Customer
            WHERE  CustomerId = @id
        END
  END
  GO
  USE Sales
  GO
  CREATE PROCEDURE [dbo].[sp_ProductOperation] (
										  @id             INT,
                                          @name           NVARCHAR(256),
                                          @unit		      NVARCHAR(256),
                                          @price		  FLOAT,
                                          @statementType  NVARCHAR(20) = '')
AS
  BEGIN
      IF @statementType = 'Insert'
        BEGIN
            INSERT INTO Product
                        ( ProductName,
                        ProductUnit ,
						ProductPrice)
            VALUES     ( @name,
                         @unit,
                         @price
                       )
        END

      IF @statementType = 'Select'
        BEGIN
		IF @id IS NOT NULL
		    BEGIN
              SELECT *
              FROM   Product WHERE ProductId =@id
			END
		ELSE
		    BEGIN
			SELECT * 
			FROM Product
			END
        END

      IF @statementType = 'Update'
        BEGIN
            UPDATE Product
            SET    ProductName = @name,
                   ProductPrice = @price,
                   ProductUnit = @unit
            WHERE  ProductId = @id
        END
      ELSE IF @statementType = 'Delete'
        BEGIN
            DELETE FROM Product
            WHERE  ProductId = @id
        END
  END
  

  GO
    USE Sales
  GO
 
  CREATE PROCEDURE [dbo].[sp_SalesTransactionOperation] (
										  @id             INT,
                                          @customerId     INT,
                                          @productId		 INT,
                                          @quantity		  FLOAT,
										  @amount        FLOAT,
										  @invoice      BIT,
										  @transactionDate DateTime,
                                          @statementType NVARCHAR(20) = '')
AS
  BEGIN
      IF @statementType = 'Insert'
        BEGIN
            INSERT INTO SalesTransaction
                        ( CustomerId,
                        ProductId,
						Quantity,
						Amount,
						Invoice,
						TransactionDate)
            VALUES     ( @customerId,
						@productId,
						@quantity,
                        @amount,
                        @invoice,
						@transactionDate
                       )
        END

      IF @statementType = 'Select'
        BEGIN
		IF @id IS NOT NULL
		    BEGIN
              SELECT *
              FROM		SalesTransaction WHERE SalesTransactionId =@id
			END
		ELSE
		    BEGIN
			SELECT * 
			FROM SalesTransaction
			END
        END

      IF @statementType = 'Update'
        BEGIN
            UPDATE SalesTransaction
            SET    ProductId = @productId,
                   CustomerId = @customerId,
                   Quantity = @quantity,
				   Amount= @amount,
				   Invoice = @invoice,
				   TransactionDate =@transactionDate
            WHERE  SalesTransactionId = @id
        END
      ELSE IF @statementType = 'Delete'
        BEGIN
            DELETE FROM SalesTransaction
            WHERE  SalesTransactionId = @id
        END
  END
  

  
   
  GO