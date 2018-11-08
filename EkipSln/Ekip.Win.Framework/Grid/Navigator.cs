using System.ComponentModel;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.NavigatorButtons;

namespace Ekip.Win.Framework.DevEx.Grid
{
    public class DxNavigator : GridControlNavigator {
        public DxNavigator(GridControl control) : base(control) { }
        protected override NavigatorButtonsBase CreateButtons() {
            return new DxNavigatorButtons(this);
        }
    }

    [TypeConverter("System.ComponentModel.ExpandableObjectConverter, System")]
    public class DxNavigatorButtons : ControlNavigatorButtons {
        public DxNavigatorButtons(INavigatorOwner owner) : base(owner) { }
        protected override NavigatorButtonCollectionBase CreateNavigatorButtonCollection() {
            return new DxNavigatorButtonCollection(this);
        }
    }

    public class DxNavigatorButtonCollection : ControlNavigatorButtonCollection {
        public DxNavigatorButtonCollection(NavigatorButtonsBase buttons) : base(buttons) { }
        protected override void CreateButtons(NavigatorButtonsBase buttons) {
            base.CreateButtons(buttons);
            AddButton(new DxNavigatorButtonHelper(buttons));
        }
    }

    public class DxNavigatorButtonHelper : ControlNavigatorButtonHelperBase {
        public DxNavigatorButtonHelper(NavigatorButtonsBase buttons) : base(buttons) { }
        public override NavigatorButtonType ButtonType { get { return NavigatorButtonType.Custom; } }
        public override bool Enabled { get { return true; } }
        protected override void DoDataClick() { }
    }
}
