using System;
using System.Collections;
using System.Collections.Generic;

namespace DCSoft.CSharpWriter.Dom.Undo
{
	/// <summary>
	/// �������Ԫ��ϲ���ֲ���
	/// </summary>
	public class XTextUndoCellSpan : XTextUndoBase
	{
        public XTextUndoCellSpan(DomTableCellElement cell, int newRowSpan, int newColSpan)
        {
            myCellElement = cell;
            DomTableElement table = cell.OwnerTable;
            intOldRowSpan = cell.RowSpan;
            intOldColSpan = cell.ColSpan;
            intNewRowSpan = newRowSpan;
            intNewColSpan = newColSpan;

            DomElementList oldOverrideCells = table.GetRange(
                cell.RowIndex,
                cell.ColIndex,
                Math.Max( intOldRowSpan , intNewRowSpan ),
                Math.Max( intOldColSpan , intNewColSpan ), 
                true );
            foreach (DomTableCellElement cell2 in oldOverrideCells)
            {
                _oldCellsContents[cell2] = cell2.Elements.Clone();
            }
        }

        /// <summary>
        /// ��¼�ϲ���Ԫ�������ĸ�����Ԫ�������
        /// </summary>
        internal void LogNewCellsContent()
        {
            DomElementList newOverrideCells =  myCellElement.OwnerTable.GetRange(
                myCellElement.RowIndex ,
                myCellElement.ColIndex,
                Math.Max(intOldRowSpan, intNewRowSpan),
                Math.Max(intOldColSpan, intNewColSpan), 
                true );
            foreach (DomTableCellElement cell2 in newOverrideCells)
            {
                _newCellsContents[cell2] = cell2.Elements.Clone();
            }
        }

        private DomTableCellElement myCellElement = null;
		/// <summary>
		/// ��Ԫ�����
		/// </summary>
		public DomTableCellElement CellElement
		{
			get{ return myCellElement ;}
			set{ myCellElement = value;}
		}
		private int intOldRowSpan = 1 ;
		/// <summary>
		/// ��Ԫ��ɵĿ�����
		/// </summary>
		public int OldRowSpan
		{
			get{ return intOldRowSpan ;}
			set{ intOldRowSpan = value;}
		}
		private int intOldColSpan = 1 ;
		/// <summary>
		/// ��Ԫ��ɵĿ�����
		/// </summary>
		public int OldColSpan
		{
			get{ return intOldColSpan ;}
			set{ intOldColSpan = value;}
		}
		private int intNewRowSpan = 1 ;
		/// <summary>
		/// ��Ԫ���µĿ�����
		/// </summary>
		public int NewRowSpan
		{
			get{ return intNewRowSpan ;}
			set{ intNewRowSpan = value;}
		}
		private int intNewColSpan = 1 ;
		/// <summary>
		/// ��Ԫ���µĿ�����
		/// </summary>
		public int NewColSpan
		{
			get{ return intNewColSpan ;}
			set{ intNewColSpan = value;}
		}
        /// <summary>
        /// δ���õ�Ԫ��ϲ���Ϣǰ�ĵ�Ԫ�������б�
        /// </summary>
        private Dictionary<DomTableCellElement, DomElementList> _oldCellsContents
            = new Dictionary<DomTableCellElement, DomElementList>();
        /// <summary>
        /// ���õ�Ԫ��ϲ���Ϣ��ĵ�Ԫ�������б�
        /// </summary>
        private Dictionary<DomTableCellElement, DomElementList> _newCellsContents
            = new Dictionary<DomTableCellElement, DomElementList>();

        private void SetCellContent(Dictionary<DomTableCellElement, DomElementList> list)
        {
            
        }

		/// <summary>
		/// ִ�г�������
		/// </summary>
        public override void Undo(DCSoft.CSharpWriter.Undo.XUndoEventArgs args)
		{
			Execute( true );
		}
		/// <summary>
		/// ִ���ظ�����
		/// </summary>
        public override void Redo(DCSoft.CSharpWriter.Undo.XUndoEventArgs args)
		{
			Execute( false );
		}

		/// <summary>
		/// ִ�в���
		/// </summary>
		/// <param name="undo">�Ƿ�ִ�г�������</param>
		private void Execute( bool undo )
		{
			if( myCellElement != null )
			{
				if( intOldRowSpan != intNewRowSpan || intOldColSpan != intNewColSpan )
				{
					if( undo )
					{
						if( intOldRowSpan >=1 && intOldColSpan >= 1 )
						{
                            myCellElement.EditorSetCellSpan(intOldRowSpan, intOldColSpan, false , _oldCellsContents );

                            //myCellElement.OwnerTable.InvalidateView();
                            //myCellElement.RowSpan = intOldRowSpan ;
                            //myCellElement.ColSpan = intOldColSpan ;
                            //myCellElement.OwnerTable.ExecuteLayout();
							//myCellElement.OwnerDocument.SetCurrentElement( myCellElement );
							
                            //myCellElement.OwnerDocument.Modified = true;
						}
					}
					else
					{
						if( intNewRowSpan >= 1 && intNewColSpan >= 1 )
						{
                            myCellElement.EditorSetCellSpan(intNewRowSpan, intNewColSpan, false , _newCellsContents );

                            //myCellElement.OwnerTable.InvalidateView();
                            //myCellElement.RowSpan = intNewRowSpan ;
                            //myCellElement.ColSpan = intNewColSpan ;
                            //myCellElement.OwnerTable.ExecuteLayout();
							//myCellElement.OwnerDocument.SetCurrentElement( myCellElement );

							//myCellElement.OwnerDocument.Modified = true;
						}
					}
				}
			}
		}
	}
}