using UnityEngine;

namespace ArchaeologistEngine
{
    public sealed class StartTurnTask : Task
    {
        private readonly GameContext _context;

        public StartTurnTask(GameContext context)
        {
            _context = context;
        }

        protected override void OnRun()
        {
            Debug.Log(" Pipeline Started! ");

            _context.CheckStatus();

            Finish();
        }
    }
}
