using System.Collections.Generic;
using System.Linq;

namespace ArchaeologistCore
{
    public sealed class GridPresenter : IGridPresenter
    {
        private readonly Grid _grid;
        private readonly ICellPresentersFactory _cellPresentersFactory;

        private readonly ICellPresenter[,] _cellPresenters;
        public IEnumerable<ICellPresenter> Presenters => _cellPresenters.Cast<ICellPresenter>();

        public GridPresenter(Grid grid, ICellPresentersFactory factory)
        {
            _grid = grid;

            _cellPresenters = new CellPresenter[grid.GridSize, grid.GridSize];

            _cellPresentersFactory = factory;
        }

        public ICellPresenter GetPresenter(int x, int y)
        {
            return _cellPresenters[x,y];
        }

        public void InitialGridData()
        {
            for (int x = 0; x < _grid.GridSize; x++)
            {
                for (int y = 0; y < _grid.GridSize; y++)
                {
                    _cellPresenters[x,y] = _cellPresentersFactory.Create(_grid.Cells[x, y]);
                }
            }

        }
    }
}
