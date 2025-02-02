using ArchaeologistCore;
using Zenject;

namespace ArchaeologistEngine
{
    public sealed class GameDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<Grid>().
                AsSingle();

            Container.
                Bind<Player>().
                AsSingle();

            Container.
                Bind<RewardsBag>().
                AsSingle();

            Container.
                Bind<IRewardsSystem>().
                To<RewardsSystem>().
                AsSingle();

        }
    }
}
