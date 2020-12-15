﻿/*****************************
CSharpWriter is a RTF style Text writer control written by C#,Currently,
it use <LGPL> license.More than RichTextBox, 
It is provide a DOM to access every thing in document and save in XML format.
It can use in WinForm.NET ,WPF,Console application.Any idea about CSharpWriter 
can write to 28348092@qq.com(or yyf9989@hotmail.com). 
Project web site is [https://github.com/dcsoft-yyf/CSharpWriter].
*****************************///@DCHC@
/*
 * 
 *   DCSoft RTF DOM v1.0
 *   Author : Yuan yong fu.
 *   Email  : yyf9989@hotmail.com
 *   blog site:http://www.cnblogs.com/xdesigner.
 * 
 */



using System;
using System.Text;

namespace DCSoft.RTF
{
    /// <summary>
    /// shape group
    /// </summary>
    [Serializable()]
    public class RTFDomShapeGroup : RTFDomElement
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        public RTFDomShapeGroup()
        {
        }

        private StringAttributeCollection myExtAttrbutes = new StringAttributeCollection();
        /// <summary>
        /// extern attributes
        /// </summary>
        public StringAttributeCollection ExtAttrbutes
        {
            get
            {
                return myExtAttrbutes;
            }
            set
            {
                myExtAttrbutes = value;
            }
        }

        public override string ToString()
        {
            return "ShapeGroup";
        }
    }
}
