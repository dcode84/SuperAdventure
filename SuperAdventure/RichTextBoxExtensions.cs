using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, bool addNewLine = false)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            if (addNewLine == true)
            {
                box.AppendText(Environment.NewLine);
            }
        }

        public static void AppendText(this RichTextBox box, string text, Color color, bool addNewLine = false)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            if (addNewLine == true)
            {
                box.AppendText(Environment.NewLine);
            }
        }
    }
}
