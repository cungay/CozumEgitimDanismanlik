using System;
using System.Linq;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using Ekip.Win.Framework.DevEx.Grid;

namespace Ekip.Win.Framework.DevEx.Editors
{
    public class DxDataNavigatorButtons : DataNavigatorButtons
    {
        public DxDataNavigatorButtons(INavigatorOwner owner)
            : base(owner)
        {
            this.Append.Hint = "Ekle";
            this.Remove.Hint = "Sil";
            this.Next.Hint = "Sonraki";
            this.Last.Hint = "Önceki";
        }

        public XtraForm TryGetFormByName(string frmname)
        {
            var formType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(a => a.BaseType == typeof(XtraForm) && a.Name == frmname)
                .FirstOrDefault();

            if (formType == null)
                return null;

            return (XtraForm)Activator.CreateInstance(formType);
        }

        public override void DoClick(NavigatorButtonBase button)
        {
            DxGridControl grid = (this.OwnerControl as DxDataNavigator).GridControl;

            if (grid != null)
            {
                DxGridView view = grid.FocusedView as DxGridView;

                if (button.ButtonType == NavigatorButtonType.Remove)
                {
                    if (grid.DeleteRows())
                    {
                        view.DeleteRow(view.FocusedRowHandle);
                    }
                }
                else
                {
                    base.DoClick(button);
                }
            }
        }
        protected override NavigatorButtonsViewInfo CreateViewInfo()
        {
            return base.CreateViewInfo();
        }
    }
}
