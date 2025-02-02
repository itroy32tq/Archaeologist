using ArchaeologistUI;
using Zenject;

namespace ArchaeologistEngine
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GridView>().
                FromComponentInHierarchy().
                AsSingle();

            Container.BindInterfacesAndSelfTo<Runner>().
                FromComponentInHierarchy().
                AsSingle();

        }
    }
}

