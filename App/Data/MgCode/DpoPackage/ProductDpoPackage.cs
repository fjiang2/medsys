//
// Machine Packed Data
//   by devel at 7/19/2012 12:14:08 AM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using App.Data.DpoClass;

namespace App.Data.DpoPackage
{
	public class ProductDpoPackage : BasePackage<ProductDpo>
	{

		public ProductDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new ProductDpo();
			dpo.ProductID = 1;
			dpo.ProductName = "Chai";
			dpo.SupplierID = 1;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "10 boxes x 20 bags";
			dpo.UnitPrice = 18.0000M;
			dpo.UnitsInStock = 39;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 10;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 2;
			dpo.ProductName = "Chang";
			dpo.SupplierID = 1;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "24 - 12 oz bottles";
			dpo.UnitPrice = 19.0000M;
			dpo.UnitsInStock = 17;
			dpo.UnitsOnOrder = 40;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 3;
			dpo.ProductName = "Aniseed Syrup";
			dpo.SupplierID = 1;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "12 - 550 ml bottles";
			dpo.UnitPrice = 10.0000M;
			dpo.UnitsInStock = 13;
			dpo.UnitsOnOrder = 70;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 4;
			dpo.ProductName = "Chef Anton's Cajun Seasoning";
			dpo.SupplierID = 2;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "48 - 6 oz jars";
			dpo.UnitPrice = 22.0000M;
			dpo.UnitsInStock = 53;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 5;
			dpo.ProductName = "Chef Anton's Gumbo Mix";
			dpo.SupplierID = 2;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "36 boxes";
			dpo.UnitPrice = 21.3500M;
			dpo.UnitsInStock = 0;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = true;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 6;
			dpo.ProductName = "Grandma's Boysenberry Spread";
			dpo.SupplierID = 3;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "12 - 8 oz jars";
			dpo.UnitPrice = 25.0000M;
			dpo.UnitsInStock = 120;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 7;
			dpo.ProductName = "Uncle Bob's Organic Dried Pears";
			dpo.SupplierID = 3;
			dpo.CategoryID = 7;
			dpo.QuantityPerUnit = "12 - 1 lb pkgs.";
			dpo.UnitPrice = 30.0000M;
			dpo.UnitsInStock = 15;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 10;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 8;
			dpo.ProductName = "Northwoods Cranberry Sauce";
			dpo.SupplierID = 3;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "12 - 12 oz jars";
			dpo.UnitPrice = 40.0000M;
			dpo.UnitsInStock = 6;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 9;
			dpo.ProductName = "Mishi Kobe Niku";
			dpo.SupplierID = 4;
			dpo.CategoryID = 6;
			dpo.QuantityPerUnit = "18 - 500 g pkgs.";
			dpo.UnitPrice = 97.0000M;
			dpo.UnitsInStock = 29;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = true;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 10;
			dpo.ProductName = "Ikura";
			dpo.SupplierID = 4;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "12 - 200 ml jars";
			dpo.UnitPrice = 31.0000M;
			dpo.UnitsInStock = 31;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 11;
			dpo.ProductName = "Queso Cabrales";
			dpo.SupplierID = 5;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "1 kg pkg.";
			dpo.UnitPrice = 21.0000M;
			dpo.UnitsInStock = 22;
			dpo.UnitsOnOrder = 30;
			dpo.ReorderLevel = 30;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 12;
			dpo.ProductName = "Queso Manchego La Pastora";
			dpo.SupplierID = 5;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "10 - 500 g pkgs.";
			dpo.UnitPrice = 38.0000M;
			dpo.UnitsInStock = 86;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 13;
			dpo.ProductName = "Konbu";
			dpo.SupplierID = 6;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "2 kg box";
			dpo.UnitPrice = 6.0000M;
			dpo.UnitsInStock = 24;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 5;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 14;
			dpo.ProductName = "Tofu";
			dpo.SupplierID = 6;
			dpo.CategoryID = 7;
			dpo.QuantityPerUnit = "40 - 100 g pkgs.";
			dpo.UnitPrice = 23.2500M;
			dpo.UnitsInStock = 35;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 15;
			dpo.ProductName = "Genen Shouyu";
			dpo.SupplierID = 6;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "24 - 250 ml bottles";
			dpo.UnitPrice = 15.5000M;
			dpo.UnitsInStock = 39;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 5;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 16;
			dpo.ProductName = "Pavlova";
			dpo.SupplierID = 7;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "32 - 500 g boxes";
			dpo.UnitPrice = 17.4500M;
			dpo.UnitsInStock = 29;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 10;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 17;
			dpo.ProductName = "Alice Mutton";
			dpo.SupplierID = 7;
			dpo.CategoryID = 6;
			dpo.QuantityPerUnit = "20 - 1 kg tins";
			dpo.UnitPrice = 39.0000M;
			dpo.UnitsInStock = 0;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = true;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 18;
			dpo.ProductName = "Carnarvon Tigers";
			dpo.SupplierID = 7;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "16 kg pkg.";
			dpo.UnitPrice = 62.5000M;
			dpo.UnitsInStock = 42;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 19;
			dpo.ProductName = "Teatime Chocolate Biscuits";
			dpo.SupplierID = 8;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "10 boxes x 12 pieces";
			dpo.UnitPrice = 9.2000M;
			dpo.UnitsInStock = 25;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 5;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 20;
			dpo.ProductName = "Sir Rodney's Marmalade";
			dpo.SupplierID = 8;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "30 gift boxes";
			dpo.UnitPrice = 81.0000M;
			dpo.UnitsInStock = 40;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 21;
			dpo.ProductName = "Sir Rodney's Scones";
			dpo.SupplierID = 8;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "24 pkgs. x 4 pieces";
			dpo.UnitPrice = 10.0000M;
			dpo.UnitsInStock = 3;
			dpo.UnitsOnOrder = 40;
			dpo.ReorderLevel = 5;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 22;
			dpo.ProductName = "Gustaf's Knäckebröd";
			dpo.SupplierID = 9;
			dpo.CategoryID = 5;
			dpo.QuantityPerUnit = "24 - 500 g pkgs.";
			dpo.UnitPrice = 21.0000M;
			dpo.UnitsInStock = 104;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 23;
			dpo.ProductName = "Tunnbröd";
			dpo.SupplierID = 9;
			dpo.CategoryID = 5;
			dpo.QuantityPerUnit = "12 - 250 g pkgs.";
			dpo.UnitPrice = 9.0000M;
			dpo.UnitsInStock = 61;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 24;
			dpo.ProductName = "Guaraná Fantástica";
			dpo.SupplierID = 10;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "12 - 355 ml cans";
			dpo.UnitPrice = 4.5000M;
			dpo.UnitsInStock = 20;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = true;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 25;
			dpo.ProductName = "NuNuCa Nuß-Nougat-Creme";
			dpo.SupplierID = 11;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "20 - 450 g glasses";
			dpo.UnitPrice = 14.0000M;
			dpo.UnitsInStock = 76;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 30;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 26;
			dpo.ProductName = "Gumbär Gummibärchen";
			dpo.SupplierID = 11;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "100 - 250 g bags";
			dpo.UnitPrice = 31.2300M;
			dpo.UnitsInStock = 15;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 27;
			dpo.ProductName = "Schoggi Schokolade";
			dpo.SupplierID = 11;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "100 - 100 g pieces";
			dpo.UnitPrice = 43.9000M;
			dpo.UnitsInStock = 49;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 30;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 28;
			dpo.ProductName = "Rössle Sauerkraut";
			dpo.SupplierID = 12;
			dpo.CategoryID = 7;
			dpo.QuantityPerUnit = "25 - 825 g cans";
			dpo.UnitPrice = 45.6000M;
			dpo.UnitsInStock = 26;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = true;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 29;
			dpo.ProductName = "Thüringer Rostbratwurst";
			dpo.SupplierID = 12;
			dpo.CategoryID = 6;
			dpo.QuantityPerUnit = "50 bags x 30 sausgs.";
			dpo.UnitPrice = 123.7900M;
			dpo.UnitsInStock = 0;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = true;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 30;
			dpo.ProductName = "Nord-Ost Matjeshering";
			dpo.SupplierID = 13;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "10 - 200 g glasses";
			dpo.UnitPrice = 25.8900M;
			dpo.UnitsInStock = 10;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 31;
			dpo.ProductName = "Gorgonzola Telino";
			dpo.SupplierID = 14;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "12 - 100 g pkgs";
			dpo.UnitPrice = 12.5000M;
			dpo.UnitsInStock = 0;
			dpo.UnitsOnOrder = 70;
			dpo.ReorderLevel = 20;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 32;
			dpo.ProductName = "Mascarpone Fabioli";
			dpo.SupplierID = 14;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "24 - 200 g pkgs.";
			dpo.UnitPrice = 32.0000M;
			dpo.UnitsInStock = 9;
			dpo.UnitsOnOrder = 40;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 33;
			dpo.ProductName = "Geitost";
			dpo.SupplierID = 15;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "500 g";
			dpo.UnitPrice = 2.5000M;
			dpo.UnitsInStock = 112;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 20;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 34;
			dpo.ProductName = "Sasquatch Ale";
			dpo.SupplierID = 16;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "24 - 12 oz bottles";
			dpo.UnitPrice = 14.0000M;
			dpo.UnitsInStock = 111;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 35;
			dpo.ProductName = "Steeleye Stout";
			dpo.SupplierID = 16;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "24 - 12 oz bottles";
			dpo.UnitPrice = 18.0000M;
			dpo.UnitsInStock = 20;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 36;
			dpo.ProductName = "Inlagd Sill";
			dpo.SupplierID = 17;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "24 - 250 g  jars";
			dpo.UnitPrice = 19.0000M;
			dpo.UnitsInStock = 112;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 20;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 37;
			dpo.ProductName = "Gravad lax";
			dpo.SupplierID = 17;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "12 - 500 g pkgs.";
			dpo.UnitPrice = 26.0000M;
			dpo.UnitsInStock = 11;
			dpo.UnitsOnOrder = 50;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 38;
			dpo.ProductName = "Côte de Blaye";
			dpo.SupplierID = 18;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "12 - 75 cl bottles";
			dpo.UnitPrice = 263.5000M;
			dpo.UnitsInStock = 17;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 39;
			dpo.ProductName = "Chartreuse verte";
			dpo.SupplierID = 18;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "750 cc per bottle";
			dpo.UnitPrice = 18.0000M;
			dpo.UnitsInStock = 69;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 5;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 40;
			dpo.ProductName = "Boston Crab Meat";
			dpo.SupplierID = 19;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "24 - 4 oz tins";
			dpo.UnitPrice = 18.4000M;
			dpo.UnitsInStock = 123;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 30;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 41;
			dpo.ProductName = "Jack's New England Clam Chowder";
			dpo.SupplierID = 19;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "12 - 12 oz cans";
			dpo.UnitPrice = 9.6500M;
			dpo.UnitsInStock = 85;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 10;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 42;
			dpo.ProductName = "Singaporean Hokkien Fried Mee";
			dpo.SupplierID = 20;
			dpo.CategoryID = 5;
			dpo.QuantityPerUnit = "32 - 1 kg pkgs.";
			dpo.UnitPrice = 14.0000M;
			dpo.UnitsInStock = 26;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = true;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 43;
			dpo.ProductName = "Ipoh Coffee";
			dpo.SupplierID = 20;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "16 - 500 g tins";
			dpo.UnitPrice = 46.0000M;
			dpo.UnitsInStock = 17;
			dpo.UnitsOnOrder = 10;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 44;
			dpo.ProductName = "Gula Malacca";
			dpo.SupplierID = 20;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "20 - 2 kg bags";
			dpo.UnitPrice = 19.4500M;
			dpo.UnitsInStock = 27;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 45;
			dpo.ProductName = "Rogede sild";
			dpo.SupplierID = 21;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "1k pkg.";
			dpo.UnitPrice = 9.5000M;
			dpo.UnitsInStock = 5;
			dpo.UnitsOnOrder = 70;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 46;
			dpo.ProductName = "Spegesild";
			dpo.SupplierID = 21;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "4 - 450 g glasses";
			dpo.UnitPrice = 12.0000M;
			dpo.UnitsInStock = 95;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 47;
			dpo.ProductName = "Zaanse koeken";
			dpo.SupplierID = 22;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "10 - 4 oz boxes";
			dpo.UnitPrice = 9.5000M;
			dpo.UnitsInStock = 36;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 48;
			dpo.ProductName = "Chocolade";
			dpo.SupplierID = 22;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "10 pkgs.";
			dpo.UnitPrice = 12.7500M;
			dpo.UnitsInStock = 15;
			dpo.UnitsOnOrder = 70;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 49;
			dpo.ProductName = "Maxilaku";
			dpo.SupplierID = 23;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "24 - 50 g pkgs.";
			dpo.UnitPrice = 20.0000M;
			dpo.UnitsInStock = 10;
			dpo.UnitsOnOrder = 60;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 50;
			dpo.ProductName = "Valkoinen suklaa";
			dpo.SupplierID = 23;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "12 - 100 g bars";
			dpo.UnitPrice = 16.2500M;
			dpo.UnitsInStock = 65;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 30;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 51;
			dpo.ProductName = "Manjimup Dried Apples";
			dpo.SupplierID = 24;
			dpo.CategoryID = 7;
			dpo.QuantityPerUnit = "50 - 300 g pkgs.";
			dpo.UnitPrice = 53.0000M;
			dpo.UnitsInStock = 20;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 10;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 52;
			dpo.ProductName = "Filo Mix";
			dpo.SupplierID = 24;
			dpo.CategoryID = 5;
			dpo.QuantityPerUnit = "16 - 2 kg boxes";
			dpo.UnitPrice = 7.0000M;
			dpo.UnitsInStock = 38;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 53;
			dpo.ProductName = "Perth Pasties";
			dpo.SupplierID = 24;
			dpo.CategoryID = 6;
			dpo.QuantityPerUnit = "48 pieces";
			dpo.UnitPrice = 32.8000M;
			dpo.UnitsInStock = 0;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = true;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 54;
			dpo.ProductName = "Tourtière";
			dpo.SupplierID = 25;
			dpo.CategoryID = 6;
			dpo.QuantityPerUnit = "16 pies";
			dpo.UnitPrice = 7.4500M;
			dpo.UnitsInStock = 21;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 10;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 55;
			dpo.ProductName = "Pâté chinois";
			dpo.SupplierID = 25;
			dpo.CategoryID = 6;
			dpo.QuantityPerUnit = "24 boxes x 2 pies";
			dpo.UnitPrice = 24.0000M;
			dpo.UnitsInStock = 115;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 20;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 56;
			dpo.ProductName = "Gnocchi di nonna Alice";
			dpo.SupplierID = 26;
			dpo.CategoryID = 5;
			dpo.QuantityPerUnit = "24 - 250 g pkgs.";
			dpo.UnitPrice = 38.0000M;
			dpo.UnitsInStock = 21;
			dpo.UnitsOnOrder = 10;
			dpo.ReorderLevel = 30;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 57;
			dpo.ProductName = "Ravioli Angelo";
			dpo.SupplierID = 26;
			dpo.CategoryID = 5;
			dpo.QuantityPerUnit = "24 - 250 g pkgs.";
			dpo.UnitPrice = 19.5000M;
			dpo.UnitsInStock = 36;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 20;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 58;
			dpo.ProductName = "Escargots de Bourgogne";
			dpo.SupplierID = 27;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "24 pieces";
			dpo.UnitPrice = 13.2500M;
			dpo.UnitsInStock = 62;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 20;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 59;
			dpo.ProductName = "Raclette Courdavault";
			dpo.SupplierID = 28;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "5 kg pkg.";
			dpo.UnitPrice = 55.0000M;
			dpo.UnitsInStock = 79;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 60;
			dpo.ProductName = "Camembert Pierrot";
			dpo.SupplierID = 28;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "15 - 300 g rounds";
			dpo.UnitPrice = 34.0000M;
			dpo.UnitsInStock = 19;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 61;
			dpo.ProductName = "Sirop d'érable";
			dpo.SupplierID = 29;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "24 - 500 ml bottles";
			dpo.UnitPrice = 28.5000M;
			dpo.UnitsInStock = 113;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 62;
			dpo.ProductName = "Tarte au sucre";
			dpo.SupplierID = 29;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "48 pies";
			dpo.UnitPrice = 49.3000M;
			dpo.UnitsInStock = 17;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 63;
			dpo.ProductName = "Vegie-spread";
			dpo.SupplierID = 7;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "15 - 625 g jars";
			dpo.UnitPrice = 43.9000M;
			dpo.UnitsInStock = 24;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 5;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 64;
			dpo.ProductName = "Wimmers gute Semmelknödel";
			dpo.SupplierID = 12;
			dpo.CategoryID = 5;
			dpo.QuantityPerUnit = "20 bags x 4 pieces";
			dpo.UnitPrice = 33.2500M;
			dpo.UnitsInStock = 22;
			dpo.UnitsOnOrder = 80;
			dpo.ReorderLevel = 30;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 65;
			dpo.ProductName = "Louisiana Fiery Hot Pepper Sauce";
			dpo.SupplierID = 2;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "32 - 8 oz bottles";
			dpo.UnitPrice = 21.0500M;
			dpo.UnitsInStock = 76;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 66;
			dpo.ProductName = "Louisiana Hot Spiced Okra";
			dpo.SupplierID = 2;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "24 - 8 oz jars";
			dpo.UnitPrice = 17.0000M;
			dpo.UnitsInStock = 4;
			dpo.UnitsOnOrder = 100;
			dpo.ReorderLevel = 20;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 67;
			dpo.ProductName = "Laughing Lumberjack Lager";
			dpo.SupplierID = 16;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "24 - 12 oz bottles";
			dpo.UnitPrice = 14.0000M;
			dpo.UnitsInStock = 52;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 10;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 68;
			dpo.ProductName = "Scottish Longbreads";
			dpo.SupplierID = 8;
			dpo.CategoryID = 3;
			dpo.QuantityPerUnit = "10 boxes x 8 pieces";
			dpo.UnitPrice = 12.5000M;
			dpo.UnitsInStock = 6;
			dpo.UnitsOnOrder = 10;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 69;
			dpo.ProductName = "Gudbrandsdalsost";
			dpo.SupplierID = 15;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "10 kg pkg.";
			dpo.UnitPrice = 36.0000M;
			dpo.UnitsInStock = 26;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 70;
			dpo.ProductName = "Outback Lager";
			dpo.SupplierID = 7;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "24 - 355 ml bottles";
			dpo.UnitPrice = 15.0000M;
			dpo.UnitsInStock = 15;
			dpo.UnitsOnOrder = 10;
			dpo.ReorderLevel = 30;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 71;
			dpo.ProductName = "Flotemysost";
			dpo.SupplierID = 15;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "10 - 500 g pkgs.";
			dpo.UnitPrice = 21.5000M;
			dpo.UnitsInStock = 26;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 72;
			dpo.ProductName = "Mozzarella di Giovanni";
			dpo.SupplierID = 14;
			dpo.CategoryID = 4;
			dpo.QuantityPerUnit = "24 - 200 g pkgs.";
			dpo.UnitPrice = 34.8000M;
			dpo.UnitsInStock = 14;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 0;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 73;
			dpo.ProductName = "Röd Kaviar";
			dpo.SupplierID = 17;
			dpo.CategoryID = 8;
			dpo.QuantityPerUnit = "24 - 150 g jars";
			dpo.UnitPrice = 15.0000M;
			dpo.UnitsInStock = 101;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 5;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 74;
			dpo.ProductName = "Longlife Tofu";
			dpo.SupplierID = 4;
			dpo.CategoryID = 7;
			dpo.QuantityPerUnit = "5 kg pkg.";
			dpo.UnitPrice = 10.0000M;
			dpo.UnitsInStock = 4;
			dpo.UnitsOnOrder = 20;
			dpo.ReorderLevel = 5;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 75;
			dpo.ProductName = "Rhönbräu Klosterbier";
			dpo.SupplierID = 12;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "24 - 0.5 l bottles";
			dpo.UnitPrice = 7.7500M;
			dpo.UnitsInStock = 125;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 25;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 76;
			dpo.ProductName = "Lakkalikööri";
			dpo.SupplierID = 23;
			dpo.CategoryID = 1;
			dpo.QuantityPerUnit = "500 ml";
			dpo.UnitPrice = 18.0000M;
			dpo.UnitsInStock = 57;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 20;
			dpo.Discontinued = false;
			list.Add(dpo);

			dpo = new ProductDpo();
			dpo.ProductID = 77;
			dpo.ProductName = "Original Frankfurter grüne Soße";
			dpo.SupplierID = 12;
			dpo.CategoryID = 2;
			dpo.QuantityPerUnit = "12 boxes";
			dpo.UnitPrice = 13.0000M;
			dpo.UnitsInStock = 32;
			dpo.UnitsOnOrder = 0;
			dpo.ReorderLevel = 15;
			dpo.Discontinued = false;
			list.Add(dpo);

		}

	}
}
