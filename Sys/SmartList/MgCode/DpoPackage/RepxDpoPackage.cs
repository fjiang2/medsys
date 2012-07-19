//
// Machine Packed Data
//   by devel at 7/16/2012 1:58:04 PM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using Sys.SmartList.DpoClass;

namespace Sys.SmartList.DpoPackage
{
	public class RepxDpoPackage : BasePackage<RepxDpo>
	{

		public RepxDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new RepxDpo();
			dpo.ID = 1;
			dpo.Command_ID = 34;
			dpo.url = "Report0";
			dpo.repx = @"/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v11.2, Version=11.2.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</AssemblyFullName>
///   <AssemblyLocation>C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v11.2\11.2.10.0__b88d1754d700e49a\DevExpress.XtraReports.v11.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class xtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.DetailBand detailBand1;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel label3;
        private DevExpress.XtraReports.UI.XRLabel label2;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private System.Resources.ResourceManager _resources;
        public xtraReport1() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = ""zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza"" +
                        ""W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O"" +
                        ""SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFA141seA"" +
                        ""AAAAO0AAAAsJAB0AGgAaQBzAC4ARABhAHQAYQBTAG8AdQByAGMAZQBTAGMAaABlAG0AYQAAAAAAAdxBP"" +
                        ""D94bWwgdmVyc2lvbj0iMS4wIj8+DQo8eHM6c2NoZW1hIGlkPSJOb3J0aHdpbmREYXRhU2V0IiB0YXJnZ"" +
                        ""XROYW1lc3BhY2U9Imh0dHA6Ly90ZW1wdXJpLm9yZy9Ob3J0aHdpbmREYXRhU2V0LnhzZCIgeG1sbnM6b"" +
                        ""XN0bnM9Imh0dHA6Ly90ZW1wdXJpLm9yZy9Ob3J0aHdpbmREYXRhU2V0LnhzZCIgeG1sbnM9Imh0dHA6L"" +
                        ""y90ZW1wdXJpLm9yZy9Ob3J0aHdpbmREYXRhU2V0LnhzZCIgeG1sbnM6eHM9Imh0dHA6Ly93d3cudzMub"" +
                        ""3JnLzIwMDEvWE1MU2NoZW1hIiB4bWxuczptc2RhdGE9InVybjpzY2hlbWFzLW1pY3Jvc29mdC1jb206e"" +
                        ""G1sLW1zZGF0YSIgeG1sbnM6bXNwcm9wPSJ1cm46c2NoZW1hcy1taWNyb3NvZnQtY29tOnhtbC1tc3Byb"" +
                        ""3AiIGF0dHJpYnV0ZUZvcm1EZWZhdWx0PSJxdWFsaWZpZWQiIGVsZW1lbnRGb3JtRGVmYXVsdD0icXVhb"" +
                        ""GlmaWVkIj4NCiAgPHhzOmVsZW1lbnQgbmFtZT0iTm9ydGh3aW5kRGF0YVNldCIgbXNkYXRhOklzRGF0Y"" +
                        ""VNldD0idHJ1ZSIgbXNkYXRhOlVzZUN1cnJlbnRMb2NhbGU9InRydWUiIG1zZGF0YTpFbmZvcmNlQ29uc"" +
                        ""3RyYWludHM9IkZhbHNlIiBtc3Byb3A6RW5hYmxlVGFibGVBZGFwdGVyTWFuYWdlcj0iVHJ1ZSIgbXNwc"" +
                        ""m9wOkdlbmVyYXRvcl9EYXRhU2V0TmFtZT0iTm9ydGh3aW5kRGF0YVNldCIgbXNwcm9wOkdlbmVyYXRvc"" +
                        ""l9Vc2VyRFNOYW1lPSJOb3J0aHdpbmREYXRhU2V0Ij4NCiAgICA8eHM6Y29tcGxleFR5cGU+DQogICAgI"" +
                        ""CA8eHM6Y2hvaWNlIG1pbk9jY3Vycz0iMCIgbWF4T2NjdXJzPSJ1bmJvdW5kZWQiPg0KICAgICAgICA8e"" +
                        ""HM6ZWxlbWVudCBuYW1lPSJDYXRlZ29yaWVzIiBtc3Byb3A6R2VuZXJhdG9yX1RhYmxlQ2xhc3NOYW1lP"" +
                        ""SJDYXRlZ29yaWVzRGF0YVRhYmxlIiBtc3Byb3A6R2VuZXJhdG9yX1RhYmxlVmFyTmFtZT0idGFibGVDY"" +
                        ""XRlZ29yaWVzIiBtc3Byb3A6R2VuZXJhdG9yX1RhYmxlUHJvcE5hbWU9IkNhdGVnb3JpZXMiIG1zcHJvc"" +
                        ""DpHZW5lcmF0b3JfUm93RGVsZXRpbmdOYW1lPSJDYXRlZ29yaWVzUm93RGVsZXRpbmciIG1zcHJvcDpHZ"" +
                        ""W5lcmF0b3JfVXNlclRhYmxlTmFtZT0iQ2F0ZWdvcmllcyIgbXNwcm9wOkdlbmVyYXRvcl9Sb3dDaGFuZ"" +
                        ""2luZ05hbWU9IkNhdGVnb3JpZXNSb3dDaGFuZ2luZyIgbXNwcm9wOkdlbmVyYXRvcl9Sb3dFdkhhbmRsZ"" +
                        ""XJOYW1lPSJDYXRlZ29yaWVzUm93Q2hhbmdlRXZlbnRIYW5kbGVyIiBtc3Byb3A6R2VuZXJhdG9yX1Jvd"" +
                        ""0RlbGV0ZWROYW1lPSJDYXRlZ29yaWVzUm93RGVsZXRlZCIgbXNwcm9wOkdlbmVyYXRvcl9Sb3dFdkFyZ"" +
                        ""05hbWU9IkNhdGVnb3JpZXNSb3dDaGFuZ2VFdmVudCIgbXNwcm9wOkdlbmVyYXRvcl9Sb3dDaGFuZ2VkT"" +
                        ""mFtZT0iQ2F0ZWdvcmllc1Jvd0NoYW5nZWQiIG1zcHJvcDpHZW5lcmF0b3JfUm93Q2xhc3NOYW1lPSJDY"" +
                        ""XRlZ29yaWVzUm93Ij4NCiAgICAgICAgICA8eHM6Y29tcGxleFR5cGU+DQogICAgICAgICAgICA8eHM6c"" +
                        ""2VxdWVuY2U+DQogICAgICAgICAgICAgIDx4czplbGVtZW50IG5hbWU9IkNhdGVnb3J5SUQiIG1zZGF0Y"" +
                        ""TpSZWFkT25seT0idHJ1ZSIgbXNkYXRhOkF1dG9JbmNyZW1lbnQ9InRydWUiIG1zZGF0YTpBdXRvSW5jc"" +
                        ""mVtZW50U2VlZD0iLTEiIG1zZGF0YTpBdXRvSW5jcmVtZW50U3RlcD0iLTEiIG1zcHJvcDpHZW5lcmF0b"" +
                        ""3JfQ29sdW1uVmFyTmFtZUluVGFibGU9ImNvbHVtbkNhdGVnb3J5SUQiIG1zcHJvcDpHZW5lcmF0b3JfQ"" +
                        ""29sdW1uUHJvcE5hbWVJblJvdz0iQ2F0ZWdvcnlJRCIgbXNwcm9wOkdlbmVyYXRvcl9Db2x1bW5Qcm9wT"" +
                        ""mFtZUluVGFibGU9IkNhdGVnb3J5SURDb2x1bW4iIG1zcHJvcDpHZW5lcmF0b3JfVXNlckNvbHVtbk5hb"" +
                        ""WU9IkNhdGVnb3J5SUQiIHR5cGU9InhzOmludCIgLz4NCiAgICAgICAgICAgICAgPHhzOmVsZW1lbnQgb"" +
                        ""mFtZT0iQ2F0ZWdvcnlOYW1lIiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtblZhck5hbWVJblRhYmxlPSJjb"" +
                        ""2x1bW5DYXRlZ29yeU5hbWUiIG1zcHJvcDpHZW5lcmF0b3JfQ29sdW1uUHJvcE5hbWVJblJvdz0iQ2F0Z"" +
                        ""WdvcnlOYW1lIiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtblByb3BOYW1lSW5UYWJsZT0iQ2F0ZWdvcnlOY"" +
                        ""W1lQ29sdW1uIiBtc3Byb3A6R2VuZXJhdG9yX1VzZXJDb2x1bW5OYW1lPSJDYXRlZ29yeU5hbWUiPg0KI"" +
                        ""CAgICAgICAgICAgICAgIDx4czpzaW1wbGVUeXBlPg0KICAgICAgICAgICAgICAgICAgPHhzOnJlc3Rya"" +
                        ""WN0aW9uIGJhc2U9InhzOnN0cmluZyI+DQogICAgICAgICAgICAgICAgICAgIDx4czptYXhMZW5ndGggd"" +
                        ""mFsdWU9IjE1IiAvPg0KICAgICAgICAgICAgICAgICAgPC94czpyZXN0cmljdGlvbj4NCiAgICAgICAgI"" +
                        ""CAgICAgICA8L3hzOnNpbXBsZVR5cGU+DQogICAgICAgICAgICAgIDwveHM6ZWxlbWVudD4NCiAgICAgI"" +
                        ""CAgICAgICAgPHhzOmVsZW1lbnQgbmFtZT0iRGVzY3JpcHRpb24iIG1zcHJvcDpHZW5lcmF0b3JfQ29sd"" +
                        ""W1uVmFyTmFtZUluVGFibGU9ImNvbHVtbkRlc2NyaXB0aW9uIiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtb"" +
                        ""lByb3BOYW1lSW5Sb3c9IkRlc2NyaXB0aW9uIiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtblByb3BOYW1lS"" +
                        ""W5UYWJsZT0iRGVzY3JpcHRpb25Db2x1bW4iIG1zcHJvcDpHZW5lcmF0b3JfVXNlckNvbHVtbk5hbWU9I"" +
                        ""kRlc2NyaXB0aW9uIiBtaW5PY2N1cnM9IjAiPg0KICAgICAgICAgICAgICAgIDx4czpzaW1wbGVUeXBlP"" +
                        ""g0KICAgICAgICAgICAgICAgICAgPHhzOnJlc3RyaWN0aW9uIGJhc2U9InhzOnN0cmluZyI+DQogICAgI"" +
                        ""CAgICAgICAgICAgICAgIDx4czptYXhMZW5ndGggdmFsdWU9IjEwNzM3NDE4MjMiIC8+DQogICAgICAgI"" +
                        ""CAgICAgICAgICA8L3hzOnJlc3RyaWN0aW9uPg0KICAgICAgICAgICAgICAgIDwveHM6c2ltcGxlVHlwZ"" +
                        ""T4NCiAgICAgICAgICAgICAgPC94czplbGVtZW50Pg0KICAgICAgICAgICAgICA8eHM6ZWxlbWVudCBuY"" +
                        ""W1lPSJQaWN0dXJlIiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtblZhck5hbWVJblRhYmxlPSJjb2x1bW5Qa"" +
                        ""WN0dXJlIiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtblByb3BOYW1lSW5Sb3c9IlBpY3R1cmUiIG1zcHJvc"" +
                        ""DpHZW5lcmF0b3JfQ29sdW1uUHJvcE5hbWVJblRhYmxlPSJQaWN0dXJlQ29sdW1uIiBtc3Byb3A6R2VuZ"" +
                        ""XJhdG9yX1VzZXJDb2x1bW5OYW1lPSJQaWN0dXJlIiB0eXBlPSJ4czpiYXNlNjRCaW5hcnkiIG1pbk9jY"" +
                        ""3Vycz0iMCIgLz4NCiAgICAgICAgICAgIDwveHM6c2VxdWVuY2U+DQogICAgICAgICAgPC94czpjb21wb"" +
                        ""GV4VHlwZT4NCiAgICAgICAgPC94czplbGVtZW50Pg0KICAgICAgICA8eHM6ZWxlbWVudCBuYW1lPSJQc"" +
                        ""m9kdWN0cyIgbXNwcm9wOkdlbmVyYXRvcl9UYWJsZUNsYXNzTmFtZT0iUHJvZHVjdHNEYXRhVGFibGUiI"" +
                        ""G1zcHJvcDpHZW5lcmF0b3JfVGFibGVWYXJOYW1lPSJ0YWJsZVByb2R1Y3RzIiBtc3Byb3A6R2VuZXJhd"" +
                        ""G9yX1RhYmxlUHJvcE5hbWU9IlByb2R1Y3RzIiBtc3Byb3A6R2VuZXJhdG9yX1Jvd0RlbGV0aW5nTmFtZ"" +
                        ""T0iUHJvZHVjdHNSb3dEZWxldGluZyIgbXNwcm9wOkdlbmVyYXRvcl9Vc2VyVGFibGVOYW1lPSJQcm9kd"" +
                        ""WN0cyIgbXNwcm9wOkdlbmVyYXRvcl9Sb3dDaGFuZ2luZ05hbWU9IlByb2R1Y3RzUm93Q2hhbmdpbmciI"" +
                        ""G1zcHJvcDpHZW5lcmF0b3JfUm93RXZIYW5kbGVyTmFtZT0iUHJvZHVjdHNSb3dDaGFuZ2VFdmVudEhhb"" +
                        ""mRsZXIiIG1zcHJvcDpHZW5lcmF0b3JfUm93RGVsZXRlZE5hbWU9IlByb2R1Y3RzUm93RGVsZXRlZCIgb"" +
                        ""XNwcm9wOkdlbmVyYXRvcl9Sb3dFdkFyZ05hbWU9IlByb2R1Y3RzUm93Q2hhbmdlRXZlbnQiIG1zcHJvc"" +
                        ""DpHZW5lcmF0b3JfUm93Q2hhbmdlZE5hbWU9IlByb2R1Y3RzUm93Q2hhbmdlZCIgbXNwcm9wOkdlbmVyY"" +
                        ""XRvcl9Sb3dDbGFzc05hbWU9IlByb2R1Y3RzUm93Ij4NCiAgICAgICAgICA8eHM6Y29tcGxleFR5cGU+D"" +
                        ""QogICAgICAgICAgICA8eHM6c2VxdWVuY2U+DQogICAgICAgICAgICAgIDx4czplbGVtZW50IG5hbWU9I"" +
                        ""lByb2R1Y3RJRCIgbXNkYXRhOlJlYWRPbmx5PSJ0cnVlIiBtc2RhdGE6QXV0b0luY3JlbWVudD0idHJ1Z"" +
                        ""SIgbXNkYXRhOkF1dG9JbmNyZW1lbnRTZWVkPSItMSIgbXNkYXRhOkF1dG9JbmNyZW1lbnRTdGVwPSItM"" +
                        ""SIgbXNwcm9wOkdlbmVyYXRvcl9Db2x1bW5WYXJOYW1lSW5UYWJsZT0iY29sdW1uUHJvZHVjdElEIiBtc"" +
                        ""3Byb3A6R2VuZXJhdG9yX0NvbHVtblByb3BOYW1lSW5Sb3c9IlByb2R1Y3RJRCIgbXNwcm9wOkdlbmVyY"" +
                        ""XRvcl9Db2x1bW5Qcm9wTmFtZUluVGFibGU9IlByb2R1Y3RJRENvbHVtbiIgbXNwcm9wOkdlbmVyYXRvc"" +
                        ""l9Vc2VyQ29sdW1uTmFtZT0iUHJvZHVjdElEIiB0eXBlPSJ4czppbnQiIC8+DQogICAgICAgICAgICAgI"" +
                        ""Dx4czplbGVtZW50IG5hbWU9IlByb2R1Y3ROYW1lIiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtblZhck5hb"" +
                        ""WVJblRhYmxlPSJjb2x1bW5Qcm9kdWN0TmFtZSIgbXNwcm9wOkdlbmVyYXRvcl9Db2x1bW5Qcm9wTmFtZ"" +
                        ""UluUm93PSJQcm9kdWN0TmFtZSIgbXNwcm9wOkdlbmVyYXRvcl9Db2x1bW5Qcm9wTmFtZUluVGFibGU9I"" +
                        ""lByb2R1Y3ROYW1lQ29sdW1uIiBtc3Byb3A6R2VuZXJhdG9yX1VzZXJDb2x1bW5OYW1lPSJQcm9kdWN0T"" +
                        ""mFtZSI+DQogICAgICAgICAgICAgICAgPHhzOnNpbXBsZVR5cGU+DQogICAgICAgICAgICAgICAgICA8e"" +
                        ""HM6cmVzdHJpY3Rpb24gYmFzZT0ieHM6c3RyaW5nIj4NCiAgICAgICAgICAgICAgICAgICAgPHhzOm1he"" +
                        ""Exlbmd0aCB2YWx1ZT0iNDAiIC8+DQogICAgICAgICAgICAgICAgICA8L3hzOnJlc3RyaWN0aW9uPg0KI"" +
                        ""CAgICAgICAgICAgICAgIDwveHM6c2ltcGxlVHlwZT4NCiAgICAgICAgICAgICAgPC94czplbGVtZW50P"" +
                        ""g0KICAgICAgICAgICAgICA8eHM6ZWxlbWVudCBuYW1lPSJTdXBwbGllcklEIiBtc3Byb3A6R2VuZXJhd"" +
                        ""G9yX0NvbHVtblZhck5hbWVJblRhYmxlPSJjb2x1bW5TdXBwbGllcklEIiBtc3Byb3A6R2VuZXJhdG9yX"" +
                        ""0NvbHVtblByb3BOYW1lSW5Sb3c9IlN1cHBsaWVySUQiIG1zcHJvcDpHZW5lcmF0b3JfQ29sdW1uUHJvc"" +
                        ""E5hbWVJblRhYmxlPSJTdXBwbGllcklEQ29sdW1uIiBtc3Byb3A6R2VuZXJhdG9yX1VzZXJDb2x1bW5OY"" +
                        ""W1lPSJTdXBwbGllcklEIiB0eXBlPSJ4czppbnQiIG1pbk9jY3Vycz0iMCIgLz4NCiAgICAgICAgICAgI"" +
                        ""CAgPHhzOmVsZW1lbnQgbmFtZT0iQ2F0ZWdvcnlJRCIgbXNwcm9wOkdlbmVyYXRvcl9Db2x1bW5WYXJOY"" +
                        ""W1lSW5UYWJsZT0iY29sdW1uQ2F0ZWdvcnlJRCIgbXNwcm9wOkdlbmVyYXRvcl9Db2x1bW5Qcm9wTmFtZ"" +
                        ""UluUm93PSJDYXRlZ29yeUlEIiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtblByb3BOYW1lSW5UYWJsZT0iQ"" +
                        ""2F0ZWdvcnlJRENvbHVtbiIgbXNwcm9wOkdlbmVyYXRvcl9Vc2VyQ29sdW1uTmFtZT0iQ2F0ZWdvcnlJR"" +
                        ""CIgdHlwZT0ieHM6aW50IiBtaW5PY2N1cnM9IjAiIC8+DQogICAgICAgICAgICAgIDx4czplbGVtZW50I"" +
                        ""G5hbWU9IlF1YW50aXR5UGVyVW5pdCIgbXNwcm9wOkdlbmVyYXRvcl9Db2x1bW5WYXJOYW1lSW5UYWJsZ"" +
                        ""T0iY29sdW1uUXVhbnRpdHlQZXJVbml0IiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtblByb3BOYW1lSW5Sb"" +
                        ""3c9IlF1YW50aXR5UGVyVW5pdCIgbXNwcm9wOkdlbmVyYXRvcl9Db2x1bW5Qcm9wTmFtZUluVGFibGU9I"" +
                        ""lF1YW50aXR5UGVyVW5pdENvbHVtbiIgbXNwcm9wOkdlbmVyYXRvcl9Vc2VyQ29sdW1uTmFtZT0iUXVhb"" +
                        ""nRpdHlQZXJVbml0IiBtaW5PY2N1cnM9IjAiPg0KICAgICAgICAgICAgICAgIDx4czpzaW1wbGVUeXBlP"" +
                        ""g0KICAgICAgICAgICAgICAgICAgPHhzOnJlc3RyaWN0aW9uIGJhc2U9InhzOnN0cmluZyI+DQogICAgI"" +
                        ""CAgICAgICAgICAgICAgIDx4czptYXhMZW5ndGggdmFsdWU9IjIwIiAvPg0KICAgICAgICAgICAgICAgI"" +
                        ""CAgPC94czpyZXN0cmljdGlvbj4NCiAgICAgICAgICAgICAgICA8L3hzOnNpbXBsZVR5cGU+DQogICAgI"" +
                        ""CAgICAgICAgIDwveHM6ZWxlbWVudD4NCiAgICAgICAgICAgICAgPHhzOmVsZW1lbnQgbmFtZT0iVW5pd"" +
                        ""FByaWNlIiBtc3Byb3A6R2VuZXJhdG9yX0NvbHVtblZhck5hbWVJblRhYmxlPSJjb2x1bW5Vbml0UHJpY"" +
                        ""2UiIG1zcHJvcDpHZW5lcmF0b3JfQ29sdW1uUHJvcE5hbWVJblJvdz0iVW5pdFByaWNlIiBtc3Byb3A6R"" +
                        ""2VuZXJhdG9yX0NvbHVtblByb3BOYW1lSW5UYWJsZT0iVW5pdFByaWNlQ29sdW1uIiBtc3Byb3A6R2VuZ"" +
                        ""XJhdG9yX1VzZXJDb2x1bW5OYW1lPSJVbml0UHJpY2UiIHR5cGU9InhzOmRlY2ltYWwiIG1pbk9jY3Vyc"" +
                        ""z0iMCIgLz4NCiAgICAgICAgICAgICAgPHhzOmVsZW1lbnQgbmFtZT0iVW5pdHNJblN0b2NrIiBtc3Byb"" +
                        ""3A6R2VuZXJhdG9yX0NvbHVtblZhck5hbWVJblRhYmxlPSJjb2x1bW5Vbml0c0luU3RvY2siIG1zcHJvc"" +
                        ""DpHZW5lcmF0b3JfQ29sdW1uUHJvcE5hbWVJblJvdz0iVW5pdHNJblN0b2NrIiBtc3Byb3A6R2VuZXJhd"" +
                        ""G9yX0NvbHVtblByb3BOYW1lSW5UYWJsZT0iVW5pdHNJblN0b2NrQ29sdW1uIiBtc3Byb3A6R2VuZXJhd"" +
                        ""G9yX1VzZXJDb2x1bW5OYW1lPSJVbml0c0luU3RvY2siIHR5cGU9InhzOnNob3J0IiBtaW5PY2N1cnM9I"" +
                        ""jAiIC8+DQogICAgICAgICAgICAgIDx4czplbGVtZW50IG5hbWU9IlVuaXRzT25PcmRlciIgbXNwcm9wO"" +
                        ""kdlbmVyYXRvcl9Db2x1bW5WYXJOYW1lSW5UYWJsZT0iY29sdW1uVW5pdHNPbk9yZGVyIiBtc3Byb3A6R"" +
                        ""2VuZXJhdG9yX0NvbHVtblByb3BOYW1lSW5Sb3c9IlVuaXRzT25PcmRlciIgbXNwcm9wOkdlbmVyYXRvc"" +
                        ""l9Db2x1bW5Qcm9wTmFtZUluVGFibGU9IlVuaXRzT25PcmRlckNvbHVtbiIgbXNwcm9wOkdlbmVyYXRvc"" +
                        ""l9Vc2VyQ29sdW1uTmFtZT0iVW5pdHNPbk9yZGVyIiB0eXBlPSJ4czpzaG9ydCIgbWluT2NjdXJzPSIwI"" +
                        ""iAvPg0KICAgICAgICAgICAgICA8eHM6ZWxlbWVudCBuYW1lPSJSZW9yZGVyTGV2ZWwiIG1zcHJvcDpHZ"" +
                        ""W5lcmF0b3JfQ29sdW1uVmFyTmFtZUluVGFibGU9ImNvbHVtblJlb3JkZXJMZXZlbCIgbXNwcm9wOkdlb"" +
                        ""mVyYXRvcl9Db2x1bW5Qcm9wTmFtZUluUm93PSJSZW9yZGVyTGV2ZWwiIG1zcHJvcDpHZW5lcmF0b3JfQ"" +
                        ""29sdW1uUHJvcE5hbWVJblRhYmxlPSJSZW9yZGVyTGV2ZWxDb2x1bW4iIG1zcHJvcDpHZW5lcmF0b3JfV"" +
                        ""XNlckNvbHVtbk5hbWU9IlJlb3JkZXJMZXZlbCIgdHlwZT0ieHM6c2hvcnQiIG1pbk9jY3Vycz0iMCIgL"" +
                        ""z4NCiAgICAgICAgICAgICAgPHhzOmVsZW1lbnQgbmFtZT0iRGlzY29udGludWVkIiBtc3Byb3A6R2VuZ"" +
                        ""XJhdG9yX0NvbHVtblZhck5hbWVJblRhYmxlPSJjb2x1bW5EaXNjb250aW51ZWQiIG1zcHJvcDpHZW5lc"" +
                        ""mF0b3JfQ29sdW1uUHJvcE5hbWVJblJvdz0iRGlzY29udGludWVkIiBtc3Byb3A6R2VuZXJhdG9yX0Nvb"" +
                        ""HVtblByb3BOYW1lSW5UYWJsZT0iRGlzY29udGludWVkQ29sdW1uIiBtc3Byb3A6R2VuZXJhdG9yX1VzZ"" +
                        ""XJDb2x1bW5OYW1lPSJEaXNjb250aW51ZWQiIHR5cGU9InhzOmJvb2xlYW4iIC8+DQogICAgICAgICAgI"" +
                        ""CA8L3hzOnNlcXVlbmNlPg0KICAgICAgICAgIDwveHM6Y29tcGxleFR5cGU+DQogICAgICAgIDwveHM6Z"" +
                        ""WxlbWVudD4NCiAgICAgIDwveHM6Y2hvaWNlPg0KICAgIDwveHM6Y29tcGxleFR5cGU+DQogICAgPHhzO"" +
                        ""nVuaXF1ZSBuYW1lPSJDb25zdHJhaW50MSIgbXNkYXRhOlByaW1hcnlLZXk9InRydWUiPg0KICAgICAgP"" +
                        ""HhzOnNlbGVjdG9yIHhwYXRoPSIuLy9tc3RuczpDYXRlZ29yaWVzIiAvPg0KICAgICAgPHhzOmZpZWxkI"" +
                        ""HhwYXRoPSJtc3RuczpDYXRlZ29yeUlEIiAvPg0KICAgIDwveHM6dW5pcXVlPg0KICAgIDx4czp1bmlxd"" +
                        ""WUgbmFtZT0iUHJvZHVjdHNfQ29uc3RyYWludDEiIG1zZGF0YTpDb25zdHJhaW50TmFtZT0iQ29uc3RyY"" +
                        ""WludDEiIG1zZGF0YTpQcmltYXJ5S2V5PSJ0cnVlIj4NCiAgICAgIDx4czpzZWxlY3RvciB4cGF0aD0iL"" +
                        ""i8vbXN0bnM6UHJvZHVjdHMiIC8+DQogICAgICA8eHM6ZmllbGQgeHBhdGg9Im1zdG5zOlByb2R1Y3RJR"" +
                        ""CIgLz4NCiAgICA8L3hzOnVuaXF1ZT4NCiAgPC94czplbGVtZW50Pg0KICA8eHM6YW5ub3RhdGlvbj4NC"" +
                        ""iAgICA8eHM6YXBwaW5mbz4NCiAgICAgIDxtc2RhdGE6UmVsYXRpb25zaGlwIG5hbWU9IkZLX1Byb2R1Y"" +
                        ""3RzX0NhdGVnb3JpZXMiIG1zZGF0YTpwYXJlbnQ9IkNhdGVnb3JpZXMiIG1zZGF0YTpjaGlsZD0iUHJvZ"" +
                        ""HVjdHMiIG1zZGF0YTpwYXJlbnRrZXk9IkNhdGVnb3J5SUQiIG1zZGF0YTpjaGlsZGtleT0iQ2F0ZWdvc"" +
                        ""nlJRCIgbXNwcm9wOkdlbmVyYXRvcl9Vc2VyQ2hpbGRUYWJsZT0iUHJvZHVjdHMiIG1zcHJvcDpHZW5lc"" +
                        ""mF0b3JfQ2hpbGRQcm9wTmFtZT0iR2V0UHJvZHVjdHNSb3dzIiBtc3Byb3A6R2VuZXJhdG9yX1VzZXJQY"" +
                        ""XJlbnRUYWJsZT0iQ2F0ZWdvcmllcyIgbXNwcm9wOkdlbmVyYXRvcl9Vc2VyUmVsYXRpb25OYW1lPSJGS"" +
                        ""19Qcm9kdWN0c19DYXRlZ29yaWVzIiBtc3Byb3A6R2VuZXJhdG9yX1JlbGF0aW9uVmFyTmFtZT0icmVsY"" +
                        ""XRpb25GS19Qcm9kdWN0c19DYXRlZ29yaWVzIiBtc3Byb3A6R2VuZXJhdG9yX1BhcmVudFByb3BOYW1lP"" +
                        ""SJDYXRlZ29yaWVzUm93IiAvPg0KICAgIDwveHM6YXBwaW5mbz4NCiAgPC94czphbm5vdGF0aW9uPg0KP"" +
                        ""C94czpzY2hlbWE+"";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 50F;
            this.topMarginBand1.Name = ""topMarginBand1"";
            // 
            // detailBand1
            // 
            this.detailBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.table1});
            this.detailBand1.HeightF = 68.75F;
            this.detailBand1.Name = ""detailBand1"";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Name = ""bottomMarginBand1"";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.label1});
            this.ReportHeader.HeightF = 30.20833F;
            this.ReportHeader.Name = ""ReportHeader"";
            // 
            // PageHeader
            // 
            this.PageHeader.HeightF = 21.875F;
            this.PageHeader.Name = ""PageHeader"";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.label3,
                        this.label2});
            this.GroupHeader1.HeightF = 50F;
            this.GroupHeader1.Name = ""GroupHeader1"";
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail});
            this.DetailReport.DataMember = ""Products"";
            this.DetailReport.Level = 0;
            this.DetailReport.Name = ""DetailReport"";
            // 
            // table1
            // 
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table1.Name = ""table1"";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.tableRow1});
            this.table1.SizeF = new System.Drawing.SizeF(300F, 25F);
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.tableCell1,
                        this.tableCell2,
                        this.tableCell3});
            this.tableRow1.Name = ""tableRow1"";
            this.tableRow1.Weight = 1D;
            // 
            // tableCell1
            // 
            this.tableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding(""Text"", null, ""Products.ProductName"")});
            this.tableCell1.Name = ""tableCell1"";
            this.tableCell1.Text = ""tableCell1"";
            this.tableCell1.Weight = 1D;
            // 
            // tableCell2
            // 
            this.tableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding(""Text"", null, ""Products.UnitPrice"")});
            this.tableCell2.Name = ""tableCell2"";
            this.tableCell2.Text = ""tableCell2"";
            this.tableCell2.Weight = 1D;
            // 
            // tableCell3
            // 
            this.tableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding(""Text"", null, ""Products.QuantityPerUnit"")});
            this.tableCell3.Name = ""tableCell3"";
            this.tableCell3.Text = ""tableCell3"";
            this.tableCell3.Weight = 1D;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font(""Times New Roman"", 12F, System.Drawing.FontStyle.Bold);
            this.label1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.label1.Name = ""label1"";
            this.label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label1.SizeF = new System.Drawing.SizeF(352.0833F, 23F);
            this.label1.StylePriority.UseFont = false;
            this.label1.Text = ""NorthWind Product-Category"";
            // 
            // label3
            // 
            this.label3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding(""Text"", null, ""Categories.Description"")});
            this.label3.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.label3.Name = ""label3"";
            this.label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label3.SizeF = new System.Drawing.SizeF(550F, 45.91667F);
            this.label3.Text = ""label3"";
            // 
            // label2
            // 
            this.label2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding(""Text"", null, ""Categories.CategoryName"")});
            this.label2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.label2.Name = ""label2"";
            this.label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.label2.Text = ""label2"";
            // 
            // Detail
            // 
            this.Detail.HeightF = 16.66667F;
            this.Detail.Name = ""Detail"";
            // 
            // xtraReport1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.topMarginBand1,
                        this.detailBand1,
                        this.bottomMarginBand1,
                        this.ReportHeader,
                        this.PageHeader,
                        this.GroupHeader1,
                        this.DetailReport});
            this.DataSourceSchema = resources.GetString(""$this.DataSourceSchema"");
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 50, 100);
            this.Name = ""xtraReport1"";
            this.PageHeight = 1100;
            this.PageWidth = 850;
            this.Version = ""11.2"";
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
";
			list.Add(dpo);

			dpo = new RepxDpo();
			dpo.ID = 2;
			dpo.Command_ID = 34;
			dpo.url = "Report1";
			dpo.repx = @"/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v11.2, Version=11.2.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a</AssemblyFullName>
///   <AssemblyLocation>C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v11.2\11.2.10.0__b88d1754d700e49a\DevExpress.XtraReports.v11.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report1 : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.XRRichText richText1;
        private DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private System.Resources.ResourceManager _resources;
        public Report1() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @""zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFBb0c0TAAAAAP8AAAA+cgBpAGMAaABUAGUAeAB0ADEALgBTAGUAcgBpAGEAbABpAHoAYQBiAGwAZQBSAHQAZgBTAHQAcgBpAG4AZwAAAAAAAdgDZXdCY0FISUFkQUJtQURFQVhBQmhBRzRBY3dCcEFHTUFjQUJuQURFQU1nQTFBRElBRFFBS0FIc0FEUUFLQUZ3QVpnQnZBRzRBZEFCMEFHSUFiQUFOQUFvQWV3QmNBR1lBTUFBZ0FGUUFhUUJ0QUdVQWN3QWdBRTRBWlFCM0FDQUFVZ0J2QUcwQVlRQnVBRHNBZlFBTkFBb0FmUUFOQUFvQWV3QU5BQW9BWEFCakFHOEFiQUJ2QUhJQWRBQmlBR3dBRFFBS0FEc0FEUUFLQUZ3QWNnQmxBR1FBTUFCY0FHY0FjZ0JsQUdVQWJnQXdBRndBWWdCc0FIVUFaUUF3QURzQURRQUtBRndBY2dCbEFHUUFNQUJjQUdjQWNnQmxBR1VBYmdBd0FGd0FZZ0JzQUhVQVpRQXlBRFVBTlFBN0FBMEFDZ0I5QUEwQUNnQjdBRndBY3dCbEFHTUFkQUJrQUZ3QWNBQmhBSElBWkFCY0FIQUFiQUJoQUdrQWJnQmNBSEVBYkFCN0FGd0FaZ0J6QURJQU1BQmNBR01BWmdBeEFDQUFjZ0JwQUdNQWFBQlVBR1VBZUFCMEFERUFmUUJjQUhBQVlRQnlBSDBBRFFBS0FIMEFEUUFLQUE9PQ=="";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.richText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.richText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.richText1,
                        this.label1});
            this.TopMargin.Name = ""TopMargin"";
            // 
            // Detail
            // 
            this.Detail.Name = ""Detail"";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = ""BottomMargin"";
            // 
            // richText1
            // 
            this.richText1.LocationFloat = new DevExpress.Utils.PointFloat(167.7083F, 34.33334F);
            this.richText1.Name = ""richText1"";
            this.richText1.SerializableRtfString = resources.GetString(""richText1.SerializableRtfString"");
            this.richText1.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // label1
            // 
            this.label1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34.33334F);
            this.label1.Name = ""label1"";
            this.label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.label1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.label1.Text = ""label1"";
            // 
            // Report1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.TopMargin,
                        this.Detail,
                        this.BottomMargin});
            this.Name = ""Report1"";
            this.PageHeight = 1100;
            this.PageWidth = 850;
            this.Version = ""11.2"";
            ((System.ComponentModel.ISupportInitialize)(this.richText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
";
			list.Add(dpo);

		}

	}
}
