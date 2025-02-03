using ArchaeologistUI;
using Zenject;

namespace Archaeologist
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

