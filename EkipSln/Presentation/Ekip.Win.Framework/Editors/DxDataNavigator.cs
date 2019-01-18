using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Ekip.Framework.UI.DevEx.Grid;

namespace Ekip.Framework.UI.DevEx.Editors
{
    public class DxDataNavigator : DataNavigator
    {
        protected override NavigatorButtonsBase CreateButtons()
        {
            return new DxDataNavigatorButtons(this);
        }

        public DxDataNavigator()
        {
            this.Buttons.NextPage.Visible = false;
            this.Buttons.Last.Visible = false;
            this.Buttons.PrevPage.Visible = false;
            this.Buttons.First.Visible = false;
            this.Buttons.CancelEdit.Visible = false;
            this.Buttons.EndEdit.Visible = false;

            this.ButtonStyle = BorderStyles.Default;
            this.TextLocation = NavigatorButtonsTextLocation.Center;
            this.TextStringFormat = "Kayıt {0} - {1}";
        }

        public DxGridControl GridControl { get; set; } = null;

        public override BorderStyles BorderStyle
        {
            get
            {
                return BorderStyles.Simple;
            }
            set
            {
                base.BorderStyle = value;
            }
        }
    }
}
