﻿/*****************************
CSharpWriter is a RTF style Text writer control written by C#,Currently,
it use <LGPL> license.More than RichTextBox, 
It is provide a DOM to access every thing in document and save in XML format.
It can use in WinForm.NET ,WPF,Console application.Any idea about CSharpWriter 
can write to 28348092@qq.com(or yyf9989@hotmail.com). 
Project web site is [https://github.com/dcsoft-yyf/CSharpWriter].
*****************************///@DCHC@
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.CSharpWriter.Controls
{
    public partial class dlgErrorViewSource : Form
    {
        public dlgErrorViewSource()
        {
            InitializeComponent();
        }

        public string ReportSource
        {
            get
            {
                return txtSource.Text;
            }
            set
            {
                txtSource.Text = value;
            }
        }

        private void dlgErrorViewSource_Load(object sender, EventArgs e)
        {

        }
    }
}
