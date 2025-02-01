using ArchaeologistCore;
using UnityEngine;

namespace ArchaeologistEngine
{
    public sealed class СhoiceCellTask : Task
    {
        private readonly IGridPresenter _gridPresenter;

        public СhoiceCellTask(IGridPresenter gridPresenter)
        {
            _gridPresenter = gridPresenter;
        }

        protected override void OnRun()
        {
            Debug.Log("СhoiceCellTask started!");

            _gridPresenter.OnPresenterClicked += PresenterClickHandler;

        }

        private void PresenterClickHandler(ICellPresenter presenter)
        {
            Finish();
        }

        protected override void OnFinish()
        {
            _gridPresenter.OnPresenterClicked -= PresenterClickHandler;
        }
    }
}
