namespace ArchaeologistCore
{
    public sealed class CellPresentersFactory : ICellPresentersFactory
    {
        private readonly CellConfig _config;

        public CellPresentersFactory(CellConfig config)
        {
            _config = config;
        }

        public ICellPresenter Create(Cell cell)
        {
            return new CellPresenter(cell, _config);
        }
    }
}
