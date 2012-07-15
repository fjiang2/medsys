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
	public class SupplierDpoPackage : BasePackage<SupplierDpo>
	{

		public SupplierDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new SupplierDpo();
			dpo.SupplierID = 1;
			dpo.CompanyName = "Exotic Liquids";
			dpo.ContactName = "Charlotte Cooper";
			dpo.ContactTitle = "Purchasing Manager";
			dpo.Address = "49 Gilbert St.";
			dpo.City = "London";
			dpo.PostalCode = "EC1 4SD";
			dpo.Country = "UK";
			dpo.Phone = "(171) 555-2222";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 2;
			dpo.CompanyName = "New Orleans Cajun Delights";
			dpo.ContactName = "Shelley Burke";
			dpo.ContactTitle = "Order Administrator";
			dpo.Address = "P.O. Box 78934";
			dpo.City = "New Orleans";
			dpo.Region = "LA";
			dpo.PostalCode = "70117";
			dpo.Country = "USA";
			dpo.Phone = "(100) 555-4822";
			dpo.HomePage = "#CAJUN.HTM#";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 3;
			dpo.CompanyName = "Grandma Kelly's Homestead";
			dpo.ContactName = "Regina Murphy";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "707 Oxford Rd.";
			dpo.City = "Ann Arbor";
			dpo.Region = "MI";
			dpo.PostalCode = "48104";
			dpo.Country = "USA";
			dpo.Phone = "(313) 555-5735";
			dpo.Fax = "(313) 555-3349";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 4;
			dpo.CompanyName = "Tokyo Traders";
			dpo.ContactName = "Yoshi Nagase";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "9-8 Sekimai Musashino-shi";
			dpo.City = "Tokyo";
			dpo.PostalCode = "100";
			dpo.Country = "Japan";
			dpo.Phone = "(03) 3555-5011";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 5;
			dpo.CompanyName = "Cooperativa de Quesos 'Las Cabras'";
			dpo.ContactName = "Antonio del Valle Saavedra";
			dpo.ContactTitle = "Export Administrator";
			dpo.Address = "Calle del Rosal 4";
			dpo.City = "Oviedo";
			dpo.Region = "Asturias";
			dpo.PostalCode = "33007";
			dpo.Country = "Spain";
			dpo.Phone = "(98) 598 76 54";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 6;
			dpo.CompanyName = "Mayumi's";
			dpo.ContactName = "Mayumi Ohno";
			dpo.ContactTitle = "Marketing Representative";
			dpo.Address = "92 Setsuko Chuo-ku";
			dpo.City = "Osaka";
			dpo.PostalCode = "545";
			dpo.Country = "Japan";
			dpo.Phone = "(06) 431-7877";
			dpo.HomePage = "Mayumi's (on the World Wide Web)#http://www.microsoft.com/accessdev/sampleapps/mayumi.htm#";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 7;
			dpo.CompanyName = "Pavlova, Ltd.";
			dpo.ContactName = "Ian Devling";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "74 Rose St. Moonie Ponds";
			dpo.City = "Melbourne";
			dpo.Region = "Victoria";
			dpo.PostalCode = "3058";
			dpo.Country = "Australia";
			dpo.Phone = "(03) 444-2343";
			dpo.Fax = "(03) 444-6588";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 8;
			dpo.CompanyName = "Specialty Biscuits, Ltd.";
			dpo.ContactName = "Peter Wilson";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "29 King's Way";
			dpo.City = "Manchester";
			dpo.PostalCode = "M14 GSD";
			dpo.Country = "UK";
			dpo.Phone = "(161) 555-4448";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 9;
			dpo.CompanyName = "PB Knäckebröd AB";
			dpo.ContactName = "Lars Peterson";
			dpo.ContactTitle = "Sales Agent";
			dpo.Address = "Kaloadagatan 13";
			dpo.City = "Göteborg";
			dpo.PostalCode = "S-345 67";
			dpo.Country = "Sweden";
			dpo.Phone = "031-987 65 43";
			dpo.Fax = "031-987 65 91";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 10;
			dpo.CompanyName = "Refrescos Americanas LTDA";
			dpo.ContactName = "Carlos Diaz";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "Av. das Americanas 12.890";
			dpo.City = "Sao Paulo";
			dpo.PostalCode = "5442";
			dpo.Country = "Brazil";
			dpo.Phone = "(11) 555 4640";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 11;
			dpo.CompanyName = "Heli Süßwaren GmbH & Co. KG";
			dpo.ContactName = "Petra Winkler";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "Tiergartenstraße 5";
			dpo.City = "Berlin";
			dpo.PostalCode = "10785";
			dpo.Country = "Germany";
			dpo.Phone = "(010) 9984510";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 12;
			dpo.CompanyName = "Plutzer Lebensmittelgroßmärkte AG";
			dpo.ContactName = "Martin Bein";
			dpo.ContactTitle = "International Marketing Mgr.";
			dpo.Address = "Bogenallee 51";
			dpo.City = "Frankfurt";
			dpo.PostalCode = "60439";
			dpo.Country = "Germany";
			dpo.Phone = "(069) 992755";
			dpo.HomePage = "Plutzer (on the World Wide Web)#http://www.microsoft.com/accessdev/sampleapps/plutzer.htm#";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 13;
			dpo.CompanyName = "Nord-Ost-Fisch Handelsgesellschaft mbH";
			dpo.ContactName = "Sven Petersen";
			dpo.ContactTitle = "Coordinator Foreign Markets";
			dpo.Address = "Frahmredder 112a";
			dpo.City = "Cuxhaven";
			dpo.PostalCode = "27478";
			dpo.Country = "Germany";
			dpo.Phone = "(04721) 8713";
			dpo.Fax = "(04721) 8714";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 14;
			dpo.CompanyName = "Formaggi Fortini s.r.l.";
			dpo.ContactName = "Elio Rossi";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Viale Dante, 75";
			dpo.City = "Ravenna";
			dpo.PostalCode = "48100";
			dpo.Country = "Italy";
			dpo.Phone = "(0544) 60323";
			dpo.Fax = "(0544) 60603";
			dpo.HomePage = "#FORMAGGI.HTM#";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 15;
			dpo.CompanyName = "Norske Meierier";
			dpo.ContactName = "Beate Vileid";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "Hatlevegen 5";
			dpo.City = "Sandvika";
			dpo.PostalCode = "1320";
			dpo.Country = "Norway";
			dpo.Phone = "(0)2-953010";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 16;
			dpo.CompanyName = "Bigfoot Breweries";
			dpo.ContactName = "Cheryl Saylor";
			dpo.ContactTitle = "Regional Account Rep.";
			dpo.Address = "3400 - 8th Avenue Suite 210";
			dpo.City = "Bend";
			dpo.Region = "OR";
			dpo.PostalCode = "97101";
			dpo.Country = "USA";
			dpo.Phone = "(503) 555-9931";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 17;
			dpo.CompanyName = "Svensk Sjöföda AB";
			dpo.ContactName = "Michael Björn";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Brovallavägen 231";
			dpo.City = "Stockholm";
			dpo.PostalCode = "S-123 45";
			dpo.Country = "Sweden";
			dpo.Phone = "08-123 45 67";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 18;
			dpo.CompanyName = "Aux joyeux ecclésiastiques";
			dpo.ContactName = "Guylène Nodier";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "203, Rue des Francs-Bourgeois";
			dpo.City = "Paris";
			dpo.PostalCode = "75004";
			dpo.Country = "France";
			dpo.Phone = "(1) 03.83.00.68";
			dpo.Fax = "(1) 03.83.00.62";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 19;
			dpo.CompanyName = "New England Seafood Cannery";
			dpo.ContactName = "Robb Merchant";
			dpo.ContactTitle = "Wholesale Account Agent";
			dpo.Address = "Order Processing Dept. 2100 Paul Revere Blvd.";
			dpo.City = "Boston";
			dpo.Region = "MA";
			dpo.PostalCode = "02134";
			dpo.Country = "USA";
			dpo.Phone = "(617) 555-3267";
			dpo.Fax = "(617) 555-3389";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 20;
			dpo.CompanyName = "Leka Trading";
			dpo.ContactName = "Chandra Leka";
			dpo.ContactTitle = "Owner";
			dpo.Address = "471 Serangoon Loop, Suite #402";
			dpo.City = "Singapore";
			dpo.PostalCode = "0512";
			dpo.Country = "Singapore";
			dpo.Phone = "555-8787";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 21;
			dpo.CompanyName = "Lyngbysild";
			dpo.ContactName = "Niels Petersen";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "Lyngbysild Fiskebakken 10";
			dpo.City = "Lyngby";
			dpo.PostalCode = "2800";
			dpo.Country = "Denmark";
			dpo.Phone = "43844108";
			dpo.Fax = "43844115";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 22;
			dpo.CompanyName = "Zaanse Snoepfabriek";
			dpo.ContactName = "Dirk Luchte";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "Verkoop Rijnweg 22";
			dpo.City = "Zaandam";
			dpo.PostalCode = "9999 ZZ";
			dpo.Country = "Netherlands";
			dpo.Phone = "(12345) 1212";
			dpo.Fax = "(12345) 1210";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 23;
			dpo.CompanyName = "Karkki Oy";
			dpo.ContactName = "Anne Heikkonen";
			dpo.ContactTitle = "Product Manager";
			dpo.Address = "Valtakatu 12";
			dpo.City = "Lappeenranta";
			dpo.PostalCode = "53120";
			dpo.Country = "Finland";
			dpo.Phone = "(953) 10956";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 24;
			dpo.CompanyName = "G'day, Mate";
			dpo.ContactName = "Wendy Mackenzie";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "170 Prince Edward Parade Hunter's Hill";
			dpo.City = "Sydney";
			dpo.Region = "NSW";
			dpo.PostalCode = "2042";
			dpo.Country = "Australia";
			dpo.Phone = "(02) 555-5914";
			dpo.Fax = "(02) 555-4873";
			dpo.HomePage = "G'day Mate (on the World Wide Web)#http://www.microsoft.com/accessdev/sampleapps/gdaymate.htm#";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 25;
			dpo.CompanyName = "Ma Maison";
			dpo.ContactName = "Jean-Guy Lauzon";
			dpo.ContactTitle = "Marketing Manager";
			dpo.Address = "2960 Rue St. Laurent";
			dpo.City = "Montréal";
			dpo.Region = "Québec";
			dpo.PostalCode = "H1J 1C3";
			dpo.Country = "Canada";
			dpo.Phone = "(514) 555-9022";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 26;
			dpo.CompanyName = "Pasta Buttini s.r.l.";
			dpo.ContactName = "Giovanni Giudici";
			dpo.ContactTitle = "Order Administrator";
			dpo.Address = "Via dei Gelsomini, 153";
			dpo.City = "Salerno";
			dpo.PostalCode = "84100";
			dpo.Country = "Italy";
			dpo.Phone = "(089) 6547665";
			dpo.Fax = "(089) 6547667";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 27;
			dpo.CompanyName = "Escargots Nouveaux";
			dpo.ContactName = "Marie Delamare";
			dpo.ContactTitle = "Sales Manager";
			dpo.Address = "22, rue H. Voiron";
			dpo.City = "Montceau";
			dpo.PostalCode = "71300";
			dpo.Country = "France";
			dpo.Phone = "85.57.00.07";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 28;
			dpo.CompanyName = "Gai pâturage";
			dpo.ContactName = "Eliane Noz";
			dpo.ContactTitle = "Sales Representative";
			dpo.Address = "Bat. B 3, rue des Alpes";
			dpo.City = "Annecy";
			dpo.PostalCode = "74000";
			dpo.Country = "France";
			dpo.Phone = "38.76.98.06";
			dpo.Fax = "38.76.98.58";
			list.Add(dpo);

			dpo = new SupplierDpo();
			dpo.SupplierID = 29;
			dpo.CompanyName = "Forêts d'érables";
			dpo.ContactName = "Chantal Goulet";
			dpo.ContactTitle = "Accounting Manager";
			dpo.Address = "148 rue Chasseur";
			dpo.City = "Ste-Hyacinthe";
			dpo.Region = "Québec";
			dpo.PostalCode = "J2S 7S8";
			dpo.Country = "Canada";
			dpo.Phone = "(514) 555-2955";
			dpo.Fax = "(514) 555-2921";
			list.Add(dpo);

		}

	}
}
