using ArchaeologistEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using Zenject;

public class Runner : MonoBehaviour, IInitializable, IDisposable
{
    private TurnPipeline _turnPipeline;

    public void Dispose()
    {
        _turnPipeline.ClearTasks();
        _turnPipeline.OnFinished -= OnTurnPipelineFinished;
    }

    [Inject]
    public void Construct(TurnPipeline turnPipeline)
    {
        _turnPipeline = turnPipeline;
    }

    [Button]
    public void Run()
    {
        _turnPipeline.Run();
    }

    private void OnTurnPipelineFinished()
    {
        _turnPipeline.Run();
    }

    void IInitializable.Initialize()
    {
        _turnPipeline.OnFinished += OnTurnPipelineFinished;

        _turnPipeline.AddBaseScenario();
    }

}
