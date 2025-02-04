using ArchaeologistCore;
using SaveModule;
using Zenject;

namespace Assets.Archaeologist.Installers
{
    public sealed class SaveModulelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<IGameRepository>().
                To<GameRepository>().
                AsSingle().
                NonLazy();

            Container.
                Bind<ISaveLoader>().
                To<GridSaveLoader>().
                AsSingle().
                NonLazy();

            Container.
                Bind<ISaveLoader>().
                To<PlayerSaveLoader>().
                AsSingle().
                NonLazy();

            Container.
                Bind<ISaveLoader>().
                To<RewardsBagSaveLoader>().
                AsSingle().
                NonLazy();
        }
    }
}
