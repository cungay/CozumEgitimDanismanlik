using System;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Serializing;
using DevExpress.Data.Filtering;
using Ekip.Framework.UI.DevEx.Editors;

namespace Ekip.Framework.UI.DevEx.Grid
{
    public class DxGridView : GridView
    {
        public DxGridView() : this(null)
        {
            IndicatorWidth = 40;
            //OptionsFind.AllowFindPanel = true;
            //OptionsFind.AlwaysVisible = true;
            //OptionsFind.SearchInPreview = true;
        }
        [XtraSerializableProperty, Category("Behavior")]
        public string EmptyDataMessage { get; set; } = string.Empty;

        public DxGridView(GridControl grid) : base(grid) { }

        protected override string ViewName { get { return "DxGridView"; } }

        protected override CriteriaOperator CreateAutoFilterCriterion(GridColumn column, AutoFilterCondition condition,
            object _value, string strVal)
        {
            if (column.ColumnType == typeof(DateTime) && strVal.Length > 0)
            {
                BinaryOperatorType type = BinaryOperatorType.Equal;
                string operand = string.Empty;
                if (strVal.Length > 1)
                {
                    operand = strVal.Substring(0, 2);
                    if (operand.Equals(">=")) type = BinaryOperatorType.GreaterOrEqual;
                    else if (operand.Equals("<=")) type = BinaryOperatorType.LessOrEqual;
                }
                if (type == BinaryOperatorType.Equal)
                {
                    operand = strVal.Substring(0, 1);
                    if (operand.Equals(">")) type = BinaryOperatorType.Greater;
                    else if (operand.Equals("<")) type = BinaryOperatorType.Less;
                }
                if (type != BinaryOperatorType.Equal)
                {
                    string val = strVal.Replace(operand, string.Empty);
                    try
                    {
                        DateTime dt = DateTime.ParseExact(val, "d", column.RealColumnEdit.EditFormat.Format);
                        return new BinaryOperator(column.FieldName, dt, type);
                    }
                    catch { return null; }
                }
            }
            return base.CreateAutoFilterCriterion(column, condition, _value, strVal);
        }

        protected override void RaiseCustomDrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int i = 1;
                if (e.RowHandle > 0) i += e.RowHandle;
                e.Info.DisplayText = i.ToString();
            }
            base.RaiseCustomDrawRowIndicator(e);
        }

        protected override void RaiseCustomDrawEmptyForeground(CustomDrawEventArgs e)
        {
            string empty = this.EmptyDataMessage.Trim().Length > 0 ? this.EmptyDataMessage + "\nYeni giriş için çift tıklatınız." : string.Empty;
            Font f = new Font("Tahoma", 10, FontStyle.Underline);
            Rectangle r = new Rectangle(e.Bounds.Left + 50, e.Bounds.Top + 45, e.Bounds.Width - 5, e.Bounds.Height - 5);
            e.Graphics.DrawString(empty, f, Brushes.Black, r);
            base.RaiseCustomDrawEmptyForeground(e);
        }

        protected override GridColumnCollection CreateColumnCollection() {
            return new DxGridColumnCollection(this);
        }

        public void BindLookUpColumns()
        {
            foreach (DxGridColumn col in Columns)
            {
                if (col.ColumnEdit is RepositoryItemDxLookUpEdit)
                {
                    //((RepositoryItemDxLookUpEdit)col.ColumnEdit).BindListItem(col.ListType, col.ListDescription);
                }
            }
        }
    }
}
