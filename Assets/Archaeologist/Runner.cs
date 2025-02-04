using ArchaeologistEngine;
using ArchaeologistUI;
using SaveModule;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Runner : MonoBehaviour, IInitializable, IDisposable
{
    private TurnPipeline _turnPipeline;
    private List<ISaveLoader> _saveLoaders;
    private IGameRepository _gameRepository;
    private GridView _gridView;

    public void Dispose()
    {
        _turnPipeline.ClearTasks();
        _turnPipeline.OnFinished -= OnTurnPipelineFinished;
    }

    [Inject]
    public void Construct(TurnPipeline turnPipeline, IGameRepository gameRepository, List<ISaveLoader> saveLoaders, GridView gridView)
    {
        _turnPipeline = turnPipeline;
        _gameRepository = gameRepository;
        _saveLoaders = saveLoaders;
        _gridView = gridView;
    }

    [Button]
    public void Run()
    {
        _turnPipeline.Run();
    }

    [Button]
    public void Save()
    {
        foreach (ISaveLoader saveLoader in _saveLoaders)
        {
            saveLoader.Save();
        }
    }

    [Button]
    public void SaveStateToFile()
    {
        _gameRepository.SaveGameState();
    }

    [Button]
    public void LoadStateFromFile()
    {
        _gameRepository.LoadGameState();
    }

    private void OnTurnPipelineFinished()
    {
        _turnPipeline.Run();
    }

    [Button]
    public void Load()
    {
        foreach (var saveLoader in _saveLoaders)
        {
            saveLoader.Load();
        }

        _gridView.Initialize();
    }

    void IInitializable.Initialize()
    {
        _turnPipeline.OnFinished += OnTurnPipelineFinished;

        _turnPipeline.AddBaseScenario();
    }

}
