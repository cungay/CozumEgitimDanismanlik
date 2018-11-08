using AppFramework;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Ekip.Win.Framework.Forms;

namespace Ekip.Win.Framework.DevEx.Editors
{
    public class BarItemAction : Action
    {
        public BarItemAction(BarItem barItem)
            : base(barItem)
        {
            barItem.ItemClick += new ItemClickEventHandler(DoItemClick);
        }

        public BarItem Item { get { return Control as BarItem; } }

        private RibbonControl Ribbon
        {
            get 
            {
                return Item.Manager.Form as DevExpress.XtraBars.Ribbon.RibbonControl;
            }
        }

        public override bool Visible
        {
            get { return Item.Visibility != BarItemVisibility.Never; }
            set
            {
                if (value)
                {
                    Item.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    Item.Visibility = BarItemVisibility.Never;
                }
            }
        }

        public override bool Enabled { get { return Item.Enabled; } set { Item.Enabled = value; } }

        public override bool IsDown
        {
            get
            {
                if (Item is BarButtonItem)
                    return (Item as BarButtonItem).Down;
                return false;
            }
            set
            {
                if (Item is BarButtonItem)
                    (Item as BarButtonItem).Down = value;
            }
        }

        void DoItemClick(object sender, ItemClickEventArgs e)
        {
            var form = this.Ribbon.FindForm();

            using (new WaitCursor(form))
            {
                e.Item.Enabled = false;

                form.Validate();

                Actions.PerformAction(this, sender, e);
            }
        }
    }
}
