

namespace ArchaeologistCore
{
    public sealed class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Layer { get; private set; }

        public Cell(int x, int y, int layer)
        {
            X = x;
            Y = y;

            Layer = layer;
        }

        public void Peel()
        {
            Layer--;
        }
    }
}
