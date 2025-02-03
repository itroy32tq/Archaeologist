using ArchaeologistCore;
using UnityEngine;

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
            Debug.Log("СhoiceCellTask started! ждем клика от пользователя ");

            _gridPresenter.OnPresenterClicked += PresenterClickHandler;

        }

        private void PresenterClickHandler(ICellPresenter presenter)
        {
            Debug.Log(" ждем отработки анимации ");

            _visualPipeline.AddTask(new BaunceCellVisualTask(presenter));

            Finish();
        }

        protected override void OnFinish()
        {
            _gridPresenter.OnPresenterClicked -= PresenterClickHandler;
        }
    }
}
