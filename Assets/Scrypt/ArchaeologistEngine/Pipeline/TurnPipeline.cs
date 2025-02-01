namespace ArchaeologistEngine
{
    public class TurnPipeline : Pipeline
    {
        private readonly VisualPipeline _visualPipeline;

        public TurnPipeline(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
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

        private void ContinueAfterVisuals()
        {
            _visualPipeline.OnFinished -= ContinueAfterVisuals;

            _visualPipeline.ClearTasks();

            base.OnTaskFinished();
        }
    }
}
