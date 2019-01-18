using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekip.Framework.Core
{
    [Serializable]
    public class PagedList
    {
        public PagedList(Dictionary<int, bool> source, int pageIndex)
        {
            this.Source = source;
            this.TotalCount = source.Count;
            this.PageIndex = pageIndex;
        }


        public int FileNumber { get; private set; }

        public Dictionary<int, bool> Source { get; set; }

        public int TotalCount { get; private set; }

        public int PageIndex { get; private set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalCount); }
        }
    }

    public enum NavigateAction
    {
        Next,
        Last,
        Prev,
        First
    }
}
