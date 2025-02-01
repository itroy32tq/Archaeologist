namespace ArchaeologistCore
{
    public interface ICellPresentersFactory
    {
        ICellPresenter Create(Cell cell);
    }
}