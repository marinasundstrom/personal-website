using System.Collections.Generic;

namespace PersonalSite.Components
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public PagedResult()
        {
            Items = new List<T>();
        }
    }
}
