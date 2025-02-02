using ArchaeologistCore;
using Cysharp.Threading.Tasks;

namespace ArchaeologistEngine
{
    public sealed class BaunceCellVisualTask : Task
    {
        private readonly ICellPresenter _cellPresenter;

        public BaunceCellVisualTask(ICellPresenter cellPresenter)
        {
            _cellPresenter = cellPresenter;
        }

        protected override void OnRun()
        {
            RunAnimation().Forget();
        }

        private async UniTask RunAnimation()
        {

            await _cellPresenter.RequestBounce();

            Finish();
        }
    }
}
