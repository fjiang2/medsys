//
// Machine Packed Data
//   by devel at 7/15/2012 2:28:54 PM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using App.Data.Dpo;

namespace App.Data.Package
{
	public class CustomerDpoPackage : BasePackage<CustomerDpo>
	{

		public CustomerDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new CustomerDpo();
			dpo.CustomerID = "ALFKI";
			dpo.CompanyName = "Alfreds Futterkiste";
			dpo.ContactName = "Maria Anders";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Obere Str. 57";
			dpo.City = "Berlin";
			dpo.PostalCode = "12209";
			dpo.Country = "Germany";
			dpo.Phone = "030-0074321";
			dpo.Fax = "030-0076545";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "ANATR";
			dpo.CompanyName = "Ana Trujillo Emparedados y helados";
			dpo.ContactName = "Ana Trujillo";
			dpo.ContactTitle = "Owner";
			dpo.Address = "Avda. de la Constitución 2222";
			dpo.City = "México D.F.";
			dpo.PostalCode = "05021";
			dpo.Country = "Mexico";
			dpo.Phone = "(5) 555-4729";
			dpo.Fax = "(5) 555-3745";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "ANTON";
			dpo.CompanyName = "Antonio Moreno Taquería";
			dpo.ContactName = "Antonio Moreno";
			dpo.ContactTitle = "Owner";
			dpo.Address = "Mataderos  2312";
			dpo.City = "México D.F.";
			dpo.PostalCode = "05023";
			dpo.Country = "Mexico";
			dpo.Phone = "(5) 555-3932";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "AROUT";
			dpo.CompanyName = "Around the Horn";
			dpo.ContactName = "Thomas Hardy";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "120 Hanover Sq.";
			dpo.City = "London";
			dpo.PostalCode = "WA1 1DP";
			dpo.Country = "UK";
			dpo.Phone = "(171) 555-7788";
			dpo.Fax = "(171) 555-6750";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "BERGS";
			dpo.CompanyName = "Berglunds snabbköp";
			dpo.ContactName = "Christina Berglund";
			dpo.ContactTitle = "Order Administrator";
			dpo.Address = "Berguvsvägen  8";
			dpo.City = "Luleå";
			dpo.PostalCode = "S-958 22";
			dpo.Country = "Sweden";
			dpo.Phone = "0921-12 34 65";
			dpo.Fax = "0921-12 34 67";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "BLAUS";
			dpo.CompanyName = "Blauer See Delikatessen";
			dpo.ContactName = "Hanna Moos";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Forsterstr. 57";
			dpo.City = "Mannheim";
			dpo.PostalCode = "68306";
			dpo.Country = "Germany";
			dpo.Phone = "0621-08460";
			dpo.Fax = "0621-08924";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "BLONP";
			dpo.CompanyName = "Blondesddsl père et fils";
			dpo.ContactName = "Frédérique Citeaux";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "24, place Kléber";
			dpo.City = "Strasbourg";
			dpo.PostalCode = "67000";
			dpo.Country = "France";
			dpo.Phone = "88.60.15.31";
			dpo.Fax = "88.60.15.32";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "BOLID";
			dpo.CompanyName = "Bólido Comidas preparadas";
			dpo.ContactName = "Martín Sommer";
			dpo.ContactTitle = "Owner";
			dpo.Address = "C/ Araquil, 67";
			dpo.City = "Madrid";
			dpo.PostalCode = "28023";
			dpo.Country = "Spain";
			dpo.Phone = "(91) 555 22 82";
			dpo.Fax = "(91) 555 91 99";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "BONAP";
			dpo.CompanyName = "Bon app'";
			dpo.ContactName = "Laurence Lebihan";
			dpo.ContactTitle = "Owner";
			dpo.Address = "12, rue des Bouchers";
			dpo.City = "Marseille";
			dpo.PostalCode = "13008";
			dpo.Country = "France";
			dpo.Phone = "91.24.45.40";
			dpo.Fax = "91.24.45.41";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "BOTTM";
			dpo.CompanyName = "Bottom-Dollar Markets";
			dpo.ContactName = "Elizabeth Lincoln";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "23 Tsawassen Blvd.";
			dpo.City = "Tsawassen";
			dpo.Region = "BC";
			dpo.PostalCode = "T2F 8M4";
			dpo.Country = "Canada";
			dpo.Phone = "(604) 555-4729";
			dpo.Fax = "(604) 555-3745";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "BSBEV";
			dpo.CompanyName = "B's Beverages";
			dpo.ContactName = "Victoria Ashworth";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Fauntleroy Circus";
			dpo.City = "London";
			dpo.PostalCode = "EC2 5NT";
			dpo.Country = "UK";
			dpo.Phone = "(171) 555-1212";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "CACTU";
			dpo.CompanyName = "Cactus Comidas para llevar";
			dpo.ContactName = "Patricio Simpson";
			dpo.ContactTitle = "Sales Agent";
			dpo.Address = "Cerrito 333";
			dpo.City = "Buenos Aires";
			dpo.PostalCode = "1010";
			dpo.Country = "Argentina";
			dpo.Phone = "(1) 135-5555";
			dpo.Fax = "(1) 135-4892";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "CENTC";
			dpo.CompanyName = "Centro comercial Moctezuma";
			dpo.ContactName = "Francisco Chang";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "Sierras de Granada 9993";
			dpo.City = "México D.F.";
			dpo.PostalCode = "05022";
			dpo.Country = "Mexico";
			dpo.Phone = "(5) 555-3392";
			dpo.Fax = "(5) 555-7293";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "CHOPS";
			dpo.CompanyName = "Chop-suey Chinese";
			dpo.ContactName = "Yang Wang";
			dpo.ContactTitle = "Owner";
			dpo.Address = "Hauptstr. 29";
			dpo.City = "Bern";
			dpo.PostalCode = "3012";
			dpo.Country = "Switzerland";
			dpo.Phone = "0452-076545";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "COMMI";
			dpo.CompanyName = "Comércio Mineiro";
			dpo.ContactName = "Pedro Afonso";
			dpo.ContactTitle = "Sales Associate";
			dpo.Address = "Av. dos Lusíadas, 23";
			dpo.City = "Sao Paulo";
			dpo.Region = "SP";
			dpo.PostalCode = "05432-043";
			dpo.Country = "Brazil";
			dpo.Phone = "(11) 555-7647";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "CONSH";
			dpo.CompanyName = "Consolidated Holdings";
			dpo.ContactName = "Elizabeth Brown";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Berkeley Gardens 12  Brewery";
			dpo.City = "London";
			dpo.PostalCode = "WX1 6LT";
			dpo.Country = "UK";
			dpo.Phone = "(171) 555-2282";
			dpo.Fax = "(171) 555-9199";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "DRACD";
			dpo.CompanyName = "Drachenblut Delikatessen";
			dpo.ContactName = "Sven Ottlieb";
			dpo.ContactTitle = "Order Administrator";
			dpo.Address = "Walserweg 21";
			dpo.City = "Aachen";
			dpo.PostalCode = "52066";
			dpo.Country = "Germany";
			dpo.Phone = "0241-039123";
			dpo.Fax = "0241-059428";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "DUMON";
			dpo.CompanyName = "Du monde entier";
			dpo.ContactName = "Janine Labrune";
			dpo.ContactTitle = "Owner";
			dpo.Address = "67, rue des Cinquante Otages";
			dpo.City = "Nantes";
			dpo.PostalCode = "44000";
			dpo.Country = "France";
			dpo.Phone = "40.67.88.88";
			dpo.Fax = "40.67.89.89";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "EASTC";
			dpo.CompanyName = "Eastern Connection";
			dpo.ContactName = "Ann Devon";
			dpo.ContactTitle = "Sales Agent";
			dpo.Address = "35 King George";
			dpo.City = "London";
			dpo.PostalCode = "WX3 6FW";
			dpo.Country = "UK";
			dpo.Phone = "(171) 555-0297";
			dpo.Fax = "(171) 555-3373";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "ERNSH";
			dpo.CompanyName = "Ernst Handel";
			dpo.ContactName = "Roland Mendel";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "Kirchgasse 6";
			dpo.City = "Graz";
			dpo.PostalCode = "8010";
			dpo.Country = "Austria";
			dpo.Phone = "7675-3425";
			dpo.Fax = "7675-3426";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "FAMIA";
			dpo.CompanyName = "Familia Arquibaldo";
			dpo.ContactName = "Aria Cruz";
			dpo.ContactTitle = "Marketing Assistant";
			dpo.Address = "Rua Orós, 92";
			dpo.City = "Sao Paulo";
			dpo.Region = "SP";
			dpo.PostalCode = "05442-030";
			dpo.Country = "Brazil";
			dpo.Phone = "(11) 555-9857";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "FISSA";
			dpo.CompanyName = "FISSA Fabrica Inter. Salchichas S.A.";
			dpo.ContactName = "Diego Roel";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "C/ Moralzarzal, 86";
			dpo.City = "Madrid";
			dpo.PostalCode = "28034";
			dpo.Country = "Spain";
			dpo.Phone = "(91) 555 94 44";
			dpo.Fax = "(91) 555 55 93";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "FOLIG";
			dpo.CompanyName = "Folies gourmandes";
			dpo.ContactName = "Martine Rancé";
			dpo.ContactTitle = "Assistant Sales Agent";
			dpo.Address = "184, chaussée de Tournai";
			dpo.City = "Lille";
			dpo.PostalCode = "59000";
			dpo.Country = "France";
			dpo.Phone = "20.16.10.16";
			dpo.Fax = "20.16.10.17";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "FOLKO";
			dpo.CompanyName = "Folk och fä HB";
			dpo.ContactName = "Maria Larsson";
			dpo.ContactTitle = "Owner";
			dpo.Address = "Åkergatan 24";
			dpo.City = "Bräcke";
			dpo.PostalCode = "S-844 67";
			dpo.Country = "Sweden";
			dpo.Phone = "0695-34 67 21";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "FRANK";
			dpo.CompanyName = "Frankenversand";
			dpo.ContactName = "Peter Franken";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "Berliner Platz 43";
			dpo.City = "München";
			dpo.PostalCode = "80805";
			dpo.Country = "Germany";
			dpo.Phone = "089-0877310";
			dpo.Fax = "089-0877451";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "FRANR";
			dpo.CompanyName = "France restauration";
			dpo.ContactName = "Carine Schmitt";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "54, rue Royale";
			dpo.City = "Nantes";
			dpo.PostalCode = "44000";
			dpo.Country = "France";
			dpo.Phone = "40.32.21.21";
			dpo.Fax = "40.32.21.20";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "FRANS";
			dpo.CompanyName = "Franchi S.p.A.";
			dpo.ContactName = "Paolo Accorti";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Via Monte Bianco 34";
			dpo.City = "Torino";
			dpo.PostalCode = "10100";
			dpo.Country = "Italy";
			dpo.Phone = "011-4988260";
			dpo.Fax = "011-4988261";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "FURIB";
			dpo.CompanyName = "Furia Bacalhau e Frutos do Mar";
			dpo.ContactName = "Lino Rodriguez";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "Jardim das rosas n. 32";
			dpo.City = "Lisboa";
			dpo.PostalCode = "1675";
			dpo.Country = "Portugal";
			dpo.Phone = "(1) 354-2534";
			dpo.Fax = "(1) 354-2535";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "GALED";
			dpo.CompanyName = "Galería del gastrónomo";
			dpo.ContactName = "Eduardo Saavedra";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "Rambla de Cataluña, 23";
			dpo.City = "Barcelona";
			dpo.PostalCode = "08022";
			dpo.Country = "Spain";
			dpo.Phone = "(93) 203 4560";
			dpo.Fax = "(93) 203 4561";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "GODOS";
			dpo.CompanyName = "Godos Cocina Típica";
			dpo.ContactName = "José Pedro Freyre";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "C/ Romero, 33";
			dpo.City = "Sevilla";
			dpo.PostalCode = "41101";
			dpo.Country = "Spain";
			dpo.Phone = "(95) 555 82 82";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "GOURL";
			dpo.CompanyName = "Gourmet Lanchonetes";
			dpo.ContactName = "André Fonseca";
			dpo.ContactTitle = "Sales Associate";
			dpo.Address = "Av. Brasil, 442";
			dpo.City = "Campinas";
			dpo.Region = "SP";
			dpo.PostalCode = "04876-786";
			dpo.Country = "Brazil";
			dpo.Phone = "(11) 555-9482";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "GREAL";
			dpo.CompanyName = "Great Lakes Food Market";
			dpo.ContactName = "Howard Snyder";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "2732 Baker Blvd.";
			dpo.City = "Eugene";
			dpo.Region = "OR";
			dpo.PostalCode = "97403";
			dpo.Country = "USA";
			dpo.Phone = "(503) 555-7555";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "GROSR";
			dpo.CompanyName = "GROSELLA-Restaurante";
			dpo.ContactName = "Manuel Pereira";
			dpo.ContactTitle = "Owner";
			dpo.Address = "5ª Ave. Los Palos Grandes";
			dpo.City = "Caracas";
			dpo.Region = "DF";
			dpo.PostalCode = "1081";
			dpo.Country = "Venezuela";
			dpo.Phone = "(2) 283-2951";
			dpo.Fax = "(2) 283-3397";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "HANAR";
			dpo.CompanyName = "Hanari Carnes";
			dpo.ContactName = "Mario Pontes";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "Rua do Paço, 67";
			dpo.City = "Rio de Janeiro";
			dpo.Region = "RJ";
			dpo.PostalCode = "05454-876";
			dpo.Country = "Brazil";
			dpo.Phone = "(21) 555-0091";
			dpo.Fax = "(21) 555-8765";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "HILAA";
			dpo.CompanyName = "HILARION-Abastos";
			dpo.ContactName = "Carlos Hernández";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Carrera 22 con Ave. Carlos Soublette #8-35";
			dpo.City = "San Cristóbal";
			dpo.Region = "Táchira";
			dpo.PostalCode = "5022";
			dpo.Country = "Venezuela";
			dpo.Phone = "(5) 555-1340";
			dpo.Fax = "(5) 555-1948";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "HUNGC";
			dpo.CompanyName = "Hungry Coyote Import Store";
			dpo.ContactName = "Yoshi Latimer";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "City Center Plaza 516 Main St.";
			dpo.City = "Elgin";
			dpo.Region = "OR";
			dpo.PostalCode = "97827";
			dpo.Country = "USA";
			dpo.Phone = "(503) 555-6874";
			dpo.Fax = "(503) 555-2376";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "HUNGO";
			dpo.CompanyName = "Hungry Owl All-Night Grocers";
			dpo.ContactName = "Patricia McKenna";
			dpo.ContactTitle = "Sales Associate";
			dpo.Address = "8 Johnstown Road";
			dpo.City = "Cork";
			dpo.Region = "Co. Cork";
			dpo.Country = "Ireland";
			dpo.Phone = "2967 542";
			dpo.Fax = "2967 3333";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "ISLAT";
			dpo.CompanyName = "Island Trading";
			dpo.ContactName = "Helen Bennett";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "Garden House Crowther Way";
			dpo.City = "Cowes";
			dpo.Region = "Isle of Wight";
			dpo.PostalCode = "PO31 7PJ";
			dpo.Country = "UK";
			dpo.Phone = "(198) 555-8888";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "KOENE";
			dpo.CompanyName = "Königlich Essen";
			dpo.ContactName = "Philip Cramer";
			dpo.ContactTitle = "Sales Associate";
			dpo.Address = "Maubelstr. 90";
			dpo.City = "Brandenburg";
			dpo.PostalCode = "14776";
			dpo.Country = "Germany";
			dpo.Phone = "0555-09876";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "LACOR";
			dpo.CompanyName = "La corne d'abondance";
			dpo.ContactName = "Daniel Tonini";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "67, avenue de l'Europe";
			dpo.City = "Versailles";
			dpo.PostalCode = "78000";
			dpo.Country = "France";
			dpo.Phone = "30.59.84.10";
			dpo.Fax = "30.59.85.11";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "LAMAI";
			dpo.CompanyName = "La maison d'Asie";
			dpo.ContactName = "Annette Roulet";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "1 rue Alsace-Lorraine";
			dpo.City = "Toulouse";
			dpo.PostalCode = "31000";
			dpo.Country = "France";
			dpo.Phone = "61.77.61.10";
			dpo.Fax = "61.77.61.11";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "LAUGB";
			dpo.CompanyName = "Laughing Bacchus Wine Cellars";
			dpo.ContactName = "Yoshi Tannamuri";
			dpo.ContactTitle = "Marketing Assistant";
			dpo.Address = "1900 Oak St.";
			dpo.City = "Vancouver";
			dpo.Region = "BC";
			dpo.PostalCode = "V3F 2K1";
			dpo.Country = "Canada";
			dpo.Phone = "(604) 555-3392";
			dpo.Fax = "(604) 555-7293";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "LAZYK";
			dpo.CompanyName = "Lazy K Kountry Store";
			dpo.ContactName = "John Steel";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "12 Orchestra Terrace";
			dpo.City = "Walla Walla";
			dpo.Region = "WA";
			dpo.PostalCode = "99362";
			dpo.Country = "USA";
			dpo.Phone = "(509) 555-7969";
			dpo.Fax = "(509) 555-6221";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "LEHMS";
			dpo.CompanyName = "Lehmanns Marktstand";
			dpo.ContactName = "Renate Messner";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Magazinweg 7";
			dpo.City = "Frankfurt a.M.";
			dpo.PostalCode = "60528";
			dpo.Country = "Germany";
			dpo.Phone = "069-0245984";
			dpo.Fax = "069-0245874";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "LETSS";
			dpo.CompanyName = "Let's Stop N Shop";
			dpo.ContactName = "Jaime Yorres";
			dpo.ContactTitle = "Owner";
			dpo.Address = "87 Polk St. Suite 5";
			dpo.City = "San Francisco";
			dpo.Region = "CA";
			dpo.PostalCode = "94117";
			dpo.Country = "USA";
			dpo.Phone = "(415) 555-5938";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "LILAS";
			dpo.CompanyName = "LILA-Supermercado";
			dpo.ContactName = "Carlos González";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo";
			dpo.City = "Barquisimeto";
			dpo.Region = "Lara";
			dpo.PostalCode = "3508";
			dpo.Country = "Venezuela";
			dpo.Phone = "(9) 331-6954";
			dpo.Fax = "(9) 331-7256";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "LINOD";
			dpo.CompanyName = "LINO-Delicateses";
			dpo.ContactName = "Felipe Izquierdo";
			dpo.ContactTitle = "Owner";
			dpo.Address = "Ave. 5 de Mayo Porlamar";
			dpo.City = "I. de Margarita";
			dpo.Region = "Nueva Esparta";
			dpo.PostalCode = "4980";
			dpo.Country = "Venezuela";
			dpo.Phone = "(8) 34-56-12";
			dpo.Fax = "(8) 34-93-93";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "LONEP";
			dpo.CompanyName = "Lonesome Pine Restaurant";
			dpo.ContactName = "Fran Wilson";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "89 Chiaroscuro Rd.";
			dpo.City = "Portland";
			dpo.Region = "OR";
			dpo.PostalCode = "97219";
			dpo.Country = "USA";
			dpo.Phone = "(503) 555-9573";
			dpo.Fax = "(503) 555-9646";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "MAGAA";
			dpo.CompanyName = "Magazzini Alimentari Riuniti";
			dpo.ContactName = "Giovanni Rovelli";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "Via Ludovico il Moro 22";
			dpo.City = "Bergamo";
			dpo.PostalCode = "24100";
			dpo.Country = "Italy";
			dpo.Phone = "035-640230";
			dpo.Fax = "035-640231";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "MAISD";
			dpo.CompanyName = "Maison Dewey";
			dpo.ContactName = "Catherine Dewey";
			dpo.ContactTitle = "Sales Agent";
			dpo.Address = "Rue Joseph-Bens 532";
			dpo.City = "Bruxelles";
			dpo.PostalCode = "B-1180";
			dpo.Country = "Belgium";
			dpo.Phone = "(02) 201 24 67";
			dpo.Fax = "(02) 201 24 68";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "MEREP";
			dpo.CompanyName = "Mère Paillarde";
			dpo.ContactName = "Jean Fresnière";
			dpo.ContactTitle = "Marketing Assistant";
			dpo.Address = "43 rue St. Laurent";
			dpo.City = "Montréal";
			dpo.Region = "Québec";
			dpo.PostalCode = "H1J 1C3";
			dpo.Country = "Canada";
			dpo.Phone = "(514) 555-8054";
			dpo.Fax = "(514) 555-8055";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "MORGK";
			dpo.CompanyName = "Morgenstern Gesundkost";
			dpo.ContactName = "Alexander Feuer";
			dpo.ContactTitle = "Marketing Assistant";
			dpo.Address = "Heerstr. 22";
			dpo.City = "Leipzig";
			dpo.PostalCode = "04179";
			dpo.Country = "Germany";
			dpo.Phone = "0342-023176";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "NORTS";
			dpo.CompanyName = "North/South";
			dpo.ContactName = "Simon Crowther";
			dpo.ContactTitle = "Sales Associate";
			dpo.Address = "South House 300 Queensbridge";
			dpo.City = "London";
			dpo.PostalCode = "SW7 1RZ";
			dpo.Country = "UK";
			dpo.Phone = "(171) 555-7733";
			dpo.Fax = "(171) 555-2530";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "OCEAN";
			dpo.CompanyName = "Océano Atlántico Ltda.";
			dpo.ContactName = "Yvonne Moncada";
			dpo.ContactTitle = "Sales Agent";
			dpo.Address = "Ing. Gustavo Moncada 8585 Piso 20-A";
			dpo.City = "Buenos Aires";
			dpo.PostalCode = "1010";
			dpo.Country = "Argentina";
			dpo.Phone = "(1) 135-5333";
			dpo.Fax = "(1) 135-5535";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "OLDWO";
			dpo.CompanyName = "Old World Delicatessen";
			dpo.ContactName = "Rene Phillips";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "2743 Bering St.";
			dpo.City = "Anchorage";
			dpo.Region = "AK";
			dpo.PostalCode = "99508";
			dpo.Country = "USA";
			dpo.Phone = "(907) 555-7584";
			dpo.Fax = "(907) 555-2880";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "OTTIK";
			dpo.CompanyName = "Ottilies Käseladen";
			dpo.ContactName = "Henriette Pfalzheim";
			dpo.ContactTitle = "Owner";
			dpo.Address = "Mehrheimerstr. 369";
			dpo.City = "Köln";
			dpo.PostalCode = "50739";
			dpo.Country = "Germany";
			dpo.Phone = "0221-0644327";
			dpo.Fax = "0221-0765721";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "PARIS";
			dpo.CompanyName = "Paris spécialités";
			dpo.ContactName = "Marie Bertrand";
			dpo.ContactTitle = "Owner";
			dpo.Address = "265, boulevard Charonne";
			dpo.City = "Paris";
			dpo.PostalCode = "75012";
			dpo.Country = "France";
			dpo.Phone = "(1) 42.34.22.66";
			dpo.Fax = "(1) 42.34.22.77";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "PERIC";
			dpo.CompanyName = "Pericles Comidas clásicas";
			dpo.ContactName = "Guillermo Fernández";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Calle Dr. Jorge Cash 321";
			dpo.City = "México D.F.";
			dpo.PostalCode = "05033";
			dpo.Country = "Mexico";
			dpo.Phone = "(5) 552-3745";
			dpo.Fax = "(5) 545-3745";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "PICCO";
			dpo.CompanyName = "Piccolo und mehr";
			dpo.ContactName = "Georg Pipps";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "Geislweg 14";
			dpo.City = "Salzburg";
			dpo.PostalCode = "5020";
			dpo.Country = "Austria";
			dpo.Phone = "6562-9722";
			dpo.Fax = "6562-9723";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "PRINI";
			dpo.CompanyName = "Princesa Isabel Vinhos";
			dpo.ContactName = "Isabel de Castro";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Estrada da saúde n. 58";
			dpo.City = "Lisboa";
			dpo.PostalCode = "1756";
			dpo.Country = "Portugal";
			dpo.Phone = "(1) 356-5634";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "QUEDE";
			dpo.CompanyName = "Que Delícia";
			dpo.ContactName = "Bernardo Batista";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "Rua da Panificadora, 12";
			dpo.City = "Rio de Janeiro";
			dpo.Region = "RJ";
			dpo.PostalCode = "02389-673";
			dpo.Country = "Brazil";
			dpo.Phone = "(21) 555-4252";
			dpo.Fax = "(21) 555-4545";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "QUEEN";
			dpo.CompanyName = "Queen Cozinha";
			dpo.ContactName = "Lúcia Carvalho";
			dpo.ContactTitle = "Marketing Assistant";
			dpo.Address = "Alameda dos Canàrios, 891";
			dpo.City = "Sao Paulo";
			dpo.Region = "SP";
			dpo.PostalCode = "05487-020";
			dpo.Country = "Brazil";
			dpo.Phone = "(11) 555-1189";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "QUICK";
			dpo.CompanyName = "QUICK-Stop";
			dpo.ContactName = "Horst Kloss";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "Taucherstraße 10";
			dpo.City = "Cunewalde";
			dpo.PostalCode = "01307";
			dpo.Country = "Germany";
			dpo.Phone = "0372-035188";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "RANCH";
			dpo.CompanyName = "Rancho grande";
			dpo.ContactName = "Sergio Gutiérrez";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Av. del Libertador 900";
			dpo.City = "Buenos Aires";
			dpo.PostalCode = "1010";
			dpo.Country = "Argentina";
			dpo.Phone = "(1) 123-5555";
			dpo.Fax = "(1) 123-5556";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "RATTC";
			dpo.CompanyName = "Rattlesnake Canyon Grocery";
			dpo.ContactName = "Paula Wilson";
			dpo.ContactTitle = "Assistant Sales Representative";
			dpo.Address = "2817 Milton Dr.";
			dpo.City = "Albuquerque";
			dpo.Region = "NM";
			dpo.PostalCode = "87110";
			dpo.Country = "USA";
			dpo.Phone = "(505) 555-5939";
			dpo.Fax = "(505) 555-3620";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "REGGC";
			dpo.CompanyName = "Reggiani Caseifici";
			dpo.ContactName = "Maurizio Moroni";
			dpo.ContactTitle = "Sales Associate";
			dpo.Address = "Strada Provinciale 124";
			dpo.City = "Reggio Emilia";
			dpo.PostalCode = "42100";
			dpo.Country = "Italy";
			dpo.Phone = "0522-556721";
			dpo.Fax = "0522-556722";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "RICAR";
			dpo.CompanyName = "Ricardo Adocicados";
			dpo.ContactName = "Janete Limeira";
			dpo.ContactTitle = "Assistant Sales Agent";
			dpo.Address = "Av. Copacabana, 267";
			dpo.City = "Rio de Janeiro";
			dpo.Region = "RJ";
			dpo.PostalCode = "02389-890";
			dpo.Country = "Brazil";
			dpo.Phone = "(21) 555-3412";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "RICSU";
			dpo.CompanyName = "Richter Supermarkt";
			dpo.ContactName = "Michael Holz";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "Grenzacherweg 237";
			dpo.City = "Genève";
			dpo.PostalCode = "1203";
			dpo.Country = "Switzerland";
			dpo.Phone = "0897-034214";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "ROMEY";
			dpo.CompanyName = "Romero y tomillo";
			dpo.ContactName = "Alejandra Camino";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "Gran Vía, 1";
			dpo.City = "Madrid";
			dpo.PostalCode = "28001";
			dpo.Country = "Spain";
			dpo.Phone = "(91) 745 6200";
			dpo.Fax = "(91) 745 6210";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "SANTG";
			dpo.CompanyName = "Santé Gourmet";
			dpo.ContactName = "Jonas Bergulfsen";
			dpo.ContactTitle = "Owner";
			dpo.Address = "Erling Skakkes gate 78";
			dpo.City = "Stavern";
			dpo.PostalCode = "4110";
			dpo.Country = "Norway";
			dpo.Phone = "07-98 92 35";
			dpo.Fax = "07-98 92 47";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "SAVEA";
			dpo.CompanyName = "Save-a-lot Markets";
			dpo.ContactName = "Jose Pavarotti";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "187 Suffolk Ln.";
			dpo.City = "Boise";
			dpo.Region = "ID";
			dpo.PostalCode = "83720";
			dpo.Country = "USA";
			dpo.Phone = "(208) 555-8097";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "SEVES";
			dpo.CompanyName = "Seven Seas Imports";
			dpo.ContactName = "Hari Kumar";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "90 Wadhurst Rd.";
			dpo.City = "London";
			dpo.PostalCode = "OX15 4NB";
			dpo.Country = "UK";
			dpo.Phone = "(171) 555-1717";
			dpo.Fax = "(171) 555-5646";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "SIMOB";
			dpo.CompanyName = "Simons bistro";
			dpo.ContactName = "Jytte Petersen";
			dpo.ContactTitle = "Owner";
			dpo.Address = "Vinbæltet 34";
			dpo.City = "Kobenhavn";
			dpo.PostalCode = "1734";
			dpo.Country = "Denmark";
			dpo.Phone = "31 12 34 56";
			dpo.Fax = "31 13 35 57";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "SPECD";
			dpo.CompanyName = "Spécialités du monde";
			dpo.ContactName = "Dominique Perrier";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "25, rue Lauriston";
			dpo.City = "Paris";
			dpo.PostalCode = "75016";
			dpo.Country = "France";
			dpo.Phone = "(1) 47.55.60.10";
			dpo.Fax = "(1) 47.55.60.20";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "SPLIR";
			dpo.CompanyName = "Split Rail Beer & Ale";
			dpo.ContactName = "Art Braunschweiger";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "P.O. Box 555";
			dpo.City = "Lander";
			dpo.Region = "WY";
			dpo.PostalCode = "82520";
			dpo.Country = "USA";
			dpo.Phone = "(307) 555-4680";
			dpo.Fax = "(307) 555-6525";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "SUPRD";
			dpo.CompanyName = "Suprêmes délices";
			dpo.ContactName = "Pascale Cartrain";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "Boulevard Tirou, 255";
			dpo.City = "Charleroi";
			dpo.PostalCode = "B-6000";
			dpo.Country = "Belgium";
			dpo.Phone = "(071) 23 67 22 20";
			dpo.Fax = "(071) 23 67 22 21";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "THEBI";
			dpo.CompanyName = "The Big Cheese";
			dpo.ContactName = "Liz Nixon";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "89 Jefferson Way Suite 2";
			dpo.City = "Portland";
			dpo.Region = "OR";
			dpo.PostalCode = "97201";
			dpo.Country = "USA";
			dpo.Phone = "(503) 555-3612";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "THECR";
			dpo.CompanyName = "The Cracker Box";
			dpo.ContactName = "Liu Wong";
			dpo.ContactTitle = "Marketing Assistant";
			dpo.Address = "55 Grizzly Peak Rd.";
			dpo.City = "Butte";
			dpo.Region = "MT";
			dpo.PostalCode = "59801";
			dpo.Country = "USA";
			dpo.Phone = "(406) 555-5834";
			dpo.Fax = "(406) 555-8083";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "TOMSP";
			dpo.CompanyName = "Toms Spezialitäten";
			dpo.ContactName = "Karin Josephs";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "Luisenstr. 48";
			dpo.City = "Münster";
			dpo.PostalCode = "44087";
			dpo.Country = "Germany";
			dpo.Phone = "0251-031259";
			dpo.Fax = "0251-035695";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "TORTU";
			dpo.CompanyName = "Tortuga Restaurante";
			dpo.ContactName = "Miguel Angel Paolino";
			dpo.ContactTitle = "Owner";
			dpo.Address = "Avda. Azteca 123";
			dpo.City = "México D.F.";
			dpo.PostalCode = "05033";
			dpo.Country = "Mexico";
			dpo.Phone = "(5) 555-2933";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "TRADH";
			dpo.CompanyName = "Tradição Hipermercados";
			dpo.ContactName = "Anabela Domingues";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Av. Inês de Castro, 414";
			dpo.City = "Sao Paulo";
			dpo.Region = "SP";
			dpo.PostalCode = "05634-030";
			dpo.Country = "Brazil";
			dpo.Phone = "(11) 555-2167";
			dpo.Fax = "(11) 555-2168";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "TRAIH";
			dpo.CompanyName = "Trail's Head Gourmet Provisioners";
			dpo.ContactName = "Helvetius Nagy";
			dpo.ContactTitle = "Sales Associate";
			dpo.Address = "722 DaVinci Blvd.";
			dpo.City = "Kirkland";
			dpo.Region = "WA";
			dpo.PostalCode = "98034";
			dpo.Country = "USA";
			dpo.Phone = "(206) 555-8257";
			dpo.Fax = "(206) 555-2174";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "VAFFE";
			dpo.CompanyName = "Vaffeljernet";
			dpo.ContactName = "Palle Ibsen";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "Smagsloget 45";
			dpo.City = "Århus";
			dpo.PostalCode = "8200";
			dpo.Country = "Denmark";
			dpo.Phone = "86 21 32 43";
			dpo.Fax = "86 22 33 44";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "VICTE";
			dpo.CompanyName = "Victuailles en stock";
			dpo.ContactName = "Mary Saveley";
			dpo.ContactTitle = "Sales Agent";
			dpo.Address = "2, rue du Commerce";
			dpo.City = "Lyon";
			dpo.PostalCode = "69004";
			dpo.Country = "France";
			dpo.Phone = "78.32.54.86";
			dpo.Fax = "78.32.54.87";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "VINET";
			dpo.CompanyName = "Vins et alcools Chevalier";
			dpo.ContactName = "Paul Henriot";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "59 rue de l'Abbaye";
			dpo.City = "Reims";
			dpo.PostalCode = "51100";
			dpo.Country = "France";
			dpo.Phone = "26.47.15.10";
			dpo.Fax = "26.47.15.11";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "WANDK";
			dpo.CompanyName = "Die Wandernde Kuh";
			dpo.ContactName = "Rita Müller";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Adenauerallee 900";
			dpo.City = "Stuttgart";
			dpo.PostalCode = "70563";
			dpo.Country = "Germany";
			dpo.Phone = "0711-020361";
			dpo.Fax = "0711-035428";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "WARTH";
			dpo.CompanyName = "Wartian Herkku";
			dpo.ContactName = "Pirkko Koskitalo";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "Torikatu 38";
			dpo.City = "Oulu";
			dpo.PostalCode = "90110";
			dpo.Country = "Finland";
			dpo.Phone = "981-443655";
			dpo.Fax = "981-443655";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "WELLI";
			dpo.CompanyName = "Wellington Importadora";
			dpo.ContactName = "Paula Parente";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "Rua do Mercado, 12";
			dpo.City = "Resende";
			dpo.Region = "SP";
			dpo.PostalCode = "08737-363";
			dpo.Country = "Brazil";
			dpo.Phone = "(14) 555-8122";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "WHITC";
			dpo.CompanyName = "White Clover Markets";
			dpo.ContactName = "Karl Jablonski";
			dpo.ContactTitle = "Owner";
			dpo.Address = "305 - 14th Ave. S. Suite 3B";
			dpo.City = "Seattle";
			dpo.Region = "WA";
			dpo.PostalCode = "98128";
			dpo.Country = "USA";
			dpo.Phone = "(206) 555-4112";
			dpo.Fax = "(206) 555-4115";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "WILMK";
			dpo.CompanyName = "Wilman Kala";
			dpo.ContactName = "Matti Karttunen";
			dpo.ContactTitle = "Owner/Marketing Assistant";
			dpo.Address = "Keskuskatu 45";
			dpo.City = "Helsinki";
			dpo.PostalCode = "21240";
			dpo.Country = "Finland";
			dpo.Phone = "90-224 8858";
			dpo.Fax = "90-224 8858";
			list.Add(dpo);

			dpo = new CustomerDpo();
			dpo.CustomerID = "WOLZA";
			dpo.CompanyName = "Wolski  Zajazd";
			dpo.ContactName = "Zbyszek Piestrzeniewicz";
			dpo.ContactTitle = "Owner";
			dpo.Address = "ul. Filtrowa 68";
			dpo.City = "Warszawa";
			dpo.PostalCode = "01-012";
			dpo.Country = "Poland";
			dpo.Phone = "(26) 642-7012";
			dpo.Fax = "(26) 642-7012";
			list.Add(dpo);

		}

	}
}
