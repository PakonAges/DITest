using UnityEngine;
using Zenject;

public class CubeSceneInstaller : MonoInstaller<CubeSceneInstaller>
{
    public SOInstaller cubesInstaller;

    public override void InstallBindings()
    {
        InstallManagers();
        InstallCubes();
    }

    public void InstallManagers() {
        Container.Bind<Saveloader>().AsSingle();
        Container.Bind<SceneLoader>().AsSingle();
        Container.Bind<Player>().AsSingle();
    }

    public void InstallCubes() {
        Container.BindInterfacesAndSelfTo<CubesManager>().AsSingle().NonLazy();
        Container.BindFactory<Cube, Cube.Factory>().FromComponentInNewPrefab(cubesInstaller.Cubes.CubePrefab).WithGameObjectName("Cube");
        Container.BindInterfacesTo<CubesSpawner>().AsSingle();
    }
}