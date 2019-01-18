using System;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;

namespace Ekip.Framework.UI.DevEx.Editors
{
    public class DxNavigatorTextViewInfo : NavigatorTextViewInfo
    {
        public DxNavigatorTextViewInfo(NavigatorButtonsViewInfo viewInfo)
            : base(viewInfo)
        {
            
        }

        protected override string GetText(int currentRecord, int count)
        {
            return String.Format("Total = {0}; Current = {1}", count.ToString("c"), currentRecord - 1);
        }
        public override Size MinSize
        {
            get
            {
                Size size = base.MinSize;
                size.Width = 180;
                return size;
            }
        }
    }
}
