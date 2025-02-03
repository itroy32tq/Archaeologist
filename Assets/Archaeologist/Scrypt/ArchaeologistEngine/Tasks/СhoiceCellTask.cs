using ArchaeologistCore;

namespace ArchaeologistEngine
{
    public sealed class ChoiceCellTask : Task
    {
        private readonly IGridPresenter _gridPresenter;
        private readonly VisualPipeline _visualPipeline;

        public ChoiceCellTask(IGridPresenter gridPresenter, VisualPipeline visualPipeline)
        {
            _gridPresenter = gridPresenter;

            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {

            _gridPresenter.OnPresenterClicked += PresenterClickHandler;

        }

        private void PresenterClickHandler(ICellPresenter presenter)
        {

            _visualPipeline.AddTask(new BaunceCellVisualTask(presenter));

            Finish();
        }

        protected override void OnFinish()
        {

            _gridPresenter.OnPresenterClicked -= PresenterClickHandler;
        }
    }
}
