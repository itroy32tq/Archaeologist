namespace ArchaeologistEngine
{
    public class TurnPipeline : Pipeline
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly IServiceFactory _serviceFactory;

        public TurnPipeline(VisualPipeline visualPipeline, IServiceFactory serviceFactory)
        {
            _visualPipeline = visualPipeline;
            _serviceFactory = serviceFactory;
        }

        protected override void OnTaskFinished()
        {
            _visualPipeline.OnFinished += ContinueAfterVisuals;

            if (_visualPipeline.HasTasks)
            {
                _visualPipeline.Run();
            }
            else
            {
                ContinueAfterVisuals();
            }
        }

        public void AddBaseScenario()
        {
            AddTask(_serviceFactory.Create<StartTurnTask>());
            AddTask(_serviceFactory.Create<ChoiceCellTask>());
            AddTask(_serviceFactory.Create<EndTurnTask>());
        }

        private void ContinueAfterVisuals()
        {
            _visualPipeline.OnFinished -= ContinueAfterVisuals;

            _visualPipeline.ClearTasks();

            base.OnTaskFinished();
        }
    }
}
