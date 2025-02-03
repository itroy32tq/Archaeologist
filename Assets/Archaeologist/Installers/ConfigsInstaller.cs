using ArchaeologistCore;
using UnityEngine;
using Zenject;

namespace Archaeologist
{
    public sealed class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private GridConfig _gridConfig;
        [SerializeField] private CellConfig _cellConfig;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private RewardConfig _rewardConfig;

        public override void InstallBindings()
        {
            Container.
               Bind<GridConfig>().
               FromInstance(_gridConfig).
               AsSingle();

            Container.
               Bind<CellConfig>().
               FromInstance(_cellConfig).
               AsSingle();

            Container.
               Bind<PlayerConfig>().
               FromInstance(_playerConfig).
               AsSingle();

            Container.
               Bind<RewardConfig>().
               FromInstance(_rewardConfig).
               AsSingle();
        }
    }
}
