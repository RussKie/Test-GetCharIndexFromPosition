using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            const int DefaultTextBoxHeight = 23;
            const int DefaultRichTextBoxHeight = 96;

            var controls = new TextBoxBase[] 
            {
                // single line
                new TextBox { Multiline = false, Text = "eöü****#*$&@&$4ä1452" },
                new TextBox { Size = new Size(50, DefaultTextBoxHeight), Multiline = false, Text = "eöü****#*$&@&$4ä1452" },
                new TextBox { Size = new Size(250, DefaultTextBoxHeight), Multiline = false, Text = "eöü****#*$&@&$4ä1452" },
                new RichTextBox { Multiline = false, Text = "eöü****#*$&@&$4ä1452" },
                new RichTextBox { Size = new Size(50, DefaultRichTextBoxHeight), Multiline = false, Text = "eöü****#*$&@&$4ä1452" },
                new RichTextBox { Size = new Size(250, DefaultRichTextBoxHeight), Multiline = false, Text = "eöü****#*$&@&$4ä1452" },
                new MaskedTextBox { Multiline = false, Text = "eöü****#*$&@&$4ä1452" },
                new MaskedTextBox { Size = new Size(50, DefaultTextBoxHeight), Multiline = false, Text = "eöü****#*$&@&$4ä1452" },
                new MaskedTextBox { Size = new Size(250, DefaultTextBoxHeight), Multiline = false, Text = "eöü****#*$&@&$4ä1452" },

                // multi line
                new TextBox { Multiline = true, Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new TextBox { Size = new Size(50, DefaultTextBoxHeight), Multiline = true, Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new TextBox { Size = new Size(250, DefaultTextBoxHeight), Multiline = true, Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new RichTextBox { Multiline = false, Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new RichTextBox { Size = new Size(50, DefaultRichTextBoxHeight), Multiline = true, Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new RichTextBox { Size = new Size(250, DefaultRichTextBoxHeight), Multiline = true, Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                // MaskedTextBox doesn't support multi line https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.maskedtextbox.multiline?view=netframework-4.8
                //new MaskedTextBox { Multiline = true, Text = "eöü****#*$&@&$4ä1452" },
                //new MaskedTextBox { Size = new Size(50, DefaultTextBoxHeight), Multiline = true, Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                //new MaskedTextBox { Size = new Size(250, DefaultTextBoxHeight), Multiline = true, Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },

                // single line orphans
                new TextBox { Tag = "Orphan", Text = "eöü****#*$&@&$4ä1452" },
                new TextBox { Size = new Size(50, DefaultTextBoxHeight), Tag = "Short Orphan", Text = "eöü****#*$&@&$4ä1452" },
                new TextBox { Size = new Size(250, DefaultTextBoxHeight), Tag = "Long Orphan", Text = "eöü****#*$&@&$4ä1452" },
                new RichTextBox { Tag = "Orphan", Text = "eöü****#*$&@&$4ä1452" },
                new RichTextBox { Size = new Size(50, DefaultRichTextBoxHeight), Tag = "Short Orphan", Text = "eöü****#*$&@&$4ä1452" },
                new RichTextBox { Size = new Size(250, DefaultRichTextBoxHeight), Tag = "Long Orphan", Text = "eöü****#*$&@&$4ä1452" },
                new MaskedTextBox { Tag = "Orphan", Text = "eöü****#*$&@&$4ä1452" },
                new MaskedTextBox { Size = new Size(50, DefaultTextBoxHeight), Tag = "Short Orphan", Text = "eöü****#*$&@&$4ä1452" },
                new MaskedTextBox { Size = new Size(250, DefaultTextBoxHeight), Tag = "Long Orphan", Text = "eöü****#*$&@&$4ä1452" },

                // multi line orphans
                new TextBox { Multiline = true, Tag = "Orphan", Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new TextBox { Size = new Size(50, DefaultTextBoxHeight), Multiline = true, Tag = "Short Orphan", Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new TextBox { Size = new Size(250, DefaultTextBoxHeight), Multiline = true, Tag = "Long Orphan", Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new RichTextBox { Multiline = false, Tag = "Orphan", Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new RichTextBox { Size = new Size(50, DefaultRichTextBoxHeight), Multiline = true, Tag = "Short Orphan", Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                new RichTextBox { Size = new Size(250, DefaultRichTextBoxHeight), Multiline = true, Tag = "Long Orphan", Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                // MaskedTextBox doesn't support multi line https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.maskedtextbox.multiline?view=netframework-4.8
                //new MaskedTextBox { Multiline = true, Tag = "Orphan", Text = "eöü****#*$&@&$4ä1452" },
                //new MaskedTextBox { Size = new Size(50, DefaultTextBoxHeight), Multiline = true, Tag = "Short Orphan", Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
                //new MaskedTextBox { Size = new Size(250, DefaultTextBoxHeight), Multiline = true, Tag = "Long Orphan", Text = "eöü****#*$&@&$4ä1452\r\n01234567890123456789" },
            };

            Controls.Add(new FlowLayoutPanel { Dock = DockStyle.Fill });
            foreach (var c in controls)
            {
                if (c.Tag == null)
                {
                    Controls[0]. Controls.Add(c);
                }

                Test(c);
            }

            //Environment.Exit(0);

            return;

            void Test(TextBoxBase control)
            {
                var s = control.Text;

                Debug.Write($"---- {control.GetType().Name} .Size={control.Size} .Multiline={control.Multiline}");
                Debug.WriteIf(!string.IsNullOrWhiteSpace((string)control.Tag), $" .Tag={control.Tag}");
                Debug.WriteLine($" .Text={s.Replace("\\", "\\\\")}");

                for (int i = 0; i < s.Length; i++)
                {
                    Point expect = control.GetPositionFromCharIndex(i);
                    int index = control.GetCharIndexFromPosition(new Point(expect.X, expect.Y));

                    //var warning = i != index ? "    <---- different!" : "";
                    //Debug.WriteLine($"symbol: {s[i]}, position: {expect}, i: {i}, index: {index}{warning}");
                    Debug.WriteLineIf(i != index, $"    symbol: {s[i]}, position: {expect}, i: {i}, index: {index}    <---- different!");
                }

                Debug.WriteLine("");
                Debug.WriteLine("");
            }
        }



    }
}
