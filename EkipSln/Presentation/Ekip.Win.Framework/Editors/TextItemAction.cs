using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Ekip.Framework.UI.XAF;

namespace Ekip.Framework.UI.DevEx.Editors
{
    public class TextItemAction : Action
    {
        public TextItemAction(BarEditItem barEditItem)
            : base(barEditItem)
        {
            RepositoryItemTextEdit edit = (RepositoryItemTextEdit)((BarEditItem)barEditItem).Edit;
            edit.EditValueChangedFiringMode = EditValueChangedFiringMode.Buffered;
            edit.ValidateOnEnterKey = true;
            edit.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EditItem.Manager.ActiveEditItemLink.PostEditor();
                Actions.PerformAction(this, sender, e);
            }
        }

        public BarEditItem EditItem
        {
            get { return Control as BarEditItem; }
        }

        public override bool Visible
        {
            get
            {
                return EditItem.Visibility != BarItemVisibility.Never;
            }
            set
            {
                if (value)
                {
                    EditItem.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    EditItem.Visibility = BarItemVisibility.Never;
                }
            }
        }

        public override bool Enabled { get { return EditItem.Enabled; } set { EditItem.Enabled = value; } }
    }
}
