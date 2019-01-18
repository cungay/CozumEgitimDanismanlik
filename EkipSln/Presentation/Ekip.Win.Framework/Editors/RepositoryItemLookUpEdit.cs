using System.Drawing;
using System.Reflection;
using System.ComponentModel;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;

namespace Ekip.Framework.UI.DevEx.Editors
{
    [UserRepositoryItem("RegisterDxLookUpEdit")]
    public class RepositoryItemDxLookUpEdit : RepositoryItemLookUpEdit
    {
        static RepositoryItemDxLookUpEdit()
        {
            RegisterDxLookUpEdit();
        }

        public RepositoryItemDxLookUpEdit() { /*this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;*/ }

        public const string EditorName = "DxLookUpEdit";

        public override string EditorTypeName { get { return EditorName; } }

        public static void RegisterDxLookUpEdit()
        {
            Image img = null;
            try
            {
                img = (Bitmap)Image.FromStream(Assembly.GetExecutingAssembly().
                  GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"));
            }
            catch { }
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName,
                typeof(DxLookUpEdit),
                typeof(RepositoryItemDxLookUpEdit),
                typeof(LookUpEditBaseViewInfo), new ButtonEditPainter(), true, img));
        }


        [Category("BindList")]
        public string ListDescription { get; set; } = string.Empty;

        [Category("BindList")]
        public string ListType { get; set; } = string.Empty;

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemDxLookUpEdit source = item as RepositoryItemDxLookUpEdit;
                if (source == null) return;
                this.ListDescription = source.ListDescription;
                this.ListType = source.ListType;
            }
            finally { EndUpdate(); }
        }
    }
}
