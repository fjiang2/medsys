//
// Machine Packed Data
//   by devel at 7/18/2012 9:44:50 AM
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
	public class TerritorieDpoPackage : BasePackage<TerritorieDpo>
	{

		public TerritorieDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new TerritorieDpo();
			dpo.TerritoryID = "01581";
			dpo.TerritoryDescription = "Westboro                                          ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "01730";
			dpo.TerritoryDescription = "Bedford                                           ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "01833";
			dpo.TerritoryDescription = "Georgetow                                         ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "02116";
			dpo.TerritoryDescription = "Boston                                            ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "02139";
			dpo.TerritoryDescription = "Cambridge                                         ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "02184";
			dpo.TerritoryDescription = "Braintree                                         ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "02903";
			dpo.TerritoryDescription = "Providence                                        ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "03049";
			dpo.TerritoryDescription = "Hollis                                            ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "03801";
			dpo.TerritoryDescription = "Portsmouth                                        ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "06897";
			dpo.TerritoryDescription = "Wilton                                            ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "07960";
			dpo.TerritoryDescription = "Morristown                                        ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "08837";
			dpo.TerritoryDescription = "Edison                                            ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "10019";
			dpo.TerritoryDescription = "New York                                          ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "10038";
			dpo.TerritoryDescription = "New York                                          ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "11747";
			dpo.TerritoryDescription = "Mellvile                                          ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "14450";
			dpo.TerritoryDescription = "Fairport                                          ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "19428";
			dpo.TerritoryDescription = "Philadelphia                                      ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "19713";
			dpo.TerritoryDescription = "Neward                                            ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "20852";
			dpo.TerritoryDescription = "Rockville                                         ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "27403";
			dpo.TerritoryDescription = "Greensboro                                        ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "27511";
			dpo.TerritoryDescription = "Cary                                              ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "29202";
			dpo.TerritoryDescription = "Columbia                                          ";
			dpo.RegionID = 4;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "30346";
			dpo.TerritoryDescription = "Atlanta                                           ";
			dpo.RegionID = 4;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "31406";
			dpo.TerritoryDescription = "Savannah                                          ";
			dpo.RegionID = 4;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "32859";
			dpo.TerritoryDescription = "Orlando                                           ";
			dpo.RegionID = 4;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "33607";
			dpo.TerritoryDescription = "Tampa                                             ";
			dpo.RegionID = 4;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "40222";
			dpo.TerritoryDescription = "Louisville                                        ";
			dpo.RegionID = 1;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "44122";
			dpo.TerritoryDescription = "Beachwood                                         ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "45839";
			dpo.TerritoryDescription = "Findlay                                           ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "48075";
			dpo.TerritoryDescription = "Southfield                                        ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "48084";
			dpo.TerritoryDescription = "Troy                                              ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "48304";
			dpo.TerritoryDescription = "Bloomfield Hills                                  ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "53404";
			dpo.TerritoryDescription = "Racine                                            ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "55113";
			dpo.TerritoryDescription = "Roseville                                         ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "55439";
			dpo.TerritoryDescription = "Minneapolis                                       ";
			dpo.RegionID = 3;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "60179";
			dpo.TerritoryDescription = "Hoffman Estates                                   ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "60601";
			dpo.TerritoryDescription = "Chicago                                           ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "72716";
			dpo.TerritoryDescription = "Bentonville                                       ";
			dpo.RegionID = 4;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "75234";
			dpo.TerritoryDescription = "Dallas                                            ";
			dpo.RegionID = 4;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "78759";
			dpo.TerritoryDescription = "Austin                                            ";
			dpo.RegionID = 4;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "80202";
			dpo.TerritoryDescription = "Denver                                            ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "80909";
			dpo.TerritoryDescription = "Colorado Springs                                  ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "85014";
			dpo.TerritoryDescription = "Phoenix                                           ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "85251";
			dpo.TerritoryDescription = "Scottsdale                                        ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "90405";
			dpo.TerritoryDescription = "Santa Monica                                      ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "94025";
			dpo.TerritoryDescription = "Menlo Park                                        ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "94105";
			dpo.TerritoryDescription = "San Francisco                                     ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "95008";
			dpo.TerritoryDescription = "Campbell                                          ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "95054";
			dpo.TerritoryDescription = "Santa Clara                                       ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "95060";
			dpo.TerritoryDescription = "Santa Cruz                                        ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "98004";
			dpo.TerritoryDescription = "Bellevue                                          ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "98052";
			dpo.TerritoryDescription = "Redmond                                           ";
			dpo.RegionID = 2;
			list.Add(dpo);

			dpo = new TerritorieDpo();
			dpo.TerritoryID = "98104";
			dpo.TerritoryDescription = "Seattle                                           ";
			dpo.RegionID = 2;
			list.Add(dpo);

		}

	}
}
