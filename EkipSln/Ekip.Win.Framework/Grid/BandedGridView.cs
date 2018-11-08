using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace Ekip.Win.Framework.DevEx.Grid
{
    public class DxBandedGridView : BandedGridView
    {
        public DxBandedGridView() : this(null) { }

        public DxBandedGridView(GridControl grid) : base(grid) { }

        protected override string ViewName
        {
            get
            {
                return "DxBandedGridView";
            }
        }
    }
}
