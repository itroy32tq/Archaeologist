namespace ArchaeologistCore
{
    public sealed class Grid
    {
        public int GridSize => Cells.Length;
        public Cell[,] Cells { get; private set; }

        public Grid(int size, int maxLayers)
        {
            Cells = new Cell[size, size];

            for (int x = 0; x < size; x++)  
            {
                for (int y = 0; y < size; y++)  
                {
                    Cells[x, y] = new Cell(x,y, maxLayers);
                }
            }
        }
    }
}
