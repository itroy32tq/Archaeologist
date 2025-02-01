using System.Collections.Generic;

namespace ArchaeologistCore
{
    public interface IGridPresenter
    {
        IEnumerable<ICellPresenter> Presenters { get; }

        ICellPresenter GetPresenter(int x, int y);
        void InitialGridData();
    }
}