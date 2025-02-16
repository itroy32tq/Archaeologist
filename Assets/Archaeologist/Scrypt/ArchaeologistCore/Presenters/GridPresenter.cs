﻿using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace ArchaeologistCore
{
    public sealed class GridPresenter : IGridPresenter, IDisposable
    {
        private readonly Grid _grid;
        private ICellPresenter[,] _cellPresenters;
        private readonly CompositeDisposable _disposable = new();
        private readonly ICellPresentersFactory _cellPresentersFactory;

        public event Action<ICellPresenter> OnPresenterClicked = delegate { };
        public List<(ICellPresenter, Action<ICellPresenter>)> _actons = new();
        public IEnumerable<ICellPresenter> Presenters => _cellPresenters.Cast<ICellPresenter>();

        public GridPresenter(Grid grid, ICellPresentersFactory factory)
        {
            _grid = grid;

            _cellPresenters = new CellPresenter[grid.GridSize, grid.GridSize];

            _cellPresentersFactory = factory;

            InitialGridData();
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

                    var presenter = _cellPresentersFactory.Create(_grid.Cells[x, y]);

                    _cellPresenters[x,y] = presenter;

                    presenter.OnCellClicked += HandlePresenterClicked;

                    _actons.Add((presenter, HandlePresenterClicked));
                }
            }
        }

        private void HandlePresenterClicked(ICellPresenter presenter)
        {

            OnPresenterClicked.Invoke(presenter);
        }

        public void LoadData(GridData data)
        {
            int maxX = 0;
            int maxY = 0;

            foreach (var cell in data.Cells)
            {
                if (cell.X > maxX) maxX = cell.X;
                if (cell.Y > maxY) maxY = cell.Y;
            }

            _cellPresenters = new ICellPresenter[maxX + 1, maxY + 1];

            foreach (var cellData in data.Cells)
            {
                var cell = new Cell(cellData.X, cellData.Y, cellData.Layer);

                _grid.ReplaceCell(cell);

                _cellPresenters[cellData.X, cellData.Y] = _cellPresentersFactory.Create(cell);
            }

        }

        public void Dispose()
        {
            foreach (var (presenter, handler) in _actons)
            {
                presenter.OnCellClicked -= handler;
            }

            _actons.Clear();

            _disposable.Dispose();
        }
    }
}
