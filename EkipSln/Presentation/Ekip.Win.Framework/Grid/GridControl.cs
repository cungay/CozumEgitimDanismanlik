using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Ekip.Framework.UI.DevEx.Grid
{
    public class DxGridControl : GridControl
    {
        public delegate void RowClickHandler(object sender, DxRowClickArgs e);
        public delegate void RowDeleteHandler(object sender, DxRowClickArgs e);
        [Browsable(true), Category("Action")]
        public event RowClickHandler OnRowClick = null;
        [Browsable(true), Category("Action")]
        public event RowDeleteHandler OnRowDelete = null;

        protected GridHitInfo hitInfo = null;
        protected DxGridView DxView { get { return this.FocusedView as DxGridView; } }
        protected override BaseView CreateDefaultView() { return CreateView("DxGridView"); }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new DxGridViewInfoRegistrator());
            collection.Add(new DxBandedGridViewInfoRegistrator());
        }
        protected override ControlNavigator CreateEmbeddedNavigator()
        {
            GridControlNavigator nav = new DxNavigator(this);
            nav.SizeChanged += new EventHandler(OnEmbeddedNavigator_SizeChanged);
            nav.ButtonClick += new NavigatorButtonClickEventHandler(nav_ButtonClick);
            nav.Visible = false;
            nav.TabStop = false;
            nav.Buttons.Append.Hint = "Yeni Ekle";
            return nav;
        }
        protected void nav_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove) e.Handled = !DeleteRows();
        }
        public bool DeleteRows()
        {
            bool deleted = true;
            //TaskDialog dlg = new TaskDialog();
            //dlg.WindowTitle = "Onay";
            //dlg.Content = "Silmek istediğinizden emin misiniz?";
            //dlg.MainIcon = TaskDialogIcon.Shield;
            //List<TaskDialogButton> buttons = new List<TaskDialogButton>();
            //buttons.Add(new TaskDialogButton(0, "Evet"));
            //buttons.Add(new TaskDialogButton(1, "Hayır"));
            //dlg.Buttons = buttons.ToArray();
            //if (dlg.Show(this.Parent) == 1) return false;
            //int[] selectedRows = DxView.GetSelectedRows();
            //if (selectedRows.Length > 0)
            //{
            //    if (OnRowDelete != null)
            //    {
            //        DxRowClickArgs arg = new DxRowClickArgs(DxView.GetRow(DxView.FocusedRowHandle), DxView.FocusedRowHandle, selectedRows);
            //        OnRowDelete(this, arg);
            //        deleted = !arg.Cancel;
            //    }
            //}
            return deleted;
        }

        #region RaiseEditorKeyDown
        protected override void RaiseEditorKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                PerformNavigation(e.Modifiers == Keys.Shift);
            }
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.None)
            {
                BaseEdit editor = FocusedView.ActiveEditor;
                if (editor != null)
                    editor.EditValue = null;
                e.Handled = true;
            }
            base.RaiseEditorKeyDown(e);
        }
        #endregion

        #region OnKeyDown
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                PerformNavigation(e.Modifiers == Keys.Shift);
            }
            base.OnKeyDown(e);
        }
        #endregion

        #region Navigation Algorithm
        private void PerformNavigation(bool backward)
        {
            int delta;
            int nextRowHandle = GetNextRowHandle(backward, out delta);
            GridColumn col = GetNextColumn(backward, delta);
            (this.DefaultView as GridView).FocusedColumn = col;
            (this.DefaultView as GridView).FocusedRowHandle = nextRowHandle;
        }
        private int GetNextRowHandle(bool backward, out int delta)
        {
            delta = 0;
            int focusedRowHandle = (this.DefaultView as GridView).FocusedRowHandle;
            focusedRowHandle += backward ? -1 : 1;
            if (focusedRowHandle < 0)
            {
                delta = -1;
                return (this.DefaultView as GridView).DataRowCount - 1;
            }
            if (focusedRowHandle == FocusedView.DataRowCount)
            {
                delta = 1;
                return 0;
            }
            return focusedRowHandle;
        }
        private GridColumn GetNextColumn(bool backward, int delta)
        {
            int visibleIndex = (this.DefaultView as GridView).FocusedColumn.VisibleIndex;
            visibleIndex += delta;
            if (visibleIndex < 0)
                visibleIndex = (this.DefaultView as GridView).VisibleColumns.Count - 1;
            if (visibleIndex == (this.DefaultView as GridView).VisibleColumns.Count)
                visibleIndex = 0;
            return (this.DefaultView as GridView).VisibleColumns[visibleIndex];
        }
        #endregion      

        protected override bool ProcessGridKeys(KeyEventArgs keys, bool onlyEvent)
        {
            GridView view = FocusedView as GridView;
            if (keys.KeyData == Keys.Delete)
            {
                if (DeleteRows()) view.DeleteSelectedRows();
                keys.Handled = true;
            }
            if (keys.KeyData == Keys.Insert)
            {
                view.AddNewRow();
                keys.Handled = true;
            }
            return base.ProcessGridKeys(keys, onlyEvent);
        }

        protected override void OnMouseDown(MouseEventArgs ev)
        {
            hitInfo = DxView.CalcHitInfo(ev.X, ev.Y);
            base.OnMouseDown(ev);
        }
        protected override void OnDoubleClick(EventArgs ev)
        {
            if (hitInfo.InRow || hitInfo.HitTest == GridHitTest.EmptyRow)
            {
                if (OnRowClick != null)
                {
                    object row = DxView.GetRow(hitInfo.RowHandle);
                    OnRowClick(this, new DxRowClickArgs(row, DxView.FocusedRowHandle, DxView.GetSelectedRows()));
                }
            }
            base.OnDoubleClick(ev);
        }
    }
}
