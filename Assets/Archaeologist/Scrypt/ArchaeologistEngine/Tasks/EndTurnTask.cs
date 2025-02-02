using UnityEngine;

namespace ArchaeologistEngine
{
    public sealed class EndTurnTask : Task
    {
        private readonly GameContext _context;
        private readonly TurnPipeline _turnPipeline;

        public EndTurnTask(GameContext context, TurnPipeline turnPipeline)
        {
            _context = context;
            _turnPipeline = turnPipeline;
        }

        protected override void OnRun()
        {
            _context.CheckStatus();

            Finish();
        }

        protected override void OnFinish()
        {

            Debug.Log(" Pipeline Finished!");

            _turnPipeline.ClearTasks();

            _turnPipeline.AddBaseScenario();
        }
    }
}
