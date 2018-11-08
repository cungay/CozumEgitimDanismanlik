using System.ComponentModel;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Serializing;
using Ekip.Win.Framework.DevEx.Editors;

namespace Ekip.Win.Framework.DevEx.Grid
{
    public class DxGridColumn : GridColumn
    {
        public DxGridColumn()
        {
            if (!DesignMode)
            {
                CreateRepositoryItem();
            }
        }

        void CreateRepositoryItem()
        {
            if (listType.Trim().Length > 0)
            {
                if (this.ColumnEdit == null)
                {
                    RepositoryItemDxLookUpEdit repository = new RepositoryItemDxLookUpEdit();
                    repository.ListType = listType;
                    repository.ListDescription = ListDescription;
                    this.ColumnEdit = repository;
                }
            }
        }

        private string listType = string.Empty;

        [XtraSerializableProperty, Category("BindList")]
        public string ListType
        {
            get { return listType; }
            set
            {
                listType = value;
                if (!DesignMode)
                {
                    CreateRepositoryItem();
                }
            }
        }
        [XtraSerializableProperty, Category("BindList")]
        public string ListDescription { get; set; } = string.Empty;

        protected override void Assign(GridColumn column) {
            base.Assign(column);
        }
    }

    public class DxGridColumnCollection : GridColumnCollection
    {
        public DxGridColumnCollection(ColumnView view) : base(view) { }

        protected override GridColumn CreateColumn() { return new DxGridColumn(); }
    }
}
