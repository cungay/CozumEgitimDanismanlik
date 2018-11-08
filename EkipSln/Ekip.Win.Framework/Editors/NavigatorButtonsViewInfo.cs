using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;

namespace Ekip.Win.Framework.DevEx.Editors
{
    public class DxNavigatorButtonsViewInfo : NavigatorButtonsViewInfo
    {
        public DxNavigatorButtonsViewInfo(NavigatorButtonsBase buttons)
            : base(buttons)
        {
            
        }

        protected override NavigatorTextViewInfo CreateTextViewInfo()
        {
            return new DxNavigatorTextViewInfo(this);
        }
    }
}
