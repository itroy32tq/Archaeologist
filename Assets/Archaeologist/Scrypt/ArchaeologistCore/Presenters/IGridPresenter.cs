using System;
using System.Collections.Generic;

namespace ArchaeologistCore
{
    public interface IGridPresenter
    {
        IEnumerable<ICellPresenter> Presenters { get; }

        event Action<ICellPresenter> OnPresenterClicked;

        ICellPresenter GetPresenter(int x, int y);
        void InitialGridData();
        void LoadData(GridData data);
    }
}