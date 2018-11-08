using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace Ekip.Win.Framework
{
    public static class GridExtension
    {
        public static List<T> GetRows<T>(this GridView view)
            where T : class, new()
        {
            List<T> result = new List<T>();
            try
            {
                int[] rowIndex = view.GetSelectedRows();

                for (int i = 0; i < rowIndex.Length; i++)
                {
                    int index = rowIndex[i];
                    T row = (T)(view.DataSource as IListSource).GetList()[i];
                    result.Add(row);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static T GetRow<T>(this GridView view) where T : class
        {
            T row = null;

            try
            {
                row = (T)view.GetRow(view.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return row;
        }

        public static void PrintPreview(this GridControl[] grids)
        {
            PrintingSystem ps = new PrintingSystem();
            CompositeLink compositeLink = new CompositeLink();
            compositeLink.PrintingSystem = ps;

            foreach (GridControl grid in grids)
            {
                PrintableComponentLink link = new PrintableComponentLink();
                link.Component = grid;
                compositeLink.Links.Add(link);
            }

            compositeLink.CreateDocument();
            compositeLink.ShowPreview();
        }

        public static void PrintPreview(this GridControl grid)
        {
            PrintingSystem ps = new PrintingSystem();
            CompositeLink compositeLink = new CompositeLink();
            compositeLink.PrintingSystem = ps;

            PrintableComponentLink link = new PrintableComponentLink();
            link.Component = grid;
            compositeLink.Links.Add(link);

            compositeLink.CreateDocument();
            compositeLink.ShowPreview();
        }
    }
}
