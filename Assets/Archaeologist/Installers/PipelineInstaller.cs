using ArchaeologistEngine;
using Zenject;

namespace Archaeologist
{
    public sealed class PipelineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<TurnPipeline>().
                AsSingle();

            Container.
                Bind<VisualPipeline>().
                AsSingle();

            Container.
                Bind<StartTurnTask>().
                AsTransient();
            
            Container.
                Bind<ChoiceCellTask>().
                AsTransient();

            Container.
                Bind<EndTurnTask>().
                AsTransient();

            Container.
                Bind<IServiceFactory>().
                To<ServiceFactory>().
                AsSingle();

            Container.
                Bind<GameContext>().
                AsSingle();

        }
    }
}
