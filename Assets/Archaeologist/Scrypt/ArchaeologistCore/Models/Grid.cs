using UnityEngine;

namespace ArchaeologistCore
{
    public sealed class Grid
    {
        public int GridSize => Cells.GetLength(0);
        public Cell[,] Cells { get; private set; }

        public Grid(GridConfig config)
        {
            var size = config.GridSize;

            var maxLayers = config.MaxLayers;

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
