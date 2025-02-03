using ArchaeologistCore;
using Zenject;

namespace Archaeologist
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
                BindInterfacesAndSelfTo<RewardsSystem>().
                AsSingle();

        }
    }
}
