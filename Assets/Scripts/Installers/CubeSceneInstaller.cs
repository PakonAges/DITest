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
        Container.BindInterfacesAndSelfTo<CubesManager>().AsSingle().NonLazy();
        Container.BindFactory<Cube, Cube.Factory>().FromComponentInNewPrefab(CubePrefab).WithGameObjectName("Cube");
        Container.BindInterfacesTo<CubesSpawner>().AsSingle();
    }
}