//
// Machine Packed Data
//   by devel at 7/19/2012 12:14:10 AM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using Sys.ViewManager.DpoClass;

namespace Sys.ViewManager.DpoPackage
{
	public class AppLinkDpoPackage : BasePackage<AppLinkDpo>
	{

		public AppLinkDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new AppLinkDpo();
			dpo.ID = 2;
			dpo.Label = "Microsoft Word";
			dpo.Description = "";
			dpo.Command = "WINWORD.EXE";
			dpo.Icon = new System.Byte[]{255,216,255,224,0,16,74,70,73,70,0,1,1,1,0,96,0,96,0,0,255,225,0,90,69,120,105,102,0,0,77,77,0,42,0,0,0,8,0,5,3,1,0,5,0,0,0,1,0,0,0,74,3,3,0,1,0,0,0,1,0,0,0,0,81,16,0,1,0,0,0,1,1,0,0,0,81,17,0,4,0,0,0,1,0,0,14,196,81,18,0,4,0,0,0,1,0,0,14,196,0,0,0,0,0,1,134,160,0,0,177,143,255,219,0,67,0,8,6,6,7,6,5,8,7,7,7,9,9,8,10,12,20,13,12,11,11,12,25,18,19,15,20,29,26,31,30,29,26,28,28,32,36,46,39,32,34,44,35,28,28,40,55,41,44,48,49,52,52,52,31,39,57,61,56,50,60,46,51,52,50,255,219,0,67,1,9,9,9,12,11,12,24,13,13,24,50,33,28,33,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,255,192,0,17,8,0,16,0,16,3,1,34,0,2,17,1,3,17,1,255,196,0,31,0,0,1,5,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1,2,3,4,5,6,7,8,9,10,11,255,196,0,181,16,0,2,1,3,3,2,4,3,5,5,4,4,0,0,1,125,1,2,3,0,4,17,5,18,33,49,65,6,19,81,97,7,34,113,20,50,129,145,161,8,35,66,177,193,21,82,209,240,36,51,98,114,130,9,10,22,23,24,25,26,37,38,39,40,41,42,52,53,54,55,56,57,58,67,68,69,70,71,72,73,74,83,84,85,86,87,88,89,90,99,100,101,102,103,104,105,106,115,116,117,118,119,120,121,122,131,132,133,134,135,136,137,138,146,147,148,149,150,151,152,153,154,162,163,164,165,166,167,168,169,170,178,179,180,181,182,183,184,185,186,194,195,196,197,198,199,200,201,202,210,211,212,213,214,215,216,217,218,225,226,227,228,229,230,231,232,233,234,241,242,243,244,245,246,247,248,249,250,255,196,0,31,1,0,3,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,2,3,4,5,6,7,8,9,10,11,255,196,0,181,17,0,2,1,2,4,4,3,4,7,5,4,4,0,1,2,119,0,1,2,3,17,4,5,33,49,6,18,65,81,7,97,113,19,34,50,129,8,20,66,145,161,177,193,9,35,51,82,240,21,98,114,209,10,22,36,52,225,37,241,23,24,25,26,38,39,40,41,42,53,54,55,56,57,58,67,68,69,70,71,72,73,74,83,84,85,86,87,88,89,90,99,100,101,102,103,104,105,106,115,116,117,118,119,120,121,122,130,131,132,133,134,135,136,137,138,146,147,148,149,150,151,152,153,154,162,163,164,165,166,167,168,169,170,178,179,180,181,182,183,184,185,186,194,195,196,197,198,199,200,201,202,210,211,212,213,214,215,216,217,218,226,227,228,229,230,231,232,233,234,242,243,244,245,246,247,248,249,250,255,218,0,12,3,1,0,2,17,3,17,0,63,0,232,181,29,126,222,201,214,217,237,26,105,93,34,17,121,109,49,46,242,68,206,163,229,126,165,130,140,14,185,56,171,126,126,165,101,225,185,117,27,89,98,182,187,211,38,185,119,201,105,4,202,38,145,118,19,144,72,27,54,242,79,28,140,16,8,177,169,233,218,86,133,120,45,231,215,197,188,136,144,205,15,159,29,160,118,101,220,138,219,140,37,137,85,92,3,212,116,205,101,106,26,190,143,109,225,77,86,202,13,94,11,153,238,22,71,220,101,66,242,59,179,51,103,106,40,234,199,3,242,174,246,249,214,135,38,177,122,159,255,217};
			dpo.OrderBy = 1;
			list.Add(dpo);

			dpo = new AppLinkDpo();
			dpo.ID = 3;
			dpo.Label = "Microsoft Excel";
			dpo.Description = "";
			dpo.Command = "EXCEL.EXE";
			dpo.Icon = new System.Byte[]{255,216,255,224,0,16,74,70,73,70,0,1,1,1,0,96,0,96,0,0,255,225,0,108,69,120,105,102,0,0,77,77,0,42,0,0,0,8,0,5,1,49,0,2,0,0,0,17,0,0,0,74,3,1,0,5,0,0,0,1,0,0,0,92,81,16,0,1,0,0,0,1,1,0,0,0,81,17,0,4,0,0,0,1,0,0,0,0,81,18,0,4,0,0,0,1,0,0,0,0,0,0,0,0,65,100,111,98,101,32,73,109,97,103,101,82,101,97,100,121,0,0,0,1,134,160,0,0,175,200,255,219,0,67,0,8,6,6,7,6,5,8,7,7,7,9,9,8,10,12,20,13,12,11,11,12,25,18,19,15,20,29,26,31,30,29,26,28,28,32,36,46,39,32,34,44,35,28,28,40,55,41,44,48,49,52,52,52,31,39,57,61,56,50,60,46,51,52,50,255,219,0,67,1,9,9,9,12,11,12,24,13,13,24,50,33,28,33,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,255,192,0,17,8,0,16,0,16,3,1,34,0,2,17,1,3,17,1,255,196,0,31,0,0,1,5,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1,2,3,4,5,6,7,8,9,10,11,255,196,0,181,16,0,2,1,3,3,2,4,3,5,5,4,4,0,0,1,125,1,2,3,0,4,17,5,18,33,49,65,6,19,81,97,7,34,113,20,50,129,145,161,8,35,66,177,193,21,82,209,240,36,51,98,114,130,9,10,22,23,24,25,26,37,38,39,40,41,42,52,53,54,55,56,57,58,67,68,69,70,71,72,73,74,83,84,85,86,87,88,89,90,99,100,101,102,103,104,105,106,115,116,117,118,119,120,121,122,131,132,133,134,135,136,137,138,146,147,148,149,150,151,152,153,154,162,163,164,165,166,167,168,169,170,178,179,180,181,182,183,184,185,186,194,195,196,197,198,199,200,201,202,210,211,212,213,214,215,216,217,218,225,226,227,228,229,230,231,232,233,234,241,242,243,244,245,246,247,248,249,250,255,196,0,31,1,0,3,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,2,3,4,5,6,7,8,9,10,11,255,196,0,181,17,0,2,1,2,4,4,3,4,7,5,4,4,0,1,2,119,0,1,2,3,17,4,5,33,49,6,18,65,81,7,97,113,19,34,50,129,8,20,66,145,161,177,193,9,35,51,82,240,21,98,114,209,10,22,36,52,225,37,241,23,24,25,26,38,39,40,41,42,53,54,55,56,57,58,67,68,69,70,71,72,73,74,83,84,85,86,87,88,89,90,99,100,101,102,103,104,105,106,115,116,117,118,119,120,121,122,130,131,132,133,134,135,136,137,138,146,147,148,149,150,151,152,153,154,162,163,164,165,166,167,168,169,170,178,179,180,181,182,183,184,185,186,194,195,196,197,198,199,200,201,202,210,211,212,213,214,215,216,217,218,226,227,228,229,230,231,232,233,234,242,243,244,245,246,247,248,249,250,255,218,0,12,3,1,0,2,17,3,17,0,63,0,235,230,213,225,183,182,123,153,244,43,89,36,150,121,25,203,128,89,29,157,137,87,44,153,4,100,15,195,182,107,82,206,223,107,88,106,145,89,141,46,245,102,138,57,35,132,12,73,19,202,170,85,176,7,102,233,142,48,15,81,198,61,190,147,163,218,253,185,37,215,194,220,61,196,209,202,151,151,17,177,98,178,176,12,195,229,98,196,12,228,158,254,135,21,175,109,117,167,219,233,246,118,81,235,54,183,179,253,174,221,87,23,42,238,217,184,67,192,220,79,3,244,21,189,21,136,231,126,211,111,145,194,143,255,217};
			dpo.OrderBy = 2;
			list.Add(dpo);

			dpo = new AppLinkDpo();
			dpo.ID = 4;
			dpo.Label = "Intranet";
			dpo.Description = "";
			dpo.Command = "http://intranet";
			dpo.Icon = new System.Byte[]{255,216,255,224,0,16,74,70,73,70,0,1,1,1,0,96,0,96,0,0,255,225,0,108,69,120,105,102,0,0,77,77,0,42,0,0,0,8,0,5,1,49,0,2,0,0,0,17,0,0,0,74,3,1,0,5,0,0,0,1,0,0,0,92,81,16,0,1,0,0,0,1,1,0,0,0,81,17,0,4,0,0,0,1,0,0,0,0,81,18,0,4,0,0,0,1,0,0,0,0,0,0,0,0,65,100,111,98,101,32,73,109,97,103,101,82,101,97,100,121,0,0,0,1,134,160,0,0,175,200,255,219,0,67,0,8,6,6,7,6,5,8,7,7,7,9,9,8,10,12,20,13,12,11,11,12,25,18,19,15,20,29,26,31,30,29,26,28,28,32,36,46,39,32,34,44,35,28,28,40,55,41,44,48,49,52,52,52,31,39,57,61,56,50,60,46,51,52,50,255,219,0,67,1,9,9,9,12,11,12,24,13,13,24,50,33,28,33,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,255,192,0,17,8,0,16,0,16,3,1,34,0,2,17,1,3,17,1,255,196,0,31,0,0,1,5,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1,2,3,4,5,6,7,8,9,10,11,255,196,0,181,16,0,2,1,3,3,2,4,3,5,5,4,4,0,0,1,125,1,2,3,0,4,17,5,18,33,49,65,6,19,81,97,7,34,113,20,50,129,145,161,8,35,66,177,193,21,82,209,240,36,51,98,114,130,9,10,22,23,24,25,26,37,38,39,40,41,42,52,53,54,55,56,57,58,67,68,69,70,71,72,73,74,83,84,85,86,87,88,89,90,99,100,101,102,103,104,105,106,115,116,117,118,119,120,121,122,131,132,133,134,135,136,137,138,146,147,148,149,150,151,152,153,154,162,163,164,165,166,167,168,169,170,178,179,180,181,182,183,184,185,186,194,195,196,197,198,199,200,201,202,210,211,212,213,214,215,216,217,218,225,226,227,228,229,230,231,232,233,234,241,242,243,244,245,246,247,248,249,250,255,196,0,31,1,0,3,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,2,3,4,5,6,7,8,9,10,11,255,196,0,181,17,0,2,1,2,4,4,3,4,7,5,4,4,0,1,2,119,0,1,2,3,17,4,5,33,49,6,18,65,81,7,97,113,19,34,50,129,8,20,66,145,161,177,193,9,35,51,82,240,21,98,114,209,10,22,36,52,225,37,241,23,24,25,26,38,39,40,41,42,53,54,55,56,57,58,67,68,69,70,71,72,73,74,83,84,85,86,87,88,89,90,99,100,101,102,103,104,105,106,115,116,117,118,119,120,121,122,130,131,132,133,134,135,136,137,138,146,147,148,149,150,151,152,153,154,162,163,164,165,166,167,168,169,170,178,179,180,181,182,183,184,185,186,194,195,196,197,198,199,200,201,202,210,211,212,213,214,215,216,217,218,226,227,228,229,230,231,232,233,234,242,243,244,245,246,247,248,249,250,255,218,0,12,3,1,0,2,17,3,17,0,63,0,244,153,174,97,184,138,91,219,255,0,222,187,13,233,27,182,229,133,91,27,66,142,157,49,147,138,202,93,85,180,233,158,234,215,48,201,9,243,26,5,109,171,42,46,75,43,118,251,187,176,112,113,89,58,253,228,186,110,167,54,153,114,145,253,162,222,223,116,9,49,216,151,36,54,212,98,119,14,54,103,141,221,65,244,197,98,190,169,11,71,112,29,138,192,97,144,60,242,56,14,141,183,1,20,121,173,149,57,35,161,235,215,184,231,141,59,210,254,241,231,170,53,101,37,43,219,243,63,255,217};
			dpo.OrderBy = 3;
			list.Add(dpo);

			dpo = new AppLinkDpo();
			dpo.ID = 5;
			dpo.Label = "Google";
			dpo.Description = "";
			dpo.Command = "http://www.google.com";
			dpo.OrderBy = 4;
			list.Add(dpo);

		}

	}
}
