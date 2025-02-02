using System;
using System.Collections.Generic;

namespace ArchaeologistEngine
{
    public abstract class Pipeline
    {
        public event Action OnFinished;

        private readonly List<Task> _tasks = new();
        protected List<Task> Tasks => _tasks;

        private int _currentTaskIndex;
        public bool HasTasks => Tasks.Count > 0;

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public void ClearTasks()
        {
            _tasks.Clear();
        }

        public void Run()
        {
            _currentTaskIndex = 0;

            RunNextTask();
        }

        private void RunNextTask()
        {
            if (_currentTaskIndex >= _tasks.Count)
            {
                OnFinished?.Invoke();
                return;
            }

            _tasks[_currentTaskIndex].Run(OnTaskFinished);
        }

        protected virtual void OnTaskFinished()
        {
            _currentTaskIndex++;

            RunNextTask();
        }
    }
}
