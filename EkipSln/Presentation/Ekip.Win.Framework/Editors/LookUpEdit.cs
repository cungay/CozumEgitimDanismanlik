using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Ekip.Framework.UI.DevEx.Editors
{
    public class DxLookUpEdit : LookUpEdit
    {
        static DxLookUpEdit()
        {
            RepositoryItemDxLookUpEdit.RegisterDxLookUpEdit();
        }

        public DxLookUpEdit()
        {
        }

        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemDxLookUpEdit.EditorName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemDxLookUpEdit Properties
        {
            get
            {
                return base.Properties as RepositoryItemDxLookUpEdit;
            }
        }
    }
}
