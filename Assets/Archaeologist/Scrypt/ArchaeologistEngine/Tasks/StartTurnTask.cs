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


            Finish();
        }
    }
}
