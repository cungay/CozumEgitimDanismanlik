using System;

namespace Ekip.Win.Framework.DevEx.Grid
{
    public class DxRowClickArgs: EventArgs
    {
        public int CurrentRowIndex { get; } = -1;

        public bool Cancel { get; set; } = false;

        public int[] SelectedRows { get; } = null;

        public object CurrentRow { get; } = null;

        public DxRowClickArgs(object row, int rowIndex, int[] selectedRows)
        {
            this.CurrentRow = row;
            this.CurrentRowIndex = rowIndex;
            this.SelectedRows = selectedRows;
        }
    }
}
