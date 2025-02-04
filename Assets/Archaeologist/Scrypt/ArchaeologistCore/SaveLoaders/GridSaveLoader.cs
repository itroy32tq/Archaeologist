using SaveModule;
using System.Linq;

namespace ArchaeologistCore
{
    public sealed class GridSaveLoader : SaveLoader<IGridPresenter, GridData>
    {
        public GridSaveLoader(IGridPresenter grid, IGameRepository gameRepository) : base(grid, gameRepository)
        {
        }

        protected override GridData ConvertToData(IGridPresenter grid)
        {
            var cells = grid.Presenters.Select(x => new CellData(x)).ToArray();

            return new GridData() 
            { 
                Cells = cells
            };
        }

        protected override void SetupData(IGridPresenter grid, GridData data)
        {
            grid.LoadData(data);
        }
    }
}
