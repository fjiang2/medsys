﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JRichTextBox : JWinControl
    {

        public JRichTextBox(RichTextBox textBox, DataField field)
            : base(textBox, field)
        {
        }

        public override void Fill()
        {
            base.Fill();

            Control.Text = value.ToString().Trim();
            return;
        }

        public override void Collect()
        {
            value = Convert(Control.Text);
            Control.Text = value.ToString();
            base.Collect();
            return;
        }



        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int GetCaretPos(ref Point lpPoint);

    
        private static int GetCorrection(RichTextBox e, int index)
        {
            Point pt1 = Point.Empty;
            GetCaretPos(ref pt1);
            Point pt2 = e.GetPositionFromCharIndex(index);

            if (pt1 != pt2)
                return 1;
            else
                return 0;
        }

        public static int Line(RichTextBox e)
        {
            return Line(e, e.SelectionStart);
        }
        
        public static int Column(RichTextBox e)
        {
            return Column(e, e.SelectionStart);
        }

        public static int Line(RichTextBox e, int index)
        {
            int correction = GetCorrection(e, index);
            return e.GetLineFromCharIndex(index) - correction + 1;
        }

        public static int Column(RichTextBox e, int index1)
        {
            int correction = GetCorrection(e, index1);
            Point p = e.GetPositionFromCharIndex(index1 - correction);

            if (p.X == 1)
                return 1;

            p.X = 0;
            int index2 = e.GetCharIndexFromPosition(p);

            int col = index1 - index2 + 1;

            return col;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private const uint EM_SETSEL = 0xB1;
        private const uint EM_GETLINECOUNT = 0xBA;
        private const uint EM_LINEINDEX = 0xBB;

        /// <summary>
        /// Zero based line number
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="line"></param>
        public static void GotoLine(RichTextBox rtb, int line)
        {
            int chrsToStart;
            int chrsToEnd;
            int lineCount;

            //Get the line count in the RichTextBox
            lineCount = SendMessage(rtb.Handle, EM_GETLINECOUNT, (int)0, (int)0);

            //Make sure line# isn't greater than total lines
            if (line > lineCount - 1)
                return;

            chrsToStart = SendMessage(rtb.Handle, EM_LINEINDEX, line, (int)0);
            chrsToEnd = SendMessage(rtb.Handle, EM_LINEINDEX,  line + 1 , (int)0);
            rtb.Focus();

            SendMessage(rtb.Handle, EM_SETSEL, chrsToStart, chrsToEnd);
        }        

    }
    
}
