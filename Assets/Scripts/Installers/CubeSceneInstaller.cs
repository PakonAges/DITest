using UnityEngine;
using Zenject;

public class CubeSceneInstaller : MonoInstaller<CubeSceneInstaller>
{

    public GameObject CubePrefab;

    public override void InstallBindings()
    {
        InstallManagers();
        InstallCubes();
    }

    public void InstallManagers() {

        Container.Bind<SceneLoader>().AsSingle();
    }

    public void InstallCubes() {
        Container.Bind<ITickable>().To<CubesManager>().AsSingle();
        Container.Bind<CubesManager>().AsSingle().NonLazy();
        Container.BindFactory<Cube, Cube.Factory>().FromComponentInNewPrefab(CubePrefab).WithGameObjectName("Cube");
        Container.BindInterfacesTo<CubesSpawner>().AsSingle();
    }
}