using ArchaeologistEngine;
using Zenject;

namespace ArchaeologistEngine
{
    public sealed class PipelineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<TurnPipeline>().
                To<TurnPipeline>().
                AsSingle();

            Container.
                Bind<VisualPipeline>().
                To<VisualPipeline>().
                AsSingle();
        }
    }
}
