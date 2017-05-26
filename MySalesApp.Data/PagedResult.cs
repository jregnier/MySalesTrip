using System.Collections.Generic;

namespace MySalesApp.Data
{
    public class PagedResult<TEntity>
    {
        private IEnumerable<TEntity> _items;
        private int _totalCount;

        public PagedResult(IEnumerable<TEntity> items, int totalCount)
        {
            this._items = items;
            this._totalCount = totalCount;
        }

        public IEnumerable<TEntity> Items
        {
            get
            {
                return this._items;
            }
        }
        public int TotalCount
        {
            get
            {
                return this._totalCount;
            }
        }
    }
}
