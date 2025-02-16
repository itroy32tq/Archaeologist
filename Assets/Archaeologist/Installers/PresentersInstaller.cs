﻿using ArchaeologistCore;
using Zenject;

namespace Archaeologist
{
    public sealed class PresentersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
               Bind<ICellPresentersFactory>().
               To<CellPresentersFactory>().
               AsSingle();

            Container.
                Bind<IGridPresenter>().
                To<GridPresenter>().
                AsSingle();

            Container.
                BindInterfacesAndSelfTo<PlayerPresenter>().
                AsSingle();

            Container.
                Bind<IRewardsBagPresenter>().
                To<RewardsBagPresenter>().
                AsSingle();

            
        }
    }
}
