using ArchaeologistUI;
using Zenject;

namespace ArchaeologistEngine
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GridView>().
                FromComponentInHierarchy().
                AsSingle();

            Container.Bind<Runner>().
                FromComponentInHierarchy().
                AsSingle();

        }
    }
}

