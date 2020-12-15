using System;



namespace DCSoft.CSharpWriter.Dom
{
	/// <summary>
	/// ��ǩ����
	/// </summary>
    [Serializable()]
    [System.Xml.Serialization.XmlType("XBookMark")]
	public class DomBookmark : DomElement
	{
		/// <summary>
		/// ��ʼ������
		/// </summary>
		public DomBookmark()
		{
		}

		private string strName = null;
		/// <summary>
		/// ��������
		/// </summary>
		public string Name
		{
			get{ return strName ;}
			set{ strName = value;}
		}

        public override void HandleDocumentEvent(DocumentEventArgs args)
        {
            if (args.Style == DocumentEventStyles.MouseMove)
            {
                args.Cursor = System.Windows.Forms.Cursors.Arrow;
                args.Tooltip = "Bookmark \"" + strName + "\"";
            }
            base.HandleDocumentEvent(args);
        }

        //public override void OnMouseMove(DocumentEventArgs args)
        //{
        //    args.Cursor = System.Windows.Forms.Cursors.Arrow ;
        //    args.Tooltip = "Bookmark \"" + strName + "\"" ;
        //}

		/// <summary>
		/// ������ǩ
		/// </summary>
		public void Active()
		{
			System.Drawing.RectangleF bounds = this.AbsBounds ;
			if( this.OwnerDocument.EditorControl != null )
			{
				this.OwnerDocument.Content.AutoClearSelection = true ;
				this.OwnerDocument.Content.MoveSelectStart( this );
				this.OwnerDocument.EditorControl.ScrollToView(
					(int )bounds.Left ,
                    (int)bounds.Top,
                    (int)bounds.Width,
                    (int)bounds.Height,
                    DCSoft.WinForms.ScrollToViewStyle.Middle );
			}
		}

		/// <summary>
		/// ����������ݵ�HTML�ĵ���
		/// </summary>
		/// <param name="writer">HTML�ĵ���д��</param>
        public override void WriteHTML(DCSoft.CSharpWriter.Html.WriterHtmlDocumentWriter writer)
		{
			writer.WriteStartElement("a");
			writer.WriteAttributeString("name" , this.Name );
			writer.WriteEndElement();
		}

        public override void WriteRTF( DCSoft.CSharpWriter.RTF.RTFContentWriter writer)
        {
            writer.WriteStartBookmark(this.Name);
            writer.WriteEndBookmark(this.Name);
        }
	}
}