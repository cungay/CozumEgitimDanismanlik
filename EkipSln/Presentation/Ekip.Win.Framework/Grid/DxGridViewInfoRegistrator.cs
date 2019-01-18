using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid;

namespace Ekip.Framework.UI.DevEx.Grid
{
    public class DxGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return "DxGridView"; } }
        public override BaseView CreateView(GridControl grid) { return new DxGridView(grid as GridControl); }
        public override BaseViewPainter CreatePainter(BaseView view) { return new DxGridPainter(view as DxGridView); }
    }
    public class DxBandedGridViewInfoRegistrator : BandedGridInfoRegistrator
    {
        public override string ViewName { get { return "DxBandedGridView"; } }
        public override BaseView CreateView(GridControl grid) { return new DxBandedGridView(grid as GridControl); }
        public override BaseViewPainter CreatePainter(BaseView view) { return new DxBandedGridPainter(view as DxBandedGridView); }
    }
}
