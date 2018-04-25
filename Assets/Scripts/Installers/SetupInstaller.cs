using UnityEngine;
using Zenject;

public class SetupInstaller : MonoInstaller<SetupInstaller>
{
    public override void InstallBindings()
    {
        InstallManagers();
    }

    public void InstallManagers() {

        Container.Bind<SceneLoader>().AsSingle();
        Container.Bind<Player>().AsSingle();
    }
}