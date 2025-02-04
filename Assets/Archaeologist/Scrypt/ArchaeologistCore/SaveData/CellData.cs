namespace ArchaeologistCore
{
    public struct CellData
    {
        public int X;
        public int Y;
        public int Layer;

        public CellData(ICellPresenter cell)
        {
            X = cell.X;
            Y = cell.Y;
            Layer = cell.Layer.Value;
        }
    }
}