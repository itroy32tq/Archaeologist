using ArchaeologistCore;
using UnityEngine;
using Zenject;

namespace ArchaeologistEngine 
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GridConfig _gridConfig;

        public override void InstallBindings()
        {
            Container.
                Bind<ICellPresentersFactory>().
                To<CellPresentersFactory>().
                AsSingle();

            Container.
                Bind<IPlayerPresenter>().
                To<PlayerPresenter>().
                AsSingle();

            Container.
                Bind<IRewardsBagPresenter>().
                To<RewardsBagPresenter>().
                AsSingle();

            Container.
                Bind<GridConfig>().
                FromInstance(_gridConfig).
                AsSingle();

            Container.
                Bind<IGridPresenter>().
                To<GridPresenter>().
                AsSingle();

            Container.
                Bind<ArchaeologistCore.Grid>().
                AsSingle();


        }
    }
}

