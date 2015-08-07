# medsys
medsys includes several projects
1. sqlcon manages multiple SQL Servers in different machines. 
  a. compare schema, data
  b. support all SQL clauses
  examples:
  \local\Northwind> dir
  [1]             dbo.Categories                            <TABLE>
  [2]             dbo.CustomerCustomerDemo                  <TABLE>
  [3]             dbo.CustomerDemographics                  <TABLE>
  [4]             dbo.Customers                             <TABLE>
  [5]             dbo.Employees                             <TABLE>
  [6]             dbo.EmployeeTerritories                   <TABLE>
  [7]             dbo.Order Details                         <TABLE>
  [8]             dbo.Orders                                <TABLE>
  [9]             dbo.Products                              <TABLE>
 [10]             dbo.Region                                <TABLE>
 [11]             dbo.Shippers                              <TABLE>
 [12]             dbo.Suppliers                             <TABLE>
 [13]             dbo.Territories                           <TABLE>
 [14]             dbo.Alphabetical list of products         <VIEW>
 [15]             dbo.Category Sales for 1997               <VIEW>
 [16]             dbo.Current Product List                  <VIEW>
 [17]             dbo.Customer and Suppliers by City        <VIEW>
 [18]             dbo.Invoices                              <VIEW>
 [19]             dbo.Order Details Extended                <VIEW>
 [20]             dbo.Order Subtotals                       <VIEW>
 [21]             dbo.Orders Qry                            <VIEW>
 [22]             dbo.Product Sales for 1997                <VIEW>
 [23]             dbo.Products Above Average Price          <VIEW>
 [24]             dbo.Products by Category                  <VIEW>
 [25]             dbo.Quarterly Orders                      <VIEW>
 [26]             dbo.Sales by Category                     <VIEW>
 [27]             dbo.Sales Totals by Amount                <VIEW>
 [28]             dbo.Summary of Sales by Quarter           <VIEW>
 [29]             dbo.Summary of Sales by Year              <VIEW>
	13 Table(s)
	16 View(s)

\local\Northwind> type products
+-----------+----------------------------------+------------+------------+----------------------+-----------+--------------+--------------+--------------+--------------+
| ProductID | ProductName                      | SupplierID | CategoryID | QuantityPerUnit      | UnitPrice | UnitsInStock | UnitsOnOrder | ReorderLevel | Discontinued |
+-----------+----------------------------------+------------+------------+----------------------+-----------+--------------+--------------+--------------+--------------+
| 1         | Chai                             | 1          | 1          | 10 boxes x 20 bags   | 18.0000   | 39           | 0            | 10           | False        |
| 2         | Chang                            | 1          | 1          | 24 - 12 oz bottles   | 19.0000   | 17           | 40           | 25           | False        |
| 3         | Aniseed Syrup                    | 1          | 2          | 12 - 550 ml bottles  | 10.0000   | 13           | 70           | 25           | False        |
| 4         | Chef Anton's Cajun Seasoning     | 2          | 2          | 48 - 6 oz jars       | 22.0000   | 53           | 0            | 0            | False        |
| 5         | Chef Anton's Gumbo Mix           | 2          | 2          | 36 boxes             | 21.3500   | 0            | 0            | 0            | True         |
| 6         | Grandma's Boysenberry Spread     | 3          | 2          | 12 - 8 oz jars       | 25.0000   | 120          | 0            | 25           | False        |
| 7         | Uncle Bob's Organic Dried Pears  | 3          | 7          | 12 - 1 lb pkgs.      | 30.0000   | 15           | 0            | 10           | False        |
| 8         | Northwoods Cranberry Sauce       | 3          | 2          | 12 - 12 oz jars      | 40.0000   | 6            | 0            | 0            | False        |
| 9         | Mishi Kobe Niku                  | 4          | 6          | 18 - 500 g pkgs.     | 97.0000   | 29           | 0            | 0            | True         |
| 10        | Ikura                            | 4          | 8          | 12 - 200 ml jars     | 31.0000   | 31           | 0            | 0            | False        |
| 11        | Queso Cabrales                   | 5          | 4          | 1 kg pkg.            | 21.0000   | 22           | 30           | 30           | False        |
| 12        | Queso Manchego La Pastora        | 5          | 4          | 10 - 500 g pkgs.     | 38.0000   | 86           | 0            | 0            | False        |
| 13        | Konbu                            | 6          | 8          | 2 kg box             | 6.0000    | 24           | 0            | 5            | False        |
| 14        | Tofu                             | 6          | 7          | 40 - 100 g pkgs.     | 23.2500   | 35           | 0            | 0            | False        |
| 15        | Genen Shouyu                     | 6          | 2          | 24 - 250 ml bottles  | 15.5000   | 39           | 0            | 5            | False        |
| 16        | Pavlova                          | 7          | 3          | 32 - 500 g boxes     | 17.4500   | 29           | 0            | 10           | False        |
| 17        | Alice Mutton                     | 7          | 6          | 20 - 1 kg tins       | 39.0000   | 0            | 0            | 0            | True         |
| 18        | Carnarvon Tigers                 | 7          | 8          | 16 kg pkg.           | 62.5000   | 42           | 0            | 0            | False        |
| 19        | Teatime Chocolate Biscuits       | 8          | 3          | 10 boxes x 12 pieces | 9.2000    | 25           | 0            | 5            | False        |
| 20        | Sir Rodney's Marmalade           | 8          | 3          | 30 gift boxes        | 81.0000   | 40           | 0            | 0            | False        |
| 21        | Sir Rodney's Scones              | 8          | 3          | 24 pkgs. x 4 pieces  | 10.0000   | 3            | 40           | 5            | False        |
| 22        | Gustaf's Knäckebröd              | 9          | 5          | 24 - 500 g pkgs.     | 21.0000   | 104          | 0            | 25           | False        |
| 23        | Tunnbröd                         | 9          | 5          | 12 - 250 g pkgs.     | 9.0000    | 61           | 0            | 25           | False        |
| 24        | Guaraná Fantástica               | 10         | 1          | 12 - 355 ml cans     | 4.5000    | 20           | 0            | 0            | True         |
| 25        | NuNuCa Nuß-Nougat-Creme          | 11         | 3          | 20 - 450 g glasses   | 14.0000   | 76           | 0            | 30           | False        |
| 26        | Gumbär Gummibärchen              | 11         | 3          | 100 - 250 g bags     | 31.2300   | 15           | 0            | 0            | False        |
| 27        | Schoggi Schokolade               | 11         | 3          | 100 - 100 g pieces   | 43.9000   | 49           | 0            | 30           | False        |
| 28        | Rössle Sauerkraut                | 12         | 7          | 25 - 825 g cans      | 45.6000   | 26           | 0            | 0            | True         |
| 29        | Thüringer Rostbratwurst          | 12         | 6          | 50 bags x 30 sausgs. | 123.7900  | 0            | 0            | 0            | True         |
| 30        | Nord-Ost Matjeshering            | 13         | 8          | 10 - 200 g glasses   | 25.8900   | 10           | 0            | 15           | False        |
| 31        | Gorgonzola Telino                | 14         | 4          | 12 - 100 g pkgs      | 12.5000   | 0            | 70           | 20           | False        |
| 32        | Mascarpone Fabioli               | 14         | 4          | 24 - 200 g pkgs.     | 32.0000   | 9            | 40           | 25           | False        |
| 33        | Geitost                          | 15         | 4          | 500 g                | 2.5000    | 112          | 0            | 20           | False        |
| 34        | Sasquatch Ale                    | 16         | 1          | 24 - 12 oz bottles   | 14.0000   | 111          | 0            | 15           | False        |
| 35        | Steeleye Stout                   | 16         | 1          | 24 - 12 oz bottles   | 18.0000   | 20           | 0            | 15           | False        |
| 36        | Inlagd Sill                      | 17         | 8          | 24 - 250 g  jars     | 19.0000   | 112          | 0            | 20           | False        |
| 37        | Gravad lax                       | 17         | 8          | 12 - 500 g pkgs.     | 26.0000   | 11           | 50           | 25           | False        |
| 38        | Côte de Blaye                    | 18         | 1          | 12 - 75 cl bottles   | 263.5000  | 17           | 0            | 15           | False        |
| 39        | Chartreuse verte                 | 18         | 1          | 750 cc per bottle    | 18.0000   | 69           | 0            | 5            | False        |
| 40        | Boston Crab Meat                 | 19         | 8          | 24 - 4 oz tins       | 18.4000   | 123          | 0            | 30           | False        |
| 41        | Jack's New England Clam Chowder  | 19         | 8          | 12 - 12 oz cans      | 9.6500    | 85           | 0            | 10           | False        |
| 42        | Singaporean Hokkien Fried Mee    | 20         | 5          | 32 - 1 kg pkgs.      | 14.0000   | 26           | 0            | 0            | True         |
| 43        | Ipoh Coffee                      | 20         | 1          | 16 - 500 g tins      | 46.0000   | 17           | 10           | 25           | False        |
| 44        | Gula Malacca                     | 20         | 2          | 20 - 2 kg bags       | 19.4500   | 27           | 0            | 15           | False        |
| 45        | Rogede sild                      | 21         | 8          | 1k pkg.              | 9.5000    | 5            | 70           | 15           | False        |
| 46        | Spegesild                        | 21         | 8          | 4 - 450 g glasses    | 12.0000   | 95           | 0            | 0            | False        |
| 47        | Zaanse koeken                    | 22         | 3          | 10 - 4 oz boxes      | 9.5000    | 36           | 0            | 0            | False        |
| 48        | Chocolade                        | 22         | 3          | 10 pkgs.             | 12.7500   | 15           | 70           | 25           | False        |
| 49        | Maxilaku                         | 23         | 3          | 24 - 50 g pkgs.      | 20.0000   | 10           | 60           | 15           | False        |
| 50        | Valkoinen suklaa                 | 23         | 3          | 12 - 100 g bars      | 16.2500   | 65           | 0            | 30           | False        |
| 51        | Manjimup Dried Apples            | 24         | 7          | 50 - 300 g pkgs.     | 53.0000   | 20           | 0            | 10           | False        |
| 52        | Filo Mix                         | 24         | 5          | 16 - 2 kg boxes      | 7.0000    | 38           | 0            | 25           | False        |
| 53        | Perth Pasties                    | 24         | 6          | 48 pieces            | 32.8000   | 0            | 0            | 0            | True         |
| 54        | Tourtière                        | 25         | 6          | 16 pies              | 7.4500    | 21           | 0            | 10           | False        |
| 55        | Pâté chinois                     | 25         | 6          | 24 boxes x 2 pies    | 24.0000   | 115          | 0            | 20           | False        |
| 56        | Gnocchi di nonna Alice           | 26         | 5          | 24 - 250 g pkgs.     | 38.0000   | 21           | 10           | 30           | False        |
| 57        | Ravioli Angelo                   | 26         | 5          | 24 - 250 g pkgs.     | 19.5000   | 36           | 0            | 20           | False        |
| 58        | Escargots de Bourgogne           | 27         | 8          | 24 pieces            | 13.2500   | 62           | 0            | 20           | False        |
| 59        | Raclette Courdavault             | 28         | 4          | 5 kg pkg.            | 55.0000   | 79           | 0            | 0            | False        |
| 60        | Camembert Pierrot                | 28         | 4          | 15 - 300 g rounds    | 34.0000   | 19           | 0            | 0            | False        |
| 61        | Sirop d'érable                   | 29         | 2          | 24 - 500 ml bottles  | 28.5000   | 113          | 0            | 25           | False        |
| 62        | Tarte au sucre                   | 29         | 3          | 48 pies              | 49.3000   | 17           | 0            | 0            | False        |
| 63        | Vegie-spread                     | 7          | 2          | 15 - 625 g jars      | 43.9000   | 24           | 0            | 5            | False        |
| 64        | Wimmers gute Semmelknödel        | 12         | 5          | 20 bags x 4 pieces   | 33.2500   | 22           | 80           | 30           | False        |
| 65        | Louisiana Fiery Hot Pepper Sauce | 2          | 2          | 32 - 8 oz bottles    | 21.0500   | 76           | 0            | 0            | False        |
| 66        | Louisiana Hot Spiced Okra        | 2          | 2          | 24 - 8 oz jars       | 17.0000   | 4            | 100          | 20           | False        |
| 67        | Laughing Lumberjack Lager        | 16         | 1          | 24 - 12 oz bottles   | 14.0000   | 52           | 0            | 10           | False        |
| 68        | Scottish Longbreads              | 8          | 3          | 10 boxes x 8 pieces  | 12.5000   | 6            | 10           | 15           | False        |
| 69        | Gudbrandsdalsost                 | 15         | 4          | 10 kg pkg.           | 36.0000   | 26           | 0            | 15           | False        |
| 70        | Outback Lager                    | 7          | 1          | 24 - 355 ml bottles  | 15.0000   | 15           | 10           | 30           | False        |
| 71        | Flotemysost                      | 15         | 4          | 10 - 500 g pkgs.     | 21.5000   | 26           | 0            | 0            | False        |
| 72        | Mozzarella di Giovanni           | 14         | 4          | 24 - 200 g pkgs.     | 34.8000   | 14           | 0            | 0            | False        |
| 73        | Röd Kaviar                       | 17         | 8          | 24 - 150 g jars      | 15.0000   | 101          | 0            | 5            | False        |
| 74        | Longlife Tofu                    | 4          | 7          | 5 kg pkg.            | 10.0000   | 4            | 20           | 5            | False        |
| 75        | Rhönbräu Klosterbier             | 12         | 1          | 24 - 0.5 l bottles   | 7.7500    | 125          | 0            | 25           | False        |
| 76        | Lakkalikööri                     | 23         | 1          | 500 ml               | 18.0000   | 57           | 0            | 20           | False        |
| 77        | Original Frankfurter grüne Soße  | 12         | 2          | 12 boxes             | 13.0000   | 32           | 0            | 15           | False        |
+-----------+----------------------------------+------------+------------+----------------------+-----------+--------------+--------------+--------------+--------------+
<77 rows>

\local\Northwind> cd orders

\local\Northwind\dbo.Orders> dir /def
TABLE: dbo.Orders
  [1]                  [OrderID] int                   ++,pk   not null
  [2]               [CustomerID] nchar(5)                 fk       null
  [3]               [EmployeeID] int                      fk       null
  [4]                [OrderDate] datetime                          null
  [5]             [RequiredDate] datetime                          null
  [6]              [ShippedDate] datetime                          null
  [7]                  [ShipVia] int                      fk       null
  [8]                  [Freight] money                             null
  [9]                 [ShipName] nvarchar(40)                      null
 [10]              [ShipAddress] nvarchar(60)                      null
 [11]                 [ShipCity] nvarchar(15)                      null
 [12]               [ShipRegion] nvarchar(15)                      null
 [13]           [ShipPostalCode] nvarchar(10)                      null
 [14]              [ShipCountry] nvarchar(15)                      null
	14 Column(s)

\local\Northwind\dbo.Orders> type /top:10
+---------+------------+------------+-----------------------+-----------------------+-----------------------+---------+----------+---------------------------+--------------------------------------------+----------------+------------+----------------+-------------+
| OrderID | CustomerID | EmployeeID | OrderDate             | RequiredDate          | ShippedDate           | ShipVia | Freight  | ShipName                  | ShipAddress                                | ShipCity       | ShipRegion | ShipPostalCode | ShipCountry |
+---------+------------+------------+-----------------------+-----------------------+-----------------------+---------+----------+---------------------------+--------------------------------------------+----------------+------------+----------------+-------------+
| 10248   | VINET      | 5          | 7/4/1996 12:00:00 AM  | 8/1/1996 12:00:00 AM  | 7/16/1996 12:00:00 AM | 3       | 32.3800  | Vins et alcools Chevalier | 59 rue de l'Abbaye                         | Reims          | NULL       | 51100          | France      |
| 10249   | TOMSP      | 6          | 7/5/1996 12:00:00 AM  | 8/16/1996 12:00:00 AM | 7/10/1996 12:00:00 AM | 1       | 11.6100  | Toms Spezialitäten        | Luisenstr. 48                              | Münster        | NULL       | 44087          | Germany     |
| 10250   | HANAR      | 4          | 7/8/1996 12:00:00 AM  | 8/5/1996 12:00:00 AM  | 7/12/1996 12:00:00 AM | 2       | 65.8300  | Hanari Carnes             | Rua do Paço, 67                            | Rio de Janeiro | RJ         | 05454-876      | Brazil      |
| 10251   | VICTE      | 3          | 7/8/1996 12:00:00 AM  | 8/5/1996 12:00:00 AM  | 7/15/1996 12:00:00 AM | 1       | 41.3400  | Victuailles en stock      | 2, rue du Commerce                         | Lyon           | NULL       | 69004          | France      |
| 10252   | SUPRD      | 4          | 7/9/1996 12:00:00 AM  | 8/6/1996 12:00:00 AM  | 7/11/1996 12:00:00 AM | 2       | 51.3000  | Suprêmes délices          | Boulevard Tirou, 255                       | Charleroi      | NULL       | B-6000         | Belgium     |
| 10253   | HANAR      | 3          | 7/10/1996 12:00:00 AM | 7/24/1996 12:00:00 AM | 7/16/1996 12:00:00 AM | 2       | 58.1700  | Hanari Carnes             | Rua do Paço, 67                            | Rio de Janeiro | RJ         | 05454-876      | Brazil      |
| 10254   | CHOPS      | 5          | 7/11/1996 12:00:00 AM | 8/8/1996 12:00:00 AM  | 7/23/1996 12:00:00 AM | 2       | 22.9800  | Chop-suey Chinese         | Hauptstr. 31                               | Bern           | NULL       | 3012           | Switzerland |
| 10255   | RICSU      | 9          | 7/12/1996 12:00:00 AM | 8/9/1996 12:00:00 AM  | 7/15/1996 12:00:00 AM | 3       | 148.3300 | Richter Supermarkt        | Starenweg 5                                | Genève         | NULL       | 1204           | Switzerland |
| 10256   | WELLI      | 3          | 7/15/1996 12:00:00 AM | 8/12/1996 12:00:00 AM | 7/17/1996 12:00:00 AM | 2       | 13.9700  | Wellington Importadora    | Rua do Mercado, 12                         | Resende        | SP         | 08737-363      | Brazil      |
| 10257   | HILAA      | 4          | 7/16/1996 12:00:00 AM | 8/13/1996 12:00:00 AM | 7/22/1996 12:00:00 AM | 3       | 81.9100  | HILARION-Abastos          | Carrera 22 con Ave. Carlos Soublette #8-35 | San Cristóbal  | Táchira    | 5022           | Venezuela   |
+---------+------------+------------+-----------------------+-----------------------+-----------------------+---------+----------+---------------------------+--------------------------------------------+----------------+------------+----------------+-------------+
<top 10 rows>

\local\Northwind\dbo.Orders> cd ..\products

\local\Northwind\dbo.Products> cd ..\products

\local\Northwind\dbo.Products> type productid=1
+-----------+-------------+------------+------------+--------------------+-----------+--------------+--------------+--------------+--------------+
| ProductID | ProductName | SupplierID | CategoryID | QuantityPerUnit    | UnitPrice | UnitsInStock | UnitsOnOrder | ReorderLevel | Discontinued |
+-----------+-------------+------------+------------+--------------------+-----------+--------------+--------------+--------------+--------------+
| 1         | Chai        | 1          | 1          | 10 boxes x 20 bags | 18.0000   | 39           | 0            | 10           | False        |
+-----------+-------------+------------+------------+--------------------+-----------+--------------+--------------+--------------+--------------+
<1 row>

\local\Northwind\dbo.Products> type productid=1 /t
+-----------------+--------------------+
| ProductID       | 1                  |
| ProductName     | Chai               |
| SupplierID      | 1                  |
| CategoryID      | 1                  |
| QuantityPerUnit | 10 boxes x 20 bags |
| UnitPrice       | 18.0000            |
| UnitsInStock    | 39                 |
| UnitsOnOrder    | 0                  |
| ReorderLevel    | 10                 |
| Discontinued    | False              |
+-----------------+--------------------+
<1 row>

\local\Northwind\dbo.Products> dir \
 [1]                      local <SVR>          8 Databases
 [2]                        xml <SVR>          ? Databases
 [3]                     medsys <SVR>          8 Databases
	3 Server(s)

\local\Northwind\dbo.Products> md productid=1

\local\Northwind\dbo.Products> dir
  [1] productid=1
	1 Item(s)

\local\Northwind\dbo.Products> cd 1

\local\Northwind\dbo.Products\productid=1> dir
	0 Item(s)

\local\Northwind\dbo.Products\productid=1> type /t
+-----------------+--------------------+
| ProductID       | 1                  |
| ProductName     | Chai               |
| SupplierID      | 1                  |
| CategoryID      | 1                  |
| QuantityPerUnit | 10 boxes x 20 bags |
| UnitPrice       | 18.0000            |
| UnitsInStock    | 39                 |
| UnitsOnOrder    | 0                  |
| ReorderLevel    | 10                 |
| Discontinued    | False              |
+-----------------+--------------------+
<1 row>

\local\Northwind\dbo.Products\productid=1> set unitprice=19
1 of row(s) affected

\local\Northwind\dbo.Products\productid=1> type /t
+-----------------+--------------------+
| ProductID       | 1                  |
| ProductName     | Chai               |
| SupplierID      | 1                  |
| CategoryID      | 1                  |
| QuantityPerUnit | 10 boxes x 20 bags |
| UnitPrice       | 19.0000            |
| UnitsInStock    | 39                 |
| UnitsOnOrder    | 0                  |
| ReorderLevel    | 10                 |
| Discontinued    | False              |
+-----------------+--------------------+
<1 row>
