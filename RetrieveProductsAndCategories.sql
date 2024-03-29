/*
    Product:
        - ProductId - int - Primary Key
        - ProductName - nvarchar(100)

    Category:
        - CategoryId - int - Primary Key
        - CategoryName - nvarchar(100)

    ProductCategoryAssign:
        - ProductId - int - Foreign Key (Product)
        - CategoryId - int - Foreign Key (Category)
*/

SELECT
	[p].ProductName,
	[c].CategoryName
FROM Product [p]
LEFT JOIN ProductCategoryAssign [pca] 
    ON [pca].ProductId = [p].ProductId
LEFT JOIN Category [c]
    ON [c].CategoryId = [pca].CategoryId