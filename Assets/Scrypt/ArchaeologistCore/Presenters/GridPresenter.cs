namespace ArchaeologistCore
{
    public sealed class GridPresenter
    {
        private readonly Grid _grid;
        public Cell[,] Cells => _grid.Cells;

        public GridPresenter(Grid grid)
        {
            _grid = grid;
        }
    }
}
