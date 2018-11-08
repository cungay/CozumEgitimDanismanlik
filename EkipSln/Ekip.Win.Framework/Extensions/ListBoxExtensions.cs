using DevExpress.XtraEditors;

namespace Ekip.Win.Framework
{
    public static class ListBoxExtensions
    {
        public static void SelectAll(this CheckedListBoxControl chkList)
        {
            for (int i = 0; i < chkList.ItemCount; i++)
            {
                chkList.SetItemChecked(i, true);
            }
        }

        public static void RemoveAll(this CheckedListBoxControl chkList)
        {
            for (int i = 0; i < chkList.ItemCount; i++)
            {
                chkList.SetItemChecked(i, false);
            }
        }
    }
}
